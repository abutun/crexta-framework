using System;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IExecutableWorkItem : ICanCancel, ICanExecute
   {
      DateTime ExecutionTime { get; set; }            
   }
}
