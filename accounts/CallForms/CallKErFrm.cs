using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopBusiness.CallForms
{
    public partial class CallKErFrm : templates.Forms.CallFrm
    {
        public CallKErFrm()
        {
            InitializeComponent();
            this.Name = "CallKErFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Text = "Ευρετήριο Εργασιών";
        }

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DefaultCellStyle.Format = "dd/MM/yyyy";
            col0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col0);
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());

            List<string> fields = new List<string>() { "AA", "Ergo", "idSynName", "RegistryDate", "KoKiKErAitiKEr", "SalesPerson", "AitiKEr", "Summary","id" };
            List<string> fname = new List<string>() { "Visible=False", "υπηρεσία", "συναλλασόμενος", "ημερομηνία", "κίνηση", "χρήστης", "αιτιολογία", "", "Visible=False" };

            // Τίτλος στο παράθυρο, Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind                        
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                      new accountsClassLibrary.KErFl(strFind).ReadZoom(this.Name),
                      cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id) { return (new accountsClassLibrary.KErFl().Delete(id[0])); }

        public override templates.Forms.def CallForm(List<string> id) { return (new DesktopBusiness.MForms.frmKErFl(id[0])); }

        public override void CustomizeMenu()
        {
            ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Κωδικοί Κίνησης");
            ViewMenuItem30.Click += (object sender, EventArgs e) =>
            {
                CallPinFrm childForm = new CallPinFrm(accountsClassLibrary.FilPin.TypeOfPin.KoKiErga);
                childForm.ShowDialog();
            };

            ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("Υπηρεσίες");
            ViewMenuItem31.Click += (object sender, EventArgs e) =>
            {
                CallErgFrm childForm = new CallErgFrm();
                childForm.ShowDialog();
            };

            ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
            menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30, ViewMenuItem31 });

            menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.KoKiErga);
        }



    }
}
