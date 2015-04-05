using System;
using System.ComponentModel;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ITypeDescription
   {
      Type ClassType { get; }
      string SourceDLL { get; }
   }
}
