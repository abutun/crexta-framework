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
    public partial class AddEditHTMLNodeCollection : Form
    {
        private AddEditCriteria parentform_ = null;

        private int index_ = -1;

        private string name_ = "";

        public AddEditHTMLNodeCollection(AddEditCriteria frm, int index, string defaultname)
        {
            InitializeComponent();

            this.parentform_ = frm;

            this.index_ = index;

            this.name_ = defaultname;
        }

        private void AddEditHTMLNodeCollection_Load(object sender, EventArgs e)
        {
            if (this.parentform_ != null)
            {
                try
                {
                    if (this.index_ != -1)
                    {
                        HTMLNodeCollectionItem item = (HTMLNodeCollectionItem)this.parentform_.executionPipelineItems_[this.index_];

                        if (item != null)
                        {
                            this.htmlNodeColNameText.Text = item.Name;
                            this.htmlNodeColResultIndexText.Text = item.ResultNodeIndex.ToString();
                            this.htmlNodeColReturnOnlyTextCheck.Checked = item.ReturnOnlyNodeText;
                            this.htmlNodeColXPathText.Text = item.XPath;
                            this.returnAllNodesCheck.Checked = item.ReturnAllNodes;
                        }
                    }
                    else
                        this.htmlNodeColNameText.Text = this.name_;
                }
                catch
                {
                    MessageBox.Show("Invalid item type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            HTMLNodeCollectionItem item = new HTMLNodeCollectionItem(this.htmlNodeColNameText.Text, this.htmlNodeColXPathText.Text);

            item.ResultNodeIndex = int.Parse(this.htmlNodeColResultIndexText.Text);
            item.ReturnOnlyNodeText = this.htmlNodeColReturnOnlyTextCheck.Checked;
            item.ReturnAllNodes = this.returnAllNodesCheck.Checked;

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

        private void returnAllNodesCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (returnAllNodesCheck.Checked)
            {
                this.htmlNodeColResultIndexText.Text = "0";
                this.htmlNodeColResultIndexText.Enabled = false;
                this.htmlNodeColReturnOnlyTextCheck.Checked = false;
                this.htmlNodeColReturnOnlyTextCheck.Enabled = false;
            }
            else
            {
                this.htmlNodeColResultIndexText.Text = "0";
                this.htmlNodeColResultIndexText.Enabled = true;
                this.htmlNodeColReturnOnlyTextCheck.Checked = false;
                this.htmlNodeColReturnOnlyTextCheck.Enabled = true;
            }
        }
    }
}
