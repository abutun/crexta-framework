namespace Crexta.Explorer
{
    partial class AddEditRuleList
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
            this.label1 = new System.Windows.Forms.Label();
            this.ruleNameText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.preserveOriginalCheck = new System.Windows.Forms.CheckBox();
            this.selectRulePathButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ruleFilePathText = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // ruleNameText
            // 
            this.ruleNameText.Location = new System.Drawing.Point(47, 32);
            this.ruleNameText.Name = "ruleNameText";
            this.ruleNameText.Size = new System.Drawing.Size(215, 20);
            this.ruleNameText.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.preserveOriginalCheck);
            this.groupBox1.Controls.Add(this.selectRulePathButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ruleFilePathText);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.okButton);
            this.groupBox1.Controls.Add(this.ruleNameText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 138);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rule List";
            // 
            // preserveOriginalCheck
            // 
            this.preserveOriginalCheck.AutoSize = true;
            this.preserveOriginalCheck.Enabled = false;
            this.preserveOriginalCheck.Location = new System.Drawing.Point(47, 86);
            this.preserveOriginalCheck.Name = "preserveOriginalCheck";
            this.preserveOriginalCheck.Size = new System.Drawing.Size(106, 17);
            this.preserveOriginalCheck.TabIndex = 3;
            this.preserveOriginalCheck.Text = "Preserve Original";
            this.preserveOriginalCheck.UseVisualStyleBackColor = true;
            // 
            // selectRulePathButton
            // 
            this.selectRulePathButton.Enabled = false;
            this.selectRulePathButton.Location = new System.Drawing.Point(268, 56);
            this.selectRulePathButton.Name = "selectRulePathButton";
            this.selectRulePathButton.Size = new System.Drawing.Size(36, 23);
            this.selectRulePathButton.TabIndex = 2;
            this.selectRulePathButton.Text = "...";
            this.selectRulePathButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Path";
            // 
            // ruleFilePathText
            // 
            this.ruleFilePathText.Enabled = false;
            this.ruleFilePathText.Location = new System.Drawing.Point(47, 58);
            this.ruleFilePathText.Name = "ruleFilePathText";
            this.ruleFilePathText.Size = new System.Drawing.Size(215, 20);
            this.ruleFilePathText.TabIndex = 1;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(128, 109);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(47, 109);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AddEditRuleList
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(333, 162);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRuleList";
            this.Text = "Crexta - Rule List";
            this.Load += new System.EventHandler(this.AddEditRuleList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ruleNameText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button selectRulePathButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ruleFilePathText;
        private System.Windows.Forms.CheckBox preserveOriginalCheck;
    }
}