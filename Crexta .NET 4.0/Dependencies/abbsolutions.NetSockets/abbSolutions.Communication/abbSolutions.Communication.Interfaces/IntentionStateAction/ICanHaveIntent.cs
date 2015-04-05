using System.ComponentModel;
using System.Collections.Generic;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ICanHaveIntent 
   {
      IIntentionQueue IntentionQueue { get; }
      bool NoIntent { get; }
      void AddIntention(IIntention intention, IAbility ability, IParameterCollection parameterCollection);      
   }
}
