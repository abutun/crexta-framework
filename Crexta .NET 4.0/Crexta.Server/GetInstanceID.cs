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
using System.IO;

namespace Crexta.Server
{
    public partial class GetInstanceID : Form
    {
        public GetInstanceID()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            string filePath = Utilities.Utilities.AssemblyDirectory + @"\id.ins";

            //Create instance file
            if (File.Exists(filePath))
                File.Delete(filePath);

            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(this.instanceIDText.Text);
                sw.Flush();

                sw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

                this.DialogResult = DialogResult.Cancel;

                this.Close();
            }

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
