using System;
using System.Linq;
using System.Windows.Forms;
using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class AddEditCrextorUrl : Form
    {
        private int urlid_ = -1;
        private int crextorid_ = -1;

        public AddEditCrextorUrl(int crextorid, int urlid)
        {
            InitializeComponent();

            this.urlid_ = urlid;
            this.crextorid_ = crextorid;
        }

        private void AddEditCrextorResource_Load(object sender, EventArgs e)
        {
            if (this.crextorid_ > 0)
            {
                // load url
                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    var url = (from rs in db.CrextorUrls
                               where rs.Id == urlid_ && rs.CrextorId == crextorid_
                               select rs).SingleOrDefault();

                    if (url != null)
                    {
                        this.urlNameText.Text = url.Name;
                        this.urlKeyText.Text = url.Key;
                        this.urlParentKeyText.Text = url.ParentKey;
                        this.urlUrlText.Text = url.Url;
                        this.urlPagePattern.Text = url.PagePattern;
                        this.hasPagingCheckBox.Checked = url.HasPaging.HasValue ? url.HasPaging.Value : false;
                        if (this.hasPagingCheckBox.Checked)
                            this.urlPagePattern.Enabled = true;
                        this.overrideCategoryCheck.Checked = url.OverrideCategory;
                        this.urlOrderText.Text = url.Order.ToString();
                        this.activeCheckBox.Checked = url.Active;
                    }
                    else
                    {
                        var total = from rs in db.CrextorUrls
                                    where rs.CrextorId == crextorid_
                                    select rs;

                        if (total != null)
                            this.urlOrderText.Text = (total.Count() + 1).ToString();
                    }
                }
            }
        }

        private void hasPagingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.hasPagingCheckBox.Checked)
                this.urlPagePattern.Enabled = true;
            else
            {
                this.urlPagePattern.Text = "";
                this.urlPagePattern.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (crextorid_ > 0)
            {
                short order = -1;
                if (short.TryParse(this.urlOrderText.Text, out order) && this.urlKeyText.Text!="")
                {
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (Uri.IsWellFormedUriString(this.urlUrlText.Text, UriKind.RelativeOrAbsolute))
                        {
                            if (urlid_ > 0)
                            {
                                // update
                                var url = (from rs in db.CrextorUrls
                                           where rs.Id == urlid_ && rs.CrextorId == crextorid_
                                           select rs).SingleOrDefault();

                                if (url != null)
                                {
                                    url.CrextorId = crextorid_;
                                    url.Name = this.urlNameText.Text;
                                    url.Key = this.urlKeyText.Text;
                                    url.ParentKey = this.urlParentKeyText.Text;
                                    url.Url = this.urlUrlText.Text;
                                    url.PagePattern = this.urlPagePattern.Text;
                                    url.HasPaging = this.hasPagingCheckBox.Checked;
                                    url.OverrideCategory = this.overrideCategoryCheck.Checked;
                                    url.Order = order;
                                    url.Active = this.activeCheckBox.Checked;

                                    db.SubmitChanges();
                                }
                            }
                            else
                            {
                                // insert
                                CrextorUrl url = new CrextorUrl();
                                url.CrextorId = crextorid_;
                                url.Name = this.urlNameText.Text;
                                url.Key = this.urlKeyText.Text;
                                url.ParentKey = this.urlParentKeyText.Text;
                                url.Url = this.urlUrlText.Text;
                                url.PagePattern = this.urlPagePattern.Text;
                                url.HasPaging = this.hasPagingCheckBox.Checked;
                                url.OverrideCategory = this.overrideCategoryCheck.Checked;
                                url.Order = order;
                                url.Active = this.activeCheckBox.Checked;

                                db.CrextorUrls.InsertOnSubmit(url);

                                db.SubmitChanges();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid URL!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is something wrong with the [key] or [order]!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }

                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void pagePattern_TextChanged(object sender, EventArgs e)
        {
            if (urlPagePattern.Text != "")
                this.hasPagingCheckBox.Checked = true;
            else
                this.hasPagingCheckBox.Checked = false;
        }
    }
}
