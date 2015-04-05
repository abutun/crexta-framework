using System.ComponentModel;
using System.Collections.Generic;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IGameObjectTemplate : IHasType, IHasCategory, IHasClassTypeName, IHasTemplateID, IHasSize, IHasWeight
   {
      new ISize Size { get; set; }
      IGameObject CreateObjectFromTemplate();
   }
}
