namespace PDFMetadataChanging
{
    partial class Form1
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
            this.PDFBtn = new System.Windows.Forms.Button();
            this.ExcelBtn = new System.Windows.Forms.Button();
            this.PDFFileName = new System.Windows.Forms.TextBox();
            this.ExcelFileName = new System.Windows.Forms.TextBox();
            this.CommitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PDFBtn
            // 
            this.PDFBtn.Location = new System.Drawing.Point(279, 12);
            this.PDFBtn.Name = "PDFBtn";
            this.PDFBtn.Size = new System.Drawing.Size(75, 23);
            this.PDFBtn.TabIndex = 0;
            this.PDFBtn.Text = "PDF";
            this.PDFBtn.UseVisualStyleBackColor = true;
            this.PDFBtn.Click += new System.EventHandler(this.PDFBtn_Click);
            // 
            // ExcelBtn
            // 
            this.ExcelBtn.Location = new System.Drawing.Point(279, 41);
            this.ExcelBtn.Name = "ExcelBtn";
            this.ExcelBtn.Size = new System.Drawing.Size(75, 23);
            this.ExcelBtn.TabIndex = 1;
            this.ExcelBtn.Text = "Excel";
            this.ExcelBtn.UseVisualStyleBackColor = true;
            this.ExcelBtn.Click += new System.EventHandler(this.ExcelBtn_Click);
            // 
            // PDFFileName
            // 
            this.PDFFileName.Enabled = false;
            this.PDFFileName.Location = new System.Drawing.Point(12, 13);
            this.PDFFileName.Name = "PDFFileName";
            this.PDFFileName.Size = new System.Drawing.Size(261, 22);
            this.PDFFileName.TabIndex = 2;
            // 
            // ExcelFileName
            // 
            this.ExcelFileName.Enabled = false;
            this.ExcelFileName.Location = new System.Drawing.Point(12, 42);
            this.ExcelFileName.Name = "ExcelFileName";
            this.ExcelFileName.Size = new System.Drawing.Size(261, 22);
            this.ExcelFileName.TabIndex = 3;
            // 
            // CommitBtn
            // 
            this.CommitBtn.Location = new System.Drawing.Point(12, 70);
            this.CommitBtn.Name = "CommitBtn";
            this.CommitBtn.Size = new System.Drawing.Size(342, 81);
            this.CommitBtn.TabIndex = 4;
            this.CommitBtn.Text = "Commit";
            this.CommitBtn.UseVisualStyleBackColor = true;
            this.CommitBtn.Click += new System.EventHandler(this.CommitBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 161);
            this.Controls.Add(this.CommitBtn);
            this.Controls.Add(this.ExcelFileName);
            this.Controls.Add(this.PDFFileName);
            this.Controls.Add(this.ExcelBtn);
            this.Controls.Add(this.PDFBtn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "PDF Metadata Changing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PDFBtn;
        private System.Windows.Forms.Button ExcelBtn;
        private System.Windows.Forms.TextBox PDFFileName;
        private System.Windows.Forms.TextBox ExcelFileName;
        private System.Windows.Forms.Button CommitBtn;
    }
}

