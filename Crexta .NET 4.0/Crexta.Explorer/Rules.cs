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

using Crexta.Common;
using Crexta.Common.Enums;
using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.Crawler;

namespace Crexta.Explorer
{
    public partial class Rules : Form
    {
        private int rulepastecount_ = 0;
        private int criteriapastecount_ = 0;

        private int currentruleid_ = -1;

        private int selectedlistindex_ = 0;
        private int selectedruleindex_ = -1;

        private bool datachanged_ = false;
        private bool loadfromdb_ = true;

        public static CrawlerRuleCollection SelectedRuleList = null;

        public Rules()
        {
            InitializeComponent();
        }

        private void deleteRuleButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                if (this.rulesListBox.SelectedIndex >= 0)
                {
                    if (MessageBox.Show("Selected rule will be deleted permenantly. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        if (SelectedRuleList != null)
                        {
                            CrawlerRule rule = (CrawlerRule)this.rulesListBox.SelectedItem;

                            if (rule != null)
                            {
                                SelectedRuleList.Remove(rule);

                                if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                                    SelectedRuleList.Save(true);
                                else
                                    ShowDataChangedMessage();

                                ExplorerUtilities.BindRules(SelectedRuleList, this.rulesListBox);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Please select a rule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void editRuleButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                if (this.rulesListBox.SelectedIndex >= 0)
                {
                    AddEditRules frmAddEdit = new AddEditRules(SelectedRuleList, (CrawlerRule)this.rulesListBox.SelectedItem);

                    if (frmAddEdit.ShowDialog() == DialogResult.OK)
                    {
                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                            SelectedRuleList.Save(true);
                        else
                            ShowDataChangedMessage();

                        ExplorerUtilities.BindRules(SelectedRuleList, this.rulesListBox);
                    }
                }
                else
                    MessageBox.Show("Please select a rule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void addRuleButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                AddEditRules frmAddEdit = new AddEditRules(SelectedRuleList, null);

                if (frmAddEdit.ShowDialog() == DialogResult.OK)
                {
                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        SelectedRuleList.Save(true);
                    else
                        ShowDataChangedMessage();

                    ExplorerUtilities.BindRules(SelectedRuleList, this.rulesListBox);
                }
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void Rules_Load(object sender, EventArgs e)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID>0)
            {
                LoadRules();

                CheckCriteriaItems(false);
            }
            else
            {
                MessageBox.Show("Please select a company!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.Close();
            }
        }

        private void LoadRules()
        {
            ExplorerUtilities.BindRuleLists(this.ruleListCombo, 0);

            if (this.ruleListCombo.Items.Count > 0)
                this.ruleListCombo.SelectedIndex = this.selectedlistindex_;
        }

        private void rulesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load rule criterias
            if (this.rulesListBox.SelectedIndex != -1)
            {
                CrawlerRule rule = (CrawlerRule)this.rulesListBox.SelectedItem;

                if (rule != null)
                {
                    this.criteriaListBox.Enabled = true;
                    this.addCriteriaButton.Enabled = true;
                    this.editCriteriaButton.Enabled = true;
                    this.deleteCriteriaButton.Enabled = true;

                    this.criteriaListBox.Items.Clear();
                    foreach (CrawlerCriteria cr in rule.Criterias)
                        this.criteriaListBox.Items.Add(cr);
                }
                else
                {
                    this.criteriaListBox.Enabled = false;
                    this.addCriteriaButton.Enabled = false;
                    this.editCriteriaButton.Enabled = false;
                    this.deleteCriteriaButton.Enabled = false;
                }
            }

            this.selectedruleindex_ = this.rulesListBox.SelectedIndex;
        }

        private void addCriteriaButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                if (this.rulesListBox.SelectedIndex != -1)
                {
                    CrawlerRule rule = (CrawlerRule)this.rulesListBox.SelectedItem;

                    if (rule != null)
                    {
                        AddEditCriteria frm = new AddEditCriteria(SelectedRuleList, rule, null);

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                                SelectedRuleList.Save(true);
                            else
                                ShowDataChangedMessage();

                            ExplorerUtilities.BindCriterias(rule, this.criteriaListBox);
                        }
                    }
                }
                else
                    MessageBox.Show("Please select a rule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editCriteriaButton_Click(object sender, EventArgs e)
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                if (this.rulesListBox.SelectedIndex != -1)
                {
                    if (this.criteriaListBox.SelectedIndex != -1)
                    {
                        CrawlerRule rule = (CrawlerRule)this.rulesListBox.SelectedItem;

                        if (rule != null)
                        {
                            CrawlerCriteria crt = (CrawlerCriteria)this.criteriaListBox.SelectedItem;

                            if (crt != null)
                            {
                                AddEditCriteria frm = new AddEditCriteria(SelectedRuleList, rule, crt);

                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                                        SelectedRuleList.Save(true);
                                    else
                                        ShowDataChangedMessage();

                                    ExplorerUtilities.BindCriterias(rule, this.criteriaListBox);
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please select a criteria!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("Please select a rule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please select a rule list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void deleteCriteriaButton_Click(object sender, EventArgs e)
        {
            if (this.rulesListBox.SelectedIndex != -1)
            {
                if (this.criteriaListBox.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Selected criteria will be deleted permenantly. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        if (SelectedRuleList != null)
                        {
                            CrawlerRule rule = (CrawlerRule)this.rulesListBox.SelectedItem;

                            if (rule != null)
                            {
                                CrawlerCriteria crt = (CrawlerCriteria)this.criteriaListBox.SelectedItem;

                                if (crt != null)
                                {
                                    rule.Criterias.Remove(crt);

                                    SelectedRuleList[rule] = rule;

                                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                                        SelectedRuleList.Save(true);
                                    else
                                        ShowDataChangedMessage();

                                    ExplorerUtilities.BindCriterias(rule, this.criteriaListBox);
                                }
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Please select a criteria!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please select a rule!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void criteriaListBox_DoubleClick(object sender, EventArgs e)
        {
            this.editCriteriaButton_Click(this, new EventArgs());
        }

        private void rulesListBox_DoubleClick(object sender, EventArgs e)
        {
            this.editRuleButton_Click(this, new EventArgs());
        }

        private void ruleListCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectedlistindex_ = this.ruleListCombo.SelectedIndex;

            if (!datachanged_)
                LoadListRules();
            else
            {
                if (MessageBox.Show("You have pending data changes. Are you sure you want to navigate?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    loadfromdb_ = true;
                    LoadListRules();
                    datachanged_ = false;
                    this.warningLabel.Text = "";

                    this.applyButton.Enabled = false;
                }
            }
        }

        private void ReleasePreviousDBList()
        {
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                if (this.selectedlistindex_ >= 0)
                {
                    var list = (from ru in db.Rules
                                where ru.Id == currentruleid_ && ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                select ru).SingleOrDefault();

                    if (list != null)
                    {
                        list.Locked = false;

                        db.SubmitChanges();
                    }
                }
            }
        }

        private void LoadListRules()
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                this.criteriaListBox.Items.Clear();
                if (loadfromdb_)
                {
                    // Release lock of previous list
                    ReleasePreviousDBList();

                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var list = (from ru in db.Rules
                                    where ru.Id == (int)this.ruleListCombo.SelectedValue && ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                    select ru).SingleOrDefault();

                        if (list != null)
                        {
                            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                                ExplorerUtilities.BindRules((CrawlerRuleCollection)this.ruleListCombo.SelectedItem, this.rulesListBox);
                            else
                            {
                                if (!list.Locked)
                                {
                                    // lock rulelist
                                    list.Locked = true;

                                    db.SubmitChanges();

                                    currentruleid_ = list.Id;

                                    if (list.Data != null)
                                        SelectedRuleList = (CrawlerRuleCollection)Serializer.Deserialize(list.Data.ToArray());
                                    else
                                        SelectedRuleList = new CrawlerRuleCollection(list.Name);

                                    ExplorerUtilities.BindRules(SelectedRuleList, this.rulesListBox);

                                    this.groupBox1.Enabled = true;
                                    this.groupBox2.Enabled = true;

                                    this.okButton.Enabled = true;
                                    this.applyButton.Enabled = false;
                                }
                                else
                                {
                                    this.groupBox1.Enabled = false;
                                    this.groupBox2.Enabled = false;

                                    this.okButton.Enabled = false;
                                    this.applyButton.Enabled = false;

                                    MessageBox.Show("This rule list is locked by another user! You cannot modify it!\nPlease wait until it is released!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (SelectedRuleList != null)
                        ExplorerUtilities.BindRules(SelectedRuleList, this.rulesListBox);
                }
            }
        }

        private void Rules_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleasePreviousDBList();

            CheckCriteriaItems(true);
        }

        private void CheckCriteriaItems(bool popup)
        {
            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
            {
                //Check itemID criteria existance
                foreach (object ruleObj in this.ruleListCombo.Items)
                {
                    this.warningLabel.Text = "";
                    CrawlerRuleCollection ruleList = (CrawlerRuleCollection)ruleObj;

                    foreach (CrawlerRule rule in ruleList)
                    {
                        if (!ItemIDExists(rule.Criterias))
                        {
                            this.warningLabel.Text = "Rule must have a itemID criteria! [" + ruleList.Name + "->" + rule.Name + "]";

                            if (popup)
                                MessageBox.Show("Rule must have a itemID criteria! [" + ruleList.Name + "->" + rule.Name + "]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

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
                    var list = from ru in db.Rules
                               where ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                               select ru;

                    foreach (Crexta.DataBase.Rule rule in list)
                    {
                        this.warningLabel.Text = "";
                        if (rule.Data != null)
                        {
                            CrawlerRuleCollection ruleList = (CrawlerRuleCollection)Serializer.Deserialize(rule.Data.ToArray());

                            foreach (CrawlerRule r in ruleList)
                            {
                                if (!ItemIDExists(r.Criterias))
                                {
                                    this.warningLabel.Text = "Rule must have a itemID criteria! [" + ruleList.Name + "->" + rule.Name + "]";

                                    if (popup)
                                        MessageBox.Show("Rule must have a itemID criteria! [" + ruleList.Name + "->" + rule.Name + "]", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool ItemIDExists(CrawlerCriteriaCollection criterias)
        {
            bool result = false;

            if (criterias != null)
            {
                foreach (CrawlerCriteria criteria in criterias)
                {
                    string name = criteria.ColumnName.ToLowerInvariant();

                    if (name == "pid" || name == "productid" || name=="id" || name=="itemid" || name=="iid")
                    {
                        result = true;

                        break;
                    }
                }
            }

            return result;
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.addRuleButton_Click(this, new EventArgs());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.editRuleButton_Click(this, new EventArgs());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deleteRuleButton_Click(this, new EventArgs());
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrawlerRule clipboardRule = (CrawlerRule)this.rulesListBox.SelectedItem;

            Clipboard.SetData(DataFormats.Serializable, clipboardRule);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (Clipboard.GetData(DataFormats.Serializable) != null)
            {
                object obj = Clipboard.GetData(DataFormats.Serializable);

                if (obj.GetType() == typeof(CrawlerRule))
                    this.pasteToolStripMenuItem.Enabled = true;
                else
                    this.pasteToolStripMenuItem.Enabled = false;
            }
            else
                this.pasteToolStripMenuItem.Enabled = false;

            if (this.rulesListBox.SelectedIndex >= 0)
            {
                this.copyToolStripMenuItem.Enabled = true;
                this.editToolStripMenuItem.Enabled = true;
                this.deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.copyToolStripMenuItem.Enabled = false;
                this.editToolStripMenuItem.Enabled = false;
                this.deleteToolStripMenuItem.Enabled = false;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrawlerRule clipboardRule = (CrawlerRule)Clipboard.GetData(DataFormats.Serializable);

            if (clipboardRule != null)
            {
                rulepastecount_++;

                clipboardRule.Name = "Copy(" + rulepastecount_.ToString() +") of " + clipboardRule.Name;

                if (SelectedRuleList != null)
                {
                    SelectedRuleList.Add(clipboardRule);

                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        SelectedRuleList.Save(false);
                    else
                        ShowDataChangedMessage();

                    loadfromdb_ = false;
                    LoadListRules();
                }
            }
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.addCriteriaButton_Click(this, new EventArgs());
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.editCriteriaButton_Click(this, new EventArgs());
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.deleteCriteriaButton_Click(this, new EventArgs());
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {
            if (Clipboard.GetData(DataFormats.Serializable) != null)
            {
                object obj = Clipboard.GetData(DataFormats.Serializable);

                if (obj.GetType() == typeof(CrawlerCriteria))
                    this.pasteToolStripMenuItem1.Enabled = true;
                else
                    this.pasteToolStripMenuItem1.Enabled = false;
            }
            else
                this.pasteToolStripMenuItem1.Enabled = false;

            if (this.criteriaListBox.SelectedIndex >= 0)
            {
                this.copyToolStripMenuItem1.Enabled = true;
                this.editToolStripMenuItem1.Enabled = true;
                this.deleteToolStripMenuItem1.Enabled = true;
            }
            else
            {
                this.copyToolStripMenuItem1.Enabled = false;
                this.editToolStripMenuItem1.Enabled = false;
                this.deleteToolStripMenuItem1.Enabled = false;
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrawlerCriteria clipboardCriteria = (CrawlerCriteria)this.criteriaListBox.SelectedItem;

            Clipboard.SetData(DataFormats.Serializable, clipboardCriteria);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CrawlerCriteria clipboardCriteria = (CrawlerCriteria)Clipboard.GetData(DataFormats.Serializable);

            if (clipboardCriteria != null)
            {
                criteriapastecount_++;

                clipboardCriteria.Name = "Copy (" + criteriapastecount_.ToString() + ") of " + clipboardCriteria.Name;

                CrawlerRule criteriaRule = (CrawlerRule)this.rulesListBox.SelectedItem;

                if (criteriaRule != null)
                {
                    criteriaRule.Criterias.Add(clipboardCriteria);

                    SelectedRuleList[criteriaRule] = criteriaRule;

                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        SelectedRuleList.Save(false);
                    else
                        ShowDataChangedMessage();

                    ExplorerUtilities.BindCriterias(criteriaRule, this.criteriaListBox);
                }
            }
        }

        private void ruleUpButton_Click(object sender, EventArgs e)
        {
            if (rulesListBox.SelectedIndex > 0)
            {
                try
                {
                    if (SelectedRuleList != null)
                    {
                        int index = rulesListBox.SelectedIndex;

                        CrawlerRule selected = SelectedRuleList[index];
                        SelectedRuleList[index] = SelectedRuleList[index - 1];
                        SelectedRuleList[index - 1] = selected;

                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                            SelectedRuleList.Save(false);
                        else
                            ShowDataChangedMessage();

                        loadfromdb_ = false;
                        //LoadRules();
                        LoadListRules();

                        this.rulesListBox.SelectedIndex = index - 1;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void ruleDownButton_Click(object sender, EventArgs e)
        {
            if (rulesListBox.SelectedIndex < rulesListBox.Items.Count - 1)
            {
                try
                {
                    if (SelectedRuleList != null)
                    {
                        int index = rulesListBox.SelectedIndex;

                        CrawlerRule selected = SelectedRuleList[index];
                        SelectedRuleList[index] = SelectedRuleList[index + 1];
                        SelectedRuleList[index + 1] = selected;

                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                            SelectedRuleList.Save(false);
                        else
                            ShowDataChangedMessage();

                        loadfromdb_ = false;
                        //LoadRules();
                        LoadListRules();

                        this.rulesListBox.SelectedIndex = index + 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void ShowDataChangedMessage()
        {
            datachanged_ = true;
            this.applyButton.Enabled = true;
            this.warningLabel.Text = "Data changed! Please save your work!";
        }

        private void criteriaUpButton_Click(object sender, EventArgs e)
        {
            if (criteriaListBox.SelectedIndex > 0)
            {
                try
                {
                    CrawlerRule selectedRule = (CrawlerRule)this.rulesListBox.SelectedItem;
                    CrawlerCriteria selectedCriteria = (CrawlerCriteria)this.criteriaListBox.SelectedItem;

                    if (selectedCriteria != null)
                    {
                        int rindex = rulesListBox.SelectedIndex;
                        int index = criteriaListBox.SelectedIndex;

                        CrawlerCriteria selected = selectedRule.Criterias[index];
                        selectedRule.Criterias[index] = selectedRule.Criterias[index - 1];
                        selectedRule.Criterias[index - 1] = selected;

                        SelectedRuleList[selectedRule] = selectedRule;

                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                            SelectedRuleList.Save(false);
                        else
                            ShowDataChangedMessage();

                        loadfromdb_ = false;
                        LoadListRules();

                        this.rulesListBox.SelectedIndex = rindex;
                        this.criteriaListBox.SelectedIndex = index - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void criteriaDownButton_Click(object sender, EventArgs e)
        {
            if (criteriaListBox.SelectedIndex < criteriaListBox.Items.Count - 1)
            {
                try
                {
                    CrawlerRule selectedRule = (CrawlerRule)this.rulesListBox.SelectedItem;
                    CrawlerCriteria selectedCriteria = (CrawlerCriteria)this.criteriaListBox.SelectedItem;

                    if (selectedCriteria != null)
                    {
                        int rindex = rulesListBox.SelectedIndex;
                        int index = criteriaListBox.SelectedIndex;

                        CrawlerCriteria selected = selectedRule.Criterias[index];
                        selectedRule.Criterias[index] = selectedRule.Criterias[index + 1];
                        selectedRule.Criterias[index + 1] = selected;

                        SelectedRuleList[selectedRule] = selectedRule;

                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                            SelectedRuleList.Save(false);
                        else
                            ShowDataChangedMessage();

                        loadfromdb_ = false;
                        LoadListRules();

                        this.rulesListBox.SelectedIndex = rindex;
                        this.criteriaListBox.SelectedIndex = index + 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void SaveRuleListToDatabase(bool backupfirst)
        {
            if (this.ruleListCombo.SelectedIndex >= 0)
            {
                int listid = (int)this.ruleListCombo.SelectedValue;

                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                if (db != null)
                {
                    var list = (from li in db.Rules
                                where li.Id == listid && li.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                               select li).SingleOrDefault();

                    if (list != null)
                    {
                        if (SelectedRuleList != null)
                        {
                            if (backupfirst)
                            {
                                if (list.Data != null)
                                {
                                    RuleBackup backup = new RuleBackup();
                                    backup.RuleId = listid;
                                    backup.Name = list.Name;
                                    backup.Data = list.Data.ToArray();
                                    backup.Date = DateTime.Now;

                                    db.RuleBackups.InsertOnSubmit(backup);
                                    db.SubmitChanges();
                                }
                            }

                            list.Data = Serializer.Serialize(SelectedRuleList);
                            list.Locked = false;

                            db.SubmitChanges();
                        }
                    }
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // save current list data
            if (datachanged_)
                SaveRuleListToDatabase(true);

            SelectedRuleList = null;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            // save current list data
            if (datachanged_)
                SaveRuleListToDatabase(true);

            this.loadfromdb_ = true;

            SelectedRuleList = null;

            this.warningLabel.Text = "";

            this.datachanged_ = false;

            LoadRules();

            this.applyButton.Enabled = false;
        }

        private void cancelButton_Click_1(object sender, EventArgs e)
        {
            SelectedRuleList = null;

            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
