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

namespace Crexta.Common.UrlInfo
{
    /// <summary>
    /// This class is used for representing Queue table url items
    /// When a client in DE mode asks server for URLs, the URLs waiting for data extraction
    /// are sent to the client in this form.
    /// </summary>
    [Serializable]
    public class QueueUrlInfo
    {
        public QueueUrlInfo() { }

        [DefaultValue("")]
        public string Url { get; set; }

        [DefaultValue(-1)]
        public int QueueId { get; set; }
    }
}
