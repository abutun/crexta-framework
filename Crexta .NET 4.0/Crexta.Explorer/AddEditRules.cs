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

using Crexta.Common;
using Crexta.Common.Enums;
using Crexta.Common.Crawler.CriteriaItems;
using Crexta.Common.Crawler;
using Crexta.Common.Crawler.Interfaces;

namespace Crexta.Explorer
{
    public partial class AddEditRules : Form
    {
        private CrawlerRuleCollection innerRuleList = null;
        private CrawlerRule innerRule = null;

        public ClickItem innerClickItem = null;

        public AddEditRules(CrawlerRuleCollection rulelist, CrawlerRule rule)
        {
            InitializeComponent();

            if (rulelist == null)
            {
                MessageBox.Show("Null rule list value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                this.Close();
            }

            this.innerRule = rule;
                        
            this.innerRuleList = rulelist;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.ruleURLRegex.Text.Trim() != "")
            {
                if (this.innerRule != null)
                {
                    //update
                    this.innerRule.Name = this.ruleNameText.Text;
                    this.innerRule.DatabaseTableName = this.ruleTableNameText.Text;
                    this.innerRule.URLMatchRegex = this.ruleURLRegex.Text.Trim();
                    this.innerRule.Encoding = (Encoding)this.ruleEncoding.SelectedItem;

                    // also update regex pattern if any overriden RegularExpressionItem objects exists
                    foreach (CrawlerCriteria criteria in this.innerRule.Criterias)
                    {
                        foreach (ICrawlerCriteriaItem item in criteria.ExecutionPipelineItems)
                        {
                            if (item.GetType() == typeof(RegularExpressionItem))
                            {
                                RegularExpressionItem regexItem = (RegularExpressionItem)item;
                                if (regexItem.OverrideRulePattern)
                                    regexItem.Pattern = this.ruleURLRegex.Text.Trim();
                            }
                        }
                    }

                    this.innerRule.ClickItem = this.innerClickItem;

                    this.innerRuleList[this.innerRule] = this.innerRule;

                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        this.innerRuleList.Save(true);
                }
                else
                {
                    //insert
                    CrawlerRule rule = new CrawlerRule(this.ruleNameText.Text);

                    rule.DatabaseTableName = this.ruleTableNameText.Text;
                    rule.URLMatchRegex = this.ruleURLRegex.Text.Trim();
                    rule.Encoding = (Encoding)this.ruleEncoding.SelectedItem;

                    if (!this.innerRuleList.Contains(rule))
                        this.innerRuleList.Add(rule);

                    if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        this.innerRuleList.Save(true);
                }

                if (ExplorerUtilities.DATASTORAGE == DataStorage.DB)
                    Rules.SelectedRuleList = this.innerRuleList;

                this.DialogResult = DialogResult.OK;

                this.Close();
            }else
                MessageBox.Show("No regex pattern defined! Please provide one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

        }

        private void AddEditRules_Load(object sender, EventArgs e)
        {
            ExplorerUtilities.LoadEncodings(this.ruleEncoding);

            BindRule();
        }

        private void BindRule()
        {
            if (this.innerRule != null)
            {
                this.ruleNameText.Text = this.innerRule.Name;
                this.ruleTableNameText.Text = this.innerRule.DatabaseTableName;
                this.ruleURLRegex.Text = this.innerRule.URLMatchRegex.Trim();
                this.innerClickItem = this.innerRule.ClickItem;
                this.ruleEncoding.SelectedItem = this.innerRule.Encoding;

                if (this.innerRule.ClickItem != null)
                    this.clickItemTotalLabel.Text = "(Total 1)";

                this.ruleClickItem.Enabled = true;
            }
            else
                this.ruleClickItem.Enabled = false;
        }

        private void ruleClickItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditClick addEditClickFrm = new AddEditClick(this);

            if (addEditClickFrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.innerRule.ClickItem = this.innerClickItem;

            BindRule();
        }

    }
}
