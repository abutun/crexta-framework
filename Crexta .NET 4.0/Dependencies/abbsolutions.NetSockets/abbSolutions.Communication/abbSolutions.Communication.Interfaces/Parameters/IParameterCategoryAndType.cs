using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IParameterCategoryAndType 
   {
      IDynamicEnumEntry ParameterType { get; set; }
      IDynamicEnumEntry ParameterCategory { get; set; }      
   }
}
