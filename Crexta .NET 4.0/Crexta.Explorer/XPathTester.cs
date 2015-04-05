using System;
using System.Linq;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Crexta.Explorer
{
    public partial class XPathTester : Form
    {
        private HtmlAgilityPack.HtmlDocument currentDoc = null; 

        public XPathTester()
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

            this.htmlText.Text = this.currentDoc.DocumentNode.InnerHtml;

            this.tabControl1.SelectTab(1);
        }

        private void singleNodeButton_Click(object sender, EventArgs e)
        {
            if (this.currentDoc != null)
            {
                HtmlNode root = HtmlNode.CreateNode(this.htmlText.Text);
                     
                HtmlNode node = root.SelectSingleNode(this.xpathText.Text);

                this.resultText.Text = "";
                if (node != null)
                    this.resultText.Text = node.InnerHtml;

                if (this.useResult.Checked)
                    this.htmlText.Text = this.resultText.Text;
            }
        }

        private void multipleNodesButton_Click(object sender, EventArgs e)
        {
            if (this.currentDoc != null)
            {
                HtmlNode root = HtmlNode.CreateNode(this.htmlText.Text);

                HtmlNodeCollection nodes = root.SelectNodes(this.xpathText.Text);

                this.resultText.Text = "";
                if (nodes != null)
                    foreach (HtmlNode n in nodes)
                        this.resultText.Text += n.InnerHtml + Environment.NewLine;

                if (this.useResult.Checked)
                    this.htmlText.Text = this.resultText.Text;
            }
        }
    }
}
