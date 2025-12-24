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
    public partial class FrmFiltro : def
    {
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public FrmFiltro()
        {
            InitializeComponent();           
        }
        private void FrmFiltro_Load(object sender, EventArgs e)
        {
            LoadDefaults();
            LoadOrderData();
            _CustomizeMenu();
            //new tclass().executeCode(this, BO, EXE);
        }
        public class OrderRec
        {
            public string id { get; set; }
            public string description { get; set; }
        }

        public virtual void LoadDefaults() { }

        public virtual void LoadOrderData() { }
        public void LoadOrderData(List<OrderRec> OrderRecs)
        {
            megaCombo_Order.megaComboBox.ValueMember = "id";
            megaCombo_Order.megaComboBox.DisplayMember = "description";
            megaCombo_Order.megaComboBox.DataSource = OrderRecs;
        }

        private void Execute_(object sender, EventArgs e)
        { Cursor.Current = Cursors.WaitCursor; Execute(); Cursor.Current = Cursors.Default; }

        public virtual void Execute() { }

        public void Execute(DataTable dt, string ReportPath, string CompanyName, string Param)
        {
            Form childForm = new Forms.frmReport(ReportPath, dt,Param,CompanyName);
            childForm.MdiParent = this.MdiParent;
            childForm.Show();
            this.Close();
        }

        private void _CustomizeMenu()
        {
            toolStripDropDownButton1.Text = _s.G(1);
            Page1.Text = _s.G(1);
            updateToolStripMenuItem.Text = _s.G(2);
            megaCombo_Order.Text_Label = _s.G(3);
            CustomizeMenu();
        }
        public virtual void CustomizeMenu() { }

        class S
        {
            private string lang = "gr";
            public S(string _lang) { lang = _lang; }

            public string G(int id)
            {
                switch (lang)
                {
                    case "gr":
                        switch (id)
                        {
                            case 1: return "Επιλογές";
                            case 2: return "Εκτέλεση";
                            case 3: return "Ταξινόμηση";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Options";
                            case 2: return "Execute";
                            case 3: return "Order";
                            default: return "String not found";
                        }

                }
            }

        }

    }
}
