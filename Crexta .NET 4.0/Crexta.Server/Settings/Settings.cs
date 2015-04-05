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
using System.Windows.Forms;

using Crexta.Common.Settings;
using Crexta.Common;

namespace Crexta.Server
{
    public class Settings
    {
        private static SettingsBase s_ServerSettings;

        /// <summary>
        /// settings for the current user
        /// </summary>
        public static SettingsBase ServerSettings
        {
            get
            {
                if (s_ServerSettings != null)
                    return s_ServerSettings;
                else
                    return new SettingsBase();
            }
        }

        /// <summary>
        /// Load current settings
        /// </summary>
        /// <returns></returns>
        public static bool LoadSettings(string instance)
        {
            s_ServerSettings = new SettingsBase();

            string filePath = Application.UserAppDataPath + "\\server\\" + instance + "\\sett.bin";

            if (File.Exists(filePath))
            {
                try
                {
                    s_ServerSettings = (SettingsBase)Serializer.Deserialize(filePath);

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return false;
        }

        public void ReLoadSettings(string instance)
        {
            LoadSettings(instance);
        }

        /// <summary>
        /// Saves current settings
        /// </summary>
        /// <returns></returns>
        public static bool SaveSettings(string instance)
        {
            string rootDir = Application.UserAppDataPath + "\\server\\" + instance;

            string filePath = rootDir + "\\sett.bin";

            if (!Directory.Exists(rootDir))
                Directory.CreateDirectory(rootDir);

            try
            {
                Serializer.Serialize(s_ServerSettings, filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
