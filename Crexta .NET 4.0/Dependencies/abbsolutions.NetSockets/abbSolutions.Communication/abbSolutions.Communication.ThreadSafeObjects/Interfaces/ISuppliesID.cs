using System;
using System.ComponentModel;

namespace abbSolutions.Communication.ThreadSafeObjects
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISuppliesID
   {
       long SuppliedID { get; set; }              
   }
}
