namespace Crexta.Explorer
{
    partial class Scheduler
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.dayTimeGroup = new System.Windows.Forms.GroupBox();
            this.toTime = new System.Windows.Forms.DateTimePicker();
            this.fromTime = new System.Windows.Forms.DateTimePicker();
            this.scheduleTime = new System.Windows.Forms.DateTimePicker();
            this.minutesText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scheduleDate = new System.Windows.Forms.DateTimePicker();
            this.dayOfTheWeekGroup = new System.Windows.Forms.GroupBox();
            this.thursdayCheck = new System.Windows.Forms.CheckBox();
            this.fridayCheck = new System.Windows.Forms.CheckBox();
            this.tuesdayCheck = new System.Windows.Forms.CheckBox();
            this.saturdayCheck = new System.Windows.Forms.CheckBox();
            this.sundayCheck = new System.Windows.Forms.CheckBox();
            this.wednesdayCheck = new System.Windows.Forms.CheckBox();
            this.mondayCheck = new System.Windows.Forms.CheckBox();
            this.scheduleTypeCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.dayTimeGroup.SuspendLayout();
            this.dayOfTheWeekGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.applyButton);
            this.groupBox1.Controls.Add(this.okButton);
            this.groupBox1.Controls.Add(this.dayTimeGroup);
            this.groupBox1.Controls.Add(this.dayOfTheWeekGroup);
            this.groupBox1.Controls.Add(this.scheduleTypeCombo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 442);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(318, 402);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(237, 402);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(156, 402);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // dayTimeGroup
            // 
            this.dayTimeGroup.Controls.Add(this.toTime);
            this.dayTimeGroup.Controls.Add(this.fromTime);
            this.dayTimeGroup.Controls.Add(this.scheduleTime);
            this.dayTimeGroup.Controls.Add(this.minutesText);
            this.dayTimeGroup.Controls.Add(this.label6);
            this.dayTimeGroup.Controls.Add(this.label5);
            this.dayTimeGroup.Controls.Add(this.label4);
            this.dayTimeGroup.Controls.Add(this.label3);
            this.dayTimeGroup.Controls.Add(this.label2);
            this.dayTimeGroup.Controls.Add(this.scheduleDate);
            this.dayTimeGroup.Location = new System.Drawing.Point(12, 259);
            this.dayTimeGroup.Name = "dayTimeGroup";
            this.dayTimeGroup.Size = new System.Drawing.Size(381, 131);
            this.dayTimeGroup.TabIndex = 3;
            this.dayTimeGroup.TabStop = false;
            this.dayTimeGroup.Text = "Day/Time";
            // 
            // toTime
            // 
            this.toTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.toTime.Location = new System.Drawing.Point(297, 95);
            this.toTime.Name = "toTime";
            this.toTime.ShowUpDown = true;
            this.toTime.Size = new System.Drawing.Size(78, 20);
            this.toTime.TabIndex = 10;
            this.toTime.Value = new System.DateTime(2011, 6, 21, 0, 0, 0, 0);
            this.toTime.ValueChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // fromTime
            // 
            this.fromTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.fromTime.Location = new System.Drawing.Point(206, 95);
            this.fromTime.Name = "fromTime";
            this.fromTime.ShowUpDown = true;
            this.fromTime.Size = new System.Drawing.Size(78, 20);
            this.fromTime.TabIndex = 9;
            this.fromTime.Value = new System.DateTime(2011, 6, 21, 0, 0, 0, 0);
            this.fromTime.ValueChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // scheduleTime
            // 
            this.scheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.scheduleTime.Location = new System.Drawing.Point(205, 44);
            this.scheduleTime.Name = "scheduleTime";
            this.scheduleTime.ShowUpDown = true;
            this.scheduleTime.Size = new System.Drawing.Size(170, 20);
            this.scheduleTime.TabIndex = 8;
            this.scheduleTime.Value = new System.DateTime(2011, 6, 21, 0, 0, 0, 0);
            this.scheduleTime.ValueChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // minutesText
            // 
            this.minutesText.Location = new System.Drawing.Point(15, 95);
            this.minutesText.Name = "minutesText";
            this.minutesText.Size = new System.Drawing.Size(161, 20);
            this.minutesText.TabIndex = 7;
            this.minutesText.TextChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "To";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "From";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Timer (Minutes)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(202, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            // 
            // scheduleDate
            // 
            this.scheduleDate.Location = new System.Drawing.Point(15, 44);
            this.scheduleDate.Name = "scheduleDate";
            this.scheduleDate.Size = new System.Drawing.Size(161, 20);
            this.scheduleDate.TabIndex = 0;
            this.scheduleDate.ValueChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // dayOfTheWeekGroup
            // 
            this.dayOfTheWeekGroup.Controls.Add(this.thursdayCheck);
            this.dayOfTheWeekGroup.Controls.Add(this.fridayCheck);
            this.dayOfTheWeekGroup.Controls.Add(this.tuesdayCheck);
            this.dayOfTheWeekGroup.Controls.Add(this.saturdayCheck);
            this.dayOfTheWeekGroup.Controls.Add(this.sundayCheck);
            this.dayOfTheWeekGroup.Controls.Add(this.wednesdayCheck);
            this.dayOfTheWeekGroup.Controls.Add(this.mondayCheck);
            this.dayOfTheWeekGroup.Location = new System.Drawing.Point(12, 72);
            this.dayOfTheWeekGroup.Name = "dayOfTheWeekGroup";
            this.dayOfTheWeekGroup.Size = new System.Drawing.Size(381, 171);
            this.dayOfTheWeekGroup.TabIndex = 2;
            this.dayOfTheWeekGroup.TabStop = false;
            this.dayOfTheWeekGroup.Text = "Days of the week";
            // 
            // thursdayCheck
            // 
            this.thursdayCheck.AutoSize = true;
            this.thursdayCheck.Location = new System.Drawing.Point(206, 66);
            this.thursdayCheck.Name = "thursdayCheck";
            this.thursdayCheck.Size = new System.Drawing.Size(70, 17);
            this.thursdayCheck.TabIndex = 6;
            this.thursdayCheck.Text = "Thursday";
            this.thursdayCheck.UseVisualStyleBackColor = true;
            this.thursdayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // fridayCheck
            // 
            this.fridayCheck.AutoSize = true;
            this.fridayCheck.Location = new System.Drawing.Point(15, 101);
            this.fridayCheck.Name = "fridayCheck";
            this.fridayCheck.Size = new System.Drawing.Size(54, 17);
            this.fridayCheck.TabIndex = 5;
            this.fridayCheck.Text = "Friday";
            this.fridayCheck.UseVisualStyleBackColor = true;
            this.fridayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // tuesdayCheck
            // 
            this.tuesdayCheck.AutoSize = true;
            this.tuesdayCheck.Location = new System.Drawing.Point(206, 32);
            this.tuesdayCheck.Name = "tuesdayCheck";
            this.tuesdayCheck.Size = new System.Drawing.Size(67, 17);
            this.tuesdayCheck.TabIndex = 4;
            this.tuesdayCheck.Text = "Tuesday";
            this.tuesdayCheck.UseVisualStyleBackColor = true;
            this.tuesdayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // saturdayCheck
            // 
            this.saturdayCheck.AutoSize = true;
            this.saturdayCheck.Location = new System.Drawing.Point(205, 101);
            this.saturdayCheck.Name = "saturdayCheck";
            this.saturdayCheck.Size = new System.Drawing.Size(68, 17);
            this.saturdayCheck.TabIndex = 3;
            this.saturdayCheck.Text = "Saturday";
            this.saturdayCheck.UseVisualStyleBackColor = true;
            this.saturdayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // sundayCheck
            // 
            this.sundayCheck.AutoSize = true;
            this.sundayCheck.Location = new System.Drawing.Point(15, 135);
            this.sundayCheck.Name = "sundayCheck";
            this.sundayCheck.Size = new System.Drawing.Size(62, 17);
            this.sundayCheck.TabIndex = 2;
            this.sundayCheck.Text = "Sunday";
            this.sundayCheck.UseVisualStyleBackColor = true;
            this.sundayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // wednesdayCheck
            // 
            this.wednesdayCheck.AutoSize = true;
            this.wednesdayCheck.Location = new System.Drawing.Point(15, 66);
            this.wednesdayCheck.Name = "wednesdayCheck";
            this.wednesdayCheck.Size = new System.Drawing.Size(83, 17);
            this.wednesdayCheck.TabIndex = 1;
            this.wednesdayCheck.Text = "Wednesday";
            this.wednesdayCheck.UseVisualStyleBackColor = true;
            this.wednesdayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // mondayCheck
            // 
            this.mondayCheck.AutoSize = true;
            this.mondayCheck.Location = new System.Drawing.Point(15, 32);
            this.mondayCheck.Name = "mondayCheck";
            this.mondayCheck.Size = new System.Drawing.Size(64, 17);
            this.mondayCheck.TabIndex = 0;
            this.mondayCheck.Text = "Monday";
            this.mondayCheck.UseVisualStyleBackColor = true;
            this.mondayCheck.CheckedChanged += new System.EventHandler(this.mondayCheck_CheckedChanged);
            // 
            // scheduleTypeCombo
            // 
            this.scheduleTypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scheduleTypeCombo.FormattingEnabled = true;
            this.scheduleTypeCombo.Items.AddRange(new object[] {
            "Default",
            "Once",
            "Daily",
            "Weekly",
            "Timer"});
            this.scheduleTypeCombo.Location = new System.Drawing.Point(12, 39);
            this.scheduleTypeCombo.Name = "scheduleTypeCombo";
            this.scheduleTypeCombo.Size = new System.Drawing.Size(121, 21);
            this.scheduleTypeCombo.TabIndex = 1;
            this.scheduleTypeCombo.SelectedIndexChanged += new System.EventHandler(this.scheduleTypeCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedule Type";
            // 
            // Scheduler
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(409, 442);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scheduler";
            this.Text = "Crexta - Scheduler";
            this.Load += new System.EventHandler(this.Scheduler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.dayTimeGroup.ResumeLayout(false);
            this.dayTimeGroup.PerformLayout();
            this.dayOfTheWeekGroup.ResumeLayout(false);
            this.dayOfTheWeekGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox dayOfTheWeekGroup;
        private System.Windows.Forms.CheckBox thursdayCheck;
        private System.Windows.Forms.CheckBox fridayCheck;
        private System.Windows.Forms.CheckBox tuesdayCheck;
        private System.Windows.Forms.CheckBox saturdayCheck;
        private System.Windows.Forms.CheckBox sundayCheck;
        private System.Windows.Forms.CheckBox wednesdayCheck;
        private System.Windows.Forms.CheckBox mondayCheck;
        private System.Windows.Forms.ComboBox scheduleTypeCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.GroupBox dayTimeGroup;
        private System.Windows.Forms.TextBox minutesText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker scheduleDate;
        private System.Windows.Forms.DateTimePicker toTime;
        private System.Windows.Forms.DateTimePicker fromTime;
        private System.Windows.Forms.DateTimePicker scheduleTime;
    }
}