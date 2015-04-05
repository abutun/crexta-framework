using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISpeed : IVector4
   {
      bool Moving { get; }
      float SpeedX { get; set; }
      float SpeedY { get; set; }
      float SpeedZ { get; set; }
   }
}
