using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ICommClientIssueCommands : ICommunicationsBase 
   {
      void IssueCommand(object o, int transmissionType);
      IGameClient GameClient { get; }
   }

   public interface IGameClient
   {
      void IssueCommand(object o, int transmissionType);
   }
}
