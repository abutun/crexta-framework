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
    public class RegularExpressionItem : ICrawlerCriteriaItem
    {
        #region Variable Definitions

        private readonly int r_Version = 1;

        private string r_Name = "";
        private string r_Pattern = "";
        private string r_ResultPrefix = "";

        private bool r_UseGroupIndex = false;
        private bool r_UseResultAsHtmlNode = false;
        private bool r_ReturnAllMatches = false;
        private bool r_OverrideRulePattern = false;

        private RegexOptions r_Options = RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase;

        private int r_GroupIndex = -1;
        private int r_ResultIndex = 0;

        #endregion

        #region Constructor Logic

        public RegularExpressionItem()
            : this("Regular Expression Item", "", 0, false, -1, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, false, false)
        {
        }

        public RegularExpressionItem(string name, string pattern, int resultindex, RegexOptions options)
            : this(name, pattern, resultindex, false, -1, options, false, false)
        {
        }

        public RegularExpressionItem(string name, string pattern, int resultindex)
            : this(name, pattern, resultindex, false, -1, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, false, false)
        {
        }

        public RegularExpressionItem(string name, string pattern, int resultindex, bool usegroup, int groupindex)
            : this(name, pattern, resultindex, usegroup, groupindex, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase, false, false)
        {
        }

        public RegularExpressionItem(string name, string pattern, int resultindex, bool usegroup, int groupindex, RegexOptions options)
            : this(name, pattern, resultindex, usegroup, groupindex, options, false, false)
        {
        }

        public RegularExpressionItem(string name, string pattern, int resultindex, bool usegroup, int groupindex, RegexOptions options, bool useresultashtmlnode, bool returnallmatches)
        {
            this.r_Name = name;
            this.r_Pattern = pattern;
            this.r_UseGroupIndex = usegroup;
            this.r_GroupIndex = groupindex;
            this.r_Options = options;
            this.r_UseResultAsHtmlNode = useresultashtmlnode;
            this.r_ReturnAllMatches = returnallmatches;
            this.r_ResultIndex = resultindex;
        }

        public RegularExpressionItem(SerializationInfo info, StreamingContext context)
        {
            int version = 1;
            try
            {
                version = info.GetInt32("r_Version");
            }
            catch
            {
                // NOP
            }

            switch (version)
            {
                case 1:
                    r_Name = info.GetString("r_Name");
                    r_Pattern = info.GetString("r_Pattern");
                    r_ResultPrefix = info.GetString("r_ResultPrefix");
                    r_UseGroupIndex = info.GetBoolean("r_UseGroupIndex");
                    r_UseResultAsHtmlNode = info.GetBoolean("r_UseResultAsHtmlNode");
                    r_OverrideRulePattern = info.GetBoolean("r_OverrideRulePattern");
                    r_ReturnAllMatches = info.GetBoolean("r_ReturnAllMatches");
                    r_Options = (RegexOptions)info.GetValue("r_Options", typeof(RegexOptions));
                    r_GroupIndex = info.GetInt32("r_GroupIndex");
                    r_ResultIndex = info.GetInt32("r_ResultIndex");
                    break;
            }
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                return this.r_Name;
            }
            set
            {
                this.r_Name = value;
            }
        }

        public string Pattern
        {
            get
            {
                return this.r_Pattern;
            }
            set
            {
                this.r_Pattern = value;
            }
        }

        public string ResultPrefix
        {
            get
            {
                return this.r_ResultPrefix;
            }
            set
            {
                this.r_ResultPrefix = value;
            }
        }

        public bool UseGroupIndex
        {
            get
            {
                return this.r_UseGroupIndex;
            }
            set
            {
                this.r_UseGroupIndex = value;
            }
        }

        public bool OverrideRulePattern
        {
            get
            {
                return this.r_OverrideRulePattern;
            }
            set
            {
                this.r_OverrideRulePattern = value;
            }
        }

        public RegexOptions Options
        {
            get
            {
                return this.r_Options;
            }
            set
            {
                this.r_Options = value;
            }
        }

        public int GroupIndex
        {
            get
            {
                return this.r_GroupIndex;
            }
            set
            {
                this.r_GroupIndex = value;
            }
        }

        public int ResultIndex
        {
            get
            {
                return this.r_ResultIndex;
            }
            set
            {
                this.r_ResultIndex = value;
            }
        }

        public bool UseResultAsHtmlNode
        {
            get
            {
                return this.r_UseResultAsHtmlNode;
            }
            set
            {
                this.r_UseResultAsHtmlNode = value;
            }
        }

        public bool ReturnAllMaches
        {
            get
            {
                return this.r_ReturnAllMatches;
            }
            set
            {
                this.r_ReturnAllMatches = value;
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
                        MatchCollection matches = Regex.Matches(previousText, this.r_Pattern, this.r_Options);

                        if (matches != null)
                        {
                            if (!this.r_ReturnAllMatches)
                            {
                                if (matches.Count > this.r_ResultIndex)
                                {
                                    if (this.r_UseGroupIndex)
                                    {
                                        if (matches[this.r_ResultIndex].Groups.Count > 0 && matches[this.r_ResultIndex].Groups.Count > this.r_GroupIndex)
                                            executionResult = matches[this.r_ResultIndex].Groups[this.r_GroupIndex].Value;
                                    }
                                    else
                                        executionResult = matches[this.r_ResultIndex].Value;
                                }
                            }

                            // go on processing
                            if (executionResult != "" || this.r_ReturnAllMatches)
                            {
                                try
                                {
                                    if (this.r_ReturnAllMatches)
                                    {
                                        // return all matches (simply add all matches to to current result list)
                                        foreach (Match m in matches)
                                            currentResultList.Add(new CrawlerCriteriaItemResult(m.Value, typeof(string)));
                                    }
                                    else
                                    {
                                        if (this.r_UseResultAsHtmlNode)
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
                                            if (this.r_ResultPrefix != "")
                                                executionResult = this.r_ResultPrefix + executionResult;

                                            currentResultList.Add(new CrawlerCriteriaItemResult(executionResult, typeof(string)));
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
                }
            }
            catch
            {
                // Log it
            }
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("r_Version", r_Version);

            info.AddValue("r_Name", r_Name);
            info.AddValue("r_Pattern", r_Pattern);
            info.AddValue("r_ResultPrefix", r_ResultPrefix);
            info.AddValue("r_UseGroupIndex", r_UseGroupIndex);
            info.AddValue("r_UseResultAsHtmlNode", r_UseResultAsHtmlNode);
            info.AddValue("r_OverrideRulePattern", r_OverrideRulePattern);
            info.AddValue("r_ReturnAllMatches", r_ReturnAllMatches);
            info.AddValue("r_Options", r_Options, typeof(RegexOptions));
            info.AddValue("r_GroupIndex", r_GroupIndex);
            info.AddValue("r_ResultIndex", r_ResultIndex);
        }

        #endregion
    }
}
