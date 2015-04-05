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
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

using Crexta.Common.Crawler.CriteriaItems;

namespace Crexta.Common.Crawler
{
    [Serializable]
    public class CrawlerRuleBase : ISerializable
    {
        #region Variable Definitions

        private string c_Name = "";
        private string c_URLMatchRegex = "";        

        private string c_ConnectionString = "";
        private string c_InnerSQLCommandText = "";
        private string c_InnerSQLCommandType = "INSERT";
        private string c_DatabaseTableName = "";
        private string c_InnerErrorText = "OK";

        private Encoding c_Encoding = System.Text.Encoding.UTF8;

        private int c_InnerErrorCode = 0;
        private readonly int c_Version = 2;

        private bool c_InnerError = false;

        private ClickItem c_ClickItem = null;

        private CrawlerCriteriaCollection c_Criterias = new CrawlerCriteriaCollection();

        private readonly DateTime c_CreateDate = DateTime.Now;
        private readonly DateTime c_LastUpdate = DateTime.Now;

        #endregion

        #region Constructor Logic

        /// <summary>
        /// Create a new crawlerrulebase object
        /// </summary>
        public CrawlerRuleBase()
        {
        }

        /// <summary>
        /// Create a new crawlerrulebase object
        /// </summary>
        /// <param name="filepath">Rule rootpath</param>
        public CrawlerRuleBase(string name)
        {
            this.c_Name = name;

            this.c_CreateDate = DateTime.Now;
            this.c_LastUpdate = DateTime.Now;
        }

        /// <summary>
        /// Create a new crawlerrulebase object
        /// </summary>
        /// <param name="name">Rule name</param>
        /// <param name="urlregex">Rule URL regex. This field is used for matching URLs with the current rule</param>
        /// <param name="criterias">Rule criteria collection</param>
        public CrawlerRuleBase(string name, string urlregex, CrawlerCriteriaCollection criterias)
        {
            this.c_Name = name;
            this.c_URLMatchRegex = urlregex;
            this.c_Criterias = criterias;

            this.c_CreateDate = DateTime.Now;
            this.c_LastUpdate = DateTime.Now;
        }

        public CrawlerRuleBase(SerializationInfo info, StreamingContext context)
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
                    c_URLMatchRegex = info.GetString("c_URLMatchRegex");
                    c_ConnectionString = info.GetString("c_ConnectionString");
                    c_InnerSQLCommandText = info.GetString("c_InnerSQLCommandText");
                    c_DatabaseTableName = info.GetString("c_DatabaseTableName");
                    c_InnerErrorText = info.GetString("c_InnerErrorText");
                    c_InnerErrorCode = info.GetInt32("c_InnerErrorCode");
                    c_InnerError = info.GetBoolean("c_InnerError");
                    c_Criterias = (CrawlerCriteriaCollection)info.GetValue("c_Criterias", typeof(CrawlerCriteriaCollection));
                    c_CreateDate = info.GetDateTime("c_CreateDate");
                    c_LastUpdate = info.GetDateTime("c_LastUpdate");
                    c_ClickItem = (ClickItem)info.GetValue("c_ClickItem", typeof(ClickItem));
                    break;

                case 2:
                    c_Name = info.GetString("c_Name");
                    c_URLMatchRegex = info.GetString("c_URLMatchRegex");
                    c_ConnectionString = info.GetString("c_ConnectionString");
                    c_InnerSQLCommandText = info.GetString("c_InnerSQLCommandText");
                    c_DatabaseTableName = info.GetString("c_DatabaseTableName");
                    c_Encoding = (Encoding)info.GetValue("c_Encoding", typeof(Encoding)); /* NEW */
                    c_InnerErrorText = info.GetString("c_InnerErrorText");
                    c_InnerErrorCode = info.GetInt32("c_InnerErrorCode");
                    c_InnerError = info.GetBoolean("c_InnerError");
                    c_Criterias = (CrawlerCriteriaCollection)info.GetValue("c_Criterias", typeof(CrawlerCriteriaCollection));
                    c_CreateDate = info.GetDateTime("c_CreateDate");
                    c_LastUpdate = info.GetDateTime("c_LastUpdate");
                    c_ClickItem = (ClickItem)info.GetValue("c_ClickItem", typeof(ClickItem));
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

        public string URLMatchRegex
        {
            get
            {
                return this.c_URLMatchRegex;
            }
            set
            {
                this.c_URLMatchRegex = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.c_ConnectionString;
            }
            set
            {
                this.c_ConnectionString = value;
            }
        }

        public string CommandText
        {
            get
            {
                return this.c_InnerSQLCommandText;
            }
            set
            {
                this.c_InnerSQLCommandText = value;
            }
        }

        public string CommandType
        {
            get
            {
                return this.c_InnerSQLCommandType;
            }
            set
            {
                this.c_InnerSQLCommandType = value;
            }
        }

        public Encoding Encoding
        {
            get
            {
                return this.c_Encoding;
            }
            set
            {
                this.c_Encoding = value;
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
                    case -1 : this.c_InnerErrorText = "Unknown command type!";
                        break;

                    default :
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

        public string DatabaseTableName
        {
            get
            {
                return this.c_DatabaseTableName;
            }
            set
            {
                this.c_DatabaseTableName = value;
            }
        }

        public CrawlerCriteriaCollection Criterias
        {
            get
            {
                return this.c_Criterias;
            }
            set
            {
                this.c_Criterias = value;
            }
        }

        public ClickItem ClickItem
        {
            get
            {
                return this.c_ClickItem;
            }
            set
            {
                this.c_ClickItem = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this.c_CreateDate;
            }
        }

        public DateTime LastUpdate
        {
            get
            {
                return this.c_LastUpdate;
            }
        }

        #endregion

        #region Public Methods

        public XmlDocument GetXMLDocument()
        {
            XmlDocument result = new XmlDocument();

            return result;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Processes the current rule
        /// </summary>
        protected virtual void Process()
        {
            //enumerate all criterias and insert/update db if neccesary

            //Contruct SQL Command Text
            if (this.CommandType == "INSERT")
            {
            }
            else if (this.CommandType == "UPDATE")
            {
            }
            else
            {
                this.c_InnerError = true;

                this.c_InnerErrorCode = -1;
            }

            //Execute SQL Command
            if (!this.InnerError)
            {
            }
        }

        /// <summary>
        /// Clears the custom property values of the rule
        /// </summary>
        protected virtual void Clear()
        {
            //clear custom property values
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_Name", c_Name);
            info.AddValue("c_URLMatchRegex", c_URLMatchRegex);
            info.AddValue("c_ConnectionString", c_ConnectionString);
            info.AddValue("c_InnerSQLCommandText", c_InnerSQLCommandText);
            info.AddValue("c_DatabaseTableName", c_DatabaseTableName);
            info.AddValue("c_Encoding", c_Encoding, typeof(Encoding));
            info.AddValue("c_InnerErrorText", c_InnerErrorText);
            info.AddValue("c_InnerErrorCode", c_InnerErrorCode);
            info.AddValue("c_InnerError", c_InnerError);
            info.AddValue("c_Criterias", c_Criterias, typeof(CrawlerCriteriaCollection));
            info.AddValue("c_CreateDate", c_CreateDate);
            info.AddValue("c_LastUpdate", c_LastUpdate);
            info.AddValue("c_ClickItem", c_ClickItem, typeof(ClickItem));
        }

        #endregion
    }
}
