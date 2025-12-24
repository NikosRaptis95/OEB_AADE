using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopBusiness.CallForms
{
    public partial class CallErgFrm : templates.Forms.CallFrm
    {
        public CallErgFrm()
        {
            InitializeComponent();

            this.Name = "CallErgFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Text = "Ευρετήριο Υπηρεσιών";
        }

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i < 3; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DefaultCellStyle.Format = "dd/MM/yyyy";
            col0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col0);

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DefaultCellStyle.Format = "dd/MM/yyyy";
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col1);

            cols.Add(new DataGridViewTextBoxColumn());

            List<string> fields = new List<string>() { "AA", "id", "description", "StartDate", "EndDate", "idPinDescription" };
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "περιγραφή", "εκκινηση", "τέλος", "κατηγορία" };

            // Τίτλος στο παράθυρο, Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind                        
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                      new accountsClassLibrary.ErgFl(strFind).ReadZoom(this.Name),
                      cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id) { return (new accountsClassLibrary.ErgFl().Delete(id[0])); }

        public override templates.Forms.def CallForm(List<string> id) { return (new DesktopBusiness.MForms.frmErgFl(id[0])); }

        public override void CustomizeMenu()
        {
            ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Κατηγορίες");
            ViewMenuItem30.Click += (object sender, EventArgs e) =>
            {
                CallPinFrm childForm = new CallPinFrm(accountsClassLibrary.FilPin.TypeOfPin.ErgaType);
                childForm.ShowDialog();
            };

            ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
            menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30 });

            menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.CategoryMtl);
        }


    }
}
