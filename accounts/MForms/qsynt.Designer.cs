namespace DesktopBusiness.MForms
{
    partial class qsynt
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
            this.label1 = new System.Windows.Forms.Label();
            this.megaText_Description = new templates.UserControls.megaText();
            this.megaText_Quantity = new templates.UserControls.megaText();
            this.tabControl1.SuspendLayout();
            this.Page1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(730, 188);
            // 
            // Page1
            // 
            this.Page1.Controls.Add(this.megaText_Quantity);
            this.Page1.Controls.Add(this.megaText_Description);
            this.Page1.Size = new System.Drawing.Size(722, 162);
            this.Page1.Text = "Είδος";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Προιόν";
            // 
            // megaText_Description
            // 
            this.megaText_Description.datafield = null;
            this.megaText_Description.Enabled = false;
            this.megaText_Description.Location = new System.Drawing.Point(12, 17);
            this.megaText_Description.Name = "megaText_Description";
            this.megaText_Description.Size = new System.Drawing.Size(702, 71);
            this.megaText_Description.TabIndex = 0;
            this.megaText_Description.Text_Default = null;
            this.megaText_Description.Text_Height = 21;
            this.megaText_Description.Text_IsNumber = false;
            this.megaText_Description.Text_Label = "Περιγραφή";
            this.megaText_Description.Text_MaxLength = 32767;
            this.megaText_Description.Text_Multiline = false;
            this.megaText_Description.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Description.Text_Textbox = "";
            // 
            // megaText_Quantity
            // 
            this.megaText_Quantity.datafield = null;
            this.megaText_Quantity.Location = new System.Drawing.Point(12, 80);
            this.megaText_Quantity.Name = "megaText_Quantity";
            this.megaText_Quantity.Size = new System.Drawing.Size(702, 71);
            this.megaText_Quantity.TabIndex = 1;
            this.megaText_Quantity.Text_Default = null;
            this.megaText_Quantity.Text_Height = 21;
            this.megaText_Quantity.Text_IsNumber = true;
            this.megaText_Quantity.Text_Label = "Ποσότητα";
            this.megaText_Quantity.Text_MaxLength = 10;
            this.megaText_Quantity.Text_Multiline = false;
            this.megaText_Quantity.Text_ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.megaText_Quantity.Text_Textbox = "";
            // 
            // qsynt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 209);
            this.Controls.Add(this.label1);
            this.Name = "qsynt";
            this.Text = "qsynt";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.Page1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private templates.UserControls.megaText megaText_Description;
        private templates.UserControls.megaText megaText_Quantity;
    }
}