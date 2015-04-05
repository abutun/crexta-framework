using System.ComponentModel;
using System.Collections.Generic;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IRequiresParameters
   {
      List<IParameterCategoryAndType> RequiredParameterTypes { get; }
   }
}
