using System;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IParameter : ICloneable, IChanged, IHasClassTypeName, IHasType, IHasCategory, IQuickCopy<IParameter>, ISuppliesID 
   {
      long ParameterID { get; set; }
      IParameterValue ParameterValue { get; set; }

      string ParameterTypeName { get; }
      string ParameterCategoryName { get; }
   }
}
