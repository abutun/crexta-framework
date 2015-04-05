namespace Crexta.Explorer
{
    partial class RuleTester
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.parserLogList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xmlTreeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.htmlTreeView = new System.Windows.Forms.TreeView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.relevantRuleIndex = new System.Windows.Forms.Label();
            this.showInBrowser = new System.Windows.Forms.CheckBox();
            this.testButton = new System.Windows.Forms.Button();
            this.ruleListCombo = new System.Windows.Forms.ComboBox();
            this.urlText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.parserLogList);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(0, 411);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(591, 162);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rule List Parser Log";
            // 
            // parserLogList
            // 
            this.parserLogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parserLogList.FormattingEnabled = true;
            this.parserLogList.Location = new System.Drawing.Point(3, 16);
            this.parserLogList.Name = "parserLogList";
            this.parserLogList.Size = new System.Drawing.Size(585, 134);
            this.parserLogList.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox7);
            this.splitContainer2.Size = new System.Drawing.Size(792, 573);
            this.splitContainer2.SplitterDistance = 197;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.xmlTreeView);
            this.groupBox2.Location = new System.Drawing.Point(3, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 302);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result XML Tree";
            // 
            // xmlTreeView
            // 
            this.xmlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xmlTreeView.Location = new System.Drawing.Point(3, 16);
            this.xmlTreeView.Name = "xmlTreeView";
            this.xmlTreeView.Size = new System.Drawing.Size(182, 283);
            this.xmlTreeView.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.htmlTreeView);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 265);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Document HTML Tree";
            // 
            // htmlTreeView
            // 
            this.htmlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlTreeView.Location = new System.Drawing.Point(3, 16);
            this.htmlTreeView.Name = "htmlTreeView";
            this.htmlTreeView.Size = new System.Drawing.Size(182, 246);
            this.htmlTreeView.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.webBrowser1);
            this.groupBox6.Location = new System.Drawing.Point(0, 60);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(591, 348);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Browser";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(585, 329);
            this.webBrowser1.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.relevantRuleIndex);
            this.groupBox7.Controls.Add(this.showInBrowser);
            this.groupBox7.Controls.Add(this.testButton);
            this.groupBox7.Controls.Add(this.ruleListCombo);
            this.groupBox7.Controls.Add(this.urlText);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(591, 60);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // relevantRuleIndex
            // 
            this.relevantRuleIndex.AutoSize = true;
            this.relevantRuleIndex.Location = new System.Drawing.Point(387, 39);
            this.relevantRuleIndex.Name = "relevantRuleIndex";
            this.relevantRuleIndex.Size = new System.Drawing.Size(0, 13);
            this.relevantRuleIndex.TabIndex = 5;
            // 
            // showInBrowser
            // 
            this.showInBrowser.AutoSize = true;
            this.showInBrowser.Location = new System.Drawing.Point(47, 37);
            this.showInBrowser.Name = "showInBrowser";
            this.showInBrowser.Size = new System.Drawing.Size(126, 17);
            this.showInBrowser.TabIndex = 4;
            this.showInBrowser.Text = "Show also in browser";
            this.showInBrowser.UseVisualStyleBackColor = true;
            this.showInBrowser.CheckedChanged += new System.EventHandler(this.shewInBrowser_CheckedChanged);
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton.Location = new System.Drawing.Point(510, 11);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 3;
            this.testButton.Text = "Test Rule";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // ruleListCombo
            // 
            this.ruleListCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ruleListCombo.DisplayMember = "name";
            this.ruleListCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruleListCombo.FormattingEnabled = true;
            this.ruleListCombo.Location = new System.Drawing.Point(383, 13);
            this.ruleListCombo.Name = "ruleListCombo";
            this.ruleListCombo.Size = new System.Drawing.Size(121, 21);
            this.ruleListCombo.TabIndex = 2;
            this.ruleListCombo.ValueMember = "id";
            // 
            // urlText
            // 
            this.urlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlText.Location = new System.Drawing.Point(47, 13);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(330, 20);
            this.urlText.TabIndex = 1;
            this.urlText.Text = "http://";
            this.urlText.TextChanged += new System.EventHandler(this.urlText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "URL :";
            // 
            // RuleTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.splitContainer2);
            this.Name = "RuleTester";
            this.Text = "Crexta - Rule Tester";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RuleTester_Load);
            this.groupBox5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.ComboBox ruleListCombo;
        private System.Windows.Forms.TextBox urlText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView htmlTreeView;
        private System.Windows.Forms.ListBox parserLogList;
        private System.Windows.Forms.TreeView xmlTreeView;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.CheckBox showInBrowser;
        private System.Windows.Forms.Label relevantRuleIndex;
    }
}