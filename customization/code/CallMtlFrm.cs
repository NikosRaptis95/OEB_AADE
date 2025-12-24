using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DesktopBusiness;
using accountsClassLibrary;
using alphaFrameWork;

public class MegaSoftClass
{
   
    public void main(DesktopBusiness.CallForms.CallMtlFrm This)
    {                     
       CustomizeMenu(This.MdiParent, This.menu);
    }
    
    public void CustomizeMenu(Form MyParnet, System.Windows.Forms.StatusStrip menu)
    {
        ToolStripMenuItem ViewMenuItem0 = new ToolStripMenuItem("Κάλεσε νέα φόρμα !");
        ViewMenuItem0.Click += (object sender, EventArgs e) =>
        {
            Form childForm = new CallMe();           
            childForm.MdiParent = MyParnet;
            childForm.Show();            
        };

        ToolStripDropDownButton menuView = new ToolStripDropDownButton("Επιλογή απο τον κώδικα !");
        menuView.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem0 });

        // Add to main menu      
        menu.Items.AddRange(new ToolStripItem[] { menuView });        

    }


    public class CallMe : DesktopBusiness.templates.CallFrm
    {
        public CallMe() { this.Name = "CallMe"; }

        public override string GetData(string strFind)
        {            
            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i < 5; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            List<string> fields = new List<string>() { "AA", "id", "description", "BCode", "CategoryDescription", "Memo" };
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "περιγραφή", "bar code", "κατηγορία", "παρατηρήσεις" };

            // Τίτλος στο παράθυρο, Customization Grid
            this.Text = "Ευρετήριο Προιόντων";
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind                        
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                      new accountsClassLibrary.MtlFl(strFind).ReadZoom(accountsClassLibrary.MtlFl.TypeOfZoom.DefaultZoom),
                      cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            return ("id");
        }

        public override string Delete(string id) { return (new accountsClassLibrary.MtlFl().Delete(id)); }

        public override Form CallForm(string id) { return (new DesktopBusiness.MForms.frmMtlFl()); }

        public override void CustomizeMenu()
        {

            // Παρουσιάσεις
            ToolStripMenuItem ViewMenuItem0 = new ToolStripMenuItem("Κατάλογος ειδών");
            ViewMenuItem0.Click += (object sender, EventArgs e) =>
            {
                Form myf = new DesktopBusiness.CallForms.CallMtlFrm();
                myf.ShowDialog();
            };

            ToolStripSeparator ViewSeperator0 = new ToolStripSeparator();

            ToolStripMenuItem ViewMenuItem1 = new ToolStripMenuItem("Καρτέλλα είδους");
            ViewMenuItem1.Click += (object sender, EventArgs e) =>
            {
                callform(new DesktopBusiness.reportForms.genView());
            };

            ToolStripMenuItem ViewMenuItem2 = new ToolStripMenuItem("Επιλογή new class");
            ViewMenuItem2.Click += (object sender, EventArgs e) =>
            {

            };

            ToolStripDropDownButton menuView = new ToolStripDropDownButton("Παρουσιάσεις");
            menuView.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem0,
                                                                  ViewSeperator0,
                                                                  ViewMenuItem1,
                                                                  ViewMenuItem2 });


            // Add to main menu
            menu.Items.AddRange(new ToolStripItem[] { menuView });
        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.CategoryMtl);
        }
    }

}