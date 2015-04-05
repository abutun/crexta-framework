namespace Crexta.Explorer
{
    partial class RegexTester
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.useUrlCheck = new System.Windows.Forms.CheckBox();
            this.useResult = new System.Windows.Forms.CheckBox();
            this.singleNodeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.regexText = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.urlText = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resultText = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.htmlText = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cultoreCheck = new System.Windows.Forms.CheckBox();
            this.ignoreWhiteCheck = new System.Windows.Forms.CheckBox();
            this.singleLineCheck = new System.Windows.Forms.CheckBox();
            this.multilineCheck = new System.Windows.Forms.CheckBox();
            this.ignoreCaseCheck = new System.Windows.Forms.CheckBox();
            this.compiledCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.useUrlCheck);
            this.groupBox1.Controls.Add(this.useResult);
            this.groupBox1.Controls.Add(this.singleNodeButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.regexText);
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.urlText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Url and Regular Expression";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(622, 89);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Regex Options";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // useUrlCheck
            // 
            this.useUrlCheck.AutoSize = true;
            this.useUrlCheck.Location = new System.Drawing.Point(198, 88);
            this.useUrlCheck.Name = "useUrlCheck";
            this.useUrlCheck.Size = new System.Drawing.Size(119, 17);
            this.useUrlCheck.TabIndex = 9;
            this.useUrlCheck.Text = "Use URL as source";
            this.useUrlCheck.UseVisualStyleBackColor = true;
            this.useUrlCheck.CheckedChanged += new System.EventHandler(this.useUrlCheck_CheckedChanged);
            // 
            // useResult
            // 
            this.useResult.AutoSize = true;
            this.useResult.Location = new System.Drawing.Point(47, 88);
            this.useResult.Name = "useResult";
            this.useResult.Size = new System.Drawing.Size(145, 17);
            this.useResult.TabIndex = 8;
            this.useResult.Text = "Use result as new source";
            this.useResult.UseVisualStyleBackColor = true;
            // 
            // singleNodeButton
            // 
            this.singleNodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.singleNodeButton.Location = new System.Drawing.Point(705, 47);
            this.singleNodeButton.Name = "singleNodeButton";
            this.singleNodeButton.Size = new System.Drawing.Size(75, 35);
            this.singleNodeButton.TabIndex = 5;
            this.singleNodeButton.Text = "Test Regex";
            this.singleNodeButton.UseVisualStyleBackColor = true;
            this.singleNodeButton.Click += new System.EventHandler(this.singleNodeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Regex";
            // 
            // regexText
            // 
            this.regexText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.regexText.Location = new System.Drawing.Point(47, 49);
            this.regexText.Multiline = true;
            this.regexText.Name = "regexText";
            this.regexText.Size = new System.Drawing.Size(652, 33);
            this.regexText.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(705, 21);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // urlText
            // 
            this.urlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlText.Location = new System.Drawing.Point(47, 23);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(652, 20);
            this.urlText.TabIndex = 0;
            this.urlText.Text = "http://";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resultText);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // resultText
            // 
            this.resultText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultText.Location = new System.Drawing.Point(3, 16);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(786, 162);
            this.resultText.TabIndex = 0;
            this.resultText.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(792, 276);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Browser";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 257);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Visual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(772, 225);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.htmlText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HTML";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // htmlText
            // 
            this.htmlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlText.Location = new System.Drawing.Point(3, 3);
            this.htmlText.Name = "htmlText";
            this.htmlText.Size = new System.Drawing.Size(772, 322);
            this.htmlText.TabIndex = 0;
            this.htmlText.Text = "";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 389);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(792, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsPanel.Controls.Add(this.groupBox4);
            this.optionsPanel.Location = new System.Drawing.Point(415, 86);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(206, 100);
            this.optionsPanel.TabIndex = 4;
            this.optionsPanel.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cultoreCheck);
            this.groupBox4.Controls.Add(this.ignoreWhiteCheck);
            this.groupBox4.Controls.Add(this.singleLineCheck);
            this.groupBox4.Controls.Add(this.multilineCheck);
            this.groupBox4.Controls.Add(this.ignoreCaseCheck);
            this.groupBox4.Controls.Add(this.compiledCheck);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // cultoreCheck
            // 
            this.cultoreCheck.AutoSize = true;
            this.cultoreCheck.Checked = true;
            this.cultoreCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cultoreCheck.Location = new System.Drawing.Point(96, 54);
            this.cultoreCheck.Name = "cultoreCheck";
            this.cultoreCheck.Size = new System.Drawing.Size(103, 17);
            this.cultoreCheck.TabIndex = 5;
            this.cultoreCheck.Text = "Culture Invariant";
            this.cultoreCheck.UseVisualStyleBackColor = true;
            // 
            // ignoreWhiteCheck
            // 
            this.ignoreWhiteCheck.AutoSize = true;
            this.ignoreWhiteCheck.Location = new System.Drawing.Point(7, 54);
            this.ignoreWhiteCheck.Name = "ignoreWhiteCheck";
            this.ignoreWhiteCheck.Size = new System.Drawing.Size(87, 17);
            this.ignoreWhiteCheck.TabIndex = 4;
            this.ignoreWhiteCheck.Text = "Ignore White";
            this.ignoreWhiteCheck.UseVisualStyleBackColor = true;
            // 
            // singleLineCheck
            // 
            this.singleLineCheck.AutoSize = true;
            this.singleLineCheck.Location = new System.Drawing.Point(96, 30);
            this.singleLineCheck.Name = "singleLineCheck";
            this.singleLineCheck.Size = new System.Drawing.Size(71, 17);
            this.singleLineCheck.TabIndex = 3;
            this.singleLineCheck.Text = "Singleline";
            this.singleLineCheck.UseVisualStyleBackColor = true;
            // 
            // multilineCheck
            // 
            this.multilineCheck.AutoSize = true;
            this.multilineCheck.Location = new System.Drawing.Point(7, 30);
            this.multilineCheck.Name = "multilineCheck";
            this.multilineCheck.Size = new System.Drawing.Size(64, 17);
            this.multilineCheck.TabIndex = 2;
            this.multilineCheck.Text = "Multiline";
            this.multilineCheck.UseVisualStyleBackColor = true;
            // 
            // ignoreCaseCheck
            // 
            this.ignoreCaseCheck.AutoSize = true;
            this.ignoreCaseCheck.Checked = true;
            this.ignoreCaseCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreCaseCheck.Location = new System.Drawing.Point(96, 7);
            this.ignoreCaseCheck.Name = "ignoreCaseCheck";
            this.ignoreCaseCheck.Size = new System.Drawing.Size(83, 17);
            this.ignoreCaseCheck.TabIndex = 1;
            this.ignoreCaseCheck.Text = "Ignore Case";
            this.ignoreCaseCheck.UseVisualStyleBackColor = true;
            // 
            // compiledCheck
            // 
            this.compiledCheck.AutoSize = true;
            this.compiledCheck.Checked = true;
            this.compiledCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.compiledCheck.Location = new System.Drawing.Point(7, 7);
            this.compiledCheck.Name = "compiledCheck";
            this.compiledCheck.Size = new System.Drawing.Size(69, 17);
            this.compiledCheck.TabIndex = 0;
            this.compiledCheck.Text = "Compiled";
            this.compiledCheck.UseVisualStyleBackColor = true;
            // 
            // RegexTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "RegexTester";
            this.Text = "Crexta - Regex Tester";
            this.Load += new System.EventHandler(this.XPathTester_Load);
            this.Click += new System.EventHandler(this.RegexTester_Click);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button singleNodeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox regexText;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox resultText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox htmlText;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.CheckBox useResult;
        private System.Windows.Forms.CheckBox useUrlCheck;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox singleLineCheck;
        private System.Windows.Forms.CheckBox multilineCheck;
        private System.Windows.Forms.CheckBox ignoreCaseCheck;
        private System.Windows.Forms.CheckBox compiledCheck;
        private System.Windows.Forms.CheckBox cultoreCheck;
        private System.Windows.Forms.CheckBox ignoreWhiteCheck;
    }
}