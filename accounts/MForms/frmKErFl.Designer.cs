namespace DesktopBusiness.MForms
{
    partial class frmKErFl
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
            this.megaText_AitiKer = new templates.UserControls.megaText();
            this.megaCombo_idErg = new templates.UserControls.megaCombo();
            this.megaFind_idSyn = new templates.UserControls.megaFind();
            this.megaDate_RegistryDate = new templates.UserControls.megaDate();
            this.megaCombo_KoKiEr = new templates.UserControls.megaCombo();
            this.megaCombo_Status = new templates.UserControls.megaCombo();
            this.megaText_SalesPerson = new templates.UserControls.megaText();
            this.megaTrackBar_Summary = new templates.UserControls.megaTrackBar();
            this.megaText_Memo = new templates.UserControls.megaText();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(698, 464);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.tableLayoutPanel1);
            this.Page1.Size = new System.Drawing.Size(690, 438);
            this.Page1.Text = "στοιχεία εγγραφής";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.megaText_Memo, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 432);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.megaText_AitiKer, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_idErg, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaFind_idSyn, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaDate_RegistryDate, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_KoKiEr, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.megaCombo_Status, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.megaText_SalesPerson, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.megaTrackBar_Summary, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(678, 232);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // megaText_AitiKer
            // 
            this.megaText_AitiKer.AutoSize = true;
            this.megaText_AitiKer.datafield = "AitiKEr";
            this.megaText_AitiKer.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_AitiKer.Location = new System.Drawing.Point(3, 119);
            this.megaText_AitiKer.Name = "megaText_AitiKer";
            this.megaText_AitiKer.Size = new System.Drawing.Size(333, 39);
            this.megaText_AitiKer.TabIndex = 8;
            this.megaText_AitiKer.Text_Default = null;
            this.megaText_AitiKer.Text_Height = 21;
            this.megaText_AitiKer.Text_IsNumber = false;
            this.megaText_AitiKer.Text_Label = "Αιτιολογία";
            this.megaText_AitiKer.Text_MaxLength = 32767;
            this.megaText_AitiKer.Text_Multiline = false;
            this.megaText_AitiKer.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_AitiKer.Text_Textbox = "";
            // 
            // megaCombo_idErg
            // 
            this.megaCombo_idErg.AutoSize = true;
            this.megaCombo_idErg.datafield = "idErg";
            this.megaCombo_idErg.DataSource = null;
            this.megaCombo_idErg.DisplayMember = "Description";
            this.megaCombo_idErg.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_idErg.Location = new System.Drawing.Point(342, 3);
            this.megaCombo_idErg.Name = "megaCombo_idErg";
            this.megaCombo_idErg.Size = new System.Drawing.Size(333, 41);
            this.megaCombo_idErg.TabIndex = 1;
            this.megaCombo_idErg.Text_Label = "Υπηρεσία";
            this.megaCombo_idErg.Text_Textbox = "";
            this.megaCombo_idErg.ValueMember = "id";
            this.megaCombo_idErg.megaComboBox_selectedIndexChanged += new System.EventHandler(this.megaCombo_idErg_megaComboBox_selectedIndexChanged);
            // 
            // megaFind_idSyn
            // 
            this.megaFind_idSyn.CallForm = null;
            this.megaFind_idSyn.datafield = "idSyn";
            this.megaFind_idSyn.DisplayMember = "Name";
            this.megaFind_idSyn.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaFind_idSyn.Location = new System.Drawing.Point(3, 61);
            this.megaFind_idSyn.Name = "megaFind_idSyn";
            this.megaFind_idSyn.Size = new System.Drawing.Size(333, 46);
            this.megaFind_idSyn.TabIndex = 2;
            this.megaFind_idSyn.Text_Default = null;
            this.megaFind_idSyn.Text_Height = 21;
            this.megaFind_idSyn.Text_Label = "Πελάτης";
            this.megaFind_idSyn.Text_MaxLength = 32767;
            this.megaFind_idSyn.Text_Multiline = false;
            this.megaFind_idSyn.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaFind_idSyn.Text_Textbox = "";
            this.megaFind_idSyn.ValueMember = "id";
            this.megaFind_idSyn.megaTextBox_textChanged += new System.EventHandler(this.megaFind_idSyn_megaTextBox_textChanged);
            // 
            // megaDate_RegistryDate
            // 
            this.megaDate_RegistryDate.AutoSize = true;
            this.megaDate_RegistryDate.datafield = "RegistryDate";
            this.megaDate_RegistryDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaDate_RegistryDate.Location = new System.Drawing.Point(3, 3);
            this.megaDate_RegistryDate.Name = "megaDate_RegistryDate";
            this.megaDate_RegistryDate.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.megaDate_RegistryDate.Size = new System.Drawing.Size(333, 47);
            this.megaDate_RegistryDate.TabIndex = 3;
            this.megaDate_RegistryDate.Text_Datebox = new System.DateTime(2019, 2, 3, 21, 46, 43, 307);
            this.megaDate_RegistryDate.Text_Label = "Ημερομηνία";
            // 
            // megaCombo_KoKiEr
            // 
            this.megaCombo_KoKiEr.AutoSize = true;
            this.megaCombo_KoKiEr.datafield = "KoKiKEr";
            this.megaCombo_KoKiEr.DataSource = null;
            this.megaCombo_KoKiEr.DisplayMember = "Name";
            this.megaCombo_KoKiEr.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_KoKiEr.Location = new System.Drawing.Point(342, 61);
            this.megaCombo_KoKiEr.Name = "megaCombo_KoKiEr";
            this.megaCombo_KoKiEr.Size = new System.Drawing.Size(333, 41);
            this.megaCombo_KoKiEr.TabIndex = 4;
            this.megaCombo_KoKiEr.Text_Label = "Κωδικός Κίνησης";
            this.megaCombo_KoKiEr.Text_Textbox = "";
            this.megaCombo_KoKiEr.ValueMember = "id";
            // 
            // megaCombo_Status
            // 
            this.megaCombo_Status.AutoSize = true;
            this.megaCombo_Status.datafield = "Status";
            this.megaCombo_Status.DataSource = null;
            this.megaCombo_Status.DisplayMember = "Name";
            this.megaCombo_Status.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Status.Location = new System.Drawing.Point(3, 177);
            this.megaCombo_Status.Name = "megaCombo_Status";
            this.megaCombo_Status.Size = new System.Drawing.Size(333, 41);
            this.megaCombo_Status.TabIndex = 5;
            this.megaCombo_Status.Text_Label = "Status";
            this.megaCombo_Status.Text_Textbox = "";
            this.megaCombo_Status.ValueMember = "id";
            // 
            // megaText_SalesPerson
            // 
            this.megaText_SalesPerson.AutoSize = true;
            this.megaText_SalesPerson.datafield = "SalesPerson";
            this.megaText_SalesPerson.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_SalesPerson.Enabled = false;
            this.megaText_SalesPerson.Location = new System.Drawing.Point(342, 177);
            this.megaText_SalesPerson.Name = "megaText_SalesPerson";
            this.megaText_SalesPerson.Size = new System.Drawing.Size(333, 39);
            this.megaText_SalesPerson.TabIndex = 6;
            this.megaText_SalesPerson.Text_Default = null;
            this.megaText_SalesPerson.Text_Height = 21;
            this.megaText_SalesPerson.Text_IsNumber = false;
            this.megaText_SalesPerson.Text_Label = "Χρήστης";
            this.megaText_SalesPerson.Text_MaxLength = 32767;
            this.megaText_SalesPerson.Text_Multiline = false;
            this.megaText_SalesPerson.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_SalesPerson.Text_Textbox = "";
            // 
            // megaTrackBar_Summary
            // 
            this.megaTrackBar_Summary.AutoSize = true;
            this.megaTrackBar_Summary.datafield = "Summary";
            this.megaTrackBar_Summary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.megaTrackBar_Summary.Location = new System.Drawing.Point(342, 119);
            this.megaTrackBar_Summary.Name = "megaTrackBar_Summary";
            this.megaTrackBar_Summary.Size = new System.Drawing.Size(333, 52);
            this.megaTrackBar_Summary.TabIndex = 7;
            this.megaTrackBar_Summary.Text_Label = "Ολοκλήρωση";
            // 
            // megaText_Memo
            // 
            this.megaText_Memo.AutoSize = true;
            this.megaText_Memo.datafield = "Memo";
            this.megaText_Memo.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaText_Memo.Location = new System.Drawing.Point(3, 241);
            this.megaText_Memo.Name = "megaText_Memo";
            this.megaText_Memo.Size = new System.Drawing.Size(678, 188);
            this.megaText_Memo.TabIndex = 1;
            this.megaText_Memo.Text_Default = null;
            this.megaText_Memo.Text_Height = 170;
            this.megaText_Memo.Text_IsNumber = false;
            this.megaText_Memo.Text_Label = "Σημειώσεις";
            this.megaText_Memo.Text_MaxLength = 32767;
            this.megaText_Memo.Text_Multiline = true;
            this.megaText_Memo.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Memo.Text_Textbox = "";
            // 
            // frmKErFl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(698, 485);
            this.Name = "frmKErFl";
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private templates.UserControls.megaCombo megaCombo_idErg;
        private templates.UserControls.megaFind megaFind_idSyn;
        private templates.UserControls.megaDate megaDate_RegistryDate;
        private templates.UserControls.megaCombo megaCombo_KoKiEr;
        private templates.UserControls.megaCombo megaCombo_Status;
        private templates.UserControls.megaText megaText_SalesPerson;
        private templates.UserControls.megaText megaText_Memo;
        private templates.UserControls.megaTrackBar megaTrackBar_Summary;
        private templates.UserControls.megaText megaText_AitiKer;
    }
}
