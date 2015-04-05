/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	ABBSOLUTIONS INC. - Turkcrawler Framework			                *
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
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;

using HtmlAgilityPack;
using Crexta.Common.Crawler.Interfaces;
using Crexta.Common.Crawler.CriteriaItems;
using Crexta.Common.Crawler.Enums;

namespace Crexta.Common.Crawler
{
    [Serializable]
    public class CrawlerCriteria : ICrawlerCriteria
    {
        #region Variable Definitions

        private string c_Name = "Sample Criteria";
        private string c_XFieldI = "";
        private string c_XFieldII = "";
        private string c_XFieldIII = "";
        private string c_ColumnName = "";
        private String c_ColumnType = "";
        private string c_InnerErrorText = "OK";
        private string c_URL = "";
        private string c_DefaultText = "";

        private readonly List<String> c_Text = new List<string>();
        private readonly List<String> c_HTML = new List<string>();

        private int c_InnerErrorCode = 0;
        private int c_ColumnLength = 0;
        private readonly int c_Version = 1;

        private bool c_InnerError = false;
        private bool c_UpperCaseValues = false;
        private bool c_LowerCaseValues = false;
        private bool c_DefaultTextCaseValues = true;
        private bool c_StripASCIICodes = true;
        private bool c_ClearHTMLTags = false;
        private bool c_ClearWhiteSpaces = false;
        private bool c_ClearHTMLComments = false;
        private bool c_ClearScriptTags = false;
        private bool c_UseURLForMatch = true;

        private readonly List<List<CrawlerCriteriaItemResult>> c_ExecutionPipelineResults = new List<List<CrawlerCriteriaItemResult>>();

        private CrawlerCriteriaItemCollection c_ExecutionPipelineItems = new CrawlerCriteriaItemCollection();

        private CrawlerExcludeListCollection c_ExcludeList = new CrawlerExcludeListCollection();

        #endregion

        #region Constructor Logic

        /// <summary>
        /// Create a new crawler rule criteria
        /// </summary>
        public CrawlerCriteria()
        {
            this.c_InnerError = false;

            this.c_InnerErrorCode = 0;

            this.c_StripASCIICodes = true;
        }

        public CrawlerCriteria(SerializationInfo info, StreamingContext context)
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
                    c_XFieldI = info.GetString("c_XFieldI");
                    c_XFieldII = info.GetString("c_XFieldII");
                    c_XFieldIII = info.GetString("c_XFieldIII");
                    c_ColumnName = info.GetString("c_ColumnName");
                    c_URL = info.GetString("c_URL");
                    c_DefaultText = info.GetString("c_DefaultText");
                    c_ColumnType = info.GetString("c_ColumnType");
                    c_ColumnLength = info.GetInt32("c_ColumnLength");
                    c_UpperCaseValues = info.GetBoolean("c_UpperCaseValues");
                    c_LowerCaseValues = info.GetBoolean("c_LowerCaseValues");
                    c_DefaultTextCaseValues = info.GetBoolean("c_DefaultTextCaseValues");
                    c_StripASCIICodes = info.GetBoolean("c_StripASCIICodes");
                    c_ClearHTMLTags = info.GetBoolean("c_ClearHTMLTags");
                    c_ClearWhiteSpaces = info.GetBoolean("c_ClearWhiteSpaces");
                    c_ClearHTMLComments = info.GetBoolean("c_ClearHTMLComments");
                    c_ClearScriptTags = info.GetBoolean("c_ClearScriptTags");
                    c_UseURLForMatch = info.GetBoolean("c_UseURLForMatch");
                    c_ExecutionPipelineItems = (CrawlerCriteriaItemCollection)info.GetValue("c_ExecutionPipelineItems", typeof(CrawlerCriteriaItemCollection));
                    c_ExcludeList = (CrawlerExcludeListCollection)info.GetValue("c_ExcludeList", typeof(CrawlerExcludeListCollection));
                    break;
            }
        }

        #endregion

        #region Public Properties

        public bool DefaultTextCaseValues
        {
            get
            {
                return this.c_DefaultTextCaseValues;
            }
            set
            {
                this.c_DefaultTextCaseValues = value;
            }
        }

        public bool UpperCaseValues
        {
            get
            {
                return this.c_UpperCaseValues;
            }
            set
            {
                this.c_UpperCaseValues = value;
            }
        }

        public bool LowerCaseValues
        {
            get
            {
                return this.c_LowerCaseValues;
            }
            set
            {
                this.c_LowerCaseValues = value;
            }
        }

        public bool UseURLForMatch
        {
            get
            {
                return this.c_UseURLForMatch;
            }
            set
            {
                this.c_UseURLForMatch = value;
            }
        }

        public bool ClearHTMLTags
        {
            get
            {
                return this.c_ClearHTMLTags;
            }
            set
            {
                this.c_ClearHTMLTags = value;
            }
        }

        public bool ClearScriptTags
        {
            get
            {
                return this.c_ClearScriptTags;
            }
            set
            {
                this.c_ClearScriptTags = value;
            }
        }

        public bool ClearWhiteSpaces
        {
            get
            {
                return this.c_ClearWhiteSpaces;
            }
            set
            {
                this.c_ClearWhiteSpaces = value;
            }
        }

        public bool ClearHTMLComments
        {
            get
            {
                return this.c_ClearHTMLComments;
            }
            set
            {
                this.c_ClearHTMLComments = value;
            }
        }

        public bool StripASCIICodes
        {
            get
            {
                return this.c_StripASCIICodes;
            }
            set
            {
                this.c_StripASCIICodes = value;
            }
        }

        public bool InnerError
        {
            get
            {
                return this.c_InnerError;
            }
        }

        public string InnerErrorText
        {
            get
            {
                switch (this.c_InnerErrorCode)
                {
                    case -1: this.c_InnerErrorText = "Unknown command type!";
                        break;

                    case -2: this.c_InnerErrorText = "HtmlNode and HtmlNodeCollection cannot be used with URLs!";
                        break;

                    default:
                        break;
                }

                return this.c_InnerErrorText;
            }
        }

        public int InnerErrorCode
        {
            get
            {
                return c_InnerErrorCode;
            }
        }

        public string Text2Xml
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (this.c_Text != null)
                {
                    if (this.c_Text.Count > 0)
                    {
                        foreach(string result in this.c_Text)
                        {
                            sb.Append("<item default=\"0\"><![CDATA[");

                            string tmp = "";
                            if (this.c_StripASCIICodes)
                            {
                                if (this.c_UpperCaseValues)
                                    tmp = Crexta.Utilities.Utilities.SafeReplaceHtmlCodes(result).ToUpperInvariant();
                                else if (this.c_LowerCaseValues)
                                    tmp = Crexta.Utilities.Utilities.SafeReplaceHtmlCodes(result).ToLowerInvariant();
                                else
                                    return Crexta.Utilities.Utilities.SafeReplaceHtmlCodes(result);
                            }
                            else
                            {
                                if (this.c_UpperCaseValues)
                                    tmp = result.ToUpperInvariant();
                                else if (this.c_LowerCaseValues)
                                    tmp = result.ToLowerInvariant();
                                else
                                    tmp = result;
                            }
                            sb.Append(tmp);

                            sb.Append("]]></item>");
                        }

                        return sb.ToString();
                    }
                }

                //add default value
                sb.Append("<item default=\"1\"><![CDATA[");
                sb.Append(this.c_DefaultText);
                sb.Append("]]></item>");

                // return default value
                return sb.ToString();
            }
        }

        #endregion

        #region ICrawlerCriteria Members

        public void Match(HtmlDocument htmldocument)
        {
            string tmpResult = "";

            // Enumerate criteria items in order
            for (int i = 0; i < this.c_ExecutionPipelineItems.Count; i++)
            {
                ICrawlerCriteriaItem item = this.ExecutionPipelineItems[i];

                // Process current item and get information about Execute parameters

                // Execute the current item and crextor the result
                if (this.UseURLForMatch)
                {
                    // Only BasicHTML and Regex can be used with URL Sources
                    if ((item.GetType() == typeof(BasicHTMLItem)) || (item.GetType() == typeof(RegularExpressionItem)))
                        item.Execute(null, this, i);
                    else
                    {
                        this.c_InnerError = true;

                        this.c_InnerErrorCode = -2;
                    }
                }
                else
                    item.Execute(htmldocument, this, i);
            }

            // Get results
            List<CrawlerCriteriaItemResult> lastResultObjects = this.c_ExecutionPipelineResults[this.c_ExecutionPipelineResults.Count - 1];

            if (lastResultObjects != null)
            {
                foreach (CrawlerCriteriaItemResult result in lastResultObjects)
                {
                    if (result.ResultType == typeof(string))
                        tmpResult = (string)result.Result;
                    else if (result.ResultType == typeof(HtmlNode))
                    {
                        HtmlNode tmpObject = (HtmlNode)result.Result;

                        tmpResult = Crexta.Utilities.Utilities.StripHTML(tmpObject.InnerHtml);
                    }

                    // Process excludes
                    foreach (CrawlerExcludeList list in this.c_ExcludeList)
                    {
                        // Process current exclude list on current item
                        if (list.Value != "")
                        {
                            if (list.Type == CrawlerExcludeListType.Regex)
                            {
                                Regex tmpRegex = new Regex(list.Value);

                                tmpResult = tmpRegex.Replace(tmpResult, string.Empty);
                            }
                            else
                                tmpResult = tmpResult.Replace(list.Value, string.Empty);
                        }
                    }

                    // Clear HTML Tags
                    if (this.c_ClearHTMLTags)
                    {
                        //tmpResult = Regex.Replace(tmpResult, @"<(.|\n)*?>", string.Empty);
                        tmpResult = Regex.Replace(tmpResult, @"<[^>]*>", String.Empty);
                    }

                    // Clear HTML Comments
                    if (this.c_ClearHTMLComments)
                    {
                        // This may not be needed since we can remove all HTML tags (see c_ClearHTMLTags)
                    }

                    // Clear Script Tags
                    if (this.c_ClearScriptTags)
                    {
                        tmpResult = Regex.Replace(tmpResult, @"<script.*?>[\s\S]*?</.*?script>", string.Empty);
                    }

                    // Clear Whitespaces
                    if (this.c_ClearWhiteSpaces)
                    {
                        tmpResult = Regex.Replace(tmpResult, @"\s", String.Empty);
                    }

                    // Replace \r with <br/>
                    tmpResult = Regex.Replace(tmpResult, @"\r", "<br/>");

                    // Replace multiple <br/> tags with one <br/> tag
                    tmpResult = Regex.Replace(tmpResult, @"(<br\s*\/?>\s*)+", "<br/>");

                    // Clear <br/> tags from the beginning of the result 
                    tmpResult = Regex.Replace(tmpResult, @"^(<br\s*\/?>\s*)+", String.Empty);

                    // Clear <br/> tags from the end of the result
                    tmpResult = Regex.Replace(tmpResult, @"(<br\s*\/?>\s*)+$", String.Empty);

                    this.c_Text.Add(tmpResult);
                }
            }

            // !!! Remove all pipeline results !!!
            // THIS IS IMPORTANT
            foreach (List<CrawlerCriteriaItemResult> list in this.ExecutionPipelineResults)
                list.Clear();
        }

        public string URL
        {
            get { return this.c_URL; }
            set { this.c_URL = value; }
        }

        public string Name
        {
            get { return this.c_Name ; }
            set { this.c_Name = value; }
        }

        public string XFieldI
        {
            get { return this.c_XFieldI; }
            set { this.c_XFieldI = value; }
        }

        public string XFieldII
        {
            get { return this.c_XFieldII; }
            set { this.c_XFieldII = value; }
        }

        public string XFieldIII
        {
            get { return this.c_XFieldIII; }
            set { this.c_XFieldIII = value; }
        }

        public List<string> Text
        {
            get
            {
                return c_Text;
            }
        }

        public List<string> HTML
        {
            get
            {
                return c_HTML;
            }
        }

        public List<List<CrawlerCriteriaItemResult>> ExecutionPipelineResults
        {
            get
            {
                return this.c_ExecutionPipelineResults;
            }
        }

        public CrawlerCriteriaItemCollection ExecutionPipelineItems
        {
            get
            {
                return this.c_ExecutionPipelineItems;
            }
            set
            {
                this.c_ExecutionPipelineItems = value;
            }
        }

        public string ColumnName
        {
            get
            {
                return this.c_ColumnName;
            }
            set
            {
                this.c_ColumnName = value;
            }
        }

        public int ColumnLength
        {
            get
            {
                return this.c_ColumnLength;
            }
            set
            {
                this.c_ColumnLength = value;
            }
        }

        public string DefaultText
        {
            get
            {
                return this.c_DefaultText;
            }
            set
            {
                this.c_DefaultText = value;
            }
        }

        public String ColumnType
        {
            get
            {
                return this.c_ColumnType;
            }
            set
            {
                if (value != null)
                    this.c_ColumnType = value;
            }
        }

        public CrawlerExcludeListCollection ExcludeList
        {
            get
            {
                return this.c_ExcludeList;
            }
            set
            {
                this.c_ExcludeList = value;
            }
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_Name", c_Name);
            info.AddValue("c_XFieldI", c_XFieldI);
            info.AddValue("c_XFieldII", c_XFieldII);
            info.AddValue("c_XFieldIII", c_XFieldIII);
            info.AddValue("c_ColumnName", c_ColumnName);
            info.AddValue("c_URL", c_URL);
            info.AddValue("c_DefaultText", c_DefaultText);
            info.AddValue("c_ColumnType", c_ColumnType);
            info.AddValue("c_ColumnLength", c_ColumnLength);
            info.AddValue("c_DefaultTextCaseValues", c_DefaultTextCaseValues);
            info.AddValue("c_UpperCaseValues", c_UpperCaseValues);
            info.AddValue("c_LowerCaseValues", c_LowerCaseValues);
            info.AddValue("c_StripASCIICodes", c_StripASCIICodes);
            info.AddValue("c_ClearHTMLTags", c_ClearHTMLTags);
            info.AddValue("c_ClearWhiteSpaces", c_ClearWhiteSpaces);
            info.AddValue("c_ClearHTMLComments", c_ClearHTMLComments);
            info.AddValue("c_ClearScriptTags", c_ClearScriptTags);
            info.AddValue("c_UseURLForMatch", c_UseURLForMatch);
            info.AddValue("c_ExecutionPipelineItems", c_ExecutionPipelineItems, typeof(CrawlerCriteriaItemCollection));
            info.AddValue("c_ExcludeList", c_ExcludeList, typeof(CrawlerExcludeListCollection));
        }

        #endregion
    }
}
