using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmFilPin : templates.Forms.def
    {
        #region formDifinition

        public frmFilPin(accountsClassLibrary.FilPin.TypeOfPin mytype, string myid)
        {
            InitializeComponent();
            MyType = mytype;
            MyId = myid;
            this.StartPosition = FormStartPosition.WindowsDefaultLocation;
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            initData();
        }

        #endregion

        #region buttons

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initData();  
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accountsClassLibrary.FilPin MyData = new accountsClassLibrary.FilPin();            
            MyData.Fields.id = this.textBox_id.Text;
            MyData.Fields.Name = this.textBox_Name.Text;
            try
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                MyData.Fields.Picture = ms.ToArray();
            }
            catch { }
            MyData.Fields.Status.id = this.textBox_Status.SelectedValue.ToString();
            MyData.Fields.Flag0 = checkBox1.Checked;
            string resultString;
            if (MyId.Equals("new"))
            { resultString = MyData.Insert(MyType); }
            else
            { resultString = MyData.Update(); }
            if (resultString.Equals("")) { this.Close(); }
            else { MessageBox.Show(resultString, "Ενημέρωση !"); }
    }

        #endregion

        #region interface
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.Filter = "txt files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.ImageLocation = openFileDialog1.FileName;
                    if ((openFileDialog1.OpenFile()) != null)
                    {
                        pictureBox1.ImageLocation = openFileDialog1.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Σφάλμα: Δεν μπορώ να διαβάσω το αρχείο απο τον δίσκο. \n\nOriginal error: " + ex.Message);
                }
            }
        }
        #endregion

        #region globalFuncsAndVars
        private accountsClassLibrary.FilPin.TypeOfPin MyType;
        private String MyId;

        private void initData()
        {
            alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
            mc.customizationforLabels(this);
            LoadParPinCombo(textBox_Status, accountsClassLibrary.ParPin.TypeOfPar.Status);
            if (MyId.Equals("new"))
            {
                this.Text = "Νέα εγγραφή !";
                this.textBox_id.Text = new accountsClassLibrary.FilPin().newId(new accountsClassLibrary.FilPin().readProthema(MyType));
                this.textBox_Name.Text = "";
                this.textBox_Status.SelectedIndex = 1;
                this.checkBox1.Checked = false;
                this.pictureBox1.ImageLocation = "";
                this.refreshToolStripMenuItem.Enabled = false;
            }
            else
            {
                this.Text = "Επεξεργασία στοιχείου πίνακα με κωδικό : " + MyId;
                if (MyType!=accountsClassLibrary.FilPin.TypeOfPin.PriceList) { this.checkBox1.Visible = false; }
                getData();
            }

        }               

        private void getData()
        {
            Cursor.Current = Cursors.WaitCursor;
            accountsClassLibrary.FilPin MyData = new accountsClassLibrary.FilPin();
            string returnString = MyData.Read(MyId);
            if (returnString.Equals("")) {
                this.textBox_id.Enabled = false;
                this.textBox_id.Text = MyData.Fields.id;
                this.textBox_Name.Text = MyData.Fields.Name;
                try
                {
                    this.pictureBox1.Image = Image.FromStream(new MemoryStream(MyData.Fields.Picture));
                }
                catch { }               
                new alphaFrameWork.AlphaFramework().setSI_Combos(this.textBox_Status, MyData.Fields.Status.id);
                this.checkBox1.Checked = MyData.Fields.Flag0;
            }
            else
            {
                MessageBox.Show(returnString, "Ανάγνωση εγγραφής !");
                this.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadParPinCombo(ComboBox MyCombo, accountsClassLibrary.ParPin.TypeOfPar ppType)
        {
            MyCombo.DisplayMember = "Name";
            MyCombo.ValueMember = "id";
            accountsClassLibrary.ParPin mcp = new accountsClassLibrary.ParPin();
            MyCombo.DataSource = mcp.ReadZoom(ppType);
        }
        #endregion

    }
}
