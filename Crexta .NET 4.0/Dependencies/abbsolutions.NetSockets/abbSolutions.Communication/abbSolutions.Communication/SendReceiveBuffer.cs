using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using abbSolutions.Communication.Interfaces;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{	
	[Browsable(true)]
	public class SendReceiveBuffer 
	{
		public static readonly int JoinPacketsIfSizeBelow = Properties.Settings.Default.JoinPacketsIfSizeBelow;

		/// <summary>
		/// This event is raised when a complete message has been received from the communications stream
		/// </summary>
		public event EventHandler<ObjectEventArgs<ICommunicationsMessage>> MessageReceived;

		internal ThreadSafeQueue<byte[]> _outgoingByteChunks = new ThreadSafeQueue<byte[]>();
		internal ThreadSafeQueue<byte[]> _incomingByteChunks = new ThreadSafeQueue<byte[]>();
		internal MessageBuffer _incomingMessageBuffer = new MessageBuffer(new MessageHeader());

		internal void EnqueueNewIncomingBytes(byte[] bytes)
		{
			_incomingByteChunks.Enqueue(bytes);
		}

		internal void EnqueueOutgoingBytes(byte[] bytes)
		{
			_outgoingByteChunks.Enqueue(bytes);
		}
		
		/// <summary>
		/// Checks to determine if a full message has been received.  If so, raises the
		/// MessageReceived event.
		/// </summary>        
		internal bool GetNextFullMessage()
		{
			bool fullMessageReceived = false;
			bool error = false;

			// No new data received, so no need to check for a new message
			if (_incomingByteChunks.Count <= 0) return false;

			// Append the new data received to the incoming message buffer
			_incomingMessageBuffer.AppendNewIncomingBytePackets(_incomingByteChunks);

			// Records the number of bytes we have available and sets up the message buffer for reading
			_incomingMessageBuffer.RewindAndCreateBinaryReader();

			while (_incomingMessageBuffer.ReadHeader(out error))
			{
				Message message;

				// Try to read the complete message.  If the message is incomplete,
				// ReadMessage returns false and we exit the loop
				if (!_incomingMessageBuffer.ReadMessage(out message))
					break;

				fullMessageReceived = true;

				// Raise an event to signal a full message was received
				if (message.MessageContents != null && MessageReceived != null) 
					MessageReceived(this, new ObjectEventArgs<ICommunicationsMessage>(message));
			}

			if (error == true)
			{
				// Clear the incoming byte chunks - see if we can start over with a fresh slate
				_incomingByteChunks.Clear();
			}

			_incomingMessageBuffer.RemoveReceivedMessagesFromBuffer();

			return fullMessageReceived;
		}

		/// <summary>
		/// Retrieves data waiting to be sent, and returns the data in a byte array ready 
		/// for transmission.  The number of bytes is output via output parameter packetLength.
		/// </summary>		
		internal byte[] ConstructOutgoingPacketFromByteChunks(out int packetLength)
		{
			byte[] outgoingPacket;
			byte[] nextPacket;
			int outgoingPacketLength = 0;

			// Dequeue a waiting byte chunk
			if (_outgoingByteChunks.Dequeue(out outgoingPacket))
			{
				outgoingPacketLength = outgoingPacket.Length;
				
				if (outgoingPacketLength < JoinPacketsIfSizeBelow)
				{
					// If the length of the byte chunk is small, then combine multiple
					// byte chunks that may be waiting
					using (MemoryStream ms = new MemoryStream(JoinPacketsIfSizeBelow))
					{						
						while (outgoingPacketLength < JoinPacketsIfSizeBelow && _outgoingByteChunks.Dequeue(out nextPacket))
						{
							ms.SetLength(0);

							int nextPacketLength = nextPacket.Length;

							// Append packet1 bytes with the bytes of packet2
							ms.Write(outgoingPacket, 0, outgoingPacketLength);
							ms.Write(nextPacket, 0, nextPacketLength);
							outgoingPacket = ms.ToArray();							
							outgoingPacketLength += nextPacketLength;
						}
					}
				}
			}

			packetLength = outgoingPacketLength;
			return outgoingPacket;
		}
	}
}
