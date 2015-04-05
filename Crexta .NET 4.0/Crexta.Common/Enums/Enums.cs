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

namespace Crexta.Common.Enums
{
    [Serializable]
    public enum LogLevel
    {
        DEBUG = 1,
        ERROR = 2,
        FATAL = 3,
        INFO = 4,
        WARN = 5
    }

    [Serializable]
    public enum ServiceStatus
    {
        STARTED = 0,
        PENDING = 1,
        STOPPED = 2
    }

    [Serializable]
    public enum Languages
    {
        ENGLISH = 0,
        TURKISH = 1
    }

    [Serializable]
    public enum MessageTypes
    {
        INFORMATION = 0,
        ERROR = 1,
        WARNING = 2
    }

    [Serializable]
    public enum LogType
    {
        CLIENT = 1,
        SERVER = 2,
        INDEXER = 3
    }

    [Serializable]
    public enum LogSubType
    {
        URLFINDER = 1,
        DATAEXTRACTOR = 2
    }

    [Serializable]
    public enum SequenceType
    {
        CLIENT = 1,
        SERVER = 2,
        INDEXER = 3
    }

    [Serializable]
    public enum SequenceSubType
    {
        URLFINDER = 1,
        DATAEXTRACTOR = 2
    }

    [Serializable]
    public enum LogAction
    {
        SEQUENCE_QUERY = 1,
        SEQUENCE_INCREMENT = 2,
        SEQUENCE_DECREMENT = 3,
        SEQUENCE_RESET = 4,
        CLIENT_CONNECTED = 50,      //xfield1 of the log table shows serverid, xfield2 = mode
        CLIENT_DISCONNECTED = 60,   //xfield1 of the log table shows serverid
        SERVER_STARTED = 70,
        SERVER_STOPPED = 80
    }

    [Serializable]
    public enum VersionType
    {
        MAINLIST = 1,
        CLIENT = 2,
        SERVER = 3,
        EXPLORER = 4
    }

    [Serializable]
    public enum ParameterType
    {
        TYPE = 1,
        STATUS = 2,
        COLOR = 3,
        FUEL = 4,
        HEAT = 5,
        GEAR = 6,
    }

    [Serializable]
    public enum DataStorage
    {
        FILE = 1,
        DB = 2
    }

    [Serializable]
    public enum ResourceType
    {
        RSS = 1,
        ATOM = 2,
        XML = 3
    }

    [Serializable]
    public enum UrlType
    {
        CRAWLER = 0,
        RESOURCE = 1,
        CUSTOM = 2
    }
}
