namespace templates
{
    partial class dbConnection
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
            this.megaText_FileName = new templates.UserControls.megaText();
            this.megaText_Description = new templates.UserControls.megaText();
            this.tabControl_ConnectionType = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label_InitialCatalog = new System.Windows.Forms.Label();
            this.label_uid = new System.Windows.Forms.Label();
            this.label_pwd = new System.Windows.Forms.Label();
            this.comboBox_server = new System.Windows.Forms.ComboBox();
            this.textBox_uid = new System.Windows.Forms.TextBox();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.comboBox_InitialCatalog = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.button_loaddatabases = new System.Windows.Forms.Button();
            this.button_testconnection = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Provider = new System.Windows.Forms.Label();
            this.label_DataSource = new System.Windows.Forms.Label();
            this.comboBox_Provider = new System.Windows.Forms.ComboBox();
            this.comboBox_DataSource = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OLEDB_TestConnection = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label_ConnectionString = new System.Windows.Forms.Label();
            this.textBox_ConnectionString = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.button_ODBC_TestConnection = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl_ConnectionType.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(672, 447);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel1);
            this.Page1.Size = new System.Drawing.Size(664, 421);
            this.Page1.Text = "Data";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 662F));
            this.tableLayoutPanel1.Controls.Add(this.megaText_FileName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.megaText_Description, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl_ConnectionType, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(658, 415);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // megaText_FileName
            // 
            this.megaText_FileName.datafield = "FileName";
            this.megaText_FileName.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_FileName.Location = new System.Drawing.Point(3, 3);
            this.megaText_FileName.Name = "megaText_FileName";
            this.megaText_FileName.Size = new System.Drawing.Size(656, 44);
            this.megaText_FileName.TabIndex = 6;
            this.megaText_FileName.Text_Default = null;
            this.megaText_FileName.Text_Height = 21;
            this.megaText_FileName.Text_IsNumber = false;
            this.megaText_FileName.Text_Label = "File Name";
            this.megaText_FileName.Text_MaxLength = 32767;
            this.megaText_FileName.Text_Multiline = false;
            this.megaText_FileName.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_FileName.Text_Textbox = "";
            // 
            // megaText_Description
            // 
            this.megaText_Description.datafield = "Description";
            this.megaText_Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_Description.Location = new System.Drawing.Point(3, 53);
            this.megaText_Description.Name = "megaText_Description";
            this.megaText_Description.Size = new System.Drawing.Size(656, 44);
            this.megaText_Description.TabIndex = 7;
            this.megaText_Description.Text_Default = null;
            this.megaText_Description.Text_Height = 21;
            this.megaText_Description.Text_IsNumber = false;
            this.megaText_Description.Text_Label = "Description";
            this.megaText_Description.Text_MaxLength = 32767;
            this.megaText_Description.Text_Multiline = false;
            this.megaText_Description.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Description.Text_Textbox = "";
            // 
            // tabControl_ConnectionType
            // 
            this.tabControl_ConnectionType.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl_ConnectionType.Controls.Add(this.tabPage1);
            this.tabControl_ConnectionType.Controls.Add(this.tabPage2);
            this.tabControl_ConnectionType.Controls.Add(this.tabPage3);
            this.tabControl_ConnectionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_ConnectionType.Location = new System.Drawing.Point(3, 103);
            this.tabControl_ConnectionType.Name = "tabControl_ConnectionType";
            this.tabControl_ConnectionType.SelectedIndex = 0;
            this.tabControl_ConnectionType.Size = new System.Drawing.Size(656, 309);
            this.tabControl_ConnectionType.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(648, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "SQLCLIENT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label_InitialCatalog, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label_uid, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label_pwd, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_server, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBox_uid, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.textBox_pwd, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_InitialCatalog, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 0, 8);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(642, 274);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(636, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = " server";
            // 
            // label_InitialCatalog
            // 
            this.label_InitialCatalog.AutoSize = true;
            this.label_InitialCatalog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_InitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_InitialCatalog.Location = new System.Drawing.Point(3, 54);
            this.label_InitialCatalog.Name = "label_InitialCatalog";
            this.label_InitialCatalog.Size = new System.Drawing.Size(636, 16);
            this.label_InitialCatalog.TabIndex = 1;
            this.label_InitialCatalog.Text = "Initial Catalog";
            // 
            // label_uid
            // 
            this.label_uid.AutoSize = true;
            this.label_uid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_uid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_uid.Location = new System.Drawing.Point(3, 104);
            this.label_uid.Name = "label_uid";
            this.label_uid.Size = new System.Drawing.Size(636, 16);
            this.label_uid.TabIndex = 2;
            this.label_uid.Text = "uid";
            // 
            // label_pwd
            // 
            this.label_pwd.AutoSize = true;
            this.label_pwd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_pwd.Location = new System.Drawing.Point(3, 154);
            this.label_pwd.Name = "label_pwd";
            this.label_pwd.Size = new System.Drawing.Size(636, 16);
            this.label_pwd.TabIndex = 3;
            this.label_pwd.Text = "pwd";
            // 
            // comboBox_server
            // 
            this.comboBox_server.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_server.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.comboBox_server.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBox_server.FormattingEnabled = true;
            this.comboBox_server.Location = new System.Drawing.Point(3, 23);
            this.comboBox_server.Name = "comboBox_server";
            this.comboBox_server.Size = new System.Drawing.Size(636, 24);
            this.comboBox_server.TabIndex = 4;
            this.comboBox_server.SelectedIndexChanged += new System.EventHandler(this.comboBox_server_SelectedIndexChanged);
            // 
            // textBox_uid
            // 
            this.textBox_uid.AcceptsReturn = true;
            this.textBox_uid.AcceptsTab = true;
            this.textBox_uid.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_uid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_uid.Location = new System.Drawing.Point(3, 123);
            this.textBox_uid.Name = "textBox_uid";
            this.textBox_uid.Size = new System.Drawing.Size(636, 22);
            this.textBox_uid.TabIndex = 6;
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.AcceptsReturn = true;
            this.textBox_pwd.AcceptsTab = true;
            this.textBox_pwd.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_pwd.Location = new System.Drawing.Point(3, 173);
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.Size = new System.Drawing.Size(636, 22);
            this.textBox_pwd.TabIndex = 7;
            // 
            // comboBox_InitialCatalog
            // 
            this.comboBox_InitialCatalog.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox_InitialCatalog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBox_InitialCatalog.FormattingEnabled = true;
            this.comboBox_InitialCatalog.Location = new System.Drawing.Point(3, 73);
            this.comboBox_InitialCatalog.Name = "comboBox_InitialCatalog";
            this.comboBox_InitialCatalog.Size = new System.Drawing.Size(636, 24);
            this.comboBox_InitialCatalog.TabIndex = 8;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.linkLabel1, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 203);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(636, 100);
            this.tableLayoutPanel5.TabIndex = 9;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.button_loaddatabases, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.button_testconnection, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(511, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(122, 100);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // button_loaddatabases
            // 
            this.button_loaddatabases.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_loaddatabases.Location = new System.Drawing.Point(3, 3);
            this.button_loaddatabases.Name = "button_loaddatabases";
            this.button_loaddatabases.Size = new System.Drawing.Size(116, 23);
            this.button_loaddatabases.TabIndex = 0;
            this.button_loaddatabases.Text = "load databases";
            this.button_loaddatabases.UseVisualStyleBackColor = true;
            this.button_loaddatabases.Click += new System.EventHandler(this.button_loaddatabases_Click);
            // 
            // button_testconnection
            // 
            this.button_testconnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_testconnection.Location = new System.Drawing.Point(3, 33);
            this.button_testconnection.Name = "button_testconnection";
            this.button_testconnection.Size = new System.Drawing.Size(116, 23);
            this.button_testconnection.TabIndex = 1;
            this.button_testconnection.Text = "test connection";
            this.button_testconnection.UseVisualStyleBackColor = true;
            this.button_testconnection.Click += new System.EventHandler(this.button_testconnection_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(21, 31);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(3, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(502, 17);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "get Application from e-iot.eu";
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(648, 280);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OLEDB";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label_Provider, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_DataSource, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_Provider, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_DataSource, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(642, 274);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label_Provider
            // 
            this.label_Provider.AutoSize = true;
            this.label_Provider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Provider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_Provider.Location = new System.Drawing.Point(3, 4);
            this.label_Provider.Name = "label_Provider";
            this.label_Provider.Size = new System.Drawing.Size(636, 16);
            this.label_Provider.TabIndex = 0;
            this.label_Provider.Text = "Provider";
            // 
            // label_DataSource
            // 
            this.label_DataSource.AutoSize = true;
            this.label_DataSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_DataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_DataSource.Location = new System.Drawing.Point(3, 54);
            this.label_DataSource.Name = "label_DataSource";
            this.label_DataSource.Size = new System.Drawing.Size(636, 16);
            this.label_DataSource.TabIndex = 1;
            this.label_DataSource.Text = "Data Source";
            // 
            // comboBox_Provider
            // 
            this.comboBox_Provider.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox_Provider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBox_Provider.FormattingEnabled = true;
            this.comboBox_Provider.Location = new System.Drawing.Point(3, 23);
            this.comboBox_Provider.Name = "comboBox_Provider";
            this.comboBox_Provider.Size = new System.Drawing.Size(636, 24);
            this.comboBox_Provider.TabIndex = 3;
            // 
            // comboBox_DataSource
            // 
            this.comboBox_DataSource.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox_DataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.comboBox_DataSource.FormattingEnabled = true;
            this.comboBox_DataSource.Location = new System.Drawing.Point(3, 73);
            this.comboBox_DataSource.Name = "comboBox_DataSource";
            this.comboBox_DataSource.Size = new System.Drawing.Size(636, 24);
            this.comboBox_DataSource.TabIndex = 6;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel7.Controls.Add(this.button_OLEDB_TestConnection, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(636, 168);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // button_OLEDB_TestConnection
            // 
            this.button_OLEDB_TestConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_OLEDB_TestConnection.Location = new System.Drawing.Point(511, 3);
            this.button_OLEDB_TestConnection.Name = "button_OLEDB_TestConnection";
            this.button_OLEDB_TestConnection.Size = new System.Drawing.Size(122, 23);
            this.button_OLEDB_TestConnection.TabIndex = 0;
            this.button_OLEDB_TestConnection.Text = "test connection";
            this.button_OLEDB_TestConnection.UseVisualStyleBackColor = true;
            this.button_OLEDB_TestConnection.Click += new System.EventHandler(this.button_OLEDB_TestConnection_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(648, 280);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ODBC";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.label_ConnectionString, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_ConnectionString, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(648, 280);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // label_ConnectionString
            // 
            this.label_ConnectionString.AutoSize = true;
            this.label_ConnectionString.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_ConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_ConnectionString.Location = new System.Drawing.Point(3, 4);
            this.label_ConnectionString.Name = "label_ConnectionString";
            this.label_ConnectionString.Size = new System.Drawing.Size(642, 16);
            this.label_ConnectionString.TabIndex = 0;
            this.label_ConnectionString.Text = " Connection String";
            // 
            // textBox_ConnectionString
            // 
            this.textBox_ConnectionString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_ConnectionString.Location = new System.Drawing.Point(3, 23);
            this.textBox_ConnectionString.Multiline = true;
            this.textBox_ConnectionString.Name = "textBox_ConnectionString";
            this.textBox_ConnectionString.Size = new System.Drawing.Size(642, 94);
            this.textBox_ConnectionString.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel8.Controls.Add(this.button_ODBC_TestConnection, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 123);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(642, 154);
            this.tableLayoutPanel8.TabIndex = 2;
            // 
            // button_ODBC_TestConnection
            // 
            this.button_ODBC_TestConnection.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_ODBC_TestConnection.Location = new System.Drawing.Point(516, 3);
            this.button_ODBC_TestConnection.Name = "button_ODBC_TestConnection";
            this.button_ODBC_TestConnection.Size = new System.Drawing.Size(123, 23);
            this.button_ODBC_TestConnection.TabIndex = 0;
            this.button_ODBC_TestConnection.Text = "test connection";
            this.button_ODBC_TestConnection.UseVisualStyleBackColor = true;
            this.button_ODBC_TestConnection.Click += new System.EventHandler(this.button_ODBC_TestConnection_Click);
            // 
            // dbConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(672, 468);
            this.Name = "dbConnection";
            this.Text = "dbConnection";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl_ConnectionType.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UserControls.megaText megaText_FileName;
        private UserControls.megaText megaText_Description;
        private System.Windows.Forms.TabControl tabControl_ConnectionType;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_InitialCatalog;
        private System.Windows.Forms.Label label_uid;
        private System.Windows.Forms.Label label_pwd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_Provider;
        private System.Windows.Forms.Label label_DataSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label_ConnectionString;
        private System.Windows.Forms.ComboBox comboBox_server;
        private System.Windows.Forms.TextBox textBox_uid;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.TextBox textBox_ConnectionString;
        private System.Windows.Forms.ComboBox comboBox_Provider;
        private System.Windows.Forms.ComboBox comboBox_InitialCatalog;
        private System.Windows.Forms.ComboBox comboBox_DataSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button button_loaddatabases;
        private System.Windows.Forms.Button button_testconnection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button button_OLEDB_TestConnection;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button button_ODBC_TestConnection;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
