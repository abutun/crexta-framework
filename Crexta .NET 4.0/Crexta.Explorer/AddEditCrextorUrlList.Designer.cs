namespace Crexta.Explorer
{
    partial class AddEditCrextorUrlList
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
            this.urlList = new System.Windows.Forms.DataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crextorNameText = new System.Windows.Forms.Label();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.urlList);
            this.groupBox1.Controls.Add(this.crextorNameText);
            this.groupBox1.Controls.Add(this.editButton);
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 301);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crextor URLs";
            // 
            // urlList
            // 
            this.urlList.AllowUserToAddRows = false;
            this.urlList.AllowUserToDeleteRows = false;
            this.urlList.AllowUserToResizeColumns = false;
            this.urlList.AllowUserToResizeRows = false;
            this.urlList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.urlList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.NameColumn,
            this.URLColumn,
            this.OrderColumn});
            this.urlList.Location = new System.Drawing.Point(6, 56);
            this.urlList.MultiSelect = false;
            this.urlList.Name = "urlList";
            this.urlList.RowHeadersVisible = false;
            this.urlList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.urlList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.urlList.Size = new System.Drawing.Size(484, 205);
            this.urlList.TabIndex = 11;
            this.urlList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.urlList_CellContentClick);
            this.urlList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.urlList_CellContentClick);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Width = 20;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NameColumn.Width = 150;
            // 
            // URLColumn
            // 
            this.URLColumn.HeaderText = "URL";
            this.URLColumn.Name = "URLColumn";
            this.URLColumn.ReadOnly = true;
            this.URLColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.URLColumn.Width = 270;
            // 
            // OrderColumn
            // 
            this.OrderColumn.HeaderText = "Order";
            this.OrderColumn.Name = "OrderColumn";
            this.OrderColumn.ReadOnly = true;
            this.OrderColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.OrderColumn.Width = 40;
            // 
            // crextorNameText
            // 
            this.crextorNameText.AutoSize = true;
            this.crextorNameText.Location = new System.Drawing.Point(42, 32);
            this.crextorNameText.Name = "crextorNameText";
            this.crextorNameText.Size = new System.Drawing.Size(0, 13);
            this.crextorNameText.TabIndex = 10;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(335, 267);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 4;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(416, 267);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(254, 267);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add New";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crextor : ";
            // 
            // AddEditCrextorUrlList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 323);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditCrextorUrlList";
            this.Text = "Crexta - Crextor URL List";
            this.Load += new System.EventHandler(this.AddEditCrextorUrlList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urlList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label crextorNameText;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView urlList;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn URLColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderColumn;
    }
}