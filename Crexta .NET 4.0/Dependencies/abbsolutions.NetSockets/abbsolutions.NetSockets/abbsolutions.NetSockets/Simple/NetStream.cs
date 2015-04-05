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
    public class NetStream : NetBaseStream<byte[]>
    {
        public NetStream(NetworkStream stream, EndPoint endpoint)
            : base(stream, endpoint)
        {
        }

        public override void Send(byte[] data)
        {
            base.SendRaw(data);
        }
        protected override void ReceivedRaw(byte[] bytes)
        {
            RaiseOnReceived(bytes);
        }
    }
}
