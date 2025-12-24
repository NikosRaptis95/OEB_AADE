using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopBusiness.CallForms
{
    public partial class CallMtlFrm : templates.Forms.CallFrm
    {
        string formname;
        public CallMtlFrm(string formname_ = "frmMtlFl")
        {
            formname = formname_;
            this.Name = "CallMtlFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Text = "Ευρετήριο Προιόντων";
        }

        public override List<string> GetData(string strFind)
        {                              

            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i <= 5; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            List<string> fields = new List<string>() { "AA", "id", "description", "BCode", "FamilyDescription", "Memo" };
            List<string> fname = new List<string>() { "AA", "κωδικός", "περιγραφή", "bar code", "Οικογένεια", "παρατηρήσεις" };

            // Τίτλος στο παράθυρο, Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind                        
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                      new accountsClassLibrary.MtlFl(strFind).ReadZoom(accountsClassLibrary.MtlFl.TypeOfZoom.DefaultZoom,"","","","",this.Name),
                      cols, fields, fname);
          
            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id) {
            return (new accountsClassLibrary.MtlFl().Delete(id[0]));
        }


        public override templates.Forms.def CallForm(List<string> id)
        {
            if (formname.Equals("frmMtlFl"))
            {
                return (new DesktopBusiness.MForms.frmMtlFl(id[0]));
            }
            else
                return (new DesktopBusiness.MForms.qsynt(id[0]));
        }


        public override void CustomizeMenu()
        {
            //menu_public = menu;
            //newMenuItem.Visible = false;
            //toolStripMenuItem1.Visible = false;
            //deleteMenuItem.Visible = false;

            // Παρουσιάσεις
            ToolStripMenuItem ViewMenuItem00 = new ToolStripMenuItem("Δημιουργία τιμών");
            ViewMenuItem00.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(new alphaFrameWork.AlphaFramework().getStr(this.DataGrid), "Δημιουργία τιμών ?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                        MtlFl m = new MtlFl();
                        for (int i = 0; i < DataGrid.SelectedRows.Count; i++) { m.ComputePrices(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString()); }
                }
                else
                {
                    MessageBox.Show("Η δημιουργία τιμών ακυρώθηκε !", "Δημιουργία τιμών !");
                }
                MessageBox.Show("Η δημιουργία τιμών ολοκληρώθηκε !", "Δημιουργία τιμών !");
            };

            ToolStripDropDownButton menuView0 = new ToolStripDropDownButton("Επεξεργασία");
            menuView0.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem00 });

            menu.Items.AddRange(new ToolStripItem[] { menuView0 });
        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.CategoryMtl);
        }

        
    }
}
