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
    /// Crextors can have custom URL information in order to pass to the Clients
    /// This class represents a custom URL
    /// </summary>
    [Serializable]
    public class CustomUrlInfo
    {
        public CustomUrlInfo() { }

        [DefaultValue(-1)]
        public int ItemId { get; set; }

        [DefaultValue("")]
        public string Url { get; set; }

        [DefaultValue(false)]
        public bool HasPaging { get; set; }

        [DefaultValue("")]
        public string PagingPattern { get; set; }
    }
}
