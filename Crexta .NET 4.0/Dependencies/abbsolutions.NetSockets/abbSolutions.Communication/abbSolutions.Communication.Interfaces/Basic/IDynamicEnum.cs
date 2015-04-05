using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IDynamicEnum 
   {
      string EnumerationName { get; }
      IDynamicEnumEntry Find(string name);
      IDynamicEnumEntry Find(int value);
      List<IDynamicEnumEntry> EnumList { get; }
      bool AddValue(string name, int value, string description);
   }
}
