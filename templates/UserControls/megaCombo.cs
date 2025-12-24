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
    public partial class megaCombo : UserControl
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
            get { return megaLabel.Text;  }
            set { megaLabel.Text = value; }
        }

        [Description("text displayed in the combobox"), Category("Data")]
        public string Text_Textbox
        {
            get { return megaComboBox.Text; }
            set { megaComboBox.Text = value; }
        }

        [Description("datafield in the textbox"), Category("Data")]
        public string datafield
        { get; set; }
       
        [Description("ValueMember in the combobox"), Category("Data")]        
        public string ValueMember
        { 
            get 
            { 
                return megaComboBox.ValueMember; 
            } 
            set 
            {
                if (value.Length == 0)
                    megaComboBox.ValueMember = "id";
                else
                    megaComboBox.ValueMember = value; 
            } 
        }

        [Description("DisplayMember in the combobox"), Category("Data")]        
        public string DisplayMember
        { get { return megaComboBox.DisplayMember; } set { megaComboBox.DisplayMember = value ; } }

        [Description("DataSource in the combobox"), Category("Data")]
        public object DataSource
        { get { return megaComboBox.DataSource; }
          set { megaComboBox.DataSource = value; } }

        public megaCombo()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.AutoSize = true;
            megaComboBox.DisplayMember = "Name";
           
        }

       
        public event EventHandler megaComboBox_selectedIndexChanged;
        private void megaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(Convert.ToInt32(e.KeyChar)==13) { SendKeys.Send("{TAB}"); }
        }

       
        private void megaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { this.megaComboBox_selectedIndexChanged(this, new EventArgs()); }
            catch { }
        }
    }
}
