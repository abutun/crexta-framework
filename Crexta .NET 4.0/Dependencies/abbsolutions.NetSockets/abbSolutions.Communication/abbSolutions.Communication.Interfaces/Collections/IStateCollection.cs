using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IStateCollection : IMultipleItems<IState>
   {
      bool CurrentStateModifyExecutingState(IState executingState, IParameterCollection argCollection);
      bool AddOrSetState(IState state, IParameterCollection parameters);
      bool RemoveState(int stateCategory, int stateType);
      bool ModifyIntention(IIntention intention, IParameterCollection modifierArgs);
      void AddState(IState state, IParameterCollection parameters);
      IState FindState(int stateCategory, int stateType);
      List<IState> FindStates(int stateCategory);
   }
}
