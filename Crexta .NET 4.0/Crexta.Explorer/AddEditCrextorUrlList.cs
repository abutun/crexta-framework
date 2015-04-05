using System;
using System.Linq;
using System.Windows.Forms;
using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class AddEditCrextorUrlList : Form
    {
        private int crextorid_ = -1;

        public AddEditCrextorUrlList(int crextorid)
        {
            InitializeComponent();

            this.crextorid_ = crextorid;
        }

        private void AddEditCrextorUrlList_Load(object sender, EventArgs e)
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (crextorid_ > 0)
                {
                    var crextor = (from st in db.Crextors
                                   where st.Id == this.crextorid_
                                   select st).SingleOrDefault();

                    if (crextor != null)
                    {
                        this.crextorNameText.Text = crextor.Name;

                        LoadCrextorUrls();
                    }
                }
            }
        }

        private void LoadCrextorUrls()
        {
            if (this.crextorid_ > 0)
            {
                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    var urls = from st in db.CrextorUrls
                                    where st.CrextorId == this.crextorid_
                                    orderby st.Order
                                    select st;

                    if (urls != null)
                    {
                        this.urlList.Rows.Clear();
                        foreach (CrextorUrl url in urls)
                            this.urlList.Rows.Add(url.Id.ToString(), url.Name, url.Url, url.Order.ToString());
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.urlList.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Selected URL will be deleted permemantly! \r\nAre you sure?", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int urlid = int.Parse(this.urlList.SelectedRows[0].Cells[0].Value.ToString());

                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        var url = (from res in db.CrextorUrls
                                   where res.Id == urlid
                                   select res).SingleOrDefault();

                        if (url != null)
                        {
                            db.CrextorUrls.DeleteOnSubmit(url);

                            db.SubmitChanges();

                            LoadCrextorUrls();
                        }
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddEditCrextorUrl frmAddEdit = new AddEditCrextorUrl(this.crextorid_, -1);

            if (frmAddEdit.ShowDialog() == DialogResult.OK)
                LoadCrextorUrls();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.urlList.SelectedRows.Count == 1)
            {
                int urlid = int.Parse(this.urlList.SelectedRows[0].Cells[0].Value.ToString());

                AddEditCrextorUrl frmAddEdit = new AddEditCrextorUrl(this.crextorid_, urlid);

                if (frmAddEdit.ShowDialog() == DialogResult.OK)
                    LoadCrextorUrls();
            }
        }

        private void urlList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int urlid = int.Parse(this.urlList.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (urlid > 0)
                    {
                        AddEditCrextorUrl frmAddEdit = new AddEditCrextorUrl(this.crextorid_, urlid);

                        if (frmAddEdit.ShowDialog() == DialogResult.OK)
                            LoadCrextorUrls();
                    }
                }
                catch
                {
                    //Empty cell double click
                }
            }
            else
                MessageBox.Show("Please select an url!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
