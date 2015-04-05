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
using System.Runtime.Serialization;

namespace Crexta.Common.Crawler
{
    [Serializable]
    public class CrawlerCriteriaDBInfo : ISerializable
    {
        #region Variable Definitions

        private string c_Name = "";
        private string c_Value = "";

        private readonly bool c_AutoQuote = true;

        private int c_Length = -1;
        private readonly int c_Version = 1;

        private Type c_Type = null;

        #endregion

        #region Contructor Logic

        /// <summary>
        /// Create a new DBField object
        /// </summary>
        public CrawlerCriteriaDBInfo()
        {
        }

        public CrawlerCriteriaDBInfo(SerializationInfo info, StreamingContext context)
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
                    c_AutoQuote = info.GetBoolean("c_AutoQuote");
                    c_Length = info.GetInt32("c_Length");
                    c_Type = (Type)info.GetValue("c_Type", typeof(Type));
                    c_Value = info.GetString("c_Value");
                    break;
            }
        }

        /// <summary>
        /// Create a new DBField object
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="value">This field is not used for now</param>
        /// <param name="type">DBField type (int, string[varchar] etc.)</param>
        /// <param name="length">Database field length</param>
        public CrawlerCriteriaDBInfo(string name, string value, bool autoquote, Type type, int length)
        {
            this.c_AutoQuote = autoquote;

            if (!string.IsNullOrEmpty(name))
            {
                if (this.c_AutoQuote)
                    this.c_Name = this.QuoteText(name);
                else
                    this.c_Name = name;
            }

            this.c_Value = value;
            this.c_Type = type;
            this.c_Length = length;
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
                if (!string.IsNullOrEmpty(value))
                {
                    if (this.c_AutoQuote)
                        this.c_Name = this.QuoteText(value);
                    else
                        this.c_Name = value;
                }
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

        public int Length
        {
            get
            {
                return this.c_Length;
            }
            set
            {
                this.c_Length = value;
            }
        }

        public Type Type
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

        #region Private Methods

        private string QuoteText(string text)
        {
            string res = text;

            if (!string.IsNullOrEmpty(text))
            {
                if (!text.StartsWith("["))
                    res = "[" + res;

                if (!text.EndsWith("]"))
                    res = res + "]";
            }

            return res;
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_Name", c_Name);
            info.AddValue("c_AutoQuote", c_AutoQuote);
            info.AddValue("c_Length", c_Length);
            info.AddValue("c_Type", c_Type, typeof(Type));
            info.AddValue("c_Value", c_Value);
        }

        #endregion
    }
}
