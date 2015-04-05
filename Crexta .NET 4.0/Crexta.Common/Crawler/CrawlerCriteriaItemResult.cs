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
    public class CrawlerCriteriaItemResult : ISerializable
    {
        private object c_ResultObject = null;
        private Type c_ResultType = null;

        private readonly int c_Version = 1;

        public CrawlerCriteriaItemResult()
        {
        }

        public CrawlerCriteriaItemResult(SerializationInfo info, StreamingContext context)
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
                    c_ResultType = (Type)info.GetValue("c_ResultType", typeof(Type));
                    c_ResultObject = info.GetValue("c_ResultObject", typeof(object));
                    break;
            }
        }

        public CrawlerCriteriaItemResult(object item, Type itemtype)
        {
            this.c_ResultObject = item;
            this.c_ResultType = itemtype;
        }

        public object Result
        {
            get
            {
                return this.c_ResultObject;
            }
            set
            {
                this.c_ResultObject = value;
            }
        }

        public Type ResultType
        {
            get
            {
                return this.c_ResultType;
            }
            set
            {
                this.c_ResultType = value;
            }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_ResultType", c_ResultType, typeof(Type));
            info.AddValue("c_ResultObject", c_ResultObject, typeof(object));
        }

        #endregion
    }
}
