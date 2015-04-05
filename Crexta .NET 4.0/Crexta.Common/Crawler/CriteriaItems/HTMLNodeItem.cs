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
using System.Collections.Generic;
using System.Linq;
using Crexta.Common.Crawler.Interfaces;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

namespace Crexta.Common.Crawler.CriteriaItems
{
    [Serializable]
    public class HTMLNodeItem : ICrawlerCriteriaItem
    {
        #region Variable Definitions

        private string h_Name = "";
        private string h_Xpath = "";
        private string h_AttributeName = "";
        private string h_ResultPrefix = "";

        List<string> h_ExcludeRegexList = new List<string>();
        List<int> h_ExcludeChildNodeList = new List<int>();

        private bool h_ReturnOnlyNodeText = false;
        private bool h_ReturnNodeHtmlAsText = false;

        private readonly int h_Version = 1;

        #endregion

        #region Constructor Logic

        public HTMLNodeItem()
            : this("HTML Node Item", "", false)
        {
        }

        public HTMLNodeItem(string name, string xpath)
            : this(name, xpath, "", false)
        {
        }

        public HTMLNodeItem(string name, string xpath, bool returnonlynodetext)
            : this(name, xpath, "", returnonlynodetext)
        {
        }

        public HTMLNodeItem(string name, string xpath, string resultattribute)
            : this(name, xpath, resultattribute, false)
        {
        }

        public HTMLNodeItem(string name, string xpath, string resultattribute, bool returnonlynodetext)
        {
            this.h_Name = name;
            this.h_Xpath = xpath;
            this.h_AttributeName = resultattribute;
            this.h_ReturnOnlyNodeText = returnonlynodetext;
        }

        public HTMLNodeItem(SerializationInfo info, StreamingContext context)
        {
            int version = 1;
            try
            {
                version = info.GetInt32("h_Version");
            }
            catch
            {
                // NOP
            }

            switch (version)
            {
                case 1:
                    h_Name = info.GetString("h_Name");
                    h_Xpath = info.GetString("h_Xpath");
                    h_AttributeName = info.GetString("h_AttributeName");
                    h_ResultPrefix = info.GetString("h_ResultPrefix");
                    h_ExcludeRegexList = (List<string>)info.GetValue("h_ExcludeRegexList", typeof(List<string>));
                    h_ExcludeChildNodeList = (List<int>)info.GetValue("h_ExcludeChildNodeList", typeof(List<int>));
                    h_ReturnOnlyNodeText = info.GetBoolean("h_ReturnOnlyNodeText");
                    h_ReturnNodeHtmlAsText = info.GetBoolean("h_ReturnNodeHtmlAsText");
                    break;
            }

        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                return this.h_Name;
            }
            set
            {
                this.h_Name = value;
            }
        }

        public string AttributeName
        {
            get
            {
                return this.h_AttributeName;
            }
            set
            {
                this.h_AttributeName = value;
            }
        }

        public string XPath
        {
            get
            {
                return this.h_Xpath;
            }
            set
            {
                this.h_Xpath = value;
            }
        }

        public string ResultPrefix
        {
            get
            {
                return this.h_ResultPrefix;
            }
            set
            {
                this.h_ResultPrefix = value;
            }
        }

        public List<string> ExcludeRegexList
        {
            get
            {
                return this.h_ExcludeRegexList;
            }
            set
            {
                this.h_ExcludeRegexList = value;
            }
        }

        public List<int> ExcludeChildNodeIndexes
        {
            get
            {
                return this.h_ExcludeChildNodeList;
            }
            set
            {
                this.h_ExcludeChildNodeList = value;
            }
        }

        public bool ReturnOnlyNodeText
        {
            get
            {
                return this.h_ReturnOnlyNodeText;
            }
            set
            {
                this.h_ReturnOnlyNodeText = value;
            }
        }

        public bool ReturnNodeHtmlAsText
        {
            get
            {
                return this.h_ReturnNodeHtmlAsText;
            }
            set
            {
                this.h_ReturnNodeHtmlAsText = value;
            }
        }

        #endregion

        #region Public Methods

        public void Execute(HtmlDocument htmldoc, CrawlerCriteria criteria, int pipelineindex)
        {
            List<CrawlerCriteriaItemResult> previousResultList = new List<CrawlerCriteriaItemResult>();

            //Get previous result item and process it
            //If this is the first pipeline item then get the rule htmldocument for input object
            if (pipelineindex == 0)
            {
                if (htmldoc != null)
                {
                    // first item in the queue so process the current html document
                    previousResultList.Add(new CrawlerCriteriaItemResult(htmldoc.DocumentNode, typeof(HtmlNode)));
                }
            }
            else
            {
                // not the first item in the queue, so select the previous result(s)
                previousResultList = criteria.ExecutionPipelineResults[pipelineindex - 1];
            }

            // enumerate all previous objects and execute current item
            try
            {
                foreach (CrawlerCriteriaItemResult previousResultObject in previousResultList)
                {
                    HtmlNode previousResult = null;
                    HtmlNode executionResult = null;

                    // Current item type (HtmlNode) will always return 1 element, so the list size will always be 1
                    List<CrawlerCriteriaItemResult> currentResultList = new List<CrawlerCriteriaItemResult>();

                    if (previousResultObject != null)
                        previousResult = (HtmlNode)previousResultObject.Result;

                    //Process the previous item
                    if (previousResult != null)
                    {
                        //Create new HtmlDocument from outerhtml of the prev. htmlnode
                        //We have to do this, otherwise SelectSingleNode will populate from the ownerdocument
                        HtmlDocument tmpHtmlDoc = new HtmlDocument();
                        tmpHtmlDoc.LoadHtml(previousResult.OuterHtml);

                        executionResult = tmpHtmlDoc.DocumentNode.SelectSingleNode(this.h_Xpath);
                    }

                    //Get and convert the result if neccesary
                    if (executionResult != null)
                    {
                        try
                        {
                            //Process exclude regex list
                            foreach (string s in this.h_ExcludeRegexList)
                            {
                                Regex tmpRegex = new Regex(s, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline | RegexOptions.IgnoreCase);

                                executionResult.InnerHtml = tmpRegex.Replace(executionResult.InnerHtml, "");
                            }

                            //Process exclude node indexes
                            foreach (int i in this.h_ExcludeChildNodeList)
                                executionResult.RemoveChild(executionResult.ChildNodes[i], false);

                            if (!this.h_ReturnOnlyNodeText)
                                currentResultList.Add(new CrawlerCriteriaItemResult(executionResult, typeof(HtmlNode)));
                            else
                            {
                                string tmpResult = "";

                                if (this.h_AttributeName == "")
                                {
                                    if (this.h_ReturnNodeHtmlAsText)
                                        tmpResult = executionResult.InnerHtml;
                                    else
                                    {
                                        tmpResult = Crexta.Utilities.Utilities.StripHTML(executionResult.InnerHtml);
                                        tmpResult = Crexta.Utilities.Utilities.OptimizeLineBreaksForHtml(tmpResult);
                                    }
                                }
                                else
                                    tmpResult = executionResult.Attributes[this.h_AttributeName].Value;

                                //Add prefix
                                if (this.h_ResultPrefix != "")
                                    tmpResult = this.h_ResultPrefix + tmpResult;

                                currentResultList.Add(new CrawlerCriteriaItemResult(tmpResult, typeof(string)));
                            }
                        }
                        catch
                        {
                            //NOP
                        }
                    }

                    //Save current execution result
                    criteria.ExecutionPipelineResults.Add(currentResultList);
                }
            }
            catch (Exception)
            {
                // Log it
            }
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("h_Version", h_Version);

            info.AddValue("h_Name", h_Name);
            info.AddValue("h_Xpath", h_Xpath);
            info.AddValue("h_AttributeName", h_AttributeName);
            info.AddValue("h_ResultPrefix", h_ResultPrefix);
            info.AddValue("h_ExcludeRegexList", h_ExcludeRegexList, typeof(List<string>));
            info.AddValue("h_ExcludeChildNodeList", h_ExcludeChildNodeList, typeof(List<int>));
            info.AddValue("h_ReturnOnlyNodeText", h_ReturnOnlyNodeText);
            info.AddValue("h_ReturnNodeHtmlAsText", h_ReturnNodeHtmlAsText);
        }

        #endregion
    }
}
