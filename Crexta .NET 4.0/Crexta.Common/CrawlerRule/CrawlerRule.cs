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
using System.Runtime.Serialization;

using Crexta.Common.Crawler;

namespace Crexta.Common
{
    [Serializable]
    public class CrawlerRule : CrawlerRuleBase
    {
        public CrawlerRule(string name) : base(name) { }

        public CrawlerRule(string name, string urlregex, CrawlerCriteriaCollection criterias) : base(name, urlregex, criterias) { }

        public CrawlerRule(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        protected override void Process()
        {
            base.Process();

            //insert in db or do whatever
        }
    }
}
