namespace abbSolutions
{
	partial class CommunicationsTest
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
			this.btnStartTest = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.lblReceived = new System.Windows.Forms.Label();
			this.tmrFiveSeconds = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblConnected = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblServerBytesReceived = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblBytesSent = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStartTest
			// 
			this.btnStartTest.Location = new System.Drawing.Point(225, 4);
			this.btnStartTest.Name = "btnStartTest";
			this.btnStartTest.Size = new System.Drawing.Size(75, 23);
			this.btnStartTest.TabIndex = 0;
			this.btnStartTest.Text = "Start Test";
			this.btnStartTest.UseVisualStyleBackColor = true;
			this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Location = new System.Drawing.Point(0, 100);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(309, 125);
			this.txtOutput.TabIndex = 1;
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Enabled = true;
			this.tmrUpdate.Interval = 400;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// lblReceived
			// 
			this.lblReceived.AutoSize = true;
			this.lblReceived.Location = new System.Drawing.Point(120, 9);
			this.lblReceived.Name = "lblReceived";
			this.lblReceived.Size = new System.Drawing.Size(19, 13);
			this.lblReceived.TabIndex = 2;
			this.lblReceived.Text = "    ";
			// 
			// tmrFiveSeconds
			// 
			this.tmrFiveSeconds.Interval = 5000;
			this.tmrFiveSeconds.Tick += new System.EventHandler(this.tmrFiveSeconds_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Commands Received:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Client Connections:";
			// 
			// lblConnected
			// 
			this.lblConnected.AutoSize = true;
			this.lblConnected.Location = new System.Drawing.Point(120, 33);
			this.lblConnected.Name = "lblConnected";
			this.lblConnected.Size = new System.Drawing.Size(19, 13);
			this.lblConnected.TabIndex = 4;
			this.lblConnected.Text = "    ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 57);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Server Bytes Recv:";
			// 
			// lblServerBytesReceived
			// 
			this.lblServerBytesReceived.AutoSize = true;
			this.lblServerBytesReceived.Location = new System.Drawing.Point(120, 57);
			this.lblServerBytesReceived.Name = "lblServerBytesReceived";
			this.lblServerBytesReceived.Size = new System.Drawing.Size(19, 13);
			this.lblServerBytesReceived.TabIndex = 6;
			this.lblServerBytesReceived.Text = "    ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Client Bytes Sent:";
			// 
			// lblBytesSent
			// 
			this.lblBytesSent.AutoSize = true;
			this.lblBytesSent.Location = new System.Drawing.Point(120, 81);
			this.lblBytesSent.Name = "lblBytesSent";
			this.lblBytesSent.Size = new System.Drawing.Size(19, 13);
			this.lblBytesSent.TabIndex = 8;
			this.lblBytesSent.Text = "    ";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.btnStartTest);
			this.panel1.Controls.Add(this.lblBytesSent);
			this.panel1.Controls.Add(this.lblReceived);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.lblConnected);
			this.panel1.Controls.Add(this.lblServerBytesReceived);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(309, 100);
			this.panel1.TabIndex = 10;
			// 
			// CommunicationsTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(309, 225);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.panel1);
			this.Name = "CommunicationsTest";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.CommunicationsTest_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnStartTest;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Timer tmrUpdate;
		private System.Windows.Forms.Label lblReceived;
		private System.Windows.Forms.Timer tmrFiveSeconds;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblConnected;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblServerBytesReceived;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblBytesSent;
		private System.Windows.Forms.Panel panel1;
	}
}

