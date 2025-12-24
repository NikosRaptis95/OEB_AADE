using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmKinFl : templates.Forms.def
    {

        #region formDefinition
        public frmKinFl(String myseira, string myid, string mykoki)
        {
            InitializeComponent();
            MyId = myid;
            MyKoKi = mykoki;
            MySeira = myseira;
            MySyn = "";
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }

        public frmKinFl(String myseira, string myid, string mykoki, string mysyn)
        {
            InitializeComponent();
            MyId = myid;
            MyKoKi = mykoki;
            MySeira = myseira;
            MySyn = mysyn;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }


    private void frmKinFl_Load(object sender, EventArgs e)
        {            
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Name = "frmKinFl";
            initData();
        }

        #endregion        

        #region interface
        private void textBox_IdSyn_Id_TextChanged(object sender, EventArgs e)
        {
            accountsClassLibrary.SynFl myc = new accountsClassLibrary.SynFl();
            string res = myc.Read(textBox_IdSyn_Id.Text);
            if (res.Equals("")) { textBox_IdSyn_Name.Text = myc.Fields.Name;
                textBox_timokat.Text = myc.Fields.PriceList.Name;
                myc.ReadYpoloipo("");
                this.textBox_ypol.Text = myc.Fields.Ypoloipo.ToString("### ##0.00"); }
            else { textBox_IdSyn_Name.Text = res.Substring(24,res.Length-24);
                textBox_timokat.Text = "";
                this.textBox_ypol.Text = "0"; }

           
        }
        private void button_idSyn_Click(object sender, EventArgs e)
        {
            if (textBox_KoKiKin.SelectedValue.ToString().Substring(0, 1).Equals("0"))
            {
                Form childForm = new CallForms.CallSynFrm(accountsClassLibrary.SynFl.TypeOfSynFl.Customers, true);
                childForm.ShowDialog();
                try {                                           
                    textBox_IdSyn_Id.Text = templates.global.r[0]; }
                catch { textBox_IdSyn_Id.Text = ""; }
                childForm.Close();
            }
            else
            {
                Form childForm = new CallForms.CallSynFrm(accountsClassLibrary.SynFl.TypeOfSynFl.Supliers, true);
                childForm.ShowDialog();
                try {
                    textBox_IdSyn_Id.Text = templates.global.r[0]; }
                catch { textBox_IdSyn_Id.Text = ""; }
                childForm.Close();
            }

        }
        private void textBox_Seira_TextChanged(object sender, EventArgs e)
        {
            ReadNewArPa();
        }
        private void textBox_KoKiKin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadNewArPa();
            SetCashEnabled();
            loadAitiologia();
        }
        private void label_Seira_CheckedChanged(object sender, EventArgs e)
        {
            loadSeira();
        }
        private void label_AitiKin_CheckedChanged(object sender, EventArgs e)
        {
            loadAitiologia();
        }
        #endregion       

        #region buttons

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accountsClassLibrary.KinFl MyData = new accountsClassLibrary.KinFl();

            if (this.textBox_Seira.Text.Length > 0) { 
                MyData.Fields.Seira = this.textBox_Seira.Text;
                if (MyData.ReadZoom(MyData.readTypeOfKin(this.textBox_KoKiKin.SelectedValue.ToString())).Rows.Count < 1 && label_Seira.Checked == true)
                {
                    MessageBox.Show("Αυτή η σειρά δεν έχει χρησιμοποιηθεί σε άλλη εγγραφή", "Προσοχή");
                    return;
                }
                MyData.Fields.Seira = "";
            }

            if (this.textBox_AitiKin.Text.Length > 0)
            {
                MyData.Fields.AitiKin = this.textBox_AitiKin.Text;
                try { if (MyData.ReadZoom(MyData.readTypeOfKin(this.textBox_KoKiKin.SelectedValue.ToString())).Rows.Count < 1 && label_AitiKin.Checked == true)
                    {
                        MessageBox.Show("Αυτή η αιτιολογία δεν έχει χρησιμοποιηθεί σε άλλη εγγραφή", "Προσοχή");
                        return;
                    }
                }
                catch { }               
            }
            else {
                MessageBox.Show("Δεν υπάρχει αιτιολογία ", "Προσοχή");
                return;
            }
            
            MyData.Fields.Seira = this.textBox_Seira.Text;
            MyData.Fields.id = this.textBox_id.Text;
            if (this.textBox_Cash.Checked) { MyData.Fields.Cash = "1"; }
            else { MyData.Fields.Cash = "0"; }
            MyData.Fields.idSyn.id = this.textBox_IdSyn_Id.Text;
            MyData.Fields.KoKiKin.id = this.textBox_KoKiKin.SelectedValue.ToString();
            MyData.Fields.Memo = this.textBox_Memo.Text;
            MyData.Fields.RegistryDate = this.textBox_RegistryDate.Value;
            MyData.Fields.SalesPerson = this.textBox_SalesPerson.Text;
            MyData.Fields.Status.id = this.textBox_Status.SelectedValue.ToString();
            alphaFrameWork.AlphaFramework MyA = new alphaFrameWork.AlphaFramework();
            MyData.Fields.Summary = MyA.MakeNo(this.textBox_Summary.Text,2);


            string resultString;
            if (MyId.Equals("new"))
            { resultString = MyData.Insert(); }
            else
            { resultString = MyData.Update(); }

            if (resultString.Equals("")) { Print_Click(); this.Close(); }
            else { MessageBox.Show(resultString.Replace("συναλλασόμενος", label_IdSyn_Id.Text) , "Ενημέρωση !"); }

        }
        
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initData();
        }
       
        #endregion

        #region globalFuncsAndVars

        private string MyId;
        private string MySeira;
        private string MyKoKi;
        private string MySyn;

        private void initData()
        {
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
            accountsClassLibrary.KoKiKin CKoKi = new accountsClassLibrary.KoKiKin();
            CKoKi.Read(MyKoKi);
            string extFile = CKoKi.Fields.Name;
            mc.customizationforLabels(this, extFile);
            LoadCombos();
            if (MyId.Equals("new"))
            {
                this.Text = "Νέα εγγραφή !";

                this.textBox_AitiKin.Text = "";
                this.textBox_id.Text = "";
                this.textBox_IdSyn_Id.Text = MySyn;
                this.textBox_Memo.Text = "";
                this.textBox_RegistryDate.Value = DateTime.Now;
                this.textBox_Seira.Text = "";
                this.textBox_Summary.Text = "0.00";
                this.textBox_Cash.Checked = true;
                mc.setSI_Combos(this.textBox_KoKiKin, MyKoKi);
                mc.setSI_Combos(this.textBox_Status, "1");
                ReadNewArPa();
                ReadSalesPerson();
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.Text = "Επεξεργασία κίνησης με αρ. παραστατικού : " + MyId;
                getData();
            }

        }

        private void getData()
        {
            Cursor.Current = Cursors.WaitCursor;
            accountsClassLibrary.KinFl MyData = new accountsClassLibrary.KinFl();
            MyData.Fields.id = MyId;
            MyData.Fields.Seira = MySeira;
            MyData.Fields.KoKiKin.id = MyKoKi;
            string resultString = MyData.Read();
            if (resultString.Equals(""))
            {
                this.textBox_id.Enabled = false;
                this.textBox_Seira.Enabled = false;
                this.label_Seira.Enabled = false;
                this.textBox_KoKiKin.Enabled = false;
                alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
                this.textBox_AitiKin.Text = MyData.Fields.AitiKin;
                if(MyData.Fields.Cash.Equals("0")) { this.textBox_Cash.Checked = false; }
                else { this.textBox_Cash.Checked = true; }
                this.textBox_id.Text = MyData.Fields.id;
                this.textBox_IdSyn_Id.Text = MyData.Fields.idSyn.id;
                mc.setSI_Combos(this.textBox_KoKiKin, MyData.Fields.KoKiKin.id);
                this.textBox_Memo.Text = MyData.Fields.Memo;
                this.textBox_RegistryDate.Value = MyData.Fields.RegistryDate;
                this.textBox_Seira.Text = MyData.Fields.Seira;
                mc.setSI_Combos(this.textBox_Status, MyData.Fields.Status.id);
                this.textBox_Summary.Text = mc.MakeNo(MyData.Fields.Summary.ToString(),2).ToString();
                this.textBox_SalesPerson.Text = MyData.Fields.SalesPerson;
            }
            else
            {
                try
                {
                    MessageBox.Show(resultString, "Ανάγνωση");
                    statusStrip1.Enabled = false;
                    this.Close();
                }
                catch
                { }

            }
            Cursor.Current = Cursors.Default;
        }
        
        private void LoadCombos()
        {
            LoadKoKiKinCombo(textBox_KoKiKin);            
            LoadParPinCombo(textBox_Status, accountsClassLibrary.ParPin.TypeOfPar.Status);
            loadAitiologia();
            loadSeira();
        }

        private void LoadParPinCombo(ComboBox MyCombo, accountsClassLibrary.ParPin.TypeOfPar ppType)
        {
            MyCombo.DisplayMember = "Name";
            MyCombo.ValueMember = "id";
            accountsClassLibrary.ParPin mcp = new accountsClassLibrary.ParPin();
            MyCombo.DataSource = mcp.ReadZoom(ppType);
        }

        private void LoadKoKiKinCombo(ComboBox MyCombo)
        {
            MyCombo.DisplayMember = "Name";
            MyCombo.ValueMember = "id";
            accountsClassLibrary.KoKiKin mcp = new accountsClassLibrary.KoKiKin();
            MyCombo.DataSource = mcp.ReadZoom();
        }

        private void ReadNewArPa()
        {

            if (this.textBox_id.Enabled) {
                accountsClassLibrary.KinFl mc = new accountsClassLibrary.KinFl();
                textBox_id.Text = mc.FindLastPlus(textBox_KoKiKin.SelectedValue.ToString(), textBox_Seira.Text);
            }            
        }

        private void SetCashEnabled()
        {
            if (textBox_KoKiKin.SelectedValue.ToString() == "00" ||
               textBox_KoKiKin.SelectedValue.ToString() == "02" ||
               textBox_KoKiKin.SelectedValue.ToString() == "10" ||
               textBox_KoKiKin.SelectedValue.ToString() == "12")
                textBox_Cash.Enabled = false;
            else
                textBox_Cash.Enabled = true;
        }

        private void ReadSalesPerson()
        {
            textBox_SalesPerson.Text = Program.global.username;
        }

        private void loadSeira()
        {
            string oldstr = textBox_Seira.Text;
            try
            {
                //if (label_Seira.Checked == true)
                //{
                textBox_Seira.DataSource = null;
                textBox_Seira.Items.Clear();
                textBox_Seira.DisplayMember = "Seira";
                accountsClassLibrary.KinFl mcp = new accountsClassLibrary.KinFl();
                textBox_Seira.DataSource = mcp.ReadZoomSeira(textBox_KoKiKin.SelectedValue.ToString());
                //}
                //else
                //{
                //    textBox_Seira.DataSource = null;
                //    textBox_Seira.Items.Clear();
                //}
            }
            catch { }
            textBox_Seira.Text = oldstr;
        }

        private void loadAitiologia()
        {
            string oldstr = textBox_AitiKin.Text;
            try
            {
                //if (label_AitiKin.Checked == true)
                //{
                textBox_AitiKin.DataSource = null;
                textBox_AitiKin.Items.Clear();
                textBox_AitiKin.DisplayMember = "AitiKin";
                accountsClassLibrary.KinFl mcp = new accountsClassLibrary.KinFl();
                textBox_AitiKin.DataSource = mcp.ReadZoomAitiKin(textBox_KoKiKin.SelectedValue.ToString());
                //}
                //else
                //{
                //    textBox_AitiKin.DataSource = null;
                //    textBox_AitiKin.Items.Clear();
                //}
            }
            catch { }
            textBox_AitiKin.Text = oldstr;
        }

        private void Print_Click()
        {
            accountsClassLibrary.reports.ApoKinFl rep = new accountsClassLibrary.reports.ApoKinFl();
            if (System.IO.File.Exists(rep.ReportPath))
            {
                if (MessageBox.Show("Η Εγγραφή έγινε ! \nΘέλετε να εκτυπώσετε απόδειξη ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin("%");
                    string c = "";
                    f.Read("xr001");
                    c += f.Fields.Name + "\n";
                    f.Read("xr003");
                    c += f.Fields.Name + "\n";
                    f.Read("xr006");
                    c += f.Fields.Name + "\n";
                    f.Read("xr007");
                    c += f.Fields.Name + "\n";
                    f.Read("xr008");
                    c += f.Fields.Name + "\n";
                    Form childForm = new templates.Forms.frmReport(rep.ReportPath,
                                                                   rep.getData(textBox_KoKiKin.SelectedValue.ToString(),
                                                                               textBox_Seira.Text,
                                                                               textBox_id.Text),
                                                                               textBox_KoKiKin.Text,
                                                                               c);
                    childForm.MdiParent = this.MdiParent;
                    childForm.Show();
                }
            }
            else { MessageBox.Show("Η Εγγραφή έγινε ! ", "Προσοχή !"); }
        }

        #endregion

    }
}
