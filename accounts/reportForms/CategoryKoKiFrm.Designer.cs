namespace DesktopBusiness.reportForms
{
    partial class CategoryKoKiFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryKoKiFrm));
            this.menu = new System.Windows.Forms.StatusStrip();
            this.menuSelect = new System.Windows.Forms.ToolStripDropDownButton();
            this.refreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.CategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KoKiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox_Category = new System.Windows.Forms.ListBox();
            this.megaDetail_KoKi = new templates.UserControls.megaDetail();
            this.button1 = new System.Windows.Forms.Button();
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
            this.menu.Location = new System.Drawing.Point(0, 548);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menu.Size = new System.Drawing.Size(740, 21);
            this.menu.TabIndex = 4;
            this.menu.Text = "statusStrip1";
            this.menu.Click += new System.EventHandler(this.menu_Click);
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
            this.CategoriesToolStripMenuItem,
            this.KoKiToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(72, 19);
            this.toolStripDropDownButton1.Text = "Ρυθμίσεις";
            // 
            // CategoriesToolStripMenuItem
            // 
            this.CategoriesToolStripMenuItem.Name = "CategoriesToolStripMenuItem";
            this.CategoriesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.CategoriesToolStripMenuItem.Text = "Κατηγορίες";
            this.CategoriesToolStripMenuItem.Click += new System.EventHandler(this.CategoriesToolStripMenuItem_Click);
            // 
            // KoKiToolStripMenuItem
            // 
            this.KoKiToolStripMenuItem.Name = "KoKiToolStripMenuItem";
            this.KoKiToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.KoKiToolStripMenuItem.Text = "Κωδικοί Κίνησης";
            this.KoKiToolStripMenuItem.Click += new System.EventHandler(this.KoKiToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.listBox_Category, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.megaDetail_KoKi, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(740, 548);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // listBox_Category
            // 
            this.listBox_Category.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Category.FormattingEnabled = true;
            this.listBox_Category.Location = new System.Drawing.Point(3, 3);
            this.listBox_Category.Name = "listBox_Category";
            this.listBox_Category.Size = new System.Drawing.Size(216, 542);
            this.listBox_Category.TabIndex = 0;
            this.listBox_Category.Click += new System.EventHandler(this.listBox_Category_Click);
            this.listBox_Category.SelectedIndexChanged += new System.EventHandler(this.listBox_Category_SelectedIndexChanged);
            this.listBox_Category.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBox_Category_MouseMove);
            // 
            // megaDetail_KoKi
            // 
            this.megaDetail_KoKi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaDetail_KoKi.Location = new System.Drawing.Point(225, 3);
            this.megaDetail_KoKi.Name = "megaDetail_KoKi";
            this.megaDetail_KoKi.PrimaryFields = null;
            this.megaDetail_KoKi.Size = new System.Drawing.Size(512, 542);
            this.megaDetail_KoKi.TabIndex = 1;
            this.megaDetail_KoKi.LoadData += new System.EventHandler(this.megaDetail_KoKi_LoadData);
            this.megaDetail_KoKi.NewRecord += new System.EventHandler(this.megaDetail_KoKi_NewRecord);
            this.megaDetail_KoKi.DeleteRecord += new System.EventHandler(this.megaDetail_KoKi_DeleteRecord);
            this.megaDetail_KoKi.EditRecord += new System.EventHandler(this.megaDetail_KoKi_EditRecord);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 86);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CategoryKoKiFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(740, 569);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Name = "CategoryKoKiFrm";
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
        private System.Windows.Forms.ToolStripMenuItem CategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KoKiToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox_Category;
        private templates.UserControls.megaDetail megaDetail_KoKi;
        private System.Windows.Forms.Button button1;
    }
}
