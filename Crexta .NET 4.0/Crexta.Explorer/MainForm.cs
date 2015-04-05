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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using Crexta.DataBase;
using Crexta.Utilities;
using System.Data.Common;
using System.Data.Linq.SqlClient;

namespace Crexta.Explorer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public IEnumerable<Crextor> GetCrextors(CrextaDataContext db, string searchTerm, int countryId, int groupId)
        {
            if (!searchTerm.Equals("") && !searchTerm.Equals("Search"))
            {
                if (countryId > 0 && groupId > 0)
                {
                    var crextors = from cr in db.Crextors
                                   where SqlMethods.Like(cr.Name + " " + cr.ShortName + " " + cr.Tags, "%" + searchTerm + "%") && cr.CountryId == countryId && cr.GroupId == groupId
                                   select cr;

                    return crextors;
                }
                else if (countryId > 0)
                {
                    var crextors = from cr in db.Crextors
                                   where SqlMethods.Like(cr.Name + " " + cr.ShortName + " " + cr.Tags, "%" + searchTerm + "%") && cr.CountryId == countryId
                                   select cr;

                    return crextors;
                }
                else if (groupId > 0)
                {
                    var crextors = from cr in db.Crextors
                                   where SqlMethods.Like(cr.Name + " " + cr.ShortName + " " + cr.Tags, "%" + searchTerm + "%") && cr.GroupId == groupId
                                   select cr;

                    return crextors;
                }
                else
                {
                    var crextors = from cr in db.Crextors
                                   where SqlMethods.Like(cr.Name + " " + cr.ShortName + " " + cr.Tags, "%" + searchTerm + "%")
                                   select cr;

                    return crextors;
                }
            }
            else
            {
                if (countryId > 0 && groupId > 0)
                {
                    var crextors = from cr in db.Crextors
                                   where cr.CountryId == countryId && cr.GroupId == groupId
                                   select cr;

                    return crextors;
                }
                else if (countryId > 0)
                {
                    var crextors = from cr in db.Crextors
                                   where cr.CountryId == countryId
                                   select cr;

                    return crextors;
                }
                else if (groupId > 0)
                {
                    var crextors = from cr in db.Crextors
                                   where cr.GroupId == groupId
                                   select cr;

                    return crextors;
                }
                else
                {
                    var crextors = from cr in db.Crextors
                                   select cr;

                    return crextors;
                }
            }
        }

        private string getSearchTerm()
        {
            return this.searchTextBox.Text.Equals("Search") ? "" : this.searchTextBox.Text;
        }

        private int getCountryId()
        {
            if (this.countryComboBox.SelectedValue != null)
            {
                try
                {
                    return int.Parse(this.countryComboBox.SelectedValue.ToString());
                }
                catch (Exception)
                {
                    // NOP
                }
            }

            return -1;
        }

        private int getGroupId()
        {
            if (this.crextorTypeCombo.SelectedValue != null)
            {
                try
                {
                    return int.Parse(this.crextorTypeCombo.SelectedValue.ToString());
                }
                catch (Exception)
                {
                    // NOP
                }
            }

            return -1;
        }

        private void PopulateCrextors()
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    var crextors = GetCrextors(db, getSearchTerm(), getCountryId(), getGroupId());

                    if (crextors != null)
                    {
                        crextorGrid.Rows.Clear();
                        foreach (Crextor crextor in crextors)
                        {
                            crextorGrid.Rows.Add(new object[] { crextor.Id, crextor.CrextorGroup.Name, crextor.ShortName, crextor.Name, crextor.Url, crextor.TotalItems, crextor.CrextorResources.Count.ToString(),
                                                 crextor.LastCrawlStart, crextor.LastCrawlFinish, crextor.Crawled });

                            // default color
                            crextorGrid.Rows[crextorGrid.RowCount - 1].DefaultCellStyle.BackColor = Color.Yellow;

                            if (crextor.Active && crextor.RuleId <= 0)
                                crextorGrid.Rows[crextorGrid.RowCount - 1].DefaultCellStyle.BackColor = Color.Red;
                            else if (crextor.Active && crextor.RuleId > 0)
                                crextorGrid.Rows[crextorGrid.RowCount - 1].DefaultCellStyle.BackColor = Color.Blue;
                        }
                    }
                    else
                        MessageBox.Show("Cannot populate crextor information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("Cannot populate crextor information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.openFileDialog1.InitialDirectory = Common.Constants.GeneralConstants.defaultBackupFileRoot;
        }

        private void LoadData()
        {
            try
            {
                PopulateCrextors();

                DataGridViewButtonColumn scheduleColumn = (DataGridViewButtonColumn)crextorGrid.Columns["Schedule"];
                scheduleColumn.FlatStyle = FlatStyle.Flat;
                scheduleColumn.DefaultCellStyle.ForeColor = Color.Black;
                scheduleColumn.DefaultCellStyle.BackColor = Color.Purple;

                //Get Versions
                this.fileVersionLabel.Text = "???";
                this.toolStripStatusLabel1.Text = "???";

                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    if (db != null)
                    {
                        var version1 = (from ver in db.Versions
                                        where ver.Id == (int)Common.Enums.VersionType.MAINLIST
                                        select ver).SingleOrDefault();

                        if (version1 != null)
                            this.fileVersionLabel.Text = version1.Version1;

                        var version2 = (from ver in db.Versions
                                        where ver.Id == (int)Common.Enums.VersionType.EXPLORER
                                        select ver).SingleOrDefault();

                        if (version2 != null)
                            this.fileVersionLabel.Text = version1.Version1;
                        this.toolStripStatusLabel1.Text = version2.Version1;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.Close();
            }
        }

        private void crextorGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    int crextorid = int.Parse(this.crextorGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                    if (crextorid > 0)
                    {
                        AddEditCrextor frmAddEdit = new AddEditCrextor(crextorid);

                        if (frmAddEdit.ShowDialog() == DialogResult.OK)
                            PopulateCrextors();
                    }
                }
                catch
                {
                    //Empty cell double click
                }
            }
            else
                MessageBox.Show("Please select a crextor!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void addNewButton_Click(object sender, EventArgs e)
        {
            //Add new Crextor
            AddEditCrextor form = new AddEditCrextor(-1);

            if (form.ShowDialog() == DialogResult.OK)
                LoadData();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rules form = new Rules();

            form.ShowDialog();
        }

        private void ruleListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RuleLists form = new RuleLists(-1);

            form.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Depending on the directory this could be very large and would require more attention
                // in a commercial package.
                string[] filenames = Directory.GetFiles(Common.Constants.GeneralConstants.defaultRulesFileRoot);

                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                if (!Directory.Exists(Common.Constants.GeneralConstants.defaultBackupFileRoot))
                    Directory.CreateDirectory(Common.Constants.GeneralConstants.defaultBackupFileRoot);

                string backupname = "Backup_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                    "_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".rll";

                using (ZipOutputStream s = new ZipOutputStream(File.Create(Common.Constants.GeneralConstants.defaultBackupFileRoot + backupname)))
                {

                    s.SetLevel(9); // 0 - crextor only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {

                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        // Setup the entry data as required.

                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.

                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {

                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();

                    // Close is important to wrap things up and unlock the file.
                    s.Close();

                    MessageBox.Show("Backup Succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                // No need to rethrow the exception as for our purposes its handled.
            }
        }

        private void recrextorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (ZipInputStream s = new ZipInputStream(File.OpenRead(this.openFileDialog1.FileName)))
                {

                    ZipEntry theEntry;

                    //Delete all rules
                    if (Directory.Exists(Common.Constants.GeneralConstants.defaultRulesFileRoot))
                        Directory.Delete(Common.Constants.GeneralConstants.defaultRulesFileRoot, true);

                    //Re-create directory
                    if (!Directory.Exists(Common.Constants.GeneralConstants.defaultRulesFileRoot))
                        Directory.CreateDirectory(Common.Constants.GeneralConstants.defaultRulesFileRoot);

                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        string fileName = Path.GetFileName(theEntry.Name);

                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(Common.Constants.GeneralConstants.defaultRulesFileRoot + theEntry.Name))
                            {
                                int size = 2048;
                                byte[] data = new byte[2048];
                                while (true)
                                {
                                    size = s.Read(data, 0, data.Length);
                                    if (size > 0)
                                    {
                                        streamWriter.Write(data, 0, size);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                MessageBox.Show("Recrextor Succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void mainListdefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateVersion form = new UpdateVersion();

            form.ShowDialog();
        }

        private void perfectHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculatePerfectHash form = new CalculatePerfectHash();

            form.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About form = new About();

            form.ShowDialog();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.addNewButton_Click(this, new EventArgs());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.editButton_Click(this, new EventArgs());
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.crextorGrid.SelectedRows.Count == 1)
            {
                //Add new Crextor
                AddEditCrextor form = new AddEditCrextor(int.Parse(this.crextorGrid.SelectedRows[0].Cells[0].Value.ToString()));

                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.crextorGrid.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Selected crextor will be deleted permenantly! Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        int crextorid = int.Parse(this.crextorGrid.SelectedRows[0].Cells[0].Value.ToString());

                        if (crextorid > 0)
                        {
                            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                            {
                                if (db != null)
                                {
                                    // JUST IN CASE!
                                    if (db.Connection.State == ConnectionState.Closed)
                                        db.Connection.Open();

                                    DbTransaction tran = db.Connection.BeginTransaction();
                                    db.Transaction = tran;

                                    try
                                    {
                                        // delete crextor
                                        var crextor = (from cr in db.Crextors
                                                       where cr.Id == crextorid && cr.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                                       select cr).SingleOrDefault();

                                        if (crextor != null)
                                        {
                                            db.Crextors.DeleteOnSubmit(crextor);

                                            // delete resources
                                            var resources = from rr in db.CrextorResources
                                                            where rr.CrextorId == crextorid
                                                            select rr;

                                            if (resources != null)
                                                db.CrextorResources.DeleteAllOnSubmit(resources);

                                            // delete fixed urls
                                            var urls = from u in db.CrextorUrls
                                                       where u.CrextorId == crextorid
                                                       select u;

                                            if (urls != null)
                                                db.CrextorUrls.DeleteAllOnSubmit(urls);

                                            // delete schedules
                                            var schedules = from s in db.CrextorSchedules
                                                            where s.CrextorId == crextorid
                                                            select s;

                                            if (schedules != null)
                                                db.CrextorSchedules.DeleteAllOnSubmit(schedules);

                                            // delete crextor results
                                            var results = from res in db.Results
                                                          where res.CrextorId == crextorid
                                                          select res;

                                            if (results != null)
                                                db.Results.DeleteAllOnSubmit(results);

                                            // delete access
                                            var access = (from acc in db.ResultAccesses
                                                          where acc.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID &&
                                                          acc.CrextorId == crextorid
                                                          select acc).SingleOrDefault();

                                            if (access != null)
                                                db.ResultAccesses.DeleteOnSubmit(access);

                                            db.SubmitChanges();

                                            tran.Commit();

                                            PopulateCrextors();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        tran.Rollback();

                                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    }
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
                MessageBox.Show("Please select a crextor!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.deleteButton_Click(this, new EventArgs());
        }

        private void ımportRuleListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exportRuleListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //resize the toolstrip
            this.toolStrip1.Size = new Size(this.Width, this.toolStrip1.Height);
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.refreshToolStripMenuItem_Click(this, new EventArgs());
        }

        private void ruleSimulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RuleTester form = new RuleTester();

            form.Show();
        }

        private void xpathTestetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XPathTester form = new XPathTester();

            form.Show();
        }

        private void regexTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegexTester form = new RegexTester();

            form.Show();
        }

        private void selectCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCompanyForm();   
        }

        private void crextorGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //ShowCompanyForm();
        }

        private void ShowCompanyForm()
        {
            Companies form = new Companies();

            this.ruleListButton.Enabled = this.rulesButton.Enabled = this.ruleListsToolStripMenuItem.Enabled = this.ruleSimulatorToolStripMenuItem.Enabled =
            this.databaseFieldsToolStripMenuItem.Enabled = this.rulesToolStripMenuItem.Enabled = false;
            this.addNewButton.Enabled = this.editButton.Enabled = this.deleteButton.Enabled = this.contextMenuStrip1.Enabled = this.searchTextBox.Enabled = this.countryComboBox.Enabled = this.crextorTypeCombo.Enabled = false;
            foreach (ToolStripItem item in this.contextMenuStrip1.Items)
                item.Enabled = false;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
                {
                    ExplorerUtilities.BindCountries(this.countryComboBox, 0);

                    ExplorerUtilities.BindCrextorGroups(this.crextorTypeCombo, 0);

                    LoadData();

                    this.ruleListButton.Enabled = this.rulesButton.Enabled = this.ruleListsToolStripMenuItem.Enabled = this.ruleSimulatorToolStripMenuItem.Enabled =
                    this.databaseFieldsToolStripMenuItem.Enabled = this.rulesToolStripMenuItem.Enabled = true;
                    this.addNewButton.Enabled = this.editButton.Enabled = this.deleteButton.Enabled = this.contextMenuStrip1.Enabled = this.searchTextBox.Enabled = this.countryComboBox.Enabled = this.crextorTypeCombo.Enabled = true;
                    foreach (ToolStripItem item in this.contextMenuStrip1.Items)
                        item.Enabled = true;
                }
            }
        }

        private void databaseFieldsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBFields form = new DBFields();

            form.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
                PopulateCrextors();
         }

        private void crextorGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (crextorGrid.Columns[e.ColumnIndex].Name == "Schedule")
            {
                int crextorid = int.Parse(this.crextorGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                if (crextorid > 0)
                {
                    Scheduler form = new Scheduler(crextorid);

                    form.ShowDialog();
                }
            }
        }

        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCrextors();
        }

        private void crextorTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCrextors();
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            this.searchTextBox.Text = "";
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (this.searchTextBox.Text.Equals(""))
                this.searchTextBox.Text = "Search";
        }
    }
}
