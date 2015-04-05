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
    public class BrandCollection : CollectionBase
    {
        public BrandCollection()
        {
        }

        public int Add(Brand ct)
        {
            return base.InnerList.Add(ct);
        }

        public int Add(string name, int id, KeywordTypeCollection keywords)
        {
            Brand ct = new Brand(name, id, keywords);

            return this.Add(ct);
        }

        public int Add(string name, int id)
        {
            return this.Add(name, id, new KeywordTypeCollection());
        }

        public void Remove(Brand ct)
        {
            base.InnerList.Remove(ct);
        }

        new public void RemoveAt(int index)
        {
            base.InnerList.RemoveAt(index);
        }

        new public void Clear()
        {
            base.InnerList.Clear();
        }

        public Brand this[int index]
        {
            get
            {
                return (Brand)base.InnerList[index];
            }
            set
            {
                base.InnerList[index] = value;
            }
        }

        public bool Contains(Brand ct)
        {
            bool res = false;

            foreach (Brand c in base.InnerList)
            {
                if (c.BrandName.ToLowerInvariant() == ct.BrandName.ToLowerInvariant())
                {
                    res = true;
                    break;
                }
            }

            return res;

        }

    }

}
