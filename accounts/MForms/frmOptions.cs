using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.iForms
{
    public partial class optionsFrm : templates.Forms.def
    
    {

#region Interface

        public optionsFrm()
        {
            InitializeComponent();
            LoadFilPinCombo(textBox_User, accountsClassLibrary.FilPin.TypeOfPin.Users,false);
            LoadData();
        }

        private void επαγγέλματαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form childForm = new CallForms.CallPinFrm(accountsClassLibrary.FilPin.TypeOfPin.Users);
            childForm.ShowDialog();
            LoadFilPinCombo(textBox_User, accountsClassLibrary.FilPin.TypeOfPin.Users, true);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

#endregion

#region General

        private void LoadFilPinCombo(ComboBox MyCombo, accountsClassLibrary.FilPin.TypeOfPin fpType, Boolean setOldValue)
        {
            try
            {

                string oldValue = "";
                if (setOldValue) { oldValue = MyCombo.SelectedValue.ToString(); }

                MyCombo.DisplayMember = "Name";
                MyCombo.ValueMember = "id";
                accountsClassLibrary.FilPin mcp = new accountsClassLibrary.FilPin("%");
                MyCombo.DataSource = mcp.ReadZoom(fpType);

                if (setOldValue)
                {
                    alphaFrameWork.AlphaFramework mc = new alphaFrameWork.AlphaFramework();
                    mc.setSI_Combos(MyCombo, oldValue);
                }
            }
            catch { }
        }

        private void LoadData()
        {
            accountsClassLibrary.FilPin c = new accountsClassLibrary.FilPin();
            c.Read("xr001");
            textBox_comp.Text = c.Fields.Name;
            c.Read("xr002");
            textBox_User.Text = c.Fields.Name;
            c.Read("xr003");
            textBox_address.Text = c.Fields.Name;
            c.Read("xr004");
            textBox_deka.Text = c.Fields.Name;
            c.Read("xr005");
            textBox_par.Text = c.Fields.Name;
            c.Read("xr006");
            textBox_phone.Text = c.Fields.Name;
            c.Read("xr007");
            textBox_eMail.Text = c.Fields.Name;
            c.Read("xr008");
            textBox_smtp.Text = c.Fields.Name;
            c.Read("xr009");
            textBox_password.Text = c.Fields.Name;
            c.Read("xr010");
            textBox_port.Text = c.Fields.Name;
        }

        private void UpdateData()
        {
            accountsClassLibrary.FilPin c = new accountsClassLibrary.FilPin();

            c.Fields.id = "xr001";
            c.Fields.Name = textBox_comp.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general); 

            c.Fields.id = "xr002";
            c.Fields.Name = textBox_User.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr003";
            c.Fields.Name = textBox_address.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr004";
            c.Fields.Name = textBox_deka.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr005";
            c.Fields.Name = textBox_par.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr006";
            c.Fields.Name = textBox_phone.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr007";
            c.Fields.Name = textBox_eMail.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr008";
            c.Fields.Name = textBox_smtp.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr009";
            c.Fields.Name = textBox_password.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            c.Fields.id = "xr010";
            c.Fields.Name = textBox_port.Text;
            if (new accountsClassLibrary.FilPin().Read(c.Fields.id).Trim().Length == 0) c.Update();
            else c.Insert(accountsClassLibrary.FilPin.TypeOfPin.general);

            this.Close();
        }

#endregion

    }
}
