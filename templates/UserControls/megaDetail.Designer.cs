namespace templates.UserControls
{
    partial class megaDetail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(megaDetail));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.Button_NewRecord = new System.Windows.Forms.ToolStripButton();
            this.Button_Delete = new System.Windows.Forms.ToolStripButton();
            this.Button_Refresh = new System.Windows.Forms.ToolStripButton();
            this.megaGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.megaGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaGridView, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(287, 238);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(281, 24);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // menu
            // 
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button_NewRecord,
            this.Button_Delete,
            this.Button_Refresh});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(281, 24);
            this.menu.TabIndex = 7;
            this.menu.Text = "toolStrip1";
            // 
            // Button_NewRecord
            // 
            this.Button_NewRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_NewRecord.Image = ((System.Drawing.Image)(resources.GetObject("Button_NewRecord.Image")));
            this.Button_NewRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_NewRecord.Name = "Button_NewRecord";
            this.Button_NewRecord.Size = new System.Drawing.Size(23, 21);
            this.Button_NewRecord.Text = "Add New";
            this.Button_NewRecord.Click += new System.EventHandler(this.Button_NewRecord_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Button_Delete.Image")));
            this.Button_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(23, 21);
            this.Button_Delete.Text = "Delete";
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("Button_Refresh.Image")));
            this.Button_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(23, 21);
            this.Button_Refresh.Text = "Refresh";
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // megaGridView
            // 
            this.megaGridView.AllowUserToDeleteRows = false;
            this.megaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.megaGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.megaGridView.Location = new System.Drawing.Point(3, 33);
            this.megaGridView.MultiSelect = false;
            this.megaGridView.Name = "megaGridView";
            this.megaGridView.Size = new System.Drawing.Size(281, 202);
            this.megaGridView.TabIndex = 2;
            this.megaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.megaGridView.DoubleClick += new System.EventHandler(this.megaGridView_DoubleClick);
            // 
            // megaDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "megaDetail";
            this.Size = new System.Drawing.Size(287, 238);
            this.Load += new System.EventHandler(this.megaDetail_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.megaGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.ToolStrip menu;
        public System.Windows.Forms.ToolStripButton Button_NewRecord;
        public System.Windows.Forms.ToolStripButton Button_Delete;
        public System.Windows.Forms.ToolStripButton Button_Refresh;
        public System.Windows.Forms.DataGridView megaGridView;
    }
}
