namespace templates.Forms
{
    partial class CallFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallFrm));
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.ComboBox();
            this.CrearButton = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolParams = new System.Windows.Forms.ToolStripMenuItem();
            this.topRecordsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAfterSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.falseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.after3SecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.after10SecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.after1MinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.menu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToOrderColumns = true;
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataGrid.Location = new System.Drawing.Point(3, 3);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGrid.Size = new System.Drawing.Size(788, 382);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentDoubleClick);
            this.DataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGrid_CellFormatting);
            this.DataGrid.CurrentCellChanged += new System.EventHandler(this.DataGrid_CurrentCellChanged);
            this.DataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseClick);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.Location = new System.Drawing.Point(751, 3);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(24, 24);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // searchBox
            // 
            this.searchBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.searchBox.FormattingEnabled = true;
            this.searchBox.Location = new System.Drawing.Point(63, 3);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(682, 21);
            this.searchBox.TabIndex = 0;
            this.searchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchBox_KeyPress);
            // 
            // CrearButton
            // 
            this.CrearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CrearButton.Image = ((System.Drawing.Image)(resources.GetObject("CrearButton.Image")));
            this.CrearButton.Location = new System.Drawing.Point(33, 3);
            this.CrearButton.Name = "CrearButton";
            this.CrearButton.Size = new System.Drawing.Size(24, 24);
            this.CrearButton.TabIndex = 1;
            this.CrearButton.UseVisualStyleBackColor = true;
            this.CrearButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Location = new System.Drawing.Point(781, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(24, 24);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "%";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(24, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "%";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // menuSelect
            // 
            this.menuSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenuItem,
            this.newMenuItem,
            this.toolStripMenuItem1,
            this.deleteMenuItem,
            this.toolStripMenuItem3,
            this.toolParams,
            this.toolStripMenuItem2,
            this.refreshMenuItem});
            this.menuSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSelect.Name = "menuSelect";
            this.menuSelect.Size = new System.Drawing.Size(67, 19);
            this.menuSelect.Text = "Επιλογές";
            this.menuSelect.Click += new System.EventHandler(this.menuSelect_Click);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.editMenuItem.Size = new System.Drawing.Size(164, 22);
            this.editMenuItem.Text = "Επεξεργασία";
            this.editMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // newMenuItem
            // 
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.newMenuItem.Size = new System.Drawing.Size(164, 22);
            this.newMenuItem.Text = "Νέα εγγραφή";
            this.newMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(164, 22);
            this.deleteMenuItem.Text = "Διαγραφή";
            this.deleteMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(161, 6);
            // 
            // toolParams
            // 
            this.toolParams.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topRecordsToolStripMenuItem1,
            this.closeAfterSelectionToolStripMenuItem,
            this.refreshToolStripMenuItem});
            this.toolParams.Name = "toolParams";
            this.toolParams.Size = new System.Drawing.Size(164, 22);
            this.toolParams.Text = "Ρυθμίσεις";
            // 
            // topRecordsToolStripMenuItem1
            // 
            this.topRecordsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.topRecordsToolStripMenuItem1.Name = "topRecordsToolStripMenuItem1";
            this.topRecordsToolStripMenuItem1.Size = new System.Drawing.Size(183, 22);
            this.topRecordsToolStripMenuItem1.Text = "Top Records";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem5.Text = "0";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem6.Text = "10";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem7.Text = "200";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem8.Text = "400";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem9.Text = "1800";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // closeAfterSelectionToolStripMenuItem
            // 
            this.closeAfterSelectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trueToolStripMenuItem,
            this.falseToolStripMenuItem});
            this.closeAfterSelectionToolStripMenuItem.Name = "closeAfterSelectionToolStripMenuItem";
            this.closeAfterSelectionToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.closeAfterSelectionToolStripMenuItem.Text = "Close after selection ";
            // 
            // trueToolStripMenuItem
            // 
            this.trueToolStripMenuItem.Name = "trueToolStripMenuItem";
            this.trueToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.trueToolStripMenuItem.Text = "True";
            this.trueToolStripMenuItem.Click += new System.EventHandler(this.trueToolStripMenuItem_Click);
            // 
            // falseToolStripMenuItem
            // 
            this.falseToolStripMenuItem.Name = "falseToolStripMenuItem";
            this.falseToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.falseToolStripMenuItem.Text = "False";
            this.falseToolStripMenuItem.Click += new System.EventHandler(this.falseToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neverToolStripMenuItem,
            this.after3SecToolStripMenuItem,
            this.after10SecToolStripMenuItem,
            this.after1MinToolStripMenuItem});
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.refreshToolStripMenuItem.Text = "Auto Refresh";
            // 
            // neverToolStripMenuItem
            // 
            this.neverToolStripMenuItem.Name = "neverToolStripMenuItem";
            this.neverToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.neverToolStripMenuItem.Text = "Never";
            this.neverToolStripMenuItem.Click += new System.EventHandler(this.neverToolStripMenuItem_Click);
            // 
            // after3SecToolStripMenuItem
            // 
            this.after3SecToolStripMenuItem.Name = "after3SecToolStripMenuItem";
            this.after3SecToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.after3SecToolStripMenuItem.Text = "After 3 sec";
            this.after3SecToolStripMenuItem.Click += new System.EventHandler(this.after3SecToolStripMenuItem_Click);
            // 
            // after10SecToolStripMenuItem
            // 
            this.after10SecToolStripMenuItem.Name = "after10SecToolStripMenuItem";
            this.after10SecToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.after10SecToolStripMenuItem.Text = "After 10 sec";
            this.after10SecToolStripMenuItem.Click += new System.EventHandler(this.after10SecToolStripMenuItem_Click);
            // 
            // after1MinToolStripMenuItem
            // 
            this.after1MinToolStripMenuItem.Name = "after1MinToolStripMenuItem";
            this.after1MinToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.after1MinToolStripMenuItem.Text = "After 1 min";
            this.after1MinToolStripMenuItem.Click += new System.EventHandler(this.after1MinToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Name = "refreshMenuItem";
            this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshMenuItem.Size = new System.Drawing.Size(164, 22);
            this.refreshMenuItem.Text = "Ανανέωση";
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.menu.AllowItemReorder = true;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelect});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(0, 450);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menu.Size = new System.Drawing.Size(808, 21);
            this.menu.TabIndex = 2;
            this.menu.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 414);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "...";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.ColumnCount = 5;
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panel1.Controls.Add(this.checkBox2, 4, 0);
            this.panel1.Controls.Add(this.RefreshButton, 3, 0);
            this.panel1.Controls.Add(this.checkBox1, 0, 0);
            this.panel1.Controls.Add(this.searchBox, 2, 0);
            this.panel1.Controls.Add(this.CrearButton, 1, 0);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RowCount = 1;
            this.panel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel1.Size = new System.Drawing.Size(808, 30);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(808, 420);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CallFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(808, 471);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu);
            this.Name = "CallFrm";
            this.Text = "...";
            this.Activated += new System.EventHandler(this.CallFrm_Activated);
            this.Load += new System.EventHandler(this.CallFrm_Load);
            this.Resize += new System.EventHandler(this.CallFrm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataGridView DataGrid;
        public System.Windows.Forms.Button CrearButton;
        public System.Windows.Forms.CheckBox checkBox2;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.ComboBox searchBox;
        public System.Windows.Forms.ToolStripDropDownButton menuSelect;
        public System.Windows.Forms.ToolStripMenuItem editMenuItem;
        public System.Windows.Forms.ToolStripMenuItem newMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        public System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.StatusStrip menu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolParams;
        private System.Windows.Forms.ToolStripMenuItem topRecordsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeAfterSelectionToolStripMenuItem;
        public System.Windows.Forms.Button RefreshButton;
        public System.Windows.Forms.TableLayoutPanel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem trueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem falseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem after3SecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem after10SecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem after1MinToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}

