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
using Microsoft.Win32;

namespace Crexta.Common.Registry
{
    /// <summary>
    /// Summary description for clsRegistry.
    /// </summary>
    public class CrextaRegistry
    {
        public string strRegError; //this variable contains the error message (null when no error occured)


        public CrextaRegistry() //class constructor
        {
        }

        /// <summary>
        /// Retrieves the specified String value. Returns a System.String object
        /// </summary>
        public string GetStringValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            object objData = null;
            RegistryKey subKey = null;

            try
            {
                subKey = hiveKey.OpenSubKey(strSubKey);
                if (subKey == null)
                {
                    strRegError = "Cannot open the specified sub-key";
                    return null;
                }
                objData = subKey.GetValue(strValue);
                if (objData == null)
                {
                    strRegError = "Cannot open the specified value";
                    return null;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return null;
            }

            strRegError = null;
            return objData.ToString();
        }

        /// <summary>
        /// Sets/creates the specified String value
        /// </summary>
        public bool SetStringValue(RegistryKey hiveKey, string strSubKey, string strValue, string strData)
        {
            RegistryKey subKey = null;

            try
            {
                subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    strRegError = "Cannot create/open the specified sub-key";
                    return false;
                }
                subKey.SetValue(strValue, strData);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return false;
            }

            strRegError = null;
            return true;
        }

        /// <summary>
        /// Creates a new subkey or opens an existing subkey
        /// </summary>
        public bool CreateSubKey(RegistryKey hiveKey, string strSubKey)
        {
            RegistryKey subKey = null;

            try
            {
                subKey = hiveKey.CreateSubKey(strSubKey);
                if (subKey == null)
                {
                    strRegError = "Cannot create the specified sub-key";
                    return false;
                }
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return false;
            }

            strRegError = null;
            return true;
        }

        /// <summary>
        /// Deletes a subkey and any child subkeys recursively
        /// </summary>
        public bool DeleteSubKeyTree(RegistryKey hiveKey, string strSubKey)
        {
            try
            {
                hiveKey.DeleteSubKeyTree(strSubKey);
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return false;
            }

            strRegError = null;
            return true;
        }

        /// <summary>
        /// Deletes the specified value from this (current) key
        /// </summary>
        public bool DeleteValue(RegistryKey hiveKey, string strSubKey, string strValue)
        {
            RegistryKey subKey = null;
            try
            {
                subKey = hiveKey.OpenSubKey(strSubKey, true);
                if (subKey == null)
                {
                    strRegError = "Cannot open the specified sub-key";
                    return false;
                }
                subKey.DeleteValue(strValue);
                subKey.Close();
                hiveKey.Close();
            }
            catch (Exception exc)
            {
                strRegError = exc.Message;
                return false;
            }

            strRegError = null;
            return true;
        }
    }

    public class RegistryUtility
    {
        public static bool CheckRegisteryKeys()
        {
            CrextaRegistry actReg = new CrextaRegistry();

            if ((actReg.GetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Crexta.Common.Constants.GeneralConstants.defaultHLMKey)
                                     != null) || (actReg.GetStringValue(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Crexta.Common.Constants.GeneralConstants.defaultHCUKey)) != null)
                return true;
            else
                return false;
        }

        public static string GetInstallationFolder()
        {
            CrextaRegistry actReg = new CrextaRegistry();

            string path1 = actReg.GetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\abbSolutions Inc\CrextaClient", Crexta.Common.Constants.GeneralConstants.defaultInstallationPathKey);
            string path2 = actReg.GetStringValue(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\abbSolutions Inc\CrextaClient", Crexta.Common.Constants.GeneralConstants.defaultInstallationPathKey);

            if (path1 != "")
                return path1;
            else
                return path2;
        }

        public static bool SetRegisteryKeys()
        {
            CrextaRegistry actReg = new CrextaRegistry();

            string stringValue = GetInstallationFolder() + Constants.GeneralConstants.clientExecutableName + " -b -a";

            if (actReg.SetStringValue(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Crexta.Common.Constants.GeneralConstants.defaultHLMKey, stringValue))
                return true;
            else
            {
                if (actReg.SetStringValue(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", Crexta.Common.Constants.GeneralConstants.defaultHCUKey, stringValue))
                    return true;
                else
                    return false;
            }
        }

        public static void DeleteRegisteryKeys()
        {
            CrextaRegistry actReg = new CrextaRegistry();

            actReg.DeleteSubKeyTree(Microsoft.Win32.Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\" + Crexta.Common.Constants.GeneralConstants.defaultHLMKey);
            actReg.DeleteSubKeyTree(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\" + Crexta.Common.Constants.GeneralConstants.defaultHCUKey);
        }
    }
}
