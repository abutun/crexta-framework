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
using System.Linq;
using System.Collections;

namespace Crexta.Server
{
    public class KeywordTypeCollection : CollectionBase
    {
        public KeywordTypeCollection()
        {
        }

        public int Add(KeywordType kt)
        {
            return base.InnerList.Add(kt);
        }

        public int Add(string keyword, double factor)
        {
            KeywordType kt = new KeywordType(keyword, factor);
            return this.Add(kt);
        }

        public int Add(string keyword)
        {
            return this.Add(keyword, 0);
        }

        public void Remove(KeywordType kt)
        {
            base.InnerList.Remove(kt);
        }

        new public void Clear()
        {
            base.InnerList.Clear();
        }

        new public void RemoveAt(int index)
        {
            base.InnerList.RemoveAt(index);
        }

        public KeywordType this[int index]
        {
            get
            {
                return (KeywordType)base.InnerList[index];
            }
            set
            {
                base.InnerList[index] = value;
            }
        }

        public KeywordType this[string keyword]
        {
            get
            {
                int i = 0;
                bool found = false;

                while (i < base.InnerList.Count && found == false)
                {
                    KeywordType tmpKey = (KeywordType)base.InnerList[i];

                    if (tmpKey.Keyword.ToLowerInvariant() == keyword.ToLowerInvariant())
                        found = true;

                    i++;
                }

                if (found)
                    return (KeywordType)base.InnerList[i - 1];
                else
                    return null;
            }
        }

        public bool Contains(string keyword)
        {
            return Contains(new KeywordType(keyword));
        }

        private bool Contains(KeywordType kt)
        {
            bool res = false;

            foreach (KeywordType k in base.InnerList)
            {
                if (k.Keyword.ToLowerInvariant() == kt.Keyword.ToLowerInvariant())
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

    }

}
