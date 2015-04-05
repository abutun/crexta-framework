using System.ComponentModel;

namespace abbSolutions.Communication.ThreadSafeObjects
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsEnqueueDequeue<TListType> 
   {
      void Enqueue(TListType item);
      bool Dequeue(out TListType item);
   }   
}
