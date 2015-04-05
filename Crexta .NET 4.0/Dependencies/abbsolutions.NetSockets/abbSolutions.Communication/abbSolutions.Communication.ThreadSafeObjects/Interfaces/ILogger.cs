using System;
using System.ComponentModel;

namespace abbSolutions.Communication.ThreadSafeObjects
{
    public enum LogSeverity
    {        
        DebugInformation= 0,
        DebugWarning = 1,
        DebugError = 2,
        DebugCritical = 3,
        Information = 4,
        Warning = 5,
        Error = 6,
        Critical = 7,
        Max = 8
    }

   [Browsable(true), TypeConverter(typeof(ExpandableObjectConverter))]
   public interface ILogger
   {
       bool AddLogListener(ILogListener listener);
       bool RemoveLogListener(ILogListener listener);
       void Log(string messageType, string message, LogSeverity severity);
       void Log(Exception ex, LogSeverity severity, bool verbose);
       void Log(Exception ex, string message, LogSeverity severity, bool verbose);
       void SetFilter(LogSeverity severity, bool logThisSeverityLevel);

       string FileNameBase { get; set; }
       bool WantExit { get; set; }
       void BeginLogging();
       bool[] LogFilter { get; }       
   }
}
