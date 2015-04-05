using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
	/// <summary>
	/// The base class for incoming and outgoing connections
	/// </summary>
	[Browsable(true)]
	public class ConnectionBase : ICommunicationsBase, IHasAssociatedID
	{
		public static readonly int MaxIncomingBytesToReadAtOnce = Properties.Settings.Default.MaxIncomingBytesToReadAtOnce;
		public static readonly int MaxBytesToReadInASinglePass = 32768 * 6;
		public static readonly int MaxOutgoingPacketSize = Properties.Settings.Default.MaxOutgoingPacketSize;

		/// <summary>
		/// This event is raised when a complete message has been received from the communications stream
		/// </summary>
		public event EventHandler<ObjectEventArgs<ICommunicationsMessage>> MessageReceived;

		/// <summary>
		/// Handles buffering send/receive byte packets
		/// </summary>
		internal SendReceiveBuffer _sendReceiveBuffer = new SendReceiveBuffer();

		protected long _sentBytes;
		protected long _receivedBytes;
		protected long _associatedID;

		/// <summary>
		/// Indicates whether or not the connections needs to be closed / cleaned up
		/// </summary>
		public bool NeedsClosing { get; set; }

		/// <summary>
		/// Total numbers of bytes transmitted
		/// </summary>
		public long BytesSent { get { return _sentBytes; } }

		/// <summary>
		/// Total number of bytes received
		/// </summary>
		public long BytesReceived { get { return _receivedBytes; } }

		/// <summary>
		/// Responsible for communication with the remote host
		/// </summary>
		public ICommunicationsProtocol TcpClientConnection { get; set; }

		/// <summary>
		/// On the server side, the AssociatedID links an incoming connection
		/// to an Entity in the game (by Entity ID)
		/// </summary>
		public virtual long AssociatedID
		{
			get { return _associatedID; }
			set { _associatedID = value; }
		}

		public virtual void CloseConnection()
		{
			NeedsClosing = true;
			TcpClientConnection.CloseAndCleanup();
		}

		public virtual long AddBytesReceived(long nBytes) { return Interlocked.Add(ref _receivedBytes, nBytes); }
		public virtual long AddBytesReceived(int nBytes) { return Interlocked.Add(ref _receivedBytes, (Int64)nBytes); }
		public virtual long AddBytesSent(long nBytes) { return Interlocked.Add(ref _sentBytes, nBytes); }
		public virtual long AddBytesSent(int nBytes) { return Interlocked.Add(ref _sentBytes, (Int64)nBytes); }

		/// <summary>
		/// Enqueues an object to be sent across the wire.  Transmission type is a user-defined
		/// integer that is transmitted in the header and can be used to quickly identify 
		/// the type of message being sent.
		/// </summary>
		public void SendMessage(object o, int transmissionType)
		{
			Message message = new Message(o, transmissionType, new MessageHeader());
			byte[] bytes = message.ReadBytesForTransmission();

			if (bytes != null)
				EnqueueForSend(bytes);
		}

		/// <summary>
		/// Sends some queue'd (waiting) packets to the current connection
		/// </summary>
		/// <returns>Returns bytes sent on success, 0 on failure</returns>
		internal int SendBytesOutgoing()
		{
			int outgoingPacketLength;
			byte[] outgoingPacket = _sendReceiveBuffer.ConstructOutgoingPacketFromByteChunks(out outgoingPacketLength);

			if (outgoingPacketLength > 0)
			{
				SocketError se = SocketError.Success;

				if (TcpClientConnection == null) { return 0; }

				try
				{
					int bytesSent = TcpClientConnection.Send(outgoingPacket, 0, outgoingPacketLength, SocketFlags.None, out se);
					if (bytesSent != outgoingPacketLength) { return 0; }
				}
				catch (Exception ex)
				{
					GlobalLogger.Log(ex, "Sending Data", LogSeverity.DebugWarning, true);
				}

				if (se == SocketError.Success)
				{
					AddBytesSent(outgoingPacketLength);
					return outgoingPacketLength;
				}
			}

			return 0;
		}


		/// <summary>
		/// Check if incoming bytes are available on this connection and if so, read them in.
		/// </summary>
		/// <returns>
		/// the number of bytes that were read, or 0 if no new bytes were available/read
		/// </returns>
		internal int CheckBytesIncoming()
		{
			int availableBytes = 0;

			if (TcpClientConnection == null)
				return 0;

			try { availableBytes = TcpClientConnection.Available; }
			catch (Exception ex) { GlobalLogger.Log(ex, "Available", LogSeverity.DebugWarning, true); return 0; }

			if (availableBytes > 0)
			{
				// Limit the number of bytes read by CheckBytesIncoming to MaxIncomingBytesToReadAtOnce per call
				if (availableBytes > MaxIncomingBytesToReadAtOnce) { availableBytes = MaxIncomingBytesToReadAtOnce; }
				int remainingBytesToRead = availableBytes;
				int bytesReadSoFar = 0;
				byte[] byteArrayIn = new byte[availableBytes];

				while (remainingBytesToRead > 0)
				{
					int maxBytesToRead = (remainingBytesToRead > MaxBytesToReadInASinglePass) ? MaxBytesToReadInASinglePass : remainingBytesToRead;
					int bytesRead = 0;
					SocketError errCode;

					try
					{
						bytesRead = TcpClientConnection.Receive(byteArrayIn, bytesReadSoFar, maxBytesToRead, SocketFlags.None, out errCode);
					}
					catch (Exception ex)
					{
						GlobalLogger.Log(ex, "Receiving Data", LogSeverity.DebugWarning, true);
						break;
					}

					if (errCode != SocketError.Success)
						break;

					bytesReadSoFar += bytesRead;
					remainingBytesToRead -= bytesRead;
				}

				// Enqueue the new incoming bytes into our byte chunk queue
				_sendReceiveBuffer.EnqueueNewIncomingBytes(byteArrayIn);

				AddBytesReceived(availableBytes);
				return availableBytes;
			}

			return 0;
		}

		/// <summary>
		/// Enqueue an array of bytes to send across the wire
		/// </summary>
		/// <param name="rgByte"></param>
		internal void EnqueueForSend(byte[] bytesToSend)
		{
			int bytesToSendLength = bytesToSend.Length;
			int remainingBytesToSend = bytesToSendLength;
			int currentPosition = 0;
			List<byte[]> packetList = new List<byte[]>();

			// If this byte array is too big to send in one go, break
			// it into two (or more) parts for transmission
			while (remainingBytesToSend > MaxOutgoingPacketSize)
			{
				byte[] packet = new byte[MaxOutgoingPacketSize];
				Array.Copy(bytesToSend, currentPosition, packet, 0, MaxOutgoingPacketSize);
				remainingBytesToSend -= MaxOutgoingPacketSize;
				packetList.Add(packet);
				currentPosition += MaxOutgoingPacketSize;
			}

			if (remainingBytesToSend > 0)
			{
				byte[] packet = new byte[remainingBytesToSend];
				Array.Copy(bytesToSend, currentPosition, packet, 0, remainingBytesToSend);
				packetList.Add(packet);
			}

			// Enqueue all byte packets to be sent out by the outgoing worker thread
			for (int i = 0; i < packetList.Count; i++)
				_sendReceiveBuffer.EnqueueOutgoingBytes(packetList[i]);
		}

		internal bool GetNextFullMessage()
		{
			return _sendReceiveBuffer.GetNextFullMessage();
		}

		public ConnectionBase()
		{
			_sendReceiveBuffer.MessageReceived += new EventHandler<ObjectEventArgs<ICommunicationsMessage>>(_sendReceiveBuffer_MessageReceived);
		}

		void _sendReceiveBuffer_MessageReceived(object sender, ObjectEventArgs<ICommunicationsMessage> e)
		{
			if (MessageReceived != null)
			{
				MessageReceived(this, e);
			}
		}
	}
}
