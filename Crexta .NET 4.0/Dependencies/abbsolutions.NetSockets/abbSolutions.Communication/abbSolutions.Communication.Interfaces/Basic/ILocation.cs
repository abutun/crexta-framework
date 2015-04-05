using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ILocation : IVector4
   {
      ILocation LocationVector { get; }
      bool NoLocation { get; }      
   }
}
