/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	ABBSOLUTIONS INC. - Server-Client Communication Framework			*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System.Net;
using System.Net.Sockets;

namespace abbSolutions.NetSockets
{
    public class NetObjectServer : NetBaseServer<NetObject>
    {
        protected override NetBaseStream<NetObject> CreateStream(NetworkStream ns, EndPoint ep)
        {
            return new NetObjectStream(ns, ep);
        }
    }
}
