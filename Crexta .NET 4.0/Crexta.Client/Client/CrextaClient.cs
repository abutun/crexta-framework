/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

#define LIVE

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Security;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using abbSolutions.NetSockets;

using Crexta.Common.Crextor;
using Crexta.Common.Client;
using Crexta.Utilities;
using Crexta.Network.Commands.Client;
using Crexta.Network.Commands.Server;
using Crexta.Common.UrlInfo;
using Crexta.Common;
using Crexta.Common.Logging;
using Crexta.Common.Enums;
using Crexta.Common.Constants;
using Crexta.Common.Crawler;
using Crexta.Common.Registry;
using Crexta.Client.Events;

// reference to LIVE (always)
using Crexta.Client.com.crexta.www;

using ICSharpCode.SharpZipLib.Zip;
using Rss;
using NCrawler;
using NCrawler.Services;
using NCrawler.HtmlProcessor;
using WatiN.Core;
using HtmlAgilityPack;

namespace Crexta.Client
{
    public class CrextaClient
    {
        // LAST ERROR CODE : 0x00014

        public delegate void CrextorChangedEventHandler(object sender, CrextorChangedEventArgs e);
        public event CrextorChangedEventHandler CrextorChanged;

        public delegate void ClientDisconnectedEventHandler(object sender, ClientDisconnectedEventArgs e);
        public event ClientDisconnectedEventHandler ClientDisconnected;

        private int c_MaxListItems = 1000;
        private int c_WaitTimeoutAfterServerAnswer = 5000; // Miliseconds
        private int c_ServerAnswerWaitTimeout = 30; // Seconds
        private int c_UFMaxURLCount = 50; // Send founded of (N) URLs to the server
        private int c_CrawlerMaxThreadCount = 4;
        private int c_CrawlerMaxCrawlDepth = 10;
        private int c_UFWaitingTimeInSeconds = 0; // Wait before every request (for UF)
        private int c_DEWaitingTimeInSeconds = 0; // Wait before every request (for DE)
        private int c_UFMaxRequestCount = 25;
        private int c_DEMaxRequestCount = 25;
        private int c_UFRequestCounter = 0;
        private int c_DERequestCounter = 0;
        private int c_UFRequestIntervalTimeInSeconds = 10; // Request wait interval (for UF)
        private int c_DERequestIntervalTimeInSeconds = 10; // Request wait interval (for DE)
        private int c_DECrawlerDataHourThreshold = 24; // Data refresh rate
        private int c_DECrawlerDataMinuteThreshold = 0; // Data refresh rate
        private int c_ClientReconnectTimeMinutes = 5;
        private int c_ClientReconnectTimeSeconds = 0;
        private int c_NavigationTimeout = 120; //seconds

        private Hashtable c_URLHistoryTable = new Hashtable();

        private ThreadPriority c_MainStartThreadPriority = ThreadPriority.Normal;
        private ThreadPriority c_MainStopThreadPriority = ThreadPriority.Highest;

        private List<ClientUrlInfo> c_URLFinderURLList = new List<ClientUrlInfo>();

        private bool c_DEUseWatiNBuiltInBrowser = false;
        private bool c_LogAllEvents = false;

        private Logger c_CrextaLogger;

        private IDictionary<QueueUrlInfo, CrextorInfo> c_DataExtractorURLList = new Dictionary<QueueUrlInfo, CrextorInfo>();
        private IDictionary<int, byte[]> c_CrextorRuleCache = new Dictionary<int, byte[]>();

        private ManualResetEvent c_FileDownloaded = new ManualResetEvent(false);
        private ManualResetEvent c_ServerAnswered = new ManualResetEvent(false);

        private CrextorInfo c_CurrentCrextorInfo = new CrextorInfo();

        private NetObjectClient c_CrextaClient = new NetObjectClient();

        private Crawler c_CrextaCrawler;

        private Thread c_MainClientStartThread;
        private Thread c_MainClientStopThread;

        private System.Timers.Timer c_ConnectionCheckTimer = new System.Timers.Timer(300000);

        public delegate void UpdateListDelegate(string text, bool writealso2log);

        public CrextaClient(String instance, int workerID, NetObjectClient netObjectClient, ClientInfo clientInfo)
        {
            if (netObjectClient.IsConnected)
            {
                try
                {
                    ServicePointManager.MaxServicePoints = 999999;
                    ServicePointManager.DefaultConnectionLimit = 999999;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    ServicePointManager.CheckCertificateRevocationList = true;
                    ServicePointManager.EnableDnsRoundRobin = true;

                    this.WorkerID = workerID;

                    this.Instance = instance;

                    // Logger must be initialized after workerId and Instance set
                    this.c_CrextaLogger = new Logger("Worker_" + this.Instance + "_" + this.WorkerID.ToString() + ".log", typeof(CrextaClient));

                    this.c_CrextaClient = netObjectClient;

                    this.ClientInfo = clientInfo;

                    StopConnectionTimer();

                    this.c_CrextaClient.OnDisconnected += new NetDisconnectedEventHandler(c_CrextaClient_OnDisconnected);

                    this.c_CrextaClient.OnReceived += new NetReceivedEventHandler<NetObject>(c_CrextaClient_OnReceived);

                    // TODO: Inherit this values from Client Settings
                    this.c_ConnectionCheckTimer.Interval = (c_ClientReconnectTimeMinutes * 60 + c_ClientReconnectTimeSeconds) * 1000;

                    this.c_ConnectionCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(c_ConnectionCheckTimer_Elapsed);

                }
                catch (Exception ex)
                {
                    this.UpdateList("Error occured, [code:0x00001]!..." + ex.Message, false);
                    Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
                }
            }
        }

        private void c_ConnectionCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.c_CrextaClient.IsConnected)
            {
                if (this.Mode == 1)
                    DoURLFinderJob(false);
                else
                    DoDataExtractorJob(false);
            }
        }

        public void Start()
        {
            Write2Log(LogLevel.INFO, "Starting main thread...");

            // Check Start Thread
            if (this.c_MainClientStartThread != null)
            {
                try
                {
                    this.c_MainClientStartThread.Abort();
                }
                catch
                {
                    //NOP
                }

                this.c_MainClientStartThread = null;
            }

            // Kill Stop Thread
            try
            {
                if (this.c_MainClientStopThread != null)
                    this.c_MainClientStopThread.Abort();
            }
            catch
            {
                // NOP
            }
            this.c_MainClientStopThread = null;

            this.c_MainClientStartThread = new Thread(new ThreadStart(this.DoJob));
            this.c_MainClientStartThread.SetApartmentState(ApartmentState.STA);
            this.c_MainClientStartThread.IsBackground = true;
            this.c_MainClientStartThread.Priority = this.c_MainStartThreadPriority;
            this.c_MainClientStartThread.Start();

            Write2Log(LogLevel.INFO, "Starting main thread...Done!");
        }

        private void DoJob()
        {
            if (this.c_CrextaClient.IsConnected)
            {
                if (ClientInfo != null)
                {
                    if (this.Instance != "")
                    {
                        Settings.LoadSettings(this.Instance);

                        BindSettings();

                        if (Mode == 1)
                            this.DoURLFinderJob(true);
                        else
                            this.DoDataExtractorJob(true);
                    }
                    else
                        this.UpdateList("Instance is empty!", false);
                }
                else
                    this.UpdateList("Client information is null!", false);
            }
            else
                this.UpdateList("Client is not connected to any server!", false);
        }

        private void DoDataExtractorJob(bool firsttime)
        {
            if (firsttime)
                this.UpdateList("Client started [Mode=2]", true);

            try
            {
                //GET URL INFORMATION FROM SERVER
                if (this.c_CrextaClient.IsConnected)
                {
                    RequestURLs2Extract message = new RequestURLs2Extract();
                    message.ClientInfo = this.ClientInfo;
                    message.GUID = this.ClientInfo.GuId;
                    message.ClientID = this.ClientInfo.Id;
                    message.WorkerID = this.WorkerID;

                    // TODO: Cache rule data! (or not!)
                    message.IncludeRuleData = true;

                    this.UpdateList("Asking for a set of URLs to process from master...", false);

                    this.c_ServerAnswered.Reset();
                    try
                    {
                        this.c_CrextaClient.Send("Give me some URL information master! I need it...", message);
                    }
                    catch (Exception ex)
                    {
                        this.UpdateList("Error occured, [code:0x00002]!..." + ex.Message, true);
                        Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                    }
                    this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                    //Just wait a little more so that we can set variables according to the server answer
                    Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);

                    if (this.c_DataExtractorURLList.Count > 0)
                    {
                        this.UpdateList("Master sent a list of URLs! Thanks Master!Processing URLs...", true);

                        StringBuilder xml2send = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><rules>");

                        int i = 0;
                        foreach (QueueUrlInfo queueUrlInfo in this.c_DataExtractorURLList.Keys)
                        {
                            if (this.c_DataExtractorURLList.Keys.Contains(queueUrlInfo))
                            {
                                CrextorInfo crextorInfo = this.c_DataExtractorURLList[queueUrlInfo];

                                if (crextorInfo != null)
                                {
                                    if (crextorInfo.RuleData != null)
                                    {
                                        CrawlerRuleCollection crextorRuleList = (CrawlerRuleCollection)Serializer.Deserialize(crextorInfo.RuleData);

                                        if (crextorRuleList != null)
                                        {
                                            //Enumerate rules and check if the current url matches any of the rule regex
                                            int ruleIndex = crextorRuleList.GetRelevantRule(queueUrlInfo.Url);

                                            if (ruleIndex >= 0)
                                            {
                                                CrawlerRule currentRule = crextorRuleList[ruleIndex];

                                                // TODO: Instead of creating an instance for each URL, just create one outside the for-each loop and use it for all URLs
                                                using (WebClient webClient = new WebClient())
                                                {
                                                    // USE MOZILLA OR ANY OTHER USER AGENT INFORMATION SINCE SOME SERVERS MAY REJECT REQUEST FROM UNKNOWN USER AGENTS!!!
                                                    webClient.Headers.Add("user-agent", UserAgent);

                                                    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                                                    if (currentRule != null)
                                                    {
                                                        this.UpdateList("Current URL : " + queueUrlInfo.Url, true);

                                                        xml2send.Append("<rule name=\"");
                                                        xml2send.Append(currentRule.Name != null ? SecurityElement.Escape(currentRule.Name) : "");
                                                        xml2send.Append("\" tableName=\"");
                                                        xml2send.Append(currentRule.DatabaseTableName != null ? SecurityElement.Escape(currentRule.DatabaseTableName.ToLowerInvariant()) : "");
                                                        xml2send.Append("\" crextorId=\"" + SecurityElement.Escape(crextorInfo.Id.ToString()));
                                                        xml2send.Append("\" queueId=\"" + SecurityElement.Escape(queueUrlInfo.QueueId.ToString()));

                                                        #region Download Web Site

                                                        bool loadError = false;
                                                        try
                                                        {
                                                            if (this.c_DEWaitingTimeInSeconds > 0)
                                                                Thread.Sleep(this.c_DEWaitingTimeInSeconds * 1000);

                                                            webClient.Encoding = currentRule.Encoding;
                                                            if (currentRule.ClickItem == null)
                                                            {
                                                                if (this.c_DEUseWatiNBuiltInBrowser)
                                                                {
                                                                    using (var browser = new IE(false))
                                                                    {
                                                                        WatiN.Core.Settings.WaitForCompleteTimeOut = this.c_NavigationTimeout;
                                                                        browser.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.Hide);
                                                                        browser.GoTo(queueUrlInfo.Url);

                                                                        htmlDoc.LoadHtml(browser.Html);
                                                                    }
                                                                }
                                                                else
                                                                    htmlDoc.LoadHtml(webClient.DownloadString(queueUrlInfo.Url));
                                                            }
                                                            else
                                                            {
                                                                htmlDoc = currentRule.ClickItem.Execute(queueUrlInfo.Url);
                                                                if (htmlDoc == null && !currentRule.ClickItem.MustClick)
                                                                {
                                                                    if (this.c_DEUseWatiNBuiltInBrowser)
                                                                    {
                                                                        using (var browser = new IE(false))
                                                                        {
                                                                            WatiN.Core.Settings.WaitForCompleteTimeOut = this.c_NavigationTimeout;
                                                                            browser.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.Hide);
                                                                            browser.GoTo(queueUrlInfo.Url);

                                                                            htmlDoc.LoadHtml(browser.Html);
                                                                        }
                                                                    }
                                                                    else
                                                                        htmlDoc.LoadHtml(webClient.DownloadString(queueUrlInfo.Url));
                                                                }
                                                            }

                                                            if (this.c_DERequestCounter >= this.c_DEMaxRequestCount)
                                                            {
                                                                Thread.Sleep(this.c_DERequestIntervalTimeInSeconds * 1000);

                                                                // reset counter
                                                                this.c_DERequestCounter = 0;
                                                            }
                                                            this.c_DERequestCounter++;
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            loadError = true;
                                                            this.UpdateList(ex.Message + "\r\nURL : " + queueUrlInfo.Url, true);
                                                        }

                                                        #endregion

                                                        #region Process HTML

                                                        if (loadError)
                                                            xml2send.Append("\" loadError=\"1\">");
                                                        else
                                                            xml2send.Append("\" loadError=\"0\">");

                                                        if (htmlDoc != null && !loadError)
                                                        {
                                                            #region Enumerate Crextor Rule's Criterias

                                                            foreach (CrawlerCriteria criteria in currentRule.Criterias)
                                                            {
                                                                xml2send.Append("<criteria name=\"");
                                                                xml2send.Append(criteria.Name != null ? SecurityElement.Escape(criteria.Name) : "");
                                                                xml2send.Append("\" columnName=\"");
                                                                xml2send.Append(criteria.ColumnName != null ? SecurityElement.Escape(criteria.ColumnName.ToLowerInvariant()) : "");
                                                                xml2send.Append("\" columnType=\"");
                                                                xml2send.Append(criteria.ColumnType != null ? SecurityElement.Escape(criteria.ColumnType.ToString().ToLowerInvariant()) : "");
                                                                xml2send.Append("\">");

                                                                //SET criteria URL in order to provide reliable match
                                                                criteria.URL = queueUrlInfo.Url;

                                                                try
                                                                {
                                                                    criteria.Match(htmlDoc);
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    this.UpdateList("Error ocurred while rule matching!\r\nURL: " + queueUrlInfo.Url + "\r\nException: " + ex.StackTrace, true);
                                                                }

                                                                if (criteria.Text2Xml != null)
                                                                    xml2send.Append(criteria.Text2Xml);

                                                                xml2send.Append("</criteria>");
                                                            }

                                                            #endregion
                                                        }

                                                        #endregion

                                                        xml2send.Append("</rule>");

                                                        // update item count 
                                                        this.TotalItemsSent2Server++;
                                                    }
                                                    else
                                                        this.UpdateList("Crextor rule index returned nothing!\r\nURL : " + queueUrlInfo.Url, true);
                                                }
                                            }
                                            else
                                                this.UpdateList("Crextor rule index not found!\r\nURL : " + queueUrlInfo.Url, true);
                                        }
                                        else
                                            this.UpdateList("Crextor rule not found!\r\nURL : " + queueUrlInfo.Url, true);
                                    }
                                    else
                                        this.UpdateList("Crextor rule data information is NULL for this URL!\r\nURL : " + queueUrlInfo.Url, true);
                                }
                                else
                                    this.UpdateList("Crextor information is NULL for this URL!\r\nURL : " + queueUrlInfo.Url, true);
                            }
                            else
                                this.UpdateList("Could not get a crextor information for this URL!\r\nURL : " + queueUrlInfo.Url, true);

                            i++;
                        }

                        xml2send.Append("</rules>");

                        //Send results to SERVER
                        InformURLsExtractedData xmlMessage = new InformURLsExtractedData();
                        xmlMessage.GUID = this.ClientInfo.GuId;
                        xmlMessage.ClientID = this.ClientInfo.Id;
                        xmlMessage.WorkerID = this.WorkerID;
                        xmlMessage.XML = xml2send;

                        this.c_ServerAnswered.Reset();
                        try
                        {
                            this.c_CrextaClient.Send("URL list extracted sir, Good job ha!", xmlMessage);
                        }
                        catch (Exception ex)
                        {
                            this.UpdateList("Error occured, [code:0x00003]!..." + ex.Message, true);
                            Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                        }
                        this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                        //Just wait a little more so that we can set variables according to the server answer
                        Thread.Sleep(this.c_ServerAnswerWaitTimeout);
                    }
                    else
                    {
                        this.UpdateList("Could not get a list of URLs! \r\nWill try again 2 minutes later...", true);

                        Thread.Sleep(new TimeSpan(0,2,0));
                    }

                    //Reset current list
                    this.c_DataExtractorURLList.Clear();

                    //Get new URL list
                    this.DoDataExtractorJob(false);
                }
                else
                {
                    this.UpdateList("Client is not connected!\r\nWill try " + 
                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " +
                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                    StartConnectionTimer(false);
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured!\r\n" + ex.Message + "\r\nWill try " +
                    this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " +
                    this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));

                StartConnectionTimer(false);
            }
        }

        private void DoURLFinderJob(bool firsttime)
        {
            if (firsttime)
                this.UpdateList("Client started [Mode=1]", true);

            try
            {
                // GET CREXTOR INFORMATION FROM SERVER
                if (this.c_CrextaClient.IsConnected)
                {
                    RequestCrextorInformation message = new RequestCrextorInformation();
                    message.ClientInfo = this.ClientInfo;
                    message.GUID = this.ClientInfo.GuId;
                    message.ClientID = this.ClientInfo.Id;
                    message.WorkerID = this.WorkerID;

                    // TODO: Cache rule data!
                    message.IncludeRuleData = true;

                    this.c_ServerAnswered.Reset();
                    try
                    {
                        this.c_CrextaClient.Send("Give me some crextor information master! I need it...", message);
                    }
                    catch (Exception ex)
                    {
                        this.UpdateList("Error occured, [code:0x00004]!..." + ex.Message, true);
                        Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                    }
                    this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                    //Just wait a little more so that we can set variables according to the server answer
                    Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);

                    if (this.c_CurrentCrextorInfo.Id > 0)
                    {
                        // Inform server that we have just started to crawl process
                        SendCrextorCrawlProcessStartedCommand();

                        bool crawlEntireWebsite = true;
                        if(this.c_CurrentCrextorInfo.UseRssUrl)
                            crawlEntireWebsite = false;

                        if(this.c_CurrentCrextorInfo.CustomUrlList!=null)
                            if(this.c_CurrentCrextorInfo.CustomUrlList.Count>0)
                                crawlEntireWebsite = false;

                        if (crawlEntireWebsite)
                        {
                            this.UpdateList("Setting up crawler in order to fetch URLs...", true);

                            NCrawler.NCrawlerModule.Setup();

                            this.c_CrextaCrawler = new Crawler(new Uri(this.c_CurrentCrextorInfo.Url),
                                new HtmlDocumentProcessor(
                                    new Dictionary<string, string>
						            {
							            {"<body", "</body>"}
						            },
                                    new Dictionary<string, string>
						            {
							            {"<head", "</head>"}
						            })
                                );

                            this.c_CrextaCrawler.MaximumCrawlDepth = this.c_CrawlerMaxCrawlDepth;
                            this.c_CrextaCrawler.MaximumThreadCount = this.c_CrawlerMaxThreadCount;

                            RegexFilter[] URLFinderExtensionsToSkip;
                            if (string.IsNullOrEmpty(this.c_CurrentCrextorInfo.SkipUrls))
                            {
                                URLFinderExtensionsToSkip = new[]
			                    {
				                    (RegexFilter)new Regex(@"(\.axd|\.jpg|\.css|\.js|\.gif|\.jpeg|\.png|\.bmp|\.avi|\.mpg|\.mpeg|\.doc|\.xls|\.pdf|\.ppt|\.rtf|\.ico|\.docx|\.xlsx|\.pptx)",
					                    RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)
			                    };
                            }
                            else
                            {
                                URLFinderExtensionsToSkip = new[]
			                    {
				                    (RegexFilter)new Regex(@"(\.axd|\.jpg|\.css|\.js|\.gif|\.jpeg|\.png|\.bmp|\.avi|\.mpg|\.mpeg|\.doc|\.xls|\.pdf|\.ppt|\.rtf|\.ico|\.docx|\.xlsx|\.pptx)",
					                    RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase),
                                    (RegexFilter)new Regex(this.c_CurrentCrextorInfo.SkipUrls, 
                                                                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)
			                    };
                            }
                            this.c_CrextaCrawler.ExcludeFilter = URLFinderExtensionsToSkip;

                            if (!string.IsNullOrEmpty(this.c_CurrentCrextorInfo.ExtraDomains))
                            {
                                this.c_CrextaCrawler.IncludeFilter = new[]
			                    {
                                    (RegexFilter)new Regex(this.c_CurrentCrextorInfo.ExtraDomains.Replace(",", "|"), 
                                                                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)
			                    };
                            }

                            this.c_CrextaCrawler.AfterDownload += new EventHandler<NCrawler.Events.AfterDownloadEventArgs>(c_Crawler_AfterDownload_Discovered);
                            this.c_CrextaCrawler.CrawlFinished += new EventHandler<NCrawler.Events.CrawlFinishedEventArgs>(c_CrextaCrawler_CrawlFinished_Discovered);
                            this.c_CrextaCrawler.Cancelled += new EventHandler<EventArgs>(c_CrextaCrawler_Cancelled_Discovered);
                            this.c_CrextaCrawler.DownloadException += new EventHandler<NCrawler.Events.DownloadExceptionEventArgs>(c_CrextaCrawler_DownloadException_Discovered);
                            this.c_CrextaCrawler.PipelineException += new EventHandler<NCrawler.Events.PipelineExceptionEventArgs>(c_CrextaCrawler_PipelineException_Discovered);
                            
                            // Begin crawl
                            try
                            {
                                this.c_CrextaCrawler.Crawl();
                            }
                            catch (Exception ex)
                            {
                                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                            }
                        }
                        else
                        {
                            bool error = false;

                            // Use resources RSS/ATOM/XML
                            if (this.c_CurrentCrextorInfo.UseRssUrl)
                            {
                                this.UpdateList("Using RSS feed in order to fetch URLs...", true);

                                try
                                {
                                    foreach (ResourceUrlInfo resourceUrlInfo in this.c_CurrentCrextorInfo.RssUrlList)
                                    {
                                        if (resourceUrlInfo.Url != null)
                                        {
                                            try
                                            {
                                                RssReader reader = new RssReader(resourceUrlInfo.Url);

                                                RssElement element;
                                                while ((element = reader.Read()) != null)
                                                {
                                                    if (element.GetType() == typeof(RssItem))
                                                    {
                                                        RssItem currentRssItem = (RssItem)element;

                                                        if (currentRssItem != null)
                                                        {
                                                            if (resourceUrlInfo.DiscoverRedirects)
                                                                CheckURLAndSendList2Server(UrlType.RESOURCE, resourceUrlInfo.ItemId, new string[] { currentRssItem.Link.ToString() }, new string[] { currentRssItem.PubDate.ToString("yyyy-MM-dd HH:mm:ss") }, false);
                                                            else
                                                            {
                                                                try
                                                                {
                                                                    Digger digger = new Digger();
                                                                    Uri finalUri = digger.Resolve(currentRssItem.Link);
                                                                    CheckURLAndSendList2Server(UrlType.RESOURCE, resourceUrlInfo.ItemId, new string[] { finalUri.ToString() }, new string[] { currentRssItem.PubDate.ToString("yyyy-MM-dd HH:mm:ss") }, false);
                                                                }
                                                                catch (Exception)
                                                                {
                                                                    this.UpdateList("Mulformed URL...Skipping...[URL: " + resourceUrlInfo.Url + "]", false);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                this.UpdateList("RSS Error...[RSS Info: " + resourceUrlInfo.Url + "]", false);
                                            }
                                        }
                                    }

                                    this.UpdateList("RSS feed fetch finished...", true);
                                }
                                catch (Exception ex)
                                {
                                    error = true;

                                    this.UpdateList("Error occured!\r\n" + ex.Message + "\r\nWill try " +
                                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " +
                                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));

                                    StartConnectionTimer(true);
                                }
                            }

                            // Custom URL lists
                            if (this.c_CurrentCrextorInfo.CustomUrlList != null)
                            {
                                if (this.c_CurrentCrextorInfo.CustomUrlList.Count > 0)
                                {
                                    try
                                    {
                                        this.UpdateList("Using custom URL list in order to fetch URLs...", true);

                                        foreach (CustomUrlInfo customUrlInfo in this.c_CurrentCrextorInfo.CustomUrlList)
                                        {
                                            try
                                            {
                                                Uri customUrlInfoUri;

                                                if (customUrlInfo.Url != "" && Uri.TryCreate(customUrlInfo.Url, UriKind.Absolute, out customUrlInfoUri))
                                                {
                                                    HtmlWeb htmlWeb = new HtmlWeb();
                                                    htmlWeb.UserAgent = UserAgent;

                                                    HtmlAgilityPack.HtmlDocument doc = htmlWeb.Load(customUrlInfo.Url);

                                                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                                                    {
                                                        HtmlAttribute currentLinkHref = link.Attributes["href"];

                                                        if (currentLinkHref.Value != "")
                                                        {
                                                            // this is mendotary since href is HTML encoded!!!
                                                            string linkHrefValue = currentLinkHref.Value.Replace("&amp;", "&");

                                                            if (!(linkHrefValue.StartsWith("http://") || linkHrefValue.StartsWith("https://") || linkHrefValue.StartsWith("www.")))
                                                            {
                                                                if (linkHrefValue.StartsWith("/"))
                                                                    linkHrefValue = "http://" + customUrlInfoUri.Host + linkHrefValue;
                                                                else
                                                                    linkHrefValue = "http://" + customUrlInfoUri.Host + "/" + linkHrefValue;
                                                            }

                                                            CheckURLAndSendList2Server(UrlType.CUSTOM, customUrlInfo.ItemId, new string[] { linkHrefValue }, null, false);
                                                        }
                                                    }
                                                }
                                                else
                                                    this.UpdateList("Invalid custom URL: " + customUrlInfo.Url, true);
                                            }
                                            catch (Exception)
                                            {
                                                this.UpdateList("Invalid custom URL: " + customUrlInfo.Url, true);
                                            }
                                        }

                                        this.UpdateList("Custom URL list fetch finished...", true);
                                    }
                                    catch (Exception ex)
                                    {
                                        error = true;

                                        this.UpdateList("Error occured!\r\n" + ex.Message + "\r\nWill try " +
                                            this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " +
                                            this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                                        Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));

                                        StartConnectionTimer(true);
                                    }
                                }
                            }

                            if (!error)
                            {
                                // Send if there are any links left in the URL list
                                CheckURLAndSendList2Server(UrlType.CRAWLER, -1, null, null, true);

                                // Inform server that we have just finished a crawl process
                                SendCrextorCrawlProcessFinisedCommand();

                                this.UpdateList("Resource and fixed URL fetching process finished! Asking for a new crextor...", true);

                                // Ask for a new crextor information
                                DoURLFinderJob(false);
                            }
                        }
                    }
                    else
                    {
                        this.UpdateList("No crextor information to crawl!\r\nWill try " + 
                            this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                            this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                        StartConnectionTimer(true);
                    }
                }
                else
                {
                    this.UpdateList("Client is not connected!\r\nWill try " + 
                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                    StartConnectionTimer(false);
                }
            }
            catch(Exception ex)
            {
                this.UpdateList("Error occured!\r\n" + ex.Message + "\r\nWill try " + 
                    this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                    this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));

                StartConnectionTimer(false);
            }
        }

        private void SendCrextorCrawlProcessFinisedCommand()
        {
            if (this.c_CurrentCrextorInfo != null)
            {
                CrextorCrawlProcessFinished message = new CrextorCrawlProcessFinished();
                message.GUID = this.ClientInfo.GuId;
                message.ClientID = this.ClientInfo.Id;
                message.CrextorID = this.c_CurrentCrextorInfo.Id;
                message.Date = DateTime.Now;
                message.WorkerID = this.WorkerID;

                this.c_ServerAnswered.Reset();
                try
                {
                    this.c_CrextaClient.Send("Yupiii, I have finished crawling a crextor...", message);
                }
                catch (Exception ex)
                {
                    this.UpdateList("Error occured, [code:0x00005]!..." + ex.Message, true);
                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                }
                this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                //Just wait a little more so that we can set variables according to the server answer
                Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);
            }
        }

        private void SendCrextorCrawlProcessStartedCommand()
        {
            if (this.c_CurrentCrextorInfo != null)
            {
                CrextorCrawlProcessStarted message = new CrextorCrawlProcessStarted();
                message.GUID = this.ClientInfo.GuId;
                message.ClientID = this.ClientInfo.Id;
                message.CrextorID = this.c_CurrentCrextorInfo.Id;
                message.Date = DateTime.Now;
                message.WorkerID = this.WorkerID;

                this.c_ServerAnswered.Reset();
                try
                {
                    this.c_CrextaClient.Send("Hey Master, I have just started crawling a crextor...", message);
                }
                catch (Exception ex)
                {
                    this.UpdateList("Error occured, [code:0x00006]!..." + ex.Message, true);
                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                }
                this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                //Just wait a little more so that we can set variables according to the server answer
                Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemId">if RSS resources/fixed urls are used, this param shows the resource/fixed url key ID.</param>
        /// <param name="currentURLs">Current URLs</param>
        /// <param name="currentURLPubDates">Pub dates</param>
        /// <param name="skipListSizeCheck">Skip the url size limit check</param>
        private void CheckURLAndSendList2Server(UrlType type, int itemId, string[] currentURLs, string[] currentURLPubDates, bool skipListSizeCheck)
        {
            try
            {
                if (this.c_CurrentCrextorInfo != null)
                {
                    //If match with crextor rule regex(any of) then add it to the list!
                    CrawlerRuleCollection crextorRuleList = (CrawlerRuleCollection)Serializer.Deserialize(this.c_CurrentCrextorInfo.RuleData);

                    if (crextorRuleList != null)
                    {
                        //Enumerate rules and check if the current url matches any of the rule regex
                        if (currentURLs != null)
                        {
                            if (currentURLs.Length > 0)
                            {
                                bool hasMatchedRule = false;
                                int i = 0;

                                while (!hasMatchedRule && i < currentURLs.Length)
                                {
                                    int ruleIndex = crextorRuleList.GetRelevantRule(currentURLs[i]);

                                    if (ruleIndex >= 0)
                                        hasMatchedRule = true;

                                    i++;
                                }

                                if (hasMatchedRule)
                                {
                                    // Check URL history
                                    string key = currentURLs[i - 1].ToLower();
                                    bool skipCurrentURL = false;

                                    if (this.c_URLHistoryTable.ContainsKey(key))
                                    {
                                        DateTime lastCrawlDateDiff = DateTime.Now.Subtract(new TimeSpan(((DateTime)this.c_URLHistoryTable[key]).Ticks));

                                        if (lastCrawlDateDiff.Hour * 60 + lastCrawlDateDiff.Minute <= this.c_DECrawlerDataHourThreshold * 60 + this.c_DECrawlerDataMinuteThreshold)
                                            skipCurrentURL = true;
                                    }

                                    if (!skipCurrentURL)
                                    {
                                        // Add it to the founded URL queue
                                        ClientUrlInfo urlInfo = new ClientUrlInfo();
                                        urlInfo.ItemId = itemId;
                                        urlInfo.Url = currentURLs[i - 1];
                                        urlInfo.Type = type;
                                        urlInfo.PubDate = currentURLPubDates != null && i < currentURLPubDates.Length ? currentURLPubDates[i] : "";

                                        this.c_URLFinderURLList.Add(urlInfo);

                                        // Add/update URL history
                                        if (!this.c_URLHistoryTable.ContainsKey(key))
                                            this.c_URLHistoryTable.Add(key, DateTime.Now);
                                        else
                                            this.c_URLHistoryTable[key] = DateTime.Now;

                                        if (type == UrlType.RESOURCE)
                                            this.UpdateList("New URL is found (Resource): " + currentURLs[i - 1], true);
                                        else if (type == UrlType.CUSTOM)
                                            this.UpdateList("New URL is found (Fixed): " + currentURLs[i - 1], true);
                                        else
                                            this.UpdateList("New URL is found (Discovered): " + currentURLs[i - 1], true);
                                    }
                                    else
                                        this.UpdateList("URL is already sent before, skipping...: " + currentURLs[i - 1], true);
                                }
                                else
                                    this.UpdateList("No rule match for: " + currentURLs[i - 1], true);
                            }
                        }

                        //If URL queue reached the maximum limit then send the list to the server
                        if (this.c_URLFinderURLList.Count >= this.c_UFMaxURLCount || (skipListSizeCheck && this.c_URLFinderURLList.Count > 0) )
                        {
                            //Check client connectivity!
                            if (this.c_CrextaClient != null)
                            {
                                this.UpdateList("Sending founded URLs...Total: " + this.c_URLFinderURLList.Count.ToString(), true);

                                InformNewUrlFounded message = new InformNewUrlFounded();
                                message.CrextorID = this.c_CurrentCrextorInfo.Id;
                                message.GUID = this.ClientInfo.GuId;
                                message.ClientID = this.ClientInfo.Id;
                                message.UrlList = this.c_URLFinderURLList;
                                message.WorkerID = this.WorkerID;

                                //this.c_ServerAnswered.Reset();
                                try
                                {
                                    this.c_CrextaClient.Send("Found new URLs, Good job ha!", message);
                                }
                                catch (Exception ex)
                                {
                                    this.UpdateList("Error occured, [code:0x00007]!..." + ex.Message, true);
                                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                                }
                                //this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                                //Just wait a little more so that we can set variables according to the server answer
                                Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);

                                // Update item count
                                this.TotalItemsSent2Server += this.c_URLFinderURLList.Count;

                                //URL history here maybe?

                                //Clear sent items
                                this.c_URLFinderURLList.Clear();
                            }
                        }
                    }
                    else
                    {
                        this.UpdateList("Method: CheckURLAndSendList2Server(), Cannot find CrextorRuleList!", true);
                        Write2Log(LogLevel.ERROR, "Method: CheckURLAndSendList2Server(), Cannot find CrextorRuleList!");
                    }
                }
                else
                {
                    this.UpdateList("Method: CheckURLAndSendList2Server(), CurrentCrextorInfo NULL!", true);
                    Write2Log(LogLevel.ERROR, "Method: CheckURLAndSendList2Server(), CurrentCrextorInfo NULL!");
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:0x00008]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        private void BindSettings()
        {
            try
            {
                // URL FINDER
                if (Settings.ClientSettings.Contains(URLFinderConstants.crawlThreadCount))
                    this.c_CrawlerMaxThreadCount = int.Parse(Settings.ClientSettings[URLFinderConstants.crawlThreadCount].ToString());

                if (Settings.ClientSettings.Contains(URLFinderConstants.crawlDeptLevel))
                    this.c_CrawlerMaxCrawlDepth = int.Parse(Settings.ClientSettings[URLFinderConstants.crawlDeptLevel].ToString());

                if (Settings.ClientSettings.Contains(URLFinderConstants.waitingTimeInSeconds))
                    this.c_UFWaitingTimeInSeconds = int.Parse(Settings.ClientSettings[URLFinderConstants.waitingTimeInSeconds].ToString());

                if (Settings.ClientSettings.Contains(URLFinderConstants.requestCount))
                    this.c_UFMaxRequestCount = int.Parse(Settings.ClientSettings[URLFinderConstants.requestCount].ToString());

                if (Settings.ClientSettings.Contains(URLFinderConstants.requestIntervalInSeconds))
                    this.c_UFRequestIntervalTimeInSeconds = int.Parse(Settings.ClientSettings[URLFinderConstants.requestIntervalInSeconds].ToString());

                if (Settings.ClientSettings.Contains(URLFinderConstants.maxURLCount))
                    this.c_UFMaxURLCount = int.Parse(Settings.ClientSettings[URLFinderConstants.maxURLCount].ToString());

                // DATA EXTRACTOR
                if (Settings.ClientSettings.Contains(DataExtractorConstants.waitingTimeInSeconds))
                    this.c_UFWaitingTimeInSeconds = int.Parse(Settings.ClientSettings[DataExtractorConstants.waitingTimeInSeconds].ToString());

                if (Settings.ClientSettings.Contains(DataExtractorConstants.requestCount))
                    this.c_DEMaxRequestCount = int.Parse(Settings.ClientSettings[DataExtractorConstants.requestCount].ToString());

                if (Settings.ClientSettings.Contains(DataExtractorConstants.requestIntervalInSeconds))
                    this.c_DERequestIntervalTimeInSeconds = int.Parse(Settings.ClientSettings[DataExtractorConstants.requestIntervalInSeconds].ToString());

                if (Settings.ClientSettings.Contains(DataExtractorConstants.crawlerExtractHourThreshold))
                    this.c_DECrawlerDataHourThreshold = int.Parse(Settings.ClientSettings[DataExtractorConstants.crawlerExtractHourThreshold].ToString());

                if (Settings.ClientSettings.Contains(DataExtractorConstants.crawlerExtractMinuteThreshold))
                    this.c_DECrawlerDataMinuteThreshold = int.Parse(Settings.ClientSettings[DataExtractorConstants.crawlerExtractMinuteThreshold].ToString());

                if (Settings.ClientSettings.Contains(DataExtractorConstants.useWatiNBuiltInBrowser))
                    this.c_DEUseWatiNBuiltInBrowser = bool.Parse(Settings.ClientSettings[DataExtractorConstants.useWatiNBuiltInBrowser].ToString());

                // CLIENT
                if (Settings.ClientSettings.Contains(ClientConstants.logAllEvents))
                    this.c_LogAllEvents = bool.Parse(Settings.ClientSettings[ClientConstants.logAllEvents].ToString());

                // GENERAL
                if (Settings.ClientSettings.Contains(GeneralConstants.clientStartThreadPriority))
                    this.c_MainStartThreadPriority = (ThreadPriority)(Settings.ClientSettings[GeneralConstants.clientStartThreadPriority]);

                if (Settings.ClientSettings.Contains(GeneralConstants.clientStopThreadPriority))
                    this.c_MainStopThreadPriority = (ThreadPriority)(Settings.ClientSettings[GeneralConstants.clientStopThreadPriority]);

            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured while binding settings, [code:0x00009]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        private void Write2Log(LogLevel logLevel, string message)
        {
            try
            {
                if (this.c_CrextaLogger != null)
                    this.c_CrextaLogger.WriteLog(logLevel, message);

                // Write also to db
                if (logLevel != LogLevel.INFO)
                {
#if LIVE
                    CrextaWS webService = new CrextaWS();
#else
                    localhost.CrextaWS webService = new Crexta.Client.localhost.CrextaWS();
#endif
                    try
                    {
                        if (this.ClientInfo != null)
                            webService.AddClientLog(ClientInfo.UniqueHash, ClientInfo.GuId.ToString(), ClientInfo.Mac, short.Parse(ClientInfo.Instance), message, "");
                    }
                    catch (Exception)
                    {
                        // NOP
                    }
                }
            }
            catch (Exception ex)
            {
                // write2log parameter must be FALSE in order to prevent infinite loop!!!
                this.UpdateList("Error occured, [code:0x00010]!..." + ex.Message, false);

                // DO NOT call Write2Log(...) here since it will cause an infinite loop!!!
            }
        }

        public void Stop(bool doNotUseANewThread)
        {
            Write2Log(LogLevel.INFO, "Starting main disconnect thread...");

            // Check Stop Thread
            if (this.c_MainClientStopThread != null)
            {
                try
                {
                    this.c_MainClientStopThread.Abort();
                }
                catch
                {
                    //NOP
                }
                this.c_MainClientStopThread = null;
            }

            // Kill Start Thread
            try
            {
                if (this.c_MainClientStartThread != null)
                    this.c_MainClientStartThread.Abort();
            }
            catch
            {
                // NOP
            }
            this.c_MainClientStartThread = null;

            try
            {
                if (!doNotUseANewThread)
                {
                    this.c_MainClientStopThread = new Thread(new ThreadStart(this.StopCrawler));
                    this.c_MainClientStopThread.IsBackground = true;
                    this.c_MainClientStopThread.Priority = this.c_MainStopThreadPriority;
                    this.c_MainClientStopThread.Start();
                }
                else
                    this.StopCrawler();
            }
            catch
            {
                // NOP
            }

            Write2Log(LogLevel.INFO, "Starting main disconnect thread...Done!");
        }

        private void UpdateList(string text, bool writealso2log)
        {
            if (Output != null)
            {
                try
                {
                    if (Output.Lines.Length > this.c_MaxListItems)
                        Output.Clear();

                    string[] data = text.Split("\r\n".ToCharArray());

                    Output.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " - " + data[0] + Environment.NewLine);

                    for (int i = 1; i < data.Length; i++)
                    {
                        if (data[i].Trim() != "")
                            Output.AppendText(data[i] + Environment.NewLine);
                    }

                    if (writealso2log && this.c_LogAllEvents)
                        Write2Log(LogLevel.INFO, text);

                    //Application.DoEvents();
                }
                catch (Exception ex)
                {
                    //DO NOT CALL UpdateList(..) again since it will cause an infinite loop!
                    Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
                }
            }
        }

        private void StartConnectionTimer(bool skipClientConnection)
        {
            try
            {
                //Enable connection timer!
                this.c_ConnectionCheckTimer.Enabled = true;
                this.c_ConnectionCheckTimer.Start();
            }
            catch (Exception)
            {
                // NOP
            }
        }

        private void StopConnectionTimer()
        {
            try
            {
                //Disable timer!
                this.c_ConnectionCheckTimer.Enabled = false;
                this.c_ConnectionCheckTimer.Stop();
            }
            catch (Exception)
            {
                // NOP
            }
        }

        private void StopCrawler()
        {
            if (this.c_CrextaClient != null)
            {
                Write2Log(LogLevel.INFO, "Stopping crawler...");
                //Stop crawler if it is working
                try
                {
                    if (this.c_CrextaCrawler != null)
                    {
                        this.c_CrextaCrawler.Cancel();

                        int i = 0;
                        while (this.c_CrextaCrawler.ThreadsInUse > 0 && i < 2000)
                        {
                            Thread.Sleep(10);
                            i++;
                        }

                        Thread.Sleep(500);
                    }
                }
                catch (Exception ex)
                {
                    this.UpdateList("Error occured, [code:0x00011]!..." + ex.Message, true);
                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                }

                this.c_CrextaCrawler = null;
            }
        }

        private void c_CrextaCrawler_PipelineException_Discovered(object sender, NCrawler.Events.PipelineExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void c_CrextaCrawler_DownloadException_Discovered(object sender, NCrawler.Events.DownloadExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void c_CrextaCrawler_CrawlFinished_Discovered(object sender, NCrawler.Events.CrawlFinishedEventArgs e)
        {
            Write2Log(LogLevel.INFO, "Crawling finished...! Starting all over again in 10 minutes...!");

            // Send if there are any URL lefted in the list
            CheckURLAndSendList2Server(UrlType.CRAWLER, -1, null, null, true);

            // Inform server that we have just finished a crawl process
            SendCrextorCrawlProcessFinisedCommand();

            // Ask for a new crextor information
            DoURLFinderJob(false);
        }

        private void c_CrextaCrawler_Cancelled_Discovered(object sender, EventArgs e)
        {
            Write2Log(LogLevel.INFO, "Crawling cancelled!");
        }

        private void c_Crawler_AfterDownload_Discovered(object sender, NCrawler.Events.AfterDownloadEventArgs e)
        {
            try
            {
                if (this.c_UFWaitingTimeInSeconds > 0)
                    Thread.Sleep(this.c_UFWaitingTimeInSeconds * 1000);

                CheckURLAndSendList2Server(UrlType.CRAWLER, -1, new string[] { e.CrawlStep.Uri.ToString() }, null, false);

                if (this.c_UFRequestCounter >= this.c_UFMaxRequestCount)
                {
                    Thread.Sleep(this.c_UFRequestIntervalTimeInSeconds * 1000);

                    // reset counter
                    this.c_UFRequestCounter = 0;
                }
                this.c_UFRequestCounter++;

                this.UpdateList("Crawling ended (Discovered):\r\n" + e.CrawlStep.Uri.ToString(), true);
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:0x00012]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        private void c_CrextaClient_OnDisconnected(object sender, NetDisconnectedEventArgs e)
        {
            OnClientDisconnected(new ClientDisconnectedEventArgs(this.WorkerID));
        }

        private void c_CrextaClient_OnReceived(object sender, NetReceivedEventArgs<NetObject> e)
        {
            try
            {
                if (e.Data.Object != null)
                {
                    // We could also use the "type" parameter integer and avoid reflection/etc
                    Type messageType = e.Data.Object.GetType();

                    if (messageType == typeof(CrextorInformationResponse))
                    {
                        CrextorInformationResponse serverAnswer = (CrextorInformationResponse)e.Data.Object;

                        if (serverAnswer.WorkerID == this.WorkerID)
                        {
                            this.c_ServerAnswered.Set();

                            //SET CREXTOR INFORMATION
                            this.c_CurrentCrextorInfo = serverAnswer.CrextorInfo;

                            if (serverAnswer.ErrorCode == 0)
                            {
                                // fire new event
                                OnCrextorChanged(new CrextorChangedEventArgs(this.WorkerID, this.c_CurrentCrextorInfo));

                                UpdateList("A new crextor item sent by the Master...God bless Master!\r\nCurrent crextor : " +
                                    serverAnswer.CrextorInfo.Name, true);
                            }
                            else
                            {
                                UpdateList("Crextor information request rejected by the server...\r\nReason : " +
                                    serverAnswer.ErrorMessage + "\r\nCode : " + serverAnswer.ErrorCode.ToString(), true);
                            }
                        }
                    }
                    else if (messageType == typeof(UnknownCommandResponse))
                    {
                        UnknownCommandResponse serverAnswer = (UnknownCommandResponse)e.Data.Object;

                        if (serverAnswer.WorkerID == this.WorkerID)
                        {
                            UpdateList("Unknown response issued by the server!", true);
                        }
                    }
                    else if (messageType == typeof(FoundedURLsAdded2DB))
                    {
                        FoundedURLsAdded2DB serverAnswer = (FoundedURLsAdded2DB)e.Data.Object;

                        if (serverAnswer.WorkerID == this.WorkerID)
                        {
                            UpdateList("Founded URLs is now in DB! Good job slave...", true);
                        }
                    }
                    else if (messageType == typeof(ExtractedURLDataAdded2DB))
                    {
                        ExtractedURLDataAdded2DB serverAnswer = (ExtractedURLDataAdded2DB)e.Data.Object;

                        if (serverAnswer.WorkerID == this.WorkerID)
                        {
                            UpdateList("URL Extraction succesfull! Well done boy...", true);
                        }
                    }
                    else if (messageType == typeof(URLInformationResponse))
                    {
                        URLInformationResponse serverAnswer = (URLInformationResponse)e.Data.Object;

                        if (serverAnswer.WorkerID == this.WorkerID)
                        {
                            this.c_ServerAnswered.Set();

                            //SET CREXTOR INFORMATION
                            this.c_DataExtractorURLList = serverAnswer.CrextorURLs;

                            if (serverAnswer.ErrorCode == 0)
                            {
                                UpdateList("A new URL list sent by the Master...God bless Master!\r\nList count : " +
                                    serverAnswer.CrextorURLs.Count.ToString(), true);
                            }
                            else
                            {
                                UpdateList("URL list information request rejected by the server...\r\nReason : " +
                                    serverAnswer.ErrorMessage + "\r\nCode : " + serverAnswer.ErrorCode.ToString(), true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:0x00013]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        public void ReloadSettings()
        {
            try
            {
                // reload settings
                Settings.LoadSettings(this.Instance);

                this.c_MainStartThreadPriority = (ThreadPriority)(int.Parse(Settings.ClientSettings[GeneralConstants.clientStartThreadPriority].ToString()));
                if (this.c_MainClientStartThread != null && this.c_MainClientStartThread.IsAlive)
                    this.c_MainClientStartThread.Priority = this.c_MainStartThreadPriority;

                this.c_CrawlerMaxThreadCount = int.Parse(Settings.ClientSettings[URLFinderConstants.crawlThreadCount].ToString());
                if (this.c_CrextaCrawler != null)
                    this.c_CrextaCrawler.MaximumThreadCount = this.c_CrawlerMaxThreadCount;

                this.c_CrawlerMaxCrawlDepth = int.Parse(Settings.ClientSettings[URLFinderConstants.crawlDeptLevel].ToString());
                if (this.c_CrextaCrawler != null)
                    this.c_CrextaCrawler.MaximumCrawlDepth = this.c_CrawlerMaxCrawlDepth;

                this.c_CrawlerMaxThreadCount = int.Parse(Settings.ClientSettings[URLFinderConstants.crawlThreadCount].ToString());
                this.c_CrawlerMaxCrawlDepth = int.Parse(Settings.ClientSettings[URLFinderConstants.crawlDeptLevel].ToString());
                this.c_UFWaitingTimeInSeconds = int.Parse(Settings.ClientSettings[URLFinderConstants.waitingTimeInSeconds].ToString());
                this.c_UFMaxRequestCount = int.Parse(Settings.ClientSettings[URLFinderConstants.requestCount].ToString());
                this.c_UFRequestIntervalTimeInSeconds = int.Parse(Settings.ClientSettings[URLFinderConstants.requestIntervalInSeconds].ToString());
                this.c_UFMaxURLCount = int.Parse(Settings.ClientSettings[URLFinderConstants.maxURLCount].ToString());
                this.c_UFWaitingTimeInSeconds = int.Parse(Settings.ClientSettings[DataExtractorConstants.waitingTimeInSeconds].ToString());
                this.c_DEMaxRequestCount = int.Parse(Settings.ClientSettings[DataExtractorConstants.requestCount].ToString());
                this.c_DERequestIntervalTimeInSeconds = int.Parse(Settings.ClientSettings[DataExtractorConstants.requestIntervalInSeconds].ToString());
                this.c_DEUseWatiNBuiltInBrowser = bool.Parse(Settings.ClientSettings[DataExtractorConstants.useWatiNBuiltInBrowser].ToString());
                this.c_DECrawlerDataHourThreshold = int.Parse(Settings.ClientSettings[DataExtractorConstants.crawlerExtractHourThreshold].ToString());
                this.c_DECrawlerDataMinuteThreshold = int.Parse(Settings.ClientSettings[DataExtractorConstants.crawlerExtractMinuteThreshold].ToString());
                this.c_LogAllEvents = bool.Parse(Settings.ClientSettings[ClientConstants.logAllEvents].ToString());

                this.UpdateList("New settings are applied succesfully...", false);
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:0x00014]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        [DefaultValue(1)]
        public int WorkerID { get; internal set; }

        [DefaultValue(1)]
        public int Mode { get; set; }

        [DefaultValue(null)]
        public ServerIpPort ServerInfo { internal get; set; }

        [DefaultValue("")]
        public string Instance { get; internal set; }

        [DefaultValue(null)]
        public RichTextBox Output { internal get; set; }

        [DefaultValue(null)]
        public TabPage TabPage { get; set; }

        [DefaultValue(null)]
        public ClientInfo ClientInfo { get; internal set; }

        [DefaultValue("Mozilla/6.0 (Macintosh; I; Intel Mac OS X 11_7_9; de-LI; rv:1.9b4) Gecko/2012010317 Firefox/10.0a4")]
        public string UserAgent { get; set; }

        [DefaultValue(0)]
        public int TotalItemsSent2Server { get; internal set; }

        public long ThreadsInUseByCrawler
        {
            get
            {
                if (this.c_CrextaCrawler != null)
                    return this.c_CrextaCrawler.ThreadsInUse;
                else
                    return 0;
            }
        }

        public long WaitingQueueLenghtOfCrawler
        {
            get
            {
                if (this.c_CrextaCrawler != null)
                    return this.c_CrextaCrawler.WaitingQueueLength;
                else
                    return 0;
            }
        }

        protected virtual void OnCrextorChanged(CrextorChangedEventArgs e)
        {
            if (CrextorChanged != null)
                CrextorChanged(this, e);
        }

        protected virtual void OnClientDisconnected(ClientDisconnectedEventArgs e)
        {
            if (ClientDisconnected != null)
                ClientDisconnected(this, e);
        }
    }
}