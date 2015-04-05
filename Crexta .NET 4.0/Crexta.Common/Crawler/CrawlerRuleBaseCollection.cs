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
    public class CrawlerRuleBaseCollection : ISerializable, IEnumerable<CrawlerRuleBase>
    {
        private readonly int c_Version = 1;

        private readonly List<CrawlerRuleBase> c_RuleList = new List<CrawlerRuleBase>();

        public CrawlerRuleBaseCollection()
        {
        }

        public CrawlerRuleBaseCollection(SerializationInfo info, StreamingContext context)
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
                    c_RuleList = (List<CrawlerRuleBase>)info.GetValue("c_RuleList", typeof(List<CrawlerRuleBase>));
                    break;
            }
        }

        public CrawlerRuleBase this[int index]
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

        public void Add(CrawlerRuleBase rule)
        {
            c_RuleList.Add(rule);
        }

        public bool Contains(CrawlerRuleBase rule)
        {
            foreach (CrawlerRuleBase tmp in c_RuleList)
            {
                if (tmp.Name.ToLowerInvariant() == rule.Name.ToLowerInvariant())
                    return true;
            }

            return false;
        }

        public void Remove(CrawlerRuleBase rule)
        {
            int i = 0;

            foreach (CrawlerRuleBase tmp in c_RuleList)
            {
                if (tmp.Name.ToLowerInvariant() == rule.Name.ToLowerInvariant())
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

            info.AddValue("c_RuleList", c_RuleList, typeof(List<CrawlerRuleBase>));
        }

        #endregion

        #region IEnumerable<CrawlerRuleBase> Members

        public IEnumerator<CrawlerRuleBase> GetEnumerator()
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
