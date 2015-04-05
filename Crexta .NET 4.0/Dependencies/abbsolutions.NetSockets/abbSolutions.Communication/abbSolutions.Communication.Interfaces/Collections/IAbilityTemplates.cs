using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
	public interface IAbilityTemplates : IMultipleItems<IAbilityTemplate>, ISupportsAddRemoveClear<long, IAbilityTemplate>, ISupportsCount, ISupportsFindMany<long, IAbilityTemplate>
   {
   }
}
