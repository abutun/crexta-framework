using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;
using abbSolutions.Communication;

namespace abbSolutions
{
	public partial class CommunicationsTest : Form
	{
		// Note: simulating 50 outgoing connections is heavy-duty. Each one requires 3 threads.  
		// Usually this is no big deal, since one game client requires one connection.  
		// But for this unit test, this is considered a somewhat heavy load.
		const int OutgoingConnectionsToServerCount = 50;
		const int MessagesSentFromEachOutgoingThread = 200;
		const int PortNum = 4006;

		OutgoingConnection[] _connectionsToServer;
		CommunicationsServer _server;
		ServerMessageHandler _messageHandler;

		public CommunicationsTest()
		{
			InitializeComponent();
		}

		private void CommunicationsTest_Load(object sender, EventArgs e)
		{

		}

		public void Output(string text)
		{
			txtOutput.AppendText(text + Environment.NewLine);
		}

		private void btnStartTest_Click(object sender, EventArgs e)
		{
			btnStartTest.Enabled = false;
			Application.DoEvents();

			Output("Starting test... please wait.");

			Output("Begin Listening for Connections...");

			ServerMessageHandler._messagesReceived = 0;

			// Set up the server that will accept incoming connections
			_messageHandler = new ServerMessageHandler();
			_server = new CommunicationsServer(IPAddress.Any, PortNum, _messageHandler);
			_server.BeginListening();

			_connectionsToServer = new OutgoingConnection[OutgoingConnectionsToServerCount];

			Output("Creating " + OutgoingConnectionsToServerCount.ToString() + " connections, connecting each to server...");
			// Create outgoing connections and connect to the server
			for (int n = 0; n < OutgoingConnectionsToServerCount; n++)
			{
				_connectionsToServer[n] = new OutgoingConnection(connectionToServer_MessageReceived);

				// Connect outgoing thread to the server
				bool success = _connectionsToServer[n].Connect("localhost", PortNum, true);

				// Give the listener some time since there may be a concurrent new connection limit 
				Thread.Sleep(20);

				Application.DoEvents();
			}

			Thread.Sleep(500);

			// Send some kind of initial hello message
			for (int n = 0; n < OutgoingConnectionsToServerCount; n++)
			{
				HelloMessage message = new HelloMessage("Hello from client number " + n.ToString());
				_connectionsToServer[n].IssueCommand(message, 1);
			}

			Output("Issuing commands...");

			// Send multiple messages to the server from all connections
			for (int i = 0; i < MessagesSentFromEachOutgoingThread; i++)
			{
				for (int n = 0; n < OutgoingConnectionsToServerCount; n++)
				{
					SomeGameCommandParameters fakeCommandParameter = new SomeGameCommandParameters(42, "testing", 1);

					SomeGameCommand command = new SomeGameCommand(
							"Issuing command number " + i.ToString() + " from connection number " + n.ToString(),
							i, fakeCommandParameter);

					_connectionsToServer[n].IssueCommand(command, i);
				}

				Application.DoEvents();
			}

			// Give ourselves 5 seconds for all the messages to come through
			tmrFiveSeconds.Enabled = true;

			btnStartTest.Enabled = true;
		}

		public void connectionToServer_MessageReceived(object sender, ObjectEventArgs<ICommunicationsMessage> e)
		{
			Output(e.obj.MessageContents.ToString());
		}

		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			lblReceived.Text = ServerMessageHandler._messagesReceived.ToString();

			if (_connectionsToServer != null)
			{
				int countConnected = 0;
				long bytesSent = 0;

				for (int n = 0; n < OutgoingConnectionsToServerCount; n++)
				{
					if (_connectionsToServer[n] == null)
						continue;

					if (!_connectionsToServer[n].NeedsClosing)
					{
						bytesSent += _connectionsToServer[n].BytesSent;
						countConnected++;
					}
				}

				lblConnected.Text = countConnected.ToString();
				
				if (bytesSent > 0)
					lblBytesSent.Text = bytesSent.ToString();
			}			
			
			if (_server != null)
			{
				lblServerBytesReceived.Text = _server.BytesReceived.ToString();
			}
		}

		private void tmrFiveSeconds_Tick(object sender, EventArgs e)
		{
			tmrFiveSeconds.Enabled = false;

			Output("Closing connections...");

			// Close all client connections
			for (int n = 0; n < OutgoingConnectionsToServerCount; n++) { _connectionsToServer[n].CloseConnection(); }

			// Shut down the server
			_server.ShutdownServer();

			// Give the server some time to clean up open connections, etc
			Thread.Sleep(1000);

			Output("Server sent " + _server.BytesSent.ToString() + " bytes and received " + _server.BytesReceived.ToString() + " bytes");

			// 21 messages should have been sent on each outgoing connection. Ensure that the server actually received 
			// (MessagesSentFromEachOutgoingThread + 1 hello) * OutgoingConnectionsToServerCount messages
			Output("Success = " + ((OutgoingConnectionsToServerCount * (MessagesSentFromEachOutgoingThread + 1)) == ServerMessageHandler._messagesReceived).ToString());
		}
	}
}
