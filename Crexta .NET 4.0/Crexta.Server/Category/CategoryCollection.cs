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
    public class CategoryCollection : CollectionBase
    {
        public CategoryCollection()
        {
        }

        public int Add(Category ct)
        {
            return base.InnerList.Add(ct);
        }

        public int Add(string name, int id, KeywordTypeCollection keywords)
        {
            Category ct = new Category(name, id, keywords);

            return this.Add(ct);
        }

        public int Add(string name, int id)
        {
            return this.Add(name, id, new KeywordTypeCollection());
        }

        public void Remove(Category ct)
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

        public Category this[int index]
        {
            get
            {
                return (Category)base.InnerList[index];
            }
            set
            {
                base.InnerList[index] = value;
            }
        }

        public bool Contains(Category ct)
        {
            bool res = false;

            foreach (Category c in base.InnerList)
            {
                if (c.CategoryName.ToLowerInvariant() == ct.CategoryName.ToLowerInvariant())
                {
                    res = true;
                    break;
                }
            }

            return res;

        }

    }

}
