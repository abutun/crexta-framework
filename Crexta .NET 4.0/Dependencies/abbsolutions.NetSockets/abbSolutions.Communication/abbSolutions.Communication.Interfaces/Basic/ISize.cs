using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISize : IVector4
   {
      float Length { get; set; }
      float Width { get; set; }
      float Height { get; set; }
   }
}
