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
    public partial class frmErgRel : templates.Forms.frmMaster
    {

        string id;
        string category;
        public frmErgRel(string _id, string _category)
        {
            InitializeComponent();
            id = _id;
            category = _category;
            setFormsGlobals();
        }


        ErgRel dataclass = new ErgRel();
        public override void LoadData()
        {
            if (id.ToUpper().Equals("NEW"))
            {
                this.refreshToolStripMenuItem.Enabled = false;
                //new alphaFrameWork.AlphaFramework().setSI_Combos(this.megaCombo_KoKi.megaComboBox, idErgo);
                /* primary key enable = false για το edit */
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα         
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                     /* primary key enable = false για το edit */
                }
            }
        }
        public override void UpdateBtn()
        {
            object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
            foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));
            string res = "";
            if (id.Equals("new"))
            {
                dataclass.Fields.Category.id = category;
                res = dataclass.Insert(); // νεα εγγραφή
            }
            else
            {
                //dataclass.Fields.Category.id = category;
                //dataclass.Fields.Id = id;
                res = dataclass.Update();  // σώζω 
            }
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
        }

        public override void LoadDefaults()
        {
            // Όρίζω τιμές στα αντικείμενα της φόρμας κατα το form load
            megaCombo_KoKi.DataSource = new FilPin("%").ReadZoom(FilPin.TypeOfPin.KoKiErga);
        }

        public override void CustomizeMenu()
        {

            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Κωδικοί κίνησης");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.KoKiErga, megaCombo_KoKi.megaComboBox); };

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
            this.Name = "frmErgRel";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin("%");
            f.Read(category);
            if (id.ToUpper().Equals("NEW"))
                this.Text = f.Fields.Name + " - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου            
            else
                this.Text = f.Fields.Name; //΄Ορίζω τον τίτλο του παραθύρου
        }

    }
}
