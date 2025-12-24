using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopBusiness.reportForms
{
    public partial class ReportErga : templates.Forms.def
    {

        string id;
        public ReportErga(string _id)
        {
            InitializeComponent();
            setFormsGlobals();
            id = _id;
            ReadPelath();
            ReadErgaPelath();
        }


        private void setFormsGlobals()
        {
            this.Name = "ReportErga";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
        }

        private void ReadPelath()
        {
            accountsClassLibrary.SynFl s = new accountsClassLibrary.SynFl();
            if (s.Read(id).Length == 0)
                this.Text = "Εργασίες στον Πελάτη : " + s.Fields.Name;
            else
            {
                this.Text = "Εργασίες στον Πελάτη : Προσοχή ΔΕΝ υπάρχει ο πελάτης αυτός !";
                menu.Items[0].Enabled = false;
            }
        }

        List<accountsClassLibrary.ItemErgFlModel> Erga;
        private void ReadErgaPelath()
        {
            Erga = new accountsClassLibrary.KErFl().ReadErgaPelath(id);
            listBox_Erga.Items.Clear();
            for (int i = 0; i < Erga.Count; i++)
                listBox_Erga.Items.Add(Erga[i].Description);
        }

        private void CustommersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new MForms.frmSynFl(id,accountsClassLibrary.SynFl.TypeOfSynFl.Customers);
            if (this.MdiParent==null)
            {
                childForm.ShowDialog();
            }
            else
            {
                childForm.MdiParent = this.MdiParent;
                childForm.Show();
            }
        }

        private void listBox_Erga_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDetail();
        }

        private void megaDetail_Erga_LoadData(object sender, EventArgs e)
        {
            loadDetail();
        }

        private void loadDetail()
        {
            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            cols.Add(new DataGridViewTextBoxColumn());

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DefaultCellStyle.Format = "dd/MM/yyyy";
            col0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cols.Add(col0);

            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());

            cols.Add(new DataGridViewTextBoxColumn());

            // Δηλώνω τα πεδία
            List<string> fields = new List<string>() { "id", "RegistryDate", "KoKiKErAitiKEr", "SalesPerson", "AitiKEr", "Summary" };
            List<string> fname = new List<string>() { "Visible=False", "ημερομηνία", "κίνηση", "χρήστης", "αιτιολογία", "" };

            // Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind
            string tmp = "^";
            try { tmp = Erga[listBox_Erga.SelectedIndex].id; }
            catch { tmp = "^"; }
            new alphaFrameWork.AlphaFramework().Bind(megaDetail_Erga.megaGridView,
                      new accountsClassLibrary.KErFl().ReadKiniseisAnaErgoAnaPelath(id, tmp),
                      cols, fields, fname);

            // Set Primary Field του Grid
            //this.megaDetail_Erga.PrimaryFields.Add("id");
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            ReadPelath();
            ReadErgaPelath();
            megaDetail_Erga.megaGridView.DataSource = new DataTable();
        }

        private void megaDetail_Erga_DeleteRecord(object sender, EventArgs e)
        {
            if (megaDetail_Erga.megaGridView.SelectedRows.Count > 0)
                if (MessageBox.Show("Πρόκειται να διαγράψετε " + megaDetail_Erga.megaGridView.SelectedRows.Count.ToString() + " εγγραφή/ές !", "Προσοχή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < this.megaDetail_Erga.megaGridView.SelectedRows.Count; i++)
                        new accountsClassLibrary.KErFl().Delete(megaDetail_Erga.megaGridView.SelectedRows[i].Cells[0].Value.ToString());

                    ReadErgaPelath();
                    megaDetail_Erga.RefreshData();
                }
        }

        private void megaDetail_Erga_NewRecord(object sender, EventArgs e)
        {
            string tmp = "";
            if (listBox_Erga.SelectedIndex >= 0) tmp = Erga[listBox_Erga.SelectedIndex].id;
            Form childForm = new MForms.frmKErFl("new", id, tmp);
            childForm.ShowDialog();
            ReadErgaPelath();
            megaDetail_Erga.RefreshData();
        }

        private void megaDetail_Erga_EditRecord(object sender, EventArgs e)
        {
            Form childForm = new MForms.frmKErFl(megaDetail_Erga.megaGridView.SelectedRows[0].Cells[0].Value.ToString());
            childForm.ShowDialog();
            ReadErgaPelath();
            megaDetail_Erga.RefreshData();
        }

       

        private void megaDetail_Erga_RefreshRecord(object sender, EventArgs e)
        {
            loadDetail();
        }
    }
}
