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

namespace Crexta.Client
{
    public class Settings
    {
        private static SettingsBase s_ClientSettings;

        /// <summary>
        /// settings for the current user
        /// </summary>
        public static SettingsBase ClientSettings
        {
            get
            {
                if (s_ClientSettings != null)
                    return s_ClientSettings;
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
            s_ClientSettings = new SettingsBase();

            string filePath = Application.UserAppDataPath + "\\client\\" + instance + "\\sett.bin";

            if (File.Exists(filePath))
            {
                try
                {
                    s_ClientSettings = (SettingsBase)Serializer.Deserialize(filePath);

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
            string rootDir = Application.UserAppDataPath + "\\client\\" + instance;

            string filePath = rootDir + "\\sett.bin";

            if (!Directory.Exists(rootDir))
                Directory.CreateDirectory(rootDir);

            try
            {
                Serializer.Serialize(s_ClientSettings, filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
