using System;
using System.Linq;
using System.Windows.Forms;
using WatiN.Core;
using HtmlAgilityPack;
using NCrawler.HtmlProcessor.Extensions;
using System.Globalization;

namespace Crexta.Test
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private bool loaded = false;

        private bool clicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private byte GetNextWorkingModeForNewClient()
        {
            //UF : URLFounder
            //DE : DataExtractor

            try
            {
                int mode1Clients = int.Parse(this.textBox1.Text);

                if (mode1Clients == 0)
                    return 1; //No UF then assign one

                //Check mode2 clients
                int mode2Clients = int.Parse(this.textBox2.Text);

                if (mode1Clients == 1)
                {
                    if (mode2Clients == 0)
                        return 2;//1 UF, 0 DE then assing at least one DE
                    else
                        return 1;//1 UF, >=1 DE then assign new UF
                }
                else
                {
                    if (mode2Clients == 0)
                        return 2;

                    //Implement 1/4 RULE HERE (UF = 4xDE)
                    if (mode1Clients < mode2Clients * 4)
                        return 1;
                    else
                        return 2;
                }
            }
            catch (Exception)
            {
            }

            return 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label3.Text = GetNextWorkingModeForNewClient().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = this.textBox3.Text.ToLowerInvariant();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("www.google.com");
            Schedule schedule = new Schedule();
            schedule.Type = 2;

            if (schedule == null || (schedule != null && schedule.Type == 0))
                MessageBox.Show("TTTTT");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var browser = new IE("http://www.firmanya.com/Ingilizce-ogrenmek-icin-kursa-gitmeye-vaktiniz-yok-mu-Oyleyse-bu-set-tam-size-gore-5-DVDlik-Turkce-destekli-online-ingilizce-seti-95TL-yerine-2150TL--P997.aspx"))
            {
                //browser.TextField(Find.ByName("q")).TypeText("A");
                //browser.Button(Find.ByName("btnG")).Click();
                browser.Link(Find.ByText("Zaten üyeyim")).Click();

                this.label3.Text = browser.Title;
                this.webBrowser1.Navigate(browser.Url);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument htmlDoc = htmlWeb.Load("http://market.mekanist.net/category.aspx?id=3");

            // Extract Links
            DocumentWithLinks links = htmlDoc.GetLinks();
            foreach (string link in links.Links.Union(links.References))
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Parse(this.date1.Text, CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat);
            DateTime date2 = DateTime.Parse(this.date2.Text, CultureInfo.GetCultureInfo("tr-TR").DateTimeFormat);

            TimeSpan sub = date1.Subtract(date2);

            this.day.Text = sub.Days.ToString();
            this.hour.Text = sub.Hours.ToString();
            this.minute.Text = sub.Minutes.ToString();

            this.totaldays.Text = sub.TotalDays.ToString();
            this.totalhours.Text = sub.TotalHours.ToString();
            this.totalminutes.Text = sub.TotalMinutes.ToString();
        }
    }

    public class Schedule
    {
        public Schedule()
        {
        }

        public int Type {get;set;}
    }
}
