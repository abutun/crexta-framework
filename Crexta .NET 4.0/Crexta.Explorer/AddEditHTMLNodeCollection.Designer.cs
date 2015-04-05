namespace Crexta.Explorer
{
    partial class AddEditHTMLNodeCollection
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
            this.returnAllNodesCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.htmlNodeColResultIndexText = new System.Windows.Forms.TextBox();
            this.htmlNodeColXPathText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.htmlNodeColNameText = new System.Windows.Forms.TextBox();
            this.htmlNodeColReturnOnlyTextCheck = new System.Windows.Forms.CheckBox();
            this.basicHTMLNameText = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.returnAllNodesCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.htmlNodeColResultIndexText);
            this.groupBox1.Controls.Add(this.htmlNodeColXPathText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.htmlNodeColNameText);
            this.groupBox1.Controls.Add(this.htmlNodeColReturnOnlyTextCheck);
            this.groupBox1.Controls.Add(this.basicHTMLNameText);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 168);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "HTML Node Collection Item";
            // 
            // returnAllNodesCheck
            // 
            this.returnAllNodesCheck.AutoSize = true;
            this.returnAllNodesCheck.Location = new System.Drawing.Point(80, 138);
            this.returnAllNodesCheck.Name = "returnAllNodesCheck";
            this.returnAllNodesCheck.Size = new System.Drawing.Size(103, 17);
            this.returnAllNodesCheck.TabIndex = 4;
            this.returnAllNodesCheck.Text = "Return all nodes";
            this.returnAllNodesCheck.UseVisualStyleBackColor = true;
            this.returnAllNodesCheck.CheckedChanged += new System.EventHandler(this.returnAllNodesCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Result Index";
            // 
            // htmlNodeColResultIndexText
            // 
            this.htmlNodeColResultIndexText.Location = new System.Drawing.Point(80, 89);
            this.htmlNodeColResultIndexText.Name = "htmlNodeColResultIndexText";
            this.htmlNodeColResultIndexText.Size = new System.Drawing.Size(26, 20);
            this.htmlNodeColResultIndexText.TabIndex = 2;
            this.htmlNodeColResultIndexText.Text = "0";
            // 
            // htmlNodeColXPathText
            // 
            this.htmlNodeColXPathText.Location = new System.Drawing.Point(80, 63);
            this.htmlNodeColXPathText.Name = "htmlNodeColXPathText";
            this.htmlNodeColXPathText.Size = new System.Drawing.Size(239, 20);
            this.htmlNodeColXPathText.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "XPath";
            // 
            // htmlNodeColNameText
            // 
            this.htmlNodeColNameText.Location = new System.Drawing.Point(80, 37);
            this.htmlNodeColNameText.Name = "htmlNodeColNameText";
            this.htmlNodeColNameText.Size = new System.Drawing.Size(239, 20);
            this.htmlNodeColNameText.TabIndex = 0;
            // 
            // htmlNodeColReturnOnlyTextCheck
            // 
            this.htmlNodeColReturnOnlyTextCheck.AutoSize = true;
            this.htmlNodeColReturnOnlyTextCheck.Location = new System.Drawing.Point(80, 115);
            this.htmlNodeColReturnOnlyTextCheck.Name = "htmlNodeColReturnOnlyTextCheck";
            this.htmlNodeColReturnOnlyTextCheck.Size = new System.Drawing.Size(127, 17);
            this.htmlNodeColReturnOnlyTextCheck.TabIndex = 3;
            this.htmlNodeColReturnOnlyTextCheck.Text = "Return only node text";
            this.htmlNodeColReturnOnlyTextCheck.UseVisualStyleBackColor = true;
            // 
            // basicHTMLNameText
            // 
            this.basicHTMLNameText.AutoSize = true;
            this.basicHTMLNameText.Location = new System.Drawing.Point(8, 40);
            this.basicHTMLNameText.Name = "basicHTMLNameText";
            this.basicHTMLNameText.Size = new System.Drawing.Size(35, 13);
            this.basicHTMLNameText.TabIndex = 2;
            this.basicHTMLNameText.Text = "Name";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(272, 184);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(191, 184);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AddEditHTMLNodeCollection
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(360, 217);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditHTMLNodeCollection";
            this.Text = "Crexta - HTMLNodeCollection Item";
            this.Load += new System.EventHandler(this.AddEditHTMLNodeCollection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox htmlNodeColXPathText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox htmlNodeColNameText;
        private System.Windows.Forms.CheckBox htmlNodeColReturnOnlyTextCheck;
        private System.Windows.Forms.Label basicHTMLNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox htmlNodeColResultIndexText;
        private System.Windows.Forms.CheckBox returnAllNodesCheck;
    }
}