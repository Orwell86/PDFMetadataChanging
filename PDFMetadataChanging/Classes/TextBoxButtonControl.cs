using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AppNexus.BSG.SunAtlas.PDFMetadataChanging
{
    class TextBoxButtonControl : UserControl
    {
        public TextBox txtBox { get; set; }
        public Button btn { get; set; }

        public TextBoxButtonControl()
        {
            this.Width = 350;
            this.Height = 350;
            this.txtBox = new TextBox();
            this.Controls.Add(this.txtBox);
            this.btn = new Button();
            this.Controls.Add(this.btn);
            this.RenderControl();
        }

        private void RenderControl()
        {
            this.txtBox.Location = new Point(0, 0);
            this.txtBox.Width = this.Width;
            this.txtBox.Height = this.Height;
            this.btn.Location = new Point(this.Width, 0);
            this.btn.Width = 20;
            this.btn.Height = 20;
        }
    }
}