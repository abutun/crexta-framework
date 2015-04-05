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
using System.Collections;

namespace Crexta.Common.Settings
{
    /// <summary>
    /// user setting are crextord via this object
    /// it is a simple serializable dictionary
    /// </summary>
    [Serializable]
    public class SettingsBase : ICollection, ICloneable
    {
        private readonly Hashtable curSettings_ = new Hashtable();

        public SettingsBase()
        {
            // load the default settings
            LoadDefaultSettings();
        }

        public SettingsBase(ICollection Collection)
        {
            this.curSettings_ = new Hashtable();

            foreach (SettingPropery p in Collection)
                this.curSettings_.Add(p.Name, p.Value);
        }

        public object this[string propertyName]
        {
            get
            {
                if (this.Contains(propertyName))
                    return this.curSettings_[propertyName];
                else
                    return null;
            }
            set
            {
                this.curSettings_[propertyName] = value;
            }
        }

        public object this[SettingPropery prop]
        {
            get
            {
                return this[prop.Name];
            }
            set
            {
                this[prop.Name] = value;
            }
        }

        public void Add(SettingPropery prop)
        {
            this.curSettings_.Add(prop.Name, prop.Value);
        }

        public void Remove(SettingPropery prop)
        {
            this.curSettings_.Remove(prop.Name);
        }

        public void Clear()
        {
            this.curSettings_.Clear();
        }

        public bool Contains(SettingPropery prop)
        {
            return this.curSettings_.Contains(prop.Name);
        }

        public bool Contains(string properyName)
        {
            return this.curSettings_.Contains(properyName);
        }

        public void LoadDefaultSettings()
        {
            // Clear all before
            this.Clear();

            // DATA EXTRACTOR
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlLogUISize, Constants.DataExtractorConstants.defaultCrawlLogUISize));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.errorLogUISize, Constants.DataExtractorConstants.defaultErrorLogUISize));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.dumpResultsToLogFile, Constants.DataExtractorConstants.defaultDumpResultsToFile));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.connectionString, Constants.DataExtractorConstants.defaultConnectionString));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlThreadCount, Constants.DataExtractorConstants.defaultCrawlThreadCount));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlDeptLevel, Constants.DataExtractorConstants.defaultCrawlDeptLevel));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.allowInheritanceForCriterias, Constants.DataExtractorConstants.defaultAllowInheritanceForCriterias));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.allowInheritanceForRules, Constants.DataExtractorConstants.defaultAllowInheritanceForRules));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.allowInheritanceForCrextors, Constants.DataExtractorConstants.defaultAllowInheritanceForCrextors));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.maxCaptureFileSize, Constants.DataExtractorConstants.defaultMaxCaptureFileSize));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlerInstanceName, Constants.DataExtractorConstants.defaultCrawlerInstanceName));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.reflectPredictedCategoryID2DB, Constants.DataExtractorConstants.defaultReflectPredictedCategoryID2DB));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.reflectPredictedBrandID2DB, Constants.DataExtractorConstants.defaultReflectPredictedBrandID2DB));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlerQueueTopSelect, Constants.DataExtractorConstants.defaultCrawlerQueueTopSelect));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.waitingTimeInSeconds, Constants.DataExtractorConstants.defaultWaitingTimeInSeconds));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.requestIntervalInSeconds, Constants.DataExtractorConstants.defaultRequestIntervalInSeconds));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.requestCount, Constants.DataExtractorConstants.defaultRequestCount));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlerExtractHourThreshold, Constants.DataExtractorConstants.defaultCrawlerExtractHourThreshold));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.crawlerExtractMinuteThreshold, Constants.DataExtractorConstants.defaultCrawlerExtractMinuteThreshold));
            this.Add(new SettingPropery(Constants.DataExtractorConstants.useWatiNBuiltInBrowser, Constants.DataExtractorConstants.defaultUseWatiNBuiltInBrowser));

            // URL FOUNDER
            this.Add(new SettingPropery(Constants.URLFinderConstants.crawlLogUISize, Constants.URLFinderConstants.defaultCrawlLogUISize));
            this.Add(new SettingPropery(Constants.URLFinderConstants.errorLogUISize, Constants.URLFinderConstants.defaultErrorLogUISize));
            this.Add(new SettingPropery(Constants.URLFinderConstants.dumpResultsToLogFile, Constants.URLFinderConstants.defaultDumpResultsToFile));
            this.Add(new SettingPropery(Constants.URLFinderConstants.connectionString, Constants.URLFinderConstants.defaultConnectionString));
            this.Add(new SettingPropery(Constants.URLFinderConstants.crawlThreadCount, Constants.URLFinderConstants.defaultCrawlThreadCount));
            this.Add(new SettingPropery(Constants.URLFinderConstants.crawlDeptLevel, Constants.URLFinderConstants.defaultCrawlDeptLevel));
            this.Add(new SettingPropery(Constants.URLFinderConstants.maxCaptureFileSize, Constants.URLFinderConstants.defaultMaxCaptureFileSize));
            this.Add(new SettingPropery(Constants.URLFinderConstants.crawlerInstanceName, Constants.URLFinderConstants.defaultCrawlerInstanceName));
            this.Add(new SettingPropery(Constants.URLFinderConstants.crawlerQueueTopSelect, Constants.URLFinderConstants.defaultCrawlerQueueTopSelect));
            this.Add(new SettingPropery(Constants.URLFinderConstants.useU2mService, Constants.URLFinderConstants.defaultUseU2mService));
            this.Add(new SettingPropery(Constants.URLFinderConstants.waitingTimeInSeconds, Constants.URLFinderConstants.defaultWaitingTimeInSeconds));
            this.Add(new SettingPropery(Constants.URLFinderConstants.requestIntervalInSeconds, Constants.URLFinderConstants.defaultRequestIntervalInSeconds));
            this.Add(new SettingPropery(Constants.URLFinderConstants.requestCount, Constants.URLFinderConstants.defaultRequestCount));
            this.Add(new SettingPropery(Constants.URLFinderConstants.maxURLCount, Constants.URLFinderConstants.defaultMaxURLCount));

            // SERVER
            this.Add(new SettingPropery(Constants.ServerConstants.clientMaxIDLETimeInSeconds, Constants.ServerConstants.defaultClientMaxIDLETimeInSeconds));
            this.Add(new SettingPropery(Constants.ServerConstants.reflectBrandPrediction, Constants.ServerConstants.defaultReflectBrandPrediction));
            this.Add(new SettingPropery(Constants.ServerConstants.reflectCategoryPrediction, Constants.ServerConstants.defaultReflectCategoryPrediction));
            this.Add(new SettingPropery(Constants.ServerConstants.shortenURLsWithU2M, Constants.ServerConstants.defaultShortenURLsWithU2M));
            this.Add(new SettingPropery(Constants.ServerConstants.dataExtractorMultiplier, Constants.ServerConstants.defaultDataExtractorMultiplier));
            this.Add(new SettingPropery(Constants.ServerConstants.dataExtractorURLSetCount, Constants.ServerConstants.defaultDataExtractorURLSetCount));
            this.Add(new SettingPropery(Constants.ServerConstants.crawlerExtractHourThreshold, Constants.ServerConstants.defaultCrawlerExtractHourThreshold));
            this.Add(new SettingPropery(Constants.ServerConstants.crawlerExtractMinuteThreshold, Constants.ServerConstants.defaultCrawlerExtractMinuteThreshold));
            this.Add(new SettingPropery(Constants.ServerConstants.clientReConnectTimeMinutes, Constants.ServerConstants.defaultClientReConnectTimeMinutes));
            this.Add(new SettingPropery(Constants.ServerConstants.clientReConnectTimeSeconds, Constants.ServerConstants.defaultClientReConnectTimeSeconds));
            this.Add(new SettingPropery(Constants.ServerConstants.logAllEvents, Constants.ServerConstants.defaultLogAllEvents));
            this.Add(new SettingPropery(Constants.ServerConstants.dumpXMLResult2Disk, Constants.ServerConstants.defaultDumpXMLResult2Disk));
            this.Add(new SettingPropery(Constants.ServerConstants.dataExtractorUrlRetryCount, Constants.ServerConstants.defaultDataExtractorUrlRetryCount));

            //CLIENT
            this.Add(new SettingPropery(Constants.ClientConstants.logAllEvents, Constants.ClientConstants.defaultLogAllEvents));
            this.Add(new SettingPropery(Constants.ClientConstants.showNotifications, Constants.ClientConstants.defaultShowNotifications));

            // GENERAL
            this.Add(new SettingPropery(Constants.GeneralConstants.clientStartThreadPriority, Constants.GeneralConstants.defaultClientStartThreadPriority));
            this.Add(new SettingPropery(Constants.GeneralConstants.clientStopThreadPriority, Constants.GeneralConstants.defaultClientStopThreadPriority));
        }

        #region ICloneable Members

        public object Clone()
        {
            return curSettings_.Clone();
        }

        #endregion

        #region ICollection Members

        public void CopyTo(Array array, int index)
        {
            this.curSettings_.CopyTo(array, index);
        }

        public int Count
        {
            get
            {
                return this.curSettings_.Count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return this.curSettings_.IsSynchronized;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return this.curSettings_.GetEnumerator();
        }

        #endregion
    }

    [Serializable]
    public class SettingPropery
    {
        private string properyName_;
        private object properyValue_;

        public SettingPropery(string Name)
        {
            this.properyName_ = Name;
            this.properyValue_ = null;
        }

        public SettingPropery(string Name, object Value)
        {
            this.properyName_ = Name;
            this.properyValue_ = Value;
        }

        public string Name
        {
            get
            {
                return properyName_;
            }
            set
            {
                this.properyName_ = value;
            }
        }

        public object Value
        {
            get
            {
                return properyValue_;
            }
            set
            {
                this.properyValue_ = value;
            }
        }
    }

}
