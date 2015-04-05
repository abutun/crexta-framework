using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IAbility : IHasAssociatedID, IHasParameters, IHasType, IHasTemplateID, IFromTemplate<IAbilityTemplate>, IEnablesIntentions, IRequiresParameters
   {
      new List<IIntention> AllowsIntentionList { get; }            
      new long TemplateID { get; set; }      
      void ApplyParameterToAbility(IParameter arg);
      long AbilityID { get; set; }      
      
      bool RetrieveParameterValues<T1>(out T1 parameter1, int parameterType)
         where T1 : class, IParameterValue;
      bool RetrieveParameterValues<T1, T2>(out T1 parameter1, out T2 parameter2, params int[] parameterTypes)
         where T1 : class, IParameterValue
         where T2 : class, IParameterValue;
      bool RetrieveParameterValues<T1, T2, T3>(out T1 parameter1, out T2 parameter2, out T3 parameter3, params int[] parameterTypes)
         where T1 : class, IParameterValue
         where T2 : class, IParameterValue
         where T3 : class, IParameterValue;
      bool RetrieveParameterValues<T1, T2, T3, T4>(out T1 parameter1, out T2 parameter2, out T3 parameter3, out T4 parameter4, params int[] parameterTypes)
         where T1 : class, IParameterValue
         where T2 : class, IParameterValue
         where T3 : class, IParameterValue
         where T4 : class, IParameterValue;
      bool RetrieveParameterValues<T1, T2, T3, T4, T5>(out T1 parameter1, out T2 parameter2, out T3 parameter3, out T4 parameter4, out T5 parameter5, params int[] parameterTypes)
         where T1 : class, IParameterValue
         where T2 : class, IParameterValue
         where T3 : class, IParameterValue
         where T4 : class, IParameterValue
         where T5 : class, IParameterValue;
   }
}
