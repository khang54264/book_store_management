using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;
using System.Windows.Forms.DataVisualization.Charting;
using DoAn1.Lib;

namespace GUI
{
    public partial class GUI_ThongKe : Form
    {
        BUS_TKBC bus_tkbc = new BUS_TKBC();
        Series DoanhThu = new Series();
        Series Sach = new Series();
        
        public GUI_ThongKe()
        {
            InitializeComponent();
        }

        private void GUI_ThongKe_Load(object sender, EventArgs e)
        {
            //Doanh thu
            DoanhThu.Name = "Doanh Thu";
            DoanhThu.ChartType = SeriesChartType.Column;
            DoanhThu.IsValueShownAsLabel = true;          
            chartDoanhThu.Titles.Add("Biểu Đồ Doanh Thu");
            chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
            chartDoanhThu.ChartAreas[0].AxisX.Minimum = 1;
            chartDoanhThu.ChartAreas[0].AxisX.Maximum= 12;
            chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
            chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (Đồng)";
            DataTable dt1 = new DataTable();
            dt1=bus_tkbc.getDTThang(DateTime.Now);
            foreach (DataRow row in dt1.Rows)
            {
                DoanhThu.Points.AddXY(row["Thang"], row["DoanhThu"]);
            }
            chartDoanhThu.Series.Add(DoanhThu);
            chartDoanhThu.DataBind();


            //Sách bán chạy
            Sach.Name = "Sách";
            Sach.ChartType = SeriesChartType.Pie;
            Sach.IsValueShownAsLabel = true;
            chartSach.Titles.Add("Biểu Đồ Sách Bán Chạy Nhất");
            DataTable dt2 = new DataTable();
            dt2 = bus_tkbc.getSNam(DateTime.Now);
            foreach (DataRow row in dt2.Rows)
            {
                Sach.Points.AddXY(row["TenSach"], row["tong_so_luong"]);
            }
            chartSach.Series.Add(Sach);
            chartSach.DataBind();
        }
        private void cmbDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartDoanhThu.Series.Remove(DoanhThu);
            DoanhThu.ResetIsValueShownAsLabel();
            DoanhThu.IsValueShownAsLabel = true;
            DoanhThu.Points.Clear();
            switch (cmbDT.SelectedIndex)
            {
                case 0:
                    {
                        chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
                        chartDoanhThu.ChartAreas[0].AxisX.Minimum = 1;
                        chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                        chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (Đồng)";
                        DataTable dt = new DataTable();
                        dt = bus_tkbc.getDTThang(DateTime.Now);
                        foreach (DataRow row in dt.Rows)
                        {
                            DoanhThu.Points.AddXY(row["Thang"], row["DoanhThu"]);
                        }
                        chartDoanhThu.Series.Add(DoanhThu);
                        chartDoanhThu.DataBind();
                        cmbDTNam.Enabled = true;
                        break;
                    }
                case 1:
                    {
                        chartDoanhThu.ChartAreas[0].AxisX.Title = "Năm";
                        chartDoanhThu.ChartAreas[0].AxisX.Minimum = 2020;
                        chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                        chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (Đồng)";
                        DataTable dt = new DataTable();
                        dt = bus_tkbc.getDTNam(DateTime.Now);
                        foreach (DataRow row in dt.Rows)
                        {
                            DoanhThu.Points.AddXY(row["Nam"], row["DoanhThu"]);
                        }
                        chartDoanhThu.Series.Add(DoanhThu);
                        chartDoanhThu.DataBind();
                        cmbDTNam.Enabled = false;
                        break;
                    }
            }
        }

        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDT.SelectedIndex == 0)
            {
                DataTable dt = new DataTable();
                chartDoanhThu.Series.Remove(DoanhThu);
                DoanhThu.ResetIsValueShownAsLabel();
                DoanhThu.IsValueShownAsLabel = true;
                DoanhThu.Points.Clear();
                chartDoanhThu.ChartAreas[0].AxisX.Title = "Tháng";
                chartDoanhThu.ChartAreas[0].AxisY.Title = "Doanh thu (Đồng)";
                chartDoanhThu.ChartAreas[0].AxisX.Minimum = 1;
                chartDoanhThu.ChartAreas[0].AxisX.Maximum = 12;
                chartDoanhThu.ChartAreas[0].AxisX.Interval = 1;
                int nam = int.Parse(cmbDTNam.SelectedItem.ToString());
                DateTime date = new DateTime(nam, 01, 01);
                dt = bus_tkbc.getDTThang(date);
                foreach (DataRow row in dt.Rows)
                {
                    DoanhThu.Points.AddXY(row["Thang"], row["DoanhThu"]);
                }
                chartDoanhThu.Series.Add(DoanhThu);
                chartDoanhThu.DataBind();
            }
            else
            {
                return;
            }
        }
        private void cmbS_SelectedIndexChanged(object sender, EventArgs e)
        {
            chartSach.Series.Remove(Sach);
            Sach.ResetIsValueShownAsLabel();
            Sach.IsValueShownAsLabel = true;
            Sach.Points.Clear();
            cmbSNam.SelectedIndex = 3;
            switch (cmbS.SelectedIndex)
            {
                case 0:
                        {
                            DataTable dt = new DataTable();
                            dt = bus_tkbc.getSThang(DateTime.Now);
                            foreach (DataRow row in dt.Rows)
                            {
                                Sach.Points.AddXY(row["TenSach"], row["tong_so_luong"]);
                            }
                            chartSach.Series.Add(Sach);
                            chartSach.DataBind();
                            cmbSThang.SelectedIndex = 0;
                            cmbSThang.Enabled = true;
                            break;
                        }
                case 1:
                        {
                            DataTable dt = new DataTable();
                            dt = bus_tkbc.getSNam(DateTime.Now);
                            foreach (DataRow row in dt.Rows)
                            {
                                Sach.Points.AddXY(row["TenSach"], row["tong_so_luong"]);
                            }
                            chartSach.Series.Add(Sach);
                            chartSach.DataBind();                      
                            cmbSThang.Enabled = false;
                            break;
                        }
            }
        }

        private void cmbSNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            chartSach.Series.Remove(Sach);
            Sach.ResetIsValueShownAsLabel();
            Sach.IsValueShownAsLabel = true;
            Sach.Points.Clear();
            if (cmbS.SelectedItem.ToString() == "Theo năm")
            {
                int nam = int.Parse(cmbSNam.SelectedItem.ToString());
                DateTime date = new DateTime(nam, 01, 01);
                dt = bus_tkbc.getSNam(date);
                foreach (DataRow row in dt.Rows)
                {
                    Sach.Points.AddXY(row["TenSach"], row["tong_so_luong"]);
                }
                chartSach.Series.Add(Sach);
                chartSach.DataBind();
                cmbSThang.SelectedIndex = 0;
            }
            else if (cmbS.SelectedItem.ToString() == "Theo tháng")
            {
                cmbSThang.SelectedIndex = 0;
                int thang;
                int nam = int.Parse(cmbSNam.SelectedItem.ToString());
                if (cmbSThang.SelectedItem.ToString() == null || cmbSThang.SelectedItem.ToString() == "")
                    thang = 1;
                else
                {
                    thang = int.Parse(cmbSThang.SelectedItem.ToString());
                }
                DateTime date = new DateTime(nam, thang, 01);
                dt = bus_tkbc.getSThang(date);
                foreach (DataRow row in dt.Rows)
                {
                    Sach.Points.AddXY(row["TenSach"], row["tong_so_luong"]);
                }
                chartSach.DataBind();
            }
        }

        private void cmbSThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            chartSach.Series.Remove(Sach);
            Sach.ResetIsValueShownAsLabel();
            Sach.IsValueShownAsLabel = true;
            Sach.Points.Clear();
            int thang;
            int nam = int.Parse(cmbSNam.SelectedItem.ToString());
            if (cmbSThang.SelectedItem.ToString() == null || cmbSThang.SelectedItem.ToString() == "")
                thang = 1;
            else
            {
                thang = int.Parse(cmbSThang.SelectedItem.ToString());
            }
            DateTime date = new DateTime(nam, thang, 01);
            dt = bus_tkbc.getSThang(date);
            foreach (DataRow row in dt.Rows)
            {
                Sach.Points.AddXY(row["TenSach"], row["tong_so_luong"]);
            }
            chartSach.Series.Add(Sach);
            chartSach.DataBind();
        }

        private void btnInKho_Click(object sender, EventArgs e)
        {
            DinhDangEX exc = new DinhDangEX();
            System.Data.DataTable dt = bus_tkbc.getDTNam(DateTime.Now);
            float sum = 0;
            exc.XuatFile_DoanhThu(dt, "Doanh Thu", "Doanh Thu Theo Năm", sum);
        }

        private void btnInExc_Click(object sender, EventArgs e)
        {
            DinhDangEX exc = new DinhDangEX();
            System.Data.DataTable dt = bus_tkbc.getSNam(DateTime.Now);
            exc.XuatSachBanChay(dt, "Báo cáo", "Sách Bán Chạy Nhất");
        }
    }
}
