using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IEnablesIntentions 
   {
      Dictionary<int, IIntention> AllowsIntentions { get; }
      List<IIntention> AllowsIntentionList { get; }            
   }
}
