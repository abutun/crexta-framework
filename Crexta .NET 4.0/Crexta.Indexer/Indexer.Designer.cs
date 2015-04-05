namespace Crexta.Indexer
{
    partial class Indexer
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
            this.indexLogListbox = new System.Windows.Forms.ListBox();
            this.stopIndexingButton = new System.Windows.Forms.Button();
            this.startIndexingButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.totalItemsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rebuildeIndexCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rebuildeIndexCheck);
            this.groupBox1.Controls.Add(this.indexLogListbox);
            this.groupBox1.Controls.Add(this.stopIndexingButton);
            this.groupBox1.Controls.Add(this.startIndexingButton);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.totalItemsLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 371);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // indexLogListbox
            // 
            this.indexLogListbox.FormattingEnabled = true;
            this.indexLogListbox.Location = new System.Drawing.Point(9, 113);
            this.indexLogListbox.Name = "indexLogListbox";
            this.indexLogListbox.Size = new System.Drawing.Size(545, 251);
            this.indexLogListbox.TabIndex = 5;
            // 
            // stopIndexingButton
            // 
            this.stopIndexingButton.Location = new System.Drawing.Point(90, 74);
            this.stopIndexingButton.Name = "stopIndexingButton";
            this.stopIndexingButton.Size = new System.Drawing.Size(75, 23);
            this.stopIndexingButton.TabIndex = 4;
            this.stopIndexingButton.Text = "Stop";
            this.stopIndexingButton.UseVisualStyleBackColor = true;
            // 
            // startIndexingButton
            // 
            this.startIndexingButton.Location = new System.Drawing.Point(9, 74);
            this.startIndexingButton.Name = "startIndexingButton";
            this.startIndexingButton.Size = new System.Drawing.Size(75, 23);
            this.startIndexingButton.TabIndex = 3;
            this.startIndexingButton.Text = "Start";
            this.startIndexingButton.UseVisualStyleBackColor = true;
            this.startIndexingButton.Click += new System.EventHandler(this.startIndexingButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 45);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(545, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // totalItemsLabel
            // 
            this.totalItemsLabel.AutoSize = true;
            this.totalItemsLabel.Location = new System.Drawing.Point(179, 16);
            this.totalItemsLabel.Name = "totalItemsLabel";
            this.totalItemsLabel.Size = new System.Drawing.Size(0, 13);
            this.totalItemsLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total items waiting to be indexed :";
            // 
            // rebuildeIndexCheck
            // 
            this.rebuildeIndexCheck.AutoSize = true;
            this.rebuildeIndexCheck.Location = new System.Drawing.Point(463, 80);
            this.rebuildeIndexCheck.Name = "rebuildeIndexCheck";
            this.rebuildeIndexCheck.Size = new System.Drawing.Size(91, 17);
            this.rebuildeIndexCheck.TabIndex = 6;
            this.rebuildeIndexCheck.Text = "Rebuild Index";
            this.rebuildeIndexCheck.UseVisualStyleBackColor = true;
            // 
            // Indexer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 395);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Indexer";
            this.Text = "abbSolutions - Product Indexer";
            this.Load += new System.EventHandler(this.Indexer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox indexLogListbox;
        private System.Windows.Forms.Button stopIndexingButton;
        private System.Windows.Forms.Button startIndexingButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label totalItemsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rebuildeIndexCheck;
    }
}

