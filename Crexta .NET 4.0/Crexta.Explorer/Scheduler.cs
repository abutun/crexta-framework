using System;
using System.Linq;
using System.Windows.Forms;
using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class Scheduler : Form
    {
        private int crextorId = -1;

        public Scheduler(int crextorId)
        {
            InitializeComponent();

            this.crextorId = crextorId;
        }

        private void Scheduler_Load(object sender, EventArgs e)
        {
            if (crextorId > 0)
                LoadCrextorSchedule();
            else
                this.scheduleTypeCombo.SelectedIndex = 0;
        }

        private void LoadCrextorSchedule()
        {
            using(CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                var schedule = (from sc in db.CrextorSchedules
                                where sc.CrextorId == crextorId
                                select sc).SingleOrDefault();

                if (schedule != null)
                {
                    this.scheduleTypeCombo.SelectedIndex = schedule.Type;

                    if (schedule.Monday != null)
                        this.mondayCheck.Checked = (bool)schedule.Monday;
                    if (schedule.Tuesday != null)
                        this.tuesdayCheck.Checked = (bool)schedule.Tuesday;
                    if (schedule.Wednesday != null)
                        this.wednesdayCheck.Checked = (bool)schedule.Wednesday;
                    if (schedule.Thursday != null)
                        this.thursdayCheck.Checked = (bool)schedule.Thursday;
                    if (schedule.Friday != null)
                        this.fridayCheck.Checked = (bool)schedule.Friday;
                    if (schedule.Saturday != null)
                        this.saturdayCheck.Checked = (bool)schedule.Saturday;
                    if (schedule.Sunday != null)
                        this.sundayCheck.Checked = (bool)schedule.Sunday;

                    if (schedule.Date != null)
                        this.scheduleDate.Value = (DateTime)schedule.Date;
                    if (schedule.Time != null)
                        this.scheduleTime.Value = (DateTime)schedule.Time;

                    if (schedule.Minutes != null)
                        this.minutesText.Text = schedule.Minutes.ToString();
                    if (schedule.To != null)
                        this.toTime.Value = (DateTime)schedule.To;
                    if (schedule.From != null)
                        this.fromTime.Value = (DateTime)schedule.From;
                }
                else
                    this.scheduleTypeCombo.SelectedIndex = 0;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void scheduleTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scheduleTypeCombo.SelectedIndex > -1)
            {
                this.applyButton.Enabled = true;

                switch (scheduleTypeCombo.SelectedIndex)
                {
                    case 0: //Default
                        ChangeDayOptions(false);
                        dayTimeGroup.Enabled = false;
                        dayOfTheWeekGroup.Enabled = false;
                        break;

                    case 1: //Once
                        ChangeDayOptions(false);
                        dayOfTheWeekGroup.Enabled = false;
                        dayTimeGroup.Enabled = true;
                        this.minutesText.Text = "0";
                        this.minutesText.Enabled = false;
                        this.fromTime.Value = this.toTime.Value = new DateTime(2011, 01, 01, 0, 0, 0);
                        this.fromTime.Enabled = this.toTime.Enabled = false;
                        this.scheduleDate.Enabled = this.scheduleTime.Enabled = true;
                        this.scheduleDate.Value = DateTime.Now;
                        this.scheduleTime.Value = new DateTime(2011, 01, 01, 02, 0, 0);
                        break;

                    case 2: //Daily
                        ChangeDayOptions(false);
                        dayOfTheWeekGroup.Enabled = false;
                        dayTimeGroup.Enabled = true;
                        this.minutesText.Text = "0";
                        this.minutesText.Enabled = false;
                        this.fromTime.Value = this.toTime.Value = new DateTime(2011, 01, 01, 0, 0, 0);
                        this.fromTime.Enabled = this.toTime.Enabled = false;
                        this.scheduleDate.Value = DateTime.Now;
                        this.scheduleDate.Enabled = false;
                        this.scheduleTime.Enabled = true;
                        this.scheduleTime.Value = new DateTime(2011, 01, 01, 02, 0, 0);
                        break;

                    case 3: //Weekly
                        ChangeDayOptions(true);
                        dayOfTheWeekGroup.Enabled = true;
                        dayTimeGroup.Enabled = true;
                        this.minutesText.Text = "0";
                        this.minutesText.Enabled = false;
                        this.fromTime.Value = this.toTime.Value = new DateTime(2011, 01, 01, 0, 0, 0);
                        this.fromTime.Enabled = this.toTime.Enabled = false;
                        this.scheduleDate.Value = DateTime.Now;
                        this.scheduleDate.Enabled = false;
                        this.scheduleTime.Enabled = true;
                        this.scheduleTime.Value = new DateTime(2011, 01, 01, 02, 0, 0);
                        break;

                    case 4: //Time
                        ChangeDayOptions(false);
                        dayOfTheWeekGroup.Enabled = false;
                        dayTimeGroup.Enabled = true;
                        this.minutesText.Text = "0";
                        this.minutesText.Enabled = true;
                        this.fromTime.Value = new DateTime(2011, 01, 01, 0, 0, 0);
                        this.toTime.Value = new DateTime(2011, 01, 01, 23, 59, 59);
                        this.fromTime.Enabled = this.toTime.Enabled = true;
                        this.scheduleDate.Value = DateTime.Now;
                        this.scheduleDate.Enabled = false;
                        this.scheduleTime.Value = new DateTime(2011, 01, 01, 0, 0, 0);
                        this.scheduleTime.Enabled = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void ChangeDayOptions(bool p)
        {
            this.mondayCheck.Checked = this.tuesdayCheck.Checked = this.wednesdayCheck.Checked =
                this.thursdayCheck.Checked = this.fridayCheck.Checked = this.saturdayCheck.Checked = this.sundayCheck.Checked = p;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            SaveSchedule();

            this.applyButton.Enabled = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveSchedule();

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void SaveSchedule()
        {
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                try
                {
                    var schedule = (from sc in db.CrextorSchedules
                                    where sc.CrextorId == crextorId
                                    select sc).SingleOrDefault();

                    if (schedule != null)
                    {
                        schedule.LastRun = null;

                        // update
                        switch (scheduleTypeCombo.SelectedIndex)
                        {
                            case 0: //Default
                                schedule.Type = 0;
                                schedule.Date = null;
                                schedule.Monday = null;
                                schedule.Tuesday = null;
                                schedule.Wednesday = null;
                                schedule.Thursday = null;
                                schedule.Friday = null;
                                schedule.Saturday = null;
                                schedule.Sunday = null;
                                schedule.Time = null;
                                schedule.To = null;
                                schedule.From = null;
                                schedule.Minutes = null;
                                break;

                            case 1: //Once
                                schedule.Type = 1;
                                schedule.Minutes = null;
                                schedule.Date = this.scheduleDate.Value;
                                schedule.Time = this.scheduleTime.Value;
                                schedule.Monday = null;
                                schedule.Tuesday = null;
                                schedule.Wednesday = null;
                                schedule.Thursday = null;
                                schedule.Friday = null;
                                schedule.Saturday = null;
                                schedule.Sunday = null;
                                schedule.To = null;
                                schedule.From = null;
                                break;

                            case 2: //Daily
                                schedule.Type = 2;
                                schedule.Time = this.scheduleTime.Value;
                                schedule.Date = null;
                                schedule.Monday = null;
                                schedule.Tuesday = null;
                                schedule.Wednesday = null;
                                schedule.Thursday = null;
                                schedule.Friday = null;
                                schedule.Saturday = null;
                                schedule.Sunday = null;
                                schedule.To = null;
                                schedule.From = null;
                                schedule.Minutes = null;
                                break;

                            case 3: //Weekly
                                schedule.Type = 3;
                                schedule.Time = this.scheduleTime.Value;
                                schedule.Monday = this.mondayCheck.Checked;
                                schedule.Tuesday = this.tuesdayCheck.Checked;
                                schedule.Wednesday = this.wednesdayCheck.Checked;
                                schedule.Thursday = this.thursdayCheck.Checked;
                                schedule.Friday = this.fridayCheck.Checked;
                                schedule.Saturday = this.saturdayCheck.Checked;
                                schedule.Sunday = this.sundayCheck.Checked;
                                schedule.Date = null;
                                schedule.To = null;
                                schedule.From = null;
                                schedule.Minutes = null;
                                break;

                            case 4: //Timer
                                schedule.Type = 4;
                                schedule.Minutes = short.Parse(this.minutesText.Text);
                                schedule.From = this.fromTime.Value;
                                schedule.To = this.toTime.Value;
                                schedule.Date = null;
                                schedule.Monday = null;
                                schedule.Tuesday = null;
                                schedule.Wednesday = null;
                                schedule.Thursday = null;
                                schedule.Friday = null;
                                schedule.Saturday = null;
                                schedule.Sunday = null;
                                schedule.Time = null;
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        CrextorSchedule newSchedule = new CrextorSchedule();
                        newSchedule.CrextorId = this.crextorId;
                        newSchedule.LastRun = null;

                        // insert
                        switch (scheduleTypeCombo.SelectedIndex)
                        {
                            case 0: //Default
                                newSchedule.Type = 0;
                                newSchedule.Date = null;
                                newSchedule.Monday = null;
                                newSchedule.Tuesday = null;
                                newSchedule.Wednesday = null;
                                newSchedule.Thursday = null;
                                newSchedule.Friday = null;
                                newSchedule.Saturday = null;
                                newSchedule.Sunday = null;
                                newSchedule.Time = null;
                                newSchedule.To = null;
                                newSchedule.From = null;
                                newSchedule.Minutes = null;
                                break;

                            case 1: //Once
                                newSchedule.Type = 1;
                                newSchedule.Minutes = null;
                                schedule.Date = this.scheduleDate.Value;
                                newSchedule.Time = this.scheduleTime.Value;
                                newSchedule.Monday = null;
                                newSchedule.Tuesday = null;
                                newSchedule.Wednesday = null;
                                newSchedule.Thursday = null;
                                newSchedule.Friday = null;
                                newSchedule.Saturday = null;
                                newSchedule.Sunday = null;
                                newSchedule.To = null;
                                newSchedule.From = null;
                                break;

                            case 2: //Daily
                                newSchedule.Type = 2;
                                newSchedule.Time = this.scheduleTime.Value;
                                newSchedule.Date = null;
                                newSchedule.Monday = null;
                                newSchedule.Tuesday = null;
                                newSchedule.Wednesday = null;
                                newSchedule.Thursday = null;
                                newSchedule.Friday = null;
                                newSchedule.Saturday = null;
                                newSchedule.Sunday = null;
                                newSchedule.To = null;
                                newSchedule.From = null;
                                newSchedule.Minutes = null;
                                break;

                            case 3: //Weekly
                                newSchedule.Type = 3;
                                newSchedule.Time = this.scheduleTime.Value;
                                newSchedule.Monday = this.mondayCheck.Checked;
                                newSchedule.Tuesday = this.tuesdayCheck.Checked;
                                newSchedule.Wednesday = this.wednesdayCheck.Checked;
                                newSchedule.Thursday = this.thursdayCheck.Checked;
                                newSchedule.Friday = this.fridayCheck.Checked;
                                newSchedule.Saturday = this.saturdayCheck.Checked;
                                newSchedule.Sunday = this.sundayCheck.Checked;
                                newSchedule.Date = null;
                                newSchedule.To = null;
                                newSchedule.From = null;
                                newSchedule.Minutes = null;
                                break;

                            case 4: //Timer
                                newSchedule.Type = 4;
                                newSchedule.Minutes = short.Parse(this.minutesText.Text);
                                newSchedule.From = this.fromTime.Value;
                                newSchedule.To = this.toTime.Value;
                                newSchedule.Date = null;
                                newSchedule.Monday = null;
                                newSchedule.Tuesday = null;
                                newSchedule.Wednesday = null;
                                newSchedule.Thursday = null;
                                newSchedule.Friday = null;
                                newSchedule.Saturday = null;
                                newSchedule.Sunday = null;
                                newSchedule.Time = null;
                                break;

                            default:
                                break;
                        }

                        db.CrextorSchedules.InsertOnSubmit(newSchedule);
                    }

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void mondayCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.applyButton.Enabled = true;
        }
    }
}
