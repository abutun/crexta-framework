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
using System.Windows.Forms;

using Crexta.Common.Crawler.CriteriaItems;

namespace Crexta.Explorer
{
    public partial class AddEditHTMLNode : Form
    {
        private AddEditCriteria parentform_ = null;

        private int index_ = -1;

        private string name_ = "";

        private List<string> excluderegexlist_ = new List<string>();
        private List<int> excludechildnodelist_ = new List<int>();

        public AddEditHTMLNode(AddEditCriteria frm, int index, string defaultname)
        {
            InitializeComponent();

            this.parentform_ = frm;

            this.index_ = index;

            this.name_ = defaultname;
        }

        private void AddEditHTMLNode_Load(object sender, EventArgs e)
        {
            if (this.parentform_ != null)
            {
                try
                {
                    if (this.index_ != -1)
                    {
                        HTMLNodeItem item = (HTMLNodeItem)this.parentform_.executionPipelineItems_[this.index_];

                        if (item != null)
                        {
                            this.htmlNodeAttributeText.Text = item.AttributeName;
                            this.htmlNodeNameText.Text = item.Name;
                            this.htmlNodePrefixText.Text = item.ResultPrefix;
                            this.htmlNodeReturnNodeHTMLCheck.Checked = item.ReturnNodeHtmlAsText;
                            this.htmlNodeReturnOnlyTextCheck.Checked = item.ReturnOnlyNodeText;
                            this.htmlNodeXPathText.Text = item.XPath;

                            this.excludechildnodelist_ = item.ExcludeChildNodeIndexes;

                            BindChildIndexList();

                            this.excluderegexlist_ = item.ExcludeRegexList;

                            BindExcludeRegexList();
                        }
                    }
                    else
                        this.htmlNodeNameText.Text = this.name_;
                }
                catch
                {
                    MessageBox.Show("Invalid item type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void BindExcludeRegexList()
        {
            this.htmlNodeExcludeRegexList.Items.Clear();
            foreach (string s in this.excluderegexlist_)
                this.htmlNodeExcludeRegexList.Items.Add(s);
        }

        private void BindChildIndexList()
        {
            this.htmlNodeExcludeChildIndexList.Items.Clear();
            foreach (int i in this.excludechildnodelist_)
                this.htmlNodeExcludeChildIndexList.Items.Add(i);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            HTMLNodeItem item = new HTMLNodeItem(this.htmlNodeNameText.Text, this.htmlNodeXPathText.Text, this.htmlNodeAttributeText.Text, this.htmlNodeReturnOnlyTextCheck.Checked);

            item.ExcludeChildNodeIndexes = this.excludechildnodelist_;
            item.ExcludeRegexList = this.excluderegexlist_;
            item.ResultPrefix = this.htmlNodePrefixText.Text;
            item.ReturnNodeHtmlAsText = this.htmlNodeReturnNodeHTMLCheck.Checked;

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

        private void htmlNodeExcludeRegexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeRegexList.SelectedIndex != -1)
            {
                this.currentExcludeRegexText.Text = (string)this.htmlNodeExcludeRegexList.SelectedItem;
            }
        }

        private void htmlNodeExcludeChildIndexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeChildIndexList.SelectedIndex != -1)
            {
                this.currentExcludeChildText.Text = this.htmlNodeExcludeChildIndexList.SelectedItem.ToString();
            }
        }

        private void htmlNodeExcludeListAddButton_Click(object sender, EventArgs e)
        {
            if (this.currentExcludeRegexText.Text != "")
            {
                this.excluderegexlist_.Add(this.currentExcludeRegexText.Text);

                BindExcludeRegexList();
            }
            else
                MessageBox.Show("Please provide a value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void htmlNodeExcludeChildIndexListAddButton_Click(object sender, EventArgs e)
        {
            if (this.currentExcludeChildText.Text != "")
            {
                try
                {
                    this.excludechildnodelist_.Add(int.Parse(this.currentExcludeChildText.Text));
                }
                catch
                {
                    MessageBox.Show("Not an integer value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }

                BindChildIndexList();
            }
            else
                MessageBox.Show("Please provide a value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void htmlNodeExcludeListUpdateButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeRegexList.SelectedIndex != -1)
            {
                if (this.currentExcludeRegexText.Text != "")
                {
                    this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex] = this.currentExcludeRegexText.Text;

                    BindExcludeRegexList();
                }
                else
                    MessageBox.Show("Please provide a value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void htmlNodeExcludeChildIndexListUpdateButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeChildIndexList.SelectedIndex != -1)
            {
                if (this.currentExcludeChildText.Text != "")
                {
                    try
                    {
                        this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex] = int.Parse(this.currentExcludeChildText.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Not an integer value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }

                    BindChildIndexList();
                }
                else
                    MessageBox.Show("Please provide a value!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void htmlNodeExcludeListDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeRegexList.SelectedIndex != -1)
            {
                if (MessageBox.Show("Selected item will be deleted permenantly. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    this.excluderegexlist_.RemoveAt(this.htmlNodeExcludeRegexList.SelectedIndex);

                    BindExcludeRegexList();
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void htmlNodeExcludeChildIndexListDeleteButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeChildIndexList.SelectedIndex != -1)
            {
                if (MessageBox.Show("Selected item will be deleted permenantly. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    this.excludechildnodelist_.RemoveAt(this.htmlNodeExcludeChildIndexList.SelectedIndex);

                    BindChildIndexList();
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void htmlNodeExcludeListUpButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeRegexList.SelectedIndex >0)
            {
                string tmpItem = this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex - 1];
                this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex - 1] = this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex];
                this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex] = tmpItem;

                BindExcludeRegexList();
            }
        }

        private void htmlNodeExcludeListDownButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeRegexList.SelectedIndex != -1 && this.htmlNodeExcludeRegexList.SelectedIndex< this.htmlNodeExcludeRegexList.Items.Count - 1)
            {
                string tmpItem = this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex + 1];
                this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex + 1] = this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex];
                this.excluderegexlist_[this.htmlNodeExcludeRegexList.SelectedIndex] = tmpItem;

                BindExcludeRegexList();
            }
        }

        private void htmlNodeExcludeChildIndexListUpButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeChildIndexList.SelectedIndex > 0)
            {
                int tmpItem = this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex - 1];
                this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex - 1] = this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex];
                this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex] = tmpItem;

                BindChildIndexList();
            }
        }

        private void htmlNodeExcludeChildIndexListDownButton_Click(object sender, EventArgs e)
        {
            if (this.htmlNodeExcludeChildIndexList.SelectedIndex != -1 && this.htmlNodeExcludeChildIndexList.SelectedIndex < this.htmlNodeExcludeChildIndexList.Items.Count - 1)
            {
                int tmpItem = this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex + 1];
                this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex + 1] = this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex];
                this.excludechildnodelist_[this.htmlNodeExcludeChildIndexList.SelectedIndex] = tmpItem;

                BindChildIndexList();
            }
        }

        private void htmlNodePrefixText_TextChanged(object sender, EventArgs e)
        {
            if (htmlNodePrefixText.Text == "")
                htmlNodeReturnOnlyTextCheck.Checked = false;
            else
                htmlNodeReturnOnlyTextCheck.Checked = true;
        }

        private void htmlNodeAttributeText_TextChanged(object sender, EventArgs e)
        {
            if (htmlNodeAttributeText.Text == "")
                htmlNodeReturnOnlyTextCheck.Checked = false;
            else
                htmlNodeReturnOnlyTextCheck.Checked = true;
        }
    }
}
