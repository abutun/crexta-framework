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

namespace abbSolutions.NetSockets
{
    /// <summary>
    /// Abstract generic base class providing core client functionality.
    /// </summary>
    /// <typeparam name="T">The type of data communicated.</typeparam>
    public abstract class NetBaseClient<T>
    {
        /// <summary>
        /// TCP
        /// </summary>
        protected TcpClient tcp;

        /// <summary>
        /// Stream
        /// </summary>
        protected NetBaseStream<T> stream;

        /// <summary>
        /// Occurs when data has been received.
        /// </summary>
        public event NetReceivedEventHandler<T> OnReceived;

        /// <summary>
        /// Occurs when the connection is established succesfully.
        /// </summary>
        public event NetConnectedEventHandler OnConnected;

        /// <summary>
        /// Occurs when the connection is closed by the client or server.
        /// </summary>
        public event NetDisconnectedEventHandler OnDisconnected;

        /// <summary>
        /// Gets the remote host name.
        /// </summary>
        public string RemoteHost
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the remote port number.
        /// </summary>
        public int RemotePort
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the client is connected.
        /// </summary>
        public bool IsConnected
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the NetBaseStream class.
        /// </summary>
        public NetBaseClient()
        {
            IsConnected = false;
        }

        /// <summary>
        /// Connects to the server on the specified host and port.
        /// </summary>
        /// <param name="host">The remote host name.</param>
        /// <param name="port">The remote port number.</param>
        public void Connect(string host, int port)
        {
            if (IsConnected)
                Disconnect(NetStoppedReason.Manually);

            RemoteHost = host;
            RemotePort = port;

            tcp = new TcpClient();
            tcp.Connect(host, port);

            IsConnected = true;
            if (OnConnected != null)
                OnConnected(this, new NetConnectedEventArgs());

            NetworkStream ns = tcp.GetStream();
            EndPoint ep = tcp.Client.RemoteEndPoint;
            
            stream = CreateStream(ns, ep);
            stream.OnReceived += new NetStreamReceivedEventHandler<T>(stream_OnReceived);
            stream.OnStopped += new NetStreamStoppedEventHandler(stream_OnStopped);
            stream.Start();
        }

        /// <summary>
        /// Connects to the server, returns a bool indicating whether the attempt failed or succeeded.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public bool TryConnect(string host, int port)
        {
            try
            {
                Connect(host, port);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect()
        {
            Disconnect(NetStoppedReason.Manually);
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        protected void Disconnect(NetStoppedReason reason)
        {
            if (!IsConnected)
                return;

            stream.Stop();
            tcp.Close();

            IsConnected = false;
            if (OnDisconnected != null) 
                OnDisconnected(this, new NetDisconnectedEventArgs(reason));
        }

        /// <summary>
        /// Sends the provided data to the server.
        /// </summary>
        /// <param name="data">The data to be sent to the server.</param>
        public void Send(T data)
        {
            stream.Send(data);
        }

        /// <summary>
        /// Returns a new instance of an appropriate stream.
        /// </summary>
        /// <param name="ns">The network stream associated with the stream.</param>
        /// <param name="ep">The end point associated with the stream.</param>
        /// <returns></returns>
        protected abstract NetBaseStream<T> CreateStream(NetworkStream ns, EndPoint ep);
        
        /// <summary>
        /// Invoked when the internal stream receives data.
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="data"></param>
        protected void stream_OnReceived(object sender, NetStreamReceivedEventArgs<T> e)
        {
            if (OnReceived != null)
                OnReceived(this, new NetReceivedEventArgs<T>(e.Data));
        }

        /// <summary>
        /// Invoked when the interal stream is stopped.
        /// </summary>
        /// <param name="stream"></param>
        protected void stream_OnStopped(object sender, NetStreamStoppedEventArgs e)
        {
            Disconnect(e.Reason);
        }
    }
}
