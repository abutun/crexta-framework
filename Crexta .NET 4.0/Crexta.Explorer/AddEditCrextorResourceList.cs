using System;
using System.Linq;
using System.Windows.Forms;

using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class AddEditCrextorResourceList : Form
    {
        private int crextorid_ = -1;

        public AddEditCrextorResourceList(int crextorid)
        {
            InitializeComponent();

            this.crextorid_ = crextorid;
        }

        private void AddEditCrextorResourceList_Load(object sender, EventArgs e)
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                var types = from ty in db.ResourceTypes
                            where ty.Id == 1
                            select ty;

                if (types != null)
                {
                    this.typeCombo.DataSource = types;

                    if (crextorid_ > 0)
                    {
                        var crextor = (from st in db.Crextors
                                    where st.Id == this.crextorid_
                                    select st).SingleOrDefault();

                        if (crextor != null)
                        {
                            this.crextorNameText.Text = crextor.Name;

                            LoadCrextorResources(types.First().Id);
                        }
                    }
                }
            }
        }

        private void LoadCrextorResources(int typeid)
        {
            if (this.crextorid_ > 0)
            {
                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    var resources = from st in db.CrextorResources
                                where st.TypeId == typeid && st.CrextorId == this.crextorid_
                                orderby st.Order
                                select st;

                    if (resources != null)
                    {
                        this.resurceList.Rows.Clear();
                        foreach (CrextorResource res in resources)
                            this.resurceList.Rows.Add(res.Id.ToString(), res.Name, res.Url, res.Order.ToString());
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.resurceList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Selected resource will be deleted permemantly! \r\nAre you sure?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int resid = int.Parse(this.resurceList.SelectedRows[0].Cells[0].Value.ToString());
                    int type = int.Parse(this.typeCombo.SelectedValue.ToString());

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        var resource = (from res in db.CrextorResources
                                        where res.Id == resid && res.TypeId == type
                                        select res).SingleOrDefault();

                        if (resource != null)
                        {
                            db.CrextorResources.DeleteOnSubmit(resource);

                            db.SubmitChanges();

                            LoadCrextorResources(type);
                        }
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            short type = short.Parse(this.typeCombo.SelectedValue.ToString());

            AddEditCrextorResource frmAddEdit = new AddEditCrextorResource(this.crextorid_, -1, type);

            if (frmAddEdit.ShowDialog() == DialogResult.OK)
                LoadCrextorResources(type);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.resurceList.SelectedRows.Count == 1)
            {
                int resid = int.Parse(this.resurceList.SelectedRows[0].Cells[0].Value.ToString());
                short type = short.Parse(this.typeCombo.SelectedValue.ToString());

                AddEditCrextorResource frmAddEdit = new AddEditCrextorResource(this.crextorid_, resid, type);

                if (frmAddEdit.ShowDialog() == DialogResult.OK)
                    LoadCrextorResources(type);
            }
        }

        private void resurceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int resid = int.Parse(this.resurceList.Rows[e.RowIndex].Cells[0].Value.ToString());
                    short type = short.Parse(this.typeCombo.SelectedValue.ToString());

                    if (resid > 0)
                    {
                        AddEditCrextorResource frmAddEdit = new AddEditCrextorResource(this.crextorid_, resid, type);

                        if (frmAddEdit.ShowDialog() == DialogResult.OK)
                            LoadCrextorResources(type);
                    }
                }
                catch
                {
                    //Empty cell double click
                }
            }
            else
                MessageBox.Show("Please select a resource!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void typeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeCombo.SelectedIndex >= 0)
            {
                int type = int.Parse(this.typeCombo.SelectedValue.ToString());

                LoadCrextorResources(type);
            }
        }
    }
}
