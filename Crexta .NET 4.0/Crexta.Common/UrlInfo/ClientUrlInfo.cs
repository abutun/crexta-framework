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
    /// When a Client in UF mode finds a set of URL to be sent to the Server,
    /// founded URL information is sent to the Server in this form.
    /// </summary>
    [Serializable]
    public class ClientUrlInfo
    {
        public ClientUrlInfo() { }

        [DefaultValue(-1)]
        public int ItemId { get; set; }

        [DefaultValue(UrlType.CRAWLER)]
        public UrlType Type { get; set; }

        [DefaultValue("")]
        public string Url { get; set; }

        [DefaultValue("")]
        public string PubDate { get; set; }
    }
}
