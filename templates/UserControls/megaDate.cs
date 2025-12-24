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
    public partial class megaDate : UserControl
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

        [Description("datetime displayed in the box"), Category("Data")]
        public DateTime Text_Datebox
        {
            get { return megaDateBox.Value; }
            set { megaDateBox.Value = value; }
        }

        [Description("datafield"), Category("Data")]
        public string datafield
        { get; set; }


        public megaDate()
        {
            InitializeComponent();
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.AutoSize = true;
        }

        
    }
}
