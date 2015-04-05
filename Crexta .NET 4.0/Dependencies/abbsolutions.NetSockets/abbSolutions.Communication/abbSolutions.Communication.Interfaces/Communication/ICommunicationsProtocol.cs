using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.Communication.Interfaces
{
	[Browsable(true)]
	public interface ICommunicationsProtocol
	{
		void CloseAndCleanup();
		int Send(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode);
		int Available { get; }
		int Receive(byte[] buffer, int offset, int size, SocketFlags flags, out SocketError errorCode);
		void Close();
		bool Connect(string hostName, int portNumber, bool wantThrowException);
		Socket Socket { get; set; }
	}	
}
