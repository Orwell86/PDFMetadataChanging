using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text.xml.xmp;
using Excel;

namespace AppNexus.BSG.SunAtlas.PDFMetadataModifier
{
    public partial class MainForm : Form
    {
        private TextBoxButtonControl txtBoxBtn;
        private DataGridViewTextBoxCell cell;

        public MainForm()
        {
            InitializeComponent();

            this.txtBoxBtn = new TextBoxButtonControl();
            this.txtBoxBtn.Visible = false;
            this.dataGridViewPDFLookups.Controls.Add(this.txtBoxBtn);
            //this.saveFilesToTxtBox.Controls.Add(this.txtBoxBtn);

            this.saveFilesToTxtBox.Click += saveFilesToTxtBox_Click;

            this.dataGridViewPDFLookups.CellClick += dataGridViewPDFLookups_CellClick;
            this.dataGridViewPDFLookups.ColumnHeaderMouseClick += dataGridViewPDFLookups_ColumnHeaderMouseClick;

            this.txtBoxBtn.txtBox.TextChanged += txtBox_TextChanged;
            this.txtBoxBtn.btn.Click += txtBoxBtn_Click;
        }

        private void saveFilesToTxtBox_Click(object sender, EventArgs e)
        {
            this.txtBoxBtn.Location = this.saveFilesToTxtBox.Location;
            this.txtBoxBtn.Size = this.saveFilesToTxtBox.Size;
            this.txtBoxBtn.Visible = true;
            this.txtBoxBtn.Focus();
        }

        private void dataGridViewPDFLookups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Rectangle rect = this.dataGridViewPDFLookups.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                this.txtBoxBtn.Location = rect.Location;
                this.txtBoxBtn.Size = rect.Size;
                this.txtBoxBtn.Visible = true;
                this.txtBoxBtn.Focus();

                cell = (DataGridViewTextBoxCell)dataGridViewPDFLookups.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
                {
                    this.txtBoxBtn.txtBox.Text = cell.Value.ToString();
                }
                else
                {
                    this.txtBoxBtn.txtBox.Text = "";
                }
            }
        }

        private void dataGridViewPDFLookups_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.txtBoxBtn.Visible = false;
        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            cell.Value = txtBoxBtn.txtBox.Text;
        }

        private void txtBoxBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Adobe PDF Files (*.pdf)|*.pdf|Excel Files (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBoxBtn.txtBox.Text = fileDialog.FileName.ToString();
                if (cell.ColumnIndex == 1)
                {
                    dataGridViewPDFLookups.NotifyCurrentCellDirty(true);
                    dataGridViewPDFLookups.Rows.Insert(cell.RowIndex + 1, new DataGridViewRow());
                    dataGridViewPDFLookups.NotifyCurrentCellDirty(false);
                }
            }
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            DialogResult result = browserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                saveFilesToTxtBox.Text = browserDialog.SelectedPath;
            }
        }
        
        private void CommitBtn_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(saveFilesToTxtBox.Text))
            {
                MessageBox.Show("Correct filepath should be chosen.");
                return;
            }

            foreach (var line in dataGridViewPDFLookups.Rows)
            {
                DataGridViewRow gridViewRow = (DataGridViewRow)line;
                if ((gridViewRow.Cells[0].Value != null && !string.IsNullOrEmpty(gridViewRow.Cells[0].Value.ToString())) &&
                    (gridViewRow.Cells[1].Value != null && !string.IsNullOrEmpty(gridViewRow.Cells[1].Value.ToString())))
                {
                    string newPdfFileName = String.Format(@"{0}\{1}", saveFilesToTxtBox.Text, Path.GetFileName(gridViewRow.Cells[0].Value.ToString()));
                    PdfReader pdfChangeReader = new PdfReader(gridViewRow.Cells[0].Value.ToString());
                    PdfStamper pdfChangeStamper = new PdfStamper(pdfChangeReader, new FileStream(newPdfFileName, FileMode.Create));
                    Dictionary<string, string> pdfChangeInfo = pdfChangeReader.Info;

                    if (gridViewRow.Cells[1].Value.ToString().Substring(gridViewRow.Cells[1].Value.ToString().Length - 3) == "pdf")
                    {
                        PdfReader pdfTemplateReader = new PdfReader(gridViewRow.Cells[1].Value.ToString());
                        Dictionary<string, string> pdfTemplateInfo = pdfTemplateReader.Info;

                        foreach (string attribute in pdfTemplateInfo.Keys)
                        {
                            if (pdfChangeInfo.ContainsKey(attribute))
                            {
                                pdfChangeInfo[attribute] = pdfTemplateInfo[attribute];
                            }
                            else
                            {
                                pdfChangeInfo.Add(attribute, pdfTemplateInfo[attribute]);
                            }
                        }
                    }
                    else
                    {
                        foreach (var worksheet in Workbook.Worksheets(gridViewRow.Cells[1].Value.ToString()))
                        {
                            foreach (var row in worksheet.Rows)
                            {
                                string attribute = "";
                                foreach (var cell in row.Cells)
                                {
                                    if (cell != null)
                                    {
                                        cell.Text = Regex.Replace(cell.Text, @",", "");
                                        if (cell.ColumnIndex == 0)
                                        {
                                            attribute = cell.Text;
                                        }
                                        else
                                        {
                                            if (pdfChangeInfo.ContainsKey(attribute))
                                            {
                                                pdfChangeInfo[attribute] = cell.Text;
                                            }
                                            else
                                            {
                                                pdfChangeInfo.Add(attribute, cell.Text);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    pdfChangeStamper.MoreInfo = pdfChangeInfo;
                    MemoryStream memoryStream = new MemoryStream();
                    XmpWriter xmp = new XmpWriter(memoryStream, pdfChangeInfo);
                    xmp.Close();
                    pdfChangeStamper.XmpMetadata = memoryStream.ToArray();
                    pdfChangeStamper.Close();
                }
            }

            dataGridViewPDFLookups.Rows.Clear();
            dataGridViewPDFLookups.Refresh();
            this.txtBoxBtn.Dispose();
            MessageBox.Show("Finished.");
        }        
    }
}