using System;
using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ISchedulingEngine
   {
      /// <summary>
      /// Fires up the scheduling engine
      /// </summary> 
      void StartSchedulingEngine();

      /// <summary>
      /// Schedules an event to be executed by the scheduling engine at a specified time
      /// </summary>
      /// <param name="eventToExecute"></param>
      void ScheduleEventToExecute(IExecutableWorkItem eventToExecute);

      /// <summary>
      /// Count of work items/events executed
      /// </summary>
      long WorkItemsExecuted { get; set; }

      /// <summary>
      /// Setting WantExit will begin the shutdown process of the scheduling engine
      /// </summary>
      bool WantExit { get; set; }      

      /// <summary>
      /// Keeps track of the current date/time
      /// </summary>
      DateTime CurrentDateTime { get; set; }

      /// <summary>
      /// Returns an array of ISupportsCount, which can be used to ge the count of items in each work queue
      /// </summary>
      ISupportsCount[] WorkItemQueueCounts { get; }

      /// <summary>
      /// A list of exceptions that have occurred trying to execute work items
      /// </summary>
      List<Exception> Exceptions { get; }
   }
}
