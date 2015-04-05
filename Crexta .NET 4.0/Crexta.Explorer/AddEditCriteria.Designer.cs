namespace Crexta.Explorer
{
    partial class AddEditCriteria
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
            this.criteriaExcludeListTotalLabel = new System.Windows.Forms.Label();
            this.criteriaNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.criteriaExcludeListLink = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.criteriaLowercaseCheck = new System.Windows.Forms.CheckBox();
            this.criteriaUppercaseCheck = new System.Windows.Forms.CheckBox();
            this.criteriaClearWhitespacesCheck = new System.Windows.Forms.CheckBox();
            this.criteriaStripASCIICodesCheck = new System.Windows.Forms.CheckBox();
            this.criteriaClearHTMLTagsCheck = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.criteriaColumnNameCombo = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.criteriaUseURLForMatchCheck = new System.Windows.Forms.CheckBox();
            this.criteriaDefaultTextCaseCheck = new System.Windows.Forms.CheckBox();
            this.criteriaClearHTMLCommentCheck = new System.Windows.Forms.CheckBox();
            this.criteriaClearScriptTagsCheck = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.criteriaDefaultValueText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.criteriaItemEditButton = new System.Windows.Forms.Button();
            this.criteriaItemDownButton = new System.Windows.Forms.Button();
            this.criteriaItemDeleteButton = new System.Windows.Forms.Button();
            this.criteriaItemUpButton = new System.Windows.Forms.Button();
            this.criteriaRegexButton = new System.Windows.Forms.Button();
            this.criteriaHTMLNodeCollectionButton = new System.Windows.Forms.Button();
            this.criteriaHTMLNodeButton = new System.Windows.Forms.Button();
            this.criteriaBasicHTMLButton = new System.Windows.Forms.Button();
            this.criteriaItemsList = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.criteriaExtraFieldIIIText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.criteriaExtraFieldIIText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.criteriaExtraFieldIText = new System.Windows.Forms.TextBox();
            this.columnTypeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.criteriaExcludeListTotalLabel);
            this.groupBox1.Controls.Add(this.criteriaNameText);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.criteriaExcludeListLink);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criteria Information";
            // 
            // criteriaExcludeListTotalLabel
            // 
            this.criteriaExcludeListTotalLabel.AutoSize = true;
            this.criteriaExcludeListTotalLabel.Location = new System.Drawing.Point(130, 46);
            this.criteriaExcludeListTotalLabel.Name = "criteriaExcludeListTotalLabel";
            this.criteriaExcludeListTotalLabel.Size = new System.Drawing.Size(49, 13);
            this.criteriaExcludeListTotalLabel.TabIndex = 27;
            this.criteriaExcludeListTotalLabel.Text = "(Total=0)";
            // 
            // criteriaNameText
            // 
            this.criteriaNameText.Location = new System.Drawing.Point(81, 19);
            this.criteriaNameText.Name = "criteriaNameText";
            this.criteriaNameText.Size = new System.Drawing.Size(314, 20);
            this.criteriaNameText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // criteriaExcludeListLink
            // 
            this.criteriaExcludeListLink.AutoSize = true;
            this.criteriaExcludeListLink.Location = new System.Drawing.Point(78, 46);
            this.criteriaExcludeListLink.Name = "criteriaExcludeListLink";
            this.criteriaExcludeListLink.Size = new System.Drawing.Size(56, 13);
            this.criteriaExcludeListLink.TabIndex = 2;
            this.criteriaExcludeListLink.TabStop = true;
            this.criteriaExcludeListLink.Text = "Click Here";
            this.criteriaExcludeListLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.criteriaExcludeListLink_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Exclude List";
            // 
            // criteriaLowercaseCheck
            // 
            this.criteriaLowercaseCheck.AutoSize = true;
            this.criteriaLowercaseCheck.Location = new System.Drawing.Point(9, 61);
            this.criteriaLowercaseCheck.Name = "criteriaLowercaseCheck";
            this.criteriaLowercaseCheck.Size = new System.Drawing.Size(78, 17);
            this.criteriaLowercaseCheck.TabIndex = 25;
            this.criteriaLowercaseCheck.Text = "Lowercase";
            this.criteriaLowercaseCheck.UseVisualStyleBackColor = true;
            this.criteriaLowercaseCheck.CheckedChanged += new System.EventHandler(this.criteriaLowercaseCheck_CheckedChanged);
            // 
            // criteriaUppercaseCheck
            // 
            this.criteriaUppercaseCheck.AutoSize = true;
            this.criteriaUppercaseCheck.Location = new System.Drawing.Point(166, 61);
            this.criteriaUppercaseCheck.Name = "criteriaUppercaseCheck";
            this.criteriaUppercaseCheck.Size = new System.Drawing.Size(78, 17);
            this.criteriaUppercaseCheck.TabIndex = 26;
            this.criteriaUppercaseCheck.Text = "Uppercase";
            this.criteriaUppercaseCheck.UseVisualStyleBackColor = true;
            this.criteriaUppercaseCheck.CheckedChanged += new System.EventHandler(this.criteriaUppercaseCheck_CheckedChanged);
            // 
            // criteriaClearWhitespacesCheck
            // 
            this.criteriaClearWhitespacesCheck.AutoSize = true;
            this.criteriaClearWhitespacesCheck.Location = new System.Drawing.Point(339, 15);
            this.criteriaClearWhitespacesCheck.Name = "criteriaClearWhitespacesCheck";
            this.criteriaClearWhitespacesCheck.Size = new System.Drawing.Size(115, 17);
            this.criteriaClearWhitespacesCheck.TabIndex = 21;
            this.criteriaClearWhitespacesCheck.Text = "Clear Whitespaces";
            this.criteriaClearWhitespacesCheck.UseVisualStyleBackColor = true;
            // 
            // criteriaStripASCIICodesCheck
            // 
            this.criteriaStripASCIICodesCheck.AutoSize = true;
            this.criteriaStripASCIICodesCheck.Location = new System.Drawing.Point(9, 38);
            this.criteriaStripASCIICodesCheck.Name = "criteriaStripASCIICodesCheck";
            this.criteriaStripASCIICodesCheck.Size = new System.Drawing.Size(110, 17);
            this.criteriaStripASCIICodesCheck.TabIndex = 22;
            this.criteriaStripASCIICodesCheck.Text = "Strip ASCII Codes";
            this.criteriaStripASCIICodesCheck.UseVisualStyleBackColor = true;
            // 
            // criteriaClearHTMLTagsCheck
            // 
            this.criteriaClearHTMLTagsCheck.AutoSize = true;
            this.criteriaClearHTMLTagsCheck.Location = new System.Drawing.Point(10, 15);
            this.criteriaClearHTMLTagsCheck.Name = "criteriaClearHTMLTagsCheck";
            this.criteriaClearHTMLTagsCheck.Size = new System.Drawing.Size(110, 17);
            this.criteriaClearHTMLTagsCheck.TabIndex = 19;
            this.criteriaClearHTMLTagsCheck.Text = "Clear HTML Tags";
            this.criteriaClearHTMLTagsCheck.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Column Name";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(399, 547);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 29;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(318, 547);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 28;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.columnTypeTextBox);
            this.groupBox2.Controls.Add(this.criteriaColumnNameCombo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(462, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DB Mapping";
            // 
            // criteriaColumnNameCombo
            // 
            this.criteriaColumnNameCombo.DisplayMember = "FieldName";
            this.criteriaColumnNameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.criteriaColumnNameCombo.FormattingEnabled = true;
            this.criteriaColumnNameCombo.Location = new System.Drawing.Point(81, 18);
            this.criteriaColumnNameCombo.Name = "criteriaColumnNameCombo";
            this.criteriaColumnNameCombo.Size = new System.Drawing.Size(181, 21);
            this.criteriaColumnNameCombo.TabIndex = 14;
            this.criteriaColumnNameCombo.ValueMember = "Id";
            this.criteriaColumnNameCombo.SelectedIndexChanged += new System.EventHandler(this.criteriaColumnNameCombo_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.criteriaUseURLForMatchCheck);
            this.groupBox3.Controls.Add(this.criteriaDefaultTextCaseCheck);
            this.groupBox3.Controls.Add(this.criteriaClearHTMLCommentCheck);
            this.groupBox3.Controls.Add(this.criteriaClearScriptTagsCheck);
            this.groupBox3.Controls.Add(this.criteriaClearHTMLTagsCheck);
            this.groupBox3.Controls.Add(this.criteriaLowercaseCheck);
            this.groupBox3.Controls.Add(this.criteriaStripASCIICodesCheck);
            this.groupBox3.Controls.Add(this.criteriaUppercaseCheck);
            this.groupBox3.Controls.Add(this.criteriaClearWhitespacesCheck);
            this.groupBox3.Location = new System.Drawing.Point(12, 455);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(462, 86);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc";
            // 
            // criteriaUseURLForMatchCheck
            // 
            this.criteriaUseURLForMatchCheck.AutoSize = true;
            this.criteriaUseURLForMatchCheck.Location = new System.Drawing.Point(339, 61);
            this.criteriaUseURLForMatchCheck.Name = "criteriaUseURLForMatchCheck";
            this.criteriaUseURLForMatchCheck.Size = new System.Drawing.Size(118, 17);
            this.criteriaUseURLForMatchCheck.TabIndex = 27;
            this.criteriaUseURLForMatchCheck.Text = "Use URL for Match";
            this.criteriaUseURLForMatchCheck.UseVisualStyleBackColor = true;
            // 
            // criteriaDefaultTextCaseCheck
            // 
            this.criteriaDefaultTextCaseCheck.AutoSize = true;
            this.criteriaDefaultTextCaseCheck.Location = new System.Drawing.Point(339, 38);
            this.criteriaDefaultTextCaseCheck.Name = "criteriaDefaultTextCaseCheck";
            this.criteriaDefaultTextCaseCheck.Size = new System.Drawing.Size(111, 17);
            this.criteriaDefaultTextCaseCheck.TabIndex = 24;
            this.criteriaDefaultTextCaseCheck.Text = "Default Text Case";
            this.criteriaDefaultTextCaseCheck.UseVisualStyleBackColor = true;
            this.criteriaDefaultTextCaseCheck.CheckedChanged += new System.EventHandler(this.criteriaDefaultTextCaseCheck_CheckedChanged);
            // 
            // criteriaClearHTMLCommentCheck
            // 
            this.criteriaClearHTMLCommentCheck.AutoSize = true;
            this.criteriaClearHTMLCommentCheck.Location = new System.Drawing.Point(166, 15);
            this.criteriaClearHTMLCommentCheck.Name = "criteriaClearHTMLCommentCheck";
            this.criteriaClearHTMLCommentCheck.Size = new System.Drawing.Size(135, 17);
            this.criteriaClearHTMLCommentCheck.TabIndex = 20;
            this.criteriaClearHTMLCommentCheck.Text = "Clear HTML Comments";
            this.criteriaClearHTMLCommentCheck.UseVisualStyleBackColor = true;
            // 
            // criteriaClearScriptTagsCheck
            // 
            this.criteriaClearScriptTagsCheck.AutoSize = true;
            this.criteriaClearScriptTagsCheck.Location = new System.Drawing.Point(166, 38);
            this.criteriaClearScriptTagsCheck.Name = "criteriaClearScriptTagsCheck";
            this.criteriaClearScriptTagsCheck.Size = new System.Drawing.Size(117, 17);
            this.criteriaClearScriptTagsCheck.TabIndex = 23;
            this.criteriaClearScriptTagsCheck.Text = "Clear <script> Tags";
            this.criteriaClearScriptTagsCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.criteriaDefaultValueText);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.criteriaItemEditButton);
            this.groupBox4.Controls.Add(this.criteriaItemDownButton);
            this.groupBox4.Controls.Add(this.criteriaItemDeleteButton);
            this.groupBox4.Controls.Add(this.criteriaItemUpButton);
            this.groupBox4.Controls.Add(this.criteriaRegexButton);
            this.groupBox4.Controls.Add(this.criteriaHTMLNodeCollectionButton);
            this.groupBox4.Controls.Add(this.criteriaHTMLNodeButton);
            this.groupBox4.Controls.Add(this.criteriaBasicHTMLButton);
            this.groupBox4.Controls.Add(this.criteriaItemsList);
            this.groupBox4.Location = new System.Drawing.Point(12, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(462, 205);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Criteria Items";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Click";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.criteriaClickButton_Click);
            // 
            // criteriaDefaultValueText
            // 
            this.criteriaDefaultValueText.Location = new System.Drawing.Point(81, 176);
            this.criteriaDefaultValueText.Name = "criteriaDefaultValueText";
            this.criteriaDefaultValueText.Size = new System.Drawing.Size(369, 20);
            this.criteriaDefaultValueText.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Default Value";
            // 
            // criteriaItemEditButton
            // 
            this.criteriaItemEditButton.Location = new System.Drawing.Point(399, 48);
            this.criteriaItemEditButton.Name = "criteriaItemEditButton";
            this.criteriaItemEditButton.Size = new System.Drawing.Size(51, 23);
            this.criteriaItemEditButton.TabIndex = 5;
            this.criteriaItemEditButton.Text = "Edit";
            this.criteriaItemEditButton.UseVisualStyleBackColor = true;
            this.criteriaItemEditButton.Click += new System.EventHandler(this.criteriaItemEditButton_Click);
            // 
            // criteriaItemDownButton
            // 
            this.criteriaItemDownButton.Location = new System.Drawing.Point(399, 106);
            this.criteriaItemDownButton.Name = "criteriaItemDownButton";
            this.criteriaItemDownButton.Size = new System.Drawing.Size(51, 23);
            this.criteriaItemDownButton.TabIndex = 7;
            this.criteriaItemDownButton.Text = "Down";
            this.criteriaItemDownButton.UseVisualStyleBackColor = true;
            this.criteriaItemDownButton.Click += new System.EventHandler(this.criteriaItemDownButton_Click);
            // 
            // criteriaItemDeleteButton
            // 
            this.criteriaItemDeleteButton.Location = new System.Drawing.Point(399, 77);
            this.criteriaItemDeleteButton.Name = "criteriaItemDeleteButton";
            this.criteriaItemDeleteButton.Size = new System.Drawing.Size(51, 23);
            this.criteriaItemDeleteButton.TabIndex = 6;
            this.criteriaItemDeleteButton.Text = "Delete";
            this.criteriaItemDeleteButton.UseVisualStyleBackColor = true;
            this.criteriaItemDeleteButton.Click += new System.EventHandler(this.criteriaItemDeleteButton_Click);
            // 
            // criteriaItemUpButton
            // 
            this.criteriaItemUpButton.Location = new System.Drawing.Point(399, 19);
            this.criteriaItemUpButton.Name = "criteriaItemUpButton";
            this.criteriaItemUpButton.Size = new System.Drawing.Size(51, 23);
            this.criteriaItemUpButton.TabIndex = 4;
            this.criteriaItemUpButton.Text = "Up";
            this.criteriaItemUpButton.UseVisualStyleBackColor = true;
            this.criteriaItemUpButton.Click += new System.EventHandler(this.criteriaItemUpButton_Click);
            // 
            // criteriaRegexButton
            // 
            this.criteriaRegexButton.Location = new System.Drawing.Point(357, 133);
            this.criteriaRegexButton.Name = "criteriaRegexButton";
            this.criteriaRegexButton.Size = new System.Drawing.Size(93, 23);
            this.criteriaRegexButton.TabIndex = 12;
            this.criteriaRegexButton.Text = "Regular Exp.";
            this.criteriaRegexButton.UseVisualStyleBackColor = true;
            this.criteriaRegexButton.Click += new System.EventHandler(this.criteriaRegexButton_Click);
            // 
            // criteriaHTMLNodeCollectionButton
            // 
            this.criteriaHTMLNodeCollectionButton.Location = new System.Drawing.Point(227, 133);
            this.criteriaHTMLNodeCollectionButton.Name = "criteriaHTMLNodeCollectionButton";
            this.criteriaHTMLNodeCollectionButton.Size = new System.Drawing.Size(124, 23);
            this.criteriaHTMLNodeCollectionButton.TabIndex = 11;
            this.criteriaHTMLNodeCollectionButton.Text = "HTML Node Collection";
            this.criteriaHTMLNodeCollectionButton.UseVisualStyleBackColor = true;
            this.criteriaHTMLNodeCollectionButton.Click += new System.EventHandler(this.criteriaHTMLNodeCollectionButton_Click);
            // 
            // criteriaHTMLNodeButton
            // 
            this.criteriaHTMLNodeButton.Location = new System.Drawing.Point(141, 133);
            this.criteriaHTMLNodeButton.Name = "criteriaHTMLNodeButton";
            this.criteriaHTMLNodeButton.Size = new System.Drawing.Size(80, 23);
            this.criteriaHTMLNodeButton.TabIndex = 10;
            this.criteriaHTMLNodeButton.Text = "HTML Node";
            this.criteriaHTMLNodeButton.UseVisualStyleBackColor = true;
            this.criteriaHTMLNodeButton.Click += new System.EventHandler(this.criteriaHTMLNodeButton_Click);
            // 
            // criteriaBasicHTMLButton
            // 
            this.criteriaBasicHTMLButton.Location = new System.Drawing.Point(60, 133);
            this.criteriaBasicHTMLButton.Name = "criteriaBasicHTMLButton";
            this.criteriaBasicHTMLButton.Size = new System.Drawing.Size(77, 23);
            this.criteriaBasicHTMLButton.TabIndex = 9;
            this.criteriaBasicHTMLButton.Text = "HTML";
            this.criteriaBasicHTMLButton.UseVisualStyleBackColor = true;
            this.criteriaBasicHTMLButton.Click += new System.EventHandler(this.criteriaBasicHTMLButton_Click);
            // 
            // criteriaItemsList
            // 
            this.criteriaItemsList.DisplayMember = "Name";
            this.criteriaItemsList.FormattingEnabled = true;
            this.criteriaItemsList.Location = new System.Drawing.Point(9, 19);
            this.criteriaItemsList.Name = "criteriaItemsList";
            this.criteriaItemsList.Size = new System.Drawing.Size(386, 108);
            this.criteriaItemsList.TabIndex = 3;
            this.criteriaItemsList.DoubleClick += new System.EventHandler(this.criteriaItemsList_DoubleClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.criteriaExtraFieldIIIText);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.criteriaExtraFieldIIText);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.criteriaExtraFieldIText);
            this.groupBox5.Location = new System.Drawing.Point(12, 354);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(462, 95);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Extra Fields";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "XField III";
            // 
            // criteriaExtraFieldIIIText
            // 
            this.criteriaExtraFieldIIIText.Location = new System.Drawing.Point(81, 69);
            this.criteriaExtraFieldIIIText.Name = "criteriaExtraFieldIIIText";
            this.criteriaExtraFieldIIIText.Size = new System.Drawing.Size(181, 20);
            this.criteriaExtraFieldIIIText.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "XField II";
            // 
            // criteriaExtraFieldIIText
            // 
            this.criteriaExtraFieldIIText.Location = new System.Drawing.Point(81, 44);
            this.criteriaExtraFieldIIText.Name = "criteriaExtraFieldIIText";
            this.criteriaExtraFieldIIText.Size = new System.Drawing.Size(181, 20);
            this.criteriaExtraFieldIIText.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "XField I";
            // 
            // criteriaExtraFieldIText
            // 
            this.criteriaExtraFieldIText.Location = new System.Drawing.Point(81, 18);
            this.criteriaExtraFieldIText.Name = "criteriaExtraFieldIText";
            this.criteriaExtraFieldIText.Size = new System.Drawing.Size(181, 20);
            this.criteriaExtraFieldIText.TabIndex = 16;
            // 
            // columnTypeTextBox
            // 
            this.columnTypeTextBox.Enabled = false;
            this.columnTypeTextBox.Location = new System.Drawing.Point(268, 18);
            this.columnTypeTextBox.Name = "columnTypeTextBox";
            this.columnTypeTextBox.Size = new System.Drawing.Size(182, 20);
            this.columnTypeTextBox.TabIndex = 17;
            // 
            // AddEditCriteria
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(484, 581);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditCriteria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crexta - Criteria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditCriteria_FormClosing);
            this.Load += new System.EventHandler(this.AddEditCriteria_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox criteriaNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel criteriaExcludeListLink;
        private System.Windows.Forms.CheckBox criteriaClearHTMLTagsCheck;
        private System.Windows.Forms.CheckBox criteriaStripASCIICodesCheck;
        private System.Windows.Forms.CheckBox criteriaClearWhitespacesCheck;
        private System.Windows.Forms.CheckBox criteriaLowercaseCheck;
        private System.Windows.Forms.CheckBox criteriaUppercaseCheck;
        private System.Windows.Forms.Label criteriaExcludeListTotalLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox criteriaDefaultTextCaseCheck;
        private System.Windows.Forms.CheckBox criteriaClearHTMLCommentCheck;
        private System.Windows.Forms.CheckBox criteriaClearScriptTagsCheck;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button criteriaItemDownButton;
        private System.Windows.Forms.Button criteriaItemDeleteButton;
        private System.Windows.Forms.Button criteriaItemUpButton;
        private System.Windows.Forms.Button criteriaRegexButton;
        private System.Windows.Forms.Button criteriaHTMLNodeCollectionButton;
        private System.Windows.Forms.Button criteriaHTMLNodeButton;
        private System.Windows.Forms.Button criteriaBasicHTMLButton;
        private System.Windows.Forms.ListBox criteriaItemsList;
        private System.Windows.Forms.Button criteriaItemEditButton;
        private System.Windows.Forms.CheckBox criteriaUseURLForMatchCheck;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox criteriaExtraFieldIIText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox criteriaExtraFieldIText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox criteriaExtraFieldIIIText;
        private System.Windows.Forms.TextBox criteriaDefaultValueText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox criteriaColumnNameCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox columnTypeTextBox;
    }
}