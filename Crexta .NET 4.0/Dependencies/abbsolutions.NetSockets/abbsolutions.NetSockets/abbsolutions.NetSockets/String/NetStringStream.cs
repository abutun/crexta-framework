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
    public class NetStringStream : NetBaseStream<string>
    {
        public NetStringStream(NetworkStream stream, EndPoint endpoint)
            : base(stream, endpoint)
        {
        }

        public override void Send(string data)
        {
            base.SendRaw(System.Text.Encoding.Default.GetBytes(data));
        }

        protected override void ReceivedRaw(byte[] bytes)
        {
            base.RaiseOnReceived(System.Text.Encoding.Default.GetString(bytes));
        }
    }
}
