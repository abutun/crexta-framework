namespace Crexta.Server
{
    partial class Preferences
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ufUseU2mServiceCheck = new System.Windows.Forms.CheckBox();
            this.reflectCategoryCheck = new System.Windows.Forms.CheckBox();
            this.reflectBrandCheck = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientIdleTimeInSeconds = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.deMulitplierCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deURLListCount = new System.Windows.Forms.NumericUpDown();
            this.Policies = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.clientReconnectSeconds = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.clientReconnectMinutes = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.deDataMinutesNumeric = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.deDataHoursNumeric = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.Scheduler = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.dumpResultsCheckBox = new System.Windows.Forms.CheckBox();
            this.logAllEventsCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.deUrlRetryCount = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientIdleTimeInSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMulitplierCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deURLListCount)).BeginInit();
            this.Policies.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientReconnectSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientReconnectMinutes)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDataMinutesNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDataHoursNumeric)).BeginInit();
            this.Scheduler.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deUrlRetryCount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.applyButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 31);
            this.panel1.TabIndex = 7;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(222, 3);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(384, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(303, 3);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(468, 286);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.Policies);
            this.tabControl1.Controls.Add(this.Scheduler);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 267);
            this.tabControl1.TabIndex = 0;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.groupBox3);
            this.generalTab.Controls.Add(this.groupBox2);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(454, 241);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ufUseU2mServiceCheck);
            this.groupBox3.Controls.Add(this.reflectCategoryCheck);
            this.groupBox3.Controls.Add(this.reflectBrandCheck);
            this.groupBox3.Location = new System.Drawing.Point(6, 146);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 89);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc";
            // 
            // ufUseU2mServiceCheck
            // 
            this.ufUseU2mServiceCheck.AutoSize = true;
            this.ufUseU2mServiceCheck.Location = new System.Drawing.Point(11, 19);
            this.ufUseU2mServiceCheck.Name = "ufUseU2mServiceCheck";
            this.ufUseU2mServiceCheck.Size = new System.Drawing.Size(188, 17);
            this.ufUseU2mServiceCheck.TabIndex = 13;
            this.ufUseU2mServiceCheck.Text = "Use U2M service to shorten URLs";
            this.ufUseU2mServiceCheck.UseVisualStyleBackColor = true;
            // 
            // reflectCategoryCheck
            // 
            this.reflectCategoryCheck.AutoSize = true;
            this.reflectCategoryCheck.Location = new System.Drawing.Point(11, 65);
            this.reflectCategoryCheck.Name = "reflectCategoryCheck";
            this.reflectCategoryCheck.Size = new System.Drawing.Size(183, 17);
            this.reflectCategoryCheck.TabIndex = 15;
            this.reflectCategoryCheck.Text = "Reflect category prediction to DB";
            this.reflectCategoryCheck.UseVisualStyleBackColor = true;
            // 
            // reflectBrandCheck
            // 
            this.reflectBrandCheck.AutoSize = true;
            this.reflectBrandCheck.Location = new System.Drawing.Point(11, 42);
            this.reflectBrandCheck.Name = "reflectBrandCheck";
            this.reflectBrandCheck.Size = new System.Drawing.Size(169, 17);
            this.reflectBrandCheck.TabIndex = 14;
            this.reflectBrandCheck.Text = "Reflect brand prediction to DB";
            this.reflectBrandCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.deUrlRetryCount);
            this.groupBox2.Controls.Add(this.clientIdleTimeInSeconds);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.deMulitplierCount);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.deURLListCount);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 137);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "General Setting";
            // 
            // clientIdleTimeInSeconds
            // 
            this.clientIdleTimeInSeconds.Location = new System.Drawing.Point(91, 24);
            this.clientIdleTimeInSeconds.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.clientIdleTimeInSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.clientIdleTimeInSeconds.Name = "clientIdleTimeInSeconds";
            this.clientIdleTimeInSeconds.Size = new System.Drawing.Size(72, 20);
            this.clientIdleTimeInSeconds.TabIndex = 3;
            this.clientIdleTimeInSeconds.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MAX Idle Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "seconds (Client IDLE time, -1: NO IDLE)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total UF\'s =";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(235, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "(DE URL list count for a data extraction process)";
            // 
            // deMulitplierCount
            // 
            this.deMulitplierCount.Location = new System.Drawing.Point(91, 50);
            this.deMulitplierCount.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.deMulitplierCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deMulitplierCount.Name = "deMulitplierCount";
            this.deMulitplierCount.Size = new System.Drawing.Size(72, 20);
            this.deMulitplierCount.TabIndex = 7;
            this.deMulitplierCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "List Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "* Total DE\'s";
            // 
            // deURLListCount
            // 
            this.deURLListCount.Location = new System.Drawing.Point(91, 76);
            this.deURLListCount.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.deURLListCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deURLListCount.Name = "deURLListCount";
            this.deURLListCount.Size = new System.Drawing.Size(72, 20);
            this.deURLListCount.TabIndex = 10;
            this.deURLListCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Policies
            // 
            this.Policies.Controls.Add(this.groupBox7);
            this.Policies.Controls.Add(this.groupBox6);
            this.Policies.Location = new System.Drawing.Point(4, 22);
            this.Policies.Name = "Policies";
            this.Policies.Padding = new System.Windows.Forms.Padding(3);
            this.Policies.Size = new System.Drawing.Size(454, 241);
            this.Policies.TabIndex = 2;
            this.Policies.Text = "Policies";
            this.Policies.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.clientReconnectSeconds);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.clientReconnectMinutes);
            this.groupBox7.Location = new System.Drawing.Point(3, 135);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(448, 100);
            this.groupBox7.TabIndex = 22;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Client Reconnection Policy";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(368, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "seconds";
            // 
            // clientReconnectSeconds
            // 
            this.clientReconnectSeconds.Location = new System.Drawing.Point(290, 72);
            this.clientReconnectSeconds.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.clientReconnectSeconds.Name = "clientReconnectSeconds";
            this.clientReconnectSeconds.Size = new System.Drawing.Size(72, 20);
            this.clientReconnectSeconds.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(368, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "minutes and";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(356, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "If client connection is lost, let the client request connection again for every";
            // 
            // clientReconnectMinutes
            // 
            this.clientReconnectMinutes.Location = new System.Drawing.Point(290, 46);
            this.clientReconnectMinutes.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.clientReconnectMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.clientReconnectMinutes.Name = "clientReconnectMinutes";
            this.clientReconnectMinutes.Size = new System.Drawing.Size(72, 20);
            this.clientReconnectMinutes.TabIndex = 4;
            this.clientReconnectMinutes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.deDataMinutesNumeric);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.deDataHoursNumeric);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Location = new System.Drawing.Point(3, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(448, 123);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Data Update Policy";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 89);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(344, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "(Hour=0, Minute=0 means extract data regardless of last extraction time)";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(371, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "minutes";
            // 
            // deDataMinutesNumeric
            // 
            this.deDataMinutesNumeric.Location = new System.Drawing.Point(293, 50);
            this.deDataMinutesNumeric.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.deDataMinutesNumeric.Name = "deDataMinutesNumeric";
            this.deDataMinutesNumeric.Size = new System.Drawing.Size(72, 20);
            this.deDataMinutesNumeric.TabIndex = 21;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(371, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "hours and";
            // 
            // deDataHoursNumeric
            // 
            this.deDataHoursNumeric.Location = new System.Drawing.Point(293, 24);
            this.deDataHoursNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.deDataHoursNumeric.Name = "deDataHoursNumeric";
            this.deDataHoursNumeric.Size = new System.Drawing.Size(72, 20);
            this.deDataHoursNumeric.TabIndex = 19;
            this.deDataHoursNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(275, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Extract only datas which last extraction time is more than ";
            // 
            // Scheduler
            // 
            this.Scheduler.Controls.Add(this.groupBox5);
            this.Scheduler.Controls.Add(this.label9);
            this.Scheduler.Controls.Add(this.linkLabel1);
            this.Scheduler.Controls.Add(this.label8);
            this.Scheduler.Controls.Add(this.groupBox4);
            this.Scheduler.Location = new System.Drawing.Point(4, 22);
            this.Scheduler.Name = "Scheduler";
            this.Scheduler.Padding = new System.Windows.Forms.Padding(3);
            this.Scheduler.Size = new System.Drawing.Size(454, 241);
            this.Scheduler.TabIndex = 1;
            this.Scheduler.Text = "Scheduler";
            this.Scheduler.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(4, 112);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(448, 100);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Schedule DATAExtractor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "for the clients if you set any scheduler!";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(133, 225);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(57, 13);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "IDLE Time";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "You MUST set infinite (-1)";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(4, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 100);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Schedule URLFounder";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(454, 241);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Logging";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.dumpResultsCheckBox);
            this.groupBox8.Controls.Add(this.logAllEventsCheckBox);
            this.groupBox8.Location = new System.Drawing.Point(5, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(442, 229);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Log Settings";
            // 
            // dumpResultsCheckBox
            // 
            this.dumpResultsCheckBox.AutoSize = true;
            this.dumpResultsCheckBox.Location = new System.Drawing.Point(13, 54);
            this.dumpResultsCheckBox.Name = "dumpResultsCheckBox";
            this.dumpResultsCheckBox.Size = new System.Drawing.Size(153, 17);
            this.dumpResultsCheckBox.TabIndex = 1;
            this.dumpResultsCheckBox.Text = "Dump XML Results to Disk";
            this.dumpResultsCheckBox.UseVisualStyleBackColor = true;
            // 
            // logAllEventsCheckBox
            // 
            this.logAllEventsCheckBox.AutoSize = true;
            this.logAllEventsCheckBox.Location = new System.Drawing.Point(13, 31);
            this.logAllEventsCheckBox.Name = "logAllEventsCheckBox";
            this.logAllEventsCheckBox.Size = new System.Drawing.Size(94, 17);
            this.logAllEventsCheckBox.TabIndex = 0;
            this.logAllEventsCheckBox.Text = "Log All Events";
            this.logAllEventsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "(DE URL retry count for failed URLs)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Retry Count";
            // 
            // deUrlRetryCount
            // 
            this.deUrlRetryCount.Location = new System.Drawing.Point(91, 102);
            this.deUrlRetryCount.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.deUrlRetryCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.deUrlRetryCount.Name = "deUrlRetryCount";
            this.deUrlRetryCount.Size = new System.Drawing.Size(72, 20);
            this.deUrlRetryCount.TabIndex = 13;
            this.deUrlRetryCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Preferences
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(468, 320);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientIdleTimeInSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deMulitplierCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deURLListCount)).EndInit();
            this.Policies.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientReconnectSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientReconnectMinutes)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deDataMinutesNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDataHoursNumeric)).EndInit();
            this.Scheduler.ResumeLayout(false);
            this.Scheduler.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deUrlRetryCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.NumericUpDown clientIdleTimeInSeconds;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown deMulitplierCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown deURLListCount;
        private System.Windows.Forms.CheckBox reflectCategoryCheck;
        private System.Windows.Forms.CheckBox reflectBrandCheck;
        private System.Windows.Forms.CheckBox ufUseU2mServiceCheck;
        private System.Windows.Forms.TabPage Scheduler;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage Policies;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown deDataMinutesNumeric;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown deDataHoursNumeric;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown clientReconnectMinutes;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown clientReconnectSeconds;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox logAllEventsCheckBox;
        private System.Windows.Forms.CheckBox dumpResultsCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown deUrlRetryCount;

    }
}