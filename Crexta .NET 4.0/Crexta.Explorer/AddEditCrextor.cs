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
using System.Data;
using System.Linq;
using System.Windows.Forms;

using Crexta.DataBase;
using Crexta.Utilities;
using System.Data.Common;

namespace Crexta.Explorer
{
    public partial class AddEditCrextor : Form
    {
        private int crextorid_ = -1;
        private string name_ = "";

        public AddEditCrextor(int id)
        {
            InitializeComponent();

            this.crextorid_ = id;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    // JUST IN CASE!
                    if (db.Connection.State == ConnectionState.Closed)
                        db.Connection.Open();

                    // check existance
                    var crext = (from st in db.Crextors
                                 where st.Name.ToLower() == this.crextorNameText.Text.ToLower() && st.Id != this.crextorid_ && st.GroupId == (int)this.crextorGroupsCombo.SelectedValue
                                 select st).SingleOrDefault();

                    if (crext == null)
                    {
                        if (this.crextorid_ != -1)
                        {
                            // update
                            var crextor = (from st in db.Crextors
                                           where st.Id == this.crextorid_
                                           select st).SingleOrDefault();

                            if (crextor != null)
                            {
                                //update
                                crextor.Name = this.crextorNameText.Text;
                                crextor.Description = this.crextorDescTextbox.Text;
                                crextor.Url = this.crextorURLText.Text;
                                crextor.Tags = this.crextorTags.Text;
                                crextor.Active = this.crextorActiveCheck.Checked;
                                crextor.Paid = this.crextorPaidCheck.Checked;
                                crextor.UseResources = this.useResourcesCheck.Checked;

                                if (this.crextorRuleListCombo.SelectedIndex != -1)
                                    crextor.RuleId = (int)this.crextorRuleListCombo.SelectedValue;
                                else
                                    crextor.RuleId = -1;

                                if (this.crextorGroupsCombo.SelectedIndex != -1)
                                    crextor.GroupId = (int)this.crextorGroupsCombo.SelectedValue;
                                else
                                    crextor.GroupId = 1;

                                if (this.crextorCountryCombo.SelectedIndex != -1)
                                    crextor.CountryId = (int)this.crextorCountryCombo.SelectedValue;
                                else
                                    crextor.CountryId = 1;

                                crextor.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;

                                db.SubmitChanges();

                                // check access
                                var access = (from acc in db.ResultAccesses
                                              where acc.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID &&
                                              acc.CrextorId == this.crextorid_ && acc.Ip == "127.0.0.1"
                                              select acc).SingleOrDefault();

                                if (access == null)
                                {
                                    // Give RESULT Access to Current Company
                                    ResultAccess newAccess = new ResultAccess();
                                    newAccess.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;
                                    newAccess.CrextorId = this.crextorid_;
                                    newAccess.Ip = "127.0.0.1";

                                    db.ResultAccesses.InsertOnSubmit(newAccess);
                                    db.SubmitChanges();
                                }
                            }
                            else
                                MessageBox.Show("Cannot find crextor information in DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            DbTransaction tran = db.Connection.BeginTransaction();
                            db.Transaction = tran;

                            try
                            {
                                //insert new crextor
                                Crextor crextor = new Crextor();

                                crextor.Name = this.crextorNameText.Text;
                                crextor.Description = this.crextorDescTextbox.Text;
                                crextor.ShortName = crextor.Name;

                                if (crextor.Name.IndexOf(".") > 0)
                                    crextor.ShortName = crextor.Name.Substring(0, crextor.Name.IndexOf("."));

                                crextor.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;
                                crextor.Tags = this.crextorTags.Text;
                                crextor.Active = this.crextorActiveCheck.Checked;
                                crextor.Crawled = false;
                                crextor.Paid = this.crextorPaidCheck.Checked;
                                crextor.LastCrawlStart = null;
                                crextor.LastCrawlFinish = null;
                                crextor.Rating = 0;
                                crextor.TotalItems = 0;
                                crextor.ExtraDomains = "";
                                crextor.SkipUrls = "";
                                crextor.LogoPath = "";
                                crextor.Url = this.crextorURLText.Text;
                                crextor.UseResources = this.useResourcesCheck.Checked;

                                if (this.crextorRuleListCombo.SelectedIndex != -1)
                                    crextor.RuleId = (int)this.crextorRuleListCombo.SelectedValue;
                                else
                                    crextor.RuleId = -1;

                                if (this.crextorGroupsCombo.SelectedIndex != -1)
                                    crextor.GroupId = (int)this.crextorGroupsCombo.SelectedValue;
                                else
                                    crextor.GroupId = 1;

                                if (this.crextorCountryCombo.SelectedIndex != -1)
                                    crextor.CountryId = (int)this.crextorCountryCombo.SelectedValue;
                                else
                                    crextor.CountryId = 1;

                                db.Crextors.InsertOnSubmit(crextor);
                                db.SubmitChanges();

                                if (crextor.Id > 0)
                                {
                                    // Give RESULT Access to Current Company
                                    ResultAccess newAccess = new ResultAccess();
                                    newAccess.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;
                                    newAccess.CrextorId = crextor.Id;
                                    newAccess.Ip = "127.0.0.1";

                                    db.ResultAccesses.InsertOnSubmit(newAccess);
                                    db.SubmitChanges();

                                    tran.Commit();
                                }
                            }
                            catch (Exception ex)
                            {
                                tran.Rollback();

                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }

                        this.DialogResult = DialogResult.OK;

                        this.Close();
                    }
                    else
                        MessageBox.Show("Crextor already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("Cannot connect to DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void AddEditCrextor_Load(object sender, EventArgs e)
        {
            ExplorerUtilities.BindRuleLists(this.crextorRuleListCombo, -1);

            ExplorerUtilities.BindCountries(this.crextorCountryCombo, 0);

            ExplorerUtilities.BindCrextorGroups(this.crextorGroupsCombo, 0);

            LoadCrextorInfo();

            if (this.crextorid_ <= 0)
                this.totalResCountLink.Enabled = false;
            else
                this.totalResCountLink.Enabled = true;
        }

        private void LoadCrextorInfo()
        {
            if (this.crextorid_ != -1)
            {
                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    if (db != null)
                    {
                        var crextor = (from st in db.Crextors
                                     where st.Id == this.crextorid_
                                     select st).SingleOrDefault();

                        if (crextor != null)
                        {
                            this.name_ = crextor.Name;

                            this.crextorActiveCheck.Checked = crextor.Active;
                            this.crextorPaidCheck.Checked = crextor.Paid;
                            this.crextorNameText.Text = crextor.Name;
                            this.crextorDescTextbox.Text = crextor.Description;
                            this.crextorTags.Text = crextor.Tags;
                            this.crextorURLText.Text = crextor.Url;
                            this.useResourcesCheck.Checked = crextor.UseResources;
                            this.crextorCountryCombo.SelectedValue = crextor.CountryId;
                            this.crextorGroupsCombo.SelectedValue = crextor.GroupId;

                            if (crextor.RuleId > 0)
                                this.crextorRuleListCombo.SelectedValue = crextor.RuleId;

                            var res = from rs in db.CrextorResources
                                      where rs.CrextorId == this.crextorid_
                                      select rs;

                            if (res != null)
                                this.totalResourceLabel.Text = "(Total " + res.Count().ToString() + ")";

                            var urls = from ur in db.CrextorUrls
                                       where ur.CrextorId == this.crextorid_
                                       select ur;

                            if (urls != null)
                                this.totalUrlLabel.Text = "(Total " + urls.Count().ToString() + ")";
                        }
                    }
                    else
                        MessageBox.Show("Cannot find crextor information in DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RuleLists form = new RuleLists(this.crextorid_);

            form.ShowDialog();

            ExplorerUtilities.BindRuleLists(this.crextorRuleListCombo, -1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditCrextorResourceList form = new AddEditCrextorResourceList(this.crextorid_);

            form.ShowDialog();

            LoadCrextorInfo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.crextorRuleListCombo.SelectedIndex = -1;
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddEditCrextorUrlList form = new AddEditCrextorUrlList(this.crextorid_);

            form.ShowDialog();

            LoadCrextorInfo();
        }
    }
}
