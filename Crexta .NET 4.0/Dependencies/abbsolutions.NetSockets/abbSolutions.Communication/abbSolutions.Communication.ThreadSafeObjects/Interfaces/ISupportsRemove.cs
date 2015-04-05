﻿using System.ComponentModel;

namespace abbSolutions.Communication.ThreadSafeObjects
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISupportsRemove<TKeyType>
   {
      bool Remove(TKeyType key);
   }
}
