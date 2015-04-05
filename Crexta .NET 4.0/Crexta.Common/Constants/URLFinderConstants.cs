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

namespace Crexta.Common.Constants
{
    public class URLFinderConstants
    {
        public const int defaultCrawlLogUISize = 100;

        public const int defaultErrorLogUISize = 100;

        public const int defaultCrawlThreadCount = 4;

        public const int defaultCrawlerQueueTopSelect = 1;

        public const int defaultCrawlDeptLevel = 10;

        public const bool defaultDumpResultsToFile = true;

        public const bool defaultUseU2mService = true;

        public const string defaultCrawlerInstanceName = "URL Founder #1";

        public const string defaultConnectionString = GeneralConstants.defaultConnectionString;

        /// <summary>
        /// Security key(password) needed to encrypt/decrypt data
        /// </summary>
        public const string securityKey = GeneralConstants.securityKey;

        /// <summary>
        /// Default value for maxErrorCount
        /// </summary>
        public const int defaultMaxErrorCount = 100;

        /// <summary>
        /// Default value for max of maxErrorCount
        /// </summary>
        public const int defaultMaxMaxErrorCount = 2000;

        /// <summary>
        /// Default value for max value of maxCaptureFileSize
        /// </summary>
        public const long defaultMaxCaptureFileSize = 2147483648; // 2048 MB

        /// <summary>
        /// Default value for unpressedTimeThreshHold
        /// </summary>
        public const int defaultUnpressedTimeThreshHold = 5; //Seconds

        /// <summary>
        /// Default value for max value of defaultUnpressedTimeThreshHold
        /// </summary>
        public const int defaultMaxUnpressedTimeThreshHold = 120; //Seconds

        /// <summary>
        /// Default wait time before every request
        /// </summary>
        public const int defaultWaitingTimeInSeconds = 0; //Seconds

        /// <summary>
        /// Default request interval for interval count 
        /// </summary>
        public const int defaultRequestIntervalInSeconds = 0; //Seconds

        /// <summary>
        /// Default interval count
        /// </summary>
        public const int defaultRequestCount = 25;

        /// <summary>
        /// Default value for administratorPassword
        /// </summary>
        public const string defaultAdministratorPassword = "crexta";

        /// <summary>
        /// Default keyname of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
        /// </summary>
        public const string defaultHLMKey = "Crexta URL Founder";

        /// <summary>
        /// Default keyname of HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
        /// </summary>
        public const string defaultHCUKey = "Crexta URL Founder";

        /// <summary>
        /// URL Founder max URL count list
        /// </summary>
        public const int defaultMaxURLCount = 50;

        public static string crawlLogUISize = "UF_crawlLogUISize";

        public static string errorLogUISize = "UF_errorLogUISize";

        public static string connectionString = "UF_connectionString";

        public static string maxURLCount = "UF_maxURLCount";
        
        public static string waitingTimeInSeconds = "UF_waitingTimeInSeconds";

        public static string requestIntervalInSeconds = "UF_requestIntervalInSeconds";

        public static string requestCount = "UF_requestCount";

        public static string useU2mService = "UF_useU2mService";

        public static string crawlThreadCount = "UF_crawlThreadCount";

        public static string crawlDeptLevel = "UF_crawlDeptLevel";

        public static string dumpResultsToLogFile = "UF_dumpResultsToLogFile";

        public static string crawlerQueueTopSelect = "UF_crawlerQueueTopSelect";

        public const string crawlerInstanceName = "UF_crawlerInstanceName";

        /// <summary>
        /// Setting key of maxErrorCount
        /// </summary>
        public static string maxErrorCount = "UF_maxErrorCount";

        /// <summary>
        /// Setting key of maxCaptureFileSize
        /// </summary>
        public static string maxCaptureFileSize = "UF_maxCaptureFileSize";

        /// <summary>
        /// Setting key of language
        /// </summary>
        public static string currentLanguage = "UF_currentLanguage";
    }
}
