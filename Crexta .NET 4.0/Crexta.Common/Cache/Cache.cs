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
using System.Collections.Generic;
using System.Linq;

namespace Crexta.Common.Cache
{
    public class CrextaCache
    {
        private Dictionary<string, CrawlerRuleCollection> innerRuleCullectionCache = new Dictionary<string, CrawlerRuleCollection>();

        public CrextaCache()
        {
        }

        public Dictionary<string, CrawlerRuleCollection> RuleCollectionCache
        {
            get
            {
                return this.innerRuleCullectionCache;
            }
            set
            {
                this.innerRuleCullectionCache = value;
            }
        }
    }
}
