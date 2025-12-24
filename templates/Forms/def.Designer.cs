#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace templates.Forms
{
    partial class def
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
            this.SuspendLayout();
            // 
            // def
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderColor = System.Drawing.Color.Gainsboro;
            this.CaptionBarColor = System.Drawing.Color.LightSteelBlue;
            this.CaptionBarHeight = 35;
            this.CaptionButtonColor = System.Drawing.Color.Gray;
            this.CaptionButtonHoverColor = System.Drawing.Color.Coral;
            this.ClientSize = new System.Drawing.Size(660, 285);
            this.DropShadow = true;
            this.Name = "def";
            this.ShowIcon = false;
            this.Text = "iLake";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.def_FormClosing);
            this.Load += new System.EventHandler(this.def_Load);
            this.Shown += new System.EventHandler(this.def_Shown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}