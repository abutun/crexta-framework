﻿using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsEnqueueDequeue<TListType> 
   {
      void Enqueue(TListType item);
      bool Dequeue(out TListType item);
   }   
}
