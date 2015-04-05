using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ITerrain : IHasClassTypeName, IHasType
   {
      IOccupySpace TerrainSpace { get; set; }
      long TerrainID { get; set; }
   }
}
