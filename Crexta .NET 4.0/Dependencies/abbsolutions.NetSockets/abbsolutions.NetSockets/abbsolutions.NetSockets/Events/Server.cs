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
    public delegate void NetStartedEventHandler(object sender, NetStartedEventArgs e);
    public class NetStartedEventArgs : EventArgs
    {

    }

    public delegate void NetStoppedEventHandler(object sender, NetStoppedEventArgs e);
    public class NetStoppedEventArgs : EventArgs
    {
        /// <summary>
        /// The reason why the server was stopped.
        /// </summary>
        public NetStoppedReason Reason { get; private set; }

        public NetStoppedEventArgs(NetStoppedReason reason)
        {
            Reason = reason;
        }
    }

    public delegate void NetClientConnectedEventHandler(object sender, NetClientConnectedEventArgs e);
    public class NetClientConnectedEventArgs : NetStreamEventArgs
    {
        /// <summary>
        /// Gets or sets whether the client should be rejected.
        /// </summary>
        public bool Reject { get; set; }

        public NetClientConnectedEventArgs(Guid guid, bool reject)
            : base(guid)
        {
            Reject = reject;
        }
    }

    public delegate void NetClientDisconnectedEventHandler(object sender, NetClientDisconnectedEventArgs e);
    public class NetClientDisconnectedEventArgs : NetStreamStoppedEventArgs
    {
        public NetClientDisconnectedEventArgs(Guid guid, NetStoppedReason reason)
            : base(guid, reason)
        {
        }
    }

    public delegate void NetClientAcceptedEventHandler(object sender, NetClientAcceptedEventArgs e);
    public class NetClientAcceptedEventArgs : NetStreamEventArgs
    {
        public NetClientAcceptedEventArgs(Guid guid)
            : base(guid)
        {
        }
    }

    public delegate void NetClientRejectedEventHandler(object sender, NetClientRejectedEventArgs e);
    public class NetClientRejectedEventArgs : NetStreamEventArgs
    {
        /// <summary>
        /// The reason why the stream being stopped.
        /// </summary>
        public NetRejectedReason Reason { get; private set; }

        public NetClientRejectedEventArgs(Guid guid, NetRejectedReason reason)
            : base(guid)
        {
            Reason = reason;
        }
    }

    public delegate void NetExceptionEventHandler(object sender, NetExceptionEventArgs e);
    public class NetExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// The exception tht was caught.
        /// </summary>
        public Exception Exception { get; private set; }

        public NetExceptionEventArgs(Exception ex)
        {
            Exception = ex;
        }
    }

    public delegate void NetClientReceivedEventHandler<T>(object sender, NetClientReceivedEventArgs<T> e);
    public class NetClientReceivedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// The data received.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// The echo mode for this event.
        /// </summary>
        public NetEchoMode EchoMode { get; set; }

        public NetClientReceivedEventArgs(T data, NetEchoMode echoMode)
        {
            Data = data;
            EchoMode = echoMode;
        }
    }
}
