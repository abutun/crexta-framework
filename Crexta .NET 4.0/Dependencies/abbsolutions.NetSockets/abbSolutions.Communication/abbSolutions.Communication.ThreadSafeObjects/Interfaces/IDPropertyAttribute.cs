using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.ThreadSafeObjects
{
   [AttributeUsage(AttributeTargets.Class)]
   public class IDProperty : System.Attribute, IReadableAttribute
   {
      protected string _prop;
      public IDProperty(string prop) { _prop = prop; }
      public string IDPropertyName { get { return _prop; } }
      public object Value { get { return _prop; } }
   }
}