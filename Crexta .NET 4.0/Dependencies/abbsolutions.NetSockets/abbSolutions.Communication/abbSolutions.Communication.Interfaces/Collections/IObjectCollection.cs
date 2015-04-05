using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IObjectCollection : ISupportsRemove<long>, ISupportsAdd<long>, IMultipleItems<long>
   {
   }
}
