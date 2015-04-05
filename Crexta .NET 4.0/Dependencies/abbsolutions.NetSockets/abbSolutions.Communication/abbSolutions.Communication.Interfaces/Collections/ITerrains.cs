using System.ComponentModel;
using System.Collections.Generic;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	public interface ITerrains : ISupportsFind<long, ITerrain>, ISupportsRemove<ITerrain>, IMultipleItems<ITerrain>, IChanged, ISupportsAdd<ITerrain> 
   {      
      ITerrainCollection FindTerrains(ILocation location);      
   }
}
