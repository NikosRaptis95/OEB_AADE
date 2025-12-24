namespace templates.Forms
{
    partial class FrmFiltro
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
            this.Page1 = new System.Windows.Forms.TabPage();
            this.megaCombo_Order = new templates.UserControls.megaCombo();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menu = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Page1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.megaCombo_Order);
            this.Page1.Location = new System.Drawing.Point(4, 22);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(592, 452);
            this.Page1.TabIndex = 0;
            this.Page1.Text = "Επιλογές";
            // 
            // megaCombo_Order
            // 
            this.megaCombo_Order.AutoSize = true;
            this.megaCombo_Order.datafield = null;
            this.megaCombo_Order.DisplayMember = "Name";
            this.megaCombo_Order.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.megaCombo_Order.Location = new System.Drawing.Point(3, 402);
            this.megaCombo_Order.Name = "megaCombo_Order";
            this.megaCombo_Order.Size = new System.Drawing.Size(586, 47);
            this.megaCombo_Order.TabIndex = 0;
            this.megaCombo_Order.Text_Label = "Ταξινόμηση";
            this.megaCombo_Order.Text_Textbox = "";
            this.megaCombo_Order.ValueMember = "id";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Page1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 478);
            this.tabControl1.TabIndex = 12;
            this.tabControl1.TabStop = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menu.Location = new System.Drawing.Point(0, 478);
            this.menu.Name = "menu";
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menu.Size = new System.Drawing.Size(600, 21);
            this.menu.TabIndex = 13;
            this.menu.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(67, 19);
            this.toolStripDropDownButton1.Text = "Επιλογές";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateToolStripMenuItem.Text = "Εκτέλεση";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.Execute_);
            // 
            // FrmFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(600, 499);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menu);
            this.Name = "FrmFiltro";
            this.Text = "...";
            this.Load += new System.EventHandler(this.FrmFiltro_Load);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TabPage Page1;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.StatusStrip menu;
        public System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        public System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        public UserControls.megaCombo megaCombo_Order;
    }
}