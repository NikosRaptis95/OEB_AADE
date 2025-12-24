namespace DesktopBusiness.MForms
{
    partial class frmSynFl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.megaText_id = new templates.UserControls.megaText();
            this.megaText_Name = new templates.UserControls.megaText();
            this.megaText_Address = new templates.UserControls.megaText();
            this.megaText_PhoneNo = new templates.UserControls.megaText();
            this.megaText_AFM = new templates.UserControls.megaText();
            this.megaText_DOY = new templates.UserControls.megaText();
            this.megaText_Line = new templates.UserControls.megaText();
            this.megaCombo_Occupation = new templates.UserControls.megaCombo();
            this.megaCombo_Category = new templates.UserControls.megaCombo();
            this.megaCombo_KindOfTax = new templates.UserControls.megaCombo();
            this.megaCombo_PriceList = new templates.UserControls.megaCombo();
            this.megaText_WebSite = new templates.UserControls.megaText();
            this.megaText_eMail = new templates.UserControls.megaText();
            this.megaCombo_Kind = new templates.UserControls.megaCombo();
            this.megaText_Map = new templates.UserControls.megaText();
            this.megaCombo_Status = new templates.UserControls.megaCombo();
            this.megaText_Memo = new templates.UserControls.megaText();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tabControl1.Size = new System.Drawing.Size(1204, 763);
            // 
            // Page1
            // 
            this.Page1.AutoScroll = true;
            this.Page1.Controls.Add(this.tableLayoutPanel1);
            this.Page1.Location = new System.Drawing.Point(4, 25);
            this.Page1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Page1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Page1.Size = new System.Drawing.Size(1196, 734);
            this.Page1.Text = "στοιχεία εγγραφής";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.megaText_Memo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1186, 724);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.megaText_id, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaText_Name, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaText_Address, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_PhoneNo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_AFM, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.megaText_DOY, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.megaText_Line, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_Occupation, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_Category, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_KindOfTax, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_PriceList, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.megaText_WebSite, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.megaText_eMail, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_Kind, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.megaText_Map, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_Status, 1, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1178, 509);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // megaText_id
            // 
            this.megaText_id.AutoSize = true;
            this.megaText_id.datafield = "id";
            this.megaText_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_id.Location = new System.Drawing.Point(5, 5);
            this.megaText_id.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_id.Name = "megaText_id";
            this.megaText_id.Size = new System.Drawing.Size(579, 53);
            this.megaText_id.TabIndex = 0;
            this.megaText_id.Text_Default = null;
            this.megaText_id.Text_Height = 21;
            this.megaText_id.Text_IsNumber = false;
            this.megaText_id.Text_Label = "κωδικός";
            this.megaText_id.Text_MaxLength = 60;
            this.megaText_id.Text_Multiline = false;
            this.megaText_id.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_id.Text_Textbox = "";
            // 
            // megaText_Name
            // 
            this.megaText_Name.AutoSize = true;
            this.megaText_Name.datafield = "Name";
            this.megaText_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Name.Location = new System.Drawing.Point(594, 5);
            this.megaText_Name.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_Name.Name = "megaText_Name";
            this.megaText_Name.Size = new System.Drawing.Size(579, 53);
            this.megaText_Name.TabIndex = 1;
            this.megaText_Name.Text_Default = null;
            this.megaText_Name.Text_Height = 21;
            this.megaText_Name.Text_IsNumber = false;
            this.megaText_Name.Text_Label = "όνομα ή επωνυμία";
            this.megaText_Name.Text_MaxLength = 100;
            this.megaText_Name.Text_Multiline = false;
            this.megaText_Name.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Name.Text_Textbox = "";
            // 
            // megaText_Address
            // 
            this.megaText_Address.AutoSize = true;
            this.megaText_Address.datafield = "Address";
            this.megaText_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Address.Location = new System.Drawing.Point(5, 68);
            this.megaText_Address.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_Address.Name = "megaText_Address";
            this.megaText_Address.Size = new System.Drawing.Size(579, 53);
            this.megaText_Address.TabIndex = 2;
            this.megaText_Address.Text_Default = null;
            this.megaText_Address.Text_Height = 21;
            this.megaText_Address.Text_IsNumber = false;
            this.megaText_Address.Text_Label = "διεύθυνση";
            this.megaText_Address.Text_MaxLength = 100;
            this.megaText_Address.Text_Multiline = false;
            this.megaText_Address.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Address.Text_Textbox = "";
            // 
            // megaText_PhoneNo
            // 
            this.megaText_PhoneNo.AutoSize = true;
            this.megaText_PhoneNo.datafield = "PhoneNo";
            this.megaText_PhoneNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_PhoneNo.Location = new System.Drawing.Point(594, 68);
            this.megaText_PhoneNo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_PhoneNo.Name = "megaText_PhoneNo";
            this.megaText_PhoneNo.Size = new System.Drawing.Size(579, 53);
            this.megaText_PhoneNo.TabIndex = 3;
            this.megaText_PhoneNo.Text_Default = null;
            this.megaText_PhoneNo.Text_Height = 21;
            this.megaText_PhoneNo.Text_IsNumber = false;
            this.megaText_PhoneNo.Text_Label = "τηλέφωνο";
            this.megaText_PhoneNo.Text_MaxLength = 50;
            this.megaText_PhoneNo.Text_Multiline = false;
            this.megaText_PhoneNo.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_PhoneNo.Text_Textbox = "";
            // 
            // megaText_AFM
            // 
            this.megaText_AFM.AutoSize = true;
            this.megaText_AFM.datafield = "AFM";
            this.megaText_AFM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_AFM.Location = new System.Drawing.Point(5, 131);
            this.megaText_AFM.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_AFM.Name = "megaText_AFM";
            this.megaText_AFM.Size = new System.Drawing.Size(579, 53);
            this.megaText_AFM.TabIndex = 4;
            this.megaText_AFM.Text_Default = null;
            this.megaText_AFM.Text_Height = 21;
            this.megaText_AFM.Text_IsNumber = false;
            this.megaText_AFM.Text_Label = "ΑΦΜ";
            this.megaText_AFM.Text_MaxLength = 20;
            this.megaText_AFM.Text_Multiline = false;
            this.megaText_AFM.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_AFM.Text_Textbox = "";
            // 
            // megaText_DOY
            // 
            this.megaText_DOY.AutoSize = true;
            this.megaText_DOY.datafield = "DOY";
            this.megaText_DOY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_DOY.Location = new System.Drawing.Point(594, 131);
            this.megaText_DOY.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_DOY.Name = "megaText_DOY";
            this.megaText_DOY.Size = new System.Drawing.Size(579, 53);
            this.megaText_DOY.TabIndex = 5;
            this.megaText_DOY.Text_Default = null;
            this.megaText_DOY.Text_Height = 21;
            this.megaText_DOY.Text_IsNumber = false;
            this.megaText_DOY.Text_Label = "ΔΟΥ";
            this.megaText_DOY.Text_MaxLength = 60;
            this.megaText_DOY.Text_Multiline = false;
            this.megaText_DOY.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_DOY.Text_Textbox = "";
            // 
            // megaText_Line
            // 
            this.megaText_Line.AutoSize = true;
            this.megaText_Line.datafield = "Line";
            this.megaText_Line.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Line.Location = new System.Drawing.Point(5, 194);
            this.megaText_Line.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_Line.Name = "megaText_Line";
            this.megaText_Line.Size = new System.Drawing.Size(579, 53);
            this.megaText_Line.TabIndex = 6;
            this.megaText_Line.Text_Default = null;
            this.megaText_Line.Text_Height = 21;
            this.megaText_Line.Text_IsNumber = false;
            this.megaText_Line.Text_Label = "σειρά";
            this.megaText_Line.Text_MaxLength = 20;
            this.megaText_Line.Text_Multiline = false;
            this.megaText_Line.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Line.Text_Textbox = "";
            // 
            // megaCombo_Occupation
            // 
            this.megaCombo_Occupation.AutoSize = true;
            this.megaCombo_Occupation.datafield = "Occupation";
            this.megaCombo_Occupation.DataSource = null;
            this.megaCombo_Occupation.DisplayMember = "Name";
            this.megaCombo_Occupation.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Occupation.Location = new System.Drawing.Point(594, 194);
            this.megaCombo_Occupation.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaCombo_Occupation.Name = "megaCombo_Occupation";
            this.megaCombo_Occupation.Size = new System.Drawing.Size(579, 41);
            this.megaCombo_Occupation.TabIndex = 7;
            this.megaCombo_Occupation.Text_Label = "Επάγγελμα";
            this.megaCombo_Occupation.Text_Textbox = "";
            this.megaCombo_Occupation.ValueMember = "id";
            // 
            // megaCombo_Category
            // 
            this.megaCombo_Category.AutoSize = true;
            this.megaCombo_Category.datafield = "Category";
            this.megaCombo_Category.DataSource = null;
            this.megaCombo_Category.DisplayMember = "Name";
            this.megaCombo_Category.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Category.Location = new System.Drawing.Point(5, 257);
            this.megaCombo_Category.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaCombo_Category.Name = "megaCombo_Category";
            this.megaCombo_Category.Size = new System.Drawing.Size(579, 41);
            this.megaCombo_Category.TabIndex = 8;
            this.megaCombo_Category.Text_Label = "Κατηγορία";
            this.megaCombo_Category.Text_Textbox = "";
            this.megaCombo_Category.ValueMember = "id";
            // 
            // megaCombo_KindOfTax
            // 
            this.megaCombo_KindOfTax.AutoSize = true;
            this.megaCombo_KindOfTax.datafield = "KindOfTax";
            this.megaCombo_KindOfTax.DataSource = null;
            this.megaCombo_KindOfTax.DisplayMember = "Name";
            this.megaCombo_KindOfTax.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_KindOfTax.Location = new System.Drawing.Point(594, 257);
            this.megaCombo_KindOfTax.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaCombo_KindOfTax.Name = "megaCombo_KindOfTax";
            this.megaCombo_KindOfTax.Size = new System.Drawing.Size(579, 41);
            this.megaCombo_KindOfTax.TabIndex = 9;
            this.megaCombo_KindOfTax.Text_Label = "Κατηγορία ΦΠΑ";
            this.megaCombo_KindOfTax.Text_Textbox = "";
            this.megaCombo_KindOfTax.ValueMember = "id";
            // 
            // megaCombo_PriceList
            // 
            this.megaCombo_PriceList.AutoSize = true;
            this.megaCombo_PriceList.datafield = "PriceList";
            this.megaCombo_PriceList.DataSource = null;
            this.megaCombo_PriceList.DisplayMember = "Name";
            this.megaCombo_PriceList.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_PriceList.Location = new System.Drawing.Point(5, 320);
            this.megaCombo_PriceList.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaCombo_PriceList.Name = "megaCombo_PriceList";
            this.megaCombo_PriceList.Size = new System.Drawing.Size(579, 41);
            this.megaCombo_PriceList.TabIndex = 10;
            this.megaCombo_PriceList.Text_Label = "Κατηγορία Τιμοκαταλόγου";
            this.megaCombo_PriceList.Text_Textbox = "";
            this.megaCombo_PriceList.ValueMember = "id";
            // 
            // megaText_WebSite
            // 
            this.megaText_WebSite.AutoSize = true;
            this.megaText_WebSite.datafield = "WebSite";
            this.megaText_WebSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_WebSite.Location = new System.Drawing.Point(594, 320);
            this.megaText_WebSite.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_WebSite.Name = "megaText_WebSite";
            this.megaText_WebSite.Size = new System.Drawing.Size(579, 53);
            this.megaText_WebSite.TabIndex = 11;
            this.megaText_WebSite.Text_Default = null;
            this.megaText_WebSite.Text_Height = 21;
            this.megaText_WebSite.Text_IsNumber = false;
            this.megaText_WebSite.Text_Label = "web site (facebook)";
            this.megaText_WebSite.Text_MaxLength = 100;
            this.megaText_WebSite.Text_Multiline = false;
            this.megaText_WebSite.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_WebSite.Text_Textbox = "";
            // 
            // megaText_eMail
            // 
            this.megaText_eMail.AutoSize = true;
            this.megaText_eMail.datafield = "eMail";
            this.megaText_eMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_eMail.Location = new System.Drawing.Point(5, 383);
            this.megaText_eMail.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_eMail.Name = "megaText_eMail";
            this.megaText_eMail.Size = new System.Drawing.Size(579, 53);
            this.megaText_eMail.TabIndex = 12;
            this.megaText_eMail.Text_Default = null;
            this.megaText_eMail.Text_Height = 21;
            this.megaText_eMail.Text_IsNumber = false;
            this.megaText_eMail.Text_Label = "eMail";
            this.megaText_eMail.Text_MaxLength = 100;
            this.megaText_eMail.Text_Multiline = false;
            this.megaText_eMail.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_eMail.Text_Textbox = "";
            // 
            // megaCombo_Kind
            // 
            this.megaCombo_Kind.AutoSize = true;
            this.megaCombo_Kind.datafield = "Kind";
            this.megaCombo_Kind.DataSource = null;
            this.megaCombo_Kind.DisplayMember = "Name";
            this.megaCombo_Kind.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Kind.Location = new System.Drawing.Point(594, 383);
            this.megaCombo_Kind.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaCombo_Kind.Name = "megaCombo_Kind";
            this.megaCombo_Kind.Size = new System.Drawing.Size(579, 41);
            this.megaCombo_Kind.TabIndex = 13;
            this.megaCombo_Kind.Text_Label = "Τύπος";
            this.megaCombo_Kind.Text_Textbox = "";
            this.megaCombo_Kind.ValueMember = "id";
            // 
            // megaText_Map
            // 
            this.megaText_Map.AutoSize = true;
            this.megaText_Map.datafield = "Map";
            this.megaText_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Map.Location = new System.Drawing.Point(5, 446);
            this.megaText_Map.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_Map.Name = "megaText_Map";
            this.megaText_Map.Size = new System.Drawing.Size(579, 58);
            this.megaText_Map.TabIndex = 14;
            this.megaText_Map.Text_Default = null;
            this.megaText_Map.Text_Height = 21;
            this.megaText_Map.Text_IsNumber = false;
            this.megaText_Map.Text_Label = "τοποθεσία";
            this.megaText_Map.Text_MaxLength = 60;
            this.megaText_Map.Text_Multiline = false;
            this.megaText_Map.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Map.Text_Textbox = "";
            // 
            // megaCombo_Status
            // 
            this.megaCombo_Status.AutoSize = true;
            this.megaCombo_Status.datafield = "Status";
            this.megaCombo_Status.DataSource = null;
            this.megaCombo_Status.DisplayMember = "Name";
            this.megaCombo_Status.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Status.Location = new System.Drawing.Point(594, 446);
            this.megaCombo_Status.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaCombo_Status.Name = "megaCombo_Status";
            this.megaCombo_Status.Size = new System.Drawing.Size(579, 41);
            this.megaCombo_Status.TabIndex = 15;
            this.megaCombo_Status.Text_Label = "Status";
            this.megaCombo_Status.Text_Textbox = "";
            this.megaCombo_Status.ValueMember = "id";
            // 
            // megaText_Memo
            // 
            this.megaText_Memo.AutoSize = true;
            this.megaText_Memo.datafield = "Memo";
            this.megaText_Memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Memo.Location = new System.Drawing.Point(5, 522);
            this.megaText_Memo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.megaText_Memo.Name = "megaText_Memo";
            this.megaText_Memo.Size = new System.Drawing.Size(1176, 197);
            this.megaText_Memo.TabIndex = 16;
            this.megaText_Memo.Text_Default = null;
            this.megaText_Memo.Text_Height = 171;
            this.megaText_Memo.Text_IsNumber = false;
            this.megaText_Memo.Text_Label = "σημειώσεις";
            this.megaText_Memo.Text_MaxLength = 32767;
            this.megaText_Memo.Text_Multiline = true;
            this.megaText_Memo.Text_ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.megaText_Memo.Text_Textbox = "";
            // 
            // frmSynFl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1204, 784);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmSynFl";
            this.Text = "συναλλασσόμενοι";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private templates.UserControls.megaText megaText_id;
        private templates.UserControls.megaText megaText_Name;
        private templates.UserControls.megaText megaText_Address;
        private templates.UserControls.megaText megaText_PhoneNo;
        private templates.UserControls.megaText megaText_AFM;
        private templates.UserControls.megaText megaText_DOY;
        private templates.UserControls.megaText megaText_Line;
        private templates.UserControls.megaCombo megaCombo_Occupation;
        private templates.UserControls.megaCombo megaCombo_Category;
        private templates.UserControls.megaCombo megaCombo_KindOfTax;
        private templates.UserControls.megaCombo megaCombo_PriceList;
        private templates.UserControls.megaText megaText_WebSite;
        private templates.UserControls.megaText megaText_eMail;
        private templates.UserControls.megaCombo megaCombo_Kind;
        private templates.UserControls.megaText megaText_Map;
        private templates.UserControls.megaCombo megaCombo_Status;
        private templates.UserControls.megaText megaText_Memo;
    }
}