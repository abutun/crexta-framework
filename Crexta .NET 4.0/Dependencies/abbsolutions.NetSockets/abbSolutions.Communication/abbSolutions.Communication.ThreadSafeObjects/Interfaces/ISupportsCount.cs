using System.ComponentModel;

namespace abbSolutions.Communication.ThreadSafeObjects
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsCount
   {
      int Count { get; }
   }
}
