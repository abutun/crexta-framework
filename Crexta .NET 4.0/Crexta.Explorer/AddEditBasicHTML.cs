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

using Crexta.Common.Crawler.CriteriaItems;

namespace Crexta.Explorer
{
    public partial class AddEditBasicHTML : Form
    {
        private AddEditCriteria parentform_ = null;

        private int index_ = -1;

        private string name_ = "";

        public AddEditBasicHTML(AddEditCriteria frm, int index, string defaultname)
        {
            InitializeComponent();

            this.parentform_ = frm;

            this.index_ = index;

            this.name_ = defaultname;
        }

        private void AddEditBasicHTML_Load(object sender, EventArgs e)
        {
            if (this.parentform_ != null)
            {
                try
                {
                    if (this.index_ != -1)
                    {
                        BasicHTMLItem item = (BasicHTMLItem)this.parentform_.executionPipelineItems_[this.index_];

                        if (item != null)
                        {
                            this.basicHTMLNameText.Text = item.Name;
                            this.basicHTMLPrefixText.Text = item.ResultPrefix;
                            this.basicHTMLResultHtmlNodeCheck.Checked = item.UseResultAsHtmlNode;
                            this.basicHTMLBeginText.Text = item.HTMLBegin;
                            this.basicHTMLEndText.Text = item.HTMLEnd;
                            this.basicHTMLEndCountText.Text = item.EndCount.ToString();
                        }
                    }
                    else
                        this.basicHTMLNameText.Text = this.name_;
                }
                catch
                {
                    MessageBox.Show("Invalid item type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            BasicHTMLItem item = new BasicHTMLItem(this.basicHTMLNameText.Text, this.basicHTMLBeginText.Text, this.basicHTMLEndText.Text,
                        int.Parse(this.basicHTMLEndCountText.Text), this.basicHTMLResultHtmlNodeCheck.Checked);

            item.ResultPrefix = this.basicHTMLPrefixText.Text;

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
    }
}
