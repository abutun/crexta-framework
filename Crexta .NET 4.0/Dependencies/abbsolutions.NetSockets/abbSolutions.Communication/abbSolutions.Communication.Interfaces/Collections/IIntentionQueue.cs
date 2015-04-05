using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IIntentionQueue : IMultipleItems<IIntention>, ISupportsAdd<IIntention>, ISupportsClear, ISupportsCount
   {
      IIntention Dequeue();
      void Set(IIntention intention);
   }
}
