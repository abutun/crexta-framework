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
using System.ComponentModel;
using System.Collections.Generic;
using Crexta.Common.UrlInfo;

namespace Crexta.Common.Crextor
{
    [Serializable]
    public class CrextorInfo
    {
        public CrextorInfo() { }

        [DefaultValue(-1)]
        public int Id { get; set; }

        [DefaultValue("")]
        public string Name { get; set; }

        [DefaultValue("")]
        public string Url { get; set; }

        [DefaultValue(false)]
        public bool UseRssUrl { get; set; }

        [DefaultValue(null)]
        public List<ResourceUrlInfo> RssUrlList { get; set; }

        [DefaultValue(null)]
        public List<CustomUrlInfo> CustomUrlList { get; set; }

        [DefaultValue("")]
        public string RuleListPath { get; set; }

        [DefaultValue(null)]
        public byte[] RuleData { get; set; }

        [DefaultValue("")]
        public string ExtraDomains { get; set; }

        [DefaultValue("")]
        public string SkipUrls { get; set; }
    }
}
