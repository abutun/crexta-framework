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
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

using Crexta.Common.Constants;
using Crexta.Common.Cache;
using System.Runtime.Serialization;

namespace Crexta.Common
{
    [Serializable]
    public class CrawlerRuleCollection : ISerializable, IEnumerable<CrawlerRule>
    {
        private readonly List<CrawlerRule> c_RuleList = new List<CrawlerRule>();

        private string c_Name = "";
        private string c_RuleRootPath = "";

        private object c_Owner = null;

        private static readonly CrextaCache c_Cache = new CrextaCache();

        private readonly int c_Version = 1;

        public CrawlerRuleCollection(string name)
        {
            this.c_Name = name;
        }

        public CrawlerRuleCollection(string name, string rootpath)
        {
            this.c_Name = name;
            this.c_RuleRootPath = rootpath;
        }

        public CrawlerRuleCollection(SerializationInfo info, StreamingContext context)
        {
            int version = 1;
            try
            {
                version = info.GetInt32("c_Version");
            }
            catch
            {
                // NOP
            }

            switch (version)
            {
                case 1:
                    c_Name = info.GetString("c_Name");
                    c_RuleRootPath = info.GetString("c_RuleRootPath");
                    c_Owner = info.GetValue("c_Owner", typeof(object));
                    c_RuleList = (List<CrawlerRule>)info.GetValue("c_RuleList", typeof(List<CrawlerRule>));
                    break;
            }
        }

        #region CollectionBase

        public CrawlerRule this[int index]
        {
            get
            {
                return c_RuleList[index];
            }
            set
            {
                c_RuleList[index] = value;
            }
        }

        public CrawlerRule this[CrawlerRule rule]
        {
            get
            {
                int i = -1;

                foreach (CrawlerRule tmp in c_RuleList)
                {
                    i++;

                    if (tmp.Name.ToLowerInvariant() == rule.Name.ToLowerInvariant())
                        break;
                }

                if (i != -1)
                    return c_RuleList[i];
                else
                    return null;
            }
            set
            {
                int i = -1;

                foreach (CrawlerRule tmp in c_RuleList)
                {
                    i++;

                    if (tmp.Name.ToLowerInvariant() == rule.Name.ToLowerInvariant())
                        break;
                }

                if (i != -1)
                    c_RuleList[i] = value;               
            }
        }

        public void Add(CrawlerRule rule)
        {
            c_RuleList.Add(rule);
        }

        public bool Contains(CrawlerRule rule)
        {
            foreach (CrawlerRule tmp in c_RuleList)
            {
                if (tmp.Name.ToLowerInvariant() == rule.Name.ToLowerInvariant())
                    return true;
            }

            return false;
        }

        public void Remove(CrawlerRule rule)
        {
            int i = 0;

            foreach (CrawlerRule tmp in c_RuleList)
            {
                if (tmp.Name.ToLowerInvariant() == rule.Name.ToLowerInvariant())
                    break;

                i++;
            }

            this.RemoveAt(i);
        }

        public void RemoveAt(int index)
        {
            c_RuleList.RemoveAt(index);
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get
            {
                return this.c_Name;
            }
            set
            {
                this.c_Name = value;
            }
        }

        public object Owner
        {
            get
            {
                return this.c_Owner;
            }
            set
            {
                this.c_Owner = value;
            }
        }

        public string RuleFilePath
        {
            get
            {
                CheckRootPath();

                return this.RuleRootPath + this.Name.ToLowerInvariant().Trim() + Constants.GeneralConstants.defaultRuleListFileExtension;
            }
        }

        #endregion

        #region Private Properties

        private string RuleRootPath
        {
            get
            {
                return this.c_RuleRootPath;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Checks the current rule's file path, if it does not exist then a new one is created
        /// </summary>
        protected void CheckRootPath()
        {
            if (this.c_RuleRootPath == "")
                this.c_RuleRootPath = Constants.GeneralConstants.defaultRulesFileRoot;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Saves the rule to the disk
        /// </summary>
        public void Save(bool backup)
        {
            try
            {
                CheckRootPath();

                if (File.Exists(this.RuleFilePath))
                {
                    if (backup)
                    {
                        //Backup original
                        this.Backup();
                    }

                    //Delete file in order to serialize again
                    File.Delete(this.RuleFilePath);
                }

                Serializer.Serialize(this, this.RuleFilePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Backup()
        {
            if (File.Exists(this.RuleFilePath))
            {
                string filename = this.RuleRootPath + @"\Backup\" + DateTime.Now.Year.ToString() + 
                    DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + 
                    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + 
                    this.Name.ToLowerInvariant().Trim() + Constants.GeneralConstants.defaultRuleListBacupFileExtension;

                if (!Directory.Exists(this.RuleRootPath + @"\Backup\"))
                    Directory.CreateDirectory(this.RuleRootPath + @"\Backup\");

                File.Copy(this.RuleFilePath, filename, true);

                return true;
            }

            return false;
        }

        public bool Recrextor(string backupfilepath)
        {
            if (File.Exists(backupfilepath))
            {
                CheckRootPath();

                File.Copy(backupfilepath, this.RuleFilePath);

                this.Reload();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Loads the rule
        /// </summary>
        public void Load()
        {
            try
            {
                CheckRootPath();

                if (this.RuleFilePath != "")
                {
                    if (File.Exists(this.RuleFilePath))
                    {
                        CrawlerRuleCollection tmpRuleList = (CrawlerRuleCollection)Serializer.Deserialize(this.RuleFilePath);

                        this.c_Name = tmpRuleList.Name;
                        this.c_RuleRootPath = tmpRuleList.RuleRootPath;
                        this.c_Owner = tmpRuleList.Owner;

                        this.c_RuleList.Clear();
                        foreach (CrawlerRule rule in tmpRuleList)
                            this.Add(rule);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Reload()
        {
            this.Load();
        }

        public int GetRelevantRule(string url)
        {
            if (c_RuleList != null)
            {
                for (int i = 0; i < c_RuleList.Count; i++)
                {
                    if (Regex.Match(url.Trim(),
                                 this[i].URLMatchRegex.Trim(),
                                 RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase).Success)
                        return i;
                }
            }

            return -1;
        }

        #endregion

        #region Static Methods

        public static CrawlerRuleCollection LoadFromFile(int companyid, string filepath)
        {
            string extention = Path.GetExtension(filepath);

            string filename = Path.GetFileNameWithoutExtension(filepath);

            // CACHE
            if(c_Cache.RuleCollectionCache.ContainsKey(filepath))
                return c_Cache.RuleCollectionCache[filepath];

            CrawlerRuleCollection result = new CrawlerRuleCollection("", DataExtractorConstants.crawlerCrextorRulesDirectory + companyid.ToString() + "\\");
            if (extention == Constants.GeneralConstants.defaultRuleListFileExtension)
            {
                if (filename != "")
                {
                    try
                    {
                        Object locker = new object();

                        lock (locker)
                        {
                            CrawlerRuleCollection tmpRuleList;

                            tmpRuleList = (CrawlerRuleCollection)Serializer.Deserialize(filepath);

                            result.c_Name = tmpRuleList.Name;
                            result.c_RuleRootPath = tmpRuleList.RuleRootPath;
                            result.c_Owner = tmpRuleList.Owner;

                            foreach (CrawlerRule rule in tmpRuleList)
                                result.Add(rule);

                            // add it to the cache
                            if (!c_Cache.RuleCollectionCache.ContainsKey(filepath))
                                c_Cache.RuleCollectionCache.Add(filepath, result);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                else
                    throw new System.Exception("Invalid rule list file name!");
            }
            else
                throw new System.Exception("Invalid rule list file extention!");            

            return result;
        }

        #endregion

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // for versioning purpose
            info.AddValue("c_Version", c_Version);

            info.AddValue("c_Name", c_Name);
            info.AddValue("c_RuleRootPath", c_RuleRootPath);
            info.AddValue("c_Owner", c_Owner, typeof(object));
            info.AddValue("c_RuleList", c_RuleList, typeof(List<CrawlerRule>));
        }

        #endregion

        #region IEnumerable<CrawlerRule> Members

        public IEnumerator<CrawlerRule> GetEnumerator()
        {
            return c_RuleList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return c_RuleList.GetEnumerator();
        }

        #endregion
    }
}
