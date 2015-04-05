using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IChangeMessage : IMessage 
   {
      IMessage Message { get; set; }
      string MessageType { get; }
      long From { get; }
      long To { get; }
   }
}
