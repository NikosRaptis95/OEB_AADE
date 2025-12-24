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
    public partial class megaFind : UserControl
    {
        [Description("text displayed in the Label"), Category("Data")]
        public override string Text
        {
            get { return megaLabel.Text; }
            set { megaLabel.Text = value; }
        }

        [Description("text displayed in the Label"), Category("Data")]
        public string Text_Label
        {
            get { return megaLabel.Text; }
            set { megaLabel.Text = value; }
        }

        [Description("text displayed in the textbox"), Category("Data")]
        public string Text_Textbox
        {
            get { return megaTextBox.Text; }
            set { megaTextBox.Text = value; }
        }

        [Description("datafield in the textbox"), Category("Data")]
        public string datafield
        { get; set; }

        [Description("ValueMember in the Text"), Category("Data")]
        public string ValueMember
        { get; set; }

        [Description("DisplayMember in the combobox"), Category("Data")]
        public string DisplayMember
        { get; set; }

        [Description("default text in the textbox"), Category("Data")]
        public string Text_Default
        { get; set; }

        [Description("multiline in the textbox"), Category("Data")]
        public Boolean Text_Multiline
        {
            get { return megaTextBox.Multiline; }
            set { megaTextBox.Multiline = value; }
        }

        [Description("scrollBars in the textbox"), Category("Data")]
        public ScrollBars Text_ScrollBars
        {
            get { return megaTextBox.ScrollBars; }
            set { megaTextBox.ScrollBars = value; }
        }

        [Description("Height in the textbox"), Category("Data")]
        public int Text_Height
        {
            get { return megaTextBox.Height; }
            set { megaTextBox.Height = value; }
        }

        [Description("MaxLength in the textbox"), Category("Data")]
        public int Text_MaxLength
        {
            get { return megaTextBox.MaxLength; }
            set { megaTextBox.MaxLength = value; }
        }

        [Description("Zoom call form"), Category("Data")]
        public Forms.CallFrm CallForm
        { get; set; }

        public megaFind()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.ValueMember = "id";
            this.DisplayMember = "Name";
        }

        public event EventHandler megaTextBox_textChanged;
        private void megaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) { SendKeys.Send("{TAB}"); }         
        }

        private void megaTextBox_TextChanged(object sender, EventArgs e)
        {
            try { this.megaTextBox_textChanged(this, new EventArgs()); }
            catch(Exception ee) { MessageBox.Show("Set 'textChanged' event \n"+ee.Message, Name); }
            
        }

        private void megaButton_Click(object sender, EventArgs e)
        {
            CallForm.menu.Visible = false;
            CallForm.ShowDialog();
            try { if(templates.global.r[0].ToString().Trim().Length>0) this.megaTextBox.Text = templates.global.r[0]; }
            catch {  }
        }
    }
}
