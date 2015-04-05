/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */
using System;
using System.Linq;

using log4net.Config;
using log4net;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net.Appender;

using Crexta.Common.Enums;
using log4net.Repository;

namespace Crexta.Common.Logging
{
    public class Logger
    {
        #region Members

        private readonly ILog logger;

        #endregion

        #region Constructors

        public Logger(string name, Type type)
        {
            ILoggerRepository loggerRepository = LogManager.CreateRepository(name + "Repository");
            ThreadContext.Properties["LogName"] = name;
            log4net.Config.XmlConfigurator.Configure(loggerRepository);

            this.logger = LogManager.GetLogger(name + "Repository", "CrextaLogger");
        }

        #endregion

        #region Methods

        public void WriteLog(LogLevel logLevel, String log)
        {
            if (logLevel.Equals(LogLevel.DEBUG))
                logger.Debug(log);

            else if (logLevel.Equals(LogLevel.ERROR))
                logger.Error(log);

            else if (logLevel.Equals(LogLevel.FATAL))
                logger.Fatal(log);
            else if (logLevel.Equals(LogLevel.INFO))
                logger.Info(log);
            else if (logLevel.Equals(LogLevel.WARN))
                logger.Warn(log);
        }

        #endregion

        #region Properties

        #endregion
    }
}
