using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsAddByIndex<TIndex, TListType> where TListType : class
   {
      bool Add(TIndex key, TListType item);
   }
}
