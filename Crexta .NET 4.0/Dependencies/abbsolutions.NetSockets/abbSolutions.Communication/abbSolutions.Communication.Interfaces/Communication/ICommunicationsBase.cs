using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.Communication.Interfaces
{
	[Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	public interface ICommunicationsBase : ITrackBytes
	{
		event EventHandler<ObjectEventArgs<ICommunicationsMessage>> MessageReceived;
		long AssociatedID { get; set; }
		bool NeedsClosing { get; set; }
		ICommunicationsProtocol TcpClientConnection { get; set; }
		void SendMessage(object o, int transmissionType);
		void CloseConnection();
	}
}
