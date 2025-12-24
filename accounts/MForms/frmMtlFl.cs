using templates.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using accountsClassLibrary;
using System.Security.Cryptography;
using static DesktopBusiness.reports.isoDataSet;
using DesktopBusiness.iForms;

namespace DesktopBusiness.MForms
{
    public partial class frmMtlFl : templates.Forms.frmMaster
    {
        public frmMtlFl()
        {
            InitializeComponent();
            setFormsGlobals();
        }

        private string id;
        public frmMtlFl(string id_)
        {
            InitializeComponent();
            id = id_;
            memo = "";
            setFormsGlobals();

        }

        string memo;

        public frmMtlFl(string id_, string memo_)
        {
            InitializeComponent();
            id = id_;
            memo = memo_;
            setFormsGlobals();
           
        }

        #region virtual functions, general functions & variables

        public override void LoadDefaults()
        {                   
            FilPin pin = new FilPin("%");
            megaCombo_Family.DataSource = pin.ReadZoom(FilPin.TypeOfPin.Families);          
            megaCombo_KindOfTax.DataSource = pin.ReadZoom(FilPin.TypeOfPin.KindofTax);
            megaCombo_Category.DataSource = pin.ReadZoom(FilPin.TypeOfPin.CategoryMtl);
            megaCombo_MoMe.DataSource = pin.ReadZoom(FilPin.TypeOfPin.MoMeMtl);
            ParPin par = new ParPin();
            megaCombo_Status.DataSource = par.ReadZoom(ParPin.TypeOfPar.Status);
        }

        MtlFl dataclass = new MtlFl(" ");
        public override void LoadData()
        {
            if (id.ToUpper().Equals("NEW")) {
                this.Text = "Είδος - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου
                megaText_id.megaTextBox.Text = System.Guid.NewGuid().ToString();
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                string Res = dataclass.Read(id); // Διαβάζω τα δεδομένα
                if (Res.Length > 0) { MessageBox.Show(Res, "Προσοχή !"); menu.Enabled = false; } // Μνμ εαν δεν μπορώ να τα διαβάσω, Απενεργοποίηση του μενου
                else
                {
                    this.Text = "Είδος - " + dataclass.Fields.Description; //΄Ορίζω τον τίτλο του παραθύρου
                    base.LoadData(dataclass.Fields); // Μεταφαίρω τα δεδομένα στα αντικείμενα της φόρμας
                    megaText_id.Enabled = false; /* primary key enable = false για το edit */
                    if (memo.Length > 0) htmlEditorControl1.InnerHtml = memo;
                    else htmlEditorControl1.InnerHtml = dataclass.Fields.Memo;
                    htmlEditorControl2.InnerHtml = dataclass.Fields.MemoEn;
                    if (dataclass.Fields.eShop == "1") { checkBox_eShop.Checked = true; }
                    else { checkBox_eShop.Checked = false; }
                    label2.Text = "Τιμές (" + megaText_Description.megaTextBox.Text + ")";
                }
                refreshdata();
                refreshdataSynteges();
            }

        }
        public override void UpdateBtn()
        {
            object objectdata = base.UpdateBtn(dataclass.Fields); // μεταφέρω τις τιμές των αντικειμένων σε ένα γενικό αντικείμενο 
            foreach (var property in objectdata.GetType().GetProperties())   // μεταφέρω τις τιμές απο το γενικό αντικείμενο στα πεδία της κλάσης
                dataclass.Fields.GetType().GetProperty(property.Name).SetValue(dataclass.Fields, property.GetValue(objectdata));
            if(checkBox_eShop.Checked) { dataclass.Fields.eShop = "1"; }
            else { dataclass.Fields.eShop = "0"; }

            if (htmlEditorControl1.InnerHtml is null) htmlEditorControl1.InnerText = " ";
            dataclass.Fields.Memo = htmlEditorControl1.InnerHtml;
            if (htmlEditorControl2.InnerHtml is null) htmlEditorControl2.InnerText = " ";
            dataclass.Fields.MemoEn = htmlEditorControl2.InnerHtml;
            string res = "";
            if (id.Equals("new")) res = dataclass.Insert(); // νεα εγγραφή
            else res = dataclass.Update();  // σώζω 
            if (res.Length == 0) this.Close(); // έξοδος
            else MessageBox.Show(res, "Σφάλμα !"); // παρουσίαση σφάλματος στο update
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
        public override void CustomizeMenu()
        {
            // Ρυθμίσεις

            {
                ToolStripMenuItem ViewMenuItem30 = new ToolStripMenuItem("Οικογένειες");
                ViewMenuItem30.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.Families, megaCombo_Family.megaComboBox); };

                ToolStripMenuItem ViewMenuItem31 = new ToolStripMenuItem("Κατηγορίες");
                ViewMenuItem31.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.CategoryMtl, megaCombo_Category.megaComboBox); };

                ToolStripMenuItem ViewMenuItem32 = new ToolStripMenuItem("ΦΠΑ");
                ViewMenuItem32.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.KindofTax, megaCombo_KindOfTax.megaComboBox); };

                ToolStripMenuItem ViewMenuItem33 = new ToolStripMenuItem("Μονάδες Μέτρησης");
                ViewMenuItem33.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.MoMeMtl, megaCombo_MoMe.megaComboBox); };

                ToolStripMenuItem ViewMenuItem34 = new ToolStripMenuItem("Τιμοκατάλογοι");
                ViewMenuItem34.Click += (object sender, EventArgs e) =>
                { CallfrmPinFl(FilPin.TypeOfPin.PriceList, new ComboBox()); };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ρυθμίσεις");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem30, ViewMenuItem31, ViewMenuItem32, ViewMenuItem33, ViewMenuItem34 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView2 });

            }


            // Ενέργειες            
            {
                ToolStripMenuItem ViewMenuItem00 = new ToolStripMenuItem("Επεξεργασία συστατικού");
                ViewMenuItem00.Click += (object sender, EventArgs e) =>
                {
                    try
                    {
                        DesktopBusiness.MForms.frmMtlFl f = new frmMtlFl(megaDetail1.megaGridView.SelectedRows[0].Cells[1].Value.ToString());
                        f.ShowDialog();
                        //new DesktopBusiness.MForms.frmMtlFl(id[0])
                    }
                    catch { }
                };

                ToolStripMenuItem ViewMenuItem01 = new ToolStripMenuItem("Δημιουργία τιμών απο τα συστατικά");
                ViewMenuItem01.Click += (object sender, EventArgs e) =>
                {
                     MtlFl m = new MtlFl();
                    m.ComputePrices(megaText_id.megaTextBox.Text);
                    refreshdata();                   
                };
                ToolStripMenuItem ViewMenuItem03 = new ToolStripMenuItem("Μηδενισμός τιμών στα συστατικά");
                ViewMenuItem03.Click += (object sender, EventArgs e) =>
                {
                    MtlFl m = new MtlFl();
                    m.DeletePricesToSys(megaText_id.megaTextBox.Text);
                    refreshdata();
                };
                ToolStripMenuItem ViewMenuItem02 = new ToolStripMenuItem("Δημιουργία τιμών στα συστατικά");
                ViewMenuItem02.Click += (object sender, EventArgs e) =>
                {
                    MtlFl m = new MtlFl();
                    m.ComputePricesToSys(megaText_id.megaTextBox.Text, Convert.ToDouble(quantitysum.Text));
                    refreshdata();
                };
                ToolStripMenuItem ViewMenuItem04 = new ToolStripMenuItem("Ανάλυση Κόστους !");
                ViewMenuItem04.Click += (object sender, EventArgs e) =>
                {
                    try
                    {
                        reportKost m = new reportKost(megaDetail_Times.megaGridView.SelectedRows[0].Cells[2].Value.ToString(),
                                                      megaDetail_Times.megaGridView.SelectedRows[0].Cells[3].Value.ToString(),
                                                      megaText_id.megaTextBox.Text,
                                                      megaText_Description.megaTextBox.Text);
                        m.ShowDialog();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                };
                ToolStripDropDownButton menuView0 = new ToolStripDropDownButton("Ενέργειες");
                menuView0.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem00, ViewMenuItem01, ViewMenuItem03, ViewMenuItem02, ViewMenuItem04 });

                menu.Items.AddRange(new ToolStripDropDownButton[] { menuView0 });
            }       
        }

        private void setFormsGlobals()
        {
            this.Name = "frmMtlFl";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            if (id.ToUpper().Equals("NEW"))
                this.Text = "Είδος - Νέα Εγγραφή !"; //΄Ορίζω τον τίτλο του παραθύρου
            else
                this.Text = "Είδος "; //΄Ορίζω τον τίτλο του παραθύρου
            Program.global.InputBoxText = "";
            Program.global.InputBox1Text = "";
            Program.global.InputBox2Text = "";
            Program.global.InputBoxList = new List<string>();
            Program.global.InputBoxList = new List<string>();

        }

        accountsClassLibrary.Times times = new Times("!@#$");
        DataTable Times_;
        private DataTable ReadTimesanaEidos(string id ="")
        {
            if(id.Trim().Length == 0) id = megaText_id.megaTextBox.Text;
            
            times.Fields.Product = id;
            return times.ReadZoom();
            
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
                            case 1: return "Κωδικός";
                            case 2: return "Περιγραφή";
                            case 3: return "΄Bar code";
                            case 4: return "Bar code Box";
                            case 5: return "Περιέχει";
                            case 6: return "Οικογένεια";
                            case 7: return "ΦΠΑ";
                            case 8: return "Κατηγορία";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "ID";
                            case 2: return "Description";
                            case 3: return "΄Bar code";
                            case 4: return "Bar code Box";
                            case 5: return "Contain";
                            case 6: return "Family";
                            case 7: return "Vat";
                            case 8: return "Category";
                            default: return "String not found";
                        }
                }
            }

        }

        private void megaDetail1_Load(object sender, EventArgs e)
        {

            refreshdata();
        }

        private void megaDetail_Times_EditRecord(object sender, EventArgs e)
        {
            Form childForm = new MForms.frmTimi(megaDetail_Times.megaGridView.SelectedRows[0].Cells[1].Value.ToString(),
                                                megaDetail_Times.megaGridView.SelectedRows[0].Cells[2].Value.ToString(), 
                                                dataclass.Fields.Description,
                                                megaDetail_Times.megaGridView.SelectedRows[0].Cells[3].Value.ToString());
            childForm.ShowDialog();
            refreshdata();
        }

       
        private void refreshdata()
        {
            List<Object> cols = new List<Object>();
            List<string> fields = new List<string>();
            List<string> fname = new List<string>();

            // Δηλώνω κολόνες στο Grid

            for (int i = 0; i < 6; i++)
            {
                cols.Add(new DataGridViewTextBoxColumn());
            }

            // Δηλώνω τα πεδία
            fields = new List<string>() { "AA", "Product", "PriceList", "PriceListDescription", "PEkpt", "Price" };
            fname = new List<string>() { "AA", "Visible=False", "Κωδικός", "Περιγραφή", "Έκπτωση", "Τιμή" };

            // Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind
            new alphaFrameWork.AlphaFramework().Bind(megaDetail_Times.megaGridView, Times_, cols, fields, fname);
            new alphaFrameWork.AlphaFramework().Bind(megaDetail2.megaGridView, Times_, cols, fields, fname);
            megaDetail_Times.megaGridView.DataSource = ReadTimesanaEidos(megaText_id.megaTextBox.Text);
            megaDetail_Times.megaGridView.Refresh();
            megaDetail2.menu.Items[1].Visible = false;
            megaDetail2.menu.Items[0].Visible = false;
        }
        private void loadTimessyatatikon(string id)
        {
            List<Object> cols = new List<Object>();
            List<string> fields = new List<string>();
            List<string> fname = new List<string>();

            // Δηλώνω κολόνες στο Grid

            for (int i = 0; i < 6; i++)
            {
                cols.Add(new DataGridViewTextBoxColumn());
            }

            // Δηλώνω τα πεδία
            fields = new List<string>() { "AA", "Product", "PriceList", "PriceListDescription", "PEkpt", "Price" };
            fname = new List<string>() { "AA", "Visible=False", "Κωδικός", "Περιγραφή", "Έκπτωση", "Τιμή" };

            // Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind
            new alphaFrameWork.AlphaFramework().Bind(megaDetail2.megaGridView, Times_, cols, fields, fname);
            megaDetail2.megaGridView.DataSource = ReadTimesanaEidos(id);
            megaDetail2.megaGridView.Refresh();

        }

        private void megaDetail_Times_NewRecord(object sender, EventArgs e)
        {
            Form childForm = new MForms.koki(id);
            childForm.ShowDialog();
            accountsClassLibrary.Times t = new Times("");
            t.Fields.Product = id;
            t.Fields.PriceList.id = Program.global.InputBoxText;
            t.Fields.Price = 0;
            t.Fields.PEkpt = 0;
            if(Program.global.InputBoxText.Trim().Length>0) t.Insert();
            refreshdata();
        }

        private void megaDetail_Times_RefreshRecord(object sender, EventArgs e)
        {
            refreshdata();
        }

        private void megaDetail_Times_DeleteRecord(object sender, EventArgs e)
        {
            accountsClassLibrary.Times t = new Times("");
            t.Fields.Product = id;
            t.Fields.PriceList.id = megaDetail_Times.megaGridView.SelectedRows[0].Cells[2].Value.ToString();
            t.Delete();
            refreshdata();
        }

        accountsClassLibrary.Syntages Syntages_ = new Syntages("!@#$");
        DataTable Synt_;
        private void megaDetail1_LoadData(object sender, EventArgs e)
        {
            refreshdataSynteges();
        }
        private DataTable ReadProductsanaEidos()
        {

            Syntages_.Fields.id = megaText_id.megaTextBox.Text;
            return Syntages_.ReadZoom(megaText_id.megaTextBox.Text);
            
        }

        private void megaDetail1_RefreshRecord(object sender, EventArgs e)
        {
            refreshdataSynteges();
        }

        private void refreshdataSynteges()
        {
            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i < 6; i++)
            {
                cols.Add(new DataGridViewTextBoxColumn());
            }

            // Δηλώνω τα πεδία
            List<string> fields = new List<string>() { "Id", "Product", "ProductDescription", "Quantity" };
            List<string> fname = new List<string>() { "Visible=False", "Κωδικός", "Περιγραφή", "Ποσότητα" };

            // Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind
            new alphaFrameWork.AlphaFramework().Bind(megaDetail1.megaGridView, Synt_, cols, fields, fname);
            items = ReadProductsanaEidos();
            megaDetail1.megaGridView.DataSource = items;
            megaDetail1.megaGridView.Refresh();
            quantitysum.Text = SumQuantity().ToString();
        }
        DataTable items = new DataTable();
        private void megaDetail1_NewRecord(object sender, EventArgs e)
        {
            //Form childForm = new MForms.qsynt(megaText_Description.megaTextBox.Text);
            Form childForm = new CallForms.CallMtlFrm("qsynt");
            childForm.ShowDialog();
            accountsClassLibrary.Syntages s = new Syntages("");
            s.Fields.id = id;
            s.Fields.Product = Program.global.InputBoxText;
            try { s.Fields.Quantity = Convert.ToDouble(Program.global.InputBox1Text); }
            catch { s.Fields.Quantity = 1; }            
            
            if (Program.global.InputBoxText.Trim().Length > 0) s.Insert();
            refreshdataSynteges();
        }

        private void megaDetail1_DeleteRecord(object sender, EventArgs e)
        {
            accountsClassLibrary.Syntages t = new Syntages("");
            t.Fields.id = id;
            t.Fields.Product = megaDetail1.megaGridView.SelectedRows[0].Cells[1].Value.ToString();
            t.Delete();
            refreshdataSynteges();

        }

        private void megaDetail1_EditRecord(object sender, EventArgs e)
        {
            Form childForm = new MForms.qsynt(megaDetail1.megaGridView.SelectedRows[0].Cells[0].Value.ToString(),
                                               megaDetail1.megaGridView.SelectedRows[0].Cells[1].Value.ToString(),
                                               megaDetail1.megaGridView.SelectedRows[0].Cells[2].Value.ToString(),
                                               megaDetail1.megaGridView.SelectedRows[0].Cells[3].Value.ToString());
            childForm.ShowDialog();
            if (id != "new")
            {
                Syntages s = new Syntages();
                s.Fields.id = id;
                s.Fields.Product = Program.global.InputBoxText;
                s.Fields.Quantity = Convert.ToDouble(Program.global.InputBox1Text);
                s.Update();
            }
            refreshdataSynteges();
        }

        private void megaDetail2_RefreshRecord(object sender, EventArgs e)
        {
            loadTimessyatatikon(megaDetail1.megaGridView.SelectedRows[0].Cells[1].Value.ToString());
            label_systat.Text = "Τιμές (" + megaDetail1.megaGridView.SelectedRows[0].Cells[2].Value.ToString() + ")";
        }

        private double SumQuantity()
        {
            double tmp = 0;
            for (int i = 0; i < items.Rows.Count; i++)
            {
                tmp += Convert.ToDouble(items.Rows[i]["quantity"]);
            }
            return tmp;
        }

        private void megaDetail2_Load(object sender, EventArgs e)
        {

        }
    }
    #endregion

}
