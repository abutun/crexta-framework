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
    public class NetPayloadStream : NetBasePayloadStream<byte[]>
    {
        public NetPayloadStream(NetworkStream stream, EndPoint endpoint)
            : base(stream, endpoint)
        {
        }

        public override void Send(byte[] data)
        {
            SendPayload(data);
        }

        protected override void ReceivedPayload(byte[] data)
        {
            RaiseOnReceived(data);
        }
    }
}
