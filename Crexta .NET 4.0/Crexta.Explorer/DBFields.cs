using System;
using System.Linq;
using System.Windows.Forms;
using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class DBFields : Form
    {
        public DBFields()
        {
            InitializeComponent();
        }

        private void mappingsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mappingTypesListBox.SelectedIndex = this.defaultValueListBox.SelectedIndex = mappingsListBox.SelectedIndex;

            this.updateButton.Enabled = this.mappingsListBox.SelectedIndex != -1;

            try
            {
                DbField selected = (DbField)this.mappingsListBox.SelectedItem;

                using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                {
                    var field = (from fl in db.DbFields
                                 where fl.Id == selected.Id
                                 select fl).SingleOrDefault();

                    if (field != null)
                    {
                        this.mappingNameTextbox.Text = field.FieldName;

                        for (int i = 0; i < this.mappingTypesCombo.Items.Count; i++)
                        {
                            if (this.mappingTypesCombo.Items[i].ToString() == field.FieldType)
                            {
                                this.mappingTypesCombo.SelectedIndex = i;
                                break;
                            }
                        }

                        this.defaultValueText.Text = field.DefaultValue;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void DBFields_Load(object sender, EventArgs e)
        {
            if (ExplorerUtilities.CURRENT_COMPANY_ID > 0)
            {
                ExplorerUtilities.LoadDBTypes(this.mappingTypesCombo);

                LoadCompanyFields();
            }
            else
            {
                MessageBox.Show("Please select a company first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.Close();
            }
        }

        private void LoadCompanyFields()
        {
            this.mappingsListBox.Items.Clear();
            this.mappingTypesListBox.Items.Clear();
            this.defaultValueListBox.Items.Clear();

            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                var fields = from fl in db.DbFields
                             where fl.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                             orderby fl.FieldName
                             select fl;

                if (fields != null)
                {
                    foreach (DbField field in fields)
                    {
                        this.mappingsListBox.Items.Add(field);
                        this.mappingTypesListBox.Items.Add(field);
                        this.defaultValueListBox.Items.Add(field);
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.mappingNameTextbox.Text != "")
            {
                if (this.mappingTypesCombo.SelectedIndex != -1)
                {
                    using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                    {
                        var field = (from df in db.DbFields
                                     where df.FieldName.ToLower() == this.mappingNameTextbox.Text.ToLower()
                                     && df.FieldType.ToLower() == this.mappingTypesCombo.Text.ToLower()
                                     && df.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                     select df).SingleOrDefault();

                        if (field != null)
                            MessageBox.Show("Field name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        else
                        {
                            DbField newField = new DbField();
                            newField.FieldName = this.mappingNameTextbox.Text;
                            newField.FieldType = this.mappingTypesCombo.SelectedItem.ToString();
                            newField.DefaultValue = this.defaultValueText.Text;
                            newField.CompanyId = ExplorerUtilities.CURRENT_COMPANY_ID;

                            db.DbFields.InsertOnSubmit(newField);

                            db.SubmitChanges();

                            LoadCompanyFields();
                        }
                    }
                }
                else
                    MessageBox.Show("Please select field type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please enter field name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.mappingsListBox.SelectedIndex != -1)
            {
                if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    try
                    {
                        DbField selected = (DbField)this.mappingsListBox.SelectedItem;

                        using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                        {
                            var field = (from fl in db.DbFields
                                         where fl.Id == selected.Id
                                         select fl).SingleOrDefault();

                            if (field != null)
                            {
                                db.DbFields.DeleteOnSubmit(field);

                                db.SubmitChanges();

                                LoadCompanyFields();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
                MessageBox.Show("Please enter field name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (this.mappingNameTextbox.Text != "")
            {
                if (this.mappingTypesCombo.SelectedIndex != -1)
                {
                    try
                    {
                        DbField selected = (DbField)this.mappingsListBox.SelectedItem;

                        using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
                        {
                            var field = (from df in db.DbFields
                                         where df.FieldName.ToLower() == this.mappingNameTextbox.Text.ToLower()
                                         && df.FieldType.ToLower() == this.mappingTypesCombo.Text.ToLower()
                                         && df.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID && df.Id != selected.Id
                                         select df).SingleOrDefault();

                            if (field != null)
                                MessageBox.Show("Field name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            else
                            {
                                var updfield = (from df in db.DbFields
                                                where df.Id == selected.Id
                                                && df.CompanyId == ExplorerUtilities.CURRENT_COMPANY_ID
                                                select df).SingleOrDefault();

                                if (updfield != null)
                                {
                                    updfield.FieldName = this.mappingNameTextbox.Text;
                                    updfield.FieldType = this.mappingTypesCombo.SelectedItem.ToString();
                                    updfield.DefaultValue = this.defaultValueText.Text;

                                    db.SubmitChanges();

                                    LoadCompanyFields();
                                }
                                else
                                    MessageBox.Show("Field not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                    MessageBox.Show("Please select field type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
                MessageBox.Show("Please enter field name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void mappingTypesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
