using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using HtmlAgilityPack;
using System.Web;

namespace Crexta.Test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //GetXMLDocument();
            HtmlAgilityPack.HtmlDocument doc = new HtmlWeb().Load("http://www.zaman.com.tr/");

            Uri uri = new Uri("http://www.zaman.com.tr/");

            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                att.Value = att.Value.Replace("&amp;", "&");

                this.richTextBox1.Text += att.Value + Environment.NewLine;
                if (!(att.Value.StartsWith("http://") || att.Value.StartsWith("https://") || att.Value.StartsWith("www.")))
                {
                    if (att.Value.StartsWith("/"))
                        att.Value = "http://" + uri.Host + att.Value;
                    else
                        att.Value = "http://" + uri.Host + "/" + att.Value;
                }
                this.richTextBox1.Text += att.Value + Environment.NewLine;
                this.richTextBox1.Text += "------------------------------"+ Environment.NewLine;
            }

        }

        private void GetXMLDocument()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Crexta\XML\Client\50.xml");

            if (xmlDoc != null)
            {
                //Enumerate Rules
                XmlNodeList rules = xmlDoc.GetElementsByTagName("rule");

                if (rules != null)
                {
                    if (rules.Count > 0)
                    {
                        string rulename = "";
                        string tablename = "";
                        int crextorid = 0;
                        int queueid = 0;

                            //Enumerate rule
                            foreach (XmlNode rule in rules)
                            {
                                rulename = "";
                                if (rule.Attributes["name"] != null)
                                    rulename = rule.Attributes["name"].Value;
                                tablename = "";
                                if (rule.Attributes["tablename"] != null)
                                    tablename = rule.Attributes["tablename"].Value;
                                crextorid = 0;
                                if (rule.Attributes["crextorId"] != null)
                                    crextorid = int.Parse(rule.Attributes["crextorId"].Value);
                                queueid = 0;
                                if (rule.Attributes["queueId"] != null)
                                    queueid = int.Parse(rule.Attributes["queueId"].Value);

                                if (crextorid > 0 && queueid > 0)
                                {
                                    XmlNodeList criterias = rule.ChildNodes;

                                    string pid = GetProductID(criterias);

                                    string criteriaName = "";
                                    string columnName = "";
                                    string columnType = "";
                                    string criteriaValue = "";

                                    foreach (XmlNode criteria in criterias)
                                    {
                                        //We have everything we need here, do some real god damn job!
                                        criteriaName = "";
                                        if (criteria.Attributes["name"] != null)
                                            criteriaName = criteria.Attributes["name"].Value.ToLowerInvariant();
                                        columnName = "";
                                        if (criteria.Attributes["columnname"] != null)
                                            columnName = criteria.Attributes["columnname"].Value.ToLowerInvariant();
                                        columnType = "";
                                        if (criteria.Attributes["columntype"] != null)
                                            columnType = criteria.Attributes["columntype"].Value.ToLowerInvariant();

                                        criteriaValue = criteria.Value;
                                        //columnLength = GetColumnLength(columnName);
                                    }
                                }
                            }
                    }
                }
            }
        }

        private string GetProductID(XmlNodeList criterias)
        {
            string result = "";

            if (criterias != null)
            {
                foreach (XmlNode criteria in criterias)
                {
                    if (criteria.Attributes["columnName"] != null)
                    {
                        string name = criteria.Attributes["columnName"].Value.ToLowerInvariant();

                        if (name == "pid" || name == "productid" || name == "id" || name == "itemid")
                        {
                            if (criteria.HasChildNodes)
                            {
                                XmlNode itemNode = criteria.FirstChild;

                                if (itemNode != null)
                                {
                                    if (itemNode.Value != null)
                                        result = itemNode.Value.ToLowerInvariant();
                                    else
                                        result = itemNode.InnerText.ToLowerInvariant();

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetXMLDocument();
        }

    }
}
