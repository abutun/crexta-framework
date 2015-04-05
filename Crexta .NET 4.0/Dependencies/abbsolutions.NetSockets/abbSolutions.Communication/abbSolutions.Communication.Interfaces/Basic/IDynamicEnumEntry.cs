using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IDynamicEnumEntry
   {
      IDynamicEnum BelongsTo { get; set; }
      string Name { get; set; }
      int Value { get; set; }
      string Description { get; set; }      
   }
}
