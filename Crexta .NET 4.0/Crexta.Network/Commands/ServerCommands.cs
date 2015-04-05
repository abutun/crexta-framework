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
using System.ComponentModel;

using Crexta.Common.Client;
using Crexta.Common.Crextor;
using Crexta.Common.UrlInfo;
using Crexta.Network.Interfaces;

namespace Crexta.Network.Commands.Server
{
    /// <summary>
    /// Sunucu ile bağlantı kurmaya çalışan Client'lara verilen cevaptır
    /// </summary>
    [Serializable]
    public class ClientInformationResponse : IServerCommand
    {
        public ClientInformationResponse() { }

        [DefaultValue(null)]
        public ClientInfo ClientInfo { get; set; }

        [DefaultValue(0)]
        public int ErrorCode { get; set; }

        [DefaultValue(10)]
        public int ReconnectTimeMinutes { get; set; }

        [DefaultValue(0)]
        public int ReconnectTimeSeconds { get; set; }

        [DefaultValue("Everything seems fine master:)")]
        public string ErrorMessage { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// Geçerli bir sunucuya gönderilen ve sistemde kayıtlı bir CREXTOR bilgisini içeren komuttur
    /// </summary>
    [Serializable]
    public class CrextorInformationResponse : IServerCommand
    {
         public CrextorInformationResponse() { }

        [DefaultValue(null)]
        public CrextorInfo CrextorInfo { get; set; }

        [DefaultValue(0)]
        public int ErrorCode { get; set; }

        [DefaultValue("Everything seems fine master:)")]
        public string ErrorMessage { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// Client'lar tarafında gönderilen bilinmeyen/tanımlanamayan komut
    /// </summary>
    [Serializable]
    public class UnknownCommandResponse : IServerCommand
    {
        public UnknownCommandResponse() { }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// GUID bilgisi isteyen geçerli bir Client'a verilen cevaptır
    /// </summary>
    [Serializable]
    public class GUIDInformationResponse : IServerCommand
    {
        public GUIDInformationResponse() { }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// URLFounder tipindeki Client'ların gönderdikleri URL'lerin veri tabanına yazıldığını, ilgili Client'a bildiren komuttur
    /// </summary>
    [Serializable]
    public class FoundedURLsAdded2DB : IServerCommand
    {
        public FoundedURLsAdded2DB() { }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// DATAExtractor tipindeki Client'ların gönderdikleri bilgilerin veri tabanına yazıldığını, ilgili Client'a bildiren komuttur
    /// </summary>
    [Serializable]
    public class ExtractedURLDataAdded2DB : IServerCommand
    {
        public ExtractedURLDataAdded2DB() { }

        [DefaultValue(null)]
        public Guid GUID { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// DATAExtractor tipindeki Client'lar tarafından URL isteklerine verilen cevaptır. Belirli bir set URL bilgisi içerir.
    /// </summary>
    [Serializable]
    public class URLInformationResponse : IServerCommand
    {
        public URLInformationResponse() { }

        [DefaultValue(null)]
        public IDictionary<QueueUrlInfo, CrextorInfo> CrextorURLs { get; set; }

        [DefaultValue(0)]
        public int ErrorCode { get; set; }

        [DefaultValue("Everything seems fine master:)")]
        public string ErrorMessage { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }

    /// <summary>
    /// Dağıtık sistemde yer alan öğelerden birisinde bir güncelleme olduğunu bildiren komuttur
    /// </summary>
    [Serializable]
    public class InformSystemUpdate : IServerCommand
    {
        public InformSystemUpdate() { }

        [DefaultValue(null)]
        public int SystemType { get; set; }

        [DefaultValue(0)]
        public int ErrorCode { get; set; }

        [DefaultValue("Everything seems fine master:)")]
        public string ErrorMessage { get; set; }

        #region IServerCommand Members

        [DefaultValue(-1)]
        public int ServerID { get; set; }

        [DefaultValue(0)]
        public int WorkerID { get; set; }

        #endregion
    }
}
