using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
	/// <summary>
	/// Implements TCP/IP communication using the .NET Socket object
	/// </summary>
	[Browsable(true)]
	public class TCPIPSocketProtocol : ICommunicationsProtocol
	{
		public Socket TcpClientConnection { get; set; }

		public void Close()
		{
			TcpClientConnection.Close();
		}

		public Socket Socket
		{
			get { return TcpClientConnection; }
			set { TcpClientConnection = value; }
		}

		public bool Connect(string hostName, int portNumber, bool wantThrowException)
		{
			Socket s = null;			
			Socket tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				tempSocket.Connect(hostName, portNumber);

				if (tempSocket.Connected)
				{
					s = tempSocket;
				}
				else
				{
					s = null;
				}
			}
			catch { }

			TcpClientConnection = s;
			return (s != null);
		}

		public int Send(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode)
		{
			return TcpClientConnection.Send(buffer, offset, size, flags, out errorCode);
		}

		public int Receive(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode)
		{
			int bytes = TcpClientConnection.Receive(buffer, offset, size, flags, out errorCode);
			return bytes;
		}

		public int Available
		{
			get { return TcpClientConnection.Available; }
		}

		/// <summary>
		/// Takes care of cleaning up a TcpClient connection - a bit messy, but functional.
		/// </summary>
		public void CloseAndCleanup()
		{
			if (TcpClientConnection != null)
			{
				try { TcpClientConnection.Shutdown(SocketShutdown.Both); }
				catch { }
				try { TcpClientConnection.Close(); }
				catch { }
				TcpClientConnection = null;
			}
		}
	}
}
