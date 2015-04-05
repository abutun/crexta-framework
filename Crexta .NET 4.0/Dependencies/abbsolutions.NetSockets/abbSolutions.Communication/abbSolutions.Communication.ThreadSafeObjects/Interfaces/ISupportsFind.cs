using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.ThreadSafeObjects
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsFind<TIndex, TListType> where TListType : class
   {
      TListType Find(TIndex key);
   }
}
