using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;
using System.Runtime.InteropServices;

namespace abbSolutions.Communication
{
	[Serializable, Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	public class CommunicationsServer : ICommunicationsServer
	{
		private static Lockable _acceptingIncomingConnectionLock = new Lockable();

		private readonly int MaxSendThreads = Properties.Settings.Default.MaxSendThreads;
		private readonly int MaxProcessThreads = Properties.Settings.Default.MaxProcessThreads;
		private readonly int MaxReceiveThreads = Properties.Settings.Default.MaxReceiveThreads;
		private readonly int MaxAcceptIncomingThreads = Properties.Settings.Default.MaxAcceptIncomingThreads;
		private readonly int MaxSimultaneousIncomingConnections = Properties.Settings.Default.MaxSimultaneousIncomingConnections;

		public CommunicationsServer() { }

		public CommunicationsServer(IPAddress listenIPAddress, int listenPort)
		{
			ListenOnLocalIP = listenIPAddress;
			ListenPort = listenPort;
		}

		public CommunicationsServer(IPAddress listenIPAddress, int listenPort, IIncomingMessageHandler incomingMessageHandler)
			: this(listenIPAddress, listenPort)
		{
			IncomingMessageHandler = incomingMessageHandler;
		}

		private long _bytesSent = 0;
		private long _bytesReceived = 0;
		private TcpListener TcpListenerObject { get; set; }
		private ThreadSafeList<IncomingConnection> _connections = new ThreadSafeList<IncomingConnection>();
		private Thread ListenThread { get; set; }
		private Thread[] SendThreads { get; set; }
		private Thread[] ReceiveThreads { get; set; }
		private Thread[] ProcessThreads { get; set; }
		private Thread[] AcceptIncomingThreads { get; set; }
		private Exception _listenerObjectException;
		private bool _listenerIsListening;

		public IPAddress ListenOnLocalIP { get; set; }
		public int ListenPort { get; set; }
		public IMapIDToControlReceiver IDToControlReceiverMap { get; set; }
		public IIncomingMessageHandler IncomingMessageHandler { get; set; }
		public long BytesSent { get { return _bytesSent; } }
		public long BytesReceived { get { return _bytesReceived; } }

		internal ThreadSafeLookup<long, ConnectionBase> _lookupConnectionByID = new ThreadSafeLookup<long, ConnectionBase>();
		public ThreadSafeList<IncomingConnection> Connections { get { return _connections; } }
		public int ConnectionCount { get { return _connections.Count; } }
		public bool WantExit { get; set; }

		public void BeginListening()
		{
			ListenThread = new ThreadStart(SetupAndCleanup).CreateAndRunThread();
			ListenThread.Priority = ThreadPriority.AboveNormal;

			SendThreads = new Thread[MaxSendThreads];
			ReceiveThreads = new Thread[MaxReceiveThreads];
			ProcessThreads = new Thread[MaxProcessThreads];
			AcceptIncomingThreads = new Thread[MaxAcceptIncomingThreads];

			while (!_listenerIsListening && _listenerObjectException == null && !WantExit)
				Thread.Sleep(100);

			if (_listenerObjectException != null)
				throw new Exception("Error setting up socket listener", _listenerObjectException);

			GlobalLogger.Log("BeginListening", "Successfully listening on port " + ListenPort.ToString(), LogSeverity.DebugInformation);

			if (!WantExit)
			{
				// Start up the send/receive/process threads
				for (int n = 0; n < MaxSendThreads; n++)
					SendThreads[n] = new ThreadStart(SendOutgoingWorker).CreateAndRunThread();

				for (int n = 0; n < MaxReceiveThreads; n++)
					ReceiveThreads[n] = new ThreadStart(ReceiveIncomingWorker).CreateAndRunThread();

				for (int n = 0; n < MaxProcessThreads; n++)
					ProcessThreads[n] = new ThreadStart(ProcessIncomingDataWorker).CreateAndRunThread();

				for (int n = 0; n < MaxAcceptIncomingThreads; n++)
				{
					AcceptIncomingThreads[n] = new ThreadStart(AcceptIncomingConnectionWorker).CreateAndRunThread();
					AcceptIncomingThreads[n].Priority = ThreadPriority.AboveNormal;
				}
			}
		}

		public void ShutdownServer()
		{
			WantExit = true;
			Thread.Sleep(100);
			if (TcpListenerObject != null) { try { TcpListenerObject.Stop(); } catch { } }
		}

		/// <summary>
		/// Finds the incoming connection associated with a particular ID
		/// </summary>
		public ICommunicationsBase FindConnectionForID(long ID)
		{
			return _lookupConnectionByID[ID];
		}

		internal int ForEachIncomingConnection(TDelegateGeneralInt<IncomingConnection> codeToExecuteForEach)
		{
			int returnValue = 0;

			for (int current = 0; current < _connections.Count; current++)
			{
				try
				{
					IncomingConnection connection = _connections._list[current];
					if (connection == null) break;

					returnValue += codeToExecuteForEach(connection);
				}
				catch { }
			}

			return returnValue;
		}

		/// <summary>
		/// Entry point for threads that processes incoming data streams
		/// </summary>
		private void ProcessIncomingDataWorker()
		{
			while (WantExit == false)
			{
				int processedMessages = ForEachIncomingConnection(delegate(IncomingConnection connection)
				{
					int processed = 0;

					// Make sure only one thread is processing message bytes from this connection at any one time
					if (connection._processLock.TryAquireLock())
					{
						try { while (connection.GetNextFullMessage()) { processed++; } }
						finally { connection._processLock.ReleaseLock(); }
					}

					return processed;
				});

				if (processedMessages == 0) { Thread.Sleep(100); }
			}
		}

		/// <summary>
		/// Entry point for the thread that sends all pending outgoing data to
		/// all connected clients
		/// </summary>
		private void SendOutgoingWorker()
		{
			while (WantExit == false)
			{
				int sentDataTo = ForEachIncomingConnection(delegate(IncomingConnection connection)
				{
					int sent = 0;

					// Make sure only one thread is sending bytes out to this connection at any one time
					if (connection._writeLock.TryAquireLock())
					{
						try { if (connection.SendBytesOutgoing() > 0) { sent++; } }
						finally { connection._writeLock.ReleaseLock(); }
					}

					return sent;
				});

				if (sentDataTo == 0) { Thread.Sleep(50); }
			}
		}

		/// <summary>
		/// Entry point for the main thread that checks all connections for incoming data
		/// </summary>
		private void ReceiveIncomingWorker()
		{
			while (WantExit == false)
			{
				int receiveCount = ForEachIncomingConnection(delegate(IncomingConnection connection)
				{
					int recv = 0;

					// Make sure only one thread is reading bytes in from this connection at any one time
					if (connection._readLock.TryAquireLock())
					{
						try { if (connection.CheckBytesIncoming() > 0) { recv++; } }
						finally { connection._readLock.ReleaseLock(); }
					}

					return recv;
				});

				if (receiveCount == 0) { Thread.Sleep(50); }
			}
		}

		internal IncomingConnection InitializeIncomingClientConnection(TcpClient clientConnection)
		{			
			clientConnection.Client.NoDelay = false;
			clientConnection.Client.ReceiveBufferSize = 8192 * 2;
			clientConnection.Client.SendBufferSize = 8192 * 2;
			clientConnection.Client.Blocking = true;
			IncomingConnection incomingConnection = new IncomingConnection(this, IncomingMessageHandler);
			incomingConnection.TcpClientConnection = new TCPIPProtocol(clientConnection);
			incomingConnection.MessageReceived += new EventHandler<ObjectEventArgs<ICommunicationsMessage>>(connection_MessageReceived);

			return incomingConnection;
		}

		/// <summary>
		/// Handles incoming connections
		/// </summary>
		private void AcceptIncomingConnectionWorker()
		{
			while (WantExit == false)
			{
				if (TcpListenerObject.Pending())
				{
					// We don't want multiple threads trying to accept the incoming tcp
					// client from the single listener object
					if (_acceptingIncomingConnectionLock.TryAquireLock())
					{
						TcpClient clientConnection = null;
						try
						{
							if (TcpListenerObject.Pending())
							{
								clientConnection = TcpListenerObject.AcceptTcpClient();

                                //ADDED - Ahmet BUTUN
                                Socket incomingSocket = clientConnection.Client;

                                incomingSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);

                                const uint keepAliveTime = 1000;
                                const uint keepAliveInterval = 500;

                                // marshal the equivalent of the native structure into a byte array
                                const uint dummy = 0;
                                byte[] inOptionValues = new byte[Marshal.SizeOf(dummy) * 3];
                                BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0);
                                BitConverter.GetBytes(keepAliveTime).CopyTo(inOptionValues, Marshal.SizeOf(dummy));
                                BitConverter.GetBytes(keepAliveInterval).CopyTo(inOptionValues, Marshal.SizeOf(dummy) * 2);
                                // of course there are other ways to marshal up this byte array, this is just one way

                                // call WSAIoctl via IOControl
                                incomingSocket.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
                                //ADDED - Ahmet BUTUN
							}
						}
						catch (Exception ex) { ex.Log(LogSeverity.Warning, false); }
						finally
						{
							// Now that we've accepted the connection (or error'd out), we can release the lock
							_acceptingIncomingConnectionLock.ReleaseLock();
						}

						if (clientConnection != null)
						{
							IncomingConnection incomingConnection = InitializeIncomingClientConnection(clientConnection);

							if (incomingConnection != null)
							{
								incomingConnection.TcpClientConnection.Socket.Blocking = false;
								_connections.Add(incomingConnection);

                                //ADDED ONCLIENTCONNECTED EVENT
							}
						}
					}
					else
					{
						// Another thread is handling this pending connection
						Thread.Sleep(5);
					}
				}
				else
				{
					// No connections pending... sleep
					Thread.Sleep(20);
				}
			}
		}

		/// <summary>
		/// Set up the TcpListener on this separate thread.  However, let the threads running
		/// AcceptIncomingConnections() actually handle incoming connection requests.
		/// This method also occasionally cleans up connections that need to be closed.
		/// </summary>
		private void SetupAndCleanup()
		{
			TcpListenerObject = new TcpListener(ListenOnLocalIP, ListenPort);

			if (ListenOnLocalIP != IPAddress.None)
			{
				try { TcpListenerObject.Start(MaxSimultaneousIncomingConnections); }
				catch (Exception ex) { _listenerObjectException = ex; throw; }

				_listenerIsListening = true;
				int passCount = 0;

				while (WantExit == false)
				{
					Thread.Sleep(200);

					// Do a quick cleanup pass            
					for (int i = _connections.Count - 1; i >= 0; i--)
					{
						IncomingConnection connection = _connections.GetItem(i);
						if (connection == null) continue;
						if (connection.NeedsClosing == true) { CleanupAndRemove(connection); }
					}

					passCount++;

					// Every so often, query sockets using Socket.Select to determine
					// which clients may have disconnected
					if (passCount > 40)
					{
						passCount = 0;
						if (_connections.Count > 0)
						{
							List<IncomingConnection> incomingConnections = _connections.AllItems;
							List<Socket> sockets = new List<Socket>();

							foreach (IncomingConnection connection in incomingConnections)
							{
								sockets.Add(connection.TcpClientConnection.Socket);
							}

							// Check read
							Socket.Select(sockets, null, null, 10000);

							if (sockets.Count > 0)
							{
								// Check write
								Socket.Select(null, sockets, null, 10000);

								if (sockets.Count > 0)
								{
									// For these sockets, both read and write are bad - client dropped connection
									foreach (Socket s in sockets)
									{
										foreach (IncomingConnection connection in incomingConnections)
										{
											if (connection.TcpClientConnection.Socket.Handle.ToInt32() == s.Handle.ToInt32())								
												connection.NeedsClosing = true;
										}
									}
								}
							}
						}
					}
				}
			}

			// On shutdown, close and clean up all incoming connections
			if (ListenOnLocalIP != IPAddress.None)
			{
				for (int n = _connections.Count - 1; n >= 0; n--) { CleanupAndRemove(_connections.GetItem(n)); }
				TcpListenerObject.Stop();
			}
		}

		/// <summary>
		/// Cleans up / closes, and removes an incoming connection
		/// </summary>
		/// <param name="connection"></param>
		private void CleanupAndRemove(IncomingConnection connection)
		{
			if (connection == null) return;

			try { connection.MessageReceived -= connection_MessageReceived; }
			catch { }

			connection.TcpClientConnection.CloseAndCleanup();
			_connections.Remove(connection);
			_lookupConnectionByID.Remove(connection.AssociatedID, connection);
		}

		private void connection_MessageReceived(object sender, ObjectEventArgs<ICommunicationsMessage> e)
		{
			IncomingConnection connection = sender as IncomingConnection;
			connection.HandleIncomingMessage(e.obj);
		}

		internal long AddBytesReceived(long bytes) { return Interlocked.Add(ref _bytesReceived, bytes); }
		internal long AddBytesReceived(int bytes) { return Interlocked.Add(ref _bytesReceived, (Int64)bytes); }
		internal long AddBytesSent(long bytes) { return Interlocked.Add(ref _bytesSent, bytes); }
		internal long AddBytesSent(int bytes) { return Interlocked.Add(ref _bytesSent, (Int64)bytes); }
	}
}
