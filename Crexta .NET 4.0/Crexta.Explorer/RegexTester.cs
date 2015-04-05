using System;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Crexta.Explorer
{
    public partial class RegexTester : Form
    {
        private HtmlAgilityPack.HtmlDocument currentDoc = null;

        public RegexTester()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            this.browseButton.Enabled = false;

            Uri currentUri = null;

            if (Uri.TryCreate(this.urlText.Text, UriKind.Absolute, out currentUri))
            {
                //this.webBrowser1.Navigate(currentUri);

                this.webBrowser1_DocumentCompleted(this, new WebBrowserDocumentCompletedEventArgs(currentUri));
            }

            this.browseButton.Enabled = true;
        }

        private void XPathTester_Load(object sender, EventArgs e)
        {
            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
        }

        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            currentDoc = web.Load(e.Url.ToString());

            this.regexText.Enabled = true;
            this.singleNodeButton.Enabled = true;

            this.htmlText.Text = this.currentDoc.DocumentNode.InnerHtml;

            this.tabControl1.SelectTab(1);
        }

        private void singleNodeButton_Click(object sender, EventArgs e)
        {
            if (this.currentDoc != null || this.htmlText.Text != "")
            {
                string result = "";
                string source = "";

                if (!this.useUrlCheck.Checked)
                    source = this.htmlText.Text;
                else
                    source = this.urlText.Text;

                Regex reg = new Regex(this.regexText.Text, GetOptions());

                this.resultText.Text = "";
                if (reg.IsMatch(source))
                {
                    string tmp = "";

                    MatchCollection matches = reg.Matches(source);
                    foreach (Match m in matches)
                    {
                        result += m.Value;

                        if (m.Groups.Count > 0)
                        {
                            int gi = 0;
                            foreach (Group g in m.Groups)
                            {
                                tmp += "Group " + gi.ToString() + " : " + g.Value + Environment.NewLine;

                                int ca = 0;
                                foreach (Capture c in g.Captures)
                                {
                                    tmp += "     Capture " + ca.ToString() + " : " + c.Value + Environment.NewLine;
                                    ca++;
                                }

                                gi++;
                            }
                        }
                        else
                            tmp += m.Value;
                    }

                    this.resultText.Text = tmp;
                }

                if (this.useResult.Checked)
                    this.htmlText.Text = result;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.optionsPanel.Visible = !this.optionsPanel.Visible;
        }

        private RegexOptions GetOptions()
        {
            RegexOptions options = RegexOptions.None;

            if (this.compiledCheck.Checked)
                options = options | RegexOptions.Compiled;

            if (this.singleLineCheck.Checked)
                options = options | RegexOptions.Singleline;

            if (this.multilineCheck.Checked)
                options = options | RegexOptions.Multiline;

            if (this.ignoreCaseCheck.Checked)
                options = options | RegexOptions.IgnoreCase;

            if (this.ignoreWhiteCheck.Checked)
                options = options | RegexOptions.IgnorePatternWhitespace;

            if (this.cultoreCheck.Checked)
                options = options | RegexOptions.CultureInvariant;

            return options;
        }

        private void RegexTester_Click(object sender, EventArgs e)
        {
            this.optionsPanel.Visible = false;
        }

        private void useUrlCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.regexText.Enabled)
                this.regexText.Enabled = true;

            if (!this.singleNodeButton.Enabled)
                this.singleNodeButton.Enabled = true;
        }
    }
}
