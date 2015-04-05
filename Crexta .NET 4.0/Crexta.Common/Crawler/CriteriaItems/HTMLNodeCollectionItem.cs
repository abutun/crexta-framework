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
    public class HTMLNodeCollectionItem : ICrawlerCriteriaItem
    {
        #region Variable Definitions
        
        private readonly int h_Version = 1;

        private string h_Name = "";
        private string h_Xpath = "";

        private int h_ResultNodeIndex = 0;

        private bool h_ReturnOnlyNodeText = false;
        private bool h_ReturnAllNodes = false;

        #endregion

        #region Constructor Logic

        public HTMLNodeCollectionItem() 
            : this("HTMLNode Collection Item", "", 0, false)
        {
        }

        public HTMLNodeCollectionItem(string name, string xpath)
            : this(name, xpath, 0, false)
        {
        }

        public HTMLNodeCollectionItem(string name, string xpath, int resultnodeindex)
            : this(name, xpath, resultnodeindex, false)
        {
        }

        public HTMLNodeCollectionItem(string name, string xpath, int resultnodeindex, bool returnonlynodetext)
            : this(name, xpath, resultnodeindex, returnonlynodetext, false)
        {
        }

        public HTMLNodeCollectionItem(string name, string xpath, int resultnodeindex, bool returnonlynodetext, bool returnallnodes)
        {
            this.h_Name = name;
            this.h_Xpath = xpath;
            this.h_ResultNodeIndex = resultnodeindex;
            this.h_ReturnOnlyNodeText = returnonlynodetext;
            this.h_ReturnAllNodes = returnallnodes;
        }

        public HTMLNodeCollectionItem(SerializationInfo info, StreamingContext context)
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
                    h_ResultNodeIndex = info.GetInt32("h_ResultNodeIndex");
                    h_ReturnOnlyNodeText = info.GetBoolean("h_ReturnOnlyNodeText");
                    h_ReturnAllNodes = info.GetBoolean("h_ReturnAllNodes");
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

        public int ResultNodeIndex
        {
            get
            {
                return this.h_ResultNodeIndex;
            }
            set
            {
                this.h_ResultNodeIndex = value;
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

        public bool ReturnAllNodes
        {
            get
            {
                return this.h_ReturnAllNodes;
            }
            set
            {
                this.h_ReturnAllNodes = value;
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
                    HtmlNodeCollection executionResult = null;
                    HtmlNode previousResult = null;
                    List<CrawlerCriteriaItemResult> currentResultList = new List<CrawlerCriteriaItemResult>();

                    if (previousResultObject != null)
                        previousResult = (HtmlNode)previousResultObject.Result;

                    //Process the previous item
                    if (previousResult != null)
                        executionResult = previousResult.SelectNodes(this.h_Xpath);

                    //Get and convert the result if neccesary
                    if (executionResult != null)
                    {
                        try
                        {
                            if (this.h_ReturnAllNodes)
                            {
                                // return all nodes (simply add all nodes to to current result list)
                                foreach (HtmlNode node in executionResult)
                                    currentResultList.Add(new CrawlerCriteriaItemResult(node, typeof(HtmlNodeCollection)));
                            }
                            else
                            {
                                // return only one single node
                                if (executionResult.Count > this.h_ResultNodeIndex)
                                {
                                    if (!this.h_ReturnOnlyNodeText)
                                        currentResultList.Add(new CrawlerCriteriaItemResult(executionResult[this.h_ResultNodeIndex], typeof(HtmlNode)));
                                    else
                                    {
                                        string currentText = Crexta.Utilities.Utilities.StripHTML(executionResult[this.h_ResultNodeIndex].InnerHtml);
                                        currentText = Crexta.Utilities.Utilities.OptimizeLineBreaksForHtml(currentText);
                                        currentResultList.Add(new CrawlerCriteriaItemResult(currentText, typeof(string)));
                                    }
                                }
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
            info.AddValue("h_ResultNodeIndex", h_ResultNodeIndex);
            info.AddValue("h_ReturnOnlyNodeText", h_ReturnOnlyNodeText);
            info.AddValue("h_ReturnAllNodes", h_ReturnAllNodes);
        }

        #endregion
    }
}
