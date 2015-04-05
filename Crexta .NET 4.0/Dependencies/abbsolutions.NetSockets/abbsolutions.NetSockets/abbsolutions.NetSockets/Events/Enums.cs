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
    /// <summary>
    /// Stop reasons.
    /// </summary>
    public enum NetStoppedReason { Manually, Remote, Exception };

    /// <summary>
    /// Rejection reasons.
    /// </summary>
    public enum NetRejectedReason { Full, Other };
}
