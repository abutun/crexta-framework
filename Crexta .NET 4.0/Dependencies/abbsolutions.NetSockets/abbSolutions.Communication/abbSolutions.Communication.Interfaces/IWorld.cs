using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IWorld : IMapIDToControlReceiver 
   {
      IAllEntities Entities { get; }
      IEntityLocations EntityLocations { get; }
      IAbilityTemplates AbilityTemplates { get; }
      ITypeLookup TypeProvider { get; set; }
      ITerrains Terrains { get; }
      IGameObjects GameObjects { get; }
      IGameObjectTemplates GameObjectTemplates { get; }      
   }
}
