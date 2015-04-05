namespace Crexta.Explorer
{
    partial class ExcludeList
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
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.excludeReplaceValueText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.excludeExcludeWholeHTMLCheck = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.excludeTypeCombo = new System.Windows.Forms.ComboBox();
            this.excludeFindValueText = new System.Windows.Forms.TextBox();
            this.excludeNameText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.excludeListBox = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(6, 257);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(100, 23);
            this.newButton.TabIndex = 1;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(112, 257);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.excludeReplaceValueText);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.excludeExcludeWholeHTMLCheck);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.excludeTypeCombo);
            this.groupBox1.Controls.Add(this.excludeFindValueText);
            this.groupBox1.Controls.Add(this.excludeNameText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.excludeListBox);
            this.groupBox1.Controls.Add(this.newButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(577, 295);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exclude List Information";
            // 
            // excludeReplaceValueText
            // 
            this.excludeReplaceValueText.Location = new System.Drawing.Point(302, 183);
            this.excludeReplaceValueText.Multiline = true;
            this.excludeReplaceValueText.Name = "excludeReplaceValueText";
            this.excludeReplaceValueText.Size = new System.Drawing.Size(269, 65);
            this.excludeReplaceValueText.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Replace";
            // 
            // excludeExcludeWholeHTMLCheck
            // 
            this.excludeExcludeWholeHTMLCheck.AutoSize = true;
            this.excludeExcludeWholeHTMLCheck.Enabled = false;
            this.excludeExcludeWholeHTMLCheck.Location = new System.Drawing.Point(302, 90);
            this.excludeExcludeWholeHTMLCheck.Name = "excludeExcludeWholeHTMLCheck";
            this.excludeExcludeWholeHTMLCheck.Size = new System.Drawing.Size(155, 17);
            this.excludeExcludeWholeHTMLCheck.TabIndex = 5;
            this.excludeExcludeWholeHTMLCheck.Text = "Exclude whole HTML node";
            this.excludeExcludeWholeHTMLCheck.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(302, 257);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(441, 257);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(130, 23);
            this.updateButton.TabIndex = 9;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // excludeTypeCombo
            // 
            this.excludeTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.excludeTypeCombo.FormattingEnabled = true;
            this.excludeTypeCombo.Location = new System.Drawing.Point(302, 62);
            this.excludeTypeCombo.Name = "excludeTypeCombo";
            this.excludeTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.excludeTypeCombo.TabIndex = 4;
            this.excludeTypeCombo.SelectedIndexChanged += new System.EventHandler(this.excludeTypeCombo_SelectedIndexChanged);
            // 
            // excludeFindValueText
            // 
            this.excludeFindValueText.Location = new System.Drawing.Point(302, 113);
            this.excludeFindValueText.Multiline = true;
            this.excludeFindValueText.Name = "excludeFindValueText";
            this.excludeFindValueText.Size = new System.Drawing.Size(269, 65);
            this.excludeFindValueText.TabIndex = 6;
            // 
            // excludeNameText
            // 
            this.excludeNameText.Location = new System.Drawing.Point(302, 36);
            this.excludeNameText.Name = "excludeNameText";
            this.excludeNameText.Size = new System.Drawing.Size(170, 20);
            this.excludeNameText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Find";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Type";
            // 
            // excludeListBox
            // 
            this.excludeListBox.DisplayMember = "Name";
            this.excludeListBox.FormattingEnabled = true;
            this.excludeListBox.Location = new System.Drawing.Point(6, 36);
            this.excludeListBox.Name = "excludeListBox";
            this.excludeListBox.Size = new System.Drawing.Size(206, 212);
            this.excludeListBox.TabIndex = 0;
            this.excludeListBox.SelectedIndexChanged += new System.EventHandler(this.excludeListBox_SelectedIndexChanged);
            // 
            // ExcludeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 317);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ExcludeList";
            this.Text = "Crexta - Exclude List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExcludeList_FormClosing);
            this.Load += new System.EventHandler(this.ExcludeList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox excludeTypeCombo;
        private System.Windows.Forms.TextBox excludeFindValueText;
        private System.Windows.Forms.TextBox excludeNameText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox excludeListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.CheckBox excludeExcludeWholeHTMLCheck;
        private System.Windows.Forms.TextBox excludeReplaceValueText;
        private System.Windows.Forms.Label label4;
    }
}