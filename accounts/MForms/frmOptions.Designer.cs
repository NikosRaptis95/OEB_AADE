namespace DesktopBusiness.iForms
{
    partial class optionsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(optionsFrm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton5 = new System.Windows.Forms.ToolStripDropDownButton();
            this.επαγγέλματαToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_User = new System.Windows.Forms.ComboBox();
            this.label_User = new System.Windows.Forms.Label();
            this.label_comp = new System.Windows.Forms.Label();
            this.label_address = new System.Windows.Forms.Label();
            this.label3_phone = new System.Windows.Forms.Label();
            this.label_eMail = new System.Windows.Forms.Label();
            this.label_deka = new System.Windows.Forms.Label();
            this.label_par = new System.Windows.Forms.Label();
            this.textBox_comp = new System.Windows.Forms.TextBox();
            this.textBox_address = new System.Windows.Forms.TextBox();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.textBox_eMail = new System.Windows.Forms.TextBox();
            this.textBox_deka = new System.Windows.Forms.TextBox();
            this.textBox_par = new System.Windows.Forms.TextBox();
            this.textBox_smtp = new System.Windows.Forms.TextBox();
            this.label_smtp = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(338, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.toolStripMenuItem3,
            this.refreshToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(67, 20);
            this.toolStripDropDownButton1.Text = "Επιλογές";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.updateToolStripMenuItem.Text = "Αποθήκευση";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(192, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.refreshToolStripMenuItem.Text = "Ακύρωση - Ανανέωση";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // toolStripDropDownButton5
            // 
            this.toolStripDropDownButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.επαγγέλματαToolStripMenuItem});
            this.toolStripDropDownButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton5.Image")));
            this.toolStripDropDownButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton5.Name = "toolStripDropDownButton5";
            this.toolStripDropDownButton5.Size = new System.Drawing.Size(72, 20);
            this.toolStripDropDownButton5.Text = "Ρυθμίσεις";
            // 
            // επαγγέλματαToolStripMenuItem
            // 
            this.επαγγέλματαToolStripMenuItem.Name = "επαγγέλματαToolStripMenuItem";
            this.επαγγέλματαToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.επαγγέλματαToolStripMenuItem.Text = "Χρήστες";
            this.επαγγέλματαToolStripMenuItem.Click += new System.EventHandler(this.επαγγέλματαToolStripMenuItem_Click);
            // 
            // textBox_User
            // 
            this.textBox_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.textBox_User.FormattingEnabled = true;
            this.textBox_User.Location = new System.Drawing.Point(12, 70);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(314, 21);
            this.textBox_User.TabIndex = 49;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(16, 54);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(50, 13);
            this.label_User.TabIndex = 48;
            this.label_User.Text = "χρήστης";
            // 
            // label_comp
            // 
            this.label_comp.AutoSize = true;
            this.label_comp.Location = new System.Drawing.Point(16, 9);
            this.label_comp.Name = "label_comp";
            this.label_comp.Size = new System.Drawing.Size(85, 13);
            this.label_comp.TabIndex = 50;
            this.label_comp.Text = "όνομα εταιρίας";
            // 
            // label_address
            // 
            this.label_address.AutoSize = true;
            this.label_address.Location = new System.Drawing.Point(16, 104);
            this.label_address.Name = "label_address";
            this.label_address.Size = new System.Drawing.Size(59, 13);
            this.label_address.TabIndex = 51;
            this.label_address.Text = "διεύθυνση";
            // 
            // label3_phone
            // 
            this.label3_phone.AutoSize = true;
            this.label3_phone.Location = new System.Drawing.Point(16, 155);
            this.label3_phone.Name = "label3_phone";
            this.label3_phone.Size = new System.Drawing.Size(58, 13);
            this.label3_phone.TabIndex = 52;
            this.label3_phone.Text = "τηλέφωνο";
            // 
            // label_eMail
            // 
            this.label_eMail.AutoSize = true;
            this.label_eMail.Location = new System.Drawing.Point(17, 203);
            this.label_eMail.Name = "label_eMail";
            this.label_eMail.Size = new System.Drawing.Size(32, 13);
            this.label_eMail.TabIndex = 53;
            this.label_eMail.Text = "eMail";
            // 
            // label_deka
            // 
            this.label_deka.AutoSize = true;
            this.label_deka.Location = new System.Drawing.Point(17, 247);
            this.label_deka.Name = "label_deka";
            this.label_deka.Size = new System.Drawing.Size(52, 13);
            this.label_deka.TabIndex = 54;
            this.label_deka.Text = "δεκαδικά";
            // 
            // label_par
            // 
            this.label_par.AutoSize = true;
            this.label_par.Location = new System.Drawing.Point(16, 296);
            this.label_par.Name = "label_par";
            this.label_par.Size = new System.Drawing.Size(146, 13);
            this.label_par.TabIndex = 55;
            this.label_par.Text = "παράμετρος παραστατικών";
            // 
            // textBox_comp
            // 
            this.textBox_comp.Location = new System.Drawing.Point(12, 25);
            this.textBox_comp.Name = "textBox_comp";
            this.textBox_comp.Size = new System.Drawing.Size(314, 20);
            this.textBox_comp.TabIndex = 56;
            // 
            // textBox_address
            // 
            this.textBox_address.Location = new System.Drawing.Point(12, 120);
            this.textBox_address.Name = "textBox_address";
            this.textBox_address.Size = new System.Drawing.Size(314, 20);
            this.textBox_address.TabIndex = 57;
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(12, 171);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(314, 20);
            this.textBox_phone.TabIndex = 58;
            // 
            // textBox_eMail
            // 
            this.textBox_eMail.Location = new System.Drawing.Point(12, 216);
            this.textBox_eMail.Name = "textBox_eMail";
            this.textBox_eMail.Size = new System.Drawing.Size(314, 20);
            this.textBox_eMail.TabIndex = 59;
            // 
            // textBox_deka
            // 
            this.textBox_deka.Location = new System.Drawing.Point(12, 263);
            this.textBox_deka.Name = "textBox_deka";
            this.textBox_deka.Size = new System.Drawing.Size(314, 20);
            this.textBox_deka.TabIndex = 60;
            // 
            // textBox_par
            // 
            this.textBox_par.Location = new System.Drawing.Point(12, 312);
            this.textBox_par.Name = "textBox_par";
            this.textBox_par.Size = new System.Drawing.Size(314, 20);
            this.textBox_par.TabIndex = 61;
            // 
            // textBox_smtp
            // 
            this.textBox_smtp.Location = new System.Drawing.Point(12, 362);
            this.textBox_smtp.Name = "textBox_smtp";
            this.textBox_smtp.Size = new System.Drawing.Size(314, 20);
            this.textBox_smtp.TabIndex = 63;
            // 
            // label_smtp
            // 
            this.label_smtp.AutoSize = true;
            this.label_smtp.Location = new System.Drawing.Point(16, 346);
            this.label_smtp.Name = "label_smtp";
            this.label_smtp.Size = new System.Drawing.Size(146, 13);
            this.label_smtp.TabIndex = 62;
            this.label_smtp.Text = "outgoing (SMTP) email server";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(12, 406);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(130, 20);
            this.textBox_password.TabIndex = 65;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(16, 390);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(52, 13);
            this.label_password.TabIndex = 64;
            this.label_password.Text = "password";
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(196, 406);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(130, 20);
            this.textBox_port.TabIndex = 67;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 66;
            this.label1.Text = "port";
            // 
            // optionsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 457);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.textBox_smtp);
            this.Controls.Add(this.label_smtp);
            this.Controls.Add(this.textBox_par);
            this.Controls.Add(this.textBox_deka);
            this.Controls.Add(this.textBox_eMail);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.textBox_address);
            this.Controls.Add(this.textBox_comp);
            this.Controls.Add(this.label_par);
            this.Controls.Add(this.label_deka);
            this.Controls.Add(this.label_eMail);
            this.Controls.Add(this.label3_phone);
            this.Controls.Add(this.label_address);
            this.Controls.Add(this.label_comp);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "optionsFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Επιλογές";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton5;
        private System.Windows.Forms.ToolStripMenuItem επαγγέλματαToolStripMenuItem;
        private System.Windows.Forms.ComboBox textBox_User;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label label_comp;
        private System.Windows.Forms.Label label_address;
        private System.Windows.Forms.Label label3_phone;
        private System.Windows.Forms.Label label_eMail;
        private System.Windows.Forms.Label label_deka;
        private System.Windows.Forms.Label label_par;
        private System.Windows.Forms.TextBox textBox_comp;
        private System.Windows.Forms.TextBox textBox_address;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.TextBox textBox_eMail;
        private System.Windows.Forms.TextBox textBox_deka;
        private System.Windows.Forms.TextBox textBox_par;
        private System.Windows.Forms.TextBox textBox_smtp;
        private System.Windows.Forms.Label label_smtp;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
    }
}