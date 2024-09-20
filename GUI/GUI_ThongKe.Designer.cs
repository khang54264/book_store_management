
namespace GUI
{
    partial class GUI_ThongKe
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDTNam = new System.Windows.Forms.ComboBox();
            this.chartSach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbS = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbSNam = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSThang = new System.Windows.Forms.ComboBox();
            this.btnInKho = new System.Windows.Forms.Button();
            this.btnInExc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSach)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDoanhThu
            // 
            chartArea11.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chartDoanhThu.Legends.Add(legend11);
            this.chartDoanhThu.Location = new System.Drawing.Point(12, 120);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(650, 589);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Text = "Doanh thu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thống kê doanh thu";
            // 
            // cmbDT
            // 
            this.cmbDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDT.FormattingEnabled = true;
            this.cmbDT.Items.AddRange(new object[] {
            "Theo tháng",
            "Theo năm"});
            this.cmbDT.Location = new System.Drawing.Point(127, 81);
            this.cmbDT.Name = "cmbDT";
            this.cmbDT.Size = new System.Drawing.Size(162, 28);
            this.cmbDT.TabIndex = 2;
            this.cmbDT.SelectedIndexChanged += new System.EventHandler(this.cmbDT_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Loại thống kê";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(309, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Năm";
            // 
            // cmbDTNam
            // 
            this.cmbDTNam.Enabled = false;
            this.cmbDTNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDTNam.FormattingEnabled = true;
            this.cmbDTNam.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cmbDTNam.Location = new System.Drawing.Point(359, 81);
            this.cmbDTNam.Name = "cmbDTNam";
            this.cmbDTNam.Size = new System.Drawing.Size(139, 28);
            this.cmbDTNam.TabIndex = 7;
            this.cmbDTNam.SelectedIndexChanged += new System.EventHandler(this.cmbNam_SelectedIndexChanged);
            // 
            // chartSach
            // 
            chartArea12.Name = "ChartArea1";
            this.chartSach.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chartSach.Legends.Add(legend12);
            this.chartSach.Location = new System.Drawing.Point(685, 120);
            this.chartSach.Name = "chartSach";
            this.chartSach.Size = new System.Drawing.Size(650, 589);
            this.chartSach.TabIndex = 8;
            this.chartSach.Text = "Doanh thu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(798, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 36);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thống kê sách bán chạy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(698, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Loại thống kê";
            // 
            // cmbS
            // 
            this.cmbS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbS.FormattingEnabled = true;
            this.cmbS.Items.AddRange(new object[] {
            "Theo tháng",
            "Theo năm"});
            this.cmbS.Location = new System.Drawing.Point(835, 81);
            this.cmbS.Name = "cmbS";
            this.cmbS.Size = new System.Drawing.Size(130, 28);
            this.cmbS.TabIndex = 11;
            this.cmbS.SelectedIndexChanged += new System.EventHandler(this.cmbS_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(981, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Năm";
            // 
            // cmbSNam
            // 
            this.cmbSNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSNam.FormattingEnabled = true;
            this.cmbSNam.Items.AddRange(new object[] {
            "2020",
            "2021",
            "2022",
            "2023"});
            this.cmbSNam.Location = new System.Drawing.Point(1031, 81);
            this.cmbSNam.Name = "cmbSNam";
            this.cmbSNam.Size = new System.Drawing.Size(118, 28);
            this.cmbSNam.TabIndex = 13;
            this.cmbSNam.SelectedIndexChanged += new System.EventHandler(this.cmbSNam_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1167, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tháng";
            // 
            // cmbSThang
            // 
            this.cmbSThang.Enabled = false;
            this.cmbSThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSThang.FormattingEnabled = true;
            this.cmbSThang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbSThang.Location = new System.Drawing.Point(1237, 81);
            this.cmbSThang.Name = "cmbSThang";
            this.cmbSThang.Size = new System.Drawing.Size(83, 28);
            this.cmbSThang.TabIndex = 15;
            this.cmbSThang.SelectedIndexChanged += new System.EventHandler(this.cmbSThang_SelectedIndexChanged);
            // 
            // btnInKho
            // 
            this.btnInKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInKho.Location = new System.Drawing.Point(513, 68);
            this.btnInKho.Name = "btnInKho";
            this.btnInKho.Size = new System.Drawing.Size(149, 41);
            this.btnInKho.TabIndex = 16;
            this.btnInKho.Text = "Doanh Thu Năm";
            this.btnInKho.UseVisualStyleBackColor = true;
            this.btnInKho.Click += new System.EventHandler(this.btnInKho_Click);
            // 
            // btnInExc
            // 
            this.btnInExc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInExc.Location = new System.Drawing.Point(1204, 9);
            this.btnInExc.Name = "btnInExc";
            this.btnInExc.Size = new System.Drawing.Size(116, 40);
            this.btnInExc.TabIndex = 17;
            this.btnInExc.Text = "In Báo Cáo";
            this.btnInExc.UseVisualStyleBackColor = true;
            this.btnInExc.Click += new System.EventHandler(this.btnInExc_Click);
            // 
            // GUI_ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 721);
            this.Controls.Add(this.btnInExc);
            this.Controls.Add(this.btnInKho);
            this.Controls.Add(this.cmbSThang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSNam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chartSach);
            this.Controls.Add(this.cmbDTNam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartDoanhThu);
            this.Name = "GUI_ThongKe";
            this.Text = "GUI_ThongKe";
            this.Load += new System.EventHandler(this.GUI_ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDTNam;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbSNam;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSThang;
        private System.Windows.Forms.Button btnInKho;
        private System.Windows.Forms.Button btnInExc;
    }
}