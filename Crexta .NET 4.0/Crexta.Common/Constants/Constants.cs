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
using System.IO;

namespace Crexta.Common.Constants
{
    public class GeneralConstants
    {
        public const string defaultConnectionString = "Data Source=(local);Initial Catalog=mydb;User ID=mydbuser;Password=mydbuserpwd";

        /// <summary>
        /// Security key(password) needed to encrypt/decrypt data
        /// </summary>
        public const string securityKey = "hgtypqw6p0mgzt0yga9lnexrp8qk2rgtj2ow";

        public static string defaultClientDownloadPath = Path.GetPathRoot(Environment.SystemDirectory) + @"Projects\crexta.com\download\client\";

        public static string defaultMainlistDownloadPath = Path.GetPathRoot(Environment.SystemDirectory) + @"Projects\crexta.com\download\mainlist\";

        public const string defaultClientDownloadURL = defaultWWWServerAddress + @"download/client/Client.zip";

        public const string defaultMainlistDownloadURL = defaultWWWServerAddress + @"download/mainlist/MainList.zip";

        public const string defaultHLMKey = "Crexta";

        public const string defaultHCUKey = "Crexta";

        public const string defaultInstallationPathKey = "Installation Folder";

        public static string defaultIndexingFileRoot = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Index\";

        public static string defaultRulesFileRoot = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Rules\";

        public static string defaultResultsFileRoot = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Results\Queue\";

        public static string defaultBackupFileRoot = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Backup\";

        public static string defaultRuleListFileRoot = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Lists\";

        public static string defaultRuleListVersionRoot = Path.GetPathRoot(Environment.SystemDirectory) + @"Crexta\Version\";

        public const string defaultWWWServerAddress = @"http://www.crexta.com/";

        public const string defaultRuleListFileExtension = ".lst";

        public const string defaultDefinitonFileExtension = ".def";

        public const string defaultRuleListBacupFileExtension = ".bck";

        public static string clientExecutableName = "Client.exe";

        public static string serverExecutableName = "Server.exe";

        public const int defaultClientStartThreadPriority = 2;
        public const int defaultClientStopThreadPriority = 4;

        public static string clientStartThreadPriority = "GEN_startThreadPriority";
        public static string clientStopThreadPriority = "GEN_stopThreadPriority";
    }
}

