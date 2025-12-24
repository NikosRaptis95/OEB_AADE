namespace DesktopBusiness.reportForms
{
    partial class genView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            this.Label_tabPage1 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label_ypoloipo = new System.Windows.Forms.Label();
            this.label_pistosi = new System.Windows.Forms.Label();
            this.label_xreosi = new System.Windows.Forms.Label();
            this.textBox_ypoloipo = new System.Windows.Forms.TextBox();
            this.textBox_pistosi = new System.Windows.Forms.TextBox();
            this.textBox_xreosi = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Label_TabControl = new System.Windows.Forms.TabControl();
            this.Label_tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Label_TabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label_tabPage1
            // 
            this.Label_tabPage1.Controls.Add(this.chart1);
            this.Label_tabPage1.Controls.Add(this.dataGridView2);
            this.Label_tabPage1.Controls.Add(this.label_ypoloipo);
            this.Label_tabPage1.Controls.Add(this.label_pistosi);
            this.Label_tabPage1.Controls.Add(this.label_xreosi);
            this.Label_tabPage1.Controls.Add(this.textBox_ypoloipo);
            this.Label_tabPage1.Controls.Add(this.textBox_pistosi);
            this.Label_tabPage1.Controls.Add(this.textBox_xreosi);
            this.Label_tabPage1.Controls.Add(this.dataGridView1);
            this.Label_tabPage1.Location = new System.Drawing.Point(4, 22);
            this.Label_tabPage1.Name = "Label_tabPage1";
            this.Label_tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.Label_tabPage1.Size = new System.Drawing.Size(890, 518);
            this.Label_tabPage1.TabIndex = 0;
            this.Label_tabPage1.Text = "Σύνολα";
            this.Label_tabPage1.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(521, 130);
            this.chart1.Name = "chart1";
            series1.BackSecondaryColor = System.Drawing.Color.Silver;
            series1.BorderColor = System.Drawing.Color.Silver;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Name = "summary";
            dataPoint1.LegendText = "Χρέωση";
            dataPoint2.LegendText = "Πίστωση";
            dataPoint3.LegendText = "Υπόλοιπο";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(361, 380);
            this.chart1.TabIndex = 16;
            this.chart1.Text = "chart1";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(507, 118);
            this.dataGridView2.TabIndex = 15;
            // 
            // label_ypoloipo
            // 
            this.label_ypoloipo.AutoSize = true;
            this.label_ypoloipo.Location = new System.Drawing.Point(526, 88);
            this.label_ypoloipo.Name = "label_ypoloipo";
            this.label_ypoloipo.Size = new System.Drawing.Size(86, 13);
            this.label_ypoloipo.TabIndex = 14;
            this.label_ypoloipo.Text = "γενικό υπόλοιπο";
            // 
            // label_pistosi
            // 
            this.label_pistosi.AutoSize = true;
            this.label_pistosi.Location = new System.Drawing.Point(526, 49);
            this.label_pistosi.Name = "label_pistosi";
            this.label_pistosi.Size = new System.Drawing.Size(95, 13);
            this.label_pistosi.TabIndex = 13;
            this.label_pistosi.Text = "σύνολο πίστωσης";
            // 
            // label_xreosi
            // 
            this.label_xreosi.AutoSize = true;
            this.label_xreosi.Location = new System.Drawing.Point(526, 10);
            this.label_xreosi.Name = "label_xreosi";
            this.label_xreosi.Size = new System.Drawing.Size(91, 13);
            this.label_xreosi.TabIndex = 12;
            this.label_xreosi.Text = "σύνολο χρέωσης";
            // 
            // textBox_ypoloipo
            // 
            this.textBox_ypoloipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_ypoloipo.Location = new System.Drawing.Point(521, 104);
            this.textBox_ypoloipo.Name = "textBox_ypoloipo";
            this.textBox_ypoloipo.ReadOnly = true;
            this.textBox_ypoloipo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_ypoloipo.Size = new System.Drawing.Size(361, 20);
            this.textBox_ypoloipo.TabIndex = 11;
            // 
            // textBox_pistosi
            // 
            this.textBox_pistosi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_pistosi.Location = new System.Drawing.Point(521, 65);
            this.textBox_pistosi.Name = "textBox_pistosi";
            this.textBox_pistosi.ReadOnly = true;
            this.textBox_pistosi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_pistosi.Size = new System.Drawing.Size(361, 20);
            this.textBox_pistosi.TabIndex = 10;
            // 
            // textBox_xreosi
            // 
            this.textBox_xreosi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.textBox_xreosi.Location = new System.Drawing.Point(521, 26);
            this.textBox_xreosi.Name = "textBox_xreosi";
            this.textBox_xreosi.ReadOnly = true;
            this.textBox_xreosi.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox_xreosi.Size = new System.Drawing.Size(361, 20);
            this.textBox_xreosi.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(507, 382);
            this.dataGridView1.TabIndex = 8;
            // 
            // Label_TabControl
            // 
            this.Label_TabControl.Controls.Add(this.Label_tabPage1);
            this.Label_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_TabControl.Location = new System.Drawing.Point(0, 0);
            this.Label_TabControl.Name = "Label_TabControl";
            this.Label_TabControl.SelectedIndex = 0;
            this.Label_TabControl.Size = new System.Drawing.Size(898, 544);
            this.Label_TabControl.TabIndex = 0;
            // 
            // genView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 544);
            this.Controls.Add(this.Label_TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "genView";
            this.Text = "γενική εικόνα";
            this.Label_tabPage1.ResumeLayout(false);
            this.Label_tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Label_TabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Label_tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label_ypoloipo;
        private System.Windows.Forms.Label label_pistosi;
        private System.Windows.Forms.Label label_xreosi;
        private System.Windows.Forms.TextBox textBox_ypoloipo;
        private System.Windows.Forms.TextBox textBox_pistosi;
        private System.Windows.Forms.TextBox textBox_xreosi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl Label_TabControl;
    }
}