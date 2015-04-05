using System;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Serializable, Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public enum Vertices
   {
      LowerLeftBottom = 0,
      LowerRightBottom = 1,
      TopLeftBottom = 2,
      TopRightBottom = 3,
      LowerLeftTop = 4,
      LowerRightTop = 5,
      TopLeftTop = 6,
      TopRightTop = 7,
   }

   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IOccupySpace
   {
      IPosition Position { get; }
      ISize Size { get; set; }
      bool Overlaps(IOccupySpace volumeSpace);
      ILocation this[Vertices v] { get; }
      float XMax { get; }
      float XMin { get; }
      float YMax { get; }
      float YMin { get; }
      float ZMax { get; }
      float ZMin { get; }
   }
}
