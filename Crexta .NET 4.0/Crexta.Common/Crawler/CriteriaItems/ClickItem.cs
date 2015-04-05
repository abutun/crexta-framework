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
using System.Runtime.Serialization;
using HtmlAgilityPack;

using Crexta.Common.Crawler.Interfaces;
using Crexta.Common.Crawler.Enums;
using WatiN.Core;

namespace Crexta.Common.Crawler.CriteriaItems
{
    [Serializable]
    public class ClickItem : ICrawlerCriteriaItem
    {
        private string c_Name = "";
        private string c_LinkID = "";
        private string c_LinkText = "";

        private ClickItemType c_LinkType = ClickItemType.ANCHOR;
        private BrowserType c_BrowserType = BrowserType.EXPLORER;

        //private int c_Version = 1;
        private readonly int c_Version = 2;
        private readonly int c_NavigationTimeout = 60; //seconds

        private bool c_MustClick = false;
        private bool c_WaitForAjax = false;
        private bool c_WaitForDocumentLoad = false;
        private bool c_HideInnerBrowserWindow = true;

        #region Constructor Logic

        public ClickItem() : this("", BrowserType.EXPLORER, ClickItemType.ANCHOR, "", "", false, false) { }

        public ClickItem(string name) : this(name, BrowserType.EXPLORER, ClickItemType.ANCHOR, "", "", false, false) { }

        public ClickItem(string name, BrowserType browsertype) : this(name, browsertype, ClickItemType.ANCHOR, "", "", false, false) { }

        public ClickItem(string name, BrowserType browsertype, ClickItemType linktype) : this(name, browsertype, linktype, "", "", false, false) { }

        public ClickItem(string name, BrowserType browsertype, ClickItemType linktype, string linkid) : this(name, browsertype, linktype, linkid, "", false, false) { }

        public ClickItem(string name, BrowserType browsertype, ClickItemType linktype, string linkid, string linktext) : this(name, browsertype, linktype, linkid, linktext, false, false) { }

        public ClickItem(string name, BrowserType browsertype, ClickItemType linktype, string linkid, string linktext, bool mustclick) : this(name, browsertype, linktype, linkid, linktext, mustclick, false) { }

        public ClickItem(string name, BrowserType browsertype, ClickItemType linktype, string linkid, string linktext, bool mustclick, bool waitforajax)
        {
            this.c_Name = name;
            this.c_LinkType = linktype;
            this.c_LinkID = linkid;
            this.c_LinkText = linktext;
            this.c_WaitForAjax = waitforajax;
            this.c_MustClick = mustclick;
        }

        public ClickItem(SerializationInfo info, StreamingContext context)
        {
            int version = 1;
            try
            {
                version = info.GetInt32("c_Version");
            }
            catch
            {
                // NOP
            }

            switch (version)
            {
                case 1:
                    c_Name = info.GetString("c_Name");
                    c_LinkID = info.GetString("c_LinkID");
                    c_LinkText = info.GetString("c_LinkText");
                    c_MustClick = info.GetBoolean("c_MustClick");
                    c_WaitForAjax = info.GetBoolean("c_WaitForAjax");
                    c_LinkType = (ClickItemType)info.GetValue("c_LinkType", typeof(ClickItemType));
                    c_BrowserType = (BrowserType)info.GetValue("c_BrowserType", typeof(BrowserType));
                    break;
                case 2:
                    c_Name = info.GetString("c_Name");
                    c_LinkID = info.GetString("c_LinkID");
                    c_LinkText = info.GetString("c_LinkText");
                    c_MustClick = info.GetBoolean("c_MustClick");
                    c_WaitForAjax = info.GetBoolean("c_WaitForAjax");
                    c_HideInnerBrowserWindow = info.GetBoolean("c_HideInnerBrowserWindow"); //NEW
                    c_WaitForDocumentLoad = info.GetBoolean("c_WaitForDocumentLoad"); //NEW
                    c_LinkType = (ClickItemType)info.GetValue("c_LinkType", typeof(ClickItemType));
                    c_BrowserType = (BrowserType)info.GetValue("c_BrowserType", typeof(BrowserType));
                    break;
            }
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                return this.c_Name;
            }
            set
            {
                this.c_Name = value;
            }
        }

        public string LinkID
        {
            get
            {
                return this.c_LinkID;
            }
            set
            {
                this.c_LinkID = value;
            }
        }

        public string LinkText
        {
            get
            {
                return this.c_LinkText;
            }
            set
            {
                this.c_LinkText = value;
            }
        }

        public ClickItemType LinkType
        {
            get
            {
                return this.c_LinkType;
            }
            set
            {
                this.c_LinkType = value;
            }
        }

        public BrowserType BrowserType
        {
            get
            {
                return this.c_BrowserType;
            }
            set
            {
                this.c_BrowserType = value;
            }
        }

        public bool MustClick
        {
            get
            {
                return this.c_MustClick;
            }
            set
            {
                this.c_MustClick = value;
            }
        }

        public bool WaitForDocumentLoad
        {
            get
            {
                return this.c_WaitForDocumentLoad;
            }
            set
            {
                this.c_WaitForDocumentLoad = value;
            }
        }

        public bool HideInnerBrowserWindow
        {
            get
            {
                return this.c_HideInnerBrowserWindow;
            }
            set
            {
                this.c_HideInnerBrowserWindow = value;
            }
        }

        public bool WaitForAjax
        {
            get
            {
                return this.c_WaitForAjax;
            }
            set
            {
                this.c_WaitForAjax = value;
            }
        }

        #endregion

        #region Public Methods

        public HtmlDocument Execute(string url)
        {
            HtmlDocument doc = null;

            Uri singleuri = null;

            if (Uri.TryCreate(url, UriKind.Absolute, out singleuri))
            {
                if (this.c_BrowserType == Enums.BrowserType.EXPLORER)
                {
                    using (var browser = new IE(singleuri, false))
                    {
                        WatiN.Core.Settings.WaitForCompleteTimeOut = this.c_NavigationTimeout;
                        //WatiN.Core.Settings.MakeNewIeInstanceVisible = false;

                        if (this.HideInnerBrowserWindow)
                            browser.ShowWindow(WatiN.Core.Native.Windows.NativeMethods.WindowShowStyle.Hide);

                        if (this.c_LinkType == ClickItemType.ANCHOR)
                        {
                            if (!string.IsNullOrEmpty(this.c_LinkID))
                            {
                                Link link = browser.Link(Find.ById(this.c_LinkID));

                                if (link != null && link.Exists)
                                {
                                    if (this.c_WaitForDocumentLoad)
                                        link.Click();
                                    else
                                        link.ClickNoWait();

                                    HtmlDocument html = new HtmlDocument();
                                    html.LoadHtml(browser.Html);

                                    return html;
                                }

                                return null;
                            }
                            else if (!string.IsNullOrEmpty(this.c_LinkText))
                            {
                                Link link = browser.Link(Find.ByText(this.c_LinkText));

                                if (link != null && link.Exists)
                                {
                                    if (this.c_WaitForDocumentLoad)
                                        link.Click();
                                    else
                                        link.ClickNoWait();

                                    HtmlDocument html = new HtmlDocument();
                                    html.LoadHtml(browser.Html);

                                    return html;
                                }

                                return null;
                            }
                        }
                        else if (this.c_LinkType == ClickItemType.BUTTON)
                        {
                            if (!string.IsNullOrEmpty(this.c_LinkID))
                            {
                                Button button = browser.Button(Find.ById(this.c_LinkID));

                                if (button != null && button.Exists)
                                {
                                    if (this.c_WaitForDocumentLoad)
                                        button.Click();
                                    else
                                        button.ClickNoWait();

                                    HtmlDocument html = new HtmlDocument();
                                    html.LoadHtml(browser.Html);

                                    return html;
                                }

                                return null;
                            }
                            else if (!string.IsNullOrEmpty(this.c_LinkText))
                            {
                                Button button = browser.Button(Find.ByText(this.c_LinkText));

                                if (button != null && button.Exists)
                                {
                                    if (this.c_WaitForDocumentLoad)
                                        button.Click();
                                    else
                                        button.ClickNoWait();

                                    HtmlDocument html = new HtmlDocument();
                                    html.LoadHtml(browser.Html);

                                    return html;
                                }

                                return null;
                            }
                        }
                    }
                }
                else
                {
                    using (var browser = new FireFox(singleuri))
                    {
                    }
                }
            }

            return doc;
        }

        public void Execute(HtmlDocument htmldoc, CrawlerCriteria criteria, int pipelineindex)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_Name", c_Name);
            info.AddValue("c_LinkID", c_LinkID);
            info.AddValue("c_LinkText", c_LinkText);
            info.AddValue("c_MustClick", c_MustClick);
            info.AddValue("c_WaitForAjax", c_WaitForAjax);
            info.AddValue("c_WaitForDocumentLoad", c_WaitForDocumentLoad);
            info.AddValue("c_HideInnerBrowserWindow", c_HideInnerBrowserWindow);
            info.AddValue("c_LinkType", c_LinkType, typeof(ClickItemType));
            info.AddValue("c_BrowserType", c_BrowserType, typeof(BrowserType));
        }

        #endregion
    }
}
