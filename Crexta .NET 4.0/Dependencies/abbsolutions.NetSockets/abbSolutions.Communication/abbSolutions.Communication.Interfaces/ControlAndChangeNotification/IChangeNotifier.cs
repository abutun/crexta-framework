using System.ComponentModel;
using System.Collections.Generic;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IChangeNotifier : IHasAssociatedID 
   {
      void NotifyChanged(IChangeMessage message);      
      void AddBroadcaster(IChangeMessageBroadcaster broadcaster);
      void RemoveBroadcaster(IChangeMessageBroadcaster broadcaster);
      void ClearBroadcasters();
   }
}
