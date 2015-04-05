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
using System.Text.RegularExpressions;

using Crexta.Common.Crawler.CriteriaItems;

namespace Crexta.Explorer
{
    public partial class AddEditRegularExpression : Form
    {
        private AddEditCriteria parentform_ = null;

        private int index_ = -1;

        private string name_ = "";

        public AddEditRegularExpression(AddEditCriteria frm, int index, string defaultname)
        {
            InitializeComponent();

            this.parentform_ = frm;

            this.index_ = index;

            this.name_ = defaultname;
        }

        private void AddEditRegularExpression_Load(object sender, EventArgs e)
        {
            if (this.parentform_ != null)
            {
                try
                {
                    if (this.index_ != -1)
                    {
                        RegularExpressionItem item = (RegularExpressionItem)this.parentform_.executionPipelineItems_[this.index_];

                        if (item != null)
                        {
                            this.regexNameText.Text = item.Name;
                            this.regexGroupIndexText.Text = item.GroupIndex.ToString();
                            this.regexOptionCompiledCheck.Checked = (item.Options & RegexOptions.Compiled) == RegexOptions.Compiled ? true : false;
                            this.regexOptionCultureCheck.Checked = (item.Options & RegexOptions.CultureInvariant) == RegexOptions.CultureInvariant ? true : false;
                            this.regexOptionIgnoreCaseCheck.Checked = (item.Options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase ? true : false;
                            this.regexOptionMultilineCheck.Checked = (item.Options & RegexOptions.Multiline) == RegexOptions.Multiline ? true : false;
                            this.regexOptionSinglelineCheck.Checked = (item.Options & RegexOptions.Singleline) == RegexOptions.Singleline ? true : false;
                            this.regexPatternText.Text = item.Pattern.Trim();
                            this.regexUseGroupCheck.Checked = item.UseGroupIndex;
                            this.regexUseResultAsNodeCheck.Checked = item.UseResultAsHtmlNode;
                            this.regexResultPrefixText.Text = item.ResultPrefix;
                            this.resultMatchIndex.Text = item.ResultIndex.ToString();
                            this.returnAllMatchesCheck.Checked = item.ReturnAllMaches;
                            this.overrideRulePatternCheckBox.Checked = item.OverrideRulePattern;
                        }
                    }
                    else
                        this.regexNameText.Text = this.name_;
                }
                catch
                {
                    MessageBox.Show("Invalid item type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            RegularExpressionItem item = new RegularExpressionItem(this.regexNameText.Text, this.regexPatternText.Text.Trim(), int.Parse(this.resultMatchIndex.Text));

            item.ResultPrefix = this.regexResultPrefixText.Text;
            item.UseGroupIndex = this.regexUseGroupCheck.Checked;
            item.UseResultAsHtmlNode = this.regexUseResultAsNodeCheck.Checked;
            item.ReturnAllMaches = this.returnAllMatchesCheck.Checked;
            item.GroupIndex = int.Parse(this.regexGroupIndexText.Text);
            item.OverrideRulePattern = this.overrideRulePatternCheckBox.Checked;
            if (this.regexOptionCompiledCheck.Checked)
                item.Options = item.Options | RegexOptions.Compiled;
            if (this.regexOptionCultureCheck.Checked)
                item.Options = item.Options | RegexOptions.CultureInvariant;
            if (this.regexOptionIgnoreCaseCheck.Checked)
                item.Options = item.Options | RegexOptions.IgnoreCase;
            if (this.regexOptionMultilineCheck.Checked)
                item.Options = item.Options | RegexOptions.Multiline;
            if (this.regexOptionSinglelineCheck.Checked)
                item.Options = item.Options | RegexOptions.Singleline;

            if (this.index_ == -1)
            {
                //Insert
                this.parentform_.executionPipelineItems_.Add(item);
            }
            else
            {
                //Update
                this.parentform_.executionPipelineItems_[this.index_] = item;
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void returnAllMatchesCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (returnAllMatchesCheck.Checked)
            {
                this.resultMatchIndex.Text = "0";
                this.resultMatchIndex.Enabled = false;
            }
            else
            {
                this.resultMatchIndex.Text = "0";
                this.resultMatchIndex.Enabled = true;
            }
        }

        private void regexGroupIndexText_TextChanged(object sender, EventArgs e)
        {
            int val = 0;
            if (int.TryParse(this.regexGroupIndexText.Text, out val))
            {
                if (val <= 0)
                    this.regexUseGroupCheck.Checked = false;
                else
                    this.regexUseGroupCheck.Checked = true;
            }
        }

        private void regexUseGroupCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.regexUseGroupCheck.Checked)
                this.regexGroupIndexText.Text = "0";
        }

        private void overrideRulePatternCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.regexPatternText.Enabled = !this.overrideRulePatternCheckBox.Checked;
            if (this.overrideRulePatternCheckBox.Checked)
                this.regexPatternText.Text = this.parentform_.innerRule_.URLMatchRegex;
        }
    }
}
