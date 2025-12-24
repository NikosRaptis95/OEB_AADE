namespace DesktopBusiness.MForms
{
    partial class koki
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
            this.megaCombo_Timo = new templates.UserControls.megaCombo();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(636, 103);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.megaCombo_Timo);
            this.Page1.Location = new System.Drawing.Point(4, 25);
            this.Page1.Size = new System.Drawing.Size(628, 74);
            this.Page1.Text = "Επιλογές";
            // 
            // megaCombo_Timo
            // 
            this.megaCombo_Timo.AutoSize = true;
            this.megaCombo_Timo.datafield = null;
            this.megaCombo_Timo.DataSource = null;
            this.megaCombo_Timo.DisplayMember = "Name";
            this.megaCombo_Timo.Dock = System.Windows.Forms.DockStyle.Top;
            this.megaCombo_Timo.Location = new System.Drawing.Point(4, 4);
            this.megaCombo_Timo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.megaCombo_Timo.Name = "megaCombo_Timo";
            this.megaCombo_Timo.Size = new System.Drawing.Size(620, 48);
            this.megaCombo_Timo.TabIndex = 0;
            this.megaCombo_Timo.Text_Label = "Τιμοκατάλογος";
            this.megaCombo_Timo.Text_Textbox = "";
            this.megaCombo_Timo.ValueMember = "id";
            // 
            // koki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 129);
            this.Name = "koki";
            this.Text = "koki";
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.Page1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private templates.UserControls.megaCombo megaCombo_Timo;
    }
}