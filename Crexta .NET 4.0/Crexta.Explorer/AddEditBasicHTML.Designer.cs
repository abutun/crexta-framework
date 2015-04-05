namespace Crexta.Explorer
{
    partial class AddEditBasicHTML
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
            this.okButton = new System.Windows.Forms.Button();
            this.basicHTMLResultHtmlNodeCheck = new System.Windows.Forms.CheckBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.basicHTMLNameText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.basicHTMLPrefixText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.basicHTMLEndCountText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.basicHTMLEndText = new System.Windows.Forms.TextBox();
            this.basicHTMLBeginText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(193, 315);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // basicHTMLResultHtmlNodeCheck
            // 
            this.basicHTMLResultHtmlNodeCheck.AutoSize = true;
            this.basicHTMLResultHtmlNodeCheck.Location = new System.Drawing.Point(80, 271);
            this.basicHTMLResultHtmlNodeCheck.Name = "basicHTMLResultHtmlNodeCheck";
            this.basicHTMLResultHtmlNodeCheck.Size = new System.Drawing.Size(146, 17);
            this.basicHTMLResultHtmlNodeCheck.TabIndex = 5;
            this.basicHTMLResultHtmlNodeCheck.Text = "Use result as HTMLNode";
            this.basicHTMLResultHtmlNodeCheck.UseVisualStyleBackColor = true;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(8, 40);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(35, 13);
            this.Label11.TabIndex = 2;
            this.Label11.Text = "Name";
            // 
            // basicHTMLNameText
            // 
            this.basicHTMLNameText.Location = new System.Drawing.Point(80, 37);
            this.basicHTMLNameText.Name = "basicHTMLNameText";
            this.basicHTMLNameText.Size = new System.Drawing.Size(239, 20);
            this.basicHTMLNameText.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.basicHTMLPrefixText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.basicHTMLEndCountText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.basicHTMLEndText);
            this.groupBox1.Controls.Add(this.basicHTMLBeginText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.basicHTMLNameText);
            this.groupBox1.Controls.Add(this.basicHTMLResultHtmlNodeCheck);
            this.groupBox1.Controls.Add(this.Label11);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 297);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic HTML Item";
            // 
            // basicHTMLPrefixText
            // 
            this.basicHTMLPrefixText.Location = new System.Drawing.Point(80, 245);
            this.basicHTMLPrefixText.Name = "basicHTMLPrefixText";
            this.basicHTMLPrefixText.Size = new System.Drawing.Size(239, 20);
            this.basicHTMLPrefixText.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Prefix";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "End Count";
            // 
            // basicHTMLEndCountText
            // 
            this.basicHTMLEndCountText.Location = new System.Drawing.Point(80, 219);
            this.basicHTMLEndCountText.Name = "basicHTMLEndCountText";
            this.basicHTMLEndCountText.Size = new System.Drawing.Size(25, 20);
            this.basicHTMLEndCountText.TabIndex = 3;
            this.basicHTMLEndCountText.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "End";
            // 
            // basicHTMLEndText
            // 
            this.basicHTMLEndText.Location = new System.Drawing.Point(80, 142);
            this.basicHTMLEndText.Multiline = true;
            this.basicHTMLEndText.Name = "basicHTMLEndText";
            this.basicHTMLEndText.Size = new System.Drawing.Size(239, 71);
            this.basicHTMLEndText.TabIndex = 2;
            // 
            // basicHTMLBeginText
            // 
            this.basicHTMLBeginText.Location = new System.Drawing.Point(80, 65);
            this.basicHTMLBeginText.Multiline = true;
            this.basicHTMLBeginText.Name = "basicHTMLBeginText";
            this.basicHTMLBeginText.Size = new System.Drawing.Size(239, 71);
            this.basicHTMLBeginText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Begin";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(274, 315);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddEditBasicHTML
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(366, 350);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditBasicHTML";
            this.Text = "Crexta - BasicHTML Item";
            this.Load += new System.EventHandler(this.AddEditBasicHTML_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.CheckBox basicHTMLResultHtmlNodeCheck;
        private System.Windows.Forms.Label Label11;
        private System.Windows.Forms.TextBox basicHTMLNameText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox basicHTMLPrefixText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox basicHTMLEndCountText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox basicHTMLEndText;
        private System.Windows.Forms.TextBox basicHTMLBeginText;
        private System.Windows.Forms.Label label1;
    }
}