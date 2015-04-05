using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IAbilityTemplate : IHasClassTypeName, IHasTemplateID, ISuppliesID
   {      
      IAbility CreateAbilityFromTemplate(long entityID, IParameterCollection parameters);      
   }
}
