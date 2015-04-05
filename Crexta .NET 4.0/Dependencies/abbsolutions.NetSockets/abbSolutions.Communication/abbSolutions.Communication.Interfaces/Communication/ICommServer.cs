using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ICommunicationsServer : ITrackBytes
   {
      IPAddress ListenOnLocalIP { get; set; }
      int ListenPort { get; set; }
      int ConnectionCount { get; }      
      void BeginListening();
      void ShutdownServer();
      IMapIDToControlReceiver IDToControlReceiverMap { get; set; }
      IIncomingMessageHandler IncomingMessageHandler { get; set; }      
      ICommunicationsBase FindConnectionForID(long ID);
   }
}
