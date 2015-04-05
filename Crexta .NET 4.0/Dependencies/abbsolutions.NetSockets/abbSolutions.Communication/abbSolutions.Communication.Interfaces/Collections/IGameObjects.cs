using System.ComponentModel;
using System.Collections.Generic;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	public interface IGameObjects : ISupportsFind<long, IGameObject>, ISupportsAdd<IGameObject>, ISupportsRemove<IGameObject>, IMultipleItems<IGameObject>
   {      
      IObjectCollection FindObjects(ILocation location);    
   }
}
