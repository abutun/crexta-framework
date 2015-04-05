using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IMapIDToControlReceiver
   {
      IControlReceiver FindReceiver(long ID);      
   }
}
