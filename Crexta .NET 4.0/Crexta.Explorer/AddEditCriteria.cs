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
using System.Windows.Forms;

using Crexta.Common;
using Crexta.Common.Enums;
using Crexta.Common.Crawler;
using Crexta.Common.Crawler.Interfaces;
using Crexta.Common.Crawler.CriteriaItems;
using Crexta.DataBase;

namespace Crexta.Explorer
{
    public partial class AddEditCriteria : Form
    {
        private CrawlerRuleCollection innerRuleList_ = null;

        public CrawlerRule innerRule_ = null;

        private CrawlerCriteria orginal_ = null;

        private CrawlerCriteria criteria_ = null;

        private CrawlerExcludeListCollection excludelist_ = new CrawlerExcludeListCollection();

        public CrawlerCriteriaItemCollection executionPipelineItems_ = new CrawlerCriteriaItemCollection();

        public AddEditCriteria(CrawlerRuleCollection rulelist, CrawlerRule rule, CrawlerCriteria criteria)
        {
            InitializeComponent();

            if (rulelist == null)
            {
                MessageBox.Show("Null rule list value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                this.Close();
            }

            this.innerRuleList_ = rulelist;

            this.innerRule_ = rule;

            this.criteria_ = this.orginal_ = criteria;

            if (this.criteria_ != null)
            {
                this.excludelist_ = this.criteria_.ExcludeList;
                this.executionPipelineItems_ = this.criteria_.ExecutionPipelineItems;
            }
        }

        public void UpdateExcludeList(CrawlerExcludeListCollection list)
        {
            this.excludelist_ = list;
        }

        private void AddEditCriteria_Load(object sender, EventArgs e)
        {
            ExplorerUtilities.LoadColumns(this.criteriaColumnNameCombo, 0);

            LoadCriteria();
        }

        private void LoadCriteria()
        {
            if (this.criteria_ != null)
            {
                if (this.innerRule_ != null)
                {
                    this.criteriaNameText.Text = this.criteria_.Name;

                    for (int i = 0; i < this.criteriaColumnNameCombo.Items.Count;i++ )
                    {
                        DbField current = (DbField)criteriaColumnNameCombo.Items[i];
                        if (current.FieldName == this.criteria_.ColumnName)
                        {
                            this.criteriaColumnNameCombo.SelectedIndex = i;
                            break;
                        }
                    }

                    this.criteriaDefaultValueText.Text = this.criteria_.DefaultText;
                    this.criteriaClearScriptTagsCheck.Checked = this.criteria_.ClearScriptTags;
                    this.criteriaClearHTMLCommentCheck.Checked = this.criteria_.ClearHTMLComments;
                    this.criteriaClearHTMLTagsCheck.Checked = this.criteria_.ClearHTMLTags;
                    this.criteriaStripASCIICodesCheck.Checked = this.criteria_.StripASCIICodes;
                    this.criteriaClearWhitespacesCheck.Checked = this.criteria_.ClearWhiteSpaces;
                    this.criteriaUppercaseCheck.Checked = this.criteria_.UpperCaseValues;
                    this.criteriaLowercaseCheck.Checked = this.criteria_.LowerCaseValues;
                    this.criteriaUseURLForMatchCheck.Checked = this.criteria_.UseURLForMatch;
                    this.criteriaDefaultTextCaseCheck.Checked = this.criteria_.DefaultTextCaseValues;

                    this.criteriaExtraFieldIText.Text = this.criteria_.XFieldI;
                    this.criteriaExtraFieldIIText.Text = this.criteria_.XFieldII;
                    this.criteriaExtraFieldIIIText.Text = this.criteria_.XFieldIII;

                    this.executionPipelineItems_ = this.criteria_.ExecutionPipelineItems;
                    foreach (ICrawlerCriteriaItem item in this.criteria_.ExecutionPipelineItems)
                        this.criteriaItemsList.Items.Add(item);

                    this.excludelist_ = this.criteria_.ExcludeList;

                    this.criteriaExcludeListTotalLabel.Text = "(Total=" + this.criteria_.ExcludeList.Count().ToString() +")";
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.criteriaColumnNameCombo.SelectedIndex >= 0)
            {
                DbField selectedField = (DbField)this.criteriaColumnNameCombo.SelectedItem;

                if (this.criteria_ != null)
                {
                    //Update
                    if (this.innerRule_ != null)
                    {
                        this.criteria_.URL = "";
                        this.criteria_.Name = this.criteriaNameText.Text;
                        this.criteria_.ColumnName = selectedField.FieldName;
                        this.criteria_.ColumnType = selectedField.FieldType;

                        this.criteria_.DefaultText = this.criteriaDefaultValueText.Text;

                        this.criteria_.StripASCIICodes = this.criteriaStripASCIICodesCheck.Checked;
                        this.criteria_.LowerCaseValues = this.criteriaLowercaseCheck.Checked;
                        this.criteria_.UpperCaseValues = this.criteriaUppercaseCheck.Checked;
                        this.criteria_.ClearHTMLComments = this.criteriaClearHTMLCommentCheck.Checked;
                        this.criteria_.ClearHTMLTags = this.criteriaClearHTMLTagsCheck.Checked;
                        this.criteria_.ClearScriptTags = this.criteriaClearScriptTagsCheck.Checked;
                        this.criteria_.ClearWhiteSpaces = this.criteriaClearWhitespacesCheck.Checked;
                        this.criteria_.UseURLForMatch = this.criteriaUseURLForMatchCheck.Checked;
                        this.criteria_.DefaultTextCaseValues = this.criteriaDefaultTextCaseCheck.Checked;

                        this.criteria_.XFieldI = this.criteriaExtraFieldIText.Text;
                        this.criteria_.XFieldII = this.criteriaExtraFieldIIText.Text;
                        this.criteria_.XFieldIII = this.criteriaExtraFieldIIIText.Text;

                        this.criteria_.ExecutionPipelineItems = this.executionPipelineItems_;

                        this.criteria_.ExcludeList = this.excludelist_;

                        //Update criteria
                        if (this.innerRule_.Criterias.Contains(this.criteria_))
                        {
                            this.innerRule_.Criterias[this.criteria_] = this.criteria_;

                            this.innerRuleList_[this.innerRule_] = this.innerRule_;

                            if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                                this.innerRuleList_.Save(true);
                            else
                                Rules.SelectedRuleList = this.innerRuleList_;

                            this.DialogResult = DialogResult.OK;

                            this.Close();
                        }
                        else
                            MessageBox.Show("Criteria not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    //Insert
                    CrawlerCriteria crt = new CrawlerCriteria();

                    crt.URL = "";
                    crt.Name = this.criteriaNameText.Text;
                    crt.ColumnName = selectedField.FieldName;
                    crt.ColumnType = selectedField.FieldType;

                    crt.DefaultText = this.criteriaDefaultValueText.Text;

                    crt.StripASCIICodes = this.criteriaStripASCIICodesCheck.Checked;
                    crt.LowerCaseValues = this.criteriaLowercaseCheck.Checked;
                    crt.UpperCaseValues = this.criteriaUppercaseCheck.Checked;
                    crt.ClearHTMLComments = this.criteriaClearHTMLCommentCheck.Checked;
                    crt.ClearHTMLTags = this.criteriaClearHTMLTagsCheck.Checked;
                    crt.ClearScriptTags = this.criteriaClearScriptTagsCheck.Checked;
                    crt.ClearWhiteSpaces = this.criteriaClearWhitespacesCheck.Checked;
                    crt.UseURLForMatch = this.criteriaUseURLForMatchCheck.Checked;
                    crt.DefaultTextCaseValues = this.criteriaDefaultTextCaseCheck.Checked;

                    crt.XFieldI = this.criteriaExtraFieldIText.Text;
                    crt.XFieldII = this.criteriaExtraFieldIIText.Text;
                    crt.XFieldIII = this.criteriaExtraFieldIIIText.Text;

                    crt.ExecutionPipelineItems = this.executionPipelineItems_;

                    crt.ExcludeList = this.excludelist_;

                    if (!this.innerRule_.Criterias.Contains(crt))
                    {
                        this.innerRule_.Criterias.Add(crt);

                        this.innerRuleList_[this.innerRule_] = this.innerRule_;

                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                            this.innerRuleList_.Save(true);
                        else
                            Rules.SelectedRuleList = this.innerRuleList_;

                        this.DialogResult = DialogResult.OK;

                        this.Close();
                    }
                    else
                        MessageBox.Show("This criteria already exists! Please select a different name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            else
                MessageBox.Show("Please determine DB mapping for the criteria!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            ResetCriteria();

            this.Close();
        }

        private void ResetCriteria()
        {
            //Reload orginal criteria
            if (this.orginal_ != null && this.innerRule_ != null)
            {
                this.innerRule_.Criterias[this.orginal_] = this.orginal_;

                this.innerRuleList_[this.innerRule_] = this.innerRule_;

                if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                    this.innerRuleList_.Save(true);
                else
                    Rules.SelectedRuleList = this.innerRuleList_;
            }
        }

        private void criteriaExcludeListLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExcludeList listFrm = new ExcludeList(this, this.criteria_, this.excludelist_);

            listFrm.ShowDialog();

            this.criteriaExcludeListTotalLabel.Text = "(Total=" + this.excludelist_.Count().ToString() + ")";
        }

        private void criteriaUppercaseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (criteriaUppercaseCheck.Checked)
            {
                this.criteriaLowercaseCheck.Checked = false;
                this.criteriaDefaultTextCaseCheck.Checked = false;
            }
        }

        private void criteriaLowercaseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (criteriaLowercaseCheck.Checked)
            {
                this.criteriaUppercaseCheck.Checked = false;
                this.criteriaDefaultTextCaseCheck.Checked = false;
            }
        }

        private void criteriaBasicHTMLButton_Click(object sender, EventArgs e)
        {
            AddEditBasicHTML basicFrm = new AddEditBasicHTML(this, -1, this.criteriaNameText.Text);

            if (basicFrm.ShowDialog() == DialogResult.OK)
                BindCriteriaItems();
        }

        private void BindCriteriaItems()
        {
            this.criteriaItemsList.Items.Clear();
            foreach (ICrawlerCriteriaItem item in this.executionPipelineItems_)
                this.criteriaItemsList.Items.Add(item);
        }

        private void criteriaHTMLNodeButton_Click(object sender, EventArgs e)
        {
            AddEditHTMLNode htmlNodeFrm = new AddEditHTMLNode(this, -1, this.criteriaNameText.Text);

            if (htmlNodeFrm.ShowDialog() == DialogResult.OK)
                BindCriteriaItems();
        }

        private void criteriaHTMLNodeCollectionButton_Click(object sender, EventArgs e)
        {
            AddEditHTMLNodeCollection htmlNodeColFrm = new AddEditHTMLNodeCollection(this, -1, this.criteriaNameText.Text);

            if (htmlNodeColFrm.ShowDialog() == DialogResult.OK)
                BindCriteriaItems();
        }

        private void criteriaRegexButton_Click(object sender, EventArgs e)
        {
            AddEditRegularExpression regexFrm = new AddEditRegularExpression(this, -1, this.criteriaNameText.Text);

            if (regexFrm.ShowDialog() == DialogResult.OK)
                BindCriteriaItems();
        }

        private void criteriaDefaultTextCaseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.criteriaDefaultTextCaseCheck.Checked)
            {
                this.criteriaLowercaseCheck.Checked = false;
                this.criteriaUppercaseCheck.Checked = false;
            }
        }

        private void AddEditCriteria_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetCriteria();
        }

        private void criteriaItemEditButton_Click(object sender, EventArgs e)
        {
            if (this.criteriaItemsList.SelectedIndex != -1)
            {
                ICrawlerCriteriaItem item = (ICrawlerCriteriaItem)this.criteriaItemsList.SelectedItem;

                if (item != null)
                {
                    if (item.GetType() == typeof(ClickItem))
                    {
                        AddEditClick clickFrm = new AddEditClick(this, this.criteriaItemsList.SelectedIndex, "");

                        if (clickFrm.ShowDialog() == DialogResult.OK)
                            BindCriteriaItems();
                    }
                    else if (item.GetType() == typeof(BasicHTMLItem))
                    {
                        AddEditBasicHTML basicFrm = new AddEditBasicHTML(this, this.criteriaItemsList.SelectedIndex, "");

                        if (basicFrm.ShowDialog() == DialogResult.OK)
                            BindCriteriaItems();
                    }
                    else if (item.GetType() == typeof(HTMLNodeItem))
                    {
                        AddEditHTMLNode nodeFrm = new AddEditHTMLNode(this, this.criteriaItemsList.SelectedIndex, "");

                        if (nodeFrm.ShowDialog() == DialogResult.OK)
                            BindCriteriaItems();
                    }
                    else if (item.GetType() == typeof(HTMLNodeCollectionItem))
                    {
                        AddEditHTMLNodeCollection nodeColFrm = new AddEditHTMLNodeCollection(this, this.criteriaItemsList.SelectedIndex, "");

                        if (nodeColFrm.ShowDialog() == DialogResult.OK)
                            BindCriteriaItems();
                    }
                    else if (item.GetType() == typeof(RegularExpressionItem))
                    {
                        AddEditRegularExpression regexFrm = new AddEditRegularExpression(this, this.criteriaItemsList.SelectedIndex, "");

                        if (regexFrm.ShowDialog() == DialogResult.OK)
                            BindCriteriaItems();
                    }
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void criteriaItemDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.criteriaItemsList.SelectedIndex != -1)
            {
                if (MessageBox.Show("Selected item will be deleted permenantly. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    this.executionPipelineItems_.RemoveAt(this.criteriaItemsList.SelectedIndex);

                    BindCriteriaItems();
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void criteriaItemUpButton_Click(object sender, EventArgs e)
        {
            if (this.criteriaItemsList.SelectedIndex != -1)
            {
                if (this.criteriaItemsList.SelectedIndex != 0)
                {
                    ICrawlerCriteriaItem tmpItem = this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex - 1];
                    this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex - 1] = this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex];
                    this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex] = tmpItem;

                    BindCriteriaItems();
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void criteriaItemDownButton_Click(object sender, EventArgs e)
        {
            if (this.criteriaItemsList.SelectedIndex != -1)
            {
                if (this.criteriaItemsList.SelectedIndex != this.criteriaItemsList.Items.Count - 1)
                {
                    ICrawlerCriteriaItem tmpItem = this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex + 1];
                    this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex + 1] = this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex];
                    this.executionPipelineItems_[this.criteriaItemsList.SelectedIndex] = tmpItem;

                    BindCriteriaItems();
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void criteriaItemsList_DoubleClick(object sender, EventArgs e)
        {
            this.criteriaItemEditButton_Click(this, new EventArgs());
        }

        private void criteriaClickButton_Click(object sender, EventArgs e)
        {
            AddEditClick clickFrm = new AddEditClick(this, -1, this.criteriaNameText.Text);

            if (clickFrm.ShowDialog() == DialogResult.OK)
                BindCriteriaItems();
        }

        private void criteriaColumnNameCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get db field item
            try
            {
                DbField field = (DbField)this.criteriaColumnNameCombo.SelectedItem;
 
                // set default value
                this.criteriaDefaultValueText.Text = field.DefaultValue;

                // set type
                this.columnTypeTextBox.Text = field.FieldType;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
