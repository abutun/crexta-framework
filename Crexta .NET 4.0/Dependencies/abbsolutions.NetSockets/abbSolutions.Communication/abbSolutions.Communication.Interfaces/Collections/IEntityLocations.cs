using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IEntityLocations 
   {
      IEntityCollection GetNearbyEntities(long locationKey);
      IChangeMessageBroadcaster GetAreaPublisher(long locationKey);
      IEntityCollection GetNearbyEntities(ILocation location);
      ILocation FindEntityLocation(long entityID);
      void SetEntityLocation(IEntity entity, ILocation location);
      void SetEntityLocation(IEntity entity, float x, float y, float z);
   }
}
