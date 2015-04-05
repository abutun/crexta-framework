namespace Crexta.Explorer
{
    partial class AddEditRegularExpression
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
            this.resultMatchIndex = new System.Windows.Forms.TextBox();
            this.returnAllMatchesCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.regexResultPrefixText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.regexUseResultAsNodeCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.regexGroupIndexText = new System.Windows.Forms.TextBox();
            this.regexPatternText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.regexNameText = new System.Windows.Forms.TextBox();
            this.regexUseGroupCheck = new System.Windows.Forms.CheckBox();
            this.basicHTMLNameText = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.regexOptionCompiledCheck = new System.Windows.Forms.CheckBox();
            this.regexOptionIgnoreCaseCheck = new System.Windows.Forms.CheckBox();
            this.regexOptionCultureCheck = new System.Windows.Forms.CheckBox();
            this.regexOptionSinglelineCheck = new System.Windows.Forms.CheckBox();
            this.regexOptionMultilineCheck = new System.Windows.Forms.CheckBox();
            this.overrideRulePatternCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.overrideRulePatternCheckBox);
            this.groupBox1.Controls.Add(this.resultMatchIndex);
            this.groupBox1.Controls.Add(this.returnAllMatchesCheck);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.regexResultPrefixText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.regexUseResultAsNodeCheck);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.regexGroupIndexText);
            this.groupBox1.Controls.Add(this.regexPatternText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.regexNameText);
            this.groupBox1.Controls.Add(this.regexUseGroupCheck);
            this.groupBox1.Controls.Add(this.basicHTMLNameText);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 296);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Regular Expression Item";
            // 
            // resultMatchIndex
            // 
            this.resultMatchIndex.Location = new System.Drawing.Point(80, 156);
            this.resultMatchIndex.Name = "resultMatchIndex";
            this.resultMatchIndex.Size = new System.Drawing.Size(36, 20);
            this.resultMatchIndex.TabIndex = 17;
            this.resultMatchIndex.Text = "0";
            // 
            // returnAllMatchesCheck
            // 
            this.returnAllMatchesCheck.AutoSize = true;
            this.returnAllMatchesCheck.Location = new System.Drawing.Point(79, 182);
            this.returnAllMatchesCheck.Name = "returnAllMatchesCheck";
            this.returnAllMatchesCheck.Size = new System.Drawing.Size(114, 17);
            this.returnAllMatchesCheck.TabIndex = 16;
            this.returnAllMatchesCheck.Text = "Return all matches";
            this.returnAllMatchesCheck.UseVisualStyleBackColor = true;
            this.returnAllMatchesCheck.CheckedChanged += new System.EventHandler(this.returnAllMatchesCheck_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Match Index";
            // 
            // regexResultPrefixText
            // 
            this.regexResultPrefixText.Location = new System.Drawing.Point(79, 228);
            this.regexResultPrefixText.Name = "regexResultPrefixText";
            this.regexResultPrefixText.Size = new System.Drawing.Size(239, 20);
            this.regexResultPrefixText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Prefix";
            // 
            // regexUseResultAsNodeCheck
            // 
            this.regexUseResultAsNodeCheck.AutoSize = true;
            this.regexUseResultAsNodeCheck.Location = new System.Drawing.Point(79, 254);
            this.regexUseResultAsNodeCheck.Name = "regexUseResultAsNodeCheck";
            this.regexUseResultAsNodeCheck.Size = new System.Drawing.Size(146, 17);
            this.regexUseResultAsNodeCheck.TabIndex = 5;
            this.regexUseResultAsNodeCheck.Text = "Use result as HTMLNode";
            this.regexUseResultAsNodeCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Group Index";
            // 
            // regexGroupIndexText
            // 
            this.regexGroupIndexText.Location = new System.Drawing.Point(282, 203);
            this.regexGroupIndexText.Name = "regexGroupIndexText";
            this.regexGroupIndexText.Size = new System.Drawing.Size(36, 20);
            this.regexGroupIndexText.TabIndex = 3;
            this.regexGroupIndexText.Text = "0";
            this.regexGroupIndexText.TextChanged += new System.EventHandler(this.regexGroupIndexText_TextChanged);
            // 
            // regexPatternText
            // 
            this.regexPatternText.Location = new System.Drawing.Point(80, 85);
            this.regexPatternText.Multiline = true;
            this.regexPatternText.Name = "regexPatternText";
            this.regexPatternText.Size = new System.Drawing.Size(296, 65);
            this.regexPatternText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pattern";
            // 
            // regexNameText
            // 
            this.regexNameText.Location = new System.Drawing.Point(80, 33);
            this.regexNameText.Name = "regexNameText";
            this.regexNameText.Size = new System.Drawing.Size(296, 20);
            this.regexNameText.TabIndex = 0;
            // 
            // regexUseGroupCheck
            // 
            this.regexUseGroupCheck.AutoSize = true;
            this.regexUseGroupCheck.Location = new System.Drawing.Point(79, 205);
            this.regexUseGroupCheck.Name = "regexUseGroupCheck";
            this.regexUseGroupCheck.Size = new System.Drawing.Size(75, 17);
            this.regexUseGroupCheck.TabIndex = 2;
            this.regexUseGroupCheck.Text = "Use group";
            this.regexUseGroupCheck.UseVisualStyleBackColor = true;
            this.regexUseGroupCheck.CheckedChanged += new System.EventHandler(this.regexUseGroupCheck_CheckedChanged);
            // 
            // basicHTMLNameText
            // 
            this.basicHTMLNameText.AutoSize = true;
            this.basicHTMLNameText.Location = new System.Drawing.Point(8, 36);
            this.basicHTMLNameText.Name = "basicHTMLNameText";
            this.basicHTMLNameText.Size = new System.Drawing.Size(35, 13);
            this.basicHTMLNameText.TabIndex = 2;
            this.basicHTMLNameText.Text = "Name";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(320, 397);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(239, 397);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.regexOptionCompiledCheck);
            this.groupBox2.Controls.Add(this.regexOptionIgnoreCaseCheck);
            this.groupBox2.Controls.Add(this.regexOptionCultureCheck);
            this.groupBox2.Controls.Add(this.regexOptionSinglelineCheck);
            this.groupBox2.Controls.Add(this.regexOptionMultilineCheck);
            this.groupBox2.Location = new System.Drawing.Point(12, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 77);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Regex Options";
            // 
            // regexOptionCompiledCheck
            // 
            this.regexOptionCompiledCheck.AutoSize = true;
            this.regexOptionCompiledCheck.Checked = true;
            this.regexOptionCompiledCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.regexOptionCompiledCheck.Location = new System.Drawing.Point(308, 23);
            this.regexOptionCompiledCheck.Name = "regexOptionCompiledCheck";
            this.regexOptionCompiledCheck.Size = new System.Drawing.Size(69, 17);
            this.regexOptionCompiledCheck.TabIndex = 8;
            this.regexOptionCompiledCheck.Text = "Compiled";
            this.regexOptionCompiledCheck.UseVisualStyleBackColor = true;
            // 
            // regexOptionIgnoreCaseCheck
            // 
            this.regexOptionIgnoreCaseCheck.AutoSize = true;
            this.regexOptionIgnoreCaseCheck.Checked = true;
            this.regexOptionIgnoreCaseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.regexOptionIgnoreCaseCheck.Location = new System.Drawing.Point(164, 47);
            this.regexOptionIgnoreCaseCheck.Name = "regexOptionIgnoreCaseCheck";
            this.regexOptionIgnoreCaseCheck.Size = new System.Drawing.Size(83, 17);
            this.regexOptionIgnoreCaseCheck.TabIndex = 10;
            this.regexOptionIgnoreCaseCheck.Text = "Ignore Case";
            this.regexOptionIgnoreCaseCheck.UseVisualStyleBackColor = true;
            // 
            // regexOptionCultureCheck
            // 
            this.regexOptionCultureCheck.AutoSize = true;
            this.regexOptionCultureCheck.Checked = true;
            this.regexOptionCultureCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.regexOptionCultureCheck.Location = new System.Drawing.Point(6, 47);
            this.regexOptionCultureCheck.Name = "regexOptionCultureCheck";
            this.regexOptionCultureCheck.Size = new System.Drawing.Size(103, 17);
            this.regexOptionCultureCheck.TabIndex = 9;
            this.regexOptionCultureCheck.Text = "Culture Invariant";
            this.regexOptionCultureCheck.UseVisualStyleBackColor = true;
            // 
            // regexOptionSinglelineCheck
            // 
            this.regexOptionSinglelineCheck.AutoSize = true;
            this.regexOptionSinglelineCheck.Location = new System.Drawing.Point(164, 23);
            this.regexOptionSinglelineCheck.Name = "regexOptionSinglelineCheck";
            this.regexOptionSinglelineCheck.Size = new System.Drawing.Size(71, 17);
            this.regexOptionSinglelineCheck.TabIndex = 7;
            this.regexOptionSinglelineCheck.Text = "Singleline";
            this.regexOptionSinglelineCheck.UseVisualStyleBackColor = true;
            // 
            // regexOptionMultilineCheck
            // 
            this.regexOptionMultilineCheck.AutoSize = true;
            this.regexOptionMultilineCheck.Location = new System.Drawing.Point(6, 23);
            this.regexOptionMultilineCheck.Name = "regexOptionMultilineCheck";
            this.regexOptionMultilineCheck.Size = new System.Drawing.Size(64, 17);
            this.regexOptionMultilineCheck.TabIndex = 6;
            this.regexOptionMultilineCheck.Text = "Multiline";
            this.regexOptionMultilineCheck.UseVisualStyleBackColor = true;
            // 
            // overrideRulePatternCheckBox
            // 
            this.overrideRulePatternCheckBox.AutoSize = true;
            this.overrideRulePatternCheckBox.Location = new System.Drawing.Point(80, 59);
            this.overrideRulePatternCheckBox.Name = "overrideRulePatternCheckBox";
            this.overrideRulePatternCheckBox.Size = new System.Drawing.Size(122, 17);
            this.overrideRulePatternCheckBox.TabIndex = 18;
            this.overrideRulePatternCheckBox.Text = "Override rule pattern";
            this.overrideRulePatternCheckBox.UseVisualStyleBackColor = true;
            this.overrideRulePatternCheckBox.CheckedChanged += new System.EventHandler(this.overrideRulePatternCheckBox_CheckedChanged);
            // 
            // AddEditRegularExpression
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(406, 434);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRegularExpression";
            this.Text = "Crexta - RegularExpression";
            this.Load += new System.EventHandler(this.AddEditRegularExpression_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox regexGroupIndexText;
        private System.Windows.Forms.TextBox regexPatternText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox regexNameText;
        private System.Windows.Forms.CheckBox regexUseGroupCheck;
        private System.Windows.Forms.Label basicHTMLNameText;
        private System.Windows.Forms.CheckBox regexUseResultAsNodeCheck;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox regexOptionCompiledCheck;
        private System.Windows.Forms.CheckBox regexOptionIgnoreCaseCheck;
        private System.Windows.Forms.CheckBox regexOptionCultureCheck;
        private System.Windows.Forms.CheckBox regexOptionSinglelineCheck;
        private System.Windows.Forms.CheckBox regexOptionMultilineCheck;
        private System.Windows.Forms.TextBox regexResultPrefixText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox returnAllMatchesCheck;
        private System.Windows.Forms.TextBox resultMatchIndex;
        private System.Windows.Forms.CheckBox overrideRulePatternCheckBox;
    }
}