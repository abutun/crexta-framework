using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
    [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
    public interface IPersistsWorld
    {
        IWorld World { get; set; }
        IEntity CreatePersistentEntity();

        IParameter CreatePersistentParameter(string parameterCategory, string parameterType, IParameterValue o);
        IAbility CreatePersistentEntityAbility(long entityID, long templateID);

        IAbilityTemplate CreatePersistentAbilityTemplate();
        ITerrain CreatePersistentTerrain(string terrainClassTypeName);
        IGameObject CreatePersistentObject(string objectClassTypeName);
        IGameObjectTemplate CreatePersistentObjectTemplate(string objectTemplateTypeName);

        void LoadAll();
        void SaveAll();
    }
}
