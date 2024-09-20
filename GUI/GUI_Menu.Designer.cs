
namespace GUI
{
    partial class GUI_Menu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI_Menu));
            this.pnSlide = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnQLUsers = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnHDBan = new System.Windows.Forms.Button();
            this.btnHDNhap = new System.Windows.Forms.Button();
            this.btnNV = new System.Windows.Forms.Button();
            this.btnKH = new System.Windows.Forms.Button();
            this.btnQLSach = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.pnMain = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSlide = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnSlide.SuspendLayout();
            this.pnMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnSlide
            // 
            this.pnSlide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSlide.Controls.Add(this.btnReport);
            this.pnSlide.Controls.Add(this.btnQLUsers);
            this.pnSlide.Controls.Add(this.btnLogOut);
            this.pnSlide.Controls.Add(this.btnHDBan);
            this.pnSlide.Controls.Add(this.btnHDNhap);
            this.pnSlide.Controls.Add(this.btnNV);
            this.pnSlide.Controls.Add(this.btnKH);
            this.pnSlide.Controls.Add(this.btnQLSach);
            this.pnSlide.Controls.Add(this.btnAccount);
            this.pnSlide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSlide.Location = new System.Drawing.Point(0, 0);
            this.pnSlide.Name = "pnSlide";
            this.pnSlide.Size = new System.Drawing.Size(200, 721);
            this.pnSlide.TabIndex = 0;
            // 
            // btnReport
            // 
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.Location = new System.Drawing.Point(0, 479);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(198, 80);
            this.btnReport.TabIndex = 9;
            this.btnReport.Text = "Thống kê";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnQLUsers
            // 
            this.btnQLUsers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQLUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLUsers.Location = new System.Drawing.Point(0, 559);
            this.btnQLUsers.Name = "btnQLUsers";
            this.btnQLUsers.Size = new System.Drawing.Size(198, 80);
            this.btnQLUsers.TabIndex = 8;
            this.btnQLUsers.Text = "QL Tài Khoản";
            this.btnQLUsers.UseVisualStyleBackColor = true;
            this.btnQLUsers.Click += new System.EventHandler(this.btnQLUsers_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(0, 639);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(198, 80);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Đăng Xuất";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnHDBan
            // 
            this.btnHDBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHDBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDBan.Image = ((System.Drawing.Image)(resources.GetObject("btnHDBan.Image")));
            this.btnHDBan.Location = new System.Drawing.Point(0, 400);
            this.btnHDBan.Name = "btnHDBan";
            this.btnHDBan.Size = new System.Drawing.Size(198, 80);
            this.btnHDBan.TabIndex = 6;
            this.btnHDBan.Text = "Hóa Đơn";
            this.btnHDBan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHDBan.UseVisualStyleBackColor = true;
            this.btnHDBan.Click += new System.EventHandler(this.btnHDBan_Click);
            // 
            // btnHDNhap
            // 
            this.btnHDNhap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHDNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHDNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnHDNhap.Image")));
            this.btnHDNhap.Location = new System.Drawing.Point(0, 320);
            this.btnHDNhap.Name = "btnHDNhap";
            this.btnHDNhap.Size = new System.Drawing.Size(198, 80);
            this.btnHDNhap.TabIndex = 5;
            this.btnHDNhap.Text = "Nhập Sách";
            this.btnHDNhap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHDNhap.UseVisualStyleBackColor = true;
            this.btnHDNhap.Click += new System.EventHandler(this.btnHDNhap_Click);
            // 
            // btnNV
            // 
            this.btnNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.Image = ((System.Drawing.Image)(resources.GetObject("btnNV.Image")));
            this.btnNV.Location = new System.Drawing.Point(0, 240);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(198, 80);
            this.btnNV.TabIndex = 4;
            this.btnNV.Text = "Nhân Viên";
            this.btnNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNV.UseVisualStyleBackColor = true;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // btnKH
            // 
            this.btnKH.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKH.Image = ((System.Drawing.Image)(resources.GetObject("btnKH.Image")));
            this.btnKH.Location = new System.Drawing.Point(0, 160);
            this.btnKH.Name = "btnKH";
            this.btnKH.Size = new System.Drawing.Size(198, 80);
            this.btnKH.TabIndex = 3;
            this.btnKH.Text = "Khách Hàng";
            this.btnKH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKH.UseVisualStyleBackColor = true;
            this.btnKH.Click += new System.EventHandler(this.btnKH_Click);
            // 
            // btnQLSach
            // 
            this.btnQLSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLSach.Image = ((System.Drawing.Image)(resources.GetObject("btnQLSach.Image")));
            this.btnQLSach.Location = new System.Drawing.Point(0, 80);
            this.btnQLSach.Name = "btnQLSach";
            this.btnQLSach.Size = new System.Drawing.Size(198, 80);
            this.btnQLSach.TabIndex = 2;
            this.btnQLSach.Text = "QL Sách";
            this.btnQLSach.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQLSach.UseVisualStyleBackColor = true;
            this.btnQLSach.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.AutoSize = true;
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.Image")));
            this.btnAccount.Location = new System.Drawing.Point(0, 0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(198, 80);
            this.btnAccount.TabIndex = 1;
            this.btnAccount.Text = "Tài Khoản";
            this.btnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // pnMain
            // 
            this.pnMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnMain.BackgroundImage")));
            this.pnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMain.Controls.Add(this.label1);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(285, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(721, 721);
            this.pnMain.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(208, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quản lý cửa hàng sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSlide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 721);
            this.panel1.TabIndex = 1;
            // 
            // btnSlide
            // 
            this.btnSlide.BackColor = System.Drawing.Color.Transparent;
            this.btnSlide.Image = ((System.Drawing.Image)(resources.GetObject("btnSlide.Image")));
            this.btnSlide.Location = new System.Drawing.Point(5, 11);
            this.btnSlide.Name = "btnSlide";
            this.btnSlide.Size = new System.Drawing.Size(72, 67);
            this.btnSlide.TabIndex = 0;
            this.btnSlide.UseVisualStyleBackColor = false;
            this.btnSlide.Click += new System.EventHandler(this.btnSlide_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GUI_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnSlide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GUI_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GUI_Menu";
            this.Load += new System.EventHandler(this.GUI_Menu_Load);
            this.pnSlide.ResumeLayout(false);
            this.pnSlide.PerformLayout();
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnSlide;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Button btnSlide;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnQLSach;
        private System.Windows.Forms.Button btnKH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnHDNhap;
        private System.Windows.Forms.Button btnHDBan;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnQLUsers;
        private System.Windows.Forms.Button btnReport;
    }
}