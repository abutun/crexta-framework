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
    public class Brand
    {
        private string brandName_ = "";
        private int brandID_ = -1;

        private KeywordTypeCollection keywordList_;

        public Brand(string name, int id)
            : this(name, id, new KeywordTypeCollection())
        {
        }

        public Brand(string name, int id, KeywordTypeCollection keywords)
        {
            this.brandName_ = name;

            this.brandID_ = id;

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

        public string BrandName
        {
            get
            {
                return brandName_;
            }
            set
            {
                brandName_ = value;
            }
        }

        public int BrandID
        {
            get
            {
                return brandID_;
            }
            set
            {
                brandID_ = value;
            }
        }

    }
}
