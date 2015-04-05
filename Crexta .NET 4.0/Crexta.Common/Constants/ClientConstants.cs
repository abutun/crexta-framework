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

namespace Crexta.Common.Constants
{
    public class ClientConstants
    {
        /// <summary>
        /// Write all events to log files
        /// </summary>
        public const bool defaultLogAllEvents = false;

        public const bool defaultShowNotifications = false;

        public static string logAllEvents = "CLT_logAllEvents";

        public static string showNotifications = "CLT_showNotifications";
    }
}