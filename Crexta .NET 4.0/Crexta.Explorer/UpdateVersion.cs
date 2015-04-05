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
using System.IO;
using System.Linq;
using System.Windows.Forms;

using ICSharpCode.SharpZipLib.Zip;
using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Explorer
{
    public partial class UpdateVersion : Form
    {
        private string versionFile = Common.Constants.GeneralConstants.defaultRuleListVersionRoot + "version.ver";
        private string mainlistFile = Common.Constants.GeneralConstants.defaultRuleListFileRoot + "MainList.zip";
        private string mainlistWWWPath = Common.Constants.GeneralConstants.defaultMainlistDownloadPath + "MainList.zip";

        public UpdateVersion()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Set file version
                if (File.Exists(versionFile))
                    File.Delete(versionFile);
                else
                {
                    // Create target folder
                    if (!Directory.Exists(Common.Constants.GeneralConstants.defaultRuleListVersionRoot))
                        Directory.CreateDirectory(Common.Constants.GeneralConstants.defaultRuleListVersionRoot);
                }

                StreamWriter sw = new StreamWriter(versionFile);
                sw.WriteLine(this.textBox1.Text);
                sw.Flush();
                sw.Close();

                //Copy version file in order to be zipped!
                File.Copy(versionFile, Common.Constants.GeneralConstants.defaultRulesFileRoot + "version.ver", true);

                // Depending on the directory this could be very large and would require more attention
                // in a commercial package.
                string[] filenames = Directory.GetFiles(Common.Constants.GeneralConstants.defaultRulesFileRoot);

                // Create target folder
                if (!Directory.Exists(Common.Constants.GeneralConstants.defaultRuleListFileRoot))
                    Directory.CreateDirectory(Common.Constants.GeneralConstants.defaultRuleListFileRoot);

                // 'using' statements guarantee the stream is closed properly which is a big source
                // of problems otherwise.  Its exception safe as well which is great.
                using (ZipOutputStream s = new ZipOutputStream(File.Create(mainlistFile)))
                {

                    s.SetLevel(9); // 0 - crextor only to 9 - means best compression

                    byte[] buffer = new byte[4096];

                    foreach (string file in filenames)
                    {

                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(Path.GetFileName(file));

                        // Setup the entry data as required.

                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.

                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.Now;
                        s.PutNextEntry(entry);

                        using (FileStream fs = File.OpenRead(file))
                        {

                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }

                    // Finish/Close arent needed strictly as the using statement does this automatically

                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();

                    // Close is important to wrap things up and unlock the file.
                    s.Close();

                    // Update DB
                    CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
                    if (db != null)
                    {
                        var version = (from ve in db.Versions
                                       where ve.Id == 1
                                       select ve).SingleOrDefault();

                        if (version != null)
                        {
                            version.Version1 = this.textBox1.Text;

                            db.SubmitChanges();
                        }
                        else
                            MessageBox.Show("Cannot update DB information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                        MessageBox.Show("Backup Succesfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                this.Close();
                // No need to rethrow the exception as for our purposes its handled.
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void UpdateVersion_Load(object sender, EventArgs e)
        {
            CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString);
            if (db != null)
            {
                var version = (from ve in db.Versions
                               where ve.Id == 1
                               select ve).SingleOrDefault();

                if (version != null)
                    this.textBox1.Text = version.Version1;
            }
            else
                MessageBox.Show("Cannot get DB information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
    }
}
