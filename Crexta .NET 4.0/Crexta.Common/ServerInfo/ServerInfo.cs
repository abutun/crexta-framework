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

namespace Crexta.Common.Server
{
    public class ServerInfo
    {
        public ServerInfo() { }

        [DefaultValue(-1)]
        public int Id { get; set; }

        public long UniqueHash
        {
            get
            {
                return Crexta.Utilities.PerfectHash.GetPerfectHash(this.Mac + this.Instance);
            }
        }

        [DefaultValue("")]
        public string Name { get; set; }

        [DefaultValue("")]
        public string ComputerName { get; set; }

        [DefaultValue("")]
        public string ExternalIp { get; set; }

        [DefaultValue("")]
        public string LocalIp { get; set; }

        [DefaultValue("")]
        public string Mac { get; set; }

        [DefaultValue("1")]
        public string Instance { get; set; }

        [DefaultValue(-1)]
        public int Socket { get; set; }
    }

    public class ServerIpPort
    {
        public ServerIpPort() { }

        public ServerIpPort(string externalip, string localip, int port)
        {
            this.ExternalIp = externalip;
            this.LocalIp = localip;
            this.Port = port;
        }

        [DefaultValue("")]
        public string ExternalIp { get; set; }

        [DefaultValue("")]
        public string LocalIp { get; set; }

        [DefaultValue(-1)]
        public int Port { get; set; }
    }
}
