using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IParameterValue : IHasClassTypeName, IQuickCopy, IHasCategory, IHasType 
   {

   }
}
