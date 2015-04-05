using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IObjectTemplateCollection : ISupportsAdd<long>, ISupportsRemove<long>
   {
      List<long> AllObjectTemplates { get; }
   }
}
