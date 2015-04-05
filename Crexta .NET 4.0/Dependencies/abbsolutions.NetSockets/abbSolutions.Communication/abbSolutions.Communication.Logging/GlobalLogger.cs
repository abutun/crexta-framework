using System;
using System.Collections.Generic;
using System.Text;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication.Interfaces
{
    public static class GlobalLogger
    {
        private static ILogger _logger;

        public static ILogger Logger { get { return _logger; } }

        public static void RegisterLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static void Log(string messageType, string message, LogSeverity severity)
        {
            if (_logger != null)
            {
                _logger.Log(messageType, message, severity);
            }
        }

        public static void Log(this Exception ex, LogSeverity severity, bool verbose)
        {
            if (_logger != null)
            {
                _logger.Log(ex, severity, verbose);
            }
        }

        public static void Log(this Exception ex, string message, LogSeverity severity, bool verbose)
        {
            if (_logger != null)
            {
                _logger.Log(ex, message, severity, verbose);
            }
        }
    }
}
