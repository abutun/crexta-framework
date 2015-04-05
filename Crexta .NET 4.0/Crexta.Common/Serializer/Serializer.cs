/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Crexta.Common
{
    /// <summary>
    /// Utility class for Serialization of Objects
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// Serializes an object into a binary file
        /// </summary>
        /// <param name="Object">Object to be serialized</param>
        /// <param name="FileName">File name to serialize object into</param>
        public static void Serialize(object Object, string FileName)
        {
            Object locker = new object();

            lock (locker)
            {
                //Get a binary formatter
                BinaryFormatter bformatter = new BinaryFormatter();

                //Open a file stream to a new serialization file
                Stream stream = File.Open(FileName, FileMode.Create);

                //Serialize the given object into the file
                bformatter.Serialize(stream, Object);

                //Close the file stream
                stream.Close();
            }

        }
        /// <summary>
        /// Deserialize an object from a file
        /// </summary>
        /// <param name="FileName">File name to deserialize object from</param>
        /// <returns>Deserialized Object (may require casting to desired type)</returns>
        public static object Deserialize(string FileName)
        {
            object dObject = null;

            Object locker = new object();

            lock (locker)
            {
                //Get a binary formatter
                BinaryFormatter bformatter = new BinaryFormatter();

                //Open a file stream to the serialization file
                Stream stream = File.Open(FileName, FileMode.Open);

                //Deserialize the object from the file
                dObject = bformatter.Deserialize(stream);

                //Close the file stream
                stream.Close();
            }

            //return the deserialized object
            return dObject;
        }

        /// <summary>
        /// Serializes an object into a binary data
        /// </summary>
        /// <param name="Object">Object to be serialized</param>
        public static byte[] Serialize(object Object)
        {
            byte[] result = null;

            Object locker = new object();

            lock (locker)
            {
                //Get a binary formatter
                BinaryFormatter bformatter = new BinaryFormatter();

                MemoryStream stream = new MemoryStream();

                //Serialize the given object into the file
                bformatter.Serialize(stream, Object);

                result = stream.ToArray();

                stream.Close();
            }

            return result;
        }
        /// <summary>
        /// Deserialize an object from a byte[] data
        /// </summary>
        /// <param name="data">File data to deserialize object from</param>
        /// <returns>Deserialized Object (may require casting to desired type)</returns>
        public static object Deserialize(byte[] data)
        {
            object result = null;

            Object locker = new object();

            lock (locker)
            {
                //Get a binary formatter
                BinaryFormatter bformatter = new BinaryFormatter();

                Stream stream = new MemoryStream(data);

                //Deserialize the object from the file
                result = bformatter.Deserialize(stream);

                //Close the file stream
                stream.Close();
            }

            //return the deserialized object
            return result;
        }
    }
}
