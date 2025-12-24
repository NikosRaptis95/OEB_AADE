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

namespace DesktopBusiness.reports
{
    public partial class repFiltro : templates.Forms.def
    {
        #region formDefinition

        private string Report;
        private Boolean Kinhseis;
        private Boolean Synalassomenoi;
        private Boolean Parastatika;
        public repFiltro(string report, Boolean kinhseis, Boolean synalassomenoi, Boolean parastatika)
        {
            InitializeComponent();
            Report = report;
            if (kinhseis==false) { this.tabControl1.TabPages.Remove(Label_tabPage1); }
            Kinhseis = kinhseis;
            if (synalassomenoi == false) { this.tabControl1.TabPages.Remove(Label_tabPage2); }
            Synalassomenoi = synalassomenoi;
            if (parastatika == false) { this.tabControl1.TabPages.Remove(Label_tabPage3); }
            Parastatika = parastatika;
            this.Text = "Αναφορές (" +  Report + ")";
        }

        private void isoFiltro_Load(object sender, EventArgs e)
        {
            initData();
        }
        #endregion

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            accountsClassLibrary.reports.Reports mc = new accountsClassLibrary.reports.Reports(Report);

            // kinhseis
            mc.fromKinFl.RegistryDate = textbox_fk_RegistryDate.Value.Date;
            mc.toKinFl.RegistryDate = textBox_tk_RegistryDate.Value.Date;
            mc.fromKinFl.Seira = textBox_fk_Seira.Text;
            mc.fromKinFl.AitiKin = textBox_fk_AitiKin.Text;
            mc.fromKinFl.id = textBox_fk_Id.Text;
            mc.toKinFl.id = textBox_tk_Id.Text;
            mc.fromKinFl.KoKiKin.id = textBox_K_KoKikin_ID.SelectedValue.ToString();
            mc.fromKinFl.Cash = textbox_fk_Cash.SelectedValue.ToString();
            mc.fromKinFl.Status.id = textbox_k_status_id.SelectedValue.ToString();
            mc.fromKinFl.SalesPerson = textBox_fk_SalesPerson.Text;
            mc.fromKinFl.idSyn.id = textBox_fs_id.Text;
            mc.fromKinFl.idSyn.Name = textBox_s_Name.Text;
            mc.toKinFl.idSyn.id = textBox_ts_id.Text;            
            mc.fromKinFl.idSyn.Category.id = textBox_s_category_id.SelectedValue.ToString();
            mc.fromKinFl.idSyn.Occupation.id = textBox_s_Occupation_id.SelectedValue.ToString();
            mc.fromKinFl.idSyn.PriceList.id = textBox_s_PriceList_id.SelectedValue.ToString();
            mc.fromKinFl.idSyn.KindOfTax.id = textBox_s_kindoftax_id.SelectedValue.ToString();
            mc.fromKinFl.idSyn.Status.id = textBox_S_Status_id.SelectedValue.ToString();
            mc.fromKinFl.idSyn.Kind.id = textBox_s_Type_id.SelectedValue.ToString();

            // synallasomenos
            mc.fromSynFl.id = textBox_fs_id.Text;
            mc.toSynFl.id = textBox_ts_id.Text;
            mc.toSynFl.Name = textBox_s_Name.Text;
            mc.fromSynFl.Category.id = textBox_s_category_id.SelectedValue.ToString();
            mc.fromSynFl.Occupation.id = textBox_s_Occupation_id.SelectedValue.ToString();
            mc.fromSynFl.PriceList.id = textBox_s_PriceList_id.SelectedValue.ToString();
            mc.fromSynFl.KindOfTax.id = textBox_s_kindoftax_id.SelectedValue.ToString();
            mc.fromSynFl.Status.id = textBox_S_Status_id.SelectedValue.ToString();
            mc.fromSynFl.Kind.id = textBox_s_Type_id.SelectedValue.ToString();

            Form childForm = new iForms.frmReport(mc.getReportName(), mc.getData(textbox_Tajinomisi.SelectedValue.ToString()), mc.getDescF(this));
            childForm.MdiParent = this.MdiParent;            
            childForm.Show();
            this.Close();
        }
        #endregion

        #region GlobalFuncsAndVars
        private void initData()
        {
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
            mc.customizationforLabels(this.Label_tabPage1,"repFiltro");
            mc.customizationforLabels(this.Label_tabPage2, "repFiltro");
            mc.customizationforLabels(this.Label_tabPage3, "repFiltro");
            mc.customizationforLabels(this.tabControl1, "repFiltro");
            mc.customizationforLabels(this);
            LoadCombos();
            textbox_fk_RegistryDate.Value = new DateTime(DateTime.Now.Year - 1, 12, 31);
            textBox_s_category_id.Text = "";           
        }
        private void LoadCombos()
        {
            LoadFilPinCombo(textBox_s_category_id, accountsClassLibrary.FilPin.TypeOfPin.Category);
            LoadFilPinCombo(this.textBox_s_Occupation_id, accountsClassLibrary.FilPin.TypeOfPin.Occupation);
            LoadFilPinCombo(textBox_s_PriceList_id, accountsClassLibrary.FilPin.TypeOfPin.PriceList);

            LoadParPinCombo(textBox_s_kindoftax_id, accountsClassLibrary.ParPin.TypeOfPar.KindOfTax);
            LoadParPinCombo(textBox_s_Type_id, accountsClassLibrary.ParPin.TypeOfPar.Kind);
            LoadParPinCombo(textbox_k_status_id, accountsClassLibrary.ParPin.TypeOfPar.Status);
            LoadParPinCombo(textBox_S_Status_id, accountsClassLibrary.ParPin.TypeOfPar.Status);

            accountsClassLibrary.KinFl mcp = new accountsClassLibrary.KinFl();
            DataTable dt = mcp.ReadZoomSalesPerson();
            textBox_fk_SalesPerson.Items.Clear();
            textBox_fk_SalesPerson.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            { textBox_fk_SalesPerson.Items.Add(dt.Rows[i]["SalesPerson"]); }

            dt.Clear();
            string S = "%";            
            dt = mcp.ReadZoomSeira(S);
            textBox_fk_Seira.Items.Clear();
            textBox_fk_Seira.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            { textBox_fk_Seira.Items.Add(dt.Rows[i]["Seira"]); }

            dt.Clear();
            S = "%";
            dt = mcp.ReadZoomAitiKin(S);
            textBox_fk_AitiKin.Items.Clear();
            textBox_fk_AitiKin.Items.Add("");
            for (int i = 0; i < dt.Rows.Count; i++)
            { textBox_fk_AitiKin.Items.Add(dt.Rows[i]["AitiKin"]); }

            accountsClassLibrary.KoKiKin mck = new accountsClassLibrary.KoKiKin();
            dt.Clear();
            dt = mck.ReadZoom();

            DataRow row;
            row = dt.NewRow();
            row["id"] = "";
            row["Name"] = "";
            dt.Rows.InsertAt(row, 0);
            textBox_K_KoKikin_ID.DisplayMember = "Name";
            textBox_K_KoKikin_ID.ValueMember = "id";
            textBox_K_KoKikin_ID.DataSource = dt;

            DataTable dtc = mck.ReadCashZoom();
            row = dtc.NewRow();
            row["id"] = "";
            row["Name"] = "";
            dtc.Rows.InsertAt(row, 0);
            textbox_fk_Cash.DisplayMember = "Name";
            textbox_fk_Cash.ValueMember = "id";
            textbox_fk_Cash.DataSource = dtc;

            this.textbox_Tajinomisi.DisplayMember = "Name";
            this.textbox_Tajinomisi.ValueMember = "id";
            accountsClassLibrary.reports.Reports order = new accountsClassLibrary.reports.Reports(Report);
            this.textbox_Tajinomisi.DataSource = order.getOrder();

        }
        private void LoadFilPinCombo(ComboBox MyCombo, accountsClassLibrary.FilPin.TypeOfPin fpType)
        {
            try
            {
                accountsClassLibrary.FilPin mcp = new accountsClassLibrary.FilPin("%");
                DataTable dt = mcp.ReadZoom(fpType);

                DataRow row;
                row = dt.NewRow();
                row["id"] = "";
                row["Name"] = "";
                dt.Rows.InsertAt(row, 0);

                MyCombo.DisplayMember = "Name";
                MyCombo.ValueMember = "id";
                MyCombo.DataSource = dt;
            }
            catch { }
        }

        private void LoadParPinCombo(ComboBox MyCombo, accountsClassLibrary.ParPin.TypeOfPar ppType)
        {            
            accountsClassLibrary.ParPin mcp = new accountsClassLibrary.ParPin();
            DataTable dt = mcp.ReadZoom(ppType);

            DataRow row;
            row = dt.NewRow();
            row["id"] = "";
            row["Name"] = "";
            dt.Rows.InsertAt(row, 0);

            MyCombo.DisplayMember = "Name";
            MyCombo.ValueMember = "id";
            MyCombo.DataSource = dt;
        }

       #endregion

     
    }
}
