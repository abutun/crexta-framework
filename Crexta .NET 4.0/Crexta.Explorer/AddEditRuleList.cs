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
using System.IO;

using Crexta.Common;
using Crexta.DataBase;
using Crexta.Utilities;
using Crexta.Common.Enums;

namespace Crexta.Explorer
{
    public partial class AddEditRuleList : Form
    {
        private int listid = -1;

        public AddEditRuleList(int listid)
        {
            InitializeComponent();

            this.listid = listid;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.ruleNameText.Text != null)
            {
                CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                if (db != null)
                {
                    if (this.listid > 0)
                    {
                        var rulelist = (from ru in db.Rules
                                       where ru.Id == this.listid && ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                        select ru).SingleOrDefault();
                        //update
                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        {
                            if (!ExplorerUtilities.RuleListExists(this.ruleNameText.Text))
                            {
                                if (File.Exists(rulelist.Path))
                                {
                                    //string oldpath = rulelist.path;

                                    //this.innerRuleList.Name = this.ruleNameText.Text;

                                    //this.innerRuleList.Save(true);

                                    ////Delete old file!
                                    //File.Delete(oldpath);
                                }
                            }
                            else
                                MessageBox.Show("Please enter a different rule list name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                            rulelist.Name = this.ruleNameText.Text;
                    }
                    else
                    {
                        //insert
                        if (ExplorerUtilities.DATASTORAGE == DataStorage.FILE)
                        {
                            if (!ExplorerUtilities.RuleListExists(this.ruleNameText.Text))
                            {
                                CrawlerRuleCollection newList = new CrawlerRuleCollection(this.ruleNameText.Text);

                                newList.Save(true);
                            }
                            else
                                MessageBox.Show("Please enter a different rule list name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            Crexta.DataBase.Rule newRule = new Crexta.DataBase.Rule();
                            newRule.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;
                            newRule.Name = this.ruleNameText.Text;
                            newRule.Path = "";
                            newRule.Data = null;
                            newRule.Date = DateTime.Now;

                            db.Rules.InsertOnSubmit(newRule);
                        }
                    }

                    if (ExplorerUtilities.DATASTORAGE == DataStorage.DB)
                        db.SubmitChanges();

                    this.DialogResult = DialogResult.OK;

                    this.Close();
                }
                else
                    MessageBox.Show("Cannot connect to DB!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please enter rule list name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void AddEditRuleList_Load(object sender, EventArgs e)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                if (this.listid > 0)
                {
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var rulelist = (from ru in db.Rules
                                        where ru.Id == this.listid && ru.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                        select ru).SingleOrDefault();

                        if (rulelist != null)
                            this.ruleNameText.Text = rulelist.Name;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a company!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.Close();
            }
        }
    }
}
