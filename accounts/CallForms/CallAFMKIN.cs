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
    public partial class CallAFMΚΙΝ : templates.Forms.CallFrm
    {
        public CallAFMΚΙΝ()
        {
            InitializeComponent();
            setFormsGlobals();
        }
        public CallAFMΚΙΝ(string _AFMId)
        {
            InitializeComponent();
            AFMId = _AFMId;
            setFormsGlobals();
        }
        public string AFMId;

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid            
            List<Object> cols = new List<Object>();
            for (int i = 0; i <= 2; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DefaultCellStyle.Format = "dd/MM/yyyy";
            col0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col0);
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DefaultCellStyle.Format = "# ### ##0.00";
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col1.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            cols.Add(col1);
            List<string> fields = new List<string>() { "AA", "id",  "KAE", "dueDate", "ammount" };
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "ΚΑΕ", "Ημερομηνία", "Ποσό" };
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();

            // Μεταφορα ονόματος στις παραμέτρους
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τις εγγραφές
            new alphaFrameWork.AlphaFramework().Bind(this.DataGrid,
                                                   new AFMKIN().ReadZoom(AFMId),
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
            return new accountsClassLibrary.AFMKIN().Delete(id[0]);
        }

        public override templates.Forms.def CallForm(List<string> id) { return new DesktopBusiness.MForms.frmAFMKIN(id[0], AFMId); }

        public override void CustomizeMenu()
        {
            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("TABLE !");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                {
                    ParamEditor paramEditor = new ParamEditor();
                    paramEditor.filename = "TABLE.param";
                    paramEditor.ShowDialog();
                };

                ToolStripDropDownButton menuView3 = new ToolStripDropDownButton("Παράμετροι");
                menuView3.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem31 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView3 });
            }

        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            
        }

        private void setFormsGlobals()
        {
            this.Name = "CallAFMΚΙΝ";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            AFMFl afm = new AFMFl();
            afm.Read(AFMId);
            this.Text = "ΑΦΜ:"+afm.Fields.AFM+ "/Αρ.Πρ.:"+afm.Fields.auditRecord.auditProtocol;

        }
    }
}

