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
using Crexta.Common.Enums;

namespace Crexta.Common.UrlInfo
{
    /// <summary>
    /// Crextors can have RSS/ATOM/XML resources, this class represents a resource URL
    /// Rss URL information
    /// </summary>
    [Serializable]
    public class ResourceUrlInfo
    {
        public ResourceUrlInfo() { }

        [DefaultValue(-1)]
        public int ItemId { get; set; }

        [DefaultValue(ResourceType.RSS)]
        public ResourceType Type { get; set; }

        [DefaultValue("")]
        public string Url { get; set; }

        [DefaultValue(false)]
        public bool DiscoverRedirects { get; set; }
    }
}
