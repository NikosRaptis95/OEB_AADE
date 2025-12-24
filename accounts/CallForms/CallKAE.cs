using accountsClassLibrary;
using DesktopBusiness.iForms;
using DesktopBusiness.MForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.CallForms
{
    public partial class CallKAE : templates.Forms.CallFrm
    {
        public CallKAE()
        {
            InitializeComponent();
        }
        public CallKAE(string _auditTransactionId)
        {
            auditTransactionId = _auditTransactionId;
            setFormsGlobals();
        }
        public string auditTransactionId;

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid            
            List<Object> cols = new List<Object>();
            for (int i = 0; i <= 4; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            List<string> fields = new List<string>() { "AA", "id", "Kae", "amount" };
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "KAE", "Ποσό" };
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();

            // Μεταφορα ονόματος στις παραμέτρους
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ ΚΑΕ του Πρωτοκόλου   
            new alphaFrameWork.AlphaFramework().Bind(this.DataGrid,
                                                   new KAEFl().ReadZoom(auditTransactionId),
                                                   cols, fields, fname);
            searchBox.Visible = false;
            CrearButton.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;


            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id)
        {
            return new accountsClassLibrary.KAEFl().Delete(id[0]);
        }

        public override templates.Forms.def CallForm(List<string> id) { return new DesktopBusiness.MForms.frmKAEFl(id[0], auditTransactionId); }

        public override void CustomizeMenu()
        {

            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("KAElist !");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "KAElist.param";
                    paramEditor.ShowDialog();
                };
             
                ToolStripDropDownButton menuView3 = new ToolStripDropDownButton("Παράμετροι");
                menuView3.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem31 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView3 });
            }

        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.Category);
        }

        private void setFormsGlobals()
        {
            this.Name = "CallKAE";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            AADEFl aade = new AADEFl();
            aade.Read(auditTransactionId);
            this.Text = "ΚΑΕ στην Απόφαση με Αρ.Πρωτοκόλου:" + aade.Fields.auditProtocol;
        }
    }
}
