﻿using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsAdd<TListType> 
   {
      bool Add(TListType item);
   }   
}
