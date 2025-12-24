using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace DesktopBusiness.CallForms
{
    public partial class CallKinListFrm : templates.Forms.CallFrm
    {
        private KinFl.TypeOfKin MyType;        
        public CallKinListFrm(KinFl.TypeOfKin mytype)
        {            
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;            
            MyType = mytype;
            this.Text = new accountsClassLibrary.KinFl().ReadTitle(MyType);
            this.Name = "CallKinListFrm" + "_" + MyType.ToString();
            this.Width = this.Width + 150;
        }
        public CallKinListFrm()
        {            
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            MyType = KinFl.TypeOfKin.All;
            this.Name = "CallKinListFrm" + "_" + MyType.ToString();
            this.Width = this.Width + 150;
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

            for (int i = 0; i < 3; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.DefaultCellStyle.Format = "# ### ##0.00";
            col5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col5.DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            cols.Add(col5);

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col6);

            for (int i = 0; i < 2; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            string cash = "Μετρητά";
            if (MyType == KinFl.TypeOfKin.PaymentToCustomer || MyType == KinFl.TypeOfKin.PaymentToSuplier || MyType == KinFl.TypeOfKin.RecieveFromCustomer || MyType == KinFl.TypeOfKin.RecieveFromSuplier)
                cash = "Visible=False";
            List<string> fields = new List<string>() { "KoKiKin", "DescKoKi", "RegistryDate", "Seira", "id", "SynFlDescription", "AitiKin", "Summary", "Cash", "SynFlCategory", "SalesPerson" };
            List<string> fname = new List<string>() { "Visible=False", "Visible=False", "Ημερομηνία", "Σειρά", "Αρ.Παρασ.", "Συναλλασόμενος", "Αιτιολογία", "Ποσό", cash, "Visible=False", "Χρήστης" };

            // Μεταφορά ονόματος για παραμετροποίηση            
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ κινήσεις ανα τύπο            
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                                                     new accountsClassLibrary.KinFl(strFind).ReadZoom(MyType, "KinFl"),
                                                     cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("seira");
            s.Add("id");
            s.Add("KoKiKin");
            return (s);
        }       

        public override string Delete(List<string> id)
        { accountsClassLibrary.KinFl k = new KinFl();
          k.Fields.Seira = id[0];
          k.Fields.id = id[1];
          k.Fields.KoKiKin.id = id[2];
          return k.Delete(); }

        public override templates.Forms.def CallForm(List<string> id) {
            if (id.Count == 1 && id[0] == "new")
            {
                id[0] = "";
                id.Add("new");
                id.Add(new KinFl().readKoKi(MyType));
                return (new MForms.frmKinFl(id[0], id[1], id[2])); }
            else
                return (new MForms.frmKinFl(id[0], id[1], id[2]));
        }

        public override void CustomizeMenu()
        {
            // Ενέργειες
            ToolStripMenuItem ViewMenuItem02 = new ToolStripMenuItem("Δημιουργία εγγραφών");
            ViewMenuItem02.Click += (object sender, EventArgs e) =>
            {
                Form childForm2 = new iForms.copyKin();
                childForm2.MdiParent = this.MdiParent;
                childForm2.Show();
                this.Close();
            };

            // Παρουσιάσεις
            ToolStripMenuItem ViewMenuItem00 = new ToolStripMenuItem("Σύνολο επιλεγμένων εγγραφών");
            ViewMenuItem00.Click += (object sender, EventArgs e) =>
            {
                double s = 0;
                for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                { s += Convert.ToDouble(DataGrid.SelectedRows[i].Cells["Summary"].Value); }
                MessageBox.Show("Το σύνολο των επιλεγμένων εγγραφών είναι : " +
                                 DataGrid.SelectedRows.Count.ToString() +
                                 "\nΜε σύνολο αξίας : " + s.ToString(), "Επεξεργασία !");
            };

            ToolStripMenuItem ViewMenuItem01 = new ToolStripMenuItem("Αναφορά εγγραφών");
            ViewMenuItem01.Click += (object sender, EventArgs e) =>
            {

                System.Data.DataTable table = new DataTable("dt");               
                DataColumn column;
                DataRow row;

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "DescKoKi";                
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.DateTime");
                column.ColumnName = "RegistryDate";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "SynFlDescription";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "ArPaKin";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "AitiKin";
                table.Columns.Add(column);

                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Double");
                column.ColumnName = "Summary";
                table.Columns.Add(column);

                for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                {
                    row = table.NewRow();
                    row["DescKoKi"] = DataGrid.SelectedRows[i].Cells["DescKoKi"].Value.ToString();
                    row["RegistryDate"] = DataGrid.SelectedRows[i].Cells["RegistryDate"].Value;
                    row["SynFlDescription"] = DataGrid.SelectedRows[i].Cells["SynFlDescription"].Value.ToString();
                    row["ArPaKin"] = DataGrid.SelectedRows[i].Cells["Seira"].Value.ToString() + " " + DataGrid.SelectedRows[i].Cells["Id"].Value.ToString();
                    row["AitiKin"] = DataGrid.SelectedRows[i].Cells["AitiKin"].Value.ToString();
                    row["Summary"] = Convert.ToDouble(DataGrid.SelectedRows[i].Cells["Summary"].Value);
                    table.Rows.Add(row);
                }
                
                Form childForm = new iForms.frmReport(@"reports\rdlc\KinReport.rdlc", table, "");
                childForm.MdiParent = this.MdiParent;
                childForm.Show();
                this.Close();                
            };

            ToolStripDropDownButton menuView0 = new ToolStripDropDownButton("Παρουσιάσεις");
            menuView0.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem00, ViewMenuItem01 });

            ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ενέργειες");
            menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem02 });

            // Add to main menu
            menu.Items.AddRange(new ToolStripItem[] { menuView0, menuView2 });
        }
    
        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "RegistryDate";
            accountsClassLibrary.KinFl mc = new KinFl();
            searchBox.DataSource = mc.ReadZoomRegistryDate(mc.readKoKi(MyType));
        }

       
    }
}
