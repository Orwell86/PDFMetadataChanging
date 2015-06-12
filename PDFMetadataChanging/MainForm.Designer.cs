namespace AppNexus.BSG.SunAtlas.PDFMetadataChanging
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.CommitBtn = new System.Windows.Forms.Button();
            this.dataGridViewPDFLookups = new System.Windows.Forms.DataGridView();
            this.pdfFileToChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdfFileTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilesToTxtBox = new System.Windows.Forms.TextBox();
            this.saveFilesToLabel = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPDFLookups)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CommitBtn
            // 
            this.CommitBtn.Location = new System.Drawing.Point(6, 279);
            this.CommitBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CommitBtn.Name = "CommitBtn";
            this.CommitBtn.Size = new System.Drawing.Size(785, 115);
            this.CommitBtn.TabIndex = 4;
            this.CommitBtn.Text = "Commit";
            this.CommitBtn.UseVisualStyleBackColor = true;
            this.CommitBtn.Click += new System.EventHandler(this.CommitBtn_Click);
            // 
            // dataGridViewPDFLookups
            // 
            this.dataGridViewPDFLookups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPDFLookups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pdfFileToChange,
            this.pdfFileTemplate});
            this.dataGridViewPDFLookups.Location = new System.Drawing.Point(6, 12);
            this.dataGridViewPDFLookups.Name = "dataGridViewPDFLookups";
            this.dataGridViewPDFLookups.Size = new System.Drawing.Size(784, 223);
            this.dataGridViewPDFLookups.TabIndex = 6;
            // 
            // pdfFileToChange
            // 
            this.pdfFileToChange.HeaderText = "PDF File to Change";
            this.pdfFileToChange.Name = "pdfFileToChange";
            this.pdfFileToChange.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pdfFileToChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pdfFileToChange.Width = 370;
            // 
            // pdfFileTemplate
            // 
            this.pdfFileTemplate.HeaderText = "PDF File Template";
            this.pdfFileTemplate.Name = "pdfFileTemplate";
            this.pdfFileTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.pdfFileTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pdfFileTemplate.Width = 370;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteRowMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(134, 26);
            // 
            // deleteRowMenuItem
            // 
            this.deleteRowMenuItem.Name = "deleteRowMenuItem";
            this.deleteRowMenuItem.Size = new System.Drawing.Size(133, 22);
            this.deleteRowMenuItem.Text = "Delete Row";
            // 
            // saveFilesToTxtBox
            // 
            this.saveFilesToTxtBox.Location = new System.Drawing.Point(7, 254);
            this.saveFilesToTxtBox.Name = "saveFilesToTxtBox";
            this.saveFilesToTxtBox.Size = new System.Drawing.Size(702, 20);
            this.saveFilesToTxtBox.TabIndex = 7;
            // 
            // saveFilesToLabel
            // 
            this.saveFilesToLabel.AutoSize = true;
            this.saveFilesToLabel.Location = new System.Drawing.Point(3, 238);
            this.saveFilesToLabel.Name = "saveFilesToLabel";
            this.saveFilesToLabel.Size = new System.Drawing.Size(74, 13);
            this.saveFilesToLabel.TabIndex = 8;
            this.saveFilesToLabel.Text = "Save files to...";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(715, 252);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 9;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 405);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.saveFilesToLabel);
            this.Controls.Add(this.saveFilesToTxtBox);
            this.Controls.Add(this.dataGridViewPDFLookups);
            this.Controls.Add(this.CommitBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "PDF Metadata Changing";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPDFLookups)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CommitBtn;
        private System.Windows.Forms.DataGridView dataGridViewPDFLookups;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdfFileToChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdfFileTemplate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteRowMenuItem;
        private System.Windows.Forms.TextBox saveFilesToTxtBox;
        private System.Windows.Forms.Label saveFilesToLabel;
        private System.Windows.Forms.Button browseBtn;
    }
}

