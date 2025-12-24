using DesktopBusiness.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopBusiness.MForms
{
    public partial class frmDocs : templates.Forms.frmMaster
    {

        #region formDefinition
        private string id;
        private string description;
        private string[] fileEntries;

        public frmDocs(string id_, string description_)
        {
            InitializeComponent();
            id = id_;
            description = description_;
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;

            
        }

        #endregion

        #region Interface
        private void list_files_SelectedIndexChanged(object sender, EventArgs e)
        { try { LoadPicture(fileEntries[fileEntries.Count() - 1 - list_files.SelectedIndex]); } catch { } }
        private void list_files_DoubleClick(object sender, EventArgs e)
        {
            if (list_files.SelectedIndex > -1)
            {
                try
                {
                    if (MessageBox.Show("Θέλετε να επεξεργαστείτε το αρχείο (" +
                                   fileEntries[fileEntries.Count() - 1 - list_files.SelectedIndex] +
                                   ") του συναλλασόμενου ;", "Επιβεβαίωση !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ClearPicture();
                        OpenFileDialog dlg = new OpenFileDialog()
                        {
                            Title = "Επιλογή αρχείου",
                            InitialDirectory = Application.StartupPath + "\\" + d,
                            Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|" + list_files.Items[list_files.SelectedIndex].ToString()
                        };
                        dlg.ShowDialog();
                    }
                }
                catch { }
                LoadData();
            }
            else { MessageBox.Show("Πρέπει να επιλέξετε αρχείο για επεξεργασία !"); }
        }
        #endregion

        #region virtual functions, general functions & variables
        private string d;
        private void setDirectory()
        {
            string dir = "Documents";
            new alphaFrameWork.AlphaFramework().chkeckfolders(id, dir);
            d = dir + "\\" + id;
        }
        public override void LoadData()
        {
            base.LoadData();
            this.Text = "Έγγραφα !";
            this.Page1.Text = description;
            setDirectory();
            fileEntries = Directory.GetFiles(d);
            ClearPicture();

            list_files.Items.Clear();
            list_files.Sorted = false;
            for (int i = 0; i < fileEntries.Count(); i++)
            { FileInfo f = new FileInfo(fileEntries[fileEntries.Count() - 1 - i]);
              list_files.Items.Add(f.Name);  }
           
        }
        public override void UpdateBtn()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Title = "Επιλογή αρχείου",
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ClearPicture();
                LoadPicture(dlg.FileName);
                new iForms.InputBox("Θέλετε να εισάγετε το αρχείο στον συναλλασόμενο ;\n" + "με όνομα :" ,
                                    "Επιβεβαίωση !", DateTime.Now.ToString("yyyy MM(MMMM)  dd(dddd)") + ".jpg").ShowDialog();
                                //  "Επιβεβαίωση !", DateTime.Now.ToString("yyyy MM(MMM) dd(ddd) hh_mm_ss") + ".jpg").ShowDialog();
                if (Program.global.InputBoxText != "cancel")
                {         
                    File.Copy(dlg.FileName, d + "\\" + Program.global.InputBoxText);
                    LoadData();
                }
            }
            dlg.Dispose();
        }
      
        private void LoadPicture(string fn)
        {
            try
            {
                FileInfo f = new FileInfo(fn);
                // lbl_title.Text = f.LastWriteTime.ToLongDateString() + " " + f.LastWriteTime.ToLongTimeString();
                lbl_title.Text = f.Name;
                previewBox.Load(fn);
            }
            catch { }
        }
        private void ClearPicture()
        { previewBox.Image = null;
            try { previewBox.Load(new alphaFrameWork.AlphaFramework().WriteImageToDisk(ImageToByteArray(Resources.def), "def.jpg")); }
            catch { }
          lbl_title.Text = ""; }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public override void CustomizeMenu()
        {
            ToolStripDropDownButton m = (ToolStripDropDownButton)menu.Items[0];
            m.DropDownItems[0].Text = "Μεταφόρτωση";
        }
        #endregion


    }
}


