using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DesktopBusiness.CallForms
{
    public partial class CallMtlFrm_WinPlan : templates.Forms.CallFrm
    {
        public CallMtlFrm_WinPlan()
        {
            this.Name = "CallMtlFrm_WinPlan";
            this.BO = "accountsClassLibrary.dll";
            this.EXE = Application.ExecutablePath;
            this.Text = "Ευρετήριο Προιόντων - WinPlan";
        }

        public override List<string> GetData(string strFind)
        {

            // Δηλώνω κολόνες στο Grid
            List<Object> cols = new List<Object>();
            for (int i = 0; i < 18; i++) { cols.Add(new DataGridViewTextBoxColumn()); }

            List<string> fields = new List<string>() { "AA",
                                                       "id",
                                                       "Description",
                                                       "MoMe",
                                                       "Family",
                                                       "BCode",
                                                       "Category",
                                                       "BCodeBox",
                                                       "Contain",
                                                       "Status",
                                                       "WebSite",
                                                       "FaceBook",
                                                       "YouTube",
                                                       "Paremferi",                                                       
                                                       "KindOfTax",
                                                       "eShop",
                                                       "ePosition",
                                                        "Memo"};
            List<string> fname = new List<string>() {  "AA",
                                                       "id",
                                                       "Description",
                                                       "MoMe",
                                                       "Family",
                                                       "BCode",
                                                       "Category",
                                                       "BCodeBox",
                                                       "Contain",
                                                       "Status",
                                                       "WebSite",
                                                       "FaceBook",
                                                       "YouTube",
                                                       "Paremferi",                                                       
                                                       "KindOfTax",
                                                       "eShop",
                                                       "ePosition",
                                                       "Memo"};

            // Τίτλος στο παράθυρο, Customization Grid           
            fname = new alphaFrameWork.AlphaFramework().customizationforGrid(fname, this.Name);

            // Καλώ τα δεδομένα και κάνω bind                        
            new alphaFrameWork.AlphaFramework().Bind(DataGrid,
                      new accountsClassLibrary.MtlFl(strFind).ReadZoomWinPlan(this.Name),
                      cols, fields, fname);

            // Επιστρέφω το Primary Field του Grid
            List<string> s = new List<string>();
            s.Add("id");
            return (s);
        }

        ToolStripProgressBar pb;
        ToolStripLabel tl;
        private string s_stoixein = "Ενημέρωση των στοιχείων των ειδών";
        private string s_timon = "Ενημέρωση των Τιμών Ειδών";
        private string s_ypol = "Ενημέρωση των υπολοίπων των ειδών";
        private string s_data = "Ενημέρωση όλων των δεδομένων των ειδών";
        private string s_images = "Ενημέρωση των εικόνων ειδών";
        private string s_filpin = "Ενημέρωση των παραμέτρων των ειδών";

        public override void CustomizeMenu()
        {
            menu.Items.RemoveAt(0);

            if (DataGrid.Rows.Count >= 0)
            {
                pb = new ToolStripProgressBar();
                tl = new ToolStripLabel();

                // Ενέργειες
                ToolStripMenuItem ViewMenuItem20 = new ToolStripMenuItem(s_stoixein);
                ViewMenuItem20.Click += (object sender, EventArgs e) =>
                {
                    if (MessageBox.Show("Θέλεις ενημέρωση των στοιχειων των ειδών ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadDescriptionsMtlXML();
                        MessageBox.Show("Επεξεργάστηκα " + DataGrid.SelectedRows.Count.ToString() + " προιόντα !");
                    }
                    else
                        MessageBox.Show("Η εργασία δεν έγινε !", "(" + DataGrid.SelectedRows.Count.ToString() + ")");
                };

                ToolStripMenuItem ViewMenuItem21 = new ToolStripMenuItem(s_timon);
                ViewMenuItem21.Click += (object sender, EventArgs e) =>
                {

                    if (MessageBox.Show("Θέλεις ενημέρωση των τιμών των ειδών ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadTimesMtlXML();
                        MessageBox.Show("Επεξεργάστηκα " + DataGrid.SelectedRows.Count.ToString() + " προιόντα !");
                    }
                    else
                        MessageBox.Show("Η εργασία δεν έγινε !", "(" + DataGrid.SelectedRows.Count.ToString() + ")");

                };

                ToolStripMenuItem ViewMenuItem22 = new ToolStripMenuItem(s_ypol);
                ViewMenuItem22.Click += (object sender, EventArgs e) =>
                {
                    if (MessageBox.Show("Θέλεις ενημέρωση των υπολοίπων των ειδών ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadYpoloipaMtlXML();
                        MessageBox.Show("Επεξεργάστηκα " + DataGrid.SelectedRows.Count.ToString() + " προιόντα !");
                    }
                    else
                        MessageBox.Show("Η εργασία δεν έγινε !", "(" + DataGrid.SelectedRows.Count.ToString() + ")");

                };

                ToolStripMenuItem ViewMenuItem23 = new ToolStripMenuItem(s_images);
                ViewMenuItem23.Click += (object sender, EventArgs e) =>
                {
                    if (MessageBox.Show("Θέλεις ενημέρωση των εικόνων των ειδών ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadImagesMtlXML();
                        MessageBox.Show("Επεξεργάστηκα " + DataGrid.SelectedRows.Count.ToString() + " προιόντα !");
                    }
                    else
                        MessageBox.Show("Η εργασία δεν έγινε !", "(" + DataGrid.SelectedRows.Count.ToString() + ")");

                };

                ToolStripMenuItem ViewMenuItem24 = new ToolStripMenuItem(s_data);
                ViewMenuItem24.Click += (object sender, EventArgs e) =>
                {
                    if (MessageBox.Show("Θέλεις ενημέρωση όλων των δεδομένων των ειδών ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadFilPinMtlXML();
                        LoadDescriptionsMtlXML();
                        LoadTimesMtlXML();
                        LoadYpoloipaMtlXML();
                        LoadImagesMtlXML();
                        MessageBox.Show("Επεξεργάστηκα " + DataGrid.SelectedRows.Count.ToString() + " προιόντα !");
                    }
                    else
                        MessageBox.Show("Η εργασία δεν έγινε !", "(" + DataGrid.SelectedRows.Count.ToString() + ")");
                };

                ToolStripMenuItem ViewMenuItem25 = new ToolStripMenuItem(s_filpin);
                ViewMenuItem25.Click += (object sender, EventArgs e) =>
                {
                    if (MessageBox.Show("Θέλεις ενημέρωση των παραμέτρων των ειδών ;", "Προσοχή !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        LoadFilPinMtlXML();
                        MessageBox.Show("Επεξεργάστηκα της παραμετρους των ειδών !");
                    }
                    else
                        MessageBox.Show("Η εργασία δεν έγινε !", "(" + DataGrid.SelectedRows.Count.ToString() + ")");
                };

                ToolStripDropDownButton menuView2 = new ToolStripDropDownButton("Ενημερώσεις !");
                menuView2.DropDownItems.AddRange(new ToolStripItem[] { ViewMenuItem20,
                                                                   ViewMenuItem21,
                                                                   ViewMenuItem22,
                                                                   ViewMenuItem23,
                                                                   new ToolStripSeparator(),
                                                                   ViewMenuItem25,
                                                                   new ToolStripSeparator(),
                                                                   ViewMenuItem24 });

                // Add to main menu
                menu.Items.AddRange(new ToolStripItem[] { menuView2 });

                pb.Alignment = ToolStripItemAlignment.Right;
                menu.Items.Add(pb);

                tl.Alignment = ToolStripItemAlignment.Left;
                menu.Items.Add(tl);
            }

        }

        private void LoadDescriptionsMtlXML()
        {
            tl.Text = s_stoixein;
            menu.Refresh();
            Cursor.Current = Cursors.WaitCursor;  
            accountsClassLibrary.ItemMtlFlModel m = new accountsClassLibrary.ItemMtlFlModel();
            //List<accountsClassLibrary.ItemMtlFlModel> data = new List<accountsClassLibrary.ItemMtlFlModel>();
            accountsClassLibrary.MtlFl read = new accountsClassLibrary.MtlFl();
            pb.Maximum = DataGrid.SelectedRows.Count - 1;
            for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
            {
                m.id = DataGrid.SelectedRows[i].Cells["Id"].Value.ToString();
                m.BCode = DataGrid.SelectedRows[i].Cells["BCode"].Value.ToString();
                m.BCodeBox = DataGrid.SelectedRows[i].Cells["BCode"].Value.ToString();
                m.Category.id = DataGrid.SelectedRows[i].Cells["Category"].Value.ToString();
                m.Contain = Convert.ToDouble(DataGrid.SelectedRows[i].Cells["Contain"].Value.ToString());
                m.Description = DataGrid.SelectedRows[i].Cells["Description"].Value.ToString();
                m.ePosition = DataGrid.SelectedRows[i].Cells["ePosition"].Value.ToString();
                m.eShop = DataGrid.SelectedRows[i].Cells["eShop"].Value.ToString();
                m.Facebook = DataGrid.SelectedRows[i].Cells["Facebook"].Value.ToString();
                m.Family.id = DataGrid.SelectedRows[i].Cells["Family"].Value.ToString();
                m.KindOfTax.id = DataGrid.SelectedRows[i].Cells["KindOfTax"].Value.ToString();
                m.Memo = DataGrid.SelectedRows[i].Cells["Memo"].Value.ToString();
                m.MoMe.id = DataGrid.SelectedRows[i].Cells["MoMe"].Value.ToString();
                m.Paremferi = DataGrid.SelectedRows[i].Cells["Paremferi"].Value.ToString();
                m.Status.id = DataGrid.SelectedRows[i].Cells["Status"].Value.ToString();
                m.WebSite = DataGrid.SelectedRows[i].Cells["WebSite"].Value.ToString();
                m.YouTube = DataGrid.SelectedRows[i].Cells["YouTube"].Value.ToString();
                read.Fields = m;
                if (read.ReadIfExist(m.id)) 
                    read.Update();
                else 
                    read.Insert();
                //data.Add(m);
                pb.Value = i;             
            }


            //if (Directory.Exists(@"C:\WinPlan_XML") == false) Directory.CreateDirectory(@"C:\WinPlan_XML");
            //using (FileStream fs = new FileStream(@"C:\WinPlan_xml\mtlfl.xml", FileMode.Create))
            //      new XmlSerializer(typeof(List<accountsClassLibrary.ItemMtlFlModel>)).Serialize(fs, data);
            
            pb.Value = 0;
            Cursor.Current = Cursors.Default;
        }
       
        private void LoadTimesMtlXML()
        {
            tl.Text = s_timon;
            menu.Refresh();
            Cursor.Current = Cursors.WaitCursor;
                     
            accountsClassLibrary.ItemTimesModel t = new accountsClassLibrary.ItemTimesModel();
            //List<accountsClassLibrary.ItemTimesModel> data = new List<accountsClassLibrary.ItemTimesModel>();
            DataTable dt = new DataTable();
            pb.Maximum = DataGrid.SelectedRows.Count - 1;
            accountsClassLibrary.Times times = new accountsClassLibrary.Times();
            for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
            {                                                    
                    dt = times.ReadZoomWinPlan(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                    times.DeleteAllPrices(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {                       
                        t = new accountsClassLibrary.ItemTimesModel();
                        t.Product = dt.Rows[x]["Product"].ToString();
                        t.PEkpt = Convert.ToDouble(dt.Rows[x]["PEkpt"]);
                        t.Price = Convert.ToDouble(dt.Rows[x]["Price"]);
                        t.PriceList.id = dt.Rows[x]["PriceList"].ToString();
                        //data.Add(t);                   
                        times.Fields = t;
                        times.Insert();
                }
               
                pb.Value = i;
            }

            //if (Directory.Exists(@"C:\WinPlan_XML") == false) Directory.CreateDirectory(@"C:\WinPlan_XML");
            //using (FileStream fs = new FileStream(@"C:\WinPlan_xml\times.xml", FileMode.Create))
            //    new XmlSerializer(typeof(List<accountsClassLibrary.ItemTimesModel>)).Serialize(fs, data);

            pb.Value = 0;
            Cursor.Current = Cursors.Default;
        }
       
        private void LoadYpoloipaMtlXML()
        {
            tl.Text = s_ypol;
            menu.Refresh();
            Cursor.Current = Cursors.WaitCursor;          

            accountsClassLibrary.ItemYpoloipaModel y = new accountsClassLibrary.ItemYpoloipaModel();
            //List<accountsClassLibrary.ItemYpoloipaModel> data = new List<accountsClassLibrary.ItemYpoloipaModel>();
            accountsClassLibrary.Ypoloipa ypoloipa = new accountsClassLibrary.Ypoloipa();
            DataTable dt = new DataTable();
            pb.Maximum = DataGrid.SelectedRows.Count - 1;
            for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
            {
                ypoloipa.DeleteAllYpoloipa(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                dt = ypoloipa.ReadZoomWinPlan(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());                
                for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        y = new accountsClassLibrary.ItemYpoloipaModel();
                        y.id = dt.Rows[x]["id"].ToString();
                        y.id1 = dt.Rows[x]["id1"].ToString();
                        y.Description1 = dt.Rows[x]["Description1"].ToString();
                        y.id2 = dt.Rows[x]["id2"].ToString();
                        y.Description2 = dt.Rows[x]["Description2"].ToString();
                        y.Ypoloipo = Convert.ToDouble(dt.Rows[x]["Ypoloipo"]);
                        ypoloipa.Fields = y;
                        ypoloipa.Insert();
                        //data.Add(y);
                }
                pb.Value = i;
            }
            //if (Directory.Exists(@"C:\WinPlan_XML") == false) Directory.CreateDirectory(@"C:\WinPlan_XML");
            //using (FileStream fs = new FileStream(@"C:\WinPlan_xml\ypoloipa.xml", FileMode.Create))
            //    new XmlSerializer(typeof(List<accountsClassLibrary.ItemYpoloipaModel>)).Serialize(fs, data);
            pb.Value = 0;
            Cursor.Current = Cursors.Default;
        }
      
        private void LoadImagesMtlXML()
        {
            tl.Text = s_images;
            menu.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            
            //List<accountsClassLibrary.ItemMtlFl_ImagesModel> data = new List<accountsClassLibrary.ItemMtlFl_ImagesModel>();
            accountsClassLibrary.ItemMtlFl_ImagesModel p = new accountsClassLibrary.ItemMtlFl_ImagesModel();
            accountsClassLibrary.MtlFl_Images picture = new accountsClassLibrary.MtlFl_Images();
            DataTable dt = new DataTable();
            ImageConverter converter = new ImageConverter();
            alphaFrameWork.AlphaFramework a = new alphaFrameWork.AlphaFramework();
            pb.Maximum = DataGrid.SelectedRows.Count - 1;
            for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
            {
                dt = picture.ReadZoomWinPlan(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                picture.DeleteAllImages(DataGrid.SelectedRows[i].Cells["Id"].Value.ToString());
                
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    p = new accountsClassLibrary.ItemMtlFl_ImagesModel();
                    p.id = dt.Rows[x]["id"].ToString();
                    p.Description = dt.Rows[x]["Description"].ToString();
                    p.Picture = (byte[])dt.Rows[x]["Picture"];
                    p.Status.id = dt.Rows[x]["Status"].ToString();
                    p.Type.id = dt.Rows[x]["Type"].ToString();
                    picture.Fields = p;
                    picture.Insert();
                    //data.Add(p);
                }                
                pb.Value = i;
            }
            //if (Directory.Exists(@"C:\WinPlan_XML") == false) Directory.CreateDirectory(@"C:\WinPlan_XML");
            //using (FileStream fs = new FileStream(@"C:\WinPlan_xml\mtlfl_images.xml", FileMode.Create))
            //    new XmlSerializer(typeof(List<accountsClassLibrary.ItemMtlFl_ImagesModel>)).Serialize(fs, data);
                        
            pb.Value = 0;
            Cursor.Current = Cursors.Default;
        }     

        private void LoadFilPinMtlXML()
        {
            tl.Text = s_filpin;
            menu.Refresh();
            Cursor.Current = Cursors.WaitCursor;
            
            accountsClassLibrary.FilPin f = new accountsClassLibrary.FilPin();
            accountsClassLibrary.ItemFilPinModel p = new accountsClassLibrary.ItemFilPinModel();
            //List<accountsClassLibrary.ItemFilPinModel> data = new List<accountsClassLibrary.ItemFilPinModel>();
            DataTable dt = new DataTable();
            f.DeleteWinPlan();
            dt = f.ReadZoomWinPlan();
            pb.Maximum = dt.Rows.Count - 1;            
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                p = new accountsClassLibrary.ItemFilPinModel();
                p.id = dt.Rows[i]["id"].ToString();
                p.Name = dt.Rows[i]["Name"].ToString();
                p.Status.id = dt.Rows[i]["Status"].ToString();
                p.Flag0 = true;               
                p.Picture = new byte[0];
                //data.Add(p);
                f.Fields = p;
                f.InsertWinPlan();
                pb.Value = i;
            }
            
            //if (Directory.Exists(@"C:\WinPlan_XML") == false) Directory.CreateDirectory(@"C:\WinPlan_XML");
            //using (FileStream fs = new FileStream(@"C:\WinPlan_xml\filpin.xml", FileMode.Create))
            //    new XmlSerializer(typeof(List<accountsClassLibrary.ItemFilPinModel>)).Serialize(fs, data);
            pb.Value = 0;
            Cursor.Current = Cursors.Default;
        }
  
        public override void LoadDefaultCombos(System.Windows.Forms.ComboBox searchBox)
        {
            searchBox.DisplayMember = "Name";
            searchBox.ValueMember = "id";
            searchBox.DataSource = new accountsClassLibrary.FilPin("%").ReadZoom(accountsClassLibrary.FilPin.TypeOfPin.CategoryMtl);
        }
    }
}
