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

namespace abbSolutions.NetSockets
{
    public abstract class NetStreamEventArgs : EventArgs
    {
        /// <summary>
        /// The stream's guid.
        /// </summary>
        public Guid Guid { get; private set; }

        public NetStreamEventArgs(Guid guid)
        {
            Guid = guid;
        }
    }

    public delegate void NetStreamStoppedEventHandler(object sender, NetStreamStoppedEventArgs e);  
    public class NetStreamStoppedEventArgs : NetStreamEventArgs
    {
        /// <summary>
        /// The reason why the stream being stopped.
        /// </summary>
        public NetStoppedReason Reason { get; private set; }

        public NetStreamStoppedEventArgs(Guid guid, NetStoppedReason reason)
            : base(guid)
        {
            Reason = reason;
        }
    }


    public delegate void NetStreamStartedEventHandler(object sender, NetStreamStartedEventArgs e);
    public class NetStreamStartedEventArgs : NetStreamEventArgs
    {
        public NetStreamStartedEventArgs(Guid guid)
            : base(guid)
        {
        }
    }

    public delegate void NetStreamReceivedEventHandler<T>(object sender, NetStreamReceivedEventArgs<T> e);
    public class NetStreamReceivedEventArgs<T> : NetStreamEventArgs
    {
        /// <summary>
        /// The data received.
        /// </summary>
        public T Data { get; private set; }

        public NetStreamReceivedEventArgs(Guid guid, T data)
            : base(guid)
        {
            Data = data;
        }
    }
}
