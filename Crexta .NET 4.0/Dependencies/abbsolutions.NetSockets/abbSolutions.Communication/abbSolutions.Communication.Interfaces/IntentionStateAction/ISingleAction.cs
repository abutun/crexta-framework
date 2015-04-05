using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISingleAction : IHasAssociatedID, IHasFriendlyName 
   {
      bool CanPerformAction(IIntention intention, IParameterCollection parameters);
      bool DoBasePerformAction(IIntention intention, IParameterCollection parameters);      
      ISingleAction CreateInstance(long ID);      
   }
}
