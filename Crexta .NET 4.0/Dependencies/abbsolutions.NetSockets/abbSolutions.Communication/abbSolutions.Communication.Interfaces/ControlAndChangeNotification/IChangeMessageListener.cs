using System;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   public class ChangeMessageEventArgs : EventArgs
   {
      private readonly IChangeMessage _message;
      public ChangeMessageEventArgs(IChangeMessage message) { _message = message; }
      public IChangeMessage Message { get { return _message; } }      
   }

   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IChangeMessageListener
   {
      event EventHandler<ChangeMessageEventArgs> ChangeMessageReceived;
      long AssociatedID { get; }
   }
}
