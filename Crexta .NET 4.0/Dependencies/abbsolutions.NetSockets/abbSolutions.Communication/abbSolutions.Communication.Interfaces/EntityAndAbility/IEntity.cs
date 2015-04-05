using System.ComponentModel;
using System.Collections.Generic;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IEntity : IHasAssociatedID, IControlReceiver, IHasSize, IHasLocation, ICanHaveIntent, IHasAbilities, IHasStates, IOwnsObjects, ISuppliesID  
   {
      IPosition Position { get; }
      IOccupySpace OccupySpace { get; }
      void NotifyLocationChanged();
      bool NoLocation { get; }
      ITerrainCollection Terrains { get; }
      IChangeMessageReceiver ChangeMessageReceiver { get; }
      IChangeNotifier ChangeNotifier { get; }
   }
}
