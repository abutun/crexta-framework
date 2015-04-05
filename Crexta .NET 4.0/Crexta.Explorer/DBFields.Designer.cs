namespace Crexta.Explorer
{
    partial class DBFields
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.defaultValueListBox = new System.Windows.Forms.ListBox();
            this.defaultValueText = new System.Windows.Forms.TextBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.mappingTypesListBox = new System.Windows.Forms.ListBox();
            this.mappingTypesCombo = new System.Windows.Forms.ComboBox();
            this.mappingNameTextbox = new System.Windows.Forms.TextBox();
            this.mappingsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.defaultValueListBox);
            this.groupBox1.Controls.Add(this.defaultValueText);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.mappingTypesListBox);
            this.groupBox1.Controls.Add(this.mappingTypesCombo);
            this.groupBox1.Controls.Add(this.mappingNameTextbox);
            this.groupBox1.Controls.Add(this.mappingsListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // defaultValueListBox
            // 
            this.defaultValueListBox.DisplayMember = "DefaultValue";
            this.defaultValueListBox.Enabled = false;
            this.defaultValueListBox.FormattingEnabled = true;
            this.defaultValueListBox.Location = new System.Drawing.Point(386, 45);
            this.defaultValueListBox.Name = "defaultValueListBox";
            this.defaultValueListBox.Size = new System.Drawing.Size(293, 290);
            this.defaultValueListBox.TabIndex = 5;
            this.defaultValueListBox.ValueMember = "Id";
            // 
            // defaultValueText
            // 
            this.defaultValueText.Location = new System.Drawing.Point(386, 19);
            this.defaultValueText.Name = "defaultValueText";
            this.defaultValueText.Size = new System.Drawing.Size(293, 20);
            this.defaultValueText.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(407, 340);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(85, 23);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(498, 341);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(591, 341);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 23);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(311, 341);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add New";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mappingTypesListBox
            // 
            this.mappingTypesListBox.DisplayMember = "FieldType";
            this.mappingTypesListBox.Enabled = false;
            this.mappingTypesListBox.FormattingEnabled = true;
            this.mappingTypesListBox.Location = new System.Drawing.Point(199, 45);
            this.mappingTypesListBox.Name = "mappingTypesListBox";
            this.mappingTypesListBox.Size = new System.Drawing.Size(181, 290);
            this.mappingTypesListBox.TabIndex = 4;
            this.mappingTypesListBox.ValueMember = "Id";
            this.mappingTypesListBox.SelectedIndexChanged += new System.EventHandler(this.mappingTypesListBox_SelectedIndexChanged);
            // 
            // mappingTypesCombo
            // 
            this.mappingTypesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mappingTypesCombo.FormattingEnabled = true;
            this.mappingTypesCombo.Location = new System.Drawing.Point(199, 19);
            this.mappingTypesCombo.Name = "mappingTypesCombo";
            this.mappingTypesCombo.Size = new System.Drawing.Size(181, 21);
            this.mappingTypesCombo.TabIndex = 1;
            // 
            // mappingNameTextbox
            // 
            this.mappingNameTextbox.Location = new System.Drawing.Point(12, 19);
            this.mappingNameTextbox.Name = "mappingNameTextbox";
            this.mappingNameTextbox.Size = new System.Drawing.Size(181, 20);
            this.mappingNameTextbox.TabIndex = 0;
            // 
            // mappingsListBox
            // 
            this.mappingsListBox.DisplayMember = "FieldName";
            this.mappingsListBox.FormattingEnabled = true;
            this.mappingsListBox.Location = new System.Drawing.Point(12, 45);
            this.mappingsListBox.Name = "mappingsListBox";
            this.mappingsListBox.Size = new System.Drawing.Size(181, 290);
            this.mappingsListBox.TabIndex = 3;
            this.mappingsListBox.ValueMember = "Id";
            this.mappingsListBox.SelectedIndexChanged += new System.EventHandler(this.mappingsListBox_SelectedIndexChanged);
            // 
            // DBFields
            // 
            this.AcceptButton = this.addButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(691, 375);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DBFields";
            this.Text = "Crexta - DB Fields";
            this.Load += new System.EventHandler(this.DBFields_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox mappingTypesListBox;
        private System.Windows.Forms.ComboBox mappingTypesCombo;
        private System.Windows.Forms.TextBox mappingNameTextbox;
        private System.Windows.Forms.ListBox mappingsListBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.ListBox defaultValueListBox;
        private System.Windows.Forms.TextBox defaultValueText;
    }
}