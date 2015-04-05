using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IVector4 
   {
      float X { get; set; }
      float Y { get; set; }
      float Z { get; set; }
      float W { get; set; }
   }
}
