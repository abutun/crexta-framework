using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
	//public class ObjectEventArgs : EventArgs
	//{
	//    public ICommunicationsMessage Message { get; set; }
	//    public ObjectEventArgs(ICommunicationsMessage message) { Message = message; }
	//}

	//public interface ITrackBytes
	//{
	//    long BytesSent { get; }
	//    long BytesReceived { get; }
	//}

	//[Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	//public interface ICommunicationsBase : ITrackBytes
	//{
	//    event EventHandler<ObjectEventArgs<ICommunicationsMessage>> MessageReceived;
	//    long AssociatedID { get; set; }
	//    bool NeedsClosing { get; set; }
	//    ICommunicationsProtocol TcpClientConnection { get; set; }
	//    void SendMessage(object o, int transmissionType);
	//    void CloseConnection();
	//}

	//[Browsable(true)]
	//public interface ICommunicationsProtocol
	//{
	//    void CloseAndCleanup();
	//    int Send(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode);
	//    int Available { get; }
	//    int Receive(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode);
	//    void Close();
	//    bool Connect(string hostName, int portNumber, bool wantThrowException);
	//    Socket Socket { get; set; }
	//}	

	/// <summary>
	/// Implements TCP/IP communication using the .NET TcpClient object
	/// </summary>
    [Browsable(true)]
    public class TCPIPProtocol : ICommunicationsProtocol 
    {
		public TCPIPProtocol() { }

		public TCPIPProtocol(TcpClient client)
		{
			TcpClientConnection = client;
		}

		public Socket Socket
		{
			get { return TcpClientConnection.Client; }
			set { throw new Exception("Cannot set the socket for TCP/IP Protocol"); }
		}

        public TcpClient TcpClientConnection { get; set; }

		public void Close()
		{
			TcpClientConnection.Client.Close();
			TcpClientConnection.Close();
		}

		public bool Connect(string hostName, int portNumber, bool wantThrowException)
		{
			TcpClientConnection = new TcpClient();

			try { TcpClientConnection.Connect(hostName, portNumber); }
			catch (Exception ex)
			{
				if (wantThrowException)
					throw new Exception("Error trying to connect to " + hostName + " on port " + portNumber.ToString(), ex);
				else
					return false;
			}

			return true;
		}

		public int Send(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode)
		{
			return TcpClientConnection.Client.Send(buffer, offset, size, flags, out errorCode);
		}

		public int Receive(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode)
		{
			int bytes = TcpClientConnection.Client.Receive(buffer, offset, size, flags, out errorCode);
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
				if (TcpClientConnection.Client != null)
				{
					try { TcpClientConnection.Client.Shutdown(SocketShutdown.Both); }
					catch { }
					try { TcpClientConnection.Client.Close(); }
					catch { }
				}
				try { TcpClientConnection.Close(); }
				catch { }
			}
		}
    }
}
