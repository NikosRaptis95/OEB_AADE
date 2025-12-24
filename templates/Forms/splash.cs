using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates.Forms
{
    public partial class splash : def
    {
        public splash()
        {
            InitializeComponent();
            if (System.IO.File.Exists(@"images\splash.jpg"))
                this.BackgroundImage = new Bitmap(@"images\splash.jpg");

            new tclass().executeCode(this, BO, EXE);
            label1.Text = Application.CompanyName + " - " + Application.ProductName+ " Ver."+Application.ProductVersion;
            //label2.Text = "";
            T = 0;
        }

        private int T;
        private void timer1_Tick(object sender, EventArgs e)
        {
            T += 1;           
            if (T >= progressBar1.Maximum) this.Close();
            else progressBar1.Value = T;
        }

        private void splash_Load(object sender, EventArgs e)
        {
            //new tclass().executeCode(this, BO, EXE);
        }
    }
}
