using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsRemoveByIndex<TIndex, TListType> where TListType : class
   {
      bool Remove(TIndex key, TListType item);
   }
}
