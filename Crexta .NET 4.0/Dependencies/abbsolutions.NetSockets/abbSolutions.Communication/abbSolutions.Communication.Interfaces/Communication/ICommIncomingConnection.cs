using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ICommIncomingConnection : ICommunicationsBase, ICommServerReceivesCommands
   {
      ICommunicationsServer Server { get; set; }
      IIncomingMessageHandler IncomingMessageHandler { get; set; }
      ILockable ReadLock { get; }
      ILockable WriteLock { get; }
      ILockable ProcessLock { get; }
   }
}
