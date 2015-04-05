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
using System.Linq;
using System.Collections;
using System.Runtime.Serialization;

namespace Crexta.Common
{
    [Serializable]
    public class IndexHash : Hashtable
    {
        public IndexHash() { }

        protected IndexHash(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
