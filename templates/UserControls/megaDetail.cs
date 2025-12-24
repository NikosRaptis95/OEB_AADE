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
    public partial class megaDetail : UserControl
    {
        [Browsable(true)]
        public event EventHandler LoadData;
        [Browsable(true)]
        public event EventHandler NewRecord;
        [Browsable(true)]
        public event EventHandler DeleteRecord;
        [Browsable(true)]
        public event EventHandler EditRecord;
        [Browsable(true)]
        public event EventHandler RefreshRecord;


        public megaDetail()
        {
            InitializeComponent();   
        }
        private void megaDetail_Load(object sender, EventArgs e)
        {
            try
            {
                //this.LoadData(this, new EventArgs());
            }
            catch { }
        }
       
        [Description("this is the menu"), Category("Interface")]
        public ToolStrip Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        [Description("this is the DataGrid"), Category("Interface")]
        public DataGridView DetailGrid
        {
            get { return megaGridView; }
            set { megaGridView = value; }
        }

        private List<string> _pf;
        [Description("this is the Return List Of Strings"), Category("Interface")]
        public List<string> PrimaryFields
        { get { return _pf; }  set { _pf = value; } }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void Button_NewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                this.NewRecord(this, new EventArgs());
            }
            catch { }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                this.DeleteRecord(this, new EventArgs());
            }
            catch { }
        }

        public void RefreshData()
        {
          
                try
                {
                    this.RefreshRecord(this, new EventArgs());
                }
                catch { }
            
        }

        private void megaGridView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.EditRecord(this, new EventArgs());
            }
            catch { }
        }

    }
}
