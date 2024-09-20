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

namespace GUI
{
    public partial class GUI_InHD : Form
    {
        BUS_HDBan bus_hdb = new BUS_HDBan();
        BUS_HDNhap bus_hdn = new BUS_HDNhap();
        private string loaihd;
        private string mahd;
        public string Loaihd { get => loaihd; set => loaihd = value; }
        public string Mahd { get => mahd; set => mahd = value; }

        public GUI_InHD(string lhd, string mhd) : this()
        {
            this.Loaihd = lhd;
            this.Mahd = mhd;
        }
        public GUI_InHD()
        {
            InitializeComponent();
        }

        private void GUI_InHD_Load(object sender, EventArgs e)
        {
            if(Loaihd=="HDB")
            {
                cysHoaDonBan rpt = new cysHoaDonBan();
                DataSet ds = new DataSet();
                DataTable dt = bus_hdb.printHDBan(Mahd);
                ds.Tables.Add(dt);
                rpt.SetDataSource(ds);
                string query = "{@MaHDB}='" + Mahd.Trim() + "'";
                crystalReportViewer1.SelectionFormula = query;
                crystalReportViewer1.ReportSource = rpt;
            }
            if(Loaihd=="HDN")
            {
                cysHoaDonNhap rpt = new cysHoaDonNhap();
                DataSet ds = new DataSet();
                DataTable dt = bus_hdn.printHDNhap(Mahd);
                ds.Tables.Add(dt);
                rpt.SetDataSource(ds);
                string query = "{@MaHDN}='" + Mahd.Trim() + "'";
                crystalReportViewer1.SelectionFormula = query;
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}
