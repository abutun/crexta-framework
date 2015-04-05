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

using HtmlAgilityPack;

namespace Crexta.Common.Crawler.Interfaces
{
    public interface ICrawlerCriteriaItem : ISerializable
    {
        string Name { get; set; }

        void Execute(HtmlDocument htmldoc, CrawlerCriteria criteria, int pipelineindex);
    }
}
