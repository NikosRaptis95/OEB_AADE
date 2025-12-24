using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Reflection;
using accountsClassLibrary;

namespace templates.Forms
{
    public partial class frmMaster : def
    {


        #region formDefinition      
        S _s = new S(new alphaFrameWork.AlphaFramework().lang);
        public frmMaster()
        {
            InitializeComponent();
        }
        private void frmMaster_Load(object sender, EventArgs e)
        {
            
            LoadDefaults();
            LoadData();
            _CustomizeMenu();
        }
        #endregion

        #region Interface
        private void frmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(this.Tag.ToString() != "new")
                if (MessageBox.Show(_s.G(1), _s.G(2), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) e.Cancel = true;
        }
        #endregion

        #region buttons
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_s.G(3), _s.G(2), MessageBoxButtons.YesNo) == DialogResult.Yes)
                LoadData();
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateBtn();
        }
        #endregion

        #region virtual functions, general functions & variables

        public virtual void LoadDefaults() { }
        public virtual void LoadData() { }
        public void LoadData(object data)
        {
            SetValuesToControls(this, data);
        }
        private void SetValuesToControls(Control obj, object data)
        {
            foreach (Control ctrl in obj.Controls)
            {
                try {
                    string t = ctrl.GetType().Name;
                    string field = "";
                    switch (t)
                    {
                        case "megaText":
                            try
                            { field = ((templates.UserControls.megaText)ctrl).datafield; }
                            catch { field = ""; }
                            if (field.Length > 0 && field != null)
                            {
                                //if(((UserControls.megaText)ctrl).ClassMember.Length > 0) {
                                //    string datafieldfield = ((UserControls.megaText)ctrl).datafield;
                                //    string ClassMember = ((UserControls.megaText)ctrl).ClassMember;
                                //    string ClassRelateField = ((UserControls.megaText)ctrl).ClassRelateField;

                                //    object ItemObjClassMember = data.GetType().GetProperty(ClassMember).GetValue(data, new object[] { });
                                //    ((UserControls.megaText)ctrl).megaTextBox.Text = ItemObjClassMember.GetType().GetProperty(ClassRelateField).GetValue(ItemObjClassMember).ToString();
                                //}
                                //else
                                string v = data.GetType().GetProperty(field).GetValue(data).ToString();
                                ((UserControls.megaText)ctrl).Text_Textbox = v;
                            }
                            break;
                        case "megaTrackBar":
                            try   { field = ((templates.UserControls.megaTrackBar)ctrl).datafield; }
                            catch { field = ""; }

                            if (field.Length > 0 && field != null)
                            {                                
                                string v = data.GetType().GetProperty(field).GetValue(data).ToString();
                                ((UserControls.megaTrackBar)ctrl).megaTextBox.Text = v;
                            }
                            break;
                        case "megaFind":
                            if (((UserControls.megaFind)ctrl).datafield.Length > 0 && ((UserControls.megaFind)ctrl).ValueMember.Length > 0)
                            {
                                field = ((UserControls.megaFind)ctrl).datafield;
                                string ValueMember = ((UserControls.megaFind)ctrl).ValueMember;
                                string DisplayMember = ((UserControls.megaFind)ctrl).DisplayMember;

                                object ItemObj = data.GetType().GetProperty(field).GetValue(data, new object[] { });
                                ((UserControls.megaFind)ctrl).megaTextBox.Text = ItemObj.GetType().GetProperty(ValueMember).GetValue(ItemObj).ToString();
                                ((UserControls.megaFind)ctrl).megaDisplay.Text = ItemObj.GetType().GetProperty(DisplayMember).GetValue(ItemObj).ToString();
                            }
                            break;
                        case "megaDate":
                            if (((UserControls.megaDate)ctrl).datafield.Length > 0)
                            {
                                string value = data.GetType().GetProperty(((UserControls.megaDate)ctrl).datafield).GetValue(data).ToString();
                                ((UserControls.megaDate)ctrl).megaDateBox.Text = value;
                            }
                            break;
                        case "megaCombo":
                            if (((UserControls.megaCombo)ctrl).datafield.Length > 0)
                            {
                                object datapin = data.GetType().GetProperty(((UserControls.megaCombo)ctrl).datafield).GetValue(data, new object[] { });
                                string vm = ((UserControls.megaCombo)ctrl).ValueMember;                                
                                string tmp = datapin.GetType().GetProperty(vm).GetValue(datapin).ToString();
                                new alphaFrameWork.AlphaFramework().setSI_Combos(((UserControls.megaCombo)ctrl).megaComboBox, tmp);
                            }
                            break;
                        default:
                            SetValuesToControls(ctrl, data);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, ctrl.Name);
                }
        }
        }

        public virtual void UpdateBtn() { }
        public object UpdateBtn(object data)
        {
            return GetValuesFromControls(data, this);
        }      
           
        public object GetValuesFromControls(object data, Control obj)
        {
            foreach (Control ctrl in obj.Controls)
            {
                var mydata = data.GetType();
                string t = ctrl.GetType().Name;
                string field = "";
                string value = "";
                switch (t)
                {
                    case "megaText":
                        try
                        {
                            string name = ((templates.UserControls.megaText)ctrl).Name;
                            try
                            { field = ((templates.UserControls.megaText)ctrl).datafield; }
                            catch { field = ""; }                           
                            if (field.Length > 00 && field != null)
                            {
                                value = ((templates.UserControls.megaText)ctrl).Text_Textbox;
                                if (mydata.GetProperty(field).PropertyType.Name.Equals("String"))
                                    mydata.GetProperty(field).SetValue(data, value);
                                else
                                    mydata.GetProperty(field).SetValue(data, Convert.ToDouble(value));                               
                            }
                        }
                        catch(Exception ex) { ErrTrapping(ex.Message, ctrl.Name); }
                        break;
                    case "megaTrackBar":
                        try
                        {
                            string name = ((templates.UserControls.megaTrackBar)ctrl).Name;
                            try
                            { field = ((templates.UserControls.megaTrackBar)ctrl).datafield; }
                            catch { field = ""; }
                            if (field.Length > 00 && field != null)
                            {
                                value = ((templates.UserControls.megaTrackBar)ctrl).megaTextBox.Text;
                                mydata.GetProperty(field).SetValue(data, Convert.ToInt32(value));                               
                            }
                        }
                        catch (Exception ex) { ErrTrapping(ex.Message, ctrl.Name); }
                        break;
                    case "megaFind":
                        try
                        {
                            try
                            { field = ((templates.UserControls.megaFind)ctrl).datafield; }
                            catch { field = ""; }
                            if (field.Length > 0  && field != null)
                            {
                                string itemObj_id = ((templates.UserControls.megaFind)ctrl).ValueMember;
                                object itemObj = mydata.GetProperty(field).GetValue(data, new object[] { });
                                value = ((templates.UserControls.megaFind)ctrl).megaTextBox.Text;
                                itemObj.GetType().GetProperty(itemObj_id).SetValue(itemObj, value);
                                mydata.GetProperty(field).SetValue(data, itemObj);
                            }
                        }
                        catch (Exception ex) { ErrTrapping(ex.Message, ctrl.Name); }
                        break;
                    case "megaDate":
                        try
                        {
                            try
                            { field = ((templates.UserControls.megaDate)ctrl).datafield; }
                            catch { field = ""; }
                            if (field.Length > 0  && field != null)
                            {
                                DateTime valueDate = ((templates.UserControls.megaDate)ctrl).megaDateBox.Value;
                                mydata.GetProperty(field).SetValue(data, valueDate);
                            }
                        }
                        catch (Exception ex) { ErrTrapping(ex.Message, ctrl.Name); }
                        break;
                    case "megaCombo":
                        try
                        {
                            try
                            { field = ((templates.UserControls.megaCombo)ctrl).datafield; }
                            catch { field = ""; }
                            if (field.Length > 0 && field != null)
                            {
                                object itemObj = mydata.GetProperty(field).GetValue(data, new object[] { });
                                string itemObj_id = ((templates.UserControls.megaCombo)ctrl).ValueMember;
                                value = ((templates.UserControls.megaCombo)ctrl).megaComboBox.SelectedValue.ToString();
                                itemObj.GetType().GetProperty(itemObj_id).SetValue(itemObj, value);
                                mydata.GetProperty(field).SetValue(data, itemObj);
                            }
                        }
                        catch (Exception ex) { ErrTrapping(ex.Message, ctrl.Name); }
                        break;
                    default:
                        GetValuesFromControls(data, ctrl);
                        break;
                }
            }
            return data;
        }
        public virtual void ErrTrapping(string err, string ctrl)
        { }

        private void _CustomizeMenu()
        {
            MasterView.Text = _s.G(4);
            refreshToolStripMenuItem.Text = _s.G(5);
            updateToolStripMenuItem.Text = _s.G(6);
            CustomizeMenu();
        }
        public virtual void CustomizeMenu() { }
        #endregion

        #region Action Function     


        #endregion

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
                            case 1: return "Θέλετε να κλείσετε την φόρμα ;";
                            case 2: return "Προσοχή !!";
                            case 3: return "ακύρωση των μεταβολών και ανάκτηση των προηγούμενων τιμών ;";
                            case 4: return "Επιλογές";
                            case 5:return "Ακύρωση";
                            case 6:return "Αποθήκευση";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Close form ?";
                            case 2: return "Attention !!";
                            case 3: return "Cancel and retrieve old values ?";
                            case 4: return "Options";
                            case 5: return "Cancel";
                            case 6: return "Update";
                            default: return "String not found";
                        }
                }
            }

        }
    }
}
