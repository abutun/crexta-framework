namespace Crexta.Explorer
{
    partial class AddEditCrextorResource
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.discoverRedirectsCheck = new System.Windows.Forms.CheckBox();
            this.overrideCategoryCheck = new System.Windows.Forms.CheckBox();
            this.activeCheckBox = new System.Windows.Forms.CheckBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.urlText = new System.Windows.Forms.TextBox();
            this.orderText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.typeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.parentKeyText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.parentKeyText);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.discoverRedirectsCheck);
            this.groupBox1.Controls.Add(this.overrideCategoryCheck);
            this.groupBox1.Controls.Add(this.activeCheckBox);
            this.groupBox1.Controls.Add(this.keyText);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.okButton);
            this.groupBox1.Controls.Add(this.urlText);
            this.groupBox1.Controls.Add(this.orderText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nameText);
            this.groupBox1.Controls.Add(this.typeCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // discoverRedirectsCheck
            // 
            this.discoverRedirectsCheck.AutoSize = true;
            this.discoverRedirectsCheck.Location = new System.Drawing.Point(77, 229);
            this.discoverRedirectsCheck.Name = "discoverRedirectsCheck";
            this.discoverRedirectsCheck.Size = new System.Drawing.Size(148, 17);
            this.discoverRedirectsCheck.TabIndex = 8;
            this.discoverRedirectsCheck.Text = "Discover redirected URLs";
            this.discoverRedirectsCheck.UseVisualStyleBackColor = true;
            // 
            // overrideCategoryCheck
            // 
            this.overrideCategoryCheck.AutoSize = true;
            this.overrideCategoryCheck.Location = new System.Drawing.Point(77, 206);
            this.overrideCategoryCheck.Name = "overrideCategoryCheck";
            this.overrideCategoryCheck.Size = new System.Drawing.Size(139, 17);
            this.overrideCategoryCheck.TabIndex = 7;
            this.overrideCategoryCheck.Text = "Override category name";
            this.toolTip1.SetToolTip(this.overrideCategoryCheck, "When checked, Category found by Client\'s \r\nis replaced with this specified resour" +
        "ce. This is useful\r\nwhen you want to represent category with something else.");
            this.overrideCategoryCheck.UseVisualStyleBackColor = true;
            // 
            // activeCheckBox
            // 
            this.activeCheckBox.AutoSize = true;
            this.activeCheckBox.Checked = true;
            this.activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeCheckBox.Location = new System.Drawing.Point(77, 183);
            this.activeCheckBox.Name = "activeCheckBox";
            this.activeCheckBox.Size = new System.Drawing.Size(56, 17);
            this.activeCheckBox.TabIndex = 6;
            this.activeCheckBox.Text = "Active";
            this.activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(77, 79);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(234, 20);
            this.keyText.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Key";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(158, 255);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(77, 255);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 9;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // urlText
            // 
            this.urlText.Location = new System.Drawing.Point(77, 131);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(412, 20);
            this.urlText.TabIndex = 4;
            this.urlText.Text = "http://";
            // 
            // orderText
            // 
            this.orderText.Location = new System.Drawing.Point(77, 157);
            this.orderText.Name = "orderText";
            this.orderText.Size = new System.Drawing.Size(52, 20);
            this.orderText.TabIndex = 5;
            this.orderText.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Order";
            // 
            // nameText
            // 
            this.nameText.Location = new System.Drawing.Point(77, 53);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(234, 20);
            this.nameText.TabIndex = 1;
            // 
            // typeCombo
            // 
            this.typeCombo.DisplayMember = "name";
            this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCombo.FormattingEnabled = true;
            this.typeCombo.Location = new System.Drawing.Point(77, 26);
            this.typeCombo.Name = "typeCombo";
            this.typeCombo.Size = new System.Drawing.Size(121, 21);
            this.typeCombo.TabIndex = 0;
            this.typeCombo.ValueMember = "id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(317, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "(Politics, Sports etc.)";
            // 
            // parentKeyText
            // 
            this.parentKeyText.Location = new System.Drawing.Point(77, 105);
            this.parentKeyText.Name = "parentKeyText";
            this.parentKeyText.Size = new System.Drawing.Size(234, 20);
            this.parentKeyText.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Parent Key";
            // 
            // AddEditCrextorResource
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(510, 290);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditCrextorResource";
            this.Text = "Crexta - Crextor Resource";
            this.Load += new System.EventHandler(this.AddEditCrextorResource_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.TextBox orderText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox activeCheckBox;
        private System.Windows.Forms.CheckBox overrideCategoryCheck;
        private System.Windows.Forms.CheckBox discoverRedirectsCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox parentKeyText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}