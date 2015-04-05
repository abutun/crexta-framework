using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IHasParameters 
   {
      IParameterCollection Parameters { get; set; }      
   }
}
