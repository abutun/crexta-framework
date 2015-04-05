using System;
using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface IGameEngine 
   {
      ISchedulingEngine SchedulingEngine { get; }       
      IWorld World { get; }
      ITypeLookup TypeProvider { get; }
      IPersistsWorld WorldDataStore { get; }
      ICommunicationsServer CommunicationsServer { get; }
      ILogger Log { get; }

      void Startup();
      void Shutdown();     
   }
}
