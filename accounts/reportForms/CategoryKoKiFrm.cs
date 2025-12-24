using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopBusiness.reportForms
{
    public partial class CategoryKoKiFrm : templates.Forms.def
    {
        public CategoryKoKiFrm()
        {
            InitializeComponent();
            setFormsGlobals();
            ReadCategories();
        }

        private void setFormsGlobals()
        {
            this.Name = "CategoryKoKiFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Text = "Συσχετισμός Κωδικών Κινήσεων με Κατηγορίες Υπηρεσιών.";
        }

        List<string> Categories;
        private void ReadCategories()
        {
            DataTable dt = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.ErgaType);
            listBox_Category.Items.Clear();
            Categories = new List<string>();
            for (int i=0; i<dt.Rows.Count; i++)
            {
                Categories.Add(dt.Rows[i]["id"].ToString());
                listBox_Category.Items.Add(dt.Rows[i]["Name"].ToString());
            }
        }

        private void CategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallForms.CallPinFrm childForm = new CallForms.CallPinFrm(accountsClassLibrary.FilPin.TypeOfPin.ErgaType);
            if (this.MdiParent == null)
            {
                childForm.ShowDialog();
            }
            else
            {
                childForm.MdiParent = this.MdiParent;
                childForm.Show();
            }
        }

        private void KoKiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallForms.CallPinFrm childForm = new CallForms.CallPinFrm(accountsClassLibrary.FilPin.TypeOfPin.KoKiErga);
            if (this.MdiParent == null)
            {
                childForm.ShowDialog();
            }
            else
            {
                childForm.MdiParent = this.MdiParent;
                childForm.Show();
            }
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            ReadCategories();
            megaDetail_KoKi.megaGridView.DataSource = new DataTable();
        }

        private void listBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            megaDetail_KoKi.megaGridView.DataSource = new DataTable();
            megaDetail_KoKi.RefreshData();
        }
        
        #region Detail Events

        private void megaDetail_KoKi_LoadData(object sender, EventArgs e)
        {
            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());
            cols.Add(new DataGridViewTextBoxColumn());

            // Δηλώνω τα πεδία
            List<string> fields = new List<string>() { "id", "Seira", "KoKiDesc" };
            List<string> fname = new List<string>() { "Visible=False", "Σειρά", "Κωδικός Κίνησης" };

            // Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind
            string CategoryId = "^";
            try { CategoryId = Categories[listBox_Category.SelectedIndex]; }
            catch { CategoryId = "^"; }
            new alphaFrameWork.AlphaFramework().Bind(megaDetail_KoKi.megaGridView,
                      new accountsClassLibrary.ErgRel().ReadZoom(CategoryId),
                      cols, fields, fname);

            // Set Primary Field του Grid
            this.megaDetail_KoKi.PrimaryFields.Add("id");
        }

        private void megaDetail_KoKi_DeleteRecord(object sender, EventArgs e)
        {
            if (megaDetail_KoKi.megaGridView.SelectedRows.Count > 0)
                if (MessageBox.Show("Πρόκειται να διαγράψετε " + megaDetail_KoKi.megaGridView.SelectedRows.Count.ToString() + " εγγραφή/ές !", "Προσοχή", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < this.megaDetail_KoKi.megaGridView.SelectedRows.Count; i++)
                        new accountsClassLibrary.ErgRel().Delete(megaDetail_KoKi.megaGridView.SelectedRows[i].Cells[0].Value.ToString());
                    megaDetail_KoKi.RefreshData();
                }
        }

        private void megaDetail_KoKi_EditRecord(object sender, EventArgs e)
        {
            MForms.frmErgRel childForm = new MForms.frmErgRel(megaDetail_KoKi.megaGridView.SelectedRows[0].Cells[0].Value.ToString(), "");
            childForm.ShowDialog();
            megaDetail_KoKi.RefreshData();
        }

        private void megaDetail_KoKi_NewRecord(object sender, EventArgs e)
        {
            string tmp = "";
            if (listBox_Category.SelectedIndex >= 0) tmp = Categories[listBox_Category.SelectedIndex];
            MForms.frmErgRel childForm = new MForms.frmErgRel("new", tmp);
            childForm.ShowDialog();
            megaDetail_KoKi.RefreshData();
        }

        #endregion

        private void listBox_Category_MouseMove(object sender, MouseEventArgs e)
        {
            var tmp = "";
            tmp += "";
        }

        
        private void menu_Click(object sender, EventArgs e)
        {
            var tmp = "";
            tmp += "";
        }
        private void listBox_Category_Click(object sender, EventArgs e)
        {
            string tmp = "";
            tmp += "";
            megaDetail_KoKi.megaGridView.DataSource = new DataTable();
            megaDetail_KoKi.RefreshData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmp = "";
            tmp += "";
        }
    }
}
