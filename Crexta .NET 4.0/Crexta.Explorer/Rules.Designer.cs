namespace Crexta.Explorer
{
    partial class Rules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rules));
            this.rulesListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ruleUpButton = new System.Windows.Forms.Button();
            this.ruleDownButton = new System.Windows.Forms.Button();
            this.deleteRuleButton = new System.Windows.Forms.Button();
            this.editRuleButton = new System.Windows.Forms.Button();
            this.addRuleButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.criteriaUpButton = new System.Windows.Forms.Button();
            this.criteriaDownButton = new System.Windows.Forms.Button();
            this.deleteCriteriaButton = new System.Windows.Forms.Button();
            this.criteriaListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editCriteriaButton = new System.Windows.Forms.Button();
            this.addCriteriaButton = new System.Windows.Forms.Button();
            this.Groupbox3 = new System.Windows.Forms.GroupBox();
            this.ruleListCombo = new System.Windows.Forms.ComboBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.Groupbox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // rulesListBox
            // 
            this.rulesListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.rulesListBox.DisplayMember = "Name";
            this.rulesListBox.FormattingEnabled = true;
            this.rulesListBox.Location = new System.Drawing.Point(10, 53);
            this.rulesListBox.Name = "rulesListBox";
            this.rulesListBox.Size = new System.Drawing.Size(213, 342);
            this.rulesListBox.TabIndex = 4;
            this.rulesListBox.SelectedIndexChanged += new System.EventHandler(this.rulesListBox_SelectedIndexChanged);
            this.rulesListBox.DoubleClick += new System.EventHandler(this.rulesListBox_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addNewToolStripMenuItem.Text = "&Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ruleUpButton);
            this.groupBox1.Controls.Add(this.ruleDownButton);
            this.groupBox1.Controls.Add(this.deleteRuleButton);
            this.groupBox1.Controls.Add(this.editRuleButton);
            this.groupBox1.Controls.Add(this.addRuleButton);
            this.groupBox1.Controls.Add(this.rulesListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 411);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rules";
            // 
            // ruleUpButton
            // 
            this.ruleUpButton.Image = global::Crexta.Explorer.Properties.Resources.up;
            this.ruleUpButton.Location = new System.Drawing.Point(228, 53);
            this.ruleUpButton.Name = "ruleUpButton";
            this.ruleUpButton.Size = new System.Drawing.Size(24, 163);
            this.ruleUpButton.TabIndex = 5;
            this.ruleUpButton.UseVisualStyleBackColor = true;
            this.ruleUpButton.Click += new System.EventHandler(this.ruleUpButton_Click);
            // 
            // ruleDownButton
            // 
            this.ruleDownButton.Image = global::Crexta.Explorer.Properties.Resources.down;
            this.ruleDownButton.Location = new System.Drawing.Point(228, 232);
            this.ruleDownButton.Name = "ruleDownButton";
            this.ruleDownButton.Size = new System.Drawing.Size(24, 163);
            this.ruleDownButton.TabIndex = 6;
            this.ruleDownButton.UseVisualStyleBackColor = true;
            this.ruleDownButton.Click += new System.EventHandler(this.ruleDownButton_Click);
            // 
            // deleteRuleButton
            // 
            this.deleteRuleButton.Location = new System.Drawing.Point(153, 19);
            this.deleteRuleButton.Name = "deleteRuleButton";
            this.deleteRuleButton.Size = new System.Drawing.Size(70, 23);
            this.deleteRuleButton.TabIndex = 3;
            this.deleteRuleButton.Text = "Delete";
            this.deleteRuleButton.UseVisualStyleBackColor = true;
            this.deleteRuleButton.Click += new System.EventHandler(this.deleteRuleButton_Click);
            // 
            // editRuleButton
            // 
            this.editRuleButton.Location = new System.Drawing.Point(82, 19);
            this.editRuleButton.Name = "editRuleButton";
            this.editRuleButton.Size = new System.Drawing.Size(69, 23);
            this.editRuleButton.TabIndex = 2;
            this.editRuleButton.Text = "Edit";
            this.editRuleButton.UseVisualStyleBackColor = true;
            this.editRuleButton.Click += new System.EventHandler(this.editRuleButton_Click);
            // 
            // addRuleButton
            // 
            this.addRuleButton.Location = new System.Drawing.Point(10, 19);
            this.addRuleButton.Name = "addRuleButton";
            this.addRuleButton.Size = new System.Drawing.Size(70, 23);
            this.addRuleButton.TabIndex = 1;
            this.addRuleButton.Text = "Add";
            this.addRuleButton.UseVisualStyleBackColor = true;
            this.addRuleButton.Click += new System.EventHandler(this.addRuleButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.criteriaUpButton);
            this.groupBox2.Controls.Add(this.criteriaDownButton);
            this.groupBox2.Controls.Add(this.deleteCriteriaButton);
            this.groupBox2.Controls.Add(this.criteriaListBox);
            this.groupBox2.Controls.Add(this.editCriteriaButton);
            this.groupBox2.Controls.Add(this.addCriteriaButton);
            this.groupBox2.Location = new System.Drawing.Point(303, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 411);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Criterias";
            // 
            // criteriaUpButton
            // 
            this.criteriaUpButton.Image = global::Crexta.Explorer.Properties.Resources.up;
            this.criteriaUpButton.Location = new System.Drawing.Point(228, 53);
            this.criteriaUpButton.Name = "criteriaUpButton";
            this.criteriaUpButton.Size = new System.Drawing.Size(24, 163);
            this.criteriaUpButton.TabIndex = 11;
            this.criteriaUpButton.UseVisualStyleBackColor = true;
            this.criteriaUpButton.Click += new System.EventHandler(this.criteriaUpButton_Click);
            // 
            // criteriaDownButton
            // 
            this.criteriaDownButton.Image = global::Crexta.Explorer.Properties.Resources.down;
            this.criteriaDownButton.Location = new System.Drawing.Point(228, 232);
            this.criteriaDownButton.Name = "criteriaDownButton";
            this.criteriaDownButton.Size = new System.Drawing.Size(24, 163);
            this.criteriaDownButton.TabIndex = 12;
            this.criteriaDownButton.UseVisualStyleBackColor = true;
            this.criteriaDownButton.Click += new System.EventHandler(this.criteriaDownButton_Click);
            // 
            // deleteCriteriaButton
            // 
            this.deleteCriteriaButton.Enabled = false;
            this.deleteCriteriaButton.Location = new System.Drawing.Point(152, 19);
            this.deleteCriteriaButton.Name = "deleteCriteriaButton";
            this.deleteCriteriaButton.Size = new System.Drawing.Size(70, 23);
            this.deleteCriteriaButton.TabIndex = 9;
            this.deleteCriteriaButton.Text = "Delete";
            this.deleteCriteriaButton.UseVisualStyleBackColor = true;
            this.deleteCriteriaButton.Click += new System.EventHandler(this.deleteCriteriaButton_Click);
            // 
            // criteriaListBox
            // 
            this.criteriaListBox.ContextMenuStrip = this.contextMenuStrip2;
            this.criteriaListBox.DisplayMember = "Name";
            this.criteriaListBox.FormattingEnabled = true;
            this.criteriaListBox.Location = new System.Drawing.Point(9, 53);
            this.criteriaListBox.Name = "criteriaListBox";
            this.criteriaListBox.Size = new System.Drawing.Size(213, 342);
            this.criteriaListBox.TabIndex = 10;
            this.criteriaListBox.DoubleClick += new System.EventHandler(this.criteriaListBox_DoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.editToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 114);
            this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
            // 
            // addNewToolStripMenuItem1
            // 
            this.addNewToolStripMenuItem1.Name = "addNewToolStripMenuItem1";
            this.addNewToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.addNewToolStripMenuItem1.Text = "Add New";
            this.addNewToolStripMenuItem1.Click += new System.EventHandler(this.addNewToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.copyToolStripMenuItem1.Text = "&Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.pasteToolStripMenuItem1.Text = "&Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.editToolStripMenuItem1.Text = "&Edit";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.editToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.deleteToolStripMenuItem1.Text = "&Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // editCriteriaButton
            // 
            this.editCriteriaButton.Enabled = false;
            this.editCriteriaButton.Location = new System.Drawing.Point(81, 19);
            this.editCriteriaButton.Name = "editCriteriaButton";
            this.editCriteriaButton.Size = new System.Drawing.Size(69, 23);
            this.editCriteriaButton.TabIndex = 8;
            this.editCriteriaButton.Text = "Edit";
            this.editCriteriaButton.UseVisualStyleBackColor = true;
            this.editCriteriaButton.Click += new System.EventHandler(this.editCriteriaButton_Click);
            // 
            // addCriteriaButton
            // 
            this.addCriteriaButton.Enabled = false;
            this.addCriteriaButton.Location = new System.Drawing.Point(9, 19);
            this.addCriteriaButton.Name = "addCriteriaButton";
            this.addCriteriaButton.Size = new System.Drawing.Size(70, 23);
            this.addCriteriaButton.TabIndex = 7;
            this.addCriteriaButton.Text = "Add";
            this.addCriteriaButton.UseVisualStyleBackColor = true;
            this.addCriteriaButton.Click += new System.EventHandler(this.addCriteriaButton_Click);
            // 
            // Groupbox3
            // 
            this.Groupbox3.Controls.Add(this.ruleListCombo);
            this.Groupbox3.Location = new System.Drawing.Point(12, 13);
            this.Groupbox3.Name = "Groupbox3";
            this.Groupbox3.Size = new System.Drawing.Size(550, 60);
            this.Groupbox3.TabIndex = 3;
            this.Groupbox3.TabStop = false;
            this.Groupbox3.Text = "Rule List";
            // 
            // ruleListCombo
            // 
            this.ruleListCombo.DisplayMember = "Name";
            this.ruleListCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruleListCombo.FormattingEnabled = true;
            this.ruleListCombo.Location = new System.Drawing.Point(10, 28);
            this.ruleListCombo.Name = "ruleListCombo";
            this.ruleListCombo.Size = new System.Drawing.Size(529, 21);
            this.ruleListCombo.TabIndex = 0;
            this.ruleListCombo.ValueMember = "id";
            this.ruleListCombo.SelectedIndexChanged += new System.EventHandler(this.ruleListCombo_SelectedIndexChanged);
            // 
            // warningLabel
            // 
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(12, 79);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(550, 27);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(325, 524);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 13;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(406, 524);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 14;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(487, 524);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // Rules
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(574, 557);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.Groupbox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rules";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Explorer - Rules";
            this.Load += new System.EventHandler(this.Rules_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Rules_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.Groupbox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox rulesListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox criteriaListBox;
        private System.Windows.Forms.Button deleteRuleButton;
        private System.Windows.Forms.Button editRuleButton;
        private System.Windows.Forms.Button addRuleButton;
        private System.Windows.Forms.Button deleteCriteriaButton;
        private System.Windows.Forms.Button editCriteriaButton;
        private System.Windows.Forms.Button addCriteriaButton;
        private System.Windows.Forms.GroupBox Groupbox3;
        private System.Windows.Forms.ComboBox ruleListCombo;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button ruleDownButton;
        private System.Windows.Forms.Button ruleUpButton;
        private System.Windows.Forms.Button criteriaUpButton;
        private System.Windows.Forms.Button criteriaDownButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;
    }
}