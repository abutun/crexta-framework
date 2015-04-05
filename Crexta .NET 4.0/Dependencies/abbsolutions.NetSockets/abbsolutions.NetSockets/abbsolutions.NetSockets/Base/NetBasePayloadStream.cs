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
using System.Net;
using System.Net.Sockets;

namespace abbSolutions.NetSockets
{
    public abstract class NetBasePayloadStream<T> : NetBaseStream<T>
    {
        byte[] buffer;
        public byte[] Buffer
        {
            get { return buffer; }
        }

        public NetBasePayloadStream(NetworkStream stream, EndPoint endpoint)
            : base(stream, endpoint)
        {
            buffer = new byte[0];
        }

        protected void SendPayload(byte[] data)
        {
            SendRaw(GetPayload(data));
        }
        protected abstract void ReceivedPayload(byte[] data);
        public byte[] GetPayload(byte[] bytes)
        {
            byte[] lenBytes = BitConverter.GetBytes(bytes.Length);
            byte[] payload = new byte[lenBytes.Length + bytes.Length];
            System.Buffer.BlockCopy(lenBytes, 0, payload, 0, lenBytes.Length);
            System.Buffer.BlockCopy(bytes, 0, payload, lenBytes.Length, bytes.Length);
            return payload;
        }

        protected override void ReceivedRaw(byte[] bytes)
        {
            //Buffer the received data
            int newLen = buffer.Length + bytes.Length;
            byte[] newBuffer = new byte[newLen];
            System.Buffer.BlockCopy(buffer, 0, newBuffer, 0, buffer.Length);
            System.Buffer.BlockCopy(bytes, 0, newBuffer, buffer.Length, bytes.Length);
            buffer = newBuffer;

            //There will be a size header if we have more than 4 bytes
            while (buffer.Length >= 4)
            {
                //Get payload length
                byte[] lenBytes = new byte[4];
                System.Buffer.BlockCopy(buffer, 0, lenBytes, 0, 4);
                int len = BitConverter.ToInt32(lenBytes, 0);

                //We have the full payload if we have buffer is >= the length
                if (buffer.Length >= 4 + len)
                {
                    //Get the payload
                    byte[] payload = new byte[len];
                    System.Buffer.BlockCopy(buffer, 4, payload, 0, len);

                    //Update buffer
                    newLen = buffer.Length - 4 - len;
                    newBuffer = new byte[newLen];
                    int offset = 4 + len;
                    System.Buffer.BlockCopy(buffer, offset, newBuffer, 0, newLen);
                    buffer = newBuffer;

                    //Handle payload
                    ReceivedPayload(payload);
                }
                else
                {
                    break;
                }
            }
        }
    }

}
