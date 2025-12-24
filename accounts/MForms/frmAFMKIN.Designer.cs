namespace DesktopBusiness.MForms
{
    partial class frmAFMKIN
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.megaText_ammount = new templates.UserControls.megaText();
            this.megaText_id = new templates.UserControls.megaText();
            this.megaDate_dueDate = new templates.UserControls.megaDate();
            this.megaCombo_KAEid = new templates.UserControls.megaCombo();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(800, 139);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel2);
            this.Page1.Size = new System.Drawing.Size(792, 113);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.megaText_ammount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaText_id, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaDate_dueDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_KAEid, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(786, 107);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // megaText_ammount
            // 
            this.megaText_ammount.AutoSize = true;
            this.megaText_ammount.datafield = "ammount";
            this.megaText_ammount.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_ammount.Location = new System.Drawing.Point(397, 57);
            this.megaText_ammount.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_ammount.Name = "megaText_ammount";
            this.megaText_ammount.Size = new System.Drawing.Size(385, 39);
            this.megaText_ammount.TabIndex = 23;
            this.megaText_ammount.Text_Default = null;
            this.megaText_ammount.Text_Height = 21;
            this.megaText_ammount.Text_IsNumber = false;
            this.megaText_ammount.Text_Label = "Σύνολο";
            this.megaText_ammount.Text_MaxLength = 20;
            this.megaText_ammount.Text_Multiline = false;
            this.megaText_ammount.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_ammount.Text_Textbox = "";
            // 
            // megaText_id
            // 
            this.megaText_id.AutoSize = true;
            this.megaText_id.datafield = "id";
            this.megaText_id.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_id.Location = new System.Drawing.Point(4, 4);
            this.megaText_id.Margin = new System.Windows.Forms.Padding(4);
            this.megaText_id.Name = "megaText_id";
            this.megaText_id.Size = new System.Drawing.Size(385, 39);
            this.megaText_id.TabIndex = 0;
            this.megaText_id.Text_Default = null;
            this.megaText_id.Text_Height = 21;
            this.megaText_id.Text_IsNumber = false;
            this.megaText_id.Text_Label = "Κωδικός";
            this.megaText_id.Text_MaxLength = 10;
            this.megaText_id.Text_Multiline = false;
            this.megaText_id.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_id.Text_Textbox = "";
            // 
            // megaDate_dueDate
            // 
            this.megaDate_dueDate.AutoSize = true;
            this.megaDate_dueDate.datafield = "dueDate";
            this.megaDate_dueDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaDate_dueDate.Location = new System.Drawing.Point(396, 3);
            this.megaDate_dueDate.Name = "megaDate_dueDate";
            this.megaDate_dueDate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.megaDate_dueDate.Size = new System.Drawing.Size(387, 47);
            this.megaDate_dueDate.TabIndex = 24;
            this.megaDate_dueDate.Text_Datebox = new System.DateTime(2025, 9, 10, 9, 17, 17, 466);
            this.megaDate_dueDate.Text_Label = "Ημερομηνία";
            // 
            // megaCombo_KAEid
            // 
            this.megaCombo_KAEid.AutoSize = true;
            this.megaCombo_KAEid.datafield = "KAEid";
            this.megaCombo_KAEid.DataSource = null;
            this.megaCombo_KAEid.DisplayMember = "Name";
            this.megaCombo_KAEid.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_KAEid.Location = new System.Drawing.Point(3, 56);
            this.megaCombo_KAEid.Name = "megaCombo_KAEid";
            this.megaCombo_KAEid.Size = new System.Drawing.Size(387, 41);
            this.megaCombo_KAEid.TabIndex = 25;
            this.megaCombo_KAEid.Text_Label = "KAE";
            this.megaCombo_KAEid.Text_Textbox = "";
            this.megaCombo_KAEid.ValueMember = "id";
            // 
            // frmAFMKIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 160);
            this.Name = "frmAFMKIN";
            this.Text = "frmAFM";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private templates.UserControls.megaText megaText_ammount;
        private templates.UserControls.megaText megaText_id;
        private templates.UserControls.megaDate megaDate_dueDate;
        private templates.UserControls.megaCombo megaCombo_KAEid;
    }
}