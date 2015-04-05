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
    public class KeywordType
    {
        private string keyword_ = "";
        private double keywordFactor_ = 0;

        public KeywordType()
        {
        }

        public KeywordType(string keyword)
            : this(keyword, 0)
        {
        }

        public KeywordType(string keyword, double factor)
        {
            //keyword_ = Utilities.SafeLowerCase(keyword);
            keyword_ = keyword.ToLower(new System.Globalization.CultureInfo("tr-TR"));

            keywordFactor_ = factor;
        }

        public string Keyword
        {
            get
            {
                //return Utilities.SafeLowerCase(keyword_);
                return keyword_.ToLower(new System.Globalization.CultureInfo("tr-TR"));
            }
            set
            {
                //keyword_ = Utilities.SafeLowerCase(value);
                keyword_ = value.ToLower(new System.Globalization.CultureInfo("tr-TR"));
            }
        }

        public double KeywordFactor
        {
            get
            {
                return keywordFactor_;
            }
            set
            {
                keywordFactor_ = value;
            }
        }
    }

}
