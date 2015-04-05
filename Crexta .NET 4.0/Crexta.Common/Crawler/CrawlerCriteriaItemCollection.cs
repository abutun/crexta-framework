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

using Crexta.Common.Crawler.Interfaces;

namespace Crexta.Common.Crawler
{
    [Serializable]
    public class CrawlerCriteriaItemCollection : ISerializable, IEnumerable<ICrawlerCriteriaItem>
    {
        private readonly int c_Version = 1;

        private readonly List<ICrawlerCriteriaItem> c_RuleList = new List<ICrawlerCriteriaItem>();

        public CrawlerCriteriaItemCollection()
        {
        }

        public CrawlerCriteriaItemCollection(SerializationInfo info, StreamingContext context)
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
                    c_RuleList = (List<ICrawlerCriteriaItem>)info.GetValue("c_RuleList", typeof(List<ICrawlerCriteriaItem>));
                    break;
            }
        }

        public ICrawlerCriteriaItem this[int index]
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

        public ICrawlerCriteriaItem this[ICrawlerCriteriaItem item]
        {
            get
            {
                int index = 0;
                int place = -1;

                foreach (ICrawlerCriteriaItem icc in c_RuleList)
                {
                    if (icc.Name.ToLowerInvariant() == item.Name.ToLowerInvariant())
                        place = index;

                    index++;
                }

                if (place != -1)
                    return this[place];

                return null;
            }
            set
            {
                int index = 0;
                int place = -1;

                foreach (ICrawlerCriteriaItem icc in c_RuleList)
                {
                    if (icc.Name.ToLowerInvariant() == item.Name.ToLowerInvariant())
                        place = index;

                    index++;
                }

                if (place != -1)
                    this[place] = value;
            }
        }

        #region ICollection<ICrawlerCriteriaItem> Members

        public void Add(ICrawlerCriteriaItem item)
        {
            c_RuleList.Add(item);
        }

        public void Clear()
        {
            c_RuleList.Clear();
        }

        public bool Contains(ICrawlerCriteriaItem item)
        {
            foreach (ICrawlerCriteriaItem icc in c_RuleList)
            {
                if (icc.Name.ToLowerInvariant() == item.Name.ToLowerInvariant())
                    return true;
            }

            return false;
        }

        public void CopyTo(ICrawlerCriteriaItem[] array, int arrayIndex)
        {
            c_RuleList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return c_RuleList.Count; }
        }

        public bool Remove(ICrawlerCriteriaItem item)
        {
            int r_Index = 0;
            int r_Place = -1;

            foreach (ICrawlerCriteriaItem icc in c_RuleList)
            {
                if (icc.Name.ToLowerInvariant() == item.Name.ToLowerInvariant())
                    r_Place = r_Index;

                r_Index++;
            }

            if (r_Place != -1)
            {
                c_RuleList.RemoveAt(r_Place);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            c_RuleList.RemoveAt(index);
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_RuleList", c_RuleList, typeof(List<ICrawlerCriteriaItem>));
        }

        #endregion

        #region IEnumerable<ICrawlerCriteriaItem> Members

        public IEnumerator<ICrawlerCriteriaItem> GetEnumerator()
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
