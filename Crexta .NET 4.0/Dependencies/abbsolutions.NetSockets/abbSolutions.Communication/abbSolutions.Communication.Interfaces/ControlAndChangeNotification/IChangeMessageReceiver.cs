using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IChangeMessageReceiver : IHasAssociatedID 
   {      
      bool WantNotifications { get; set; }
      void EnqueueChangeMessage(IChangeMessage message);
      bool DequeueChangeMessage(out IChangeMessage message);
   }
}
