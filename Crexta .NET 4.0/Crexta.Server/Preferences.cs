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

namespace Crexta.Server
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
                this.deURLListCount.Value = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorURLSetCount].ToString());
                this.deMulitplierCount.Value = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorMultiplier].ToString());
                this.clientIdleTimeInSeconds.Value = int.Parse(Settings.ServerSettings[ServerConstants.clientMaxIDLETimeInSeconds].ToString());
                this.reflectBrandCheck.Checked = bool.Parse(Settings.ServerSettings[ServerConstants.reflectBrandPrediction].ToString());
                this.reflectCategoryCheck.Checked = bool.Parse(Settings.ServerSettings[ServerConstants.reflectCategoryPrediction].ToString());
                this.ufUseU2mServiceCheck.Checked = bool.Parse(Settings.ServerSettings[ServerConstants.shortenURLsWithU2M].ToString());
                this.deDataHoursNumeric.Value = decimal.Parse(Settings.ServerSettings[ServerConstants.crawlerExtractHourThreshold].ToString());
                this.deDataMinutesNumeric.Value = decimal.Parse(Settings.ServerSettings[ServerConstants.crawlerExtractMinuteThreshold].ToString());
                this.clientReconnectMinutes.Value = decimal.Parse(Settings.ServerSettings[ServerConstants.clientReConnectTimeMinutes].ToString());
                this.clientReconnectSeconds.Value = decimal.Parse(Settings.ServerSettings[ServerConstants.clientReConnectTimeSeconds].ToString());
                this.logAllEventsCheckBox.Checked = bool.Parse(Settings.ServerSettings[ServerConstants.logAllEvents].ToString());
                this.dumpResultsCheckBox.Checked = bool.Parse(Settings.ServerSettings[ServerConstants.dumpXMLResult2Disk].ToString());
                this.deUrlRetryCount.Value = int.Parse(Settings.ServerSettings[ServerConstants.dataExtractorUrlRetryCount].ToString());
            }
            catch (Exception ex)
            {
                if (ex.GetType() != typeof(NullReferenceException))
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private bool SaveSettings()
        {
            try
            {
                if (this.clientIdleTimeInSeconds.Value > 0)
                {
                    if (this.clientReconnectMinutes.Value * 60 + this.clientReconnectSeconds.Value >= this.clientIdleTimeInSeconds.Value)
                    {
                        MessageBox.Show("Client reconnection time cannot be greater than client idle time!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                // GENERAL
                Settings.ServerSettings[ServerConstants.shortenURLsWithU2M] = this.ufUseU2mServiceCheck.Checked;
                Settings.ServerSettings[ServerConstants.reflectBrandPrediction] = this.reflectBrandCheck.Checked;
                Settings.ServerSettings[ServerConstants.reflectCategoryPrediction] = this.reflectCategoryCheck.Checked;
                Settings.ServerSettings[ServerConstants.clientMaxIDLETimeInSeconds] = this.clientIdleTimeInSeconds.Value;
                Settings.ServerSettings[ServerConstants.dataExtractorMultiplier] = this.deMulitplierCount.Value;
                Settings.ServerSettings[ServerConstants.dataExtractorURLSetCount] = this.deURLListCount.Value;
                Settings.ServerSettings[ServerConstants.crawlerExtractHourThreshold] = this.deDataHoursNumeric.Value;
                Settings.ServerSettings[ServerConstants.crawlerExtractMinuteThreshold] = this.deDataMinutesNumeric.Value;
                Settings.ServerSettings[ServerConstants.clientReConnectTimeMinutes] = this.clientReconnectMinutes.Value;
                Settings.ServerSettings[ServerConstants.clientReConnectTimeSeconds] = this.clientReconnectSeconds.Value;
                Settings.ServerSettings[ServerConstants.logAllEvents] = this.logAllEventsCheckBox.Checked;
                Settings.ServerSettings[ServerConstants.dumpXMLResult2Disk] = this.dumpResultsCheckBox.Checked;
                Settings.ServerSettings[ServerConstants.dataExtractorUrlRetryCount] = this.deUrlRetryCount.Value;

                Settings.SaveSettings(instance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                return false;
            }

            return true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            if (SaveSettings())
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl1.SelectTab(0);
        }
    }
}
