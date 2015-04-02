using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.xml.xmp;
using Excel;

namespace PDFMetadataChanging
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PDFBtn_Click(object sender, EventArgs e)
        {
            BrowseDialog(PDFFileName, "Adobe PDF Files (*.pdf)|*.pdf");
        }

        private void ExcelBtn_Click(object sender, EventArgs e)
        {
            BrowseDialog(ExcelFileName, "All Excel Files (*.xlsx)|*.xlsx");
        }

        private void CommitBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string newFileName = String.Format("{0}_{1}{2}", PDFFileName.Text.Substring(0, PDFFileName.Text.IndexOf(".")),
                    DateTime.Now.Date.ToString("MMddyyyy"), PDFFileName.Text.Substring(PDFFileName.Text.IndexOf(".")));
                PdfReader reader = new PdfReader(PDFFileName.Text);
                PdfStamper stamper = new PdfStamper(reader, new FileStream(newFileName, FileMode.Create));
                Dictionary<string, string> info = reader.Info;

                foreach (var worksheet in Workbook.Worksheets(ExcelFileName.Text))
                    foreach (var row in worksheet.Rows)
                    {
                        string attribute = "";
                        foreach (var cell in row.Cells)
                            if (cell != null)
                            {
                                if (cell.ColumnIndex == 0)
                                {
                                    attribute = cell.Text;
                                }
                                else
                                    if (info.ContainsKey(attribute))
                                        info[attribute] = cell.Text;
                                    else
                                        info.Add(attribute, cell.Text);
                            }
                    }
                stamper.MoreInfo = info;
                MemoryStream stream = new MemoryStream();
                XmpWriter xmp = new XmpWriter(stream, info);
                xmp.Close();
                stamper.XmpMetadata = stream.ToArray();
                stamper.Close();

                PDFFileName.Text = "";
                ExcelFileName.Text = "";
                MessageBox.Show("Successful conversion.");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void BrowseDialog(TextBox txtBox, string extension)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = extension;
            if (fileDialog.ShowDialog() == DialogResult.OK)
                txtBox.Text = fileDialog.FileName;
        }
    }
}