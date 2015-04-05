/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	ABBSOLUTIONS INC. - Server-Client Communication Framework			*
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
using System.Text;

namespace abbSolutions.NetSockets
{
    public class NetStringPayloadServer : NetBaseServer<string>
    {
        protected override NetBaseStream<string> CreateStream(System.Net.Sockets.NetworkStream ns, System.Net.EndPoint ep)
        {
            return new NetStringPayloadStream(ns, ep);
        }
    }
}
