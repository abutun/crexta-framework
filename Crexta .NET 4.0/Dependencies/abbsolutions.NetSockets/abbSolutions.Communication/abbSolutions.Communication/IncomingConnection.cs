using System;
using System.Threading;
using System.ComponentModel;
using System.Net.Sockets;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
    [Browsable(true)]
    public class IncomingConnection : ConnectionBase, ICommIncomingConnection, IKeyedOnProperty<long>
    {
        internal Lockable _readLock = new Lockable();
        internal Lockable _writeLock = new Lockable();
        internal Lockable _processLock = new Lockable();

        public ILockable ReadLock { get { return _readLock; } }
        public ILockable WriteLock { get { return _writeLock; } }
        public ILockable ProcessLock { get { return _processLock; } }
        public ICommunicationsServer Server { get; set; }
        public IIncomingMessageHandler IncomingMessageHandler { get; set; }

        public override long AddBytesReceived(long nBytes)
        {
            CommunicationsServer server = Server as CommunicationsServer;
            server.AddBytesReceived(nBytes);
            return Interlocked.Add(ref _receivedBytes, nBytes);
        }

        public override long AddBytesReceived(int nBytes)
        {
            CommunicationsServer server = Server as CommunicationsServer;
            server.AddBytesReceived(nBytes);
            return Interlocked.Add(ref _receivedBytes, (Int64)nBytes);
        }

        public override long AddBytesSent(long nBytes)
        {
            CommunicationsServer server = Server as CommunicationsServer;
            server.AddBytesSent(nBytes);
            return Interlocked.Add(ref _sentBytes, nBytes);
        }

        public override long AddBytesSent(int nBytes)
        {
            CommunicationsServer server = Server as CommunicationsServer;
            server.AddBytesSent(nBytes);
            return Interlocked.Add(ref _sentBytes, (Int64)nBytes);
        }

		public long Key { get { return _associatedID; } }
        public override long AssociatedID
        {
            get { return _associatedID; }
            set
            {
                // Register the associated ID with the communications server.
                // This lets us look up a connection by a game-associated ID (usually Entity ID) 
                CommunicationsServer server = Server as CommunicationsServer;
				server._lookupConnectionByID.Remove(_associatedID, this);

                _associatedID = value;
				server._lookupConnectionByID.Add(_associatedID, this);
            }
        }

        public IncomingConnection(ICommunicationsServer server, IIncomingMessageHandler messageHandler) { Server = server; IncomingMessageHandler = messageHandler; }
        public IControlReceiver ControlReceiver { get { return Server.IDToControlReceiverMap.FindReceiver(AssociatedID); } }
        public void HandleIncomingMessage(ICommunicationsMessage message) { IncomingMessageHandler.HandleIncomingMessage(this, message); }
    }
}
