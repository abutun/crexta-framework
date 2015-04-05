using System;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Serialization;
using Crexta.Common;
using Crexta.Common.Crawler;

namespace Crexta.Test
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person(this.textBox1.Text, this.textBox2.Text, this.textBox5.Text);

            Serializer.Serialize(p, "Person");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person p = (Person)Serializer.Deserialize("Person");

            this.textBox3.Text = p.Name;
            this.textBox4.Text = p.Surname;
            this.textBox6.Text = p.MiddleName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string currentItem = this.textBox7.Text;
            if (currentItem.StartsWith("ID:"))
            {
                int k = -1;
                k = currentItem.IndexOf("URL:");

                // k<14 ensures that no other URL: syntax in the original URL is accepted
                // k<14 tells that we can use up 1 billion resource records :)
                if (k > 3 && k < 14)
                {
                    int currentResourceId = int.Parse(currentItem.Substring(3, k - 4));
                    string currentItemURLPart = currentItem.Substring(k + 4);
                    string currentItemURL = currentItemURLPart;
                    string currentItemPubDate = "";

                    int t = -1;
                    t = currentItemURLPart.IndexOf("PUBDATE:");
                    if (t > 0)
                    {
                        currentItemURL = currentItemURLPart.Substring(0, t - 1);
                        currentItemPubDate = currentItemURLPart.Substring(t + 8);
                    }

                    this.textBox8.Text = currentResourceId.ToString() + ":::" + currentItemURL + ":::" + currentItemPubDate;
                }
            }
        }

        private string clearString(string source)
        {
            string result = source;

            result = result.Trim();

            return result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Digger digger = new Digger();
            this.textBox8.Text = digger.Resolve(new Uri(this.textBox7.Text)).ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string currentRssInfo = "URL:http://spor.milliyet.com.tr/g-saray-kulupler-birligi-nden-cekiliyor-/spor/spordetay/31.12.2011/1482789/default.htm;DU:1";
            if (!currentRssInfo.Equals(""))
            {
                if (currentRssInfo.StartsWith("URL:"))
                {
                    int k = -1;
                    k = currentRssInfo.IndexOf("DU:");
                    if (k > 0)
                    {
                        string currentRssURL = currentRssInfo.Substring(4, k-5);
                        int discoverRedirects = int.Parse(currentRssInfo.Substring(k+3, 1));

                        this.textBox7.Text = currentRssURL + Environment.NewLine + discoverRedirects.ToString();
                    }
                }
            }
        }
    }

    [Serializable]
    public class Person : ISerializable
    {
        private string name = "";
        private string surname = "";
        private string middlename = "";

        private readonly int version = 2;

        public Person(string name, string surname, string middlename)
        {
            this.name = name;
            this.surname = surname;
            this.middlename = middlename;
        }

        public Person() : this("", "", "") { }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            int version = 1;
            try
            {
                version = info.GetInt32("version");
            }
            catch
            {
                // NOP
            }

            switch (version)
            {
                case 1:
                    name = info.GetString("name");
                    surname = info.GetString("surname");
                    break;
                case 2:
                    name = info.GetString("name");
                    surname = info.GetString("surname");
                    middlename = info.GetString("middlename");
                    break;
            }
        }

        #region ISerializable Members

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", name);
            info.AddValue("surname", surname);
            info.AddValue("middlename", middlename);
            info.AddValue("version", version);
        }

        #endregion
    }

}
