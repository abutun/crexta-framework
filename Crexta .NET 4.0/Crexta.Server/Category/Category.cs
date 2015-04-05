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

namespace Crexta.Server
{
    public class Category
    {
        private string categoryName_ = "";
        private int categoryID_ = -1;

        private KeywordTypeCollection keywordList_;

        public Category(string name, int id)
            : this(name, id, new KeywordTypeCollection())
        {
        }

        public Category(string name, int id, KeywordTypeCollection keywords)
        {
            this.categoryName_ = name;

            this.categoryID_ = id;

            this.keywordList_ = keywords;
        }

        public KeywordTypeCollection Keywords
        {
            get
            {
                return keywordList_;
            }
            set
            {
                keywordList_ = value;
            }
        }

        public string CategoryName
        {
            get
            {
                return categoryName_;
            }
            set
            {
                categoryName_ = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return categoryID_;
            }
            set
            {
                categoryID_ = value;
            }
        }

    }
}
