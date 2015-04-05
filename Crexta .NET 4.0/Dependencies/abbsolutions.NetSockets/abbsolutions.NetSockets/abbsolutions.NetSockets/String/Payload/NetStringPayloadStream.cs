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
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.NetSockets
{
    public class NetStringPayloadStream : NetBasePayloadStream<string>
    {
        public NetStringPayloadStream(NetworkStream stream, EndPoint endpoint)
            : base(stream, endpoint)
        {
            
        }

        public override void Send(string data)
        {
            SendPayload(System.Text.Encoding.Default.GetBytes(data));
        }

        protected override void ReceivedPayload(byte[] data)
        {
            RaiseOnReceived(System.Text.Encoding.Default.GetString(data));
        }
    }
}
