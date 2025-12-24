using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class koki : templates.Forms.frmMaster
    {
        public string id;
        public koki(string id_)
        {
            this.id = id_;
            InitializeComponent();
        }
        DataTable dt = new DataTable(); 
        public override void LoadData()
        {
            dt = new FilPin().ReadZoomFromProduct(FilPin.TypeOfPin.PriceList, id);
            megaCombo_Timo.megaComboBox.DataSource = dt;
        }
        public override void UpdateBtn()
        {
            Program.global.InputBoxText = megaCombo_Timo.megaComboBox.SelectedValue.ToString();
            this.Close();
        }
    }
}
