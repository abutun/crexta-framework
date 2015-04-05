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

namespace Crexta.Utilities
{
    public class DBUtility
    {
        public static string ConnectionString
        {
            get
            {
                return GetConnectionString();
            }
        }

        public static string GetConnectionString()
        {
            if (Utilities.IsCrextaLive())
                return GetConnectionString("SqlServerConnectionLIVE") != "" ? GetConnectionString("SqlServerConnectionLIVE") : GetConnectionString("CrextaConnectionLIVE");
            else
                return GetConnectionString("SqlServerConnectionDEV") != "" ? GetConnectionString("SqlServerConnectionDEV") : GetConnectionString("CrextaConnectionDEV");
        }

        public static string GetConnectionString(string name)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[name] != null)
                return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
            else
                return "";
        }
    }
}
