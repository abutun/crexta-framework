using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.IO;

using Crexta.DataBase;
using Crexta.Utilities;

namespace Crexta.Indexer
{
    public partial class Indexer : Form
    {
        private Thread i_IndexerThread = null;

        private Common.Common i_CrextaCommon = new Crexta.Common.Common();

        public Indexer()
        {
            InitializeComponent();
        }

        private void Indexer_Load(object sender, EventArgs e)
        {
            //Get total items waiting to be indexed
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    //Check directory existance
                    if (!Directory.Exists(i_CrextaCommon.IndexPath))
                        Directory.CreateDirectory(i_CrextaCommon.IndexPath);

                }
            }
        }

        private void StopIndexing()
        {
            try
            {
                if (this.i_IndexerThread != null)
                {
                    if (this.i_IndexerThread.ThreadState == ThreadState.Running)
                        this.i_IndexerThread.Abort();
                }
            }
            catch
            {
                //NOP
            }
        }

        private void startIndexingButton_Click(object sender, EventArgs e)
        {
            this.i_IndexerThread = new Thread(new ThreadStart(this.StartIndexing));
            this.i_IndexerThread.Name = "Crexta - Indexer";
            this.i_IndexerThread.IsBackground = true;

            this.i_IndexerThread.Start();

            //StartIndexing();
        }

        private void StartIndexing()
        {
            //Get total items waiting to be indexed
            using (CrextaDataContext db = new CrextaDataContext(DBUtility.ConnectionString))
            {
                if (db != null)
                {
                    
                }
            }
        }

        private void IndexKeywords(Lucene.Net.Index.IndexWriter indexWriter, string keyword, int id)
        {
            //create a document, add in a single field
            Lucene.Net.Documents.Document doc = new Lucene.Net.Documents.Document();

            Lucene.Net.Documents.Field fldContent = new Lucene.Net.Documents.Field("content", PrePareKeywords(keyword), 
                Lucene.Net.Documents.Field.Store.YES,
                Lucene.Net.Documents.Field.Index.ANALYZED,
                Lucene.Net.Documents.Field.TermVector.YES);

            doc.Add(fldContent);

            //ID
            fldContent = new Lucene.Net.Documents.Field("id", id.ToString(),
                Lucene.Net.Documents.Field.Store.YES,
                Lucene.Net.Documents.Field.Index.NOT_ANALYZED,
                Lucene.Net.Documents.Field.TermVector.NO);

            doc.Add(fldContent);

            //PRICE

            //write the document to the index
            indexWriter.AddDocument(doc);
        }

        private string PrePareKeywords(string keyword)
        {
            string result = "";

            //TR-tr
            result = keyword.ToLower(new System.Globalization.CultureInfo("tr-TR"));
            result += " " + keyword.ToUpper(new System.Globalization.CultureInfo("tr-TR"));

            //EN-en
            result += " " + keyword.ToLower(new System.Globalization.CultureInfo("en-US"));
            result += " " + keyword.ToUpper(new System.Globalization.CultureInfo("en-US"));

            return result;
        }
    }
}
