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

// reference to LIVE (always)
using Crexta.Client.com.crexta.www;

using ICSharpCode.SharpZipLib.Zip;
using Rss;
using NCrawler;
using NCrawler.Services;
using NCrawler.HtmlProcessor;
using WatiN.Core;
using HtmlAgilityPack;
using System.Diagnostics;

namespace Crexta.Client
{
    public partial class Client : System.Windows.Forms.Form
    {
        // LAST ERROR CODE : 1x00015

        #region Variable Declerations

        private int c_ClientWorkingMode = 1; // Default URLFinder
        private int c_MaxListItems = 1000;
        private int c_PortNumber = -1;
        private int c_ClientID = -1;
        private int c_WaitTimeoutAfterServerAnswer = 5000; // Miliseconds
        private int c_NotifyIconBalloonDisplayTimeout = 2000; // Miliseconds
        private int c_ServerAnswerWaitTimeout = 30; // Seconds
        private int c_FileDownloadWaitTimeout = 15; // Minutes
        private int c_ClientReconnectTimeMinutes = 5;
        private int c_ClientReconnectTimeSeconds = 0;
        private int c_KeepMeAliveTimeInSeconds = 240; //(c_ClientReconnectTimeMinutes-1)*60 + c_ClientReconnectTimeSeconds

        private ThreadPriority c_MainStartThreadPriority = ThreadPriority.Normal;
        private ThreadPriority c_MainStopThreadPriority = ThreadPriority.Highest;

        private string c_Instance = "1";
        private string c_LocalIP = "";
        private string c_MacAddress = "";
        private string c_ClientName = "";

        private Guid c_ClientGUID = Guid.Empty;

        private bool c_ShowNotifications = false;
        private bool c_InstanceCheckSuccess = true;
        private bool c_ExitApplication = false;
        private bool c_StartInTaskbar = false;
        private bool c_AutoConnect2Server = false;
        private bool c_Connnected2Internet = false;
        private bool c_SkipClientVersionCheck = false;
        private bool c_SkipMainlistVersionCheck = true;
        private bool c_DownloadClientOK = true;
        private bool c_DownloadMainlistOK = true;
        private bool c_SkipClientConnectionCheck = false;
        private bool c_LogAllEvents = false;

        private Logger c_CrextaLogger;

        private NetObjectClient c_CrextaClient = new NetObjectClient();

        private ManualResetEvent c_FileDownloaded = new ManualResetEvent(false);
        private ManualResetEvent c_ServerAnswered = new ManualResetEvent(false);

        private Thread c_MainClientStartThread;
        private Thread c_MainClientStopThread;

        private System.Timers.Timer c_ConnectionCheckTimer = new System.Timers.Timer(300000);
        private System.Timers.Timer c_KeepMeAliveTimer = new System.Timers.Timer(240000);
        private System.Timers.Timer c_InformationUpdateTimer = new System.Timers.Timer(4000);

        public delegate void UpdateListDelegate(string text, bool writealso2log);
        public delegate void CreateNewWorkerClientDelegate(ServerIpPort serverInfo, int index);

        private List<CrextaClient> crextaWorkerClients = new List<CrextaClient>();

        private const int MAX_WORKER_CLIENTS = 5;

        private int GLOBAL_WORKER_ID_COUNTER = 0;

        Hashtable c_WorkerIDAndTabIndex = new Hashtable();

        #endregion

        #region Constructor Logic

        public Client(string[] args)
        {
            InitializeComponent();

            if (!CheckInstanceID())
                c_InstanceCheckSuccess = false;

            // get program arguments
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (arg == "-b")
                        this.c_StartInTaskbar = true;
                    else if (arg == "-a")
                        this.c_AutoConnect2Server = true;
                }
            }
        }

        #endregion

        #region Load Event

        private void Client_Load(object sender, EventArgs e)
        {
            try
            {
                this.InitServicePoint();

                if (!c_InstanceCheckSuccess)
                {
                    this.c_ExitApplication = true;

                    this.CloseApplication(false, false);

                    return;
                }

                this.InitLogger();

                if (this.c_StartInTaskbar)
                    this.SendToTaskBar();

                Write2Log(LogLevel.INFO, "Client started...Getting client information...");

                this.InitVariables();

                Write2Log(LogLevel.INFO, "Client started...Loading settings...");

                Settings.LoadSettings(this.c_Instance);

                BindSettings();

                StopConnectionTimer();

                Write2Log(LogLevel.INFO, "Client Information successfull...\r\nMAC : " + this.c_MacAddress + "\r\nIP : " + this.c_LocalIP +
                    "\r\nName : " + this.c_ClientName);

                Write2Log(LogLevel.INFO, "Main thread started...");

                if (this.c_AutoConnect2Server)
                {
                    //this.StartClient();
                    this.connectToolStripMenuItem_Click(this, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region Do Client Job

        private void DoClientJob()
        {
            try
            {
                this.InitClient();

                CheckInternetConnection();

                if (c_Connnected2Internet)
                {
                    ServerIpPort serverInfo = GetServerInformation();

                    if (serverInfo != null)
                    {
#if ENABLE_UI_UPDATE
                        this.serverIPLabel.Text = serverInfo.ExternalIp;
                        this.c_PortNumber = serverInfo.Port;
                        this.serverPortLabel.Text = this.c_PortNumber.ToString();
#endif

                        if (Connect2Server(serverInfo))
                        {
                            this.UpdateList("Asking permission to begin working...", true);

                            this.ShowInNotifyIcon("Crexta Client", "Asking permission to begin working...",
                                ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

                            RequestPermission2Work message = new RequestPermission2Work();
                            message.IP = this.c_LocalIP;
                            message.MAC = this.c_MacAddress;
                            message.Name = this.c_ClientName;
                            message.Instance = this.c_Instance;
                            message.GUID = this.c_ClientGUID;
                            message.WorkerID = 0;

                            this.c_ServerAnswered.Reset();
                            try
                            {
                                this.c_CrextaClient.Send("I want to work master! Give me some work...", message);
                            }
                            catch (Exception ex)
                            {
                                this.UpdateList("Error occured, [code:1x00001]!..." + ex.Message, true);
                                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                            }
                            this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                            //Just wait a little more so that we can set variables according to the server answer
                            Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);

                            if (this.c_ClientID > 0)
                            {
                                //Check for new client version
                                if (!this.c_SkipClientVersionCheck)
                                    CheckForNewClientVersion();

                                if (this.c_DownloadClientOK)
                                {
                                    //Check mainlist file version
                                    if (!this.c_SkipMainlistVersionCheck)
                                        CheckNewFileVersion();

                                    if (this.c_DownloadMainlistOK)
                                    {
                                        //Stop connection check timer first!
                                        StopConnectionTimer();

                                        //Start keep me alive time
                                        StartKeepAliveTimer();

                                        if (this.c_ClientWorkingMode == 1)
#if ENABLE_UI_UPDATE
                                            this.clientModeLabel.Text = "URL Finder";
#endif
                                        else
#if ENABLE_UI_UPDATE
                                            this.clientModeLabel.Text = "Data Extractor";
#endif

                                        this.UpdateList("Initializing workers...", true);

                                        // Initialize worker clients
                                        for (int i = 0; i < MAX_WORKER_CLIENTS; i++)
                                        {
                                            AddNewWorkerClient(serverInfo, i + 1);

                                            Thread.Sleep(20);
                                        }
                                    }
                                    else
                                    {
                                        this.UpdateList("Cannot download latest mainlist version!\r\nWill try " + 
                                            this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                            this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                                        this.ShowInNotifyIcon("Crexta Client", "Cannot download latest mainlist version!\r\nWill try " + 
                                            this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                            this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                                            ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                                        StartConnectionTimer(true);
                                    }
                                }
                                else
                                {
                                    this.UpdateList("Cannot download latest client version!\r\nWill try " + 
                                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                                    this.ShowInNotifyIcon("Crexta Client", "Cannot download latest client version!\r\nWill try " + 
                                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                                        ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                                    StartConnectionTimer(true);
                                }
                            }
                            else
                            {
                                this.UpdateList("Cannot get client information!\r\nWill try " + 
                                    this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                    this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                                this.ShowInNotifyIcon("Crexta Client", "Cannot get client information!\r\nWill try " + 
                                    this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                    this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                                    ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                                StartConnectionTimer(false);
                            }
                        }
                        else
                        {
                            this.UpdateList("Cannot connect to server!\r\nWill try " +
                                this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " +
                                this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                            this.ShowInNotifyIcon("Crexta Client", "Cannot connect to server!\r\nWill try " +
                                this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                                this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                                ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                            ChangeConnectButtonStatus(true);

                            StartConnectionTimer(false);
                        }
                    }
                    else
                    {
                        this.UpdateList("Cannot query server information!\r\nWill try " +
                            this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " +
                            this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                        this.ShowInNotifyIcon("Crexta Client", "Cannot query server information!\r\nWill try " + 
                            this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                            this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                            ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                        ChangeConnectButtonStatus(true);

                        StartConnectionTimer(false);
                    }
                }
                else
                {
                    this.UpdateList("No Internet Connection!\r\nWill try " + 
                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", false);

                    this.ShowInNotifyIcon("Crexta Client", "No Internet Connection!\r\nWill try " + 
                        this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                        this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                        ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                    ChangeConnectButtonStatus(true);

                    StartConnectionTimer(false);
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured!\r\n" + ex.Message + "\r\nWill try " + 
                    this.c_ClientReconnectTimeMinutes.ToString() + " minutes and " + 
                    this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...", true);

                this.ShowInNotifyIcon("Crexta Client", "Error occured!\r\n" + ex.Message + 
                    "\r\nWill try " + this.c_ClientReconnectTimeMinutes.ToString() + 
                    " minutes and " + this.c_ClientReconnectTimeSeconds.ToString() + " seconds later...",
                    ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));

                ChangeConnectButtonStatus(true);

                StartConnectionTimer(false);
            }
        }

        private void AddNewWorkerClient(ServerIpPort serverInfo, int index)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new CreateNewWorkerClientDelegate(
                            delegate(ServerIpPort innerServerInfo, int innerIndex)
                            {
                                this.AddNewWorkerClient(innerServerInfo, innerIndex);
                            }), serverInfo, index);
                    return;
                }
                else
                {
                    this.GLOBAL_WORKER_ID_COUNTER++;

                    TabPage crextaWorkerTabPage = new TabPage((this.c_ClientWorkingMode == 1 ? "URL Finder #" : "Extractor #") + GLOBAL_WORKER_ID_COUNTER.ToString());
                    RichTextBox crextaWorkerActivityLog = new RichTextBox();
                    crextaWorkerActivityLog.Dock = DockStyle.Fill;
                    crextaWorkerActivityLog.ContextMenuStrip = this.activityContextMenuStrip;
                    crextaWorkerTabPage.Controls.Add(crextaWorkerActivityLog);
                    this.clientTabControl.TabPages.Add(crextaWorkerTabPage);

                    CrextaClient crextaWorkerClient = new CrextaClient(this.c_Instance, GLOBAL_WORKER_ID_COUNTER, this.c_CrextaClient, GetClientInfo());
                    crextaWorkerClient.Output = crextaWorkerActivityLog;
                    crextaWorkerClient.ServerInfo = serverInfo;
                    crextaWorkerClient.Mode = this.c_ClientWorkingMode;
                    crextaWorkerClient.TabPage = crextaWorkerTabPage;

                    crextaWorkerClient.ClientDisconnected += new CrextaClient.ClientDisconnectedEventHandler(crextaWorkerClient_ClientDisconnected);
                    crextaWorkerClient.CrextorChanged += new CrextaClient.CrextorChangedEventHandler(crextaWorkerClient_CrextorChanged);

                    crextaWorkerClient.Start();

                    this.c_WorkerIDAndTabIndex.Add(GLOBAL_WORKER_ID_COUNTER, index);
                    this.crextaWorkerClients.Add(crextaWorkerClient);
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured while creating worker client, [code:1x00015]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        private void crextaWorkerClient_CrextorChanged(object sender, Events.CrextorChangedEventArgs e)
        {
            if (e.CrextorInfo != null)
            {
                UpdateList("Worker got a new Crextor information (Worker: " + e.WorkerID.ToString() + ", Crextor: " + e.CrextorInfo.Name + ")", false);

                if (this.c_WorkerIDAndTabIndex.Contains(e.WorkerID))
                {
                    int index = int.Parse(this.c_WorkerIDAndTabIndex[e.WorkerID].ToString());
                    this.clientTabControl.TabPages[index].Text = e.CrextorInfo.Name;
                }
            }
        }

        private void crextaWorkerClient_ClientDisconnected(object sender, Events.ClientDisconnectedEventArgs e)
        {
            // Stop client
            this.StopClient(true);
        }

        private void DisconnectAndClearWorkers()
        {
            try
            {
                lock (this)
                {
                    foreach (CrextaClient crextaWorkerClient in this.crextaWorkerClients)
                    {
                        crextaWorkerClient.Stop(true);
                        
                        if(crextaWorkerClient.TabPage!=null)
                            this.clientTabControl.TabPages.Remove(crextaWorkerClient.TabPage);
                    }

                    this.c_WorkerIDAndTabIndex.Clear();

                    this.GLOBAL_WORKER_ID_COUNTER = 0;
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00008]!..." + ex.Message, true);
                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region Client-Server Communication

        #region CheckNewFileVersion

        private void CheckNewFileVersion()
        {
            try
            {
                this.UpdateList("Checking new main file version...", true);

                string strVersion = GetMainListFileVersion();

#if LIVE
                CrextaWS webService = new CrextaWS();
#else
                localhost.CrextaWS webService = new Crexta.Client.localhost.CrextaWS();
#endif
                if (webService.UpdateMainList(strVersion))
                {
                    this.UpdateList("New version found! Downloading main file...", true);

                    this.ShowInNotifyIcon("Crexta Client", "New version found! Downloading main file...",
                         ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient1_DownloadFileCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

                    string tmppath = Path.GetTempPath() + "MainList.zip";
                    webClient.DownloadFileAsync(new Uri(Common.Constants.GeneralConstants.defaultMainlistDownloadURL), tmppath);

                    this.c_FileDownloaded.WaitOne(TimeSpan.FromMinutes(this.c_FileDownloadWaitTimeout));
                }

                this.UpdateList("Checking new main file version...Done!", true);

                this.c_SkipMainlistVersionCheck = true;
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00002]!..." + ex.Message, true);
                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region CheckForNewClientVersion

        private void CheckForNewClientVersion()
        {
            try
            {
                string strVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

                this.UpdateList("Checking new version...", true);

#if LIVE
                CrextaWS webService = new CrextaWS();
#else
                localhost.CrextaWS webService = new Crexta.Client.localhost.CrextaWS();
#endif

                if (webService.UpdateClientSoftware(strVersion))
                {

                    this.UpdateList("New version found! Downloading file...", true);

                    this.ShowInNotifyIcon("Crexta Client", "New version found! Downloading file...",
                         ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);

                    string tmppath = Path.GetTempPath() + "Client.zip";
                    webClient.DownloadFileAsync(new Uri(Common.Constants.GeneralConstants.defaultClientDownloadURL), tmppath);

                    this.c_FileDownloaded.WaitOne(TimeSpan.FromMinutes(this.c_FileDownloadWaitTimeout));
                }

                this.UpdateList("Checking new version...Done!", true);

                this.c_SkipClientVersionCheck = true;
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00003]!..." + ex.Message, true);
                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region GetServerInformation

        private ServerIpPort GetServerInformation()
        {
            ServerIpPort ipport = null;

            try
            {
                this.UpdateList("Trying to retrieve server information...", true);
#if LIVE
                CrextaWS webService = new CrextaWS();
                ipport = webService.GetServerInformation(Common.Constants.GeneralConstants.securityKey);
#else
                localhost.CrextaWS webService = new Crexta.Client.localhost.CrextaWS();

                localhost.ServerIpPort temp = webService.GetServerInformation(Common.Constants.GeneralConstants.securityKey);
                ipport = new ServerIpPort();
                ipport.ExternalIp = temp.ExternalIp;
                ipport.LocalIp = temp.LocalIp;
                ipport.Port = temp.Port;
#endif

                this.UpdateList("Trying to retrieve server information...Done!", true);
            }
            catch(Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00004]!..." + ex.Message, true);

                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
            }

            return ipport;
        }

        #endregion

        #region Connect2Server

        private bool Connect2Server(ServerIpPort serverInfo)
        {
            this.UpdateList("Trying to connect to the server...\r\nServer : " +
                serverInfo.ExternalIp + "\r\nPort : " + serverInfo.Port.ToString(), true);

            this.ShowInNotifyIcon("Crexta Client", "Trying to connect to the server...\r\nServer : " + 
                serverInfo.ExternalIp + "\r\nPort : " + serverInfo.Port.ToString(),
                ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

            try
            {
                if (!this.c_CrextaClient.IsConnected)
                {
                    this.c_CrextaClient = new NetObjectClient();

                    //Attach event handlers
                    this.c_CrextaClient.OnDisconnected += new NetDisconnectedEventHandler(client_OnDisconnected);
                    this.c_CrextaClient.OnReceived += new NetReceivedEventHandler<NetObject>(client_OnReceived);
                    this.c_CrextaClient.OnConnected += new NetConnectedEventHandler(client_OnConnected);

                    Write2Log(LogLevel.INFO, "Trying to connect to the server...\r\nServer : " +
                        serverInfo.ExternalIp + "\r\nPort : " + serverInfo.Port.ToString());
                    this.c_ServerAnswered.Reset();
                    bool connected = this.c_CrextaClient.TryConnect(serverInfo.ExternalIp, serverInfo.Port);
                    this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                    //Just wait a little more so that we can set variables according to the server answer
                    Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);

                    if (connected)
                    {
                        this.UpdateList("Connected to server. Assigned GUID : " + this.c_ClientGUID.ToString(), true);

                        this.ShowInNotifyIcon("Crexta Client", "Connected to server. Assigned GUID : " +
                            this.c_ClientGUID.ToString(), ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                        ChangeDisConnectButtonStatus(true);

                        return true;
                    }
                    else
                    {
                        this.UpdateList("Unable to connect! ", false);

                        this.ShowInNotifyIcon("Crexta Client", "Unable to connect! ", ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                        ChangeConnectButtonStatus(true);
                    }
                }
                else
                {
                    ChangeDisConnectButtonStatus(true);

                    return true;
                }
            }
            catch(Exception ex)
            {
                ChangeConnectButtonStatus(true);

                this.UpdateList("Connection error! " + ex.Message, true);

                this.ShowInNotifyIcon("Crexta Client", "Connection error! " + ex.Message, 
                    ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
            }

            return false;
        }

        #endregion

        #endregion

        #region Helper Methods

        #region BindSettings

        private void BindSettings()
        {
            try
            {
                // GENERAL
                if (Settings.ClientSettings.Contains(GeneralConstants.clientStartThreadPriority))
                    this.c_MainStartThreadPriority = (ThreadPriority)(Settings.ClientSettings[GeneralConstants.clientStartThreadPriority]);

                if (Settings.ClientSettings.Contains(GeneralConstants.clientStopThreadPriority))
                    this.c_MainStopThreadPriority = (ThreadPriority)(Settings.ClientSettings[GeneralConstants.clientStopThreadPriority]);

                // CLIENT
                if (Settings.ClientSettings.Contains(ClientConstants.logAllEvents))
                    this.c_LogAllEvents = bool.Parse(Settings.ClientSettings[ClientConstants.logAllEvents].ToString());

                if (Settings.ClientSettings.Contains(ClientConstants.showNotifications))
                    this.c_ShowNotifications = bool.Parse(Settings.ClientSettings[ClientConstants.showNotifications].ToString());
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured while binding settings, [code:1x00005]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region Initializations

        private void InitVariables()
        {
            this.c_MacAddress = this.clientMacLabel.Text = NetworkUtility.GetFirstOperationalMacAddress();

            this.c_LocalIP = this.clientIPLabel.Text = NetworkUtility.GetLocalIPAddress();

            this.c_ClientName = this.clientNameLabel.Text = NetworkUtility.GetMachineName();

            this.c_ConnectionCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(c_ConnectionCheckTimer_Elapsed);

            this.c_InformationUpdateTimer.Elapsed += new System.Timers.ElapsedEventHandler(c_InformationUpdateTimer_Elapsed);

            this.c_KeepMeAliveTimer.Elapsed += new System.Timers.ElapsedEventHandler(c_KeepMeAliveTimer_Elapsed);

            this.c_InformationUpdateTimer.Enabled = true;
        }

        private void InitServicePoint()
        {
            ServicePointManager.MaxServicePoints = 999999;
            ServicePointManager.DefaultConnectionLimit = 999999;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.CheckCertificateRevocationList = true;
            ServicePointManager.EnableDnsRoundRobin = true;
        }

        private void InitClient()
        {
            this.c_CrextaClient = new NetObjectClient();
        }

        private void InitLogger()
        {
            try
            {
                this.c_CrextaLogger = new Logger("Client_" + this.c_Instance + ".log", typeof(Client));
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00006]!..." + ex.Message, false);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region Write2Log

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
                        ClientInfo clientInfo = GetClientInfo();
                        if (clientInfo != null)
                            webService.AddClientLog(clientInfo.UniqueHash, clientInfo.GuId.ToString(), clientInfo.Mac, short.Parse(clientInfo.Instance), message, "");
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
                this.UpdateList("Error occured, [code:1x00007]!..." + ex.Message, false);

                // DO NOT call Write2Log(...) here since it will cause an infinite loop!!!
            }
        }

        #endregion

        #region CloseApplication

        private void CloseApplication(bool send2taskbar, bool restart)
        {
            try
            {
                if (!send2taskbar)
                {
                    // check and create registery keys to start automatically
                    if (!RegistryUtility.CheckRegisteryKeys())
                    {
                        // First try to delete
                        RegistryUtility.DeleteRegisteryKeys();

                        // Then create the keys
                        RegistryUtility.SetRegisteryKeys();
                    }
                    this.StopConnectionTimer();

                    this.StopClient(true);

                    // close or restart
                    if (restart)
                        Application.Restart();
                    else
                        Application.Exit();
                }
                else
                    SendToTaskBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region RestoreApplication

        private void RestoreApplication()
        {
            this.clientNotifyIcon.Visible = false;

            this.Show();
            this.ShowInTaskbar = true;
        }

        #endregion

        #region SendToTaskBar, GetClientInfo

        private void SendToTaskBar()
        {
            this.clientNotifyIcon.Visible = true;

            this.Hide();
            this.ShowInTaskbar = false;

            ShowInNotifyIcon("Crexta Client", "Client application is still working...",
                             ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
        }

        private ClientInfo GetClientInfo()
        {
            try
            {
                ClientInfo clientInfo = new ClientInfo();
                clientInfo.Id = this.c_ClientID;
                clientInfo.Instance = this.c_Instance;
                clientInfo.LocalIp = NetworkUtility.GetLocalIPAddress();
                clientInfo.Mac = this.c_MacAddress;
                clientInfo.Name = NetworkUtility.GetMachineName();
                clientInfo.GuId = this.c_ClientGUID;

                return clientInfo;
            }
            catch (Exception)
            {
                // NOP
            }

            return null;
        }

        #endregion

        #region StartClient

        private void StartClient()
        {
            Write2Log(LogLevel.INFO, "Starting main thread...");

            // Kill all sub-clients! (if any exists)
            DisconnectAndClearWorkers();

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

            this.c_MainClientStartThread = new Thread(new ThreadStart(this.DoClientJob));
            this.c_MainClientStartThread.SetApartmentState(ApartmentState.STA);
            this.c_MainClientStartThread.Name = "Crexta Client Thread";
            this.c_MainClientStartThread.IsBackground = true;
            this.c_MainClientStartThread.Priority = this.c_MainStartThreadPriority;
            this.c_MainClientStartThread.Start();

            Write2Log(LogLevel.INFO, "Starting main thread...Done!");
        }

        #endregion

        #region StopClient

        private void StopClient(bool doNotUseANewThread)
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
                    this.c_MainClientStopThread = new Thread(new ThreadStart(this.DisconnectClient));
                    this.c_MainClientStopThread.Name = "Crexta Client Disconnect Thread";
                    this.c_MainClientStopThread.IsBackground = true;
                    this.c_MainClientStopThread.Priority = this.c_MainStopThreadPriority;
                    this.c_MainClientStopThread.Start();
                }
                else
                    this.DisconnectClient();
            }
            catch
            {
                // NOP
            }
            finally
            {
                ChangeConnectButtonStatus(true);
            }

            Write2Log(LogLevel.INFO, "Starting main disconnect thread...Done!");
        }

        #endregion

        #region CheckInternetConnection, UpdateList, GetMainListFileVersion

        private void CheckInternetConnection()
        {
            c_Connnected2Internet = NetworkUtility.IsConnectedToInternet();
        }

        private void UpdateList(string text, bool writealso2log)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new UpdateListDelegate(
                        delegate(string innerText, bool innerWrite2Log)
                        {
                            this.UpdateList(innerText, innerWrite2Log);
                        }), text, writealso2log);
                }
                else
                {
                    if (this.mainMessageList.Lines.Length > this.c_MaxListItems)
                        this.mainMessageList.Clear();

                    string[] data = text.Split("\r\n".ToCharArray());

                    this.mainMessageList.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + " - " + data[0] + Environment.NewLine);

                    for (int i = 1; i < data.Length; i++)
                    {
                        if (data[i].Trim() != "")
                            this.mainMessageList.AppendText(data[i] + Environment.NewLine);
                    }

                    if (writealso2log && this.c_LogAllEvents)
                        Write2Log(LogLevel.INFO, text);

                    //Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                //Do NOT call UpdateList(...) here since it will cause an infinite loop!!!
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        private string GetMainListFileVersion()
        {
            string version = "1.1.0.0";

            //Check for a valid version
            if (File.Exists(Common.Constants.GeneralConstants.defaultRulesFileRoot + "version.ver"))
            {
                StreamReader sr = new StreamReader(Common.Constants.GeneralConstants.defaultRulesFileRoot + "version.ver");

                //Check for the first line
                version = sr.ReadLine();

                sr.Close();
            }

            return version;
        }

        #endregion

        #region StartTimer, StopTimer, CheckInstanceID

        private void StartConnectionTimer(bool skipClientConnection)
        {
            try
            {
                this.c_SkipClientConnectionCheck = skipClientConnection;

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
                this.c_SkipClientConnectionCheck = false;

                //Disable timer!
                this.c_ConnectionCheckTimer.Enabled = false;
                this.c_ConnectionCheckTimer.Stop();
            }
            catch (Exception)
            {
                // NOP
            }
        }

        private void StartKeepAliveTimer()
        {
            //Enable keep alive timer!
            this.c_KeepMeAliveTimer.Enabled = true;
            this.c_KeepMeAliveTimer.Start();
        }

        private void StopKeepAliveTimer()
        {
            //Disable keep alive timer!
            this.c_KeepMeAliveTimer.Enabled = false;
            this.c_KeepMeAliveTimer.Stop();
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
                    this.c_Instance = id;
            }

            return true;
        }

        #endregion

        #region DisconnectClient, ShowInNotifyIcon

        private void DisconnectClient()
        {
            if (this.c_CrextaClient != null)
            {
                Write2Log(LogLevel.INFO, "Stopping workers...");
                
                // Stop and kill all sub-clients!!!
                DisconnectAndClearWorkers();

                Write2Log(LogLevel.INFO, "Disconnecting from Server...");

                // Disconnect client
                try
                {
                    if (this.c_CrextaClient.IsConnected)
                    {
                        ChangeConnectButtonStatus(true);

                        this.c_CrextaClient.Disconnect();

                        Thread.Sleep(500);
                    }
                }
                catch (Exception ex)
                {
                    this.UpdateList("Error occured, [code:1x00009]!..." + ex.Message, true);

                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                }
                finally
                {
                    ChangeConnectButtonStatus(true);

                    Write2Log(LogLevel.INFO, "Disconnecting from Server...Done!");
                }
            }
        }

        private void ShowInNotifyIcon(string title, string text, ToolTipIcon icon, int timeout)
        {
            if (this.clientNotifyIcon.Visible)
            {
                if (this.c_ShowNotifications)
                {
                    this.clientNotifyIcon.ShowBalloonTip(timeout, title, text, icon);
                    for (int i = 0; i < timeout; i++)
                        System.Threading.Thread.Sleep(1);
                    this.clientNotifyIcon.Visible = false;
                    this.clientNotifyIcon.Visible = true;
                }
            }
        }

        #endregion

        #endregion

        #region Events

        #region client_OnReceived

        private void client_OnReceived(object sender, NetReceivedEventArgs<NetObject> e)
        {
            try
            {
                if (e.Data.Object != null)
                {
                    // We could also use the "type" parameter integer and avoid reflection/etc
                    Type messageType = e.Data.Object.GetType();

                    if (messageType == typeof(ClientInformationResponse))
                    {
                        ClientInformationResponse serverAnswer = (ClientInformationResponse)e.Data.Object;

                        if (serverAnswer.WorkerID == 0)
                        {
                            //Set manuelreset event before UpdateList method!
                            this.c_ServerAnswered.Set();

                            //SET WORKING MODE
                            this.c_ClientWorkingMode = serverAnswer.ClientInfo.Mode;

                            //SET CLIENT ID
                            this.c_ClientID = serverAnswer.ClientInfo.Id;

                            // SET re-connect time in minutes and seconds
                            if (serverAnswer.ReconnectTimeMinutes > 0)
                            {
                                this.c_ClientReconnectTimeMinutes = serverAnswer.ReconnectTimeMinutes;
                                this.c_ClientReconnectTimeSeconds = serverAnswer.ReconnectTimeSeconds;

                                // SET connection timer interval
                                this.c_ConnectionCheckTimer.Interval = (c_ClientReconnectTimeMinutes * 60 + c_ClientReconnectTimeSeconds) * 1000;

                                // SET keep alive time
                                this.c_KeepMeAliveTimeInSeconds = c_ClientReconnectTimeMinutes * 60 + c_ClientReconnectTimeSeconds;

                                // SET keep me alive timer interval
                                this.c_KeepMeAliveTimer.Interval = c_KeepMeAliveTimeInSeconds * 1000;
                            }

                            if (serverAnswer.ErrorCode == 0)
                            {
                                UpdateList("Work permission request accepted by the server...", true);

                                ShowInNotifyIcon("Crexta Client", "Work permission request accepted by the server...",
                                     ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
                            }
                            else
                            {
                                UpdateList("Work permission request rejected by the server...\r\nReason : " +
                                    serverAnswer.ErrorMessage + "\r\nCode : " + serverAnswer.ErrorCode.ToString(), true);

                                ShowInNotifyIcon("Crexta Client", "Work permission request rejected by the server...\r\nReason : " +
                                    serverAnswer.ErrorMessage + "\r\nCode : " + serverAnswer.ErrorCode.ToString(),
                                     ToolTipIcon.Warning, this.c_NotifyIconBalloonDisplayTimeout);
                            }
                        }
                    }
                    else if (messageType == typeof(GUIDInformationResponse))
                    {
                        GUIDInformationResponse serverAnswer = (GUIDInformationResponse)e.Data.Object;

                        if (serverAnswer.WorkerID == 0)
                        {
                            this.c_ServerAnswered.Set();

                            //SET CREXTOR INFORMATION
                            this.c_ClientGUID = serverAnswer.GUID;
                        }
                    }
                    else if (messageType == typeof(UnknownCommandResponse))
                    {
                        UnknownCommandResponse serverAnswer = (UnknownCommandResponse)e.Data.Object;

                        if (serverAnswer.WorkerID == 0)
                        {
                            UpdateList("Unknown response issued by the server!", true);

                            ShowInNotifyIcon("Crexta Client", "Unknown command issued by the client!",
                                 ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
                        }
                    }
                    else if (messageType == typeof(FoundedURLsAdded2DB))
                    {
                        FoundedURLsAdded2DB serverAnswer = (FoundedURLsAdded2DB)e.Data.Object;

                        if (serverAnswer.WorkerID == 0)
                        {
                            UpdateList("Founded URLs is now in DB! Good job slave...", true);

                            ShowInNotifyIcon("Crexta Client", "Founded URLs is now in DB! Good job slave...",
                                 ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
                        }
                    }
                    else if (messageType == typeof(ExtractedURLDataAdded2DB))
                    {
                        ExtractedURLDataAdded2DB serverAnswer = (ExtractedURLDataAdded2DB)e.Data.Object;

                        if (serverAnswer.WorkerID == 0)
                        {

                            UpdateList("URL Extraction succesfull! Well done boy...", true);

                            ShowInNotifyIcon("Crexta Client", "URL Extraction succesfull! Well done boy...",
                                 ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
                        }
                    }
                    else if (messageType == typeof(InformSystemUpdate))
                    {
                        InformSystemUpdate serverAnswer = (InformSystemUpdate)e.Data.Object;

                        if (serverAnswer.WorkerID == 0)
                        {
                            UpdateList("New system update available...Restarting application...!", true);

                            ShowInNotifyIcon("Crexta Client", "New system update available...Restarting application...!",
                                 ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

                            // Restart Application
                            this.c_ExitApplication = true;

                            this.CloseApplication(false, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00010]!..." + ex.Message, true);
                Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
            }
        }

        #endregion

        #region client_OnDisconnected

        private void client_OnDisconnected(object sender, NetDisconnectedEventArgs e)
        {
            //Disconnect client
            try
            {
                this.StopClient(false);

                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                this.UpdateList("Error occured, [code:1x00011]!..." + ex.Message, true);
                Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
            }

            this.UpdateList("Client Disconnected...", true);

            ShowInNotifyIcon("Crexta Client", "Client Disconnected...",
                ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
        }

        #endregion

        #region client_OnConnected

        private void client_OnConnected(object sender, NetConnectedEventArgs e)
        {
            this.UpdateList("Client Connected...", true);

            ShowInNotifyIcon("Crexta Client", "Client Connected...",
                ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);
        }

        #endregion

        #region c_InformationUpdateTimer_Elapsed

        private void UpdateFormInformation()
        {
#if ENABLE_UI_UPDATE
            if (this.c_CrextaClient != null)
            {
                if (this.c_CrextaClient.IsConnected)
                    this.clientStatusLabel.Text = "Connected...";
                else
                    this.clientStatusLabel.Text = "Not Connected...";
            }
            else
                this.clientStatusLabel.Text = "Not Connected...";

            if (this.clientTabControl.SelectedIndex != 0)
            {
                if (this.c_WorkerIDAndTabIndex.ContainsValue(this.clientTabControl.SelectedIndex))
                {
                    CrextaClient currentCrextaWorkerClient = null;

                    foreach (object key in this.c_WorkerIDAndTabIndex.Keys)
                    {
                        int targetIndex = int.Parse(this.c_WorkerIDAndTabIndex[key].ToString());
                        if (targetIndex == this.clientTabControl.SelectedIndex)
                        {
                            foreach (CrextaClient worker in this.crextaWorkerClients)
                            {
                                if (worker.WorkerID == int.Parse(key.ToString()))
                                {
                                    currentCrextaWorkerClient = worker;
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (currentCrextaWorkerClient != null)
                    {
                        this.totalItemsCountLabel.Text = "Total Items Sent: " + currentCrextaWorkerClient.TotalItemsSent2Server.ToString();
                        this.threadCountLabel.Text = "Threads in use : " + currentCrextaWorkerClient.ThreadsInUseByCrawler.ToString() + " | Waiting URL Queue : " + currentCrextaWorkerClient.WaitingQueueLenghtOfCrawler.ToString();
                    }
                    else
                    {
                        this.totalItemsCountLabel.Text = "Not Available!";
                        this.threadCountLabel.Text = "Not Available! ";
                    }
                }
            }
            else
            {
                if (Process.GetCurrentProcess() != null)
                {
                    if (Process.GetCurrentProcess().Threads != null)
                        this.threadCountLabel.Text = "Total Thread Count: " + Process.GetCurrentProcess().Threads.Count.ToString();
                }

                int totalItemsSent2Server = 0;
                foreach (CrextaClient worker in this.crextaWorkerClients)
                    totalItemsSent2Server += worker.TotalItemsSent2Server;
                this.totalItemsCountLabel.Text = "Total Items Sent: " + totalItemsSent2Server.ToString();
            }
#endif
        }

        private void c_InformationUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateFormInformation();
        }

        private void c_ConnectionCheckTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.c_SkipClientConnectionCheck || this.c_CrextaClient.IsConnected)
            {
                if (this.c_CrextaClient.IsConnected)
                {
                    ChangeConnectButtonStatus(false);
                    ChangeDisConnectButtonStatus(true);
                }
            }
            else
                this.StartClient();
        }

        #endregion

        #region webClient_DownloadProgressChanged

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.UpdateList("Download progress : " + e.ProgressPercentage.ToString() + "\r\n" + 
                e.BytesReceived.ToString() + " bytes recieved" +"\r\n" + (e.TotalBytesToReceive-e.BytesReceived).ToString() + 
                " bytes left", true);
        }

        #endregion

        #region webClient1_DownloadFileCompleted (MainList.zip)

        private void webClient1_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.UpdateList("Download complete...Installing new version...", true);

            this.ShowInNotifyIcon("Crexta Client", "Download complete...Installing new version...",
                 ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

            string zipFile = Path.GetTempPath() + "Mainlist.zip";

            if (File.Exists(zipFile))
            {
                try
                {
                    using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile)))
                    {
                        ZipEntry theEntry;

                        //Delete all rules
                        if (Directory.Exists(Common.Constants.GeneralConstants.defaultRulesFileRoot))
                            Directory.Delete(Common.Constants.GeneralConstants.defaultRulesFileRoot, true);

                        //Re-create directory
                        if (!Directory.Exists(Common.Constants.GeneralConstants.defaultRulesFileRoot))
                            Directory.CreateDirectory(Common.Constants.GeneralConstants.defaultRulesFileRoot);

                        while ((theEntry = s.GetNextEntry()) != null)
                        {
                            string fileName = Path.GetFileName(theEntry.Name);

                            if (fileName != String.Empty)
                            {
                                using (FileStream streamWriter = File.Create(Common.Constants.GeneralConstants.defaultRulesFileRoot + theEntry.Name))
                                {
                                    int size = 2048;
                                    byte[] data = new byte[2048];
                                    while (true)
                                    {
                                        size = s.Read(data, 0, data.Length);
                                        if (size > 0)
                                        {
                                            streamWriter.Write(data, 0, size);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    this.UpdateList("Unzip error!..." + ex.Message, true);

                    this.ShowInNotifyIcon("Crexta Client", "Unzip error...",
                         ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                    this.c_DownloadMainlistOK = false;

                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                }
            }
            else
            {
                this.UpdateList("Downloaded file not found!...", true);

                this.ShowInNotifyIcon("Crexta Client", "Downloaded file not found!...",
                     ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                this.c_DownloadMainlistOK = false;
            }

            this.c_FileDownloaded.Set();
        }

        #endregion

        #region webClient_DownloadFileCompleted (Client.zip)

        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.UpdateList("Download complete...Installing new version...", true);

            this.ShowInNotifyIcon("Crexta Client", "Download complete...Installing new version...",
                 ToolTipIcon.Info, this.c_NotifyIconBalloonDisplayTimeout);

            string zipFile = Path.GetTempPath() + "Client.zip";

            if (File.Exists(zipFile))
            {
                try
                {
                    using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFile)))
                    {
                        ZipEntry theEntry;

                        while ((theEntry = s.GetNextEntry()) != null)
                        {
                            string fileName = Path.GetFileName(theEntry.Name);

                            if (fileName != String.Empty)
                            {
                                using (FileStream streamWriter = File.Create(Path.GetTempPath() + theEntry.Name))
                                {
                                    int size = 2048;
                                    byte[] data = new byte[2048];
                                    while (true)
                                    {
                                        size = s.Read(data, 0, data.Length);
                                        if (size > 0)
                                        {
                                            streamWriter.Write(data, 0, size);
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.UpdateList("Unzip error!..." + ex.Message, true);

                    this.ShowInNotifyIcon("Crexta Client", "Unzip error...",
                         ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                    this.c_DownloadClientOK = false;

                    Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                }

                string msiFile = Path.GetTempPath() + "Crexta.ClientSetup.msi";
                string setupFile = Path.GetTempPath() + "Setup.exe";

                //Unzip finished, check files
                if (File.Exists(msiFile) && File.Exists(setupFile))
                {
                    System.Diagnostics.Process.Start(setupFile);

                    this.c_ExitApplication = true;

                    this.CloseApplication(false, false);
                }
                else
                {
                    this.UpdateList("Missing setup file!...", true);

                    this.ShowInNotifyIcon("Crexta Client", "Missing setup file!...",
                         ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                    this.c_DownloadClientOK = false;
                }
            }
            else
            {
                this.UpdateList("Downloaded file not found!...", true);

                this.ShowInNotifyIcon("Crexta Client", "Downloaded file not found!...",
                     ToolTipIcon.Error, this.c_NotifyIconBalloonDisplayTimeout);

                this.c_DownloadClientOK = false;
            }

            this.c_FileDownloaded.Set();
        }

        #endregion

        #region Client_Resize

        private void Client_Resize(object sender, EventArgs e)
        {
            //resize the toolstrip
            this.clientToolStrip.Size = new Size(this.Width, this.clientToolStrip.Height);

            if (this.WindowState == FormWindowState.Minimized)
                this.SendToTaskBar();
            else
                this.RestoreApplication();
        }

        #endregion

        #region ToolStrip (Menu, Status) Events

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Preferences form = new Preferences(this.c_Instance);

            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // reload settings
                    Settings.LoadSettings(this.c_Instance);

                    this.c_MainStartThreadPriority = (ThreadPriority)(int.Parse(Settings.ClientSettings[GeneralConstants.clientStartThreadPriority].ToString()));
                    if (this.c_MainClientStartThread != null && this.c_MainClientStartThread.IsAlive)
                        this.c_MainClientStartThread.Priority = this.c_MainStartThreadPriority;

                    this.c_LogAllEvents = bool.Parse(Settings.ClientSettings[ClientConstants.logAllEvents].ToString());
                    this.c_ShowNotifications = bool.Parse(Settings.ClientSettings[ClientConstants.showNotifications].ToString());

                    // Apply new settings to the sub-clients!!!
                    foreach (CrextaClient crextaWorkerClient in this.crextaWorkerClients)
                        crextaWorkerClient.ReloadSettings();

                    this.UpdateList("New settings are applied succesfully...", false);
                }
                catch (Exception ex)
                {
                    this.UpdateList("Error occured, [code:1x00012]!..." + ex.Message, true);
                    Write2Log(LogLevel.ERROR, Utilities.Utilities.DumpException(ex));
                }
            }
        }

        private void exitToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.c_ExitApplication = true;

            this.CloseApplication(false, false);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == this.connectButton)
                this.connectToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.disconnectButton)
                this.disconnectToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.send2TaskBarButton)
                this.send2TaskbarToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.aboutButton)
                this.aboutToolStripMenuItem_Click(this, new EventArgs());
            else if (e.ClickedItem == this.exitButton)
                this.exitToolStripMenuItem2_Click(this, new EventArgs());
            else if (e.ClickedItem == this.settingButton)
                this.preferencesToolStripMenuItem_Click(this, new EventArgs());
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestoreApplication();
        }

        private void send2TaskbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CloseApplication(true, false);
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.c_ExitApplication = true;

            this.CloseApplication(false, false);
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.c_CrextaClient != null)
            {
                if (!this.c_CrextaClient.IsConnected)
                {
                    this.StopConnectionTimer();

                    //starting a new connect-disconnect event so we have to prevent user doing the same event again and again
                    //before the event ends!
                    ChangeConnectButtonStatus(false);
                    ChangeDisConnectButtonStatus(false);

                    this.StartClient();
                }
                else
                    this.UpdateList("Client is already connected!", true);
            }
        }

        private void ChangeConnectButtonStatus(bool status)
        {
#if ENABLE_UI_UPDATE
            this.connectToolStripMenuItem.Enabled = status;
            this.connectButton.Enabled = status;
#endif
        }

        private void ChangeDisConnectButtonStatus(bool status)
        {
#if ENABLE_UI_UPDATE
            this.disconnectToolStripMenuItem.Enabled = status;
            this.disconnectButton.Enabled = status;
#endif
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.c_CrextaClient != null)
            {
                if (this.c_CrextaClient.IsConnected)
                {
                    ChangeConnectButtonStatus(false);
                    ChangeDisConnectButtonStatus(false);

                    this.StopClient(false);
                }
                else
                {
                    ChangeConnectButtonStatus(true);
                    ChangeDisConnectButtonStatus(false);
                }
            }
            else
            {
                ChangeConnectButtonStatus(true);
                ChangeDisConnectButtonStatus(false);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About form = new About();

            form.ShowDialog();
        }

        #endregion

        #region Client_FormClosed, Client_FormClosing, c_ConnectionCheckTimer_Elapsed, notifyIcon1_DoubleClick

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.StopConnectionTimer();

            this.StopClient(true);
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.c_ExitApplication && e.CloseReason != CloseReason.WindowsShutDown)
            {
                CloseApplication(true, false);

                e.Cancel = true;
            }
        }

        void c_KeepMeAliveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Check client connectivity!
            if (this.c_CrextaClient != null)
            {
                if (this.c_CrextaClient.IsConnected)
                {
                    KeepMeAliveMaster message = new KeepMeAliveMaster();
                    message.GUID = this.c_ClientGUID;
                    message.ClientID = this.c_ClientID;
                    message.WorkerID = 0;

                    //this.c_ServerAnswered.Reset();
                    try
                    {
                        this.c_CrextaClient.Send("Keep me alive master, i beg you!", message);
                    }
                    catch (Exception ex)
                    {
                        this.UpdateList("Error occured, [code:1x00013]!..." + ex.Message, true);
                        Write2Log(LogLevel.DEBUG, Utilities.Utilities.DumpException(ex));
                    }
                    //this.c_ServerAnswered.WaitOne(TimeSpan.FromSeconds(this.c_ServerAnswerWaitTimeout));

                    //Just wait a little more so that we can set variables according to the server answer
                    Thread.Sleep(this.c_WaitTimeoutAfterServerAnswer);

                    this.UpdateList("Keep alive command issued...Success...", true);
                    Write2Log(LogLevel.INFO, "Keep alive command issued...Success...");
                }
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            RestoreApplication();
        }

        #endregion

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.clientTabControl.SelectedIndex != 0)
            {
                if (this.c_WorkerIDAndTabIndex.ContainsValue(this.clientTabControl.SelectedIndex))
                {
                    CrextaClient currentCrextaWorkerClient = null;

                    foreach (object key in this.c_WorkerIDAndTabIndex.Keys)
                    {
                        int targetIndex = int.Parse(this.c_WorkerIDAndTabIndex[key].ToString());
                        if (targetIndex == this.clientTabControl.SelectedIndex)
                        {
                            foreach (CrextaClient worker in this.crextaWorkerClients)
                            {
                                if (worker.WorkerID == int.Parse(key.ToString()))
                                {
                                    currentCrextaWorkerClient = worker;
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    if (currentCrextaWorkerClient != null)
                    {
                        if (currentCrextaWorkerClient.Output != null && currentCrextaWorkerClient.Output.SelectedText != null)
                            Clipboard.SetText(currentCrextaWorkerClient.Output.SelectedText);
                    }
                }
            }
            else
            {
                if (this.mainMessageList.SelectedText != null)
                    Clipboard.SetText(this.mainMessageList.SelectedText);
            }
        }

        #endregion

        private void clientTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormInformation();
        }
    }
}
