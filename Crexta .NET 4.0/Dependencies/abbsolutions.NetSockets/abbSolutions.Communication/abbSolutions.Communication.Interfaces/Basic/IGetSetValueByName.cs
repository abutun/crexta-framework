using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IGetSetValueByName
   {      
      string Name { get; set; }
      int Value { get; set; }      
   }
}
