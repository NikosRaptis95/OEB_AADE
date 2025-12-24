using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.iForms
{
    public partial class InputBox : MetroForm
    {
        public InputBox(string label, string text, string prompt)
        {
            InitializeComponent();
            this.label1.Text = label;
            this.Text = text;
            this.textBox1.Text = prompt;
            Program.global.InputBoxText = "cancel";
        }

        private void button2_Click(object sender, EventArgs e)
        { this.Close(); }

        private void button1_Click(object sender, EventArgs e)
        {   Program.global.InputBoxText = this.textBox1.Text;  this.Close(); }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //textBox1.Text = dateTimePicker1.Value.ToString("yyyy MM(MMM) dd(ddd) hh_mm_ss") + ".jpg";
            textBox1.Text = dateTimePicker1.Value.ToString("yyyy MM(MMMM) dd(dddd)") + ".jpg";
        }
    }
}
