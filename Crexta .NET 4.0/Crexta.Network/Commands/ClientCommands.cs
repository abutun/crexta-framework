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
using System.Text;
using System.ComponentModel;

using Crexta.Common.Client;
using Crexta.Network.Interfaces;
using Crexta.Common.UrlInfo;
using System.Collections.Generic;

namespace Crexta.Network.Commands.Client
{
    /// <summary>
    /// Bağlanılan bir sunucudan çalışma isteği istemek için gönderilen komuttur.
    /// </summary>
    [Serializable]
    public class RequestPermission2Work : IClientCommand
    {
        public RequestPermission2Work() { }

        [DefaultValue("")]
        public string MAC { get; set; }

        [DefaultValue("")]
        public string IP { get; set; }

        [DefaultValue("")]
        public string Instance { get; set; }

        [DefaultValue("")]
        public string Name { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// Bağlanılan sunucudan sistemde kayıtlı bir mağaza bilgisi istemek için kullanılan komuttur
    /// </summary>
    [Serializable]
    public class RequestCrextorInformation : IClientCommand
    {
        public RequestCrextorInformation() { }

        [DefaultValue(null)]
        public ClientInfo ClientInfo { get; set; }

        [DefaultValue(false)]
        public bool IncludeRuleData { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// URLFounder tipindeki Client'ların buldukları URL'leri sunucuya iletmelerini sağlayan komuttur
    /// </summary>
    [Serializable]
    public class InformNewUrlFounded
    {
        public InformNewUrlFounded() { }

        [DefaultValue(-1)]
        public int CrextorID { get; set; }

        [DefaultValue(null)]
        public List<ClientUrlInfo> UrlList { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// DATAExtractor tipindeki Client'ların, crawl etmek için belirli bir set URL almalarını sağlayan komuttur
    /// </summary>
    [Serializable]
    public class RequestURLs2Extract : IClientCommand
    {
        public RequestURLs2Extract() { }

        [DefaultValue(null)]
        public ClientInfo ClientInfo { get; set; }

        [DefaultValue(true)]
        public bool IncludeRuleData { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// DATAExtractor tipindeki Client'ların, Crawl edip aldıkları bilgileri XML formatında sunucuya göndermelerini sağlayan komuttur
    /// </summary>
    [Serializable]
    public class InformURLsExtractedData : IClientCommand
    {
        public InformURLsExtractedData() { }

        [DefaultValue("")]
        public StringBuilder XML { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// Client'lar sunucuya "beni yaşat" komutu gönderirler
    /// </summary>
    [Serializable]
    public class KeepMeAliveMaster : IClientCommand
    {
        public KeepMeAliveMaster() { }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// URL Founder tipindeki client'ların belirtilen CREXTOR'un crawl işlemine başladığını belirtir
    /// </summary>
    [Serializable]
    public class CrextorCrawlProcessStarted : IClientCommand
    {
        public CrextorCrawlProcessStarted() { }

        [DefaultValue(-1)]
        public int CrextorID { get; set; }

        [DefaultValue("1/1/1900")]
        public DateTime Date { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// URL Founder tipindeki client'ların belirtilen CREXTOR'un crawl işlemini bitirdiğini belirtir
    /// </summary>
    [Serializable]
    public class CrextorCrawlProcessFinished : IClientCommand
    {
        public CrextorCrawlProcessFinished() { }
        
        [DefaultValue(-1)]
        public int CrextorID { get; set; }

        [DefaultValue("1/1/1900")]
        public DateTime Date { get; set; }

        #region IClientCommand Members

        [DefaultValue(-1)]
        public int ClientID { get; set; }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }
}
