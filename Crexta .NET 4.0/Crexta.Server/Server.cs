/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

#define ENABLE_UI_UPDATE

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using System.Web;
using System.Xml;
using System.Collections;
using System.Data.Common;

using abbSolutions.NetSockets;

using Crexta.Common.Server;
using Crexta.Common.Client;
using Crexta.Network.Commands.Client;
using Crexta.Network.Commands.Server;
using Crexta.Common.Crextor;
using Crexta.Common.Enums;
using Crexta.Common.UrlInfo;
using Crexta.Common.Logging;
using Crexta.Common.XML;
using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.Constants;

namespace Crexta.Server
{
    public partial class Server : Form
    {
        #region Variable Declerations

        // LAST ERROR CODE : 0x00022

        private char[] delimiterChars_ = { ' ', ',', '.', ':', '\t' };

        private const int CREXTOR_SELECTION_RETRY_COUNT = 100; // Searches 100 crextor for one Client query

        private bool s_InstanceCheckSuccess = true;
        private bool s_CheckInternetConnection = true;
        private bool s_ReflectCategoryPrediction = true;
        private bool s_ReflectBrandPrediction = true;
        private bool s_ShortenURLsWithU2M = true;
        private bool s_LogAllEvents = false;
        private bool s_DumpXMLResult2Disk = false;

        private string s_MacAddress = "";
        private string s_Instance = "1";

        private int s_DataExtractorMultiplier = 3;
        private int s_MaxListItems = 1000;
        private int s_PortNumber = -1;
        private int s_DefaultCategoryID = 0;
        private int s_DefaultBrandID = 0;
        private int s_TotalDEItemsInserted = 0;
        private int s_TotalDEItemsUpdated = 0;
        private int s_TotalUFItemsInserted = 0;
        private int s_TotalUFItemsUpdated = 0;
        private int s_DataExtractorURLSetCount = 50;
        private int s_DECrawlerDataHourThreshold = 24; // Data refresh rate (hour)
        private int s_DECrawlerDataMinuteThreshold = 0; // Data refresh rate (minute)
        private int s_ClientReConnectTimeMinutes = 5; // Client reconnect time (minute)
        private int s_ClientReConnectTimeSeconds = 0; // Data refresh rate (second)

        private int s_ClientMaxIDLETimeInSeconds = 600;
        private int s_ClientIDLETimeIncrementInSeconds = 6;
        private int s_ConnectionCheckTimerTimeInSeconds = 4;
        private int s_VersionCheckTimerTimeInSeconds = 120;

        private int s_DefaultCrextorReCrawlInterval = 48; // Hours
        private int s_DefaultDEItemUpdateInterval = 2; // Hours

        private int s_DataExtractorUrlRetryCount = 5;

        private Crexta.DataBase.Server s_Server = null;

        private Logger s_CrextaLogger;

        NetObjectServer s_CrextaServer = new NetObjectServer();

        private CategoryCollection s_CategoryCollection = new CategoryCollection();
        private BrandCollection s_BrandCollection = new BrandCollection();

        protected Dictionary<Guid, int> s_GUIDClientDBReference = new Dictionary<Guid, int>();
        protected Dictionary<int, Guid> s_ClientDBGUIDReference = new Dictionary<int, Guid>();
        protected Dictionary<Guid, int> s_ClientIDLETimeReference = new Dictionary<Guid, int>();
        
        private Thread s_MainServerStartThread = null;
        private Thread s_MainServerStopThread = null;

        private System.Timers.Timer s_ClientIDLEIncrementTimer;
        private System.Timers.Timer s_ConnectionCheckTimer;
        private System.Timers.Timer s_VersionCheckTimer;

        public delegate void UpdateMessageListDelegate(string text, bool writealso2log);

        public delegate void UpdateClientListDelegate(ClientInfo info);

        private Hashtable s_Versions = new Hashtable();

        #endregion

        #region Constructor Logic

        public Server()
        {
            InitializeComponent();

            if (!CheckInstanceID())
                s_InstanceCheckSuccess = false;
        }

        #endregion

        #region Load Event

        private void Server_Load(object sender, EventArgs e)
        {
            bool connnected2Internet = true;

            // initialize timers
            s_ClientIDLEIncrementTimer = new System.Timers.Timer(this.s_ClientIDLETimeIncrementInSeconds * 1000);
            s_ConnectionCheckTimer = new System.Timers.Timer(this.s_ConnectionCheckTimerTimeInSeconds * 1000);
            s_VersionCheckTimer = new System.Timers.Timer(this.s_VersionCheckTimerTimeInSeconds * 1000);

            // set timer elapsed event handlers
            this.s_ConnectionCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(s_ConnectionCheckTimer_Elapsed);
            this.s_ConnectionCheckTimer.Enabled = true;

            this.s_VersionCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(s_VersionCheckTimer_Elapsed);
            this.s_VersionCheckTimer.Enabled = true;

            this.s_ClientIDLEIncrementTimer.Elapsed += new System.Timers.ElapsedEventHandler(s_ClientIDLEIncrementTimer_Elapsed);
            this.s_ClientIDLEIncrementTimer.Enabled = true;

            if (!s_InstanceCheckSuccess)
            {
                Application.Exit();

                return;
            }

            this.InitLogger();

            Write2Log(LogLevel.INFO, "Server started...Loading settings...");

            Settings.LoadSettings(this.s_Instance);

            BindSettings();

            Write2Log(LogLevel.INFO, "Checking internet connection...");
            if (this.s_CheckInternetConnection)
                connnected2Internet = NetworkUtility.IsConnectedToInternet();
            Write2Log(LogLevel.INFO, "Checking internet connection...Done");

            if (connnected2Internet)
            {
                this.s_MacAddress = NetworkUtility.GetFirstOperationalMacAddress();

                //Connect web services in order to get Server Information
                try
                {
                    long uniquedbhash = Utilities.PerfectHash.GetPerfectHash(this.s_MacAddress + this.s_Instance);

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            var server = (from sr in db.Servers
                                          where sr.UniqueHash == uniquedbhash
                                          select sr).SingleOrDefault();

                            if (server != null)
                            {
                                this.s_Server = server;

                                if (this.s_Server.Id != -1)
                                {
                                    if (this.s_Server.Active)
                                    {
                                        Write2Log(LogLevel.INFO, "Retrieved server information...\r\nServer Name : " +
                                            this.s_Server.Name + "\r\nSocket : " + this.s_Server.Socket.ToString() +
                                            "\r\nMAC : " + this.s_MacAddress + "\r\nIP : " + this.s_Server.ExternalIp);

                                        // Set label values
                                        this.serverName.Text = this.s_Server.Name;
                                        this.serverPort.Text = this.s_Server.Socket.ToString();
                                        this.serverIP.Text = this.s_Server.ExternalIp;
                                        this.serverMAC.Text = this.s_MacAddress;

                                        this.s_PortNumber = this.s_Server.Socket;

                                        this.GetSystemVersions();

                                        #region Populate Category and Brand Collection in Order to be Used for Real Time Category and Brand Prediction
                                        // populate category keywords
                                        PopulateCategoryCollection();

                                        // populate brand keywords
                                        PopulateBrandCollection();
                                        #endregion

                                        #region Get Default Category and Brand ID values from DB
                                        //Get Default Category and Brand ID values from DB
                                        var defaultcategory = (from ct in db.Categories
                                                               where ct.Flags == 2024
                                                               select ct).SingleOrDefault();

                                        if (defaultcategory != null)
                                            this.s_DefaultCategoryID = defaultcategory.Id;

                                        var defaultbrand = (from br in db.Brands
                                                            where br.Flags == 2024
                                                            select br).SingleOrDefault();

                                        if (defaultbrand != null)
                                            this.s_DefaultBrandID = defaultbrand.Id;

                                        #endregion
                                    }
                                    else
                                    {
                                        MessageBox.Show("Server cannot run on this computer. Server is disabled!\nServer will now close!", 
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                        Write2Log(LogLevel.ERROR, "Server cannot run on this computer. Server is disabled!\nServer will now close!");

                                        this.Close();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Unable to find server information[0x00001]!\nServer will now close!", "Error", 
                                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    Write2Log(LogLevel.ERROR, "Unable to find server information[0x00001]!\nServer will now close!");

                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Unable to find server information[0x00002]!\nServer will now close!", "Error", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                Write2Log(LogLevel.ERROR, "Unable to find server information[0x00002]!\nServer will now close!");

                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot connect to main database[0x00003]!\nServer will now close!", "Error", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                            Write2Log(LogLevel.ERROR, "Cannot connect to main database[0x00003]!\nServer will now close!");

                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    Write2Log(LogLevel.DEBUG, DumpException(ex));

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("No Internet Connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                Write2Log(LogLevel.ERROR, "No Internet Connection!");

                this.Close();
            }

        }

        #endregion

        #region Helper Methods

        #region DumpException

        private string DumpException(Exception exception)
        {
            string result = "";
            if (exception != null)
            {
                result = "Message: " + exception.Message + "\r\nStack Trace: " + exception.StackTrace + "\r\nSource: " + exception.Source;
                if (exception.InnerException != null)
                    result += "\r\n***Inner Exception" + DumpException(exception.InnerException);
            }

            return result;
        }

        #endregion

        #region BindSettings

        private void BindSettings()
        {
            try
            {
                if (Settings.ServerSettings.Contains(ServerConstants.clientMaxIDLETimeInSeconds))
                    this.s_ClientMaxIDLETimeInSeconds = int.Parse(Settings.ServerSettings[ServerConstants.clientMaxIDLETimeInSeconds].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.dataExtractorMultiplier))
                    this.s_DataExtractorMultiplier = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorMultiplier].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.dataExtractorURLSetCount))
                    this.s_DataExtractorURLSetCount = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorURLSetCount].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.reflectBrandPrediction))
                    this.s_ReflectBrandPrediction = bool.Parse(Settings.ServerSettings[ServerConstants.reflectBrandPrediction].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.reflectCategoryPrediction))
                    this.s_ReflectCategoryPrediction = bool.Parse(Settings.ServerSettings[ServerConstants.reflectCategoryPrediction].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.shortenURLsWithU2M))
                    this.s_ShortenURLsWithU2M = bool.Parse(Settings.ServerSettings[ServerConstants.shortenURLsWithU2M].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.crawlerExtractHourThreshold))
                    this.s_DECrawlerDataHourThreshold = int.Parse(Settings.ServerSettings[ServerConstants.crawlerExtractHourThreshold].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.crawlerExtractMinuteThreshold))
                    this.s_DECrawlerDataMinuteThreshold = int.Parse(Settings.ServerSettings[ServerConstants.crawlerExtractMinuteThreshold].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.clientReConnectTimeMinutes))
                    this.s_ClientReConnectTimeMinutes = int.Parse(Settings.ServerSettings[ServerConstants.clientReConnectTimeMinutes].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.clientReConnectTimeSeconds))
                    this.s_ClientReConnectTimeSeconds = int.Parse(Settings.ServerSettings[ServerConstants.clientReConnectTimeSeconds].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.logAllEvents))
                    this.s_LogAllEvents = bool.Parse(Settings.ServerSettings[ServerConstants.logAllEvents].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.dumpXMLResult2Disk))
                    this.s_DumpXMLResult2Disk = bool.Parse(Settings.ServerSettings[ServerConstants.dumpXMLResult2Disk].ToString());

                if (Settings.ServerSettings.Contains(ServerConstants.dataExtractorUrlRetryCount))
                    this.s_DataExtractorUrlRetryCount = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorUrlRetryCount].ToString());
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured while binding settings, [code:0x00004]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        private bool IsCrextorSelectable(CREXTORS_GetDatasetResult item)
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    var schedule = (from sc in db.CrextorSchedules
                                    where sc.CrextorId == item.Id
                                    select sc).SingleOrDefault();

                    if (schedule == null || (schedule!=null && schedule.Type==0))
                    {
                        // DEFAULT RULES
                        bool isCrawled = false;

                        if (item.Crawled != null)
                            isCrawled = (bool)item.Crawled;

                        if (isCrawled)
                        {
                            // check last crawl date
                            if (item.LastCrawlStart != null)
                            {
                                DateTime lastCrawlDate = (DateTime)item.LastCrawlStart;

                                if (DateTime.Now.Subtract(lastCrawlDate).TotalHours > s_DefaultCrextorReCrawlInterval)
                                    return true; // not crawled for the last 48 hours
                            }
                            else
                                return true; // never crawled
                        }
                        else
                            return true; // not crawled yet
                    }
                    else
                    {
                        DateTime currentDate = DateTime.Now;

                        // SCHEDULER RULES
                        switch (schedule.Type)
                        {
                            case 1: // Once
                                if (schedule.Date != null && schedule.Time != null)
                                {
                                    DateTime date = (DateTime)schedule.Date;
                                    DateTime time = (DateTime)schedule.Time;

                                    DateTime crextorSchedule = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                                    if (currentDate.Subtract(crextorSchedule).TotalMinutes >= 0 && schedule.LastRun != null)
                                    {
                                        schedule.LastRun = DateTime.Now;
                                        UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled ONCE for " + crextorSchedule.ToShortDateString() + " " + crextorSchedule.ToLongTimeString() + ". Picking...", true);
     
                                        return true;
                                    }
                                }
                                break;
                            case 2: // Daily
                                if (schedule.Time != null)
                                {
                                    DateTime time = (DateTime)schedule.Time;

                                    DateTime crextorSchedule = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, time.Hour, time.Minute, time.Second);
                                    if (schedule.LastRun == null && currentDate.Subtract(crextorSchedule).TotalMinutes >= 0)
                                    {
                                        schedule.LastRun = DateTime.Now;
                                        UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled DAILY for " + crextorSchedule.ToLongTimeString() + ". Picking...", true);

                                        return true;
                                    }
                                    else if (schedule.LastRun != null)
                                    {
                                        DateTime lastRun = (DateTime)schedule.LastRun;
                                        // Optimize last run since it could have some delays!!! (Temp solutions!!!)
                                        DateTime lastRunOptimized = new DateTime(lastRun.Year, lastRun.Month, lastRun.Day, time.Hour, time.Minute, time.Second);

                                        TimeSpan sub = crextorSchedule.Subtract(lastRunOptimized);
                                        if (sub.Days > 0 || (sub.Days == 0 && sub.TotalHours >= 23 && sub.TotalMinutes >= 59))
                                        {
                                            schedule.LastRun = DateTime.Now;
                                            UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled DAILY for " + crextorSchedule.ToLongTimeString() + ". Picking...", true);

                                            return true;
                                        }
                                    }
                                }
                                break;
                            case 3: // Weekly
                                bool monday = schedule.Monday != null ? (bool)schedule.Monday : false;
                                bool tuesday = schedule.Tuesday != null ? (bool)schedule.Tuesday : false;
                                bool wednesday = schedule.Wednesday != null ? (bool)schedule.Wednesday : false;
                                bool thursday = schedule.Thursday != null ? (bool)schedule.Thursday : false;
                                bool friday = schedule.Friday != null ? (bool)schedule.Friday : false;
                                bool saturday = schedule.Saturday != null ? (bool)schedule.Saturday : false;
                                bool sunday = schedule.Sunday != null ? (bool)schedule.Sunday : false;

                                if (schedule.Time != null && 
                                    ((currentDate.DayOfWeek==DayOfWeek.Monday && monday) ||
                                    (currentDate.DayOfWeek==DayOfWeek.Thursday && tuesday ) ||
                                    (currentDate.DayOfWeek==DayOfWeek.Wednesday && wednesday) ||
                                    (currentDate.DayOfWeek==DayOfWeek.Thursday && thursday) ||
                                    (currentDate.DayOfWeek==DayOfWeek.Friday && friday) ||
                                    (currentDate.DayOfWeek==DayOfWeek.Saturday && saturday) ||
                                    (currentDate.DayOfWeek==DayOfWeek.Sunday && sunday)))
                                {
                                    DateTime time = (DateTime)schedule.Time;

                                    DateTime crextorSchedule = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, time.Hour, time.Minute, time.Second);
                                    if (schedule.LastRun == null && currentDate.Subtract(crextorSchedule).TotalMinutes >= 0)
                                    {
                                        schedule.LastRun = DateTime.Now;
                                        UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled WEEKLY for " + crextorSchedule.ToLongTimeString() + ". Picking...", true);

                                        return true;
                                    }
                                    else if (schedule.LastRun != null)
                                    {
                                        DateTime lastRun = (DateTime)schedule.LastRun;
                                        // Optimize last run since it could have some delays!!! (Temp solutions!!!)
                                        DateTime lastRunOptimized = new DateTime(lastRun.Year, lastRun.Month, lastRun.Day, time.Hour, time.Minute, time.Second);

                                        TimeSpan sub = crextorSchedule.Subtract(lastRunOptimized);
                                        if (sub.Days > 0 || (sub.Days == 0 && sub.TotalHours >= 23 && sub.TotalMinutes >= 59))
                                        {
                                            schedule.LastRun = DateTime.Now;
                                            UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled WEEKLY for " + crextorSchedule.ToLongTimeString() + ". Picking...", true);

                                            return true;
                                        }
                                    }
                                }
                                break;
                            case 4: // Timer
                                if (schedule.From != null && schedule.To != null && schedule.Minutes != null)
                                {
                                    DateTime fromDate = (DateTime)schedule.From;
                                    DateTime fromDateOptimized = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, fromDate.Hour, fromDate.Minute, fromDate.Second);

                                    DateTime toDate = (DateTime)schedule.To;
                                    DateTime toDateOptimized = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, toDate.Hour, toDate.Minute, toDate.Second);

                                    int minutes = (int)schedule.Minutes;

                                    if (currentDate.CompareTo(fromDateOptimized) >= 0 && currentDate.CompareTo(toDateOptimized) <= 0)
                                    {
                                        if (schedule.LastRun == null)
                                        {
                                            schedule.LastRun = DateTime.Now;
                                            UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled CUSTOM TIMER between " + fromDateOptimized.ToLongTimeString() + " and " + toDateOptimized.ToLongTimeString() + ". Picking...", true);

                                            return true;
                                        }
                                        else
                                        {
                                            DateTime lastRun = (DateTime)schedule.LastRun;
                                            if (currentDate.Subtract(lastRun).TotalMinutes >= minutes)
                                            {
                                                schedule.LastRun = DateTime.Now;
                                                UpdateMessageList("Crextor (Id=" + item.Id.ToString() + ") is scheduled CUSTOM TIMER between " + fromDateOptimized.ToLongTimeString() + " and " + toDateOptimized.ToLongTimeString() + ". Picking...", true);

                                                return true;
                                            }
                                        }
                                    }
                                }
                                break;
                        }
                    }
                }
            }

            return false;
        }

        private void GetSystemVersions()
        {
            // clear current versions
            this.s_Versions.Clear();

            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    var versions = from ver in db.Versions
                                   select ver;

                    foreach (Crexta.DataBase.Version version in versions)
                        this.s_Versions.Add(version.Id, version.Version1);
                }
            }
        }

        private string Try2DetermineCategory(string text, out string textkeywords)
        {
            Hashtable resultSet = new Hashtable();

            textkeywords = "";

            //get keywords of the selected criteria's text
            string[] keywords = text.Split(this.delimiterChars_, StringSplitOptions.RemoveEmptyEntries);

            //enumerate words
            foreach (string k in keywords)
            {
                //get current keyword
                //string tk = Utilities.SafeLowerCase(k);
                string tk = k.ToLower(new System.Globalization.CultureInfo("tr-TR"));

                if (textkeywords == "")
                    textkeywords += tk;
                else
                    textkeywords += "|" + tk;

                //enumerate category collection
                foreach (Category cat in this.s_CategoryCollection)
                {
                    double prodFactor = 0;

                    if (cat.Keywords.Contains(tk))
                        prodFactor += cat.Keywords[tk].KeywordFactor;

                    if (resultSet.Contains(cat.CategoryID))
                    {
                        prodFactor += Convert.ToInt32(resultSet[cat.CategoryID]);

                        resultSet[cat.CategoryID] = prodFactor;
                    }
                    else
                        resultSet.Add(cat.CategoryID, prodFactor);
                }
            }

            //sort hashtable here

            return GetProductCategory(resultSet);
        }

        private string GetProductCategory(Hashtable resultSet)
        {
            string category = this.s_DefaultCategoryID.ToString();

            double max = 0;

            foreach (object o in resultSet.Keys)
            {
                double tmpFactor = Convert.ToDouble(resultSet[o]);

                if (tmpFactor > max)
                {
                    max = tmpFactor;

                    category = o.ToString();
                }
            }

            return category + "|" + max.ToString();
        }

        private string Try2DetermineBrand(string text, out string textkeywords)
        {
            Hashtable resultSet = new Hashtable();

            textkeywords = "";

            //get keywords of the selected criteria's text
            string[] keywords = text.Split(this.delimiterChars_, StringSplitOptions.RemoveEmptyEntries);

            //enumerate words
            foreach (string k in keywords)
            {
                //get current keyword
                //string tk = Utilities.SafeLowerCase(k);
                string tk = k.ToLower(new System.Globalization.CultureInfo("tr-TR"));

                if (textkeywords == "")
                    textkeywords += tk;
                else
                    textkeywords += "|" + tk;

                //enumerate brand collection
                foreach (Brand bra in this.s_BrandCollection)
                {
                    double prodFactor = 0;

                    if (bra.Keywords.Contains(tk))
                        prodFactor += bra.Keywords[tk].KeywordFactor;

                    if (resultSet.Contains(bra.BrandID))
                    {
                        prodFactor += Convert.ToInt32(resultSet[bra.BrandID]);

                        resultSet[bra.BrandID] = prodFactor;
                    }
                    else
                        resultSet.Add(bra.BrandID, prodFactor);
                }
            }

            //sort hashtable here

            return GetProductBrand(resultSet);
        }

        private string GetProductBrand(Hashtable resultSet)
        {
            string brand = this.s_DefaultBrandID.ToString();

            double max = 0;

            foreach (object o in resultSet.Keys)
            {
                double tmpFactor = Convert.ToDouble(resultSet[o]);

                if (tmpFactor > max)
                {
                    max = tmpFactor;

                    brand = o.ToString();
                }
            }

            return brand + "|" + max.ToString();
        }

        /// <summary>
        /// Populates brand keywords into a BrandCollection
        /// </summary>
        private void PopulateBrandCollection()
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    //Get all brands from DB
                    var brands = from br in db.Brands
                                 select br;

                    //Enumerate brands
                    foreach (Crexta.DataBase.Brand bra in brands)
                    {
                        //Get keywords of the current brand
                        var keywords = from kw in db.BrandKeywords
                                       where kw.BrandId == bra.Id
                                       select kw;

                        //Enumerate brand keywords
                        KeywordTypeCollection keyTypes = new KeywordTypeCollection();
                        foreach (BrandKeyword bk in keywords)
                        {
                            //Get keyword
                            var keyword = (from kw in db.Keywords
                                           where kw.Id == bk.KwId
                                           select kw).SingleOrDefault();

                            //Add keyword to the current brand collection
                            if (keyword != null)
                                keyTypes.Add(keyword.Keyword1, bk.Factor);
                        }

                        this.s_BrandCollection.Add(bra.Name, bra.Id, keyTypes);
                    }
                }
            }
        }

        /// <summary>
        /// Populates category keywords into a CategoryCollection
        /// </summary>
        private void PopulateCategoryCollection()
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    //Get all categories from DB
                    var categories = from cat in db.Categories
                                     select cat;

                    //Enumerate categories
                    foreach (Crexta.DataBase.Category cat in categories)
                    {
                        //Get keywords of the current category
                        var keywords = from ck in db.CategoryKeywords
                                       where ck.CategoryId == cat.Id
                                       select ck;

                        //Enumerate category keywords
                        KeywordTypeCollection keyTypes = new KeywordTypeCollection();
                        foreach (CategoryKeyword ck in keywords)
                        {
                            //Get keyword
                            var keyword = (from kw in db.Keywords
                                           where kw.Id == ck.KwId
                                           select kw).SingleOrDefault();

                            //Add keyword to the current category collection
                            if (keyword != null)
                                keyTypes.Add(keyword.Keyword1, ck.Factor);
                        }

                        this.s_CategoryCollection.Add(cat.Name, cat.Id, keyTypes);
                    }
                }
            }
        }

        private void InitLogger()
        {
            try
            {
                this.s_CrextaLogger = new Logger("Server_" + this.s_Instance + ".log", typeof(Server));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.UpdateMessageList("Error occured, [code:0x00005]!..." + ex.Message, false);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        private void Write2Log(LogLevel logLevel, string message)
        {
            try
            {
                if (this.s_CrextaLogger != null)
                    this.s_CrextaLogger.WriteLog(logLevel, message);

                if (logLevel != LogLevel.INFO)
                {
                    ServerInfo serverInfo = GetServerInfo();
                    if (serverInfo != null)
                    {
                        // Store it also in db
                        CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                        if (db != null)
                        {
                            AppLog appLog = new AppLog();
                            appLog.Exception = "";
                            appLog.Level = logLevel.ToString();
                            appLog.Thread = "SERVER";
                            appLog.Logger = "[HASH=" + serverInfo.UniqueHash + ", INSTANCE:" + serverInfo.Instance + ", MAC:" + serverInfo.Mac + "]";
                            appLog.Message = message;
                            appLog.Date = DateTime.Now;

                            db.AppLogs.InsertOnSubmit(appLog);
                            db.SubmitChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // write2log parameter must be FALSE in order to prevent infinite loop!!!
                this.UpdateMessageList("Error occured, [code:0x00006]!..." + ex.Message, false);
                
                // this can cause an ifinite loop
                //Write2Log(LogLevel.ERROR, ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        private void LogAction(int type, int subtype, int refid, string instance, int action, string xfield1, string xfield2)
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    Log logger = new Log();
                    logger.Type = type;
                    logger.SubType = subtype;
                    logger.RefId = refid;
                    logger.Instance = instance;
                    logger.Machine = NetworkUtility.GetMachineName();
                    logger.Action = action;
                    logger.XField1 = xfield1;
                    logger.XField2 = xfield2;
                    logger.Date = DateTime.Now;

                    db.Logs.InsertOnSubmit(logger);

                    db.SubmitChanges();
                }
            }
        }

        private ServerInfo GetServerInfo()
        {
            if (this.s_Server != null)
            {
                try
                {
                    ServerInfo serverInfo = new ServerInfo();
                    serverInfo.ComputerName = this.s_Server.ComputerName;
                    serverInfo.ExternalIp = this.s_Server.ExternalIp;
                    serverInfo.Id = this.s_Server.Id;
                    serverInfo.Instance = this.s_Server.Instance.ToString();
                    serverInfo.LocalIp = this.s_Server.LocalIp;
                    serverInfo.Mac = this.s_Server.Mac;
                    serverInfo.Name = this.s_Server.Name;
                    serverInfo.Socket = this.s_Server.Socket;

                    return serverInfo;
                }
                catch (Exception)
                {
                    // NOP
                }
            }

            return null;
        }

        private bool CheckInstanceID()
        {
            string filePath = Utilities.Utilities.AssemblyDirectory + @"\id.ins";

            //Check Instance Unique Identifier
            if (!File.Exists(filePath))
            {
                GetInstanceID insIDForm = new GetInstanceID();

                if (insIDForm.ShowDialog() == DialogResult.Cancel)
                    return false;
            }
            else
            {
                //Check for a valid id
                StreamReader sr = new StreamReader(filePath);

                //Check for the first line
                string id = sr.ReadLine();

                sr.Close();

                if (id.Trim() == "")
                {
                    MessageBox.Show("Invalid ID file!", "Error", MessageBoxButtons.OK);

                    //Re-create the file
                    GetInstanceID insIDForm = new GetInstanceID();

                    if (insIDForm.ShowDialog() == DialogResult.Cancel)
                        return false;
                }
                else
                    this.s_Instance = id;
            }

            return true;
        }

        public void UpdateMessageList(string text, bool writealso2log)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new UpdateMessageListDelegate(
                        delegate(string innerText, bool innerwrite2log)
                        {
                            this.UpdateMessageList(innerText, innerwrite2log);
                        }), text, writealso2log);
                }
                else
                {
                    if (this.messageList.Lines.Length > this.s_MaxListItems)
                        this.messageList.Clear();

                    string[] data = text.Split("\r\n".ToCharArray());

                    this.messageList.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " - " + data[0] + Environment.NewLine);

                    for (int i = 1; i < data.Length; i++)
                    {
                        if (data[i].Trim() != "")
                            this.messageList.AppendText(data[i] + Environment.NewLine);
                    }

                    if (writealso2log && this.s_LogAllEvents)
                        Write2Log(LogLevel.INFO, text);

                    //Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00007]!..." + ex.Message, false);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        public void UpdateClientList(ClientInfo info)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new UpdateClientListDelegate(
                        delegate(ClientInfo innerInfo)
                        {
                            this.UpdateClientList(innerInfo);
                        }), info);
                }
                else
                {
                    this.clientsList.Items.Add(info);

                    //Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00008]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region StartServerMainThread

        private void StartServerMainThread()
        {
            Write2Log(LogLevel.INFO, "Starting main start thread...");

            // Check Start Thread
            if (this.s_MainServerStartThread != null)
            {
                try
                {
                    this.s_MainServerStartThread.Abort();
                }
                catch
                {
                    //NOP
                }

                this.s_MainServerStartThread = null;
            }

            // Kill Stop Thread
            try
            {
                if (this.s_MainServerStopThread != null)
                    this.s_MainServerStopThread.Abort();
            }
            catch
            {
                // NOP
            }
            this.s_MainServerStopThread = null;

            // Start in a new thread
            this.s_MainServerStartThread = new Thread(new ThreadStart(this.StartServer));
            this.s_MainServerStartThread.Name = "Crexta Server Start Thread";
            this.s_MainServerStartThread.IsBackground = true;
            this.s_MainServerStartThread.Start();

            Write2Log(LogLevel.INFO, "Starting main start thread...Done!");
        }

        #endregion

        #region Start Server

        private void StartServer()
        {
            Write2Log(LogLevel.INFO, "Starting Server...");

#if ENABLE_UI_UPDATE
            this.startServerToolStripMenuItem.Enabled = false;
            this.startButton.Enabled = false;
            this.stopServerToolStripMenuItem.Enabled = false;
            this.stopButton.Enabled = false;
#endif

            // Try to start server
            try
            {
                if (this.s_PortNumber != -1)
                {
                    ServerInfo serverInfo = GetServerInfo();

                    if (serverInfo != null)
                    {
                        if (!this.s_CrextaServer.IsOnline)
                        {
                            this.s_CrextaServer = new NetObjectServer();

                            //Set the deefault echo mode for everything that is received by the server.
                            this.s_CrextaServer.EchoMode = NetEchoMode.EchoSender;

                            //Attach event handlers
                            this.s_CrextaServer.OnClientAccepted += new NetClientAcceptedEventHandler(server_OnClientAccepted);
                            this.s_CrextaServer.OnClientConnected += new NetClientConnectedEventHandler(server_OnClientConnected);
                            this.s_CrextaServer.OnClientDisconnected += new NetClientDisconnectedEventHandler(server_OnClientDisconnected);
                            this.s_CrextaServer.OnClientRejected += new NetClientRejectedEventHandler(server_OnClientRejected);
                            this.s_CrextaServer.OnReceived += new NetClientReceivedEventHandler<NetObject>(server_OnReceived);
                            this.s_CrextaServer.OnStarted += new NetStartedEventHandler(server_OnStarted);
                            this.s_CrextaServer.OnStopped += new NetStoppedEventHandler(server_OnStopped);
                            this.s_CrextaServer.OnError += new NetExceptionEventHandler(s_CrextaServer_OnError);

                            // Start the server (LOCAL IP)
                            try
                            {
                                this.s_CrextaServer.Start(IPAddress.Parse(serverInfo.ExternalIp), serverInfo.Socket);

                                Write2Log(LogLevel.INFO, "Logging connect event...");

                                //Update status in DB
                                LogAction((int)Common.Enums.LogType.SERVER, -1, this.s_Server.Id, this.s_Instance, (int)Common.Enums.LogAction.SERVER_STARTED, "IP (remote) : " + serverInfo.ExternalIp, "Port : " + serverInfo.Socket.ToString());
#if ENABLE_UI_UPDATE
                                this.stopServerToolStripMenuItem.Enabled = true;
#endif
                            }
                            catch
                            {
                                try
                                {
                                    if (!this.s_CrextaServer.IsOnline)
                                    {
                                        this.s_CrextaServer.Start(IPAddress.Parse(serverInfo.LocalIp), serverInfo.Socket);

                                        Write2Log(LogLevel.INFO, "Logging connect event...");

                                        //Update status in DB
                                        LogAction((int)Common.Enums.LogType.SERVER, -1, this.s_Server.Id, this.s_Instance, (int)Common.Enums.LogAction.SERVER_STARTED, "IP (remote) : " + serverInfo.LocalIp, "Port : " + serverInfo.Socket.ToString());
#if ENABLE_UI_UPDATE
                                        this.stopServerToolStripMenuItem.Enabled = true;
                                        this.stopButton.Enabled = true;
#endif
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    Write2Log(LogLevel.DEBUG, DumpException(ex));

                                    //this.StopServer();
                                    this.StopServerMainThread(false);
                                }
                            }
                        }
                        else
                            this.UpdateMessageList("Server is already started...", true);
                    }
                    else
                        MessageBox.Show("Invalid server information! Server cannot start!", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("Invalid port number! Server cannot start!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                Write2Log(LogLevel.DEBUG, DumpException(ex));

                //this.StopServer();
                this.StopServerMainThread(false);
            }

            Write2Log(LogLevel.INFO, "Starting Server...Done!");
        }

        #endregion

        #region StopServerMainThread

        private void StopServerMainThread(bool appclose)
        {
            Write2Log(LogLevel.INFO, "Starting main stop thread...");

            // Check Stop Thread
            if (this.s_MainServerStopThread != null)
            {
                try
                {
                    this.s_MainServerStopThread.Abort();
                }
                catch
                {
                    //NOP
                }
                this.s_MainServerStopThread = null;
            }

            // Kill Start Thread
            try
            {
                if (this.s_MainServerStartThread != null)
                    this.s_MainServerStartThread.Abort();
            }
            catch
            {
                // NOP
            }
            this.s_MainServerStartThread = null;

            try
            {
                if (!appclose)
                {
                    // Start in a new thread
                    this.s_MainServerStopThread = new Thread(new ThreadStart(this.StopServer));
                    this.s_MainServerStopThread.Name = "Crexta Server Stop Thread";
                    this.s_MainServerStopThread.IsBackground = true;
                    this.s_MainServerStopThread.Start();
                }
                else
                    this.StopServer();
            }
            catch
            {
                // NOP
            }

            Write2Log(LogLevel.INFO, "Starting main stop thread...Done!");
        }

        #endregion

        #region Stop Server

        private void StopServer()
        {
            Write2Log(LogLevel.INFO, "Stopping Server...");

            if (this.s_CrextaServer != null)
            {
#if ENABLE_UI_UPDATE
                this.startServerToolStripMenuItem.Enabled = false;
                this.startButton.Enabled = false;
                this.stopServerToolStripMenuItem.Enabled = false;
                this.stopButton.Enabled = false;
#endif
                //try to stop server
                try
                {
                    Write2Log(LogLevel.INFO, "Aborting main thread...");
                    //stop main thread
                    try
                    {
                        if (this.s_MainServerStartThread != null)
                            this.s_MainServerStartThread.Abort();
                    }
                    catch(Exception ex)
                    {
                        this.UpdateMessageList("Error occured, [code:0x00009]!..." + ex.Message, true);
                        Write2Log(LogLevel.DEBUG, DumpException(ex));
                    }

                    Write2Log(LogLevel.INFO, "Disconnecting all connected clients...");

                    this.s_CrextaServer.DisconnectAll();

                    Thread.Sleep(1000);

                    this.s_CrextaServer.Stop();

                    // Give the server some time to clean up open connections, etc
                    Thread.Sleep(2000);

                    Write2Log(LogLevel.INFO, "Logging disconnect event...");

                    //Update status in DB
                    LogAction((int)Common.Enums.LogType.SERVER, -1, this.s_Server.Id, this.s_Instance, (int)Common.Enums.LogAction.SERVER_STOPPED, "", "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                    Write2Log(LogLevel.DEBUG, DumpException(ex));
                }

                this.s_MainServerStartThread = null;

#if ENABLE_UI_UPDATE
                this.startServerToolStripMenuItem.Enabled = true;
                this.startButton.Enabled = true;
#endif
            }
            Write2Log(LogLevel.INFO, "Stopping Server...Done!");
        }

        #endregion

        #region Handle Commands

        #region Communication Helper Methods

        private int GetColumnLength(string columname)
        {
            int length = 0; //Default

            switch (columname.ToLower())
            {
                #region Name

                case "name": length = 256;

                    break;

                #endregion

                #region Key

                case "key": length = 256;

                    break;

                #endregion

                #region City

                case "city": length = 32;

                    break;

                #endregion

                #region Region

                case "region": length = 32;

                    break;

                #endregion

                #region Address

                case "address": length = 320;

                    break;

                #endregion

                #region Location

                case "location": length = 32;

                    break;

                #endregion

                #region Tel

                case "tel": length = 32;

                    break;

                #endregion

                #region Fax

                case "fax": length = 32;

                    break;

                #endregion

                #region Map

                case "map": length = 512;

                    break;

                #endregion

                #region Website

                case "website": length = 128;

                    break;

                #endregion

                #region Image

                case "image": length = 512;

                    break;

                #endregion

                #region Description

                case "desc": length = -1; //infinite - text

                    break;

                #endregion

                default:
                    break;
            }

            return length;
        }

        private string GetProductID(XmlNodeList criterias)
        {
            string result = "";

            if (criterias != null)
            {
                foreach (XmlNode criteria in criterias)
                {
                    if (criteria.Attributes["columnName"] != null)
                    {
                        string name = criteria.Attributes["columnName"].Value.ToLowerInvariant();

                        if (name == "pid" || name == "productid" || name == "id" || name == "itemid")
                        {
                            if (criteria.HasChildNodes)
                            {
                                XmlNode itemNode = criteria.FirstChild;

                                if (itemNode != null)
                                {
                                    if (itemNode.Value != null)
                                        result = itemNode.Value.ToLowerInvariant();
                                    else
                                        result = itemNode.InnerText.ToLowerInvariant();

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private string GetCategoryID(XmlNodeList criterias)
        {
            string result = "";

            if (criterias != null)
            {
                foreach (XmlNode criteria in criterias)
                {
                    if (criteria.Attributes["columnName"] != null)
                    {
                        string name = criteria.Attributes["columnName"].Value.ToLowerInvariant();

                        if (name == "cid" || name == "categoryid" || name == "category")
                        {
                            if (criteria.HasChildNodes)
                            {
                                XmlNode itemNode = criteria.FirstChild;

                                if (itemNode != null)
                                {
                                    if (itemNode.Value != null)
                                        result = itemNode.Value.ToLowerInvariant();
                                    else
                                        result = itemNode.InnerText.ToLowerInvariant();

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private void ResetIdleTime(Guid guid)
        {
            if (this.s_ClientIDLETimeReference.ContainsKey(guid))
                this.s_ClientIDLETimeReference[guid] = 0;
        }

        private Guid GetGUIDFromClientID(int clientid)
        {
            if (this.s_ClientDBGUIDReference.ContainsKey(clientid))
                return this.s_ClientDBGUIDReference[clientid];
            else
                return Guid.Empty;
        }

        private int GetClientIDFromGUID(Guid guid)
        {
            if (this.s_GUIDClientDBReference.ContainsKey(guid))
                return this.s_GUIDClientDBReference[guid];
            else
                return -1;
        }

        /// <summary>
        /// Server decides the working type of the new connected client!!!
        /// </summary>
        /// <returns>Working mode of the client(UF(URLFinder)=1, DE(DataExtractor)=2)</returns>
        private byte GetNextWorkingModeForNewClient()
        {
            //UF : URLFinder
            //DE : DataExtractor
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    var mode1Clients = from cl in db.Clients
                                       where cl.CurrentMode == 1 && cl.Connected == true
                                       select cl;

                    if (mode1Clients != null)
                    {
                        if (mode1Clients.Count() == 0)
                            return 1; //No UF then assign one

                        //Check mode2 clients
                        var mode2Clients = from cl in db.Clients
                                           where cl.CurrentMode == 2 && cl.Connected == true
                                           select cl;

                        if (mode1Clients.Count() == 1)
                        {
                            if (mode2Clients != null)
                            {
                                if (mode2Clients.Count() == 0)
                                    return 2;//1 UF, 0 DE then assing at least one DE
                                else
                                    return 1;//1 UF, >=1 DE then assign new UF
                            }
                            else
                                return 2; //1 UF, 0 DE then assing at least one DE
                        }
                        else
                        {
                            if (mode2Clients.Count() == 0)
                                return 2;

                            //Implement 1/4 RULE HERE (UF = 4xDE)
                            if (mode1Clients.Count() < mode2Clients.Count() * this.s_DataExtractorMultiplier)
                                return 1;
                            else
                                return 2;
                        }
                    }
                    else
                        return 1; //No UF then assign one
                }
                else 
                    return 1; // DEFAULT
            }
        }

        #endregion

        #region HandleRequestURLs2Extract

        private void HandleRequestURLs2Extract(RequestURLs2Extract message)
        {
            try
            {
                IDictionary<QueueUrlInfo, CrextorInfo> waitingForExtractionURLList = new Dictionary<QueueUrlInfo, CrextorInfo>();

                int errorcode = 0;

                string errormessage = "No problem master!";

                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    this.UpdateMessageList(message.GUID + " asks for new url information...", true);

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            object syncObject = new object();

                            lock (syncObject)
                            {
                                // url is not picked up and not crawled yet
                                // ur is picked up and not crawled for the last 1 hour yet
                                var urlQueueDataSet = (from qu in db.UrlQueues
                                                        where ((!qu.Selected && !qu.Crawled) ||
                                                        (qu.Selected && !qu.Crawled && DateTime.Now.AddHours(-1) > qu.LastUpdate))
                                                        && qu.Active && qu.RetryCount <= this.s_DataExtractorUrlRetryCount
                                                        select qu).Take(this.s_DataExtractorURLSetCount);

                                if (urlQueueDataSet != null)
                                {
                                    foreach (var urlqueue in urlQueueDataSet)
                                    {
                                        QueueUrlInfo uf = new QueueUrlInfo();
                                        CrextorInfo si = new CrextorInfo();

                                        uf.QueueId = urlqueue.Id;
                                        uf.Url = HttpUtility.UrlDecode(urlqueue.Url);

                                        // Get crextor information
                                        var crextor = (from st in db.Crextors
                                                       where st.Id == urlqueue.CrextorId
                                                       select st).SingleOrDefault();

                                        if (crextor != null)
                                        {
                                            si.Id = crextor.Id;
                                            si.Name = crextor.Name;
                                            si.RuleListPath = crextor.Rule.Path;
                                            si.RuleData = crextor.Rule.Data.ToArray();
                                            si.SkipUrls = crextor.SkipUrls == null ? "" : crextor.SkipUrls;
                                            si.ExtraDomains = crextor.ExtraDomains == null ? "" : crextor.ExtraDomains;
                                            si.Url = crextor.Url;
                                        }

                                        // Update crawl start date
                                        if (!waitingForExtractionURLList.Keys.Contains(uf))
                                        {
                                            waitingForExtractionURLList.Add(uf, si);

                                            // Check if the URL present in DB and if we picked up it one more times
                                            // then increment retrycount!
                                            var queueItem = (from qu in db.UrlQueues
                                                             where qu.Id == urlqueue.Id
                                                             select qu).SingleOrDefault();

                                            if (queueItem != null)
                                            {
                                                queueItem.DEClientId = message.ClientID;
                                                queueItem.CrawlStart = DateTime.Now;
                                                queueItem.LastUpdate = DateTime.Now;
                                                queueItem.Selected = true;
                                            }
                                        }
                                    }
                                }

                                this.UpdateMessageList(message.GUID + " Picked up url list (Total: " + waitingForExtractionURLList.Count.ToString() + "). Sending list to client...", true);

                                //Prepare server command and send it to the client
                                URLInformationResponse serverAnswer = new URLInformationResponse();
                                serverAnswer.ServerID = this.s_Server.Id;
                                serverAnswer.CrextorURLs = waitingForExtractionURLList;
                                serverAnswer.ErrorCode = errorcode;
                                serverAnswer.ErrorMessage = errormessage;
                                serverAnswer.WorkerID = message.WorkerID;

                                try
                                {
                                    // submit Queue item crawl start date updates
                                    db.SubmitChanges();

                                    this.s_CrextaServer.ClientStreams[message.GUID].Send(new NetObject("This is your URL list, slave...", serverAnswer));
                                }
                                catch (Exception ex)
                                {
                                    this.UpdateMessageList("Error occured, [code:0x00010]!..." + ex.Message, true);
                                    Write2Log(LogLevel.DEBUG, DumpException(ex));
                                }
                            }
                        }
                    }
                }
                else
                {
                    errormessage = "Null client message!";
                    errorcode = 40007;
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00011]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region HandleClientWorkRequestMessage

        public void HandleClientWorkRequestMessage(RequestPermission2Work message)
        {
            try
            {
                ClientInfo clientInfo = new ClientInfo();

                int errorcode = 0;

                string errormessage = "No problem master!";

                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    this.UpdateMessageList(message.GUID.ToString() + " asks for permission to work!", true);

                    long uniquehash = Utilities.PerfectHash.GetPerfectHash(message.MAC + message.Instance);

                    byte workingmode = GetNextWorkingModeForNewClient();

                    //Construct Client information
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            // JUST IN CASE!
                            if (db.Connection.State == ConnectionState.Closed)
                                db.Connection.Open();

                            var client = (from cl in db.Clients
                                          where cl.UniqueHash == uniquehash
                                          select cl).SingleOrDefault();

                            if (client != null)
                            {
                                if (!client.Connected)
                                {
                                    DbTransaction tran = db.Connection.BeginTransaction(IsolationLevel.RepeatableRead);
                                    db.Transaction = tran;

                                    try
                                    {
                                        //CLIENT FOUND IN DB! SEND INFORMATION
                                        clientInfo = new ClientInfo();
                                        clientInfo.Id = client.Id;
                                        clientInfo.Instance = client.Instance.ToString();
                                        clientInfo.LocalIp = client.LocalIp;
                                        clientInfo.Mac = client.Mac;
                                        clientInfo.Name = client.Name;
                                        clientInfo.GuId = message.GUID;
                                        clientInfo.Mode = workingmode;

                                        //UPDATE CLIENT WORKING MODE AND CONNECTION STATUS
                                        client.CurrentMode = workingmode;
                                        client.Connected = true;

                                        // Client GUID may have been changed so update it!
                                        client.Guid = message.GUID.ToString();

                                        db.SubmitChanges();

                                        //LOG CLIENT CONNECTED EVENT
                                        Log logger = new Log();
                                        logger.Type = (int)Common.Enums.LogType.CLIENT;
                                        logger.SubType = workingmode;
                                        logger.RefId = client.Id;
                                        logger.Instance = client.Instance.ToString();
                                        logger.Machine = client.Name;
                                        logger.Action = (int)Common.Enums.LogAction.CLIENT_CONNECTED;
                                        logger.Date = DateTime.Now;
                                        logger.XField1 = this.s_Server.Id.ToString();
                                        logger.XField2 = workingmode.ToString();

                                        db.Logs.InsertOnSubmit(logger);

                                        if (this.s_ClientDBGUIDReference.ContainsKey(client.Id))
                                            this.s_ClientDBGUIDReference.Remove(client.Id);

                                        if (this.s_GUIDClientDBReference.ContainsKey(message.GUID))
                                            this.s_GUIDClientDBReference.Remove(message.GUID);

                                        this.s_ClientDBGUIDReference.Add(client.Id, message.GUID);
                                        this.s_GUIDClientDBReference.Add(message.GUID, client.Id);

                                        db.SubmitChanges();

                                        db.Transaction.Commit();
                                    }
                                    catch(Exception ex)
                                    {
                                        db.Transaction.Rollback();

                                        errormessage = "Cannot query client information! " + ex.Message;
                                        errorcode = 10006;
                                    }
                                }
                                else
                                {
                                    errormessage = "Client already connected!";
                                    errorcode = 10005;
                                }
                            }
                            else
                            {
                                DbTransaction tran1 = db.Connection.BeginTransaction(IsolationLevel.RepeatableRead);
                                db.Transaction = tran1;

                                try
                                {
                                    //INSERT NEW INCOMING CLIENT TO DB AND SEND INSERTED INFORMATION
                                    Client newClient = new Client();
                                    newClient.Name = message.Name;
                                    newClient.Instance = short.Parse(message.Instance);
                                    newClient.Connected = true;
                                    newClient.ItemCount = 0;
                                    newClient.LocalIp = message.IP;
                                    newClient.Mac = message.MAC;
                                    newClient.Guid = message.GUID.ToString();
                                    newClient.CountryId = 1;

                                    //Decide new client mode here
                                    newClient.CurrentMode = workingmode;

                                    newClient.Date = DateTime.Now;
                                    newClient.ExternalIp = message.IP;
                                    newClient.UniqueHash = uniquehash;
                                    newClient.UselocalId = false;
                                    newClient.ServerId = this.s_Server.Id;

                                    db.Clients.InsertOnSubmit(newClient);
                                    db.SubmitChanges();

                                    clientInfo = new ClientInfo();
                                    clientInfo.Id = newClient.Id;
                                    clientInfo.Instance = newClient.Instance.ToString();
                                    clientInfo.LocalIp = newClient.LocalIp;
                                    clientInfo.Mac = newClient.Mac;
                                    clientInfo.Name = newClient.Name;
                                    clientInfo.GuId = message.GUID;
                                    clientInfo.Mode = workingmode;

                                    //LOG CLIENT CONNECTED EVENT
                                    Log logger = new Log();
                                    logger.Type = (int)Common.Enums.LogType.CLIENT;
                                    logger.SubType = workingmode;
                                    logger.RefId = newClient.Id;
                                    logger.Instance = newClient.Instance.ToString();
                                    logger.Machine = newClient.Name;
                                    logger.Action = (int)Common.Enums.LogAction.CLIENT_CONNECTED;
                                    logger.Date = DateTime.Now;
                                    logger.XField1 = this.s_Server.Id.ToString();
                                    logger.XField2 = workingmode.ToString();

                                    if (this.s_ClientDBGUIDReference.ContainsKey(newClient.Id))
                                        this.s_ClientDBGUIDReference.Remove(newClient.Id);

                                    if (this.s_GUIDClientDBReference.ContainsKey(message.GUID))
                                        this.s_GUIDClientDBReference.Remove(message.GUID);

                                    this.s_ClientDBGUIDReference.Add(newClient.Id, message.GUID);
                                    this.s_GUIDClientDBReference.Add(message.GUID, newClient.Id);

                                    db.SubmitChanges();

                                    db.Transaction.Commit();
                                }
                                catch(Exception ex)
                                {
                                    db.Transaction.Rollback();

                                    errormessage = "Cannot query client information! " + ex.Message;
                                    errorcode = 20006;
                                }
                            }
                        }
                        else
                        {
                            errormessage = "Cannot connect to database!";
                            errorcode = 20007;
                        }
                    }

                    //Prepare server command and send it to the client
                    ClientInformationResponse serverAnswer = new ClientInformationResponse();
                    serverAnswer.ServerID = this.s_Server.Id;
                    serverAnswer.ClientInfo = clientInfo;
                    serverAnswer.ErrorCode = errorcode;
                    serverAnswer.ErrorMessage = errormessage;
                    serverAnswer.ReconnectTimeMinutes = s_ClientReConnectTimeMinutes;
                    serverAnswer.ReconnectTimeSeconds = s_ClientReConnectTimeSeconds;
                    serverAnswer.WorkerID = message.WorkerID;

                    try
                    {
                        this.s_CrextaServer.ClientStreams[message.GUID].Send(new NetObject("OK then...You are my slave now...", serverAnswer));
                    }
                    catch (Exception ex)
                    {
                        errormessage = "Exception occured while sending message!";
                        errorcode = 20009;

                        Write2Log(LogLevel.DEBUG, DumpException(ex));
                    }

                    if (errorcode == 0)
                        this.UpdateMessageList(message.GUID.ToString() + " is now a new slave:)", true);
                    else
                    {
                        this.UpdateMessageList(message.GUID.ToString() + " cannot be a slave! Code : " + errorcode.ToString(), true);

                        if (this.s_CrextaServer.ClientStreams.ContainsKey(message.GUID))
                            this.s_CrextaServer.DisconnectClient(message.GUID);

                        CleanUpClientReferences(message.GUID, -1);
                    }
                }
                else
                {
                    errormessage = "Null client message!";
                    errorcode = 20007;
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00012]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region HandleRequestCrextorInformationMessage

        public void HandleRequestCrextorInformationMessage(RequestCrextorInformation message)
        {
            try
            {
                CrextorInfo crextorInfo = new CrextorInfo();

                int errorcode = 0;

                string errormessage = "No problem master!";

                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    this.UpdateMessageList(message.GUID + " asks for crextor information...", true);

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            int i = 0;
                            int selectedCrextorId = -1;

                            while (i < CREXTOR_SELECTION_RETRY_COUNT && selectedCrextorId == -1)
                            {
                                var crextorDataset = db.CREXTORS_GetDataset(1, (int)Common.Enums.SequenceType.CLIENT,
                                    (int)Common.Enums.SequenceSubType.URLFINDER, message.ClientInfo.Id, message.ClientInfo.Instance, message.ClientInfo.ExternalIp,
                                    message.ClientInfo.LocalIp, message.ClientInfo.Name);

                                if (crextorDataset != null)
                                {
                                    List<CREXTORS_GetDatasetResult> crextors = crextorDataset.ToList<CREXTORS_GetDatasetResult>();

                                    // select a crextor
                                    foreach (var item in crextors)
                                    {
                                        if (IsCrextorSelectable(item))
                                        {
                                            selectedCrextorId = item.Id;
                                            break;
                                        }
                                    }
                                }

                                i++;
                            }

                            if (selectedCrextorId > 0)
                            {
                                var crextor = (from st in db.Crextors
                                               where st.Id == selectedCrextorId
                                               select st).SingleOrDefault();

                                if (crextor != null)
                                {
                                    crextorInfo = new CrextorInfo();
                                    crextorInfo.Name = crextor.Name;
                                    crextorInfo.ExtraDomains = crextor.ExtraDomains == null ? "" : crextor.ExtraDomains;
                                    crextorInfo.Id = crextor.Id;
                                    crextorInfo.RuleListPath = crextor.Rule.Path;
                                    crextorInfo.RuleData = crextor.Rule.Data.ToArray();
                                    crextorInfo.SkipUrls = crextor.SkipUrls == null ? "" : crextor.SkipUrls;
                                    crextorInfo.Url = crextor.Url;
                                    crextorInfo.UseRssUrl = crextor.UseResources;

                                    // fill rss url list
                                    if (crextor.UseResources)
                                    {
                                        var res = from rs in db.CrextorResources
                                                  where rs.CrextorId == crextor.Id && rs.TypeId == (int)Common.Enums.ResourceType.RSS && rs.Active
                                                  select rs;

                                        List<ResourceUrlInfo> rssUrlList = new List<ResourceUrlInfo>();
                                        foreach (CrextorResource r in res)
                                        {
                                            ResourceUrlInfo resourceUrlInfo = new ResourceUrlInfo();
                                            resourceUrlInfo.ItemId = r.Id;
                                            resourceUrlInfo.Url = r.Url;
                                            resourceUrlInfo.Type = Common.Enums.ResourceType.RSS;
                                            resourceUrlInfo.DiscoverRedirects = r.DiscoverRedirects;

                                            rssUrlList.Add(resourceUrlInfo);
                                        }

                                        crextorInfo.RssUrlList = rssUrlList;
                                    }

                                    // fill crextor fixed url list
                                    if (crextor.CrextorUrls != null)
                                    {
                                        var res = from rs in db.CrextorUrls
                                                  where rs.CrextorId == crextor.Id && rs.Active
                                                  orderby rs.Order
                                                  select rs;

                                        List<CustomUrlInfo> fixedUrlList = new List<CustomUrlInfo>();
                                        foreach (var u in res)
                                        {
                                            CustomUrlInfo fixedUrlInfo = new CustomUrlInfo();
                                            fixedUrlInfo.ItemId = u.Id;
                                            fixedUrlInfo.Url = u.Url;

                                            fixedUrlList.Add(fixedUrlInfo);
                                        }

                                        crextorInfo.CustomUrlList = fixedUrlList;
                                    }

                                    // if crextor is scheduled, update the last run date
                                    if (crextor.CrextorSchedule != null)
                                    {
                                        crextor.CrextorSchedule.LastRun = DateTime.Now;
                                        db.SubmitChanges();
                                    }
                                }
                                else
                                {
                                    errormessage = "Null crextor value!";
                                    errorcode = 30002;
                                }
                            }
                            else
                            {
                                errormessage = "No crextor information found to crawl!";
                                errorcode = 30005;
                            }
                        }
                        else
                        {
                            errormessage = "Cannot connect to database!";
                            errorcode = 30004;
                        }
                    }

                    //Prepare server command and send it to the client
                    CrextorInformationResponse serverAnswer = new CrextorInformationResponse();
                    serverAnswer.CrextorInfo = crextorInfo;
                    serverAnswer.ErrorCode = errorcode;
                    serverAnswer.ErrorMessage = errormessage;
                    serverAnswer.WorkerID = message.WorkerID;

                    //User can forget to fill the GUID property of message instance so use ClienInfo.GUID instead!
                    try
                    {
                        if (message.GUID == Guid.Empty)
                            this.s_CrextaServer.ClientStreams[message.ClientInfo.GuId].Send(new NetObject("This is your work slave! Work on it!", serverAnswer));
                        else
                            this.s_CrextaServer.ClientStreams[message.GUID].Send(new NetObject("This is your work slave! Work on it!", serverAnswer));
                    }
                    catch (Exception ex)
                    {
                        errorcode = 30008;
                        errormessage = "Exception occured while sending message!";

                        Write2Log(LogLevel.DEBUG, DumpException(ex));
                    }

                    if (errorcode == 0)
                    {
                        if (message.GUID == Guid.Empty)
                            this.UpdateMessageList(message.ClientInfo.GuId + " crextor information sent...", true);
                        else
                            this.UpdateMessageList(message.GUID + " crextor information sent...", true);
                    }
                    else
                    {
                        if (message.GUID == Guid.Empty)
                            this.UpdateMessageList(message.ClientInfo.GuId + " " + errormessage + " Code : " + errorcode.ToString(), true);
                        else
                            this.UpdateMessageList(message.GUID + " " + errormessage + " Code : " + errorcode.ToString(), true);
                    }
                }
                else
                {
                    errormessage = "Null client message!";
                    errorcode = 30007;
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00013]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region HandleInformNewUrlFoundedMessage

        private void HandleInformNewUrlFoundedMessage(InformNewUrlFounded message)
        {
            try
            {
                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            using (Crexta.Server.me.u2m.WebService u2m = new Crexta.Server.me.u2m.WebService())
                            {
                                foreach (ClientUrlInfo clientUrlInfo in message.UrlList)
                                {
                                    if (clientUrlInfo.Url != null)
                                    {
                                        string currentItemURL = clientUrlInfo.Url;
                                        string urlMiniPart = "";

                                        //U2M.ME SERVICE HERE!
                                        try
                                        {
                                            if (this.s_ShortenURLsWithU2M)
                                                urlMiniPart = u2m.url2mini(currentItemURL).MiniURL;
                                        }
                                        catch (Exception ex)
                                        {
                                            Write2Log(LogLevel.WARN, DumpException(ex));
                                        }

                                        long urlhash = Utilities.PerfectHash.GetPerfectHash(currentItemURL);

                                        //insert/update
                                        var queue = (from qu in db.UrlQueues
                                                     where qu.UrlHash == urlhash
                                                     select qu).SingleOrDefault();

                                        if (queue == null)
                                        {
                                            //insert
                                            UrlQueue queueUrl = new UrlQueue();
                                            queueUrl.CrextorId = message.CrextorID;
                                            queueUrl.ServerId = this.s_Server.Id;
                                            queueUrl.UFClientId = message.ClientID;
                                            queueUrl.ItemId = clientUrlInfo.ItemId;
                                            queueUrl.ItemType = (short)clientUrlInfo.Type;
                                            queueUrl.UrlHash = urlhash;
                                            queueUrl.UrlHash1 = Utilities.Utilities.ComputeURLHash(currentItemURL);
                                            queueUrl.Url = currentItemURL; /*No need to decode url*/
                                            queueUrl.UrlMiniPart = urlMiniPart;
                                            queueUrl.RetryCount = 0;
                                            queueUrl.CrawlStart = new DateTime(DateTime.Now.AddYears(-2).Year, 1, 1, 0, 0, 0, 0);
                                            queueUrl.CrawlFinish = new DateTime(DateTime.Now.AddYears(-2).Year, 1, 1, 0, 0, 0, 0);
                                            queueUrl.Selected = false;
                                            queueUrl.Crawled = false;
                                            queueUrl.HasError = false;
                                            queueUrl.Priority = 0;
                                            queueUrl.Created = DateTime.Now;
                                            queueUrl.Active = true;
                                            queueUrl.PubDate = clientUrlInfo.PubDate != "" ? DateTime.Parse(clientUrlInfo.PubDate) : DateTime.Now;

                                            db.UrlQueues.InsertOnSubmit(queueUrl);

                                            db.SubmitChanges();

                                            this.UpdateMessageList("Good job! A new URL inserted from the slave. GUID : " +
                                                message.GUID.ToString() + "\r\n" + currentItemURL, true);

                                            this.s_TotalUFItemsInserted++;
                                        }
                                        else
                                        {
                                            //UPDATE QUEUE ITEM

                                            //if the current URL is crawled then check it, otherwise it will already be crawled
                                            if (queue.Crawled)
                                            {
                                                //check last crawl date
                                                DateTime tmpDiff = DateTime.Now.Subtract(new TimeSpan(queue.CrawlFinish.Value.Ticks));

                                                if (tmpDiff.Hour * 60 + tmpDiff.Minute > this.s_DECrawlerDataHourThreshold * 60 + this.s_DECrawlerDataMinuteThreshold)
                                                {
                                                    bool hasError = queue.HasError;

                                                    queue.Selected = false;
                                                    queue.Crawled = false;
                                                    queue.HasError = false;
                                                    queue.LastUpdate = DateTime.Now;
                                                    if (hasError)
                                                        queue.RetryCount++;
                                                    else
                                                        queue.RetryCount = 0;

                                                    db.SubmitChanges();

                                                    this.UpdateMessageList("Good job! Existing URL updated from the slave. GUID : " +
                                                        message.GUID.ToString() + "\r\n" + currentItemURL, true);

                                                    this.s_TotalUFItemsUpdated++;
                                                }
                                            }
                                        }
                                    }
                                    else
                                        this.UpdateMessageList("Malformed(URL is NULL)", true);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00014]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region HandleInformURLsExtractedData

        private void HandleInformURLsExtractedData(InformURLsExtractedData message)
        {
            try
            {
                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    string xmlData = message.XML.ToString();

                    if (xmlData != "")
                    {
                        XmlDocument sourceXMLDoc = new XmlDocument();

                        try
                        {
                            this.UpdateMessageList("New XML document information...Parsing...\r\nGUID : " + message.GUID.ToString(), true);

                            sourceXMLDoc.LoadXml(xmlData);

                            if (sourceXMLDoc != null)
                            {
                                //Enumerate Rules
                                XmlNodeList rules = sourceXMLDoc.GetElementsByTagName("rules");

                                if (rules != null)
                                {
                                    if (rules.Count > 0)
                                    {
                                        this.UpdateMessageList("Found " + rules[0].ChildNodes.Count.ToString() + " rule(s)...Beginning DB operations...", true);

                                        using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                                        {
                                            if (db != null)
                                            {
                                                try
                                                {
                                                    int crextorid = 0;
                                                    int queueid = 0;
                                                    int loadError = 0;

                                                    //Enumerate and manipulate rule(s)
                                                    foreach (XmlNode rule in rules[0].ChildNodes)
                                                    {
                                                        crextorid = 0;
                                                        if (rule.Attributes["crextorId"] != null)
                                                            crextorid = int.Parse(rule.Attributes["crextorId"].Value);
                                                        queueid = 0;
                                                        if (rule.Attributes["queueId"] != null)
                                                            queueid = int.Parse(rule.Attributes["queueId"].Value);
                                                        loadError = 0;
                                                        if (rule.Attributes["loadError"] != null)
                                                            loadError = int.Parse(rule.Attributes["loadError"].Value);

                                                        if (crextorid > 0 && queueid > 0)
                                                        {
                                                            //Get queue and crextor object of the rule
                                                            var crextor = (from st in db.Crextors
                                                                         where st.Id == crextorid
                                                                         select st).SingleOrDefault();

                                                            var queue = (from qu in db.UrlQueues
                                                                         where qu.Id == queueid
                                                                         select qu).SingleOrDefault();

                                                            if (crextor != null && queue != null)
                                                            {
                                                                XmlNodeList criterias = rule.ChildNodes;

                                                                if (criterias != null)
                                                                {
                                                                    string productID = GetProductID(criterias);
                                                                    string categoryID = GetCategoryID(criterias);

                                                                    #region Manipulate result XML

                                                                    XmlAttribute queueUrl = sourceXMLDoc.CreateAttribute("url");
                                                                    queueUrl.Value = queue.Url;

                                                                    XmlAttribute urlMiniPart = sourceXMLDoc.CreateAttribute("miniPart");
                                                                    urlMiniPart.Value = queue.UrlMiniPart;

                                                                    XmlAttribute crextorName = sourceXMLDoc.CreateAttribute("crextor");
                                                                    crextorName.Value = crextor.Name;

                                                                    XmlAttribute crextorDescription = sourceXMLDoc.CreateAttribute("crextorDescription");
                                                                    crextorDescription.Value = crextor.Description;

                                                                    XmlAttribute hash1 = sourceXMLDoc.CreateAttribute("hash1");
                                                                    hash1.Value = queue.UrlHash.ToString();

                                                                    XmlAttribute hash2 = sourceXMLDoc.CreateAttribute("hash2");
                                                                    hash2.Value = queue.UrlHash1;

                                                                    XmlAttribute countryId = sourceXMLDoc.CreateAttribute("countryId");
                                                                    countryId.Value = crextor.CountryId.ToString();

                                                                    XmlAttribute urlTypeId = sourceXMLDoc.CreateAttribute("urlTypeId");
                                                                    urlTypeId.Value = "";

                                                                    XmlAttribute urlTypeKey = sourceXMLDoc.CreateAttribute("urlTypeKey");
                                                                    urlTypeKey.Value = "";

                                                                    XmlAttribute urlTypeName = sourceXMLDoc.CreateAttribute("urlTypeName");
                                                                    urlTypeName.Value = "";

                                                                    XmlAttribute urlTypeParentKey = sourceXMLDoc.CreateAttribute("urlTypeParentKey");
                                                                    urlTypeParentKey.Value = "";

                                                                    XmlAttribute overrideCategory = sourceXMLDoc.CreateAttribute("overrideCategory");
                                                                    overrideCategory.Value = "";

                                                                    XmlAttribute pubDate = sourceXMLDoc.CreateAttribute("pubDate");
                                                                    pubDate.Value = "";

                                                                    if (queue.ItemId > 0)
                                                                    {
                                                                        if ( queue.ItemType == (short)UrlType.RESOURCE)
                                                                        {
                                                                            urlTypeId.Value = queue.ItemId.ToString();

                                                                            var item = (from res in db.CrextorResources
                                                                                       where res.Id == queue.ItemId
                                                                                       select res).FirstOrDefault();

                                                                            if (item != null)
                                                                            {
                                                                                urlTypeKey.Value = item.Key;
                                                                                urlTypeParentKey.Value = item.ParentKey;
                                                                                urlTypeName.Value = item.Name;
                                                                                overrideCategory.Value = item.OverrideCategory ? "1" : "0";
                                                                            }

                                                                            pubDate.Value = queue.PubDate.HasValue ? queue.PubDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                                                                        }
                                                                        else if (queue.ItemType == (short)UrlType.CUSTOM)
                                                                        {
                                                                            urlTypeId.Value = queue.ItemId.ToString();

                                                                            var item = (from url in db.CrextorUrls
                                                                                        where url.Id == queue.ItemId
                                                                                        select url).FirstOrDefault();

                                                                            if (item != null)
                                                                            {
                                                                                urlTypeKey.Value = item.Key;
                                                                                urlTypeParentKey.Value = item.ParentKey;
                                                                                urlTypeName.Value = item.Name;
                                                                                overrideCategory.Value = item.OverrideCategory ? "1" : "0";
                                                                            }

                                                                            pubDate.Value = queue.PubDate.HasValue ? queue.PubDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                                                                        }
                                                                    }
                                                                    
                                                                    rule.Attributes.Append(queueUrl);
                                                                    rule.Attributes.Append(urlMiniPart);
                                                                    rule.Attributes.Append(crextorName);
                                                                    rule.Attributes.Append(crextorDescription);
                                                                    rule.Attributes.Append(urlTypeId);
                                                                    rule.Attributes.Append(urlTypeKey);
                                                                    rule.Attributes.Append(urlTypeName);
                                                                    rule.Attributes.Append(urlTypeParentKey);
                                                                    rule.Attributes.Append(overrideCategory);
                                                                    rule.Attributes.Append(pubDate);
                                                                    rule.Attributes.Append(countryId);
                                                                    rule.Attributes.Append(hash1);
                                                                    rule.Attributes.Append(hash2);

                                                                    #endregion

                                                                    // Create a new XML Doc
                                                                    XmlDocument targetXMLDoc = new XmlDocument();

                                                                    // Impoort and Append the RULE XML
                                                                    XmlNode ruleNode = targetXMLDoc.ImportNode(rule, true);
                                                                    targetXMLDoc.AppendChild(ruleNode);

                                                                    // dump to disk
                                                                    if (s_DumpXMLResult2Disk)
                                                                    {
                                                                        if (!Directory.Exists(GeneralConstants.defaultResultsFileRoot))
                                                                            Directory.CreateDirectory(GeneralConstants.defaultResultsFileRoot);

                                                                        XmlWriter writer = XmlWriter.Create(GeneralConstants.defaultResultsFileRoot + queue.Id.ToString() + ".xml");
                                                                        targetXMLDoc.WriteTo(writer);
                                                                        writer.Flush();
                                                                        writer.Close();
                                                                    }

                                                                    // We will dump XML output always but we will not allow invalid XML data in DB!
                                                                    if (!productID.Equals("") && !categoryID.Equals(""))
                                                                    {
                                                                        // We will allow failed URL crawls updates but will not allow insert the XML result in db!
                                                                        if (loadError == 0)
                                                                        {
                                                                            // check if we already have the result
                                                                            var result = (from r in db.Results
                                                                                          where r.CrextorId == queue.Crextor.Id && r.QueueId == queueid
                                                                                          select r).SingleOrDefault();

                                                                            if (result != null)
                                                                            {
                                                                                // update result xml
                                                                                if (result.LastUpdate == null || (result.LastUpdate != null && DateTime.Now.Subtract(result.LastUpdate).TotalHours > s_DefaultDEItemUpdateInterval))
                                                                                {
                                                                                    result.Result1 = targetXMLDoc.DocumentElement.GetXElement();
                                                                                    result.LastUpdate = DateTime.Now;

                                                                                    this.s_TotalDEItemsUpdated++;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                // insert result xml
                                                                                Result newResult = new Result();
                                                                                newResult.CrextorId = queue.Crextor.Id;
                                                                                newResult.ErrorCode = "0";
                                                                                newResult.ErrorText = "0";
                                                                                newResult.QueueId = queueid;
                                                                                newResult.Result1 = targetXMLDoc.DocumentElement.GetXElement();
                                                                                newResult.Date = DateTime.Now;

                                                                                db.Results.InsertOnSubmit(newResult);

                                                                                this.s_TotalDEItemsInserted++;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        loadError = 1;

                                                                        this.UpdateMessageList("ProductID or CategoryID not found! GUID : " + message.GUID.ToString(), true);

                                                                        ServerInfo serverInfo = this.GetServerInfo();

                                                                        if (serverInfo != null)
                                                                        {
                                                                            // Log error to db
                                                                            AppLog appLog = new AppLog();
                                                                            appLog.Exception = "";
                                                                            appLog.Level = "WARNING";
                                                                            appLog.Thread = "SERVER";
                                                                            appLog.Logger = "[HASH=" + serverInfo.UniqueHash + ", INSTANCE:" + serverInfo.Instance + ", MAC:" + serverInfo.Mac + "]";
                                                                            appLog.Message = "Server tried to insert XML data but found no ProductID or CategoryID! Crextor: " + crextor.Name + ", URL: " + HttpUtility.UrlDecode(queue.Url) + ", ProductID: " + productID + ", CategoryID: " + categoryID;
                                                                            appLog.Date = DateTime.Now;

                                                                            db.AppLogs.InsertOnSubmit(appLog);
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    loadError = 1;

                                                                    this.UpdateMessageList("NULL XML criteria list!", false);

                                                                    ServerInfo serverInfo = this.GetServerInfo();

                                                                    if (serverInfo != null)
                                                                    {
                                                                        // Log error to db
                                                                        AppLog appLog = new AppLog();
                                                                        appLog.Exception = "";
                                                                        appLog.Level = "WARNING";
                                                                        appLog.Thread = "SERVER";
                                                                        appLog.Logger = "[HASH=" + serverInfo.UniqueHash + ", INSTANCE:" + serverInfo.Instance + ", MAC:" + serverInfo.Mac + "]";
                                                                        appLog.Message = "NULL XML criteria list! Crextor: " + crextor.Name + ", URL: " + HttpUtility.UrlDecode(queue.Url) + ", QueueID: " + queue.Id.ToString();
                                                                        appLog.Date = DateTime.Now;

                                                                        db.AppLogs.InsertOnSubmit(appLog);
                                                                    }
                                                                }

                                                                // UPDATE QUEUE ITEM
                                                                queue.Selected = false;
                                                                queue.Crawled = true;
                                                                queue.RetryCount = 0;
                                                                queue.HasError = loadError > 0 ? true : false;
                                                                queue.CrawlFinish = DateTime.Now;
                                                                queue.LastUpdate = DateTime.Now;

                                                                db.SubmitChanges();
                                                            }
                                                            else
                                                                this.UpdateMessageList("Crextor or Queue of the rule not found in DB! GUID : " + message.GUID.ToString(), false);
                                                        }
                                                        else
                                                            this.UpdateMessageList("Crextor or Queue ID reference is zero! GUID : " + message.GUID.ToString(), false);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    this.UpdateMessageList(ex.Message, true);

                                                    Write2Log(LogLevel.ERROR, DumpException(ex));
                                                }
                                            }
                                            else
                                                this.UpdateMessageList("Cannot connect to database! : " + message.GUID.ToString(), true);
                                        }

                                        this.UpdateMessageList("Beginning DB operations...Finished...", true);
                                    }
                                    else
                                        this.UpdateMessageList("No rules found in the current XML document! GUID : " + message.GUID.ToString(), false);
                                }
                                else
                                    this.UpdateMessageList("NULL XML rules list! GUID : " + message.GUID.ToString(), false);
                            }
                            else
                                this.UpdateMessageList("NULL XML document! GUID : " + message.GUID.ToString(), false);
                        }
                        catch (Exception ex)
                        {
                            this.UpdateMessageList(ex.Message, true);

                            Write2Log(LogLevel.ERROR, DumpException(ex));
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00015]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region HandleUnknownCommand

        private void HandleUnknownCommand()
        {
            this.UpdateMessageList("Unknown command issued by some client!", true);
        }

        #endregion

        #region HandleKeepMeAliveMaster

        private void HandleKeepMeAliveMaster(KeepMeAliveMaster message)
        {
            if (message.GUID != Guid.Empty)
            {
                ResetIdleTime(message.GUID);

                this.UpdateMessageList("Keep alive command issued...Success...", true);
            }
        }

        #endregion

        #region HandleCrextorCrawlProcessStarted

        private void HandleCrextorCrawlProcessStarted(CrextorCrawlProcessStarted message)
        {
            try
            {
                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            var crextor = (from st in db.Crextors
                                        where st.Id == message.CrextorID
                                         select st).SingleOrDefault();

                            if (crextor != null)
                            {
                                crextor.LastCrawlStart = message.Date;

                                db.SubmitChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00016]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region HandleCrextorCrawlProcessFinished

        private void HandleCrextorCrawlProcessFinished(CrextorCrawlProcessFinished message)
        {
            try
            {
                if (message != null)
                {
                    ResetIdleTime(message.GUID);

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (db != null)
                        {
                            var crextor = (from st in db.Crextors
                                         where st.Id == message.CrextorID
                                         select st).SingleOrDefault();

                            if (crextor != null)
                            {
                                crextor.LastCrawlFinish = message.Date;
                                crextor.Crawled = true;

                                db.SubmitChanges();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00021]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #endregion

        #region Events

        #region s_CrextaServer_OnError

        private void s_CrextaServer_OnError(object sender, NetExceptionEventArgs e)
        {
            this.UpdateMessageList("Error occured, [code:0x00022]!..." + e.Exception.Message, true);
            Write2Log(LogLevel.ERROR, DumpException(e.Exception));
        }

        #endregion

        #region server_OnStopped

        private void server_OnStopped(object sender, NetStoppedEventArgs e)
        {
            this.s_ClientDBGUIDReference.Clear();
            this.s_GUIDClientDBReference.Clear();

            this.serverStatusLabel.Text = "Stopped...";

            this.UpdateMessageList("Server Stopped...", true);

            this.startServerToolStripMenuItem.Enabled = true;
            this.startButton.Enabled = true;
            this.stopServerToolStripMenuItem.Enabled = false;
            this.stopButton.Enabled = false;
        }

        #endregion

        #region server_OnStarted

        private void server_OnStarted(object sender, NetStartedEventArgs e)
        {
            this.serverStatusLabel.Text = "Started...";

            this.UpdateMessageList("Server Started...", true);

            this.startServerToolStripMenuItem.Enabled = false;
            this.startButton.Enabled = false;
            this.stopServerToolStripMenuItem.Enabled = true;
            this.stopButton.Enabled = true;
        }

        #endregion

        #region server_OnReceived

        private void server_OnReceived(object sender, NetClientReceivedEventArgs<NetObject> e)
        {
            // We could also use the "type" parameter integer and avoid reflection/etc
            Type messageType = e.Data.Object.GetType();

            if (messageType == typeof(RequestPermission2Work)) HandleClientWorkRequestMessage(e.Data.Object as RequestPermission2Work);
            else if (messageType == typeof(RequestCrextorInformation)) HandleRequestCrextorInformationMessage(e.Data.Object as RequestCrextorInformation);
            else if (messageType == typeof(RequestURLs2Extract)) HandleRequestURLs2Extract(e.Data.Object as RequestURLs2Extract);
            else if (messageType == typeof(InformNewUrlFounded)) HandleInformNewUrlFoundedMessage(e.Data.Object as InformNewUrlFounded);
            else if (messageType == typeof(InformURLsExtractedData)) HandleInformURLsExtractedData(e.Data.Object as InformURLsExtractedData);
            else if (messageType == typeof(KeepMeAliveMaster)) HandleKeepMeAliveMaster(e.Data.Object as KeepMeAliveMaster);
            else if (messageType == typeof(CrextorCrawlProcessFinished)) HandleCrextorCrawlProcessFinished(e.Data.Object as CrextorCrawlProcessFinished);
            else if (messageType == typeof(CrextorCrawlProcessStarted)) HandleCrextorCrawlProcessStarted(e.Data.Object as CrextorCrawlProcessStarted);
            else HandleUnknownCommand();
        }

        #endregion

        #region server_OnClientRejected

        private void server_OnClientRejected(object sender, NetClientRejectedEventArgs e)
        {
            this.UpdateMessageList("Client is rejected! GUID : " + e.Guid.ToString() + "\r\nReason : " + e.Reason.ToString(), true);
        }

        #endregion

        #region server_OnClientDisconnected

        private void server_OnClientDisconnected(object sender, NetClientDisconnectedEventArgs e)
        {
            try
            {
                //UPDATE SERVER's CLIENT COUNT
                if (this.s_CrextaServer != null)
                {
                    if (this.s_CrextaServer.IsOnline)
                    {
                        bool error = true;

                        using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                        {
                            if (db != null)
                            {
                                // JUST IN CASE
                                if (db.Connection.State == ConnectionState.Closed)
                                    db.Connection.Open();

                                DbTransaction tran = db.Connection.BeginTransaction(IsolationLevel.Serializable);
                                db.Transaction = tran;

                                var server = (from sr in db.Servers
                                              where sr.Id == this.s_Server.Id
                                              select sr).SingleOrDefault();

                                if (server != null)
                                {
                                    if (this.s_GUIDClientDBReference.ContainsKey(e.Guid))
                                    {
                                        //Update Client Connected Information
                                        var client = (from cl in db.Clients
                                                      where cl.Id == this.s_GUIDClientDBReference[e.Guid] && cl.Connected == true
                                                      select cl).SingleOrDefault();

                                        if (client != null)
                                        {
                                            server.ClientCount -= 1;

                                            try
                                            {
                                                client.Connected = false;

                                                db.SubmitChanges();

                                                error = false;

                                                CleanUpClientReferences(e.Guid, client.Id);

                                                //Update stats
#if ENABLE_UI_UPDATE
                                                this.totalClientCountLabel.Text = "Total Clients : " + this.s_CrextaServer.ClientCount.ToString();

                                                this.clientsList.Items.Remove(e.Guid.ToString());
#endif

                                                this.UpdateMessageList(e.Guid.ToString() + " disconnected...", true);
                                            }
                                            catch
                                            {
                                                error = true;
                                            }
                                        }
                                        else
                                        {
                                            this.UpdateMessageList(e.Guid.ToString() + " client is null or already disconnected...", false);
                                        }
                                    }
                                }

                                if (!error)
                                    tran.Commit();
                                else
                                    tran.Rollback();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        private void CleanUpClientReferences(Guid guid, int clientid)
        {
            try
            {
                if (guid != Guid.Empty)
                {
                    this.s_GUIDClientDBReference.Remove(guid);
                    this.s_ClientIDLETimeReference.Remove(guid);

                    if (clientid <= 0)
                    {
                        if (this.s_GUIDClientDBReference.ContainsKey(guid))
                            clientid = this.s_GUIDClientDBReference[guid];
                    }
                }

                if (clientid > 0)
                    this.s_ClientDBGUIDReference.Remove(clientid);
            }
            catch
            {
                // NOP
            }
        }

        #endregion

        #region server_OnClientConnected

        private void server_OnClientConnected(object sender, NetClientConnectedEventArgs e)
        {
            try
            {
                //UPDATE SERVER's CLIENT COUNT
                if (this.s_CrextaServer != null)
                {
                    if (this.s_CrextaServer.IsOnline)
                    {
                        using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                        {
                            if (db != null)
                            {
                                var server = (from sr in db.Servers
                                              where sr.Id == this.s_Server.Id
                                              select sr).SingleOrDefault();

                                if (server != null)
                                {
                                    // check if the client is already connected
                                    var client = (from c in db.Clients
                                                  where c.Guid == e.Guid.ToString() && c.Connected == false
                                                  select c).SingleOrDefault();

                                    if (client == null)
                                    {
                                        server.ClientCount += 1;

                                        db.SubmitChanges();

                                        //Send GUID Information to the Client
                                        GUIDInformationResponse serverAnswer = new GUIDInformationResponse();
                                        serverAnswer.GUID = e.Guid;
                                        serverAnswer.ServerID = this.s_Server.Id;
                                        serverAnswer.WorkerID = 0; // Send only main workers!

                                        try
                                        {
                                            this.s_CrextaServer.ClientStreams[e.Guid].Send(new NetObject("This is your GUID man. Remember this!", serverAnswer));
                                        }
                                        catch (Exception ex)
                                        {
                                            this.UpdateMessageList("Error occured, [code:0x00017]!..." + ex.Message, true);
                                            Write2Log(LogLevel.DEBUG, DumpException(ex));
                                        }

                                        this.UpdateMessageList(e.Guid.ToString() + " connected...", true);
                                    }
                                    else
                                    {
                                        this.UpdateMessageList(e.Guid.ToString() + " client is already connected...", false);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region server_OnClientAccepted

        private void server_OnClientAccepted(object sender, NetClientAcceptedEventArgs e)
        {
            this.UpdateMessageList("Client is accepted. GUID : " + e.Guid.ToString(), true);
        }

        #endregion

        #region Server_FormClosed

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StopServerMainThread(true);
        }

        #endregion

        #region s_ClientIDLEIncrementTimer_Elapsed

        private void s_ClientIDLEIncrementTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //Refresh client connections
                if (this.s_CrextaServer != null)
                {
                    if (this.s_CrextaServer.IsOnline)
                    {
                        foreach (Guid guid in this.s_CrextaServer.Clients)
                        {
                            if (this.s_ClientIDLETimeReference.ContainsKey(guid))
                                this.s_ClientIDLETimeReference[guid] = this.s_ClientIDLETimeReference[guid] + this.s_ClientIDLETimeIncrementInSeconds;
                            else
                                this.s_ClientIDLETimeReference.Add(guid, 0);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        #endregion

        #region s_VersionCheckTimer_Elapsed

        private void s_VersionCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (this.s_CrextaServer != null)
                {
                    if (this.s_CrextaServer.IsOnline)
                    {
                        if (this.s_CrextaServer.ClientCount >= 0)
                        {
                            this.UpdateMessageList("Checking system versions...", true);

                            // get current MainList version
                            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                            {
                                if (db != null)
                                {
                                    var mainlistVersion = (from ver in db.Versions
                                                           where ver.Id == 1
                                                           select ver).SingleOrDefault();

                                    if (mainlistVersion != null)
                                    {
                                        if (this.s_Versions.Contains(1))
                                        {
                                            if (mainlistVersion.Version1 != this.s_Versions[1].ToString())
                                            {
                                                // Tell all the clients to update the MainList
                                                this.UpdateMessageList("New MainList version found...Updating system...", true);

                                                //Prepare server command and send it to the clients
                                                InformSystemUpdate serverAnswer = new InformSystemUpdate();
                                                serverAnswer.ErrorCode = 0;
                                                serverAnswer.ErrorMessage = "";
                                                serverAnswer.SystemType = 1;
                                                serverAnswer.WorkerID = 0; // Alert only main workers

                                                foreach (Guid clientGuid in this.s_CrextaServer.Clients)
                                                    this.s_CrextaServer.ClientStreams[clientGuid].Send(new NetObject("Some system update available!", serverAnswer));
                                            }
                                        }
                                    }

                                    // get current Client version
                                    var clientVersion = (from ver in db.Versions
                                                           where ver.Id == 2
                                                           select ver).SingleOrDefault();

                                    if (clientVersion != null)
                                    {
                                        if (this.s_Versions.Contains(2))
                                        {
                                            if (clientVersion.Version1 != this.s_Versions[2].ToString())
                                            {
                                                // Tell all the clients to update themselves
                                                this.UpdateMessageList("New Client version found...Updating system...", true);

                                                //Prepare server command and send it to the clients
                                                InformSystemUpdate serverAnswer = new InformSystemUpdate();
                                                serverAnswer.ErrorCode = 0;
                                                serverAnswer.ErrorMessage = "";
                                                serverAnswer.SystemType = 2;
                                                serverAnswer.WorkerID = 0; // Alert only main workers

                                                foreach (Guid clientGuid in this.s_CrextaServer.Clients)
                                                    this.s_CrextaServer.ClientStreams[clientGuid].Send(new NetObject("Some system update available!", serverAnswer));
                                            }
                                        }
                                    }
                                }
                            }

                            // get latest system versions
                            this.GetSystemVersions();

                            this.UpdateMessageList("Checking system versions...Done...!", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.UpdateMessageList("Error occured, [code:0x00018]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region s_ConnectionCheckTimer_Elapsed

        private void s_ConnectionCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //Refresh client connections
                if (this.s_CrextaServer != null)
                {
                    if (this.s_CrextaServer.IsOnline)
                    {
                        if (this.s_CrextaServer.ClientCount >= 0)
                        {
                            // Check client IDLE times
                            foreach (Guid guid in this.s_CrextaServer.Clients)
                            {
                                if (this.s_ClientIDLETimeReference.ContainsKey(guid))
                                {
                                    int idleTime = this.s_ClientIDLETimeReference[guid];
                                    if (idleTime > this.s_ClientMaxIDLETimeInSeconds && this.s_ClientMaxIDLETimeInSeconds != -1)
                                    {
                                        if (this.s_CrextaServer.ClientStreams.ContainsKey(guid))
                                        {
                                            this.s_CrextaServer.DisconnectClient(guid);

                                            if (this.s_GUIDClientDBReference.ContainsKey(guid))
                                                CleanUpClientReferences(guid, this.s_GUIDClientDBReference[guid]);
                                            else
                                                CleanUpClientReferences(guid, -1);
#if ENABLE_UI_UPDATE
                                            this.UpdateMessageList("Client is in IDLE state...Disconnecting...[" + guid.ToString() + "]", true);
#endif
                                        }
                                    }
                                }
                            }

#if ENABLE_UI_UPDATE
                            this.totalClientCountLabel.Text = "Total Clients : " + this.s_CrextaServer.ClientCount.ToString();

                            int wt = 0;
                            int iot = 0;
                            ThreadPool.GetAvailableThreads(out wt, out iot);

                            this.threadInfoLabel.Text = "Threads : I/O " + iot.ToString() + ", Worker " + wt.ToString();
                            this.itemStatsLabel.Text = "UF IN : " + this.s_TotalUFItemsInserted.ToString() +
                                                       " UF UP : " + this.s_TotalUFItemsUpdated.ToString() +
                                                       " | DE IN : " + this.s_TotalDEItemsInserted.ToString() +
                                                       " DE UP : " + this.s_TotalDEItemsUpdated.ToString();

                            this.clientsList.Items.Clear();
                            foreach (Guid guid in this.s_CrextaServer.Clients)
                            {
                                string idle = "???";
                                if (this.s_ClientIDLETimeReference.ContainsKey(guid))
                                    idle = this.s_ClientIDLETimeReference[guid].ToString();
                                this.clientsList.Items.Add(guid.ToString() + "-" + idle);
                            }
#endif
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.UpdateMessageList("Error occured, [code:0x00019]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, DumpException(ex));
            }
        }

        #endregion

        #region ToolStripMenuItem Events

        private void startServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StartServerMainThread();
        }

        private void stopServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.StopServer();
            this.StopServerMainThread(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.StopServer();
            this.StopServerMainThread(true);

            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();

            form.ShowDialog();
        }

        #endregion

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.startButton)
                this.startServerToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.stopButton)
                this.stopServerToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.preferencesButton)
                this.preferencesToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.aboutButton)
                this.aboutToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.exitButton)
                this.exitToolStripMenuItem_Click(this, new EventArgs());
        }

        private void Server_Resize(object sender, EventArgs e)
        {
            //resize the toolstrip
            this.toolStrip1.Size = new Size(this.Width, this.toolStrip1.Height);
        }

        private void clientsList_MouseClick(object sender, MouseEventArgs e)
        {
            this.idleTimeToolStripMenuItem.Text = "Idle Time : ???";

            if (this.s_CrextaServer != null)
            {
                if (this.s_CrextaServer.IsOnline)
                {
                    ListBox list = (ListBox)sender;
                    if (list.SelectedIndex >= 0)
                    {
                        string item = list.SelectedItem.ToString();
                        if (item != "")
                        {
                            try
                            {
                                Guid guid = new Guid(item);
                                if (this.s_ClientIDLETimeReference.ContainsKey(guid))
                                    this.idleTimeToolStripMenuItem.Text = "Idle Time : " + this.s_ClientIDLETimeReference[guid].ToString();
                            }
                            catch
                            {
                                // NOP
                            }
                        }
                    }
                }
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences form = new Preferences(this.s_Instance);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // reload settings
                    Settings.LoadSettings(this.s_Instance);

                    this.s_ClientMaxIDLETimeInSeconds = int.Parse(Settings.ServerSettings[ServerConstants.clientMaxIDLETimeInSeconds].ToString());
                    this.s_DataExtractorMultiplier = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorMultiplier].ToString());
                    this.s_DataExtractorURLSetCount = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorURLSetCount].ToString());
                    this.s_ShortenURLsWithU2M = bool.Parse(Settings.ServerSettings[ServerConstants.shortenURLsWithU2M].ToString());
                    this.s_ReflectBrandPrediction = bool.Parse(Settings.ServerSettings[ServerConstants.reflectBrandPrediction].ToString());
                    this.s_ReflectCategoryPrediction = bool.Parse(Settings.ServerSettings[ServerConstants.reflectCategoryPrediction].ToString());
                    this.s_DECrawlerDataHourThreshold = int.Parse(Settings.ServerSettings[ServerConstants.crawlerExtractHourThreshold].ToString());
                    this.s_DECrawlerDataMinuteThreshold = int.Parse(Settings.ServerSettings[ServerConstants.crawlerExtractMinuteThreshold].ToString());
                    this.s_ClientReConnectTimeMinutes = int.Parse(Settings.ServerSettings[ServerConstants.clientReConnectTimeMinutes].ToString());
                    this.s_ClientReConnectTimeSeconds = int.Parse(Settings.ServerSettings[ServerConstants.clientReConnectTimeSeconds].ToString());
                    this.s_LogAllEvents = bool.Parse(Settings.ServerSettings[ServerConstants.logAllEvents].ToString());
                    this.s_DumpXMLResult2Disk = bool.Parse(Settings.ServerSettings[ServerConstants.dumpXMLResult2Disk].ToString());
                    this.s_DataExtractorUrlRetryCount = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorUrlRetryCount].ToString());

                    this.UpdateMessageList("New settings are applied succesfully...", false);
                }
                catch (Exception ex)
                {
                    this.UpdateMessageList("Error occured, [code:0x00020]!..." + ex.Message, true);
                    Write2Log(LogLevel.ERROR, DumpException(ex));
                }
            }
        }

        #endregion
    }
}