using System;
using System.Collections.Generic;
using System.Windows.Forms;
using accountsClassLibrary;

namespace DesktopBusiness.CallForms
{
    public partial class CallPinFrm : templates.Forms.CallFrm
    {
        private accountsClassLibrary.FilPin.TypeOfPin MyType;
        public CallPinFrm(FilPin.TypeOfPin mytype)
        {
            this.Name = "CallPinFrm";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            MyType = mytype;
            this.Text = new accountsClassLibrary.FilPin().ReadTitle(MyType);
        }      

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i < 2; i++) { cols.Add(new DataGridViewTextBoxColumn()); }            

            List<string> fields = new List<string>() { "id", "name", "Picture", "flag0", "status" };
            List<string> fname = new List<string>() { "κωδικός", "περιγραφή", "εικόνα", "flag0", "status" };
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
            fname = mc.customizationforGrid(fname, this.Name);

            // Καλώ τον πίνακα και κάνω bind
            accountsClassLibrary.FilPin AC = new accountsClassLibrary.FilPin(strFind);
            new alphaFrameWork.AlphaFramework().Bind(DataGrid, AC.ReadZoom(MyType), cols, fields, fname);
            
            // Τίτλος στο παράθυρο            
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name + "_" + MyType.ToString());

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id) { return (new accountsClassLibrary.FilPin().Delete(id[0])); }

        public override templates.Forms.def CallForm(List<string> id) { return (new DesktopBusiness.MForms.frmFilPin(MyType, id[0])); }

        public override void CustomizeMenu()
        {
            if(MyType==FilPin.TypeOfPin.ErgaType || MyType == FilPin.TypeOfPin.KoKiErga)
            {
                
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Συσχετισμός Κωδικών Κινήσεων με Κατηγορίες Υπηρεσιών");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                {
                    reportForms.CategoryKoKiFrm childForm = new reportForms.CategoryKoKiFrm();
                    childForm.ShowDialog();
                };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }
            
        }

      
        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
          
        }

    }

   
}
