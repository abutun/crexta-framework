namespace Crexta.Explorer
{
    partial class AddEditRules
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
            this.ruleEncoding = new System.Windows.Forms.ComboBox();
            this.clickItemTotalLabel = new System.Windows.Forms.Label();
            this.ruleClickItem = new System.Windows.Forms.LinkLabel();
            this.ruleTableNameText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ruleURLRegex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ruleNameText = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ruleEncoding);
            this.groupBox1.Controls.Add(this.clickItemTotalLabel);
            this.groupBox1.Controls.Add(this.ruleClickItem);
            this.groupBox1.Controls.Add(this.ruleTableNameText);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ruleURLRegex);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ruleNameText);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.okButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 258);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // ruleEncoding
            // 
            this.ruleEncoding.DisplayMember = "EncodingName";
            this.ruleEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruleEncoding.FormattingEnabled = true;
            this.ruleEncoding.Location = new System.Drawing.Point(103, 161);
            this.ruleEncoding.Name = "ruleEncoding";
            this.ruleEncoding.Size = new System.Drawing.Size(250, 21);
            this.ruleEncoding.TabIndex = 29;
            // 
            // clickItemTotalLabel
            // 
            this.clickItemTotalLabel.AutoSize = true;
            this.clickItemTotalLabel.Location = new System.Drawing.Point(133, 196);
            this.clickItemTotalLabel.Name = "clickItemTotalLabel";
            this.clickItemTotalLabel.Size = new System.Drawing.Size(49, 13);
            this.clickItemTotalLabel.TabIndex = 28;
            this.clickItemTotalLabel.Text = "(Total=0)";
            // 
            // ruleClickItem
            // 
            this.ruleClickItem.AutoSize = true;
            this.ruleClickItem.Enabled = false;
            this.ruleClickItem.Location = new System.Drawing.Point(100, 196);
            this.ruleClickItem.Name = "ruleClickItem";
            this.ruleClickItem.Size = new System.Drawing.Size(35, 13);
            this.ruleClickItem.TabIndex = 18;
            this.ruleClickItem.TabStop = true;
            this.ruleClickItem.Text = "Clicks";
            this.ruleClickItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ruleClickItem_LinkClicked);
            // 
            // ruleTableNameText
            // 
            this.ruleTableNameText.Location = new System.Drawing.Point(103, 48);
            this.ruleTableNameText.Name = "ruleTableNameText";
            this.ruleTableNameText.Size = new System.Drawing.Size(190, 20);
            this.ruleTableNameText.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "(/.*/|/)productDetails.aspx etc.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Table Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL match regex";
            // 
            // ruleURLRegex
            // 
            this.ruleURLRegex.Location = new System.Drawing.Point(103, 74);
            this.ruleURLRegex.Multiline = true;
            this.ruleURLRegex.Name = "ruleURLRegex";
            this.ruleURLRegex.Size = new System.Drawing.Size(362, 59);
            this.ruleURLRegex.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // ruleNameText
            // 
            this.ruleNameText.Location = new System.Drawing.Point(103, 22);
            this.ruleNameText.Name = "ruleNameText";
            this.ruleNameText.Size = new System.Drawing.Size(190, 20);
            this.ruleNameText.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(184, 221);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(103, 221);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Encoding";
            // 
            // AddEditRules
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(494, 258);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRules";
            this.Text = "Crexta - Rule";
            this.Load += new System.EventHandler(this.AddEditRules_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ruleURLRegex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ruleNameText;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ruleTableNameText;
        private System.Windows.Forms.LinkLabel ruleClickItem;
        private System.Windows.Forms.Label clickItemTotalLabel;
        private System.Windows.Forms.ComboBox ruleEncoding;
        private System.Windows.Forms.Label label2;
    }
}