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
	public class Message : ICommunicationsMessage
	{
		public Message() { }

		public Message(object o, int transmissionType, IMessageHeader header)
		{
			MessageContents = o;
			Header = header;
			Header.MessageType = transmissionType;
		}

		public int MessageType { get { return Header.MessageType; } }
		public object MessageContents { get; set; }
		public IMessageHeader Header { get; set; }

		/// <summary>
		/// Creates a byte array for an object (with appropriate header bytes),
		/// allowing a message to be sent across the wire.
		/// </summary>
		public byte[] ReadBytesForTransmission()
		{
			byte[] commandBytes;
			
			using (MemoryStream ms = new MemoryStream())
			{
				// Leave the first 8 bytes empty for now
				ms.Seek(Header.HeaderSize, SeekOrigin.Begin);

				// Serialize the object to the memory stream starting at position 8
				MessageContents.SerializeToCompressedBinaryMemoryStream(ms);

				// Determine the byte length of the serialized object
				Header.MessageSize = (int)ms.Length - Header.HeaderSize;

				// Write the header to the beginning of the memory stream
				Header.WriteHeaderToStream(ms);
				
				commandBytes = ms.ToArray();
			}
			return commandBytes;
		}
	}
}
