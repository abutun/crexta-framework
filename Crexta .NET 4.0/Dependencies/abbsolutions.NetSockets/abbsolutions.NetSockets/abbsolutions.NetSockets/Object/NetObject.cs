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
    [Serializable]
    public class NetObject
    {
        public string Name { get; set; }
        public object Object { get; set; }
        public T Cast<T>()
        {
            return (T)Object;
        }

        public NetObject(string name, object obj)
        {
            Name = name;
            Object = obj;
        }
        public NetObject()
        {

        }
    }
}
