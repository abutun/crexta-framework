/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	ABBSOLUTIONS INC. - Server-Client Communication Framework			*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace abbSolutions.NetSockets
{
    /// <summary>
    /// Abstract generic base class providing core stream functionality.
    /// </summary>
    /// <typeparam name="T">The type of data communicated.</typeparam>
    public abstract class NetBaseStream<T>
    {
        protected Thread thread;
        protected NetworkStream stream;
        
        /// <summary>
        /// Occurs when the stream is started.
        /// </summary>
        public event NetStreamStartedEventHandler OnStarted;

        /// <summary>
        /// Occurs when the stream is stopped.
        /// </summary>
        public event NetStreamStoppedEventHandler OnStopped;

        /// <summary>
        /// Occurs when data received from the stream.
        /// </summary>
        public event NetStreamReceivedEventHandler<T> OnReceived;

        /// <summary>
        /// Gets or sets the current clientID.
        /// </summary>
        public int ClientID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the streams guid (identifier used by server).
        /// </summary>
        public Guid GuID
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of bytes sent.
        /// </summary>
        public long DataSent
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the number of bytes received.
        /// </summary>
        public long DataReceived
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the stream is active.
        /// </summary>
        public bool IsActive
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the remote endpoint.
        /// </summary>
        public EndPoint EndPoint
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the tick rate.
        /// </summary>
        public int TickRate
        {
            get;
            set;
        }
        
        /// <summary>
        /// Initializes a new instance of the NetBaseStream class.
        /// </summary>
        /// <param name="stream">The network stream to stream from.</param>
        /// <param name="endpoint">The remote endpoint.</param>
        public NetBaseStream(NetworkStream stream, EndPoint endpoint)
        {
            GuID = System.Guid.NewGuid();
            IsActive = false;
            EndPoint = endpoint;
            TickRate = 1;

            this.stream = stream;
        }

        /// <summary>
        /// Starts the stream.
        /// </summary>
        public void Start()
        {
            IsActive = true;

            thread = new Thread(new ThreadStart(ThreadedReceive));
            thread.Start();
            
            if (OnStarted != null) 
                OnStarted(this, new NetStreamStartedEventArgs(GuID));
        }

        /// <summary>
        /// Stops the stream manually locally.
        /// </summary>
        public void Stop()
        {
            Stop(NetStoppedReason.Manually);
        }

        /// <summary>
        /// Stops the stream with a specific reason.
        /// </summary>
        /// <param name="reason">The stop reason.</param>
        protected void Stop(NetStoppedReason reason)
        {
            if (!IsActive)
                return;

            IsActive = false;
            stream.Close();

            if (OnStopped != null)
                OnStopped(this, new NetStreamStoppedEventArgs(GuID, reason));
        }

        /// <summary>
        /// Sends strictly typed data to the stream.
        /// </summary>
        /// <param name="data">The type of data.</param>
        public abstract void Send(T data);
        
        /// <summary>
        /// Sends a raw byte array to the stream.
        /// </summary>
        /// <param name="data"></param>
        protected void SendRaw(byte[] data)
        {
            byte[] bytes = data;
            if (IsActive && stream.CanWrite)
            {
                try
                {
                    stream.Write(bytes, 0, bytes.Length);
                    DataSent += bytes.LongLength;
                }
                catch (SocketException ex)
                {
                    Stop(NetStoppedReason.Remote);
                    return;
                }
            }
        }

        /// <summary>
        /// Should be implemented for handling raw bytes received from the stream.
        /// </summary>
        /// <param name="bytes"></param>
        protected abstract void ReceivedRaw(byte[] bytes);
        
        /// <summary>
        /// The threaded receive loop.
        /// </summary>
        protected void ThreadedReceive()
        {
            while (IsActive && stream.CanRead)
            {
                Thread.Sleep(TickRate);
                byte[] buffer = new byte[512];
                int recv = 0;

                try
                {
                    recv = stream.Read(buffer, 0, buffer.Length);
                    if (recv == 0)
                    {
                        Stop(NetStoppedReason.Remote);
                        return;
                    }
                    DataReceived += recv;
                }
                catch (System.IO.IOException ioex)
                {
                    Stop(NetStoppedReason.Remote);
                    return;
                }
                catch (Exception ex)
                {
                    Stop(NetStoppedReason.Exception);
                    throw ex;
                }

                if (recv < 512)
                {
                    byte[] newBuffer = new byte[recv];
                    System.Buffer.BlockCopy(buffer, 0, newBuffer, 0, recv);
                    buffer = newBuffer;
                }

                ReceivedRaw(buffer);
            }

            Stop(NetStoppedReason.Manually);
        }

        /// <summary>
        /// Raises the OnReceived event.
        /// </summary>
        /// <param name="data">The data associated with the event.</param>
        protected void RaiseOnReceived(T data)
        {
            if (OnReceived != null)
                OnReceived(this, new NetStreamReceivedEventArgs<T>(GuID, data));
        }
    }
}
