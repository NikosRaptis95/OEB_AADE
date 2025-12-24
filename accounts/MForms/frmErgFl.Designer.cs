namespace DesktopBusiness.MForms
{
    partial class frmErgFl
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
            this.megaText_Memo = new templates.UserControls.megaText();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.megaText_id = new templates.UserControls.megaText();
            this.megaText_Description = new templates.UserControls.megaText();
            this.megaDate_Start = new templates.UserControls.megaDate();
            this.megaDate_End = new templates.UserControls.megaDate();
            this.megaCombo_idPin = new templates.UserControls.megaCombo();
            this.megaCombo_Status = new templates.UserControls.megaCombo();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(698, 320);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel1);
            this.Page1.Size = new System.Drawing.Size(690, 294);
            this.Page1.Text = "στοιχεία εγγραφής";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.megaText_Memo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 288);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // megaText_Memo
            // 
            this.megaText_Memo.AutoSize = true;
            this.megaText_Memo.datafield = "Memo";
            this.megaText_Memo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaText_Memo.Location = new System.Drawing.Point(3, 175);
            this.megaText_Memo.Name = "megaText_Memo";
            this.megaText_Memo.Size = new System.Drawing.Size(678, 110);
            this.megaText_Memo.TabIndex = 0;
            this.megaText_Memo.Text_Default = null;
            this.megaText_Memo.Text_Height = 90;
            this.megaText_Memo.Text_IsNumber = false;
            this.megaText_Memo.Text_Label = "Σημειώσεις";
            this.megaText_Memo.Text_MaxLength = 32767;
            this.megaText_Memo.Text_Multiline = true;
            this.megaText_Memo.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Memo.Text_Textbox = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.megaText_id, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaText_Description, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaDate_Start, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaDate_End, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_idPin, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_Status, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(678, 166);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // megaText_id
            // 
            this.megaText_id.AutoSize = true;
            this.megaText_id.datafield = "id";
            this.megaText_id.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_id.Location = new System.Drawing.Point(3, 3);
            this.megaText_id.Name = "megaText_id";
            this.megaText_id.Size = new System.Drawing.Size(333, 39);
            this.megaText_id.TabIndex = 0;
            this.megaText_id.Text_Default = null;
            this.megaText_id.Text_Height = 21;
            this.megaText_id.Text_IsNumber = false;
            this.megaText_id.Text_Label = "Κωδικός";
            this.megaText_id.Text_MaxLength = 60;
            this.megaText_id.Text_Multiline = false;
            this.megaText_id.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_id.Text_Textbox = "";
            // 
            // megaText_Description
            // 
            this.megaText_Description.AutoSize = true;
            this.megaText_Description.datafield = "Description";
            this.megaText_Description.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_Description.Location = new System.Drawing.Point(342, 3);
            this.megaText_Description.Name = "megaText_Description";
            this.megaText_Description.Size = new System.Drawing.Size(333, 39);
            this.megaText_Description.TabIndex = 1;
            this.megaText_Description.Text_Default = null;
            this.megaText_Description.Text_Height = 21;
            this.megaText_Description.Text_IsNumber = false;
            this.megaText_Description.Text_Label = "Περιγραφή";
            this.megaText_Description.Text_MaxLength = 100;
            this.megaText_Description.Text_Multiline = false;
            this.megaText_Description.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Description.Text_Textbox = "";
            // 
            // megaDate_Start
            // 
            this.megaDate_Start.AutoSize = true;
            this.megaDate_Start.datafield = "StartDate";
            this.megaDate_Start.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaDate_Start.Location = new System.Drawing.Point(3, 58);
            this.megaDate_Start.Name = "megaDate_Start";
            this.megaDate_Start.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.megaDate_Start.Size = new System.Drawing.Size(333, 47);
            this.megaDate_Start.TabIndex = 2;
            this.megaDate_Start.Text_Datebox = new System.DateTime(2019, 2, 3, 20, 14, 6, 744);
            this.megaDate_Start.Text_Label = "Εκκίνηση";
            // 
            // megaDate_End
            // 
            this.megaDate_End.AutoSize = true;
            this.megaDate_End.datafield = "EndDate";
            this.megaDate_End.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaDate_End.Location = new System.Drawing.Point(342, 58);
            this.megaDate_End.Name = "megaDate_End";
            this.megaDate_End.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.megaDate_End.Size = new System.Drawing.Size(333, 47);
            this.megaDate_End.TabIndex = 3;
            this.megaDate_End.Text_Datebox = new System.DateTime(2019, 2, 3, 20, 14, 8, 683);
            this.megaDate_End.Text_Label = "Τέλος";
            // 
            // megaCombo_idPin
            // 
            this.megaCombo_idPin.AutoSize = true;
            this.megaCombo_idPin.datafield = "idPin";
            this.megaCombo_idPin.DataSource = null;
            this.megaCombo_idPin.DisplayMember = "Name";
            this.megaCombo_idPin.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_idPin.Location = new System.Drawing.Point(3, 113);
            this.megaCombo_idPin.Name = "megaCombo_idPin";
            this.megaCombo_idPin.Size = new System.Drawing.Size(333, 41);
            this.megaCombo_idPin.TabIndex = 4;
            this.megaCombo_idPin.Text_Label = "Κατηγορία";
            this.megaCombo_idPin.Text_Textbox = "";
            this.megaCombo_idPin.ValueMember = "id";
            // 
            // megaCombo_Status
            // 
            this.megaCombo_Status.AutoSize = true;
            this.megaCombo_Status.datafield = "Status";
            this.megaCombo_Status.DataSource = null;
            this.megaCombo_Status.DisplayMember = "Name";
            this.megaCombo_Status.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Status.Location = new System.Drawing.Point(342, 113);
            this.megaCombo_Status.Name = "megaCombo_Status";
            this.megaCombo_Status.Size = new System.Drawing.Size(333, 41);
            this.megaCombo_Status.TabIndex = 5;
            this.megaCombo_Status.Text_Label = "Status";
            this.megaCombo_Status.Text_Textbox = "";
            this.megaCombo_Status.ValueMember = "id";
            // 
            // frmErgFl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(698, 341);
            this.Name = "frmErgFl";
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

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private templates.UserControls.megaText megaText_Memo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private templates.UserControls.megaText megaText_id;
        private templates.UserControls.megaText megaText_Description;
        private templates.UserControls.megaDate megaDate_Start;
        private templates.UserControls.megaDate megaDate_End;
        private templates.UserControls.megaCombo megaCombo_idPin;
        private templates.UserControls.megaCombo megaCombo_Status;
    }
}
