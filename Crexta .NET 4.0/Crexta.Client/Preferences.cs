/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*	CREXTA - Web Data Extraction Framework  							*
*																		*
*	Copyright (C) 2009-2011  Ahmet BÜTÜN (ahmetbutun@gmail.com)			*
*	http://www.ahmetbutun.net |	http://www.abbsolutions.com				*
*																		*
*	www.me-like.biz														*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.Linq;
using System.Windows.Forms;
using Crexta.Common.Constants;

namespace Crexta.Client
{
    public partial class Preferences : Form
    {
        private static string instance = "0";

        public Preferences(string ins)
        {
            InitializeComponent();

            instance = ins;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                Settings.LoadSettings(instance);

                // GENERAL
                this.threadPriorityComboBox.SelectedIndex = int.Parse(Settings.ClientSettings[GeneralConstants.clientStartThreadPriority].ToString());

                // URL FOUNDER
                this.ufMaxURLListCount.Value = decimal.Parse(Settings.ClientSettings[URLFinderConstants.maxURLCount].ToString());
                this.threadCountUpDown.Value = decimal.Parse(Settings.ClientSettings[URLFinderConstants.crawlThreadCount].ToString());
                this.crawlDeptUpDown.Value = decimal.Parse(Settings.ClientSettings[URLFinderConstants.crawlDeptLevel].ToString());
                this.ufWaitSecUpDown.Value = decimal.Parse(Settings.ClientSettings[URLFinderConstants.waitingTimeInSeconds].ToString());
                this.ufIntervalMaxCount.Value = decimal.Parse(Settings.ClientSettings[URLFinderConstants.requestCount].ToString());
                this.ufIntervalTimeInSeconds.Value = decimal.Parse(Settings.ClientSettings[URLFinderConstants.requestIntervalInSeconds].ToString());
                this.ufUseU2mServiceCheck.Checked = bool.Parse(Settings.ClientSettings[URLFinderConstants.useU2mService].ToString());

                // DATA EXTRACTOR
                this.deWaitSecUpDown.Value = decimal.Parse(Settings.ClientSettings[DataExtractorConstants.waitingTimeInSeconds].ToString());
                this.deIntervalMaxCount.Value = decimal.Parse(Settings.ClientSettings[DataExtractorConstants.requestCount].ToString());
                this.deIntervalTimeInSeconds.Value = decimal.Parse(Settings.ClientSettings[DataExtractorConstants.requestIntervalInSeconds].ToString());
                this.deDataHoursNumeric.Value = decimal.Parse(Settings.ClientSettings[DataExtractorConstants.crawlerExtractHourThreshold].ToString());
                this.deDataMinutesNumeric.Value = decimal.Parse(Settings.ClientSettings[DataExtractorConstants.crawlerExtractMinuteThreshold].ToString());
                this.useWatiNBrowser.Checked = bool.Parse(Settings.ClientSettings[DataExtractorConstants.useWatiNBuiltInBrowser].ToString());

                //CLIENT
                this.logAllEventsCheckBox.Checked = bool.Parse(Settings.ClientSettings[ClientConstants.logAllEvents].ToString());
                this.showNitificationsCheck.Checked = bool.Parse(Settings.ClientSettings[ClientConstants.showNotifications].ToString());
            }
            catch(Exception ex)
            {
                if (ex.GetType() != typeof(NullReferenceException))
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void SaveSettings()
        {
            try
            {
                // GENERAL
                Settings.ClientSettings[GeneralConstants.clientStartThreadPriority] = this.threadPriorityComboBox.SelectedIndex;

                // URL FOUNDER
                Settings.ClientSettings[URLFinderConstants.crawlThreadCount] = this.threadCountUpDown.Value;
                Settings.ClientSettings[URLFinderConstants.maxURLCount] = this.ufMaxURLListCount.Value;
                Settings.ClientSettings[URLFinderConstants.crawlDeptLevel] = this.crawlDeptUpDown.Value;
                Settings.ClientSettings[URLFinderConstants.waitingTimeInSeconds] = this.ufWaitSecUpDown.Value;
                Settings.ClientSettings[URLFinderConstants.requestCount] = this.ufIntervalMaxCount.Value;
                Settings.ClientSettings[URLFinderConstants.requestIntervalInSeconds] = this.ufIntervalTimeInSeconds.Value;
                Settings.ClientSettings[URLFinderConstants.useU2mService] = this.ufUseU2mServiceCheck.Checked;

                // DATA EXTRACTOR
                Settings.ClientSettings[DataExtractorConstants.waitingTimeInSeconds] = this.deWaitSecUpDown.Value;
                Settings.ClientSettings[DataExtractorConstants.requestCount] = this.deIntervalMaxCount.Value;
                Settings.ClientSettings[DataExtractorConstants.requestIntervalInSeconds] = this.deIntervalTimeInSeconds.Value;
                Settings.ClientSettings[DataExtractorConstants.crawlerExtractHourThreshold] = this.deDataHoursNumeric.Value;
                Settings.ClientSettings[DataExtractorConstants.crawlerExtractMinuteThreshold] = this.deDataMinutesNumeric.Value;
                Settings.ClientSettings[DataExtractorConstants.useWatiNBuiltInBrowser] = this.useWatiNBrowser.Checked;

                //CLIENT
                Settings.ClientSettings[ClientConstants.logAllEvents] = this.logAllEventsCheckBox.Checked;
                Settings.ClientSettings[ClientConstants.showNotifications] = this.showNitificationsCheck.Checked;

                Settings.SaveSettings(instance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            SaveSettings();

            this.Close();
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            this.SaveSettings();

            this.applyButton.Enabled = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
