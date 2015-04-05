using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IState : IHasAssociatedID, IExecutableWorkItem, IHasParameters , IHasCategory, IHasType , IRequiresParameters
   {
      event EventHandler StateAdded;
      event EventHandler StateRemoved;
      void UpdateState(IEntity entity, IStateCollection entityStates);
      bool ModifyExecutingState(IState executingState, IParameterCollection argCollection);
      bool ModifyIntention(IIntention intention, IParameterCollection argCollection);
      void OnStateAdded();
      void OnStateRemoved();      
      IAbility OriginatingAbility { get; set; }      
   }
}
