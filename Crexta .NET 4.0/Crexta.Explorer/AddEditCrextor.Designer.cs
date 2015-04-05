namespace Crexta.Explorer
{
    partial class AddEditCrextor
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
            this.totalUrlLabel = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.crextorDescTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.crextorGroupsCombo = new System.Windows.Forms.ComboBox();
            this.totalResourceLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.useResourcesCheck = new System.Windows.Forms.CheckBox();
            this.totalResCountLink = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.crextorCountryCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.crextorPaidCheck = new System.Windows.Forms.CheckBox();
            this.crextorActiveCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.crextorRuleListCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.crextorTags = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.crextorURLText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crextorNameText = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.totalUrlLabel);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.crextorDescTextbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.crextorGroupsCombo);
            this.groupBox1.Controls.Add(this.totalResourceLabel);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.useResourcesCheck);
            this.groupBox1.Controls.Add(this.totalResCountLink);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.crextorCountryCombo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.crextorPaidCheck);
            this.groupBox1.Controls.Add(this.crextorActiveCheck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.crextorRuleListCombo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.crextorTags);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.crextorURLText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.crextorNameText);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.okButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crextor Information";
            // 
            // totalUrlLabel
            // 
            this.totalUrlLabel.AutoSize = true;
            this.totalUrlLabel.Location = new System.Drawing.Point(146, 283);
            this.totalUrlLabel.Name = "totalUrlLabel";
            this.totalUrlLabel.Size = new System.Drawing.Size(46, 13);
            this.totalUrlLabel.TabIndex = 23;
            this.totalUrlLabel.Text = "(Total 0)";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(68, 283);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 13);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Custom URLs";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Description";
            // 
            // crextorDescTextbox
            // 
            this.crextorDescTextbox.Location = new System.Drawing.Point(71, 83);
            this.crextorDescTextbox.Name = "crextorDescTextbox";
            this.crextorDescTextbox.Size = new System.Drawing.Size(287, 20);
            this.crextorDescTextbox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Group";
            // 
            // crextorGroupsCombo
            // 
            this.crextorGroupsCombo.DisplayMember = "Name";
            this.crextorGroupsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crextorGroupsCombo.FormattingEnabled = true;
            this.crextorGroupsCombo.Location = new System.Drawing.Point(71, 135);
            this.crextorGroupsCombo.Name = "crextorGroupsCombo";
            this.crextorGroupsCombo.Size = new System.Drawing.Size(190, 21);
            this.crextorGroupsCombo.TabIndex = 4;
            this.crextorGroupsCombo.ValueMember = "id";
            // 
            // totalResourceLabel
            // 
            this.totalResourceLabel.AutoSize = true;
            this.totalResourceLabel.Location = new System.Drawing.Point(146, 259);
            this.totalResourceLabel.Name = "totalResourceLabel";
            this.totalResourceLabel.Size = new System.Drawing.Size(46, 13);
            this.totalResourceLabel.TabIndex = 17;
            this.totalResourceLabel.Text = "(Total 0)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(43, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // useResourcesCheck
            // 
            this.useResourcesCheck.AutoSize = true;
            this.useResourcesCheck.Location = new System.Drawing.Point(71, 239);
            this.useResourcesCheck.Name = "useResourcesCheck";
            this.useResourcesCheck.Size = new System.Drawing.Size(162, 17);
            this.useResourcesCheck.TabIndex = 11;
            this.useResourcesCheck.Text = "Use resources (RSS, ATOM)";
            this.useResourcesCheck.UseVisualStyleBackColor = true;
            // 
            // totalResCountLink
            // 
            this.totalResCountLink.AutoSize = true;
            this.totalResCountLink.Location = new System.Drawing.Point(68, 261);
            this.totalResCountLink.Name = "totalResCountLink";
            this.totalResCountLink.Size = new System.Drawing.Size(58, 13);
            this.totalResCountLink.TabIndex = 12;
            this.totalResCountLink.TabStop = true;
            this.totalResCountLink.Text = "Resources";
            this.totalResCountLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Country";
            // 
            // crextorCountryCombo
            // 
            this.crextorCountryCombo.DisplayMember = "Name";
            this.crextorCountryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crextorCountryCombo.FormattingEnabled = true;
            this.crextorCountryCombo.Location = new System.Drawing.Point(71, 162);
            this.crextorCountryCombo.Name = "crextorCountryCombo";
            this.crextorCountryCombo.Size = new System.Drawing.Size(190, 21);
            this.crextorCountryCombo.TabIndex = 5;
            this.crextorCountryCombo.ValueMember = "id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // crextorPaidCheck
            // 
            this.crextorPaidCheck.AutoSize = true;
            this.crextorPaidCheck.Location = new System.Drawing.Point(151, 216);
            this.crextorPaidCheck.Name = "crextorPaidCheck";
            this.crextorPaidCheck.Size = new System.Drawing.Size(47, 17);
            this.crextorPaidCheck.TabIndex = 10;
            this.crextorPaidCheck.Text = "Paid";
            this.crextorPaidCheck.UseVisualStyleBackColor = true;
            // 
            // crextorActiveCheck
            // 
            this.crextorActiveCheck.AutoSize = true;
            this.crextorActiveCheck.Location = new System.Drawing.Point(71, 216);
            this.crextorActiveCheck.Name = "crextorActiveCheck";
            this.crextorActiveCheck.Size = new System.Drawing.Size(56, 17);
            this.crextorActiveCheck.TabIndex = 9;
            this.crextorActiveCheck.Text = "Active";
            this.crextorActiveCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rule List";
            // 
            // crextorRuleListCombo
            // 
            this.crextorRuleListCombo.DisplayMember = "Name";
            this.crextorRuleListCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.crextorRuleListCombo.FormattingEnabled = true;
            this.crextorRuleListCombo.Location = new System.Drawing.Point(71, 189);
            this.crextorRuleListCombo.Name = "crextorRuleListCombo";
            this.crextorRuleListCombo.Size = new System.Drawing.Size(190, 21);
            this.crextorRuleListCombo.TabIndex = 6;
            this.crextorRuleListCombo.ValueMember = "id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tags";
            // 
            // crextorTags
            // 
            this.crextorTags.Location = new System.Drawing.Point(71, 109);
            this.crextorTags.Name = "crextorTags";
            this.crextorTags.Size = new System.Drawing.Size(287, 20);
            this.crextorTags.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "URL";
            // 
            // crextorURLText
            // 
            this.crextorURLText.Location = new System.Drawing.Point(70, 57);
            this.crextorURLText.Name = "crextorURLText";
            this.crextorURLText.Size = new System.Drawing.Size(287, 20);
            this.crextorURLText.TabIndex = 1;
            this.crextorURLText.Text = "http://";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // crextorNameText
            // 
            this.crextorNameText.Location = new System.Drawing.Point(70, 31);
            this.crextorNameText.Name = "crextorNameText";
            this.crextorNameText.Size = new System.Drawing.Size(287, 20);
            this.crextorNameText.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(151, 308);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(70, 308);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 13;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AddEditCrextor
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(398, 363);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditCrextor";
            this.Text = "Crexta - Crextor";
            this.Load += new System.EventHandler(this.AddEditCrextor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox crextorActiveCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox crextorRuleListCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox crextorTags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox crextorURLText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox crextorNameText;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox crextorPaidCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox crextorCountryCombo;
        private System.Windows.Forms.LinkLabel totalResCountLink;
        private System.Windows.Forms.CheckBox useResourcesCheck;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label totalResourceLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox crextorGroupsCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox crextorDescTextbox;
        private System.Windows.Forms.Label totalUrlLabel;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}