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
using Crexta.Common.Crawler.Enums;
using System.Runtime.Serialization;

namespace Crexta.Common.Crawler
{
    [Serializable]
    public class CrawlerExcludeList : ISerializable
    {
        #region Variable Definitions

        private string c_Name = "";
        private string c_Value = "";
        private string c_ReplaceWith = "";

        private readonly int c_Version = 1;

        private bool c_ExcludeAll = false;

        private CrawlerExcludeListType c_Type = CrawlerExcludeListType.Text;

        #endregion

        #region Constructor Logic

        /// <summary>
        /// Create a new exclude list object
        /// </summary>
        public CrawlerExcludeList()
        {
        }

        public CrawlerExcludeList(SerializationInfo info, StreamingContext context)
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
                    c_ExcludeAll = info.GetBoolean("c_ExcludeAll");
                    c_Name = info.GetString("c_Name");
                    c_ReplaceWith = info.GetString("c_ReplaceWith");
                    c_Type = (CrawlerExcludeListType)info.GetValue("c_Type", typeof(CrawlerExcludeListType));
                    c_Value = info.GetString("c_Value");
                    break;
            }
        }

        /// <summary>
        /// Create a new exclude list object
        /// </summary>
        /// <param name="name">Exclude list name</param>
        /// <param name="value">List value</param>
        /// <param name="type">List type (regex, text)</param>
        public CrawlerExcludeList(string name, string value, string replacewith, CrawlerExcludeListType type)
        {
            this.c_Name = name;
            this.c_Value = value;
            this.c_ReplaceWith = replacewith;
            this.c_Type = type;
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

        public string Value
        {
            get
            {
                return this.c_Value;
            }
            set
            {
                this.c_Value = value;
            }
        }

        public string ReplaceWith
        {
            get
            {
                return this.c_ReplaceWith;
            }
            set
            {
                this.c_ReplaceWith = value;
            }
        }

        public bool ExcludeAll
        {
            get
            {
                return this.c_ExcludeAll;
            }
            set
            {
                this.c_ExcludeAll = value;
            }
        }

        public CrawlerExcludeListType Type
        {
            get
            {
                return this.c_Type;
            }
            set
            {
                this.c_Type = value;
            }
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_ExcludeAll", c_ExcludeAll);
            info.AddValue("c_Name", c_Name);
            info.AddValue("c_ReplaceWith", c_ReplaceWith);
            info.AddValue("c_Type", c_Type, typeof(CrawlerExcludeListType));
            info.AddValue("c_Value", c_Value);
        }

        #endregion
    }
}
