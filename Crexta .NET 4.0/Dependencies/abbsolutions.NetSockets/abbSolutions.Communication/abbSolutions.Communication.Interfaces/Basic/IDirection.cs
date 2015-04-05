using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IDirection : IVector4
   {
      IDirection DirectionVector { get; }      
   }
}
