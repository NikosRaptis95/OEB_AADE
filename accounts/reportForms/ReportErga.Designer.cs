namespace DesktopBusiness.reportForms
{
    partial class ReportErga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportErga));
            this.menu = new System.Windows.Forms.StatusStrip();
            this.menuSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.CustommersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox_Erga = new System.Windows.Forms.ListBox();
            this.megaDetail_Erga = new templates.UserControls.megaDetail();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AllowItemReorder = true;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelect,
            this.toolStripDropDownButton1});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(0, 502);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menu.Size = new System.Drawing.Size(851, 21);
            this.menu.TabIndex = 3;
            this.menu.Text = "statusStrip1";
            // 
            // menuSelect
            // 
            this.menuSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshMenuItem});
            this.menuSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSelect.Name = "menuSelect";
            this.menuSelect.Size = new System.Drawing.Size(67, 19);
            this.menuSelect.Text = "Επιλογές";
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Name = "refreshMenuItem";
            this.refreshMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.refreshMenuItem.Size = new System.Drawing.Size(150, 22);
            this.refreshMenuItem.Text = "Ανανέωση";
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CustommersToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(95, 19);
            this.toolStripDropDownButton1.Text = "Παρουσιάσεις";
            // 
            // CustommersToolStripMenuItem
            // 
            this.CustommersToolStripMenuItem.Name = "CustommersToolStripMenuItem";
            this.CustommersToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.CustommersToolStripMenuItem.Text = "Πελάτης";
            this.CustommersToolStripMenuItem.Click += new System.EventHandler(this.CustommersToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.listBox_Erga, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.megaDetail_Erga, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 487F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(851, 502);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // listBox_Erga
            // 
            this.listBox_Erga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Erga.FormattingEnabled = true;
            this.listBox_Erga.Location = new System.Drawing.Point(3, 3);
            this.listBox_Erga.Name = "listBox_Erga";
            this.listBox_Erga.Size = new System.Drawing.Size(249, 496);
            this.listBox_Erga.TabIndex = 0;
            this.listBox_Erga.SelectedIndexChanged += new System.EventHandler(this.listBox_Erga_SelectedIndexChanged);
            // 
            // megaDetail_Erga
            // 
            this.megaDetail_Erga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaDetail_Erga.Location = new System.Drawing.Point(258, 3);
            this.megaDetail_Erga.Name = "megaDetail_Erga";
            this.megaDetail_Erga.PrimaryFields = null;
            this.megaDetail_Erga.Size = new System.Drawing.Size(590, 496);
            this.megaDetail_Erga.TabIndex = 1;
            this.megaDetail_Erga.LoadData += new System.EventHandler(this.megaDetail_Erga_LoadData);
            this.megaDetail_Erga.NewRecord += new System.EventHandler(this.megaDetail_Erga_NewRecord);
            this.megaDetail_Erga.DeleteRecord += new System.EventHandler(this.megaDetail_Erga_DeleteRecord);
            this.megaDetail_Erga.EditRecord += new System.EventHandler(this.megaDetail_Erga_EditRecord);
            this.megaDetail_Erga.RefreshRecord += new System.EventHandler(this.megaDetail_Erga_RefreshRecord);
            // 
            // ReportErga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(851, 523);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Name = "ReportErga";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip menu;
        public System.Windows.Forms.ToolStripDropDownButton menuSelect;
        public System.Windows.Forms.ToolStripMenuItem refreshMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem CustommersToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox_Erga;
        private templates.UserControls.megaDetail megaDetail_Erga;
    }
}
