using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using abbSolutions.Communication.ThreadSafeObjects;

namespace abbSolutions.Communication
{
	public static class Serialization
	{
		public static void Save(this object o, string fileName)
		{
			if (o == null) { if (File.Exists(fileName)) File.Delete(fileName); return; }

			using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
			{
				using (BinaryWriter bw = new BinaryWriter(fs))
				{
					byte[] bytes = o.SerializeToCompressedBinary();
					bw.Write(bytes);
				}
				fs.Close();
			}
		}

		public static T Load<T>(this string fileName, bool deleteOnError) where T : class
		{
			if (!File.Exists(fileName)) { return null; }
			T item = null;
			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						using (MemoryStream ms = new MemoryStream())
						{
							while (true)
							{
								byte[] bytes = br.ReadBytes(200000);
								if (bytes == null || bytes.Length == 0) break;
								ms.Write(bytes, 0, bytes.Length);
							}

							item = ms.ToArray().DeserializeFromCompressedBinary() as T;
							ms.Close();
						}
						br.Close();
					}
					fs.Close();
				}
			}
			catch
			{
				if (deleteOnError) { try { File.Delete(fileName); } catch { } }
				item = null;
			}
			return item;
		}

		public static object DeserializeFromBinary(this byte[] data)
		{
			using (MemoryStream ms = new MemoryStream(data))
			{
				ms.Seek(0, SeekOrigin.Begin);
				return ms.DeserializeFromBinary();
			}
		}

		public static object DeserializeFromBinary(this MemoryStream ms)
		{
			BinaryFormatter bf = new BinaryFormatter();
			return bf.Deserialize(ms);
		}


		public static object DeserializeFromCompressedBinary(this MemoryStream ms)
		{
			BinaryFormatter bf = new BinaryFormatter();
			using (MemoryStream m = new MemoryStream(ms.ToArray().Decompress()))
			{
				m.Seek(0, SeekOrigin.Begin);
				return bf.Deserialize(m);
			}
		}

		public static object DeserializeFromBinary(this MemoryStream ms, BinaryFormatter bf)
		{
			return bf.Deserialize(ms);
		}

		public static object DeserializeFromBinary(this FileStream ms)
		{
			BinaryFormatter bf = new BinaryFormatter();
			return bf.Deserialize(ms);
		}

		public static byte[] SerializeToBinary(this object o)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				BinaryFormatter bf = new BinaryFormatter();
				bf.Serialize(ms, o);
				return ms.ToArray();
			}
		}

		public static byte[] SerializeToCompressedBinary(this object o)
		{
			byte[] data;
			using (MemoryStream ms = new MemoryStream())
			{
				BinaryFormatter bf = new BinaryFormatter();
				try
				{
					bf.Serialize(ms, o);
				}
				catch { throw; }
				data = ms.ToArray();
			}
			return data.Compress();
		}

		public static object DeserializeFromCompressedBinary(this byte[] data)
		{
			byte[] decompressed = data.Decompress();
			using (MemoryStream ms = new MemoryStream(decompressed))
			{
				ms.Seek(0, SeekOrigin.Begin);
				return ms.DeserializeFromBinary();
			}
		}

		public static object DeserializeFromCompressedBinary(this FileStream fs)
		{
			byte[] data;
			BinaryFormatter bf = new BinaryFormatter();
			long len = fs.Length;

			using (BinaryReader br = new BinaryReader(fs))
			{
				data = br.ReadBytes(Convert.ToInt32(len));
			}

			return data.DeserializeFromCompressedBinary();
		}

		public static void SerializeToBinaryMemoryStream(this object o, MemoryStream ms)
		{
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(ms, o);
		}

		public static void SerializeToCompressedBinaryMemoryStream(this object o, MemoryStream ms)
		{
			byte[] data = o.SerializeToCompressedBinary();
			ms.Write(data, 0, data.Length);
		}		
	}
}
