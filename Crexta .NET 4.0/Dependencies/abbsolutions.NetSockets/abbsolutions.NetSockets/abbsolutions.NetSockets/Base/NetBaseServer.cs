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
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace abbSolutions.NetSockets
{
    /// <summary>
    /// Echo modes.
    /// </summary>
    public enum NetEchoMode 
    { 
        None, 
        EchoAll, 
        EchoAllExceptSender, 
        EchoSender 
    };

    /// <summary>
    /// Abstract generic base class providing core server functionality.
    /// </summary>
    /// <typeparam name="T">The type of data communicated.</typeparam>
    public abstract class NetBaseServer<T>
    {
        protected List<Guid> clients;
        protected Dictionary<Guid, NetBaseStream<T>> streams;
        protected TcpListener tcp;
        protected Thread thread;
        protected bool active;

        /// <summary>
        /// Occurs when the server is started.
        /// </summary>
        public event NetStartedEventHandler OnStarted;

        /// <summary>
        /// Occurs when the server is stopped.
        /// </summary>
        public event NetStoppedEventHandler OnStopped;

        /// <summary>
        /// Occurs when an error occurs.
        /// </summary>
        public event NetExceptionEventHandler OnError;

        /// <summary>
        /// Occurs when a new client connects.
        /// </summary>
        public event NetClientConnectedEventHandler OnClientConnected;

        /// <summary>
        /// Occurs when a new client is accepted.
        /// </summary>
        public event NetClientAcceptedEventHandler OnClientAccepted;

        /// <summary>
        /// Occurs when a new client is rejected.
        /// </summary>
        public event NetClientRejectedEventHandler OnClientRejected;

        /// <summary>
        /// Occurs when a client disconnects.
        /// </summary>
        public event NetClientDisconnectedEventHandler OnClientDisconnected;

        /// <summary>
        /// Occurs when data is received from a client.
        /// </summary>
        public event NetClientReceivedEventHandler<T> OnReceived;

        /// <summary>
        /// Gets the max number of clients allowed.
        /// </summary>
        public int MaxClients
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the listening port number.
        /// </summary>
        public int Port
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the server is online.
        /// </summary>
        public bool IsOnline
        {
            get { return active; }
        }

        /// <summary>
        /// Gets or sets the server tick rate.
        /// </summary>
        public int TickRate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets an array of local addresses.
        /// </summary>
        public IPAddress[] LocalAddresses
        {
            get { return Dns.GetHostAddresses(Dns.GetHostName()); }
        }

        /// <summary>
        /// Gets the default address used.
        /// </summary>
        public IPAddress DefaultAddress
        {
            get
            {
                if (LocalAddresses.Length > 0)
                    return LocalAddresses[0];
                else
                    return IPAddress.None;
            }
        }

        /// <summary>
        /// Gets or sets the listening address.
        /// </summary>
        public IPAddress Address
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets an array of connected client guids.
        /// </summary>
        public Guid[] Clients
        {
            get { return clients.ToArray(); }
        }

        /// <summary>
        /// Gets an array of connected client guids.
        /// </summary>
        public List<Guid> ClientsList
        {
            get { return clients; }
        }

        /// <summary>
        /// Gets the number of connected clients.
        /// </summary>
        public int ClientCount
        {
            get { return clients.Count; }
        }

        /// <summary>
        /// Gets a dictionary of client streams.
        /// </summary>
        public Dictionary<Guid, NetBaseStream<T>> ClientStreams
        {
            get { return streams; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the server should echo all received data.
        /// </summary>
        public NetEchoMode EchoMode
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the NetBaseServer class.
        /// </summary>
        public NetBaseServer()
        {
            this.clients = new List<Guid>();
            this.streams = new Dictionary<Guid, NetBaseStream<T>>();
            this.TickRate = 1;
            this.EchoMode = NetEchoMode.None;
        }

        /// <summary>
        /// Starts the server on the specified port with no client limit, on the default address
        /// </summary>
        /// <param name="port">The listening port.</param>
        public void Start(int port)
        {
            Start(port, 0);
        }

        /// <summary>
        /// Starts the server on the specified port and client limit, on the default address
        /// </summary>
        /// <param name="port">The listening port.</param>
        /// <param name="maxClients">The maximum number of allowed clients.</param>
        public void Start(int port, int maxClients)
        {
            Start(DefaultAddress, port);
        }

        /// <summary>
        /// Starts the server on the specified port and address, with no client limit.
        /// </summary>
        /// <param name="address">The listening address.</param>
        /// <param name="port">The listening port.</param>
        public void Start(IPAddress address, int port)
        {
            Start(address, port, 0);
        }

        /// <summary>
        /// Starts the server on the specified port, address, and client limit.
        /// </summary>
        /// <param name="address">The listening address.</param>
        /// <param name="port">The listening port.</param>
        /// <param name="maxClients">The maximum number of allowed clients.</param>
        public void Start(IPAddress address, int port, int maxClients)
        {
            if (active)
            {
                throw new Exception("Server already started.");
            }
            else
            {
                this.Address = address;
                this.Port = port;
                this.MaxClients = maxClients;
                this.active = true;

                tcp = new TcpListener(address, port);
                tcp.Start();

                if (OnStarted != null)
                    OnStarted(this, new NetStartedEventArgs());

                thread = new Thread(new ThreadStart(ThreadedAccept));
                thread.Start();
            }
        }

        /// <summary>
        /// Stops the server manually.
        /// </summary>
        public void Stop()
        {
            Stop(NetStoppedReason.Manually);
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        protected void Stop(NetStoppedReason reason)
        {
            if (!active) 
                return;

            DisconnectAll();
            tcp.Stop();

            active = false;

            if (OnStopped != null)
                OnStopped(this, new NetStoppedEventArgs(reason));
        }

        /// <summary>
        /// Disconnect a single client.
        /// </summary>
        /// <param name="guid">The client's guid.</param>
        public void DisconnectClient(Guid guid)
        {
            if (!streams.ContainsKey(guid))
                throw new Exception("Client ID not found.");
            else
            {
                streams[guid].Stop();
            }
        }
        
        /// <summary>
        /// Disconnect all clients.
        /// </summary>
        public void DisconnectAll()
        {
            while (clients.Count > 0)
                streams[clients[0]].Stop();
        }

        /// <summary>
        /// Dispatch data to a single client.
        /// </summary>
        /// <param name="guid">The client's guid.</param>
        /// <param name="data">The data.</param>
        public void DispatchTo(Guid guid, T data)
        {
            if (!streams.ContainsKey(guid))
                throw new Exception("Client ID not found.");
            else
            {
                streams[guid].Send(data);
                /*if (OnDispatched != null)
                    OnDispatched(this, guid, data);*/
            }
        }

        /// <summary>
        /// Dispatch data to a group of clients.
        /// </summary>
        /// <param name="guid">The array of client guids.</param>
        /// <param name="data">The data.</param>
        public void DispatchTo(Guid[] guid, T data)
        {
            foreach (Guid i in guid)
                DispatchTo(i, data);
        }

        /// <summary>
        /// Dispatch data to all clients.
        /// </summary>
        /// <param name="data">The data.</param>
        public void DispatchAll(T data)
        {
            foreach (Guid i in clients)
                DispatchTo(i, data);
        }

        /// <summary>
        /// Dispatch data to all clients except a single client.
        /// </summary>
        /// <param name="guid">The client's guid.</param>
        /// <param name="data">The data.</param>
        public void DispatchAllExcept(Guid guid, T data)
        {
            foreach (Guid i in clients)
                if (i != guid)
                    DispatchTo(i, data);
        }
        
        /// <summary>
        /// The threaded loop for accepting new clients.
        /// </summary>
        protected void ThreadedAccept()
        {
            while (active)
            {
                Thread.Sleep(TickRate);
                NetBaseStream<T> stream = null;
                TcpClient tcpClient = null;
                NetworkStream ns = null;

                try
                {
                    tcpClient = tcp.AcceptTcpClient();
                    ns = tcpClient.GetStream();
                }
                catch (SocketException ex)
                {
                    if (OnError != null)
                        OnError(this, new NetExceptionEventArgs(ex));

                    if (ns != null)
                        ns.Close();

                    if (tcpClient != null)
                        tcpClient.Close();
                    continue;
                }

                //1. Create stream
                stream = CreateStream(ns, tcpClient.Client.RemoteEndPoint);
                stream.OnStopped += new NetStreamStoppedEventHandler(OnClientStopped);
                stream.OnReceived += new NetStreamReceivedEventHandler<T>(OnClientReceived);
                stream.Start();

                //2. Add guid and stream
                clients.Add(stream.GuID);
                streams.Add(stream.GuID, stream);

                //3. Create and raise connected event
                NetClientConnectedEventArgs e = new NetClientConnectedEventArgs(stream.GuID, false);
                if (OnClientConnected != null)
                    OnClientConnected(this, e);

                if ( (ClientCount < MaxClients || MaxClients == 0) && !e.Reject )
                {
                    //Raise the accepted event
                    if (OnClientAccepted != null)
                        OnClientAccepted(this, new NetClientAcceptedEventArgs(stream.GuID));
                }
                else
                {
                    //Raise the rejected event
                    if (OnClientRejected != null)
                        OnClientRejected(this, new NetClientRejectedEventArgs(stream.GuID, NetRejectedReason.Other));

                    ns.Close();
                    tcpClient.Close();
                    continue;
                }
            }

            Stop(NetStoppedReason.Manually);
        }

        /// <summary>
        /// Invoked when data is received from a client stream.
        /// </summary>
        /// <param name="stream">The client stream.</param>
        /// <param name="data">The data received.</param>
        protected void OnClientReceived(object sender, NetStreamReceivedEventArgs<T> e)
        {
            //Create args with data and server's echo mode.
            //The echo mode can be changed by the event handler...
            NetClientReceivedEventArgs<T> args = new NetClientReceivedEventArgs<T>(e.Data, EchoMode);
            if (OnReceived != null)
                OnReceived(this, args);

            try
            {
                switch (args.EchoMode)
                {
                    case NetEchoMode.EchoAll:
                        DispatchAll(e.Data);
                        break;
                    case NetEchoMode.EchoAllExceptSender:
                        DispatchAllExcept(e.Guid, e.Data);
                        break;
                    case NetEchoMode.EchoSender:
                        DispatchTo(e.Guid, e.Data);
                        break;
                    case NetEchoMode.None:
                        break;
                }
            }
            catch
            {
                //NOP
            }
        }

        /// <summary>
        /// Invoked when a client stream is stopped. Eg: the client has disconnected.
        /// </summary>
        /// <param name="stream">The client stream.</param>
        protected void OnClientStopped(object sender, NetStreamStoppedEventArgs e)
        {
            if (OnClientDisconnected != null)
                OnClientDisconnected(this, new NetClientDisconnectedEventArgs(e.Guid, e.Reason));

            clients.Remove(e.Guid);
            streams.Remove(e.Guid);
        }

        /// <summary>
        /// Returns a new instance of the appropriate stream.
        /// </summary>
        /// <param name="ns">The network stream associated with the stream.</param>
        /// <param name="ep">The end point associated with the stream.</param>
        /// <returns></returns>
        protected abstract NetBaseStream<T> CreateStream(NetworkStream ns, EndPoint ep);
    }
}
