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
using HtmlAgilityPack;
using System.Runtime.Serialization;

namespace Crexta.Common.Crawler.Interfaces
{
    public interface ICrawlerCriteria : ISerializable
    {
        void Match(HtmlDocument htmldocument);

        string URL { get; set; }
        string Name { get; set; }

        List<string> Text { get; }
        List<string> HTML { get; }

        string XFieldI { get; set; }
        string XFieldII { get; set; }
        string XFieldIII { get; set; }
        string ColumnName { get; set; }
        string ColumnType { get; set; }
        int ColumnLength { get; set; }

        List<List<CrawlerCriteriaItemResult>> ExecutionPipelineResults { get; }
        CrawlerCriteriaItemCollection ExecutionPipelineItems { get; set; }
        CrawlerExcludeListCollection ExcludeList { get; set; }
    }
}
