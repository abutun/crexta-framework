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
	public class MessageHeader : IMessageHeader
	{
		/// <summary>
		/// 4 bytes for the message length, 4 bytes for the message type
		/// </summary>
		public int HeaderSize { get { return 8; } }

		public int MessageType { get; set; }
		public int MessageSize { get; set; }

		public MessageHeader() { }
		public MessageHeader(int messageSize, int messageType)
		{
			MessageSize = messageSize;
			MessageType = messageType;
		}

		public void ReadFromStream(BinaryReader binaryReader)
		{
			MessageSize = binaryReader.ReadInt32();
			MessageType = binaryReader.ReadInt32();
		}

		public void WriteHeaderToStream(MemoryStream ms)
		{
			// Seek back to the beginning of the memory stream
			ms.Seek(0, SeekOrigin.Begin);

			using (BinaryWriter bw = new BinaryWriter(ms))
			{
				// Write the header - first the number of bytes in the message
				// second, the transmission type (or message type, some other message key, etc)
				bw.Write(MessageSize);
				bw.Write(MessageType);
			}
		}
	}
}
