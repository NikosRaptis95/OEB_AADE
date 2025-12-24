using accountsClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmSynFl : templates.Forms.frmMaster
    {
        public frmSynFl()
        {
            InitializeComponent();
            setFormsGlobals();
        }

        private string id;
        private SynFl.TypeOfSynFl MyType;
        public frmSynFl(string id_, SynFl.TypeOfSynFl mytype)
        {
            InitializeComponent();            
            id = id_;
            MyType= mytype;
            setFormsGlobals();
        }


        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {
            // Όρίζω τιμές στα αντικείμενα της φόρμας κατα το form load
            FilPin pin = new FilPin("%");
            megaCombo_Category.DataSource = pin.ReadZoom(FilPin.TypeOfPin.Category);
            megaCombo_Occupation.DataSource = pin.ReadZoom(FilPin.TypeOfPin.Occupation);
            megaCombo_PriceList.DataSource = pin.ReadZoom(FilPin.TypeOfPin.PriceList);
            ParPin par = new ParPin();
            megaCombo_KindOfTax.DataSource = par.ReadZoom(ParPin.TypeOfPar.KindOfTax);
            megaCombo_Kind.DataSource = par.ReadZoom(ParPin.TypeOfPar.Kind);
            megaCombo_Status.DataSource = par.ReadZoom(ParPin.TypeOfPar.Status);
        }

        SynFl dataclass = new SynFl();
        public override void LoadData()
        {
            if (id.ToUpper().Equals("NEW"))
            {
                switch (MyType)
                {
                    case SynFl.TypeOfSynFl.Supliers:
                        megaCombo_Kind.megaComboBox.SelectedIndex = 1;
                        break;
                    case SynFl.TypeOfSynFl.CustomersSupliers:
                        megaCombo_Kind.megaComboBox.SelectedIndex = 2;
                        break;
                    default:
                        megaCombo_Kind.megaComboBox.SelectedIndex = 0;
                        break;
                }
                megaText_id.megaTextBox.Text = new accountsClassLibrary.SynFl().newId();
                //this.Text = dataclass.ReadTitle(MyType) + " - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου
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
            

            // Ενέργειες            
            {
                ToolStripMenuItem ViewMenuItem00 = new ToolStripMenuItem("Παρουσίαση του web site");
                ViewMenuItem00.Click += (object sender, EventArgs e) =>
                {
                    int err = 0; string m = "";
                    if (megaText_WebSite.Text_Textbox.Length == 0) { m = "Δεν έχετε γράψει διέυθυνση site για να καλέσω !\n"; err = -1; }
                    if (err == 0) System.Diagnostics.Process.Start(megaText_WebSite.Text_Textbox);
                    else MessageBox.Show(m, "Παρουσίαση Web Site !");
                };

                ToolStripMenuItem ViewMenuItem01 = new ToolStripMenuItem("Αποστολή eMail");
                ViewMenuItem01.Click += (object sender, EventArgs e) =>
                {
                    alphaFrameWork.AlphaFramework a = new alphaFrameWork.AlphaFramework();
                    bhtaFramework.bhtaFramework b = new bhtaFramework.bhtaFramework();
                    FilPin c = new FilPin();
                    c.Read("xr007");
                    string eMail = c.Fields.Name;
                    c.Read("xr008");
                    string smpt = c.Fields.Name;
                    c.Read("xr009");
                    string password = c.Fields.Name;
                    c.Read("xr010");
                    int port = 0;
                    try { port = int.Parse(c.Fields.Name); } catch { port = 25; }
                    int err = 0; string m = "";
                    if (megaText_Memo.Text_Textbox.Length == 0) { m = "Δεν έχετε γράψει κάτι στις σημειώσεις για να στείλω !\n"; err = -1; }
                    if (megaText_eMail.Text_Textbox.Length == 0) { m += "Ο Συναλλασσόμενος δεν έχει eMail !\n"; err = -1; }
                    if (eMail.Length == 0) { m += "Δεν έχει οριστεί eMail αποστολής !\n"; err = -1; }
                    if (smpt.Length == 0) { m += "Δεν έχει οριστεί outgoing server (smtp) !\n"; err = -1; }
                    if (password.Length == 0) { m += "Δεν έχει οριστεί password για τον outgoing server (smtp) !\n"; err = -1; }
                    if (err == 0)
                    {
                        if (MessageBox.Show("Ένα αυτόματο email θα σταλεί στην διέυθυνση " + megaText_eMail.Text_Textbox + "\n\n" + megaText_Memo.Text_Textbox, "Αποστολή email !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            //if (a.SendEmail(megaText_eMail.Text_Textbox, "ΜέγαSoft BPR email automation system !", megaText_Memo.Text_Textbox, eMail, password, smpt, port))
                            //    MessageBox.Show("Email sended !", "Αποστολή email !");
                            //else MessageBox.Show("Fail to send the eMail !", "Αποστολή email !");
                            
                            if(b.SendEmail(megaText_eMail.Text_Textbox, "ΜέγαSoft BPR email automation system !", megaText_Memo.Text_Textbox))
                                MessageBox.Show("Email sended !", "Αποστολή email !");
                            else MessageBox.Show("Fail to send the eMail !", "Αποστολή email !");
                    }
                    else MessageBox.Show(m, "Αποστολή email !");
                };

                ToolStripMenuItem ViewMenuItem02 = new ToolStripMenuItem("Εντοπισμός στον χάρτη");
                ViewMenuItem02.Click += (object sender, EventArgs e) =>
                {
                    List<string> ids = new List<string>();
                    List<string> descs = new List<string>();
                    List<string> addrs = new List<string>();
                    ids.Add(megaText_id.Text_Textbox);
                    descs.Add(megaText_Name.Text_Textbox);
                    addrs.Add(megaText_Address.Text_Textbox);
                    Form f = new iForms.frmMap(ids, descs, addrs);
                    f.MdiParent = this.ParentForm;
                    f.Text = megaText_Name.Text_Textbox;
                    f.Show();
                };              

                ToolStripDropDownButton menuView0 = new ToolStripDropDownButton("Ενέργειες");
                menuView0.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem00, ViewMenuItem01, ViewMenuItem02 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView0 });
            }

            // Κινήσεις
            {

                ToolStripMenuItem ViewMenuItemErg = new ToolStripMenuItem("Νέα Εργασία");
                ViewMenuItemErg.Click += (object sender, EventArgs e) =>
                { frmKErFl f = new frmKErFl("new", megaText_id.megaTextBox.Text); f.MdiParent = this.ParentForm; f.Show(); };

                

                ToolStripMenuItem ViewMenuItem101 = new ToolStripMenuItem("Νέα είσπραξη απο "+_s.G(1));
                ViewMenuItem101.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.RecieveFromCustomer); };

                ToolStripMenuItem ViewMenuItem102 = new ToolStripMenuItem("Νέα χρέωση σε "+_s.G(1));
                ViewMenuItem102.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.DebitToCustomer); };

                ToolStripMenuItem ViewMenuItem103 = new ToolStripMenuItem("Νέα πίστωση σε "+_s.G(1));
                ViewMenuItem103.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.CreditToCustomer); };

                ToolStripMenuItem ViewMenuItem104 = new ToolStripMenuItem("Νέα πληρωμή σε " + _s.G(1));
                ViewMenuItem104.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.PaymentToCustomer); };

                ToolStripSeparator ViewMenuItem105 = new ToolStripSeparator();

                ToolStripMenuItem ViewMenuItem106 = new ToolStripMenuItem("Νέα πληρωμή σε " + _s.G(4));
                ViewMenuItem106.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.PaymentToSuplier); };

                ToolStripMenuItem ViewMenuItem107 = new ToolStripMenuItem("Νέα πίστωση σε " + _s.G(4));
                ViewMenuItem107.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.CreditToSuplier); };

                ToolStripMenuItem ViewMenuItem108 = new ToolStripMenuItem("Νέα χρέωση σε " + _s.G(4));
                ViewMenuItem108.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.DebitToSuplier); };

                ToolStripMenuItem ViewMenuItem109 = new ToolStripMenuItem("Νέα είσπραξη απο " + _s.G(4));
                ViewMenuItem109.Click += (object sender, EventArgs e) =>
                { CallfrmKinFl(KinFl.TypeOfKin.RecieveFromSuplier); };

                ToolStripMenuItem ViewMenuItem10 = new ToolStripMenuItem("Εισπράξεις - Πληρωμές");             

                ViewMenuItem10.DropDownItems.AddRange(new ToolStripItem[] {
                                                                    ViewMenuItem101,
                                                                    ViewMenuItem102,
                                                                    ViewMenuItem103,
                                                                    ViewMenuItem104,
                                                                    ViewMenuItem105,
                                                                    ViewMenuItem106,
                                                                    ViewMenuItem107,
                                                                    ViewMenuItem108,
                                                                    ViewMenuItem109 });

                ToolStripMenuItem ViewMenuItem11 = new ToolStripMenuItem("Παραστατικά");
                ViewMenuItem11.Visible = false;
                ViewMenuItem11.Click += (object sender, EventArgs e) =>
                {
                };

                ToolStripDropDownButton menuView1 = new ToolStripDropDownButton("Κινήσεις");
                menuView1.Click += (object sender, EventArgs e) =>
                {
                    if (megaCombo_Kind.megaComboBox.SelectedIndex == 0)
                    {
                        ViewMenuItemErg.Enabled = true;
                        ViewMenuItem101.Enabled = true;
                        ViewMenuItem102.Enabled = true;
                        ViewMenuItem103.Enabled = true;
                        ViewMenuItem104.Enabled = true;
                        ViewMenuItem106.Enabled = false;
                        ViewMenuItem107.Enabled = false;
                        ViewMenuItem108.Enabled = false;
                        ViewMenuItem109.Enabled = false;
                    }
                    if (megaCombo_Kind.megaComboBox.SelectedIndex == 1)
                    {
                        ViewMenuItemErg.Enabled = false;
                        ViewMenuItem101.Enabled = false;
                        ViewMenuItem102.Enabled = false;
                        ViewMenuItem103.Enabled = false;
                        ViewMenuItem104.Enabled = false;
                        ViewMenuItem106.Enabled = true;
                        ViewMenuItem107.Enabled = true;
                        ViewMenuItem108.Enabled = true;
                        ViewMenuItem109.Enabled = true;
                    }
                    if (megaCombo_Kind.megaComboBox.SelectedIndex == 2)
                    {
                        ViewMenuItem101.Enabled = true;
                        ViewMenuItem102.Enabled = true;
                        ViewMenuItem103.Enabled = true;
                        ViewMenuItem104.Enabled = true;
                        ViewMenuItem106.Enabled = true;
                        ViewMenuItem107.Enabled = true;
                        ViewMenuItem108.Enabled = true;
                        ViewMenuItem109.Enabled = true;
                    }

                };
                menuView1.DropDownItems.AddRange(new ToolStripItem[] {ViewMenuItemErg, new ToolStripSeparator(), ViewMenuItem10, ViewMenuItem11 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView1 });
            }

            // Παρουσιάσεις           
            {
               
                ToolStripMenuItem ViewMenuItem22 = new ToolStripMenuItem("Εργασίες");
                if (MyType == SynFl.TypeOfSynFl.All || MyType == SynFl.TypeOfSynFl.Supliers) ViewMenuItem22.Enabled = false;
                ViewMenuItem22.Click += (object sender, EventArgs e) =>
                {
                    reportForms.ReportErga childForm = new reportForms.ReportErga(id);
                    //childForm.MdiParent = this.ParentForm;
                    childForm.ShowDialog();
                };

                ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem("Καρτέλλα");
                ViewMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    CallForms.CallKinKartFrm childForm = new CallForms.CallKinKartFrm(id);
                    //childForm.MdiParent = this.ParentForm;
                    childForm.ShowDialog();
                };

                ToolStripMenuItem ViewMenuItem21 = new ToolStripMenuItem("Κινήσεις ανα μήνα");
                ViewMenuItem21.Click += (object sender, EventArgs e) =>
                {
                    List<String> mySyn = new List<String>();
                    List<String> myDescSyn = new List<String>();
                    mySyn.Add(id);
                    myDescSyn.Add(megaText_Name.Text_Textbox);
                    reportForms.ksynRepFrm myf = new reportForms.ksynRepFrm(mySyn, myDescSyn);
                    //myf.MdiParent = this.ParentForm;
                    myf.ShowDialog();
                };            

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Παρουσιάσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem22, ViewMenuItem20, ViewMenuItem21 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }

            // Ρυθμίσεις         
            {
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Τιμοκατάλογοι");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.PriceList, megaCombo_PriceList.megaComboBox); };

                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("Κατηγορίες");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.Category, megaCombo_Category.megaComboBox); };

                ToolStripMenuItem ViewMenuItem32 = new ToolStripMenuItem("Επαγγέλματα");
                ViewMenuItem32.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.Occupation, megaCombo_Occupation.megaComboBox); };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30, ViewMenuItem31, ViewMenuItem32 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });
            }

            // Έγραφα
            {                
                ToolStripMenuItem ViewMenuItem0 = new ToolStripMenuItem("Έγγραφα");
                ViewMenuItem0.Click += (object sender, EventArgs e) =>
                {
                    if (id.Equals("new")) MessageBox.Show("Προσοχή !", "Πρέπει πρώτα να καταχωρήσετε την εγγραφή και μετά να διαχειριστείτε τα έγγραφα !");
                    else
                    {
                        frmDocs f = new frmDocs(megaText_id.Text_Textbox, megaText_Name.Text_Textbox);
                        f.ShowDialog();
                    }
                };
                menu.Items.AddRange(new ToolStripMenuItem[] { ViewMenuItem0 });
            }
        }
        private void CallfrmKinFl(KinFl.TypeOfKin mytype)
        { frmKinFl childForm = new frmKinFl("", "new", new KinFl().readKoKi(mytype), id);
          childForm.MdiParent = this.MdiParent;
          childForm.Show(); }
        private void CallfrmPinFl(FilPin.TypeOfPin MyType, ComboBox MyCombo)
        {
            string oldValue = ""; 
            if(MyCombo.Items.Count>0) oldValue  = MyCombo.SelectedValue.ToString();
            CallForms.CallPinFrm childForm = new CallForms.CallPinFrm(MyType);
            childForm.ShowDialog();
            MyCombo.DataSource = new FilPin("%").ReadZoom(MyType);
            new alphaFrameWork.AlphaFramework().setSI_Combos(MyCombo, oldValue);
        }
        private void setFormsGlobals()
        {
            switch (MyType)
            {
                case SynFl.TypeOfSynFl.Customers:
                    this.Name = "frmSynFl_Customers";
                    break;
                case SynFl.TypeOfSynFl.Supliers:
                    this.Name = "frmSynFl_Supliers";
                    break;
                case SynFl.TypeOfSynFl.CustomersSupliers:
                    this.Name = "frmSynFl_CustomersSupliers";
                    break;
                default:
                    this.Name = "frmSynFl";
                    break;
            }
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
                this.Text = dataclass.ReadTitle(MyType) + " - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου            
            else
                this.Text = dataclass.ReadTitle(MyType); //΄Ορίζω τον τίτλο του παραθύρου

            //megaText_Name.megaTextBox.Visible = false;
            //megaText_Name.textBox1.Visible = true;
            //megaText_Name.textBox2.Visible = true;
            //megaText_Name.textBox3.Visible = true;
        }

        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        class S
        {
            private string lang = "gr";
            public S(string _lang) { lang = _lang; }

            public string G(int id)
            {
                switch (lang)
                {
                    case "gr":
                        switch (id)
                        {
                            case 1: return "Πελάτης";
                            case 2: return "Πελάτες";
                            case 3: return "΄Πελατών";
                            case 4: return "Προμηθευτής";
                            case 5: return "Προμηθευτές";
                            case 6: return "Προμηθευτών";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Customer";
                            case 2: return "Customers";
                            case 3: return "Customers";
                            case 4: return "Supplier";
                            case 5: return "Suppliers";
                            case 6: return "Suppliers";
                            default: return "String not found";
                        }
                }
            }

        }
        #endregion


    }
}
