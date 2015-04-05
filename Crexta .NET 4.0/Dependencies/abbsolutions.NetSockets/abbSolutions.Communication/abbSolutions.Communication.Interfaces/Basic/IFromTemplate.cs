using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IFromTemplate<T> where T : class 
   {
      T Template { get; set; }
   }
}
