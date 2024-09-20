using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn1.Lib
{
    public class DinhDangEX
    {
        public void ExportFile(System.Data.DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "17";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã sản phẩm";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên sản phẩm";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Mã loại";
            cl3.ColumnWidth = 12.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Đơn giá";
            cl4.EntireColumn.NumberFormat = "#,###";
            cl4.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Số lượng";

            cl5.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void XuatFile_DoanhThu(System.Data.DataTable dataTable, string sheetName, string title, float Sum)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "B1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "17";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Năm";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tổng doanh thu";
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            cl2.ColumnWidth = 40.0;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "B3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            Microsoft.Office.Interop.Excel.Range c3;
            Microsoft.Office.Interop.Excel.Range c0;
            if (c1 == c2)
            {
                c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnEnd];
                c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnStart];
            }
            else
            {
                c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnEnd];
                c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart];
            }
            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;
            c3.Value = "=SUM(B4:B7)";

            c0.Value = "Tổng cộng";
            // Kẻ viền
            Microsoft.Office.Interop.Excel.Font boldFont = c0.Font;
            boldFont.Bold = true;

            // Thiết lập font chữ đậm cho ô Sum (c3)
            boldFont = c3.Font;
            boldFont.Bold = true;
            Range range1 = oSheet.get_Range(c0, c3);
            range1.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
        public void XuatFile_DoanhThu_TungThang(System.Data.DataTable dataTable)
        {

            // Sắp xếp dữ liệu theo tháng
            DataView dataView = dataTable.DefaultView;
            dataView.Sort = "Thang ASC";
            dataTable = dataView.ToTable();

            // Khởi tạo đối tượng Excel
            Application oExcel = new Application();
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;

            // Tạo mới một Excel Workbook
            Workbooks oBooks = oExcel.Workbooks;
            Workbook oBook = oBooks.Add(Type.Missing);
            Sheets oSheets = oBook.Worksheets;
            Worksheet oSheet = (Worksheet)oSheets.get_Item(1);
            oSheet.Name = "DoanhThuSanPham";

            // Thiết lập tiêu đề
            Range head = oSheet.get_Range("A1", "E1");
            head.MergeCells = true;
            head.Value2 = "BÁO CÁO DOANH THU";
            head.Font.Bold = true;
            head.Font.Name = "Times New Roman";
            head.Font.Size = 17;
            head.HorizontalAlignment = XlHAlign.xlHAlignCenter;

            // Thiết lập các tiêu đề cột
            //Range cl1 = oSheet.get_Range("A3", "A3");
            //cl1.Value2 = "Tháng";
            //cl1.ColumnWidth = 12;
            Range cl2 = oSheet.get_Range("A3", "A3");
            cl2.Value2 = "Tháng";
            cl2.ColumnWidth = 12;

            Range cl3 = oSheet.get_Range("B3", "B3");
            cl3.Value2 = "DoanhThu";
            cl3.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            cl3.ColumnWidth = 40;

            Range cl4 = oSheet.get_Range("C3", "C3");
            cl4.Value2 = "Số lượng";
            cl4.ColumnWidth = 12;
            Range cl6 = oSheet.get_Range("D3", "D3");
            cl6.Value2 = "Đơn giá";
            cl6.EntireColumn.NumberFormat = "#,###";
            cl6.ColumnWidth = 20;

            Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "Doanh thu";
            cl5.EntireColumn.NumberFormat = "#,###";
            cl5.ColumnWidth = 20;

            Range rowHead = oSheet.get_Range("A3", "E3");
            rowHead.Font.Bold = true;
            rowHead.Borders.LineStyle = XlLineStyle.xlContinuous;
            rowHead.Interior.ColorIndex = 6;
            rowHead.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            // Điền dữ liệu
            int rowStart = 4;
            //int columnStart = 0;
            int rowIndex = rowStart;
            int currentMonth = 0;
            double monthlyRevenue = 0;

            foreach (DataRow row in dataTable.Rows)
            {
                int month = Convert.ToInt32(row["Thang"]);
                string maSP = row["MaSanPham"].ToString();
                string tenSP = row["TenSanPham"].ToString();
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                double donGia = Convert.ToDouble(row["DonGia"]);
                double doanhThu = Convert.ToDouble(row["DoanhThu"]);
                //double revenue = Convert.ToDouble(row["DoanhThu"]);
                // Kiểm tra nếu tháng hiện tại khác tháng trước đó
                if (month != currentMonth)
                {

                    // Kiểm tra nếu không phải là lần đầu tiên duyệt qua tháng
                    if (currentMonth != 0)
                    {
                        // Hiển thị tổng doanh thu tháng trước
                        Range sumCell = oSheet.Cells[rowIndex, 5];
                        sumCell.Value = monthlyRevenue;

                        // Đánh dấu các ô tổng doanh thu tháng trước
                        Range sumRange = oSheet.get_Range("A" + rowIndex, "E" + rowIndex);
                        sumRange.Font.Bold = true;
                    }

                    currentMonth = month;
                    monthlyRevenue = 0;

                    // Tạo tiêu đề tháng mới
                    Range monthTitle = oSheet.get_Range("A" + rowIndex, "E" + rowIndex);
                    monthTitle.MergeCells = true;
                    monthTitle.Value2 = "THÁNG " + currentMonth;
                    monthTitle.Font.Bold = true;
                    monthTitle.Font.Size = 14;
                    monthTitle.HorizontalAlignment = XlHAlign.xlHAlignCenter;

                    rowIndex++;
                }

                // Điền thông tin sản phẩm
                Range ma = oSheet.Cells[rowIndex, 1];
                ma.Value = maSP;

                Range ten = oSheet.Cells[rowIndex, 2];
                ten.Value = tenSP;

                Range slg = oSheet.Cells[rowIndex, 3];
                slg.Value = soLuong;

                Range dg = oSheet.Cells[rowIndex, 4];
                dg.Value = donGia;

                Range dt = oSheet.Cells[rowIndex, 5];
                dt.Value = doanhThu;

                monthlyRevenue += doanhThu;
                rowIndex++;
            }

            // Hiển thị tổng doanh thu của tháng cuối cùng
            //Range lastMonthSumCell = oSheet.Cells[rowIndex, 5];
            //lastMonthSumCell.Value = monthlyRevenue;

            // Đánh dấu các ô tổng doanh thu tháng cuối cùng
            Range lastMonthSumRange = oSheet.get_Range("A" + rowIndex, "E" + rowIndex);
            lastMonthSumRange.Font.Bold = true;

            // Căn giữa cả bảng
            oSheet.get_Range("A1", "E" + rowIndex).HorizontalAlignment = XlHAlign.xlHAlignCenter;
        }
        public void XuatSachBanChay(System.Data.DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "B1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "17";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Tên Sách";

            cl1.ColumnWidth = 50;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Số lượng bán";
            cl2.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            cl2.ColumnWidth = 12;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "B3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 1;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            Microsoft.Office.Interop.Excel.Range c3;
            Microsoft.Office.Interop.Excel.Range c0;
            if (c1 == c2)
            {
                c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnEnd];
                c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 2, columnStart];
            }
            else
            {
                c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnEnd];
                c0 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd + 1, columnStart];
            }
            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;
            //c3.Value = "=SUM(B4:B7)";

            //c0.Value = "Tổng cộng";
            // Kẻ viền
            Microsoft.Office.Interop.Excel.Font boldFont = c0.Font;
            boldFont.Bold = true;

            // Thiết lập font chữ đậm cho ô Sum (c3)
            boldFont = c3.Font;
            boldFont.Bold = true;
            Range range1 = oSheet.get_Range(c0, c3);
            range1.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }
    }
}
