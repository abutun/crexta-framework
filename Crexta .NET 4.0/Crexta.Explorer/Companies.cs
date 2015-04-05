using System;
using System.Linq;
using System.Windows.Forms;

namespace Crexta.Explorer
{
    public partial class Companies : Form
    {
        public Companies()
        {
            InitializeComponent();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            SelectCompany();
        }

        private void SelectCompany()
        {
            try
            {
                if (this.companyLisBox.SelectedIndex != -1)
                    ExplorerUtilities.CURRENT_COMPANY_ID = int.Parse(this.companyLisBox.SelectedValue.ToString());
            }
            catch (Exception)
            {
                // NOP
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void Companies_Load(object sender, EventArgs e)
        {
            ExplorerUtilities.BindCompanies(this.companyLisBox);
        }

        private void companyLisBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void companyLisBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SelectCompany();
        }
    }
}
