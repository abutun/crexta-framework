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
using System.Text;
using System.Windows.Forms;
using System.IO;

using Crexta.Common;
using Crexta.Common.Constants;
using Crexta.Common.Settings;
using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.Enums;
using Crexta.Common.Crawler;
using System.Collections;

namespace Crexta.Explorer
{
    public class ExplorerUtilities
    {
        public static int CURRENT_COMPANY_ID = -1;

        public static DataStorage DATASTORAGE = DataStorage.DB;

        //Current setting object for application
        private static SettingsBase Settings_;

        /// <summary>
        /// settings for the current user
        /// </summary>
        public static SettingsBase Settings
        {
            get
            {
                return Settings_;
            }
        }

        public ExplorerUtilities()
        {
        }

        public void RefreshSettings()
        {
            LoadSettings();
        }

        /// <summary>
        /// Load current settings
        /// </summary>
        /// <returns></returns>
        public static bool LoadSettings()
        {
            Settings_ = new SettingsBase();

            string filePath = Application.UserAppDataPath + "\\explorer\\" + GetInstanceID() + "\\sett.bin";

            if (File.Exists(filePath))
            {
                try
                {
                    Settings_ = (SettingsBase)Serializer.Deserialize(filePath);

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

        /// <summary>
        /// Saves current settings
        /// </summary>
        /// <returns></returns>
        public static bool SaveSettings()
        {
            string rootDir = Application.UserAppDataPath + "\\explorer\\" + GetInstanceID();

            string filePath = rootDir + "\\sett.bin";

            if (!Directory.Exists(rootDir))
                Directory.CreateDirectory(rootDir);

            try
            {
                Serializer.Serialize(Settings_, filePath);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void LoadDBTypes(ComboBox combo)
        {
            combo.Items.Clear();
            combo.Items.Add(typeof(Int16));
            combo.Items.Add(typeof(Int32));
            combo.Items.Add(typeof(Int64));
            combo.Items.Add(typeof(double));
            combo.Items.Add(typeof(long));
            combo.Items.Add(typeof(string));
            combo.Items.Add(typeof(bool));
            combo.Items.Add(typeof(DateTime));
        }

        public class CaseInsensitiveEncodingInfoNameComparer : IComparer
        {
            // Compare 2 EncodingInfo objects, by doing a case insensitive compare on there name
            int IComparer.Compare(Object x, Object y)
            {
                int result = 0;
                if (x is EncodingInfo && y is EncodingInfo)
                {
                    var xEncodingInfo = x as EncodingInfo;
                    var yEncodingInfo = y as EncodingInfo;
                    result = ((new CaseInsensitiveComparer()).Compare(xEncodingInfo.DisplayName, yEncodingInfo.DisplayName));
                }
                return result;
            }
        }

        public static void LoadEncodings(ComboBox combo)
        {
            combo.Items.Clear();

            // Get all encodings know on this server
            EncodingInfo[] encodings = Encoding.GetEncodings();

            // Sort EncodingInfo array by Name
            Array.Sort(encodings, new CaseInsensitiveEncodingInfoNameComparer());

            // Show all encodings
            foreach (EncodingInfo encoding in encodings)
                combo.Items.Add(encoding.GetEncoding());
        }

        public static void LoadColumns(ComboBox combo, int selectedIndex)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                if (DATASTORAGE == DataStorage.FILE)
                {
                    throw new Exception("Company DB_FIELDS Not Supported in FILE STORAGE!");
                }
                else
                {
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var fields = from fi in db.DbFields
                                     where fi.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                     orderby fi.FieldName
                                     select fi;

                        if (fields != null)
                        {
                            combo.DataSource = fields;
                            if (selectedIndex < combo.Items.Count)
                                combo.SelectedIndex = selectedIndex;
                        }
                    }
                }
            }
        }

        public static void BindRules(CrawlerRuleCollection rulelist, ListBox list)
        {
            if (rulelist != null)
            {
                //reload list
                rulelist.Reload();

                list.Items.Clear();
                foreach (CrawlerRule rule in rulelist)
                    list.Items.Add(rule);
            }
        }

        public static void BindRules(CrawlerRuleCollection rulelist, ComboBox combo)
        {
            if (rulelist != null)
            {
                //reload list
                rulelist.Reload();

                combo.Items.Clear();
                foreach (CrawlerRule rule in rulelist)
                    combo.Items.Add(rule);
            }
        }

        /// <summary>
        /// Bind application rules to the specified listbox object
        /// </summary>
        /// <param name="list">Listbox to be populated</param>
        public static void BindRuleLists(ListBox list)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                if (DATASTORAGE == DataStorage.FILE)
                {
                    DirectoryInfo root = new DirectoryInfo(DataExtractorConstants.crawlerCrextorRulesDirectory + ExplorerUtilities.CURRENT_COMPANY_ID.ToString() + "\\");

                    if (root != null)
                    {
                        if (!root.Exists)
                            root.Create();

                        FileInfo[] rules = root.GetFiles("*" + Common.Constants.GeneralConstants.defaultRuleListFileExtension);

                        list.Items.Clear();

                        foreach (FileInfo f in rules)
                        {
                            CrawlerRuleCollection rule = CrawlerRuleCollection.LoadFromFile(ExplorerUtilities.CURRENT_COMPANY_ID, f.FullName);

                            list.Items.Add(rule);
                        }
                    }
                }
                else
                {
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var rules = from ru in db.Rules
                                    where ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                    orderby ru.Name
                                    select ru;

                        if (rules != null)
                            list.DataSource = rules;
                    }
                }
            }
        }


        /// <summary>
        /// Checks if the specified rule exists?
        /// </summary>
        /// <param name="name">Name of the rule list</param>
        public static bool RuleListExists(string name)
        {
            bool result = false;

            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                if (DATASTORAGE == DataStorage.FILE)
                {
                    DirectoryInfo root = new DirectoryInfo(DataExtractorConstants.crawlerCrextorRulesDirectory + ExplorerUtilities.CURRENT_COMPANY_ID.ToString() + "\\");

                    if (root != null)
                    {
                        if (!root.Exists)
                            root.Create();

                        FileInfo[] rules = root.GetFiles("*" + Common.Constants.GeneralConstants.defaultRuleListFileExtension);

                        foreach (FileInfo f in rules)
                        {
                            CrawlerRuleCollection rule = CrawlerRuleCollection.LoadFromFile(ExplorerUtilities.CURRENT_COMPANY_ID, f.FullName);

                            if (rule.Name.ToLowerInvariant() == name.ToLowerInvariant())
                            {
                                result = true;

                                break;
                            }
                        }
                    }
                }
                else
                {
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var rule = (from ru in db.Rules
                                    where ru.Name.ToLowerInvariant() == name.ToLowerInvariant() && ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                    select ru).SingleOrDefault();

                        if (rule != null)
                            result = true;
                    }
                }
            }

            return result;
        }

        public static void SaveListFilesToDatabase()
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                DirectoryInfo root = new DirectoryInfo(DataExtractorConstants.crawlerCrextorRulesDirectory + ExplorerUtilities.CURRENT_COMPANY_ID.ToString() + "\\");

                if (root != null)
                {
                    if (!root.Exists)
                        root.Create();

                    FileInfo[] rules = root.GetFiles("*" + Common.Constants.GeneralConstants.defaultRuleListFileExtension);

                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        foreach (FileInfo f in rules)
                        {
                            CrawlerRuleCollection rule = CrawlerRuleCollection.LoadFromFile(ExplorerUtilities.CURRENT_COMPANY_ID, f.FullName);

                            Rule newRule = new Rule();
                            newRule.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;
                            newRule.Path = "";
                            newRule.Name = rule.Name;
                            newRule.Data = Serializer.Serialize(rule);
                            newRule.Date = DateTime.Now;

                            db.Rules.InsertOnSubmit(newRule);
                        }

                        db.SubmitChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Bind application rules to the specified combo object
        /// </summary>
        /// <param name="combo">Combobox to be populated</param>
        public static void BindRuleLists(ComboBox combo, int selectedIndex)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                if (DATASTORAGE == DataStorage.FILE)
                {
                    DirectoryInfo root = new DirectoryInfo(DataExtractorConstants.crawlerCrextorRulesDirectory + ExplorerUtilities.CURRENT_COMPANY_ID.ToString() + "\\");

                    if (root != null)
                    {
                        if (!root.Exists)
                            root.Create();

                        FileInfo[] rules = root.GetFiles("*" + Common.Constants.GeneralConstants.defaultRuleListFileExtension);

                        combo.Items.Clear();
                        foreach (FileInfo f in rules)
                        {
                            CrawlerRuleCollection rule = CrawlerRuleCollection.LoadFromFile(ExplorerUtilities.CURRENT_COMPANY_ID, f.FullName);

                            combo.Items.Add(rule);
                        }

                        if (selectedIndex < combo.Items.Count)
                            combo.SelectedIndex = selectedIndex;
                    }
                }
                else
                {
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var rules = from ru in db.Rules
                                    where ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                    orderby ru.Name
                                    select ru;

                        if (rules != null)
                        {
                            combo.DataSource = rules;

                            if (selectedIndex < combo.Items.Count)
                                combo.SelectedIndex = selectedIndex;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Bind countries to the specified combo object
        /// </summary>
        /// <param name="combo">Combobox to be populated</param>
        public static void BindCountries(ComboBox combo, int selectedIndex)
        {
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                var countries = from co in db.Countries
                                select co;

                if (countries != null)
                {
                    combo.DataSource = countries;

                    if (selectedIndex < combo.Items.Count)
                        combo.SelectedIndex = selectedIndex;
                }
            }
        }

        /// <summary>
        /// Bind application rules to the specified combo object
        /// </summary>
        /// <param name="combo">Combobox to be populated</param>
        public static void BindCrextorGroups(ComboBox combo, int selectedIndex)
        {
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                var groups = from gr in db.CrextorGroups
                                select gr;

                if (groups != null)
                {
                    combo.DataSource = groups;

                    if (selectedIndex < combo.Items.Count)
                        combo.SelectedIndex = selectedIndex;
                }
            }
        }

        /// <summary>
        /// Binds current crextors to the specified Listbox object
        /// </summary>
        /// <param name="list">Listbox object to be populated</param>
        public static void BindCrextors(ListBox list)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);

                if (db != null)
                {
                    var crextors = from st in db.Crextors
                                   where st.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                   orderby st.Name
                                   select st;

                    if (crextors != null)
                        list.DataSource = crextors;
                }
            }
        }

        /// <summary>
        /// Binds application crextors to the specified Combobox object
        /// </summary>
        /// <param name="combo">Combobox object to be populated</param>
        public static void BindCrextors(ComboBox combo)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);

                if (db != null)
                {
                    var crextors = from st in db.Crextors
                                   where st.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                   orderby st.Name
                                   select st;

                    if (crextors != null)
                        combo.DataSource = crextors;
                }
            }
        }

        /// <summary>
        /// Binds current companies to the specified Listbox object
        /// </summary>
        /// <param name="list">Listbox object to be populated</param>
        public static void BindCompanies(ListBox list)
        {
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);

            if (db != null)
            {
                var companies = from st in db.Companies
                                orderby st.Name
                                select st;

                if (companies != null)
                    list.DataSource = companies;
            }
        }

        /// <summary>
        /// Binds application companies to the specified Combobox object
        /// </summary>
        /// <param name="combo">Combobox object to be populated</param>
        public static void BindCompanies(ComboBox combo)
        {
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);

            if (db != null)
            {
                var companies = from st in db.Companies
                                orderby st.Name
                                select st;

                if (companies != null)
                    combo.DataSource = companies;
            }
        }

        /// <summary>
        /// Binds rule criterias to the specified Listbox object
        /// </summary>
        /// <param name="rule">Rule to be searched for criterias</param>
        /// <param name="list">Listbox object to be populated</param>
        public static void BindCriterias(CrawlerRule rule, ListBox list)
        {
            if (rule != null)
            {
                list.Items.Clear();
                foreach (CrawlerCriteria cr in rule.Criterias)
                    list.Items.Add(cr);
            }
        }

        /// <summary>
        /// Binds rule criterias to the specified Combobox object
        /// </summary>
        /// <param name="rule">Rule to be searched for criterias</param>
        /// <param name="combo">Combobox object to be populated</param>
        public static void BindCriterias(CrawlerRule rule, ComboBox combo)
        {
            if (rule != null)
            {
                combo.Items.Clear();
                foreach (CrawlerCriteria cr in rule.Criterias)
                    combo.Items.Add(cr);
                //for (int i = 0; i < rule.Criterias.Count; i++)
                //    combo.Items.Add(rule.Criterias[i]);
            }
        }

        /// <summary>
        /// Binds criteria exlude list to the specified Listbox object
        /// </summary>
        /// <param name="criteria">Criteria to be searched for exclude rules</param>
        /// <param name="list">Listbox object to be populated</param>
        public static void BindExcludeList(CrawlerCriteria criteria, ListBox list)
        {
            if (criteria != null)
            {
                list.Items.Clear();
                foreach (CrawlerExcludeList lst in criteria.ExcludeList)
                    list.Items.Add(lst);
            }
        }

        /// <summary>
        /// Binds criteria exlude list to the specified Combobox object
        /// </summary>
        /// <param name="criteria">Criteria to be searched for exclude rules</param>
        /// <param name="combo">Combobox object to be populated</param>
        public static void BindExcludeList(CrawlerCriteria criteria, ComboBox combo)
        {
            if (criteria != null)
            {
                combo.Items.Clear();
                foreach (CrawlerExcludeList lst in criteria.ExcludeList)
                    combo.Items.Add(lst);
            }
        }

        public static string GetInstanceID()
        {
            string id = "";

            string filePath = Utilities.Utilities.AssemblyDirectory + @"\id.ins";

            if (File.Exists(@filePath))
            {
                StreamReader sr = new StreamReader(filePath);

                //Check for the first line
                id = sr.ReadLine();

                sr.Close();
            }
            else
            {
                MessageBox.Show("Instance ID file not found!", "Error");

                Application.Exit();
            }

            return id;
        }

        public static Crextor GetCrextorFromURLQueue(string url, out int queueid)
        {
            long hash = PerfectHash.GetPerfectHash(url);

            queueid = -1;

            if (hash > 0)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                if (db != null)
                {
                    var urlqueue = (from uq in db.UrlQueues
                                    where uq.UrlHash == hash
                                    select uq).SingleOrDefault();

                    if (urlqueue != null)
                        return urlqueue.Crextor;
                    else
                        return null;
                }
                return null;
            }
            else
                return null;
        }

    }
}
