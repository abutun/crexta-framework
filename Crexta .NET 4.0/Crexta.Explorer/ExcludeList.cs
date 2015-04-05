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

using Crexta.Common.Crawler;
using Crexta.Common.Crawler.Enums;

namespace Crexta.Explorer
{
    public partial class ExcludeList : Form
    {
        private CrawlerCriteria criteria_ = null;

        private AddEditCriteria parentform_ = null;

        private CrawlerExcludeListCollection excludelist_ = new CrawlerExcludeListCollection();

        public ExcludeList(AddEditCriteria frm, CrawlerCriteria criteria, CrawlerExcludeListCollection list)
        {
            InitializeComponent();

            this.criteria_ = criteria;

            this.parentform_ = frm;

            this.excludelist_ = list;
        }

        private void ExcludeList_Load(object sender, EventArgs e)
        {
            LoadExcludeTypes();

            if (this.criteria_ == null)
            {
                this.criteria_ = new CrawlerCriteria();

                this.criteria_.ExcludeList = this.excludelist_;
            }

            ExplorerUtilities.BindExcludeList(this.criteria_, this.excludeListBox);
        }

        private void LoadExcludeTypes()
        {
            this.excludeTypeCombo.Items.Clear();
            this.excludeTypeCombo.Items.Add(CrawlerExcludeListType.Regex);
            this.excludeTypeCombo.Items.Add(CrawlerExcludeListType.Text);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.excludeListBox.SelectedIndex != -1)
            {
                CrawlerExcludeList list = (CrawlerExcludeList)this.excludeListBox.SelectedItem;

                if (this.criteria_.ExcludeList.Contains(list))
                {
                    this.criteria_.ExcludeList.Remove(list);

                    ExplorerUtilities.BindExcludeList(this.criteria_, this.excludeListBox);
                }
            }
            else
                MessageBox.Show("Please select an item!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            this.excludeNameText.Text = "";
            this.excludeTypeCombo.SelectedIndex = 0;
            this.excludeFindValueText.Text = "";
            this.excludeReplaceValueText.Text = "";
            this.excludeExcludeWholeHTMLCheck.Checked = false;
            this.excludeNameText.Focus();
        }

        private void excludeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.excludeListBox.SelectedIndex != -1)
            {
                CrawlerExcludeList list = (CrawlerExcludeList)this.excludeListBox.SelectedItem;

                if (list != null)
                {
                    this.excludeNameText.Text = list.Name;
                    this.excludeExcludeWholeHTMLCheck.Checked = list.ExcludeAll;
                    this.excludeTypeCombo.SelectedItem = list.Type;
                    this.excludeFindValueText.Text = list.Value;
                    this.excludeReplaceValueText.Text = list.ReplaceWith;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CrawlerExcludeList list = new CrawlerExcludeList();
            list.Name = this.excludeNameText.Text;
            list.ExcludeAll = this.excludeExcludeWholeHTMLCheck.Checked;
            list.Type = (CrawlerExcludeListType)this.excludeTypeCombo.SelectedItem;
            list.Value = this.excludeFindValueText.Text;
            list.ReplaceWith = this.excludeReplaceValueText.Text;

            if (!this.criteria_.ExcludeList.Contains(list))
            {
                this.criteria_.ExcludeList.Add(list);

                ExplorerUtilities.BindExcludeList(this.criteria_, this.excludeListBox);
            }
            else
                MessageBox.Show("This list already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (this.excludeListBox.SelectedIndex != -1)
            {
                CrawlerExcludeList list = new CrawlerExcludeList();
                list.Name = this.excludeNameText.Text;
                list.ExcludeAll = this.excludeExcludeWholeHTMLCheck.Checked;
                list.Type = (CrawlerExcludeListType)this.excludeTypeCombo.SelectedItem;
                list.Value = this.excludeFindValueText.Text;
                list.ReplaceWith = this.excludeReplaceValueText.Text;

                if (this.criteria_.ExcludeList.Contains(list))
                {
                    this.criteria_.ExcludeList[this.excludeListBox.SelectedIndex] = list;

                    ExplorerUtilities.BindExcludeList(this.criteria_, this.excludeListBox);
                }
                else
                    MessageBox.Show("List not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please select a list!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void ExcludeList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.parentform_ != null)
                this.parentform_.UpdateExcludeList(this.criteria_.ExcludeList);
        }

        private void excludeTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //html
            if (this.excludeTypeCombo.SelectedIndex == 0)
                this.excludeExcludeWholeHTMLCheck.Enabled = true;
            else
            {
                //other
                this.excludeExcludeWholeHTMLCheck.Checked = false;
                this.excludeExcludeWholeHTMLCheck.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
