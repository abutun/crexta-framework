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
using Crexta.Common.Enums;
using System.IO;

namespace Crexta.Common.Constants
{
    public class DataExtractorConstants
    {
        public const int defaultCrawlLogUISize = 100;

        public const int defaultErrorLogUISize = 100;

        public const int defaultCrawlThreadCount = 15;

        public const int defaultCrawlerQueueTopSelect = 20;

        public const int defaultCrawlDeptLevel = 10;

        public const int defaultCrawlerExtractHourThreshold = 24;

        public const int defaultCrawlerExtractMinuteThreshold = 0;

        public const bool defaultDumpResultsToFile = true;

        public const bool defaultAllowInheritanceForCrextors = true;

        public const bool defaultAllowInheritanceForRules = true;

        public const bool defaultAllowInheritanceForCriterias = true;

        public const bool defaultReflectPredictedBrandID2DB = false;

        public const bool defaultReflectPredictedCategoryID2DB = false;

        public const bool defaultUseWatiNBuiltInBrowser = false;

        public const string defaultCrawlerInstanceName = "Crawler #1";

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
        /// Default value for max value of defaultUnpressedTimeThreshHold
        /// </summary>
        public const int defaultMaxUnpressedTimeThreshHold = 120; //Seconds
        
        /// <summary>
        /// Default value for administratorPassword
        /// </summary>
        public const string defaultAdministratorPassword = "crexta";

        /// <summary>
        /// Default keyname of HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
        /// </summary>
        public const string defaultHLMKey = "Crexta Product Crawler";

        /// <summary>
        /// Default keyname of HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run
        /// </summary>
        public const string defaultHCUKey = "Crexta Product Crawler";

        /// <summary>
        /// Default value language
        /// </summary>
        public const Languages defaultCurrentLanguage = Languages.ENGLISH;

        public static string crawlerExtractHourThreshold = "DE_crawlerExtractHourThreshold";

        public static string crawlerExtractMinuteThreshold = "DE_crawlerExtractMinuteThreshold";

        public static string crawlerCrextorRulesDirectory = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Rules\";

        public static string crawlLogUISize = "DE_crawlLogUISize";

        public static string errorLogUISize = "DE_errorLogUISize";

        public static string connectionString = "DE_connectionString";

        public static string indexingFilePath = "DE_indexingFilePath";

        public static string crawlThreadCount = "DE_crawlThreadCount";

        public static string waitingTimeInSeconds = "DE_waitingTimeInSeconds";

        public static string requestIntervalInSeconds = "DE_requestIntervalInSeconds";

        public static string requestCount = "DE_requestCount";

        public static string crawlDeptLevel = "DE_crawlDeptLevel";

        public static string dumpResultsToLogFile = "DE_dumpResultsToLogFile";

        public static string allowInheritanceForCrextors = "DE_allowInheritanceForCrextors";

        public static string allowInheritanceForRules = "DE_allowInheritanceForRules";

        public static string allowInheritanceForCriterias = "DE_allowInheritanceForCriterias";

        public static string reflectPredictedCategoryID2DB = "DE_reflectPredictedCategoryID2DB";

        public static string reflectPredictedBrandID2DB = "DE_reflectPredictedBrandID2DB";

        public static string crawlerQueueTopSelect = "DE_crawlerQueueTopSelect";

        public static string crawlerInstanceName = "DE_crawlerInstanceName";

        public static string useWatiNBuiltInBrowser = "DE_useWatiNBuiltInBrowser";

        /// <summary>
        /// Setting key of maxErrorCount
        /// </summary>
        public static string maxErrorCount = "DE_maxErrorCount";

        /// <summary>
        /// Setting key of maxCaptureFileSize
        /// </summary>
        public static string maxCaptureFileSize = "DE_maxCaptureFileSize";

        /// <summary>
        /// Setting key of language
        /// </summary>
        public static string currentLanguage = "DE_currentLanguage";
    }
}
