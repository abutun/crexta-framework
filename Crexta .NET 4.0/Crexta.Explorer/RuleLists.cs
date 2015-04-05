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
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Crexta.Common;
using Crexta.Common.Enums;
using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class RuleLists : Form
    {
        private int crextorid_ = -1;

        private int pastecount_ = 0;

        private int selectedid_ = -1;

        public RuleLists(int crextorid)
        {
            InitializeComponent();

            this.crextorid_ = crextorid;
        }

        private void addRuleListButton_Click(object sender, EventArgs e)
        {
            AddEditRuleList frmAddEdit = new AddEditRuleList(-1);

            if (frmAddEdit.ShowDialog() == DialogResult.OK)
                LoadRules();
        }

        private void editRuleListButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListsListbox.SelectedIndex >= 0)
            {
                AddEditRuleList frmAddEdit = new AddEditRuleList((int)this.ruleListsListbox.SelectedValue);

                if (frmAddEdit.ShowDialog() == DialogResult.OK)
                    LoadRules();
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void LoadRules()
        {
            ExplorerUtilities.BindRuleLists(this.ruleListsListbox);
        }

        private void deleteRuleListButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListsListbox.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Selected rule list will be deleted permenantly. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        //delete the rule file
                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        {
                            CrawlerRuleCollection ruleList = (CrawlerRuleCollection)this.ruleListsListbox.SelectedItem;

                            if (ruleList != null)
                            {
                                if (File.Exists(ruleList.RuleFilePath))
                                {
                                    //Backup original
                                    ruleList.Backup();

                                    File.Delete(ruleList.RuleFilePath);
                                }

                                this.LoadRules();
                            }
                        }
                        else
                        {
                            var rule = (from ru in db.Rules
                                        where ru.Id == (int)this.ruleListsListbox.SelectedValue
                                        select ru).SingleOrDefault();

                            if (rule != null)
                            {
                                // delete also backups
                                var backups = from bc in db.RuleBackups
                                              where bc.RuleId == rule.Id
                                              select bc;

                                // update crextors which references this rule
                                var crextors = from st in db.Crextors
                                             where st.RuleId == (int)this.ruleListsListbox.SelectedValue
                                             select st;

                                foreach (Crextor crextor in crextors)
                                    crextor.RuleId = -1;

                                db.RuleBackups.DeleteAllOnSubmit(backups);

                                db.Rules.DeleteOnSubmit(rule);

                                db.SubmitChanges();

                                LoadRules();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Cannot connect to DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void ruleListsListbox_DoubleClick(object sender, EventArgs e)
        {
            if (this.ruleListsListbox.SelectedIndex >= 0)
                editRuleListButton_Click(this, new EventArgs());
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void RuleLists_Load(object sender, EventArgs e)
        {
            this.LoadRules();

            if (this.crextorid_ != -1)
            {
                //Select rule list
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
            {
                if (Clipboard.GetData(DataFormats.Serializable) != null)
                {
                    object obj = Clipboard.GetData(DataFormats.Serializable);

                    if (obj.GetType() == typeof(CrawlerRuleCollection))
                        this.pasteToolStripMenuItem.Enabled = true;
                    else
                        this.pasteToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                if (this.selectedid_ > 0)
                    this.pasteToolStripMenuItem.Enabled = true;
                else
                    this.pasteToolStripMenuItem.Enabled = false;
            }

            if (this.ruleListsListbox.SelectedIndex >= 0)
            {
                this.copyToolStripMenuItem.Enabled = true;
                this.editToolStripMenuItem.Enabled = true;
                this.deleteToolStripMenuItem.Enabled = true;
                this.lockToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.copyToolStripMenuItem.Enabled = false;
                this.editToolStripMenuItem.Enabled = false;
                this.deleteToolStripMenuItem.Enabled = false;
                this.lockToolStripMenuItem.Enabled = false;
            }

            if (this.selectedid_ > 0)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                if (db != null)
                {
                    var rule = (from ru in db.Rules
                                where ru.Id == this.selectedid_
                                select ru).SingleOrDefault();

                    if (rule != null)
                    {
                        if (rule.Locked)
                            this.lockToolStripMenuItem.Text = "Unlock";
                        else
                            this.lockToolStripMenuItem.Text = "Lock";
                    }
                }
            }
        }

        private void newListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.addRuleListButton_Click(this, new EventArgs());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.editRuleListButton_Click(this, new EventArgs());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deleteRuleListButton_Click(this, new EventArgs());
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
            {
                CrawlerRuleCollection clipboardRuleList = (CrawlerRuleCollection)this.ruleListsListbox.SelectedItem;

                Clipboard.SetData(DataFormats.Serializable, clipboardRuleList);
            }
            else
            {
                if (this.ruleListsListbox.SelectedIndex >= 0)
                    this.selectedid_ = (int)this.ruleListsListbox.SelectedValue;
                else
                    this.selectedid_ = -1;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
            {
                CrawlerRuleCollection clipboardRuleList = (CrawlerRuleCollection)Clipboard.GetData(DataFormats.Serializable);

                if (clipboardRuleList != null)
                {
                    pastecount_++;

                    clipboardRuleList.Name = clipboardRuleList.Name + pastecount_.ToString();

                    clipboardRuleList.Save(true);
                }
            }
            else
            {
                if (this.selectedid_>0)
                {                   
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var rule = (from ru in db.Rules
                                    where ru.Id == this.selectedid_
                                    select ru).SingleOrDefault();

                        if (rule != null)
                        {
                            pastecount_++;

                            Crexta.DataBase.Rule newRule = new Crexta.DataBase.Rule();

                            newRule.Name = "Copy ("+ pastecount_.ToString() +") of " + rule.Name;
                            newRule.Path = rule.Path;
                            newRule.Data = rule.Data;
                            newRule.Date = DateTime.Now;

                            db.Rules.InsertOnSubmit(newRule);

                            db.SubmitChanges();
                        }
                    }
                }
            }

            LoadRules();
        }

        private void RuleLists_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clipboard.SetData(DataFormats.Serializable, null);
        }

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.selectedid_ > 0)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                if (db != null)
                {
                    var rule = (from ru in db.Rules
                                where ru.Id == this.selectedid_
                                select ru).SingleOrDefault();

                    if (rule != null)
                    {
                        rule.Locked = !rule.Locked;

                        db.SubmitChanges();
                    }
                }
            }
        }
    }
}
