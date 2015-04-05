using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
	[Browsable(true)]
	public class OutgoingConnection : ConnectionBase, ICommClientIssueCommands, IGameClient
	{
		public Thread ListenIncomingThread { get; set; }
		public Thread SendOutgoingThread { get; set; }
		public Thread ProcessMessagesThread { get; set; }
		public bool WantExit { get; set; }
		public OutgoingConnection() { }

		public OutgoingConnection(EventHandler<ObjectEventArgs<ICommunicationsMessage>> messageReceivedEvent)
			: base()
		{
			MessageReceived += new EventHandler<ObjectEventArgs<ICommunicationsMessage>>(messageReceivedEvent);
		}

		public IGameClient GameClient { get { return this as IGameClient; } }

		public override void CloseConnection()
		{
			NeedsClosing = true;
			WantExit = true;
			TcpClientConnection.CloseAndCleanup();
		}

		public bool Connect(string hostName, int portNumber, bool wantThrowException)
		{
			TcpClientConnection = new TCPIPSocketProtocol();

			try 
            {
                // BUG FIXED - Ahmet BUTUN
                if (!TcpClientConnection.Connect(hostName, portNumber, true))
                    return false;
            }
			catch (Exception ex)
			{
				if (wantThrowException)
					throw new Exception("Error trying to connect to " + hostName + " on port " + portNumber.ToString(), ex);
				else
					return false;
			}

			ListenIncomingThread = new ThreadStart(ListenIncoming).CreateAndRunThread();
			ProcessMessagesThread = new ThreadStart(ProcessMessages).CreateAndRunThread();
			SendOutgoingThread = new ThreadStart(SendOutgoing).CreateAndRunThread();

			return true;
		}

		public void IssueCommand(object o, int transmissionType)
		{
			Message message = new Message(o, transmissionType, new MessageHeader());
			byte[] bytes = message.ReadBytesForTransmission();
			if (bytes != null) { EnqueueForSend(bytes); }
		}

		internal void ProcessMessages()
		{
			while (!WantExit) { if (!GetNextFullMessage()) { Thread.Sleep(100); } }
		}

		internal void ListenIncoming()
		{
			while (!WantExit) { if (CheckBytesIncoming() == 0) { Thread.Sleep(100); } }
		}

		internal void SendOutgoing()
		{
			while (!WantExit) { if (SendBytesOutgoing() == 0) { Thread.Sleep(100); } }
		}
	}
}
