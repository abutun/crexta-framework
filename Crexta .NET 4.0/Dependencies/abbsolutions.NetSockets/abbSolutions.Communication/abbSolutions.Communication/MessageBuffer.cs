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
	public class MessageBuffer
	{
		public static readonly int MaxSaneMessageSize = 5000000;

		private MemoryStream _incomingMemoryStream;
		private int _bytesAvailable;
		private BinaryReader _binaryReader;

		private IMessageHeader _tempHeader;

		public MessageBuffer(IMessageHeader headerToUse)
		{
			_tempHeader = headerToUse;
		}

		public void AppendNewIncomingBytePackets(ThreadSafeQueue<byte[]> incomingByteChunks)
		{
			byte[] nextBytes = null;

			if (_incomingMemoryStream == null)
				Interlocked.CompareExchange<MemoryStream>(ref _incomingMemoryStream, new MemoryStream(), null);

			// Go to the end of the incoming memory stream and append any bytes that have recently come in
			_incomingMemoryStream.Seek(0, SeekOrigin.End);

			while (incomingByteChunks.Dequeue(out nextBytes)) { _incomingMemoryStream.Write(nextBytes, 0, nextBytes.Length); }
		}

		public void RewindAndCreateBinaryReader()
		{
			_bytesAvailable = (int)_incomingMemoryStream.Length;
			_incomingMemoryStream.Seek(0, SeekOrigin.Begin);
			_binaryReader = new BinaryReader(_incomingMemoryStream);
		}

		public bool ReadHeader(out bool error)
		{
			error = false;

			// To read a header, we must have at least PacketLengthPrefixSize bytes available
			if (_bytesAvailable - (int)_binaryReader.BaseStream.Position <= _tempHeader.HeaderSize)
				return false;

			// Read the header - bytes expected and transmission type
			_tempHeader.ReadFromStream(_binaryReader);

			// Sanity checking on these values
			if (_tempHeader.MessageSize > MaxSaneMessageSize || _tempHeader.MessageSize < 0)
			{
				// Not a sensible value.  There should not be 5MB+ or negative number of bytes waiting. Try disaster recovery here.
				_incomingMemoryStream.SetLength(0);
				
				GlobalLogger.Log(
					"CommunicationsLibrary", 
					"Error: expected " + _tempHeader.MessageSize.ToString() + 
					" bytes.  Value does not seem reasonable - clearing receive buffer.", 
					LogSeverity.Warning);

				error = true;
				return false;
			}

			return true;
		}

		public bool ReadMessage(out Message message) // object o, out int transmissionType)
		{			
			if ((int)_binaryReader.BaseStream.Position + _tempHeader.MessageSize > _bytesAvailable)
			{
				// The message is not complete (i.e. data may be coming in on the next incoming message).
				// Rewind the stream back to the beginning of the message header
				if (_binaryReader.BaseStream.Position != 0)
					_binaryReader.BaseStream.Seek(-_tempHeader.HeaderSize, SeekOrigin.Current);

				message = null;
				return false;
			}

			// If we're here, we have a full message.  Read the message bytes and deserialize the message
			byte[] messageBytes = _binaryReader.ReadBytes(_tempHeader.MessageSize);

			try
			{
				message = new Message(messageBytes.DeserializeFromCompressedBinary(), _tempHeader.MessageType, new MessageHeader(_tempHeader.MessageSize, _tempHeader.MessageType));				
			}
			catch (Exception ex)
			{
				message = null;
				GlobalLogger.Log(ex, "GetNextFullMessage could not deserialize the compressed binary stream", LogSeverity.Warning, false);
				// let this fall through and return true.  The next message might be good.
			}

			return true;
		}

		public void RemoveReceivedMessagesFromBuffer()
		{
			int position = (int)_binaryReader.BaseStream.Position;

			if (position == 0)
			{
				// We didn't end up going anywhere (i.e. the message was not complete)
			}
			else if (position < _bytesAvailable)
			{
				// If we read and used some bytes from the stream (but not the whole stream), then
				// we need to update the partial receive memory stream to reflect this
				int nRemain = _bytesAvailable - (int)_binaryReader.BaseStream.Position;
				byte[] rgRemainingBytes = _binaryReader.ReadBytes(nRemain);
				_incomingMemoryStream = new MemoryStream(nRemain + 16384);
				_incomingMemoryStream.Write(rgRemainingBytes, 0, nRemain);
			}
			else
			{
				// Otherwise all bytes were read and used.  Clear the partial receive memory stream
				_incomingMemoryStream.SetLength(0);
				_incomingMemoryStream.Seek(0, SeekOrigin.Begin);
			}
		}
	}
}
