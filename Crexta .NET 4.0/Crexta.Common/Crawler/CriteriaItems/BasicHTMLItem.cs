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
using System.Runtime.Serialization;

namespace Crexta.Common.Crawler.CriteriaItems
{
    [Serializable]
    public class BasicHTMLItem : ICrawlerCriteriaItem
    {
        #region Variable Definitions

        private string b_Name = "";
        private string b_HTMLBegin = "";
        private string b_HTMLEnd = "";
        private string b_ResultPrefix = "";

        private int b_EndCount = 0;
        private readonly int b_Version = 1;

        private bool b_UseResultAsHtmlNode = false;

        #endregion

        #region Constructor Logic

        public BasicHTMLItem() 
            : this("Basic HTML Item", "", "", 0)
        {
        }

        public BasicHTMLItem(string name, string htmlbegin, string htmlend)
            : this(name, htmlbegin, htmlend, 0)
        {
        }

        public BasicHTMLItem(string name, string htmlbegin, string htmlend, int endcount)
            : this(name, htmlbegin, htmlend, endcount, false)
        {
        }

        public BasicHTMLItem(string name, string htmlbegin, string htmlend, int endcount, bool useresultashtmlnode)
        {
            this.b_Name = name;
            this.b_HTMLBegin = htmlbegin;
            this.b_HTMLEnd = htmlend;
            this.b_EndCount = endcount;
            this.b_UseResultAsHtmlNode = useresultashtmlnode;
        }

        public BasicHTMLItem(SerializationInfo info, StreamingContext context)
        {
            int version = 1;
            try
            {
                version = info.GetInt32("b_Version");
            }
            catch
            {
                // NOP
            }

            switch (version)
            {
                case 1:
                    b_Name = info.GetString("b_Name");
                    b_HTMLBegin = info.GetString("b_HTMLBegin");
                    b_HTMLEnd = info.GetString("b_HTMLEnd");
                    b_ResultPrefix = info.GetString("b_ResultPrefix");
                    b_EndCount = info.GetInt32("b_EndCount");
                    b_UseResultAsHtmlNode = info.GetBoolean("b_UseResultAsHtmlNode");
                    break;
            }
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                return this.b_Name;
            }
            set
            {
                this.b_Name = value;
            }
        }

        public string HTMLBegin
        {
            get
            {
                return this.b_HTMLBegin;
            }
            set
            {
                this.b_HTMLBegin = value.Trim();
            }
        }

        public string HTMLEnd
        {
            get
            {
                return this.b_HTMLEnd;
            }
            set
            {
                this.b_HTMLEnd = value.Trim();
            }
        }

        public string ResultPrefix
        {
            get
            {
                return this.b_ResultPrefix;
            }
            set
            {
                this.b_ResultPrefix = value;
            }
        }

        public int EndCount
        {
            get
            {
                return this.b_EndCount;
            }
            set
            {
                this.b_EndCount = value;
            }
        }

        public bool UseResultAsHtmlNode
        {
            get
            {
                return this.b_UseResultAsHtmlNode;
            }
            set
            {
                this.b_UseResultAsHtmlNode = value;
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
                // first item in the queue so process the current html document
                if (htmldoc != null)
                    previousResultList.Add(new CrawlerCriteriaItemResult(htmldoc.DocumentNode.OuterHtml, typeof(string)));
                else
                    previousResultList.Add(new CrawlerCriteriaItemResult(criteria.URL, typeof(string)));
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
                    string previousText = "";
                    string executionResult = "";

                    // Current item type (HtmlNode) will always return 1 element, so the list size will always be 1
                    List<CrawlerCriteriaItemResult> currentResultList = new List<CrawlerCriteriaItemResult>();

                    if (previousResultObject != null)
                    {
                        //Cast previous result and get the string result of if
                        //Then pass it to the current pipeline item
                        if (previousResultObject.ResultType == typeof(string))
                            previousText = (string)previousResultObject.Result;
                        else if (previousResultObject.ResultType == typeof(HtmlNode))
                        {
                            HtmlNode tmpObject = (HtmlNode)previousResultObject.Result;

                            previousText = tmpObject.OuterHtml;
                        }
                    }

                    //Process the previous item
                    if (previousText != "")
                    {
                        //if not found return original string
                        executionResult = previousText;

                        try
                        {
                            if (this.b_HTMLBegin != "" && this.b_HTMLEnd != "")
                            {
                                int start = previousText.IndexOf(this.b_HTMLBegin);

                                //can start from the beginning
                                if (start >= 0)
                                {
                                    // we have to search the end from the start of the html
                                    int finish = start;
                                    for (int i = 0; i < this.b_EndCount + 1; i++)
                                        finish = previousText.IndexOf(this.b_HTMLEnd, finish + 1);

                                    if (finish > 0 && finish != start)
                                    {
                                        //We have all we search for, get the text
                                        int k1 = start + this.b_HTMLBegin.Length;
                                        int k2 = finish - k1;

                                        executionResult = previousText.Substring(k1, k2);
                                    }
                                }
                            }
                            else if (this.b_HTMLBegin != "" && this.b_HTMLEnd == "")
                            {
                                int start = previousText.IndexOf(this.b_HTMLBegin);

                                //can start from the beginning
                                if (start >= 0)
                                    executionResult = previousText.Substring(start + this.b_HTMLBegin.Length);
                            }
                            else if (this.b_HTMLBegin == "" && this.b_HTMLEnd != "")
                            {
                                int end = previousText.IndexOf(this.b_HTMLEnd);

                                //can start from the beginning
                                if (end >= 0)
                                    executionResult = previousText.Substring(0, end);
                            }
                        }
                        catch
                        {
                            //NOP
                        }
                    }

                    //Get and convert the result if neccesary
                    if (executionResult != "")
                    {
                        try
                        {
                            if (this.b_UseResultAsHtmlNode)
                            {
                                string currentText = executionResult;
                                currentText = Crexta.Utilities.Utilities.OptimizeLineBreaksForHtml(currentText);
                                HtmlNode node = HtmlNode.CreateNode(currentText);

                                try
                                {
                                    currentResultList.Add(new CrawlerCriteriaItemResult(node.OwnerDocument.DocumentNode, typeof(HtmlNode)));
                                }
                                catch
                                {
                                    //NOP
                                }
                            }
                            else
                            {
                                //Add prefix
                                if (this.b_ResultPrefix != "")
                                    executionResult = this.b_ResultPrefix + executionResult;

                                currentResultList.Add(new CrawlerCriteriaItemResult(executionResult, typeof(string)));
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
            catch(Exception)
            {
                // Log it
            }
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("b_Version", b_Version);

            info.AddValue("b_Name", b_Name);
            info.AddValue("b_HTMLBegin", b_HTMLBegin);
            info.AddValue("b_HTMLEnd", b_HTMLEnd);
            info.AddValue("b_ResultPrefix", b_ResultPrefix);
            info.AddValue("b_EndCount", b_EndCount);
            info.AddValue("b_UseResultAsHtmlNode", b_UseResultAsHtmlNode);
        }

        #endregion
    }
}
