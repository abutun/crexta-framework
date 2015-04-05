using System.ComponentModel;
using System.Collections.Generic;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IGameObject : IHasClassTypeName, IHasCategory, IHasType, IHasSize, IHasWeight, IFromTemplate<IGameObjectTemplate>, IHasTemplateID 
   {
      long ObjectID { get; set; }      
      long CarriedByEntityID { get; set; }
      long InObjectID { get; set; }
      ILocation AtLocation { get; set; }
   }
}
