using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IControlReceiver
   {
      IControlResponse HandleIncomingControlCommand(IControlCommand controlCommand);
   }
}
