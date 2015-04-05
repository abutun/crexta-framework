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
using System.Collections;
using System.Runtime.Serialization;

namespace Crexta.Common.Crawler
{
    [Serializable]
    public class CrawlerCriteriaCollection : ISerializable, IEnumerable<CrawlerCriteria>
    {
        private readonly int c_Version = 1;

        private readonly List<CrawlerCriteria> c_RuleList = new List<CrawlerCriteria>();

        public CrawlerCriteriaCollection()
        {
        }

        public CrawlerCriteriaCollection(SerializationInfo info, StreamingContext context)
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
                    c_RuleList = (List<CrawlerCriteria>)info.GetValue("c_RuleList", typeof(List<CrawlerCriteria>));
                    break;
            }
        }

        public CrawlerCriteria this[int index]
        {
            get
            {
                return c_RuleList[index];
            }
            set
            {
                c_RuleList[index] = value;
            }
        }

        public CrawlerCriteria this[CrawlerCriteria criteria]
        {
            get
            {
                int i = -1;
                foreach (CrawlerCriteria crt in c_RuleList)
                {
                    i++;
                    if (crt.Name.ToLowerInvariant() == criteria.Name.ToLowerInvariant())
                        break;
                }
                if (i != -1)
                    return c_RuleList[i];
                else
                    return null;
            }
            set
            {
                int i = -1;
                foreach (CrawlerCriteria crt in c_RuleList)
                {
                    i++;
                    if (crt.Name.ToLowerInvariant() == criteria.Name.ToLowerInvariant())
                        break;
                }
                if (i != -1)
                    c_RuleList[i] = value;
            }
        }

        public void Add(CrawlerCriteria criteria)
        {
            c_RuleList.Add(criteria);
        }

        public bool Contains(CrawlerCriteria criteria)
        {
            foreach (CrawlerCriteria tmp in c_RuleList)
            {
                if (tmp.Name.ToLowerInvariant() == criteria.Name.ToLowerInvariant())
                    return true;
            }

            return false;
        }

        public void Remove(CrawlerCriteria criteria)
        {
            int i = 0;

            foreach (CrawlerCriteria tmp in c_RuleList)
            {
                if (tmp.Name.ToLowerInvariant() == criteria.Name.ToLowerInvariant())
                    break;

                i++;
            }

            this.RemoveAt(i);
        }

        public void RemoveAt(int index)
        {
            c_RuleList.RemoveAt(index);
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_RuleList", c_RuleList, typeof(List<CrawlerCriteria>));
        }

        #endregion

        #region IEnumerable<CrawlerCriteria> Members

        public IEnumerator<CrawlerCriteria> GetEnumerator()
        {
            return c_RuleList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return c_RuleList.GetEnumerator();
        }

        #endregion
    }
}
