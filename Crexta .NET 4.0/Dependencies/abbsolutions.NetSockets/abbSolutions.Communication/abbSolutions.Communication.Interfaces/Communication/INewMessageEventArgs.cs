using System;
using System.IO;
using System.ComponentModel;
using System.Net.Sockets;
using System.Net;

namespace abbSolutions.Communication.Interfaces
{
	public interface ICommunicationsMessage
	{
		object MessageContents { get; set; }
		IMessageHeader Header { get; set; }
		byte[] ReadBytesForTransmission();
		int MessageType { get; }
	}

	public interface IMessageHeader
	{
		void WriteHeaderToStream(MemoryStream ms);
		int HeaderSize { get; }
		int MessageType { get; set; }
		int MessageSize { get; set; }
		void ReadFromStream(BinaryReader binaryReader);
	}

   //public class ObjectEventArgs : EventArgs
   //{
   //    public ICommunicationsMessage Message { get; set; }
   //    public ObjectEventArgs(ICommunicationsMessage message) { Message = message; }
   //}

   public class ObjectEventArgsNonRef<T> : EventArgs
   {
	   public T obj { get; set; }
	   public ObjectEventArgsNonRef(T item) { obj = item; }
   }

   public class ObjectEventArgsNonRef<T1, T2> : EventArgs
   {
	   public T1 obj1 { get; set; }
	   public T2 obj2 { get; set; }
	   public ObjectEventArgsNonRef(T1 item1, T2 item2) { obj1 = item1; obj2 = item2; }
   }

   public class ObjectEventArgsNonRef<T1, T2, T3> : EventArgs
   {
	   public T1 obj1 { get; set; }
	   public T2 obj2 { get; set; }
	   public T3 obj3 { get; set; }
	   public ObjectEventArgsNonRef(T1 item1, T2 item2, T3 item3) { obj1 = item1; obj2 = item2; obj3 = item3; }
   }

   public class ObjectEventArgs<T> : EventArgs where T : class
   {
	   public T obj { get; set; }
	   public ObjectEventArgs(T item) { obj = item; }
   }

   public class ObjectEventArgs<T1, T2> : EventArgs
	   where T1 : class
	   where T2 : class
   {
	   public T1 obj1 { get; set; }
	   public T2 obj2 { get; set; }
	   public ObjectEventArgs(T1 item1, T2 item2) { obj1 = item1; obj2 = item2; }
   }

   public class ObjectEventArgs<T1, T2, T3> : EventArgs
	   where T1 : class
	   where T2 : class
	   where T3 : class
   {
	   public T1 obj1 { get; set; }
	   public T2 obj2 { get; set; }
	   public T3 obj3 { get; set; }
	   public ObjectEventArgs(T1 item1, T2 item2, T3 item3) { obj1 = item1; obj2 = item2; obj3 = item3; }
   }

}
