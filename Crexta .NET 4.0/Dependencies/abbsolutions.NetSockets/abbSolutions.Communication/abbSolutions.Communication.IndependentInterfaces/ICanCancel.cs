﻿using System;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ICanCancel
   {
      bool Cancelled { get; set; }      
   }
}
