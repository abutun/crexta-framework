﻿using System.Collections.Generic;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IHasTemplateID 
   {
      long TemplateID { get; set; }
   }
}