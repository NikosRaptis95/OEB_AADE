using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace templates.UserControls
{
    public partial class megaTrackBar : UserControl
    {
        [Description("datafield in the textbox"), Category("Data")]
        public string datafield
        { get; set; }

        [Description("text displayed in the Label"), Category("Data")]
        public string Text_Label
        {
            get { return megaLabel.Text; }
            set { megaLabel.Text = value; }
        }

        public megaTrackBar()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.AutoSize = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.megaTextBox.Text = mega_trackBar.Value.ToString();
        }

        private void megaTextBox_TextChanged(object sender, EventArgs e)
        {
            if (megaTextBox.Text.Length == 0) megaTextBox.Text = "0";
            if (System.Text.RegularExpressions.Regex.IsMatch(megaTextBox.Text, "[^0-9]"))
                            megaTextBox.Text = megaTextBox.Text.Remove(megaTextBox.Text.Length - 1);
            mega_trackBar.Value = Convert.ToUInt16(megaTextBox.Text);

        }

        private void megaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) { SendKeys.Send("{TAB}"); }
        }

        private void megaTextBox_Leave(object sender, EventArgs e)
        {
          
        }
    }
}
