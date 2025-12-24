using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmKErFl : templates.Forms.frmMaster
    {
        private string id;
        private string idSyn;
        private string idErgo;
        public frmKErFl(string id_, string _idSyn="", string _idErgo="")
        {
            InitializeComponent();
            megaTrackBar_Summary.mega_trackBar.Maximum = 100;
            id = id_;
            idSyn = _idSyn;
            idErgo = _idErgo;
            setFormsGlobals();              
        }

        SynFl s = new SynFl();
        private void megaFind_idSyn_megaTextBox_textChanged(object sender, EventArgs e)
        {
            s.Read(megaFind_idSyn.megaTextBox.Text);  // Read την επαφή
            megaFind_idSyn.megaDisplay.Text = s.Fields.Name; // όνομα στο megaDisplay
        }

        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {
            // Όρίζω τιμές στα αντικείμενα της φόρμας κατα το form load
            megaCombo_KoKiEr.DataSource = new FilPin("%").ReadZoom(FilPin.TypeOfPin.KoKiErga);
            //LoadKoKi();

            megaCombo_idErg.DataSource = new ErgFl("%").ReadZoom();
            ParPin par = new ParPin();
            megaCombo_Status.DataSource = par.ReadZoom(ParPin.TypeOfPar.Status);

            megaFind_idSyn.CallForm = new CallForms.CallSynFrm(SynFl.TypeOfSynFl.Customers, true);
        }

        private void LoadKoKi(string idergo)
        {
            ErgFl e = new ErgFl("%");
            if(e.Read(idergo).Trim().Length<1)
                        megaCombo_KoKiEr.DataSource = new ErgRel("%").ReadZoomKoKi(e.Fields.idPin.id);
           
            //megaCombo_KoKiEr.DataSource = new FilPin("%").ReadZoom(FilPin.TypeOfPin.KoKiErga);
        }

        KErFl dataclass = new KErFl();
        public override void LoadData()
        {
            if (id.ToUpper().Equals("NEW"))
            {                
                 new alphaFrameWork.AlphaFramework().setSI_Combos(this.megaCombo_idErg.megaComboBox, idErgo);
                 megaFind_idSyn.megaTextBox.Text = idSyn;
                 megaDate_RegistryDate.megaDateBox.Value = DateTime.Now;
                LoadKoKi(idErgo);
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                LoadKoKi(dataclass.Fields.idErg.id);
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    //this.Text = dataclass.ReadTitle(MyType) + " - " + dataclass.Fields.Name; //΄Ορίζω τον τίτλο του παραθύρου
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                    //megaText_id.Enabled = false; /* primary key enable = false για το edit */
                }
            }
        }
        public override void UpdateBtn()
        {
            megaText_SalesPerson.megaTextBox.Text = Program.global.username;
            object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
            foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));
            string res = "";
            if (id.Equals("new")) res = dataclass.Insert(); // νεα εγγραφή
            else res = dataclass.Update();  // σώζω 
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
        }
        public override void CustomizeMenu()
        {

            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Κωδικοί κίνησης");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.KoKiErga, megaCombo_KoKiEr.megaComboBox); };

                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("Υπηρεσίες");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                { CallfrmYphresies(megaCombo_idErg.megaComboBox); };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30, ViewMenuItem31 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }

        }

        private void CallfrmYphresies(ComboBox MyCombo)
        {
            string oldValue = "";
            if (MyCombo.Items.Count > 0) oldValue = MyCombo.SelectedValue.ToString();
            CallForms.CallErgFrm childForm = new CallForms.CallErgFrm();
            childForm.ShowDialog();
            MyCombo.DataSource = new ErgFl("%").ReadZoom();
            new alphaFrameWork.AlphaFramework().setSI_Combos(MyCombo, oldValue);
        }


        private void CallfrmPinFl(FilPin.TypeOfPin MyType, ComboBox MyCombo)
        {
            string oldValue = "";
            if (MyCombo.Items.Count > 0) oldValue = MyCombo.SelectedValue.ToString();
            CallForms.CallPinFrm childForm = new CallForms.CallPinFrm(MyType);
            childForm.ShowDialog();
            MyCombo.DataSource = new FilPin("%").ReadZoom(MyType);
            new alphaFrameWork.AlphaFramework().setSI_Combos(MyCombo, oldValue);
        }
        private void setFormsGlobals()
        {
            this.Name = "frmKErFl";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
                this.Text = "Εργασίες - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου            
            else
                this.Text = "Εργασίες"; //΄Ορίζω τον τίτλο του παραθύρου
        }



        //S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        //class S
        //{
        //    private string lang = "gr";
        //    public S(string _lang) { lang = _lang; }

        //    public string G(int id)
        //    {
        //        switch (lang)
        //        {
        //            case "gr":
        //                switch (id)
        //                {
        //                    case 1: return "Πελάτης";
        //                    case 2: return "Πελάτες";
        //                    case 3: return "΄Πελατών";
        //                    case 4: return "Προμηθευτής";
        //                    case 5: return "Προμηθευτές";
        //                    case 6: return "Προμηθευτών";
        //                    default: return "Δεν βρέθηκε η συμβολοσειρά";
        //                }
        //            default:
        //                switch (id)
        //                {
        //                    case 1: return "Customer";
        //                    case 2: return "Customers";
        //                    case 3: return "Customers";
        //                    case 4: return "Supplier";
        //                    case 5: return "Suppliers";
        //                    case 6: return "Suppliers";
        //                    default: return "String not found";
        //                }
        //        }
        //    }

        //}
        #endregion

        private void megaCombo_idErg_megaComboBox_selectedIndexChanged(object sender, EventArgs e)
        {
            //LoadKoKi(megaCombo_idErg.megaComboBox.ValueMember[megaCombo_idErg.megaComboBox.SelectedIndex].ToString());
            LoadKoKi(megaCombo_idErg.megaComboBox.SelectedValue.ToString());
        }
    }
}
