using System;
using System.Linq;
using System.Windows.Forms;

using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.Enums;

namespace Crexta.Explorer
{
    public partial class AddEditCrextorResource : Form
    {
        private int resid_ = -1;
        private short typeid_ = -1;
        private int crextorid_ = -1;

        public AddEditCrextorResource(int crextorid, int resid, short typeid)
        {
            InitializeComponent();

            this.resid_ = resid;
            this.typeid_ = typeid;
            this.crextorid_ = crextorid;
        }

        private void AddEditCrextorResource_Load(object sender, EventArgs e)
        {
            if (this.crextorid_>0)
            {
                // load resource
                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    var types = from ty in db.ResourceTypes
                                where ty.Id == 1
                                select ty;

                    if (types != null)
                    {
                        this.typeCombo.DataSource = types;
                        this.typeCombo.SelectedIndex = 0;

                        var res = (from rs in db.CrextorResources
                                   where rs.Id == resid_ && rs.TypeId == typeid_
                                   select rs).SingleOrDefault();

                        if (res != null)
                        {
                            this.nameText.Text = res.Name;
                            this.keyText.Text = res.Key;
                            this.urlText.Text = res.Url;
                            this.orderText.Text = res.Order.ToString();
                            this.activeCheckBox.Checked = res.Active;
                            this.overrideCategoryCheck.Checked = res.OverrideCategory;
                            this.discoverRedirectsCheck.Checked = res.DiscoverRedirects;
                            this.parentKeyText.Text = res.ParentKey;
                        }
                    }
                    else
                    {
                        var total = from rs in db.CrextorResources
                                    where rs.CrextorId == crextorid_
                                    select rs;

                        if (total != null)
                            this.orderText.Text = (total.Count() + 1).ToString();
                    }
                }
            }
        }

        private string GetTypeEnumString(short value)
        {
            if (value == 1)
                return Crexta.Common.Enums.ResourceType.RSS.ToString();
            else if (value == 2)
                return Crexta.Common.Enums.ResourceType.ATOM.ToString();
            else if (value == 3)
                return Crexta.Common.Enums.ResourceType.XML.ToString();

            return "";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (crextorid_ > 0)
            {
                short order = -1;
                if (short.TryParse(this.orderText.Text, out order) && this.keyText.Text!="")
                {
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        if (resid_ > 0 && typeid_ > 0)
                        {
                            // update
                            var res = (from rs in db.CrextorResources
                                       where rs.Id == resid_ && rs.TypeId == typeid_
                                       select rs).SingleOrDefault();

                            if (res != null)
                            {
                                res.Name = this.nameText.Text; 
                                res.Url = this.urlText.Text;
                                res.Key = this.keyText.Text;
                                res.CrextorId = this.crextorid_;
                                res.Order = order;
                                res.TypeId = short.Parse(this.typeCombo.SelectedValue.ToString());
                                res.Active = this.activeCheckBox.Checked;
                                res.OverrideCategory = this.overrideCategoryCheck.Checked;
                                res.DiscoverRedirects = this.discoverRedirectsCheck.Checked;
                                res.ParentKey = this.parentKeyText.Text;

                                db.SubmitChanges();
                            }
                        }
                        else
                        {
                            // insert
                            CrextorResource res = new CrextorResource();
                            res.Name = this.nameText.Text;
                            res.Url = this.urlText.Text;
                            res.Key = this.keyText.Text;
                            res.CrextorId = this.crextorid_;
                            res.TypeId = short.Parse(this.typeCombo.SelectedValue.ToString());
                            res.Order = order;
                            res.Active = this.activeCheckBox.Checked;
                            res.OverrideCategory = overrideCategoryCheck.Checked;
                            res.DiscoverRedirects = discoverRedirectsCheck.Checked;
                            res.ParentKey = this.parentKeyText.Text;

                            db.CrextorResources.InsertOnSubmit(res);

                            db.SubmitChanges();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There is something wrong with the [key] or [order]!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    return;
                }
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
