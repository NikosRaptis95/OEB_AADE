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
    public partial class frmErgFl : templates.Forms.frmMaster
    {

        private string id;
        public frmErgFl(string id_)
        {
            InitializeComponent();
            id = id_;
            setFormsGlobals();
        }

        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {
            // Όρίζω τιμές στα αντικείμενα της φόρμας κατα το form load
            FilPin pin = new FilPin("%");
            megaCombo_idPin.DataSource = pin.ReadZoom(FilPin.TypeOfPin.ErgaType);
            ParPin par = new ParPin();
            megaCombo_Status.DataSource = par.ReadZoom(ParPin.TypeOfPar.Status);
        }

        ErgFl dataclass = new ErgFl();
        public override void LoadData()
        {
            if (id.ToUpper().Equals("NEW"))
            {
                //this.Text = dataclass.ReadTitle(MyType) + " - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου 
                this.megaText_id.megaTextBox.Text = new ErgFl().newCode();
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    //this.Text = dataclass.ReadTitle(MyType) + " - " + dataclass.Fields.Name; //΄Ορίζω τον τίτλο του παραθύρου
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                    megaText_id.Enabled = false; /* primary key enable = false για το edit */
                }
            }
        }
        public override void UpdateBtn()
        {
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
            // Παρουσιάσεις           
            {

                ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem("Συμμετέχοντες στην Υπηρεσία !");
                ViewMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    CallForms.CallSynFrm childForm = new CallForms.CallSynFrm(id);
                    childForm.MdiParent = this.ParentForm;
                    childForm.Show();
                };

                
                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Παρουσιάσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }


            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Κατηγορίες");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.ErgaType, megaCombo_idPin.megaComboBox); };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }

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
            this.Name = "frmErgFl";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
            {
                this.Text = "Υπηρεσίες - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου                            
            }
            else
                this.Text = "Υπηρεσίες"; //΄Ορίζω τον τίτλο του παραθύρου
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


    }
}
