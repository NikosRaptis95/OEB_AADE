using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System.Drawing.Printing;
using System.Data;
using DataGridViewAutoFilter;
using System.Timers;

namespace templates.Forms
{
    public partial class CallFrm : templates.Forms.def
    {

#region formDefinition
      
      public Boolean myModal = false;
      public Boolean updatestatus = false;
      S _s = new S(new alphaFrameWork.AlphaFramework().lang);
     
        public CallFrm()
       {
            InitializeComponent();
            LoadExtFilters();
            global.r.Clear();

         
        }


        private void CallFrm_Load(object sender, EventArgs e)
        {
            _CustomizeMenu();            
            LoadDefaultCombos(searchBox);
            if (this.searchBox.Text.Length != 0 && this.searchBox.Items.Count > 0) this.searchBox.Text = "";
            GetData_();

            ActionRefresh();
            
        }

        private void CallFrm_Resize(object sender, EventArgs e)
        {
        }
#endregion

#region ExtFilters

        ToolStripStatusLabel filterStatusLabel = new ToolStripStatusLabel();
        ToolStripStatusLabel showAllLabel = new ToolStripStatusLabel("Show &All");
        private void LoadExtFilters()
        {
            showAllLabel.Visible = false;
            showAllLabel.IsLink = true;
            showAllLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            showAllLabel.Click += new EventHandler(showAllLabel_Click);

            menu.Items.Insert(0, filterStatusLabel);
            menu.Items.Insert(0, showAllLabel);

            DataGrid.BindingContextChanged += new EventHandler(DataGrid_BindingContextChanged);
            DataGrid.KeyDown += new KeyEventHandler(DataGrid_KeyDown);
            DataGrid.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(DataGrid_DataBindingComplete);
        }
        private void DataGrid_BindingContextChanged(object sender, EventArgs e)
        {
            if (DataGrid.DataSource == null) return;
            foreach (DataGridViewColumn col in DataGrid.Columns)
                col.HeaderCell = new DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
        }

        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up))
            {
                DataGridViewAutoFilterColumnHeaderCell filterCell = DataGrid.CurrentCell.OwningColumn.HeaderCell as DataGridViewAutoFilterColumnHeaderCell;
                if (filterCell != null)
                {
                    filterCell.ShowDropDownList();
                    e.Handled = true;
                }
            }
        }

        private void DataGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            String filterStatus = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(DataGrid);
            if (String.IsNullOrEmpty(filterStatus))
            {
                showAllLabel.Visible = false;
                filterStatusLabel.Visible = false;
            }
            else
            {
                showAllLabel.Visible = true;
                filterStatusLabel.Visible = true;
                filterStatusLabel.Text = filterStatus;
            }
        }
        private void showAllLabel_Click(object sender, EventArgs e)
        {
            DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(DataGrid);
        }
#endregion


#region interface

        public virtual void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                List<string> s = new List<string>();
                for (int i = 0; i < idFieldName.Count; i++)
                    s.Add(DataGrid.SelectedRows[0].Cells[idFieldName[i]].Value.ToString());
                CallForm_(s);
            }
            catch { }
            if (this.ParentForm == null) { updatestatus = true; GetData_(); updatestatus = false; }
            if (new alphaFrameWork.AlphaFramework().GetCloseAfterSelection(this.Name)) this.Close();
        }

        public virtual void DataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { searchBox.Text = ""; }

       private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) {
                if (searchBox.Text == "insertCode") new tclass().insertCode(this.Name, BO, EXE);
                if (searchBox.Text == "editCode") new tclass().editCode(this.Name);
                GetData_(); }          
        }

       private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                tabPage1.Text = String.Format(_s.G(1) + ": {0}/{1}, "+ _s.G(2) + ": {2}/{3} " + new alphaFrameWork.AlphaFramework().GetZoomTop(this.Name), DataGrid.CurrentCell.RowIndex + 1, DataGrid.RowCount, DataGrid.CurrentCell.ColumnIndex + 1, DataGrid.ColumnCount);
            }
            catch { }
        }

#endregion

#region buttons

        private void menuSelect_Click(object sender, EventArgs e)
            {
                if (DataGrid.SelectedRows.Count > 0) { 
                    this.editMenuItem.Enabled = true;
                    this.deleteMenuItem.Enabled = true;
                }
                else { this.editMenuItem.Enabled = true;
                this.editMenuItem.Enabled = false;
                this.deleteMenuItem.Enabled = false;
                }
            try
            {
                string r = System.IO.File.ReadAllText("customization\\interface\\" + this.Name + "_Close.txt");
                if (r.Equals("True")) { trueToolStripMenuItem.Checked = true; falseToolStripMenuItem.Checked = false; }
                if (r.Equals("False")) { falseToolStripMenuItem.Checked = true; trueToolStripMenuItem.Checked = false; }
                UnckeckRecords();
                r = System.IO.File.ReadAllText("customization\\interface\\" + this.Name + "_Top.txt");
                if (r.Equals("0")) toolStripMenuItem5.Checked = true;
                if (r.Equals("10")) toolStripMenuItem6.Checked = true;
                if (r.Equals("200")) toolStripMenuItem7.Checked = true;
                if (r.Equals("400")) toolStripMenuItem8.Checked = true;
                if (r.Equals("1800")) toolStripMenuItem9.Checked = true;
                UnckeckRefresh();
                r = System.IO.File.ReadAllText("customization\\interface\\" + this.Name + "_Refresh.txt");
                if (r.Equals("0")) neverToolStripMenuItem.Checked = true;
                if (r.Equals("3")) after3SecToolStripMenuItem.Checked = true;
                if (r.Equals("10")) after10SecToolStripMenuItem.Checked = true;
                if (r.Equals("60")) after1MinToolStripMenuItem.Checked = true;
            }
            catch { }
        }

        
        private void ActionRefresh()
        {           
            try
            {
                int i = Convert.ToInt16(System.IO.File.ReadAllText("customization\\interface\\" + this.Name + "_Refresh.txt"));
                if (i > 0)
                {
                    timer1.Interval = i * 1000;
                    timer1.Enabled = true; 
                }
                else timer1.Enabled = false;
            }
            catch { timer1.Enabled = false; }   
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetData_();
        }

        private void UnckeckRecords ()
        {
            toolStripMenuItem5.Checked = false;
            toolStripMenuItem6.Checked = false;
            toolStripMenuItem7.Checked = false;
            toolStripMenuItem8.Checked = false;
            toolStripMenuItem9.Checked = false;
        }

        private void UnckeckRefresh()
        {
            neverToolStripMenuItem.Checked = false;
            after3SecToolStripMenuItem.Checked = false;
            after10SecToolStripMenuItem.Checked = false;
            after1MinToolStripMenuItem.Checked = false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> s = new List<string>();
            s.Add("new");
            CallForm_(s);
            if (this.ParentForm == null) GetData_();
            else if (new alphaFrameWork.AlphaFramework().GetCloseAfterSelection(this.Name)) this.Close();
        }              
        
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(new alphaFrameWork.AlphaFramework().getStr(DataGrid), _s.G(3) + " ?", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {  for (int i = 0; i < DataGrid.SelectedRows.Count; i++) {
                    List<string> s = new List<string>();                    
                    for (int ii = 0; ii < idFieldName.Count; ii++)
                        s.Add(DataGrid.SelectedRows[i].Cells[idFieldName[ii]].Value.ToString());                                        
                    CallForm_(s);
                }
                if (this.ParentForm == null) { updatestatus = true;  GetData_(); updatestatus = false; } 
                else if(new alphaFrameWork.AlphaFramework().GetCloseAfterSelection(this.Name)) this.Close(); }
            else MessageBox.Show(_s.G(5) + " !", _s.G(3) + " !");                       
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if (MessageBox.Show(new alphaFrameWork.AlphaFramework().getStr(DataGrid), _s.G(4) + " ?", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.Yes)
                { for (int i = 0; i < DataGrid.SelectedRows.Count; i++) {
                        List<string> s = new List<string>();
                        for (int ii = 0; ii < idFieldName.Count; ii++)
                            s.Add(DataGrid.SelectedRows[i].Cells[idFieldName[ii]].Value.ToString());
                        Delete_(s);
                    }
                    GetData_(); }
            else MessageBox.Show(_s.G(5) + " !", _s.G(4) + " !");            
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetData_(); 
        }

       
        private void toolStripMenuItem5_Click(object sender, EventArgs e) // 0 records
        {  System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Top.txt", "0"); }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) // 10 records
        {  System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Top.txt", "10");  }

        private void toolStripMenuItem7_Click(object sender, EventArgs e) // 200 records
        {  System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Top.txt", "200"); }

        private void toolStripMenuItem8_Click(object sender, EventArgs e) // 400 records
        {  System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Top.txt", "400"); }

        private void toolStripMenuItem9_Click(object sender, EventArgs e) // 1800 records
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Top.txt", "1800"); }

        private void trueToolStripMenuItem_Click(object sender, EventArgs e)
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Close.txt", "True");  }

        private void falseToolStripMenuItem_Click(object sender, EventArgs e)
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Close.txt", "False"); }

        private void neverToolStripMenuItem_Click(object sender, EventArgs e)
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Refresh.txt", "0"); ActionRefresh(); }

        private void after3SecToolStripMenuItem_Click(object sender, EventArgs e)
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Refresh.txt", "3"); ActionRefresh(); }

        private void after10SecToolStripMenuItem_Click(object sender, EventArgs e)
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Refresh.txt", "10"); ActionRefresh(); }

        private void after1MinToolStripMenuItem_Click(object sender, EventArgs e)
        { System.IO.File.WriteAllText("customization\\interface\\" + this.Name + "_Refresh.txt", "60"); ActionRefresh(); }

        #endregion

        #region virtual functions, general functions & variables
        private List<string> idFieldName = new List<string>();
        public virtual void LoadDefaultCombos(ComboBox searchBox) { }       
        private void CallForm_(List<string> id)
        {
            if (myModal == true)
            { global.r = id;
                this.Close(); 
            }
            else
            {
                try {
                    def myForm = CallForm(id);
                    myForm.Caller = this;
                    if (this.ParentForm == null)
                        myForm.ShowDialog();
                    else
                    {
                        myForm.MdiParent = this.ParentForm;
                        myForm.Show();
                    }                   
                }
                catch { }             
            }                        
        }       
        public virtual def CallForm(List<string> id)  { return(new def()); }
        private void GetData_()
        {
            Cursor.Current = Cursors.WaitCursor;           
            // Προσδιορισμός του ορίσματος
            String strFind = searchBox.Text;
            if (checkBox1.Checked == true) { strFind += checkBox1.Text; }
            if (checkBox2.Checked == true) { strFind = checkBox2.Text + strFind; }                   
            idFieldName = GetData(strFind);
            Cursor.Current = Cursors.Default;
        }
        public virtual List<string> GetData(string strFind) { List<string> s = new List<string>(); s.Add("id") ;  return (s); }
        public virtual void Delete_(List<string> id)
        {
            string resultString = Delete(id);
            if (resultString.Equals("") == false) { MessageBox.Show(resultString, _s.G(4) + " !"); }
        }
        public virtual string Delete(List<string> id) { return (_s.G(6) + " !"); }
        private void _CustomizeMenu() {
            menuSelect.Text = _s.G(19);
            refreshMenuItem.Text = _s.G(20);
            toolParams.Text = _s.G(21);
            topRecordsToolStripMenuItem1.Text = _s.G(22);
            closeAfterSelectionToolStripMenuItem.Text = _s.G(23);
            deleteMenuItem.Text = _s.G(4);
            newMenuItem.Text = _s.G(24);
            editMenuItem.Text = _s.G(3);
            CustomizeMenu(); }
        public virtual void CustomizeMenu() { }
        #endregion

        #region Action Function

        private void DataGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();                              
                int currentMouseOverRow = DataGrid.HitTest(e.X, e.Y).RowIndex;
                int currentMouseOverCol = DataGrid.HitTest(e.X, e.Y).ColumnIndex;
                if (currentMouseOverRow >= 0)
                {
                   
                    try
                    {
                        string c = DataGrid[currentMouseOverCol, currentMouseOverRow].Value.ToString();                       
                        MenuItem ViewMenuItem1 = new MenuItem(_s.G(9) + " ! " + c);
                        //ViewMenuItem1.Shortcut = Shortcut.CtrlC;
                        ViewMenuItem1.Click += (object sender_, EventArgs e_) =>
                        {
                            Clipboard.Clear();
                            Clipboard.SetText(c);
                        };
                        m.MenuItems.Add(ViewMenuItem1);
                    } catch { }

                    if (this.panel1.Visible)
                    {
                        try
                        {
                            string s = DataGrid.Columns[currentMouseOverCol].HeaderText;
                            MenuItem ViewMenuItem2 = new MenuItem(_s.G(7) + " " + s + " " + _s.G(8) + " !");
                            ViewMenuItem2.Click += (object sender_, EventArgs e_) =>
                            {
                                var vv = DataGrid.Rows.Cast<DataGridViewRow>()
                                   .Select(x => x.Cells[currentMouseOverCol].Value.ToString())
                                   .Distinct()
                                   .ToList();
                                searchBox.DataSource = null;
                                searchBox.Items.Clear();

                                for (int i = 0; i < vv.Count; i++)
                                    searchBox.Items.Add(vv[i].ToString());
                            };
                            m.MenuItems.Add(ViewMenuItem2);
                        }
                        catch { }
                    }

                }
                MenuItem ViewMenuItem0 = new MenuItem(_s.G(10)+ " !");
                ViewMenuItem0.Click += (object sender_, EventArgs e_) =>
                {
                    zpt(false);
                };
                MenuItem ViewMenuItem6 = new MenuItem(_s.G(11)+" !");
                ViewMenuItem6.Click += (object sender_, EventArgs e_) =>
                {
                    zpt(true);
                };

                MenuItem ViewMenuItem4 = new MenuItem(_s.G(12) + " !");
                ViewMenuItem4.Click += (object sender_, EventArgs e_) =>
                {
                    ExportXml();
                };

                MenuItem ViewMenuItem3 = new MenuItem(_s.G(13) + " !");                
                ViewMenuItem3.Click += (object sender_, EventArgs e_) =>
                {
                    ContextMenu mf = new ContextMenu();
                                        
                    for (int i = 0; i < DataGrid.Columns.Count; i++)
                    {
                        MenuItem ViewMenuItemMF0 = new MenuItem(DataGrid.Columns[i].DataPropertyName+" : "+DataGrid.Columns[i].HeaderText);                       
                        ViewMenuItemMF0.Click += (object sender_f, EventArgs e_f) =>
                        {
                       
                            new templates.Forms.CodeEditor("customization\\interface\\" + this.Name + ".txt").ShowDialog();

  

                        };
                        mf.MenuItems.Add(ViewMenuItemMF0);
                    }                    
                    mf.Show(DataGrid, new Point(e.X, e.Y));
                };

                MenuItem ViewMenuItem5 = new MenuItem(_s.G(14) + " !");
                ViewMenuItem5.Click += (object sender_, EventArgs e_) =>
                {
                    List<DataGridViewRow> gi = new List<DataGridViewRow>();
                    foreach (DataGridViewRow row in DataGrid.SelectedRows)
                                        { row.Selected = false; gi.Add(row); }
                    
                    foreach (DataGridViewRow row in gi)
                    { try { row.Visible = false; } catch { } }


                };

                m.MenuItems.AddRange(new MenuItem[] { ViewMenuItem0, ViewMenuItem6, ViewMenuItem4, ViewMenuItem3
                    
                });
                m.Show(DataGrid, new Point(e.X, e.Y));
            }
        }
       
        private string stringToPrint;
        private void zpt(Boolean dp)
        {
            PrintPreviewDialog ppDialog = new PrintPreviewDialog();

            int hsize = 20;
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            doc.DocumentName = this.Name;
            ppDialog.Document = doc;
            //stringToPrint = this.Text +"\n";

            stringToPrint = "";            

            for (int i = 0; i < DataGrid.SelectedRows.Count; i++)
            {
                for(int c=0; c<DataGrid.Columns.Count; c++)
                {
                    if (DataGrid.Columns[c].Visible)
                    {                        
                        string h = DataGrid.Columns[c].HeaderText;
                        if (h.Trim().ToUpper().Equals("VISIBLE=FALSE")) h = "";
                        if (h.Length >= hsize) h = h.Substring(0, hsize);
                        else for (int x = h.Length; x <= (hsize-1); x++) h += " ";
                        stringToPrint += (h+" "+ Convert.ToString(DataGrid.SelectedRows[i].Cells[c].Value)+ "\n");                        
                    }
                }
                stringToPrint += "\n\n";
            }


            if (dp)
            {
                if (MessageBox.Show(_s.G(15)+" "+_s.G(16)+" ;", _s.G(15) + " !", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    doc.Print();
            }
            else
            {
                ppDialog.ShowDialog();
            }

        }
        private void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {           
            int charactersOnPage = 0;
            int linesPerPage = 0;
            Font f = new Font("Courier New", 12);

            e.Graphics.MeasureString(stringToPrint, f,
                                     e.MarginBounds.Size, StringFormat.GenericDefault,
                                     out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(stringToPrint, f, Brushes.Black,
                                  e.MarginBounds, StringFormat.GenericDefault);

            stringToPrint = stringToPrint.Substring(charactersOnPage);

            e.HasMorePages = (stringToPrint.Length > 0);
        }
        private void ExportXml()
        {
            BindingSource bs = (BindingSource)DataGrid.DataSource; 
            DataTable dt = (DataTable)bs.DataSource;
            List<String> cols = new List<string>();

            for (int i = 0; i < dt.Columns.Count; i++)
                try
                {
                    if (DataGrid.Columns[i].HeaderText.ToUpper().Equals("VISIBLE=FALSE"))
                        cols.Add(dt.Columns[i].ColumnName);
                } catch { cols.Add(dt.Columns[i].ColumnName); }

            for (int i = 0; i < cols.Count; i++)
                dt.Columns.Remove(cols[i]);

            string p = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\" + this.Name + ".xml";
            dt.WriteXml(p);
            MessageBox.Show(_s.G(17)+" !\n"+p, _s.G(18)+ " !");
        }

        private void CallFrm_Activated(object sender, EventArgs e)
        {
            
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        { GetData_(); }
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
                            case 1: return "Γραμμή";
                            case 2: return "Κολώνα";
                            case 3: return "Επεξεργασία";
                            case 4: return "Διαγραφή";
                            case 5: return "Ακύρωση";
                            case 6: return "Σφάλμα";
                            case 7: return "Προσθέστε το πεδίο";
                            case 8: return "στο κουτί επιλογών";
                            case 9: return "Αντιγραφή";
                            case 10: return "Προεπισκόπηση Εκτύπωσης";
                            case 11: return "Απ'ευθείας Εκτύπωση";
                            case 12: return "Export (xml)";
                            case 13: return "Πεδία";
                            case 14: return "Κρύψε τις επιλεγμένες γραμμές";
                            case 15: return "Εκτύπωση";
                            case 16: return "στον default εκτυπωτή";
                            case 17: return "Το αρχειο δημιουργήθηκε";
                            case 18: return "Προσοχή";
                            case 19: return "Επιλογές";
                            case 20: return "Ανανέωση";
                            case 21: return "Ρυθμίσεις";
                            case 22: return "Ανάκτηση εγγραφών";
                            case 23: return "Κλείσιμο μετά την επιλογή";
                            case 24: return "Νέα εγγραφή";
                            default: return "Δεν βρέθηκε η συμβολοσειρά";
                        }
                    default:
                        switch (id)
                        {
                            case 1: return "Row";
                            case 2: return "Line";
                            case 3: return "Edit";
                            case 4: return "Delete";
                            case 5: return "Cancel";
                            case 6: return "Error";
                            case 7: return "Add field ";
                            case 8: return "to combo box";
                            case 9: return "Copy";
                            case 10: return "Preview";
                            case 11: return "Direct print";
                            case 12: return "Export (xml)";
                            case 13: return "Fields";
                            case 14: return "Hide the selected lines";
                            case 15: return "Print";
                            case 16: return "to default printer";
                            case 17: return "A file has been created";
                            case 18: return "Attention";
                            case 19: return "Options";
                            case 20: return "Refresh";
                            case 21: return "Settings";
                            case 22: return "Top Records";
                            case 23: return "Close after selection";
                            case 24: return "Insert";
                            default: return "String not found";
                        }

                }
            }

        }

       
    }

    


}


