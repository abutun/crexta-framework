/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

#define DEBUGUI

using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security;
using System.Threading;
using System.Xml;

using Crexta.Common;
using Crexta.Common.Crawler;
using System.Net;

namespace Crexta.Explorer
{
    public partial class RuleTester : Form
    {
        Thread mainTesterThread = null;

        Thread browserThread = null;

        public RuleTester()
        {
            InitializeComponent();
        }

        private void RuleTester_Load(object sender, EventArgs e)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                ExplorerUtilities.BindRuleLists(this.ruleListCombo, -1);

                this.urlText.Focus();
            }
            else
            {
                MessageBox.Show("Please select a company!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.Close();
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            this.testButton.Enabled = false;

            Clear();

#if DEBUGUI
            try
            {
                if (this.mainTesterThread != null)
                    this.mainTesterThread.Abort();
            }
            catch
            {
            }

            this.mainTesterThread = new Thread(new ThreadStart(this.DoThreadJob));
            this.mainTesterThread.SetApartmentState(ApartmentState.STA);
            this.mainTesterThread.Start();
#else
            this.DoThreadJob();
#endif
        }

        private void Clear()
        {
            this.webBrowser1.Navigate("about:blank");
            this.parserLogList.Items.Clear();
        }

        private void DoNavigateJob()
        {
            Uri currentUri = null;

            if (Uri.TryCreate(this.urlText.Text, UriKind.Absolute, out currentUri))
                this.webBrowser1.Navigate(currentUri);
        }

        private void DoThreadJob()
        {
            if (!string.IsNullOrEmpty(this.urlText.Text))
            {
                if (this.ruleListCombo.SelectedIndex >= 0)
                {
                    Crexta.DataBase.Rule selectedRule = (Crexta.DataBase.Rule)this.ruleListCombo.SelectedItem;

                    if (selectedRule != null)
                    {
                        if (selectedRule.Data != null)
                        {
                            this.UpdateList("Serializing rule list...");

                            CrawlerRuleCollection crextorRuleList = (CrawlerRuleCollection)Serializer.Deserialize(selectedRule.Data.ToArray());

                            if (crextorRuleList != null)
                            {
                                Uri currentUri = null;

                                if (Uri.TryCreate(this.urlText.Text, UriKind.Absolute, out currentUri))
                                {
                                    StringBuilder xml2send = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\" ?><rules>");

                                    this.UpdateList("Selecting relevant rule...");

                                    //Enumerate rules and check if the current url matches any of the rule regex
                                    int ruleIndex = crextorRuleList.GetRelevantRule(this.urlText.Text);

                                    if (ruleIndex >= 0)
                                    {
                                        CrawlerRule currentRule = crextorRuleList[ruleIndex];

                                        using (WebClient webClient = new WebClient())
                                        {
                                            // USE MOZILLA OR ANY OTHER USER AGENT INFORMATION SINCE SOME SERVERS MAY REJECT REQUEST FROM UNKNOWN USER AGENTS!!!
                                            webClient.Headers.Add("user-agent", "Mozilla/6.0 (Macintosh; I; Intel Mac OS X 11_7_9; de-LI; rv:1.9b4) Gecko/2012010317 Firefox/10.0a4");

                                            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

                                            if (currentRule != null)
                                            {
                                                this.UpdateList("Current URL : " + currentUri.ToString());

                                                xml2send.Append("<rule name=\"");
                                                xml2send.Append(currentRule.Name != null ? SecurityElement.Escape(currentRule.Name) : "");
                                                xml2send.Append("\" tablename=\"");
                                                xml2send.Append(currentRule.DatabaseTableName != null ? SecurityElement.Escape(currentRule.DatabaseTableName.ToLowerInvariant()) : "");
                                                xml2send.Append("\">");

                                                #region Download Web Site

                                                this.UpdateList("Loading web site...");

                                                bool loadError = false;
                                                try
                                                {
                                                    webClient.Encoding = currentRule.Encoding;
                                                    if (currentRule.ClickItem == null)
                                                        htmlDoc.LoadHtml(webClient.DownloadString(currentUri.ToString()));
                                                    else
                                                    {
                                                        htmlDoc = currentRule.ClickItem.Execute(currentUri.ToString());
                                                        if (htmlDoc == null && !currentRule.ClickItem.MustClick)
                                                            htmlDoc.LoadHtml(webClient.DownloadString(currentUri.ToString()));
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    loadError = true;
                                                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                                }

                                                #endregion

                                                #region Process HTML

                                                if (htmlDoc != null && !loadError)
                                                {
                                                    #region Enumerate Crextor Rule's Criterias

                                                    this.UpdateList("Enumerating rule criterias...");

                                                    foreach (CrawlerCriteria criteria in currentRule.Criterias)
                                                    {
                                                        xml2send.Append("<criteria name=\"");
                                                        xml2send.Append(criteria.Name != null ? SecurityElement.Escape(criteria.Name) : "");
                                                        xml2send.Append("\" columnname=\"");
                                                        xml2send.Append(criteria.ColumnName != null ? SecurityElement.Escape(criteria.ColumnName.ToLowerInvariant()) : "");
                                                        xml2send.Append("\" columntype=\"");
                                                        xml2send.Append(criteria.ColumnType != null ? SecurityElement.Escape(criteria.ColumnType.ToString().ToLowerInvariant()) : "");
                                                        xml2send.Append("\">");

                                                        //SET criteria URL in order to provide reliable match
                                                        criteria.URL = currentUri.ToString();

                                                        criteria.Match(htmlDoc);

                                                        if (criteria.Text2Xml != null)
                                                            xml2send.Append(criteria.Text2Xml);

                                                        xml2send.Append("</criteria>");
                                                    }

                                                    #endregion
                                                }
                                                else
                                                    xml2send.Append("<error code=\"0x0001\"><![CDATA[Html Document is Null]]></error>");

                                                #endregion

                                                xml2send.Append("</rule>");
                                            }
                                            else
                                                this.UpdateList("Crextor rule index returned nothing!");
                                        }
                                    }
                                    else
                                        this.UpdateList("Crextor rule index not found!");

                                    xml2send.Append("</rules>");

                                    this.UpdateList("Dumping results...");

                                    if (this.InvokeRequired)
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            DumpXML2TreeView(xml2send.ToString());
                                        });
                                    }
                                }
                                else
                                    this.UpdateList("Please enter a valid URL!");
                            }
                            else
                                this.UpdateList("Crextor rule serialization is null!");
                        }
                        else
                            this.UpdateList("Crextor rule data is null!");
                    }
                    else
                        this.UpdateList("Crextor rule not found!");
                }
                else
                    this.UpdateList("Crextor rule data information is NULL for this URL");
            }

            this.testButton.Enabled = true;
        }

        private string GetElementViewName(XmlElement elem)
        {
            if (elem != null)
            {
                string name = elem.Name;

                foreach (XmlAttribute att in elem.Attributes)
                    name += " " + att.Name != null ? att.Name : "??" + "=\"" + att.Value != null ? att.Value : "??" + "\"";

                return name;
            }

            return "???";
        }

        private string GetNodeViewName(XmlNode node)
        {
            if (node != null)
            {
                string name = node.Name;

                  foreach (XmlAttribute att in node.Attributes)
                      name += " " + att.Name != null ? att.Name : "??" + "=\"" + att.Value != null ? att.Value : "??" + "\"";

                return name;
            }

            return "???";
        }

        private void DumpXML2TreeView(string xml)
        {
            try
            {
                XmlDocument XmlDoc = new XmlDocument();
                XmlDoc.LoadXml(xml);

                // SECTION 2. Initialize the TreeView control.
                xmlTreeView.Nodes.Clear();
                xmlTreeView.Nodes.Add(new TreeNode(XmlDoc.DocumentElement.Name));
                TreeNode tNode = new TreeNode();
                tNode = xmlTreeView.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(XmlDoc.DocumentElement, tNode);
                xmlTreeView.ExpandAll();
            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show(xmlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.UpdateList("Successfully dumped...");
        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    string name = xNode.Name;
                    if (xNode.Attributes != null)
                    {
                        if (xNode.Attributes["name"] != null)
                        {
                            if (xNode.Attributes["name"].Value != "")
                                name += " name=\"" + xNode.Attributes["name"].Value + "\"";
                        }
                    }
                    inTreeNode.Nodes.Add(new TreeNode(name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        private void UpdateList(string msg)
        {
            this.parserLogList.Items.Add(msg);
        }

        private void urlText_TextChanged(object sender, EventArgs e)
        {
            Uri currentUri = null;

            if (Uri.TryCreate(this.urlText.Text, UriKind.Absolute, out currentUri))
            {
                string domain1 = currentUri.Authority;
                string domain2 = domain1.Replace("www.", "");

                foreach (object obj in this.ruleListCombo.Items)
                {
                    Crexta.DataBase.Rule rule = (Crexta.DataBase.Rule)obj;
                    if (rule.Name.ToLower() == domain1 || rule.Name.ToLower() == domain2 || domain1.ToLower().Contains(rule.Name.ToLower()) || domain2.ToLower().Contains(rule.Name.ToLower()))
                    {
                        this.ruleListCombo.SelectedItem = rule;

                        CrawlerRuleCollection crextorRuleList = (CrawlerRuleCollection)Serializer.Deserialize(rule.Data.ToArray());

                        this.relevantRuleIndex.Text = "Rule Index = " + crextorRuleList.GetRelevantRule(this.urlText.Text);

                        break;
                    }
                }
            }
        }

        private void shewInBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (showInBrowser.Checked)
            {
#if DEBUGUI
                try
                {
                    if (this.browserThread != null)
                        this.browserThread.Abort();
                }
                catch
                {
                }

                this.browserThread = new Thread(new ThreadStart(this.DoNavigateJob));
                this.browserThread.Start();
#else
            this.DoNavigateJob();
#endif
            }
            else
                this.webBrowser1.Navigate("about:blank");
        }
    }
}
