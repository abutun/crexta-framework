using System;
using System.Linq;
using System.Windows.Forms;

using Crexta.Common.Crawler.CriteriaItems;
using Crexta.Common.Crawler.Enums;

namespace Crexta.Explorer
{
    public partial class AddEditClick : Form
    {
        private AddEditCriteria parentcirteriaform_ = null;

        private AddEditRules parentruleform_ = null;

        private int index_ = -1;

        private string name_ = "";

        public AddEditClick(AddEditRules frm)
        {
            InitializeComponent();

            this.parentruleform_ = frm;
        }

        public AddEditClick(AddEditCriteria frm, int index, string defaultname)
        {
            InitializeComponent();

            this.parentcirteriaform_ = frm;

            this.index_ = index;

            this.name_ = defaultname;
        }

        private void AddEditClick_Load(object sender, EventArgs e)
        {
            LoadClickItemTypes();

            if (this.parentcirteriaform_ != null)
            {
                try
                {
                    if (this.index_ != -1)
                    {
                        ClickItem item = (ClickItem)this.parentcirteriaform_.executionPipelineItems_[this.index_];

                        if (item != null)
                        {
                            this.clickNameText.Text = item.Name;
                            this.clickLinkIDText.Text = item.LinkID;
                            this.clickAnchorMustClickCheck.Checked = item.MustClick;
                            this.clickWaitForAjaxCheck.Checked = item.WaitForAjax;
                            this.clickTypeCombo.SelectedItem = item.LinkType;
                            this.clickLinkTextText.Text = item.LinkText;
                            this.clickHideInnerBrowserCheck.Checked = item.HideInnerBrowserWindow;
                            this.clickWaitForDocumentLoadCheck.Checked = item.WaitForDocumentLoad;
                        }
                    }
                    else
                        this.clickNameText.Text = this.name_;
                }
                catch
                {
                    MessageBox.Show("Invalid item type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                if (this.parentruleform_ != null)
                {
                    if (this.parentruleform_.innerClickItem != null)
                    {
                        this.clickNameText.Text = this.parentruleform_.innerClickItem.Name;
                        this.clickLinkIDText.Text = this.parentruleform_.innerClickItem.LinkID;
                        this.clickAnchorMustClickCheck.Checked = this.parentruleform_.innerClickItem.MustClick;
                        this.clickWaitForAjaxCheck.Checked = this.parentruleform_.innerClickItem.WaitForAjax;
                        this.clickTypeCombo.SelectedItem = this.parentruleform_.innerClickItem.LinkType;
                        this.clickLinkTextText.Text = this.parentruleform_.innerClickItem.LinkText;
                        this.clickHideInnerBrowserCheck.Checked = this.parentruleform_.innerClickItem.HideInnerBrowserWindow;
                        this.clickWaitForDocumentLoadCheck.Checked = this.parentruleform_.innerClickItem.WaitForDocumentLoad;
                    }
                }
            }
        }

        private void LoadClickItemTypes()
        {
            this.clickTypeCombo.Items.Clear();
            this.clickTypeCombo.Items.Add(ClickItemType.ANCHOR);
            this.clickTypeCombo.Items.Add(ClickItemType.BUTTON);
            this.clickTypeCombo.SelectedIndex = 0;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            ClickItem item = new ClickItem(this.clickNameText.Text, BrowserType.EXPLORER, (ClickItemType)this.clickTypeCombo.SelectedItem, this.clickLinkIDText.Text, this.clickLinkTextText.Text, this.clickAnchorMustClickCheck.Checked, this.clickWaitForAjaxCheck.Checked);
            item.WaitForDocumentLoad = this.clickWaitForDocumentLoadCheck.Checked;
            item.HideInnerBrowserWindow = this.clickHideInnerBrowserCheck.Checked;

            if (this.parentcirteriaform_ != null)
            {
                if (this.index_ == -1)
                {
                    //Insert
                    this.parentcirteriaform_.executionPipelineItems_.Add(item);
                }
                else
                {
                    //Update
                    this.parentcirteriaform_.executionPipelineItems_[this.index_] = item;
                }
            }
            else
                this.parentruleform_.innerClickItem = item;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
