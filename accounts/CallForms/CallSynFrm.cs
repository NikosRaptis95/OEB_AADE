using accountsClassLibrary;
using DesktopBusiness.iForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopBusiness.CallForms
{
    public partial class CallSynFrm : templates.Forms.CallFrm
    {

        private SynFl.TypeOfSynFl MyType;
        private string idErg = "";

        public CallSynFrm()
        {
            MyType = SynFl.TypeOfSynFl.All;
            setFormsGlobals();           
        }

        public CallSynFrm(string _idErg)
        {
            MyType = SynFl.TypeOfSynFl.Customers;
            idErg = _idErg;
            setFormsGlobals();
        }

        public CallSynFrm(SynFl.TypeOfSynFl mytype)
        {
            MyType = mytype;
            setFormsGlobals();           
        }


        public CallSynFrm(SynFl.TypeOfSynFl mytype, Boolean Modal)
        {       
            MyType = mytype;
            myModal = Modal;
            setFormsGlobals();                                  
        }

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid            
            List<Object> cols = new List<Object>();
            for (int i = 0; i <= 12; i++) { cols.Add(new DataGridViewTextBoxColumn()); }
            List<string> fields = new List<string>() { "AA", "id", "name", "CategoryDescription", "Address", "PhoneNo", "OccupationDescription", "PriceListDescription", "AFM", "DOY", "Line", "eMail", "WebSite", "Memo" };
            List<string> fname = new List<string>() { "Visible=False", "κωδικός", "όνομα ή επωνυμία", "κατηγορία", "διεύθυνση", "τηλέφωνο", "επάγγελμα", "τιμοκατάλογος", "ΑΦΜ", "ΔΟΥ", "σειρά", "eMail", "web site (Facebook)", "παρατηρήσεις" };
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();            

            // Μεταφορα ονόματος στις παραμέτρους
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ πε_άτες η προμηθευτές ή πελάτες - προμηθευτές ή όλους   
            if(idErg.Trim().Length==0)
                new alphaFrameWork.AlphaFramework().Bind(this.DataGrid, 
                                                   new SynFl(strFind).ReadZoom(SynFl.TypeOfReadZoom.ReadZoom, MyType,"",true,this.Name), 
                                                   cols, fields, fname);
            else
                new alphaFrameWork.AlphaFramework().Bind(this.DataGrid,
                                                   new SynFl(strFind).ReadZoomKErFl(idErg),
                                                   cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        public override string Delete(List<string> id) { return (new accountsClassLibrary.SynFl().Delete(id[0])); }

        public override templates.Forms.def CallForm(List<string> id) { return (new DesktopBusiness.MForms.frmSynFl(id[0], MyType)); }

        public override void CustomizeMenu()
        {
            
            // Παρουσιάσεις
            ToolStripMenuItem ViewMenuItem00 = new ToolStripMenuItem("Καρτέλλα");
            ViewMenuItem00.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(new alphaFrameWork.AlphaFramework().getStr(this.DataGrid), "Καρτέλλα ?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                    {                        
                        Form childForm = new CallKinKartFrm(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                        childForm.MdiParent = this.ParentForm;
                        childForm.Show();
                    }
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Η επεξεργασία ακυρώθηκε !", "Επεξεργασία !");
                }
            };           

            ToolStripMenuItem ViewMenuItem01 = new ToolStripMenuItem("Κινήσεις ανα μήνα");
            ViewMenuItem01.Click += (object sender, EventArgs e) =>
            {
                List<String> mySyn = new List<String>();
                List<String> myDescSyn = new List<String>();
                for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                {
                    mySyn.Add(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                    myDescSyn.Add(DataGrid.SelectedRows[i].Cells["Name"].Value.ToString());
                }
                Form myf = new reportForms.ksynRepFrm(mySyn, myDescSyn);
                myf.MdiParent = this.ParentForm;
                myf.Show();
            };

            ToolStripMenuItem ViewMenuItem02 = new ToolStripMenuItem("Εργασίες");
            ViewMenuItem02.Click += (object sender, EventArgs e) =>
            {
                if (MessageBox.Show(new alphaFrameWork.AlphaFramework().getStr(this.DataGrid), "Εργασίες ?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                    {
                        reportForms.ReportErga childForm = new reportForms.ReportErga(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                        childForm.MdiParent = this.ParentForm;
                        childForm.Show();
                    }
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("Η επεξεργασία ακυρώθηκε !", "Επεξεργασία !");
                }
            };

            ToolStripDropDownButton menuView0 = new ToolStripDropDownButton("Παρουσιάσεις");
            menuView0.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem02,
                                                                   ViewMenuItem00,
                                                                   ViewMenuItem01 });

            // Κινήσεις
            ToolStripMenuItem ViewMenuItem10 = new ToolStripMenuItem("Δημιουργία παραστατικών");
            ViewMenuItem10.Enabled = false;
            ViewMenuItem10.Click += (object sender, EventArgs e) =>
            {
               
            };

            ToolStripMenuItem ViewMenuItem11 = new ToolStripMenuItem("Δημιουργία κινήσεων");
            ViewMenuItem11.Enabled = false;
            ViewMenuItem11.Click += (object sender, EventArgs e) =>
            {
            };

            ToolStripDropDownButton menuView1 = new ToolStripDropDownButton("Κινήσεις");
            menuView1.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem10,
                                                                   ViewMenuItem11 });

            // Ενέργειες
            ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem("Αποστολή eMails");            
            ViewMenuItem20.Visible = false;
            ViewMenuItem20.Click += (object sender, EventArgs e) =>
            {

            };

            ToolStripMenuItem ViewMenuItem21 = new ToolStripMenuItem("Συναλλασόμενοι στον χάρτη");
            ViewMenuItem21.Click += (object sender, EventArgs e) =>
            {
                List<string> ids = new List<string>();
                List<string> descs = new List<string>();
                List<string> addrs = new List<string>();

                for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
                {
                    ids.Add(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                    descs.Add(DataGrid.SelectedRows[i].Cells["Name"].Value.ToString());
                    addrs.Add(DataGrid.SelectedRows[i].Cells["Address"].Value.ToString());
                }

                Form f = new frmMap(ids, descs, addrs);
                f.MdiParent = this.ParentForm;
                f.Text = this.searchBox.Text;
                f.Show();
            };

            ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ενέργειες");
            menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20,
                                                                   ViewMenuItem21 });

            // Add to main menu
            //menu.Items.AddRange(new ToolStripItem[] { menuView2, menuView1, menuView0 });
            menu.Items.AddRange(new ToolStripItem[] { menuView2, menuView0 });
        }

        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.Category);
        }

        private void setFormsGlobals()
        {
            this.Name = "CallSynFrm_" + MyType.ToString();
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;   
            if(idErg.Trim().Length==0)
                this.Text = new accountsClassLibrary.SynFl().ReadTitle(MyType);
            else
            {
                ErgFl e = new ErgFl("%");
                e.Read(idErg);
                this.Text = e.Fields.Description+" - "+ new accountsClassLibrary.SynFl().ReadTitle(MyType);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Size = new System.Drawing.Size(881, 456);
            // 
            // CallSynFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(895, 539);
            this.Name = "CallSynFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
