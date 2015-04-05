namespace Crexta.Explorer
{
    partial class RuleLists
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
            this.ruleListsListbox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteRuleListButton = new System.Windows.Forms.Button();
            this.editRuleListButton = new System.Windows.Forms.Button();
            this.addRuleListButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ruleListsListbox
            // 
            this.ruleListsListbox.ContextMenuStrip = this.contextMenuStrip1;
            this.ruleListsListbox.DisplayMember = "Name";
            this.ruleListsListbox.FormattingEnabled = true;
            this.ruleListsListbox.Location = new System.Drawing.Point(8, 43);
            this.ruleListsListbox.Name = "ruleListsListbox";
            this.ruleListsListbox.Size = new System.Drawing.Size(375, 355);
            this.ruleListsListbox.TabIndex = 1;
            this.ruleListsListbox.ValueMember = "id";
            this.ruleListsListbox.DoubleClick += new System.EventHandler(this.ruleListsListbox_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newListToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.editToolStripMenuItem,
            this.lockToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(115, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // newListToolStripMenuItem
            // 
            this.newListToolStripMenuItem.Name = "newListToolStripMenuItem";
            this.newListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newListToolStripMenuItem.Text = "&New List";
            this.newListToolStripMenuItem.Click += new System.EventHandler(this.newListToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lockToolStripMenuItem.Text = "Lock";
            this.lockToolStripMenuItem.Click += new System.EventHandler(this.lockToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.deleteRuleListButton);
            this.groupBox1.Controls.Add(this.ruleListsListbox);
            this.groupBox1.Controls.Add(this.editRuleListButton);
            this.groupBox1.Controls.Add(this.addRuleListButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 436);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rule Lists";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(308, 407);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(254, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Search";
            // 
            // deleteRuleListButton
            // 
            this.deleteRuleListButton.Location = new System.Drawing.Point(170, 407);
            this.deleteRuleListButton.Name = "deleteRuleListButton";
            this.deleteRuleListButton.Size = new System.Drawing.Size(75, 23);
            this.deleteRuleListButton.TabIndex = 4;
            this.deleteRuleListButton.Text = "Delete";
            this.deleteRuleListButton.UseVisualStyleBackColor = true;
            this.deleteRuleListButton.Click += new System.EventHandler(this.deleteRuleListButton_Click);
            // 
            // editRuleListButton
            // 
            this.editRuleListButton.Location = new System.Drawing.Point(89, 407);
            this.editRuleListButton.Name = "editRuleListButton";
            this.editRuleListButton.Size = new System.Drawing.Size(75, 23);
            this.editRuleListButton.TabIndex = 3;
            this.editRuleListButton.Text = "Edit";
            this.editRuleListButton.UseVisualStyleBackColor = true;
            this.editRuleListButton.Click += new System.EventHandler(this.editRuleListButton_Click);
            // 
            // addRuleListButton
            // 
            this.addRuleListButton.Location = new System.Drawing.Point(8, 407);
            this.addRuleListButton.Name = "addRuleListButton";
            this.addRuleListButton.Size = new System.Drawing.Size(75, 23);
            this.addRuleListButton.TabIndex = 2;
            this.addRuleListButton.Text = "Add";
            this.addRuleListButton.UseVisualStyleBackColor = true;
            this.addRuleListButton.Click += new System.EventHandler(this.addRuleListButton_Click);
            // 
            // RuleLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(411, 460);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RuleLists";
            this.Text = "Crexta - Rule Lists";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RuleLists_FormClosing);
            this.Load += new System.EventHandler(this.RuleLists_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ruleListsListbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteRuleListButton;
        private System.Windows.Forms.Button editRuleListButton;
        private System.Windows.Forms.Button addRuleListButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
    }
}