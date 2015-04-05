using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IChangeMessageBroadcaster : IMultipleItems<IChangeMessageReceiver>
   {
      void BroadcastChange(IChangeMessage message);
      void Subscribe(IChangeMessageReceiver subscriber);
      void Unsubscribe(IChangeMessageReceiver subscriber);      
   }
}
