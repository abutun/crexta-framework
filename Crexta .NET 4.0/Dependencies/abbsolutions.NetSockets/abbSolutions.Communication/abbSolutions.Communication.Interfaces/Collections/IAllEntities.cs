using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	public interface IAllEntities : ISupportsAdd<IEntity>, ISupportsRemove<long>, ISupportsFind<long, IEntity>, IMultipleItems<IEntity>
   {
      List<long> AllEntityIDs { get; }
   }
}
