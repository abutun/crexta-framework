using System;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IIDSupplier 
   {
       long GetNextId();
       long CurrentMaxId { get; set; }
       
   }
}
