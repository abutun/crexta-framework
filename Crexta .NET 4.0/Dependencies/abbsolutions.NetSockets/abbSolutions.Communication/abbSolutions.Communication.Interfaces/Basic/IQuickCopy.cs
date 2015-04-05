using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IQuickCopy
   {
      object Copy();
   }

   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IQuickCopy<T> where T : class
   {
      T Copy();
   }
}
