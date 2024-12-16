using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_CuoiKi.Models
{
    class Main
    {
        connect Fxml = new connect();
        void CapNhapTungBang(string tenBang)
        {
            string duongDan = @"" + tenBang + ".xml";
            DataTable table = Fxml.HienThi(duongDan);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string sql = "insert into " + tenBang + " values(";
                for (int j = 0; j < table.Columns.Count - 1; j++)
                {
                    sql += "N'" + table.Rows[i][j].ToString().Trim() + "',";
                }
                sql += "N'" + table.Rows[i][table.Columns.Count - 1].ToString().Trim() + "'";
                sql += ")";
                //MessageBox.Show(sql);
                Fxml.InsertOrUpDateSQL(sql);
            }
        }
        public void CapNhapSQL()
        {
            Fxml.InsertOrUpDateSQL("DELETE FROM NhapLaptop");
            Fxml.InsertOrUpDateSQL("DELETE FROM ChiTietHoaDon");
            Fxml.InsertOrUpDateSQL("DELETE FROM ChiTietNhap");
            Fxml.InsertOrUpDateSQL("DELETE FROM NhaCungCap");
            Fxml.InsertOrUpDateSQL("DELETE FROM HoaDon");
            Fxml.InsertOrUpDateSQL("DELETE FROM Laptop");
            Fxml.InsertOrUpDateSQL("DELETE FROM DanhMucLaptop");
            Fxml.InsertOrUpDateSQL("DELETE FROM NguoiDung");



            // Cập nhật toàn bộ dữ liệu các bảng
            CapNhapTungBang("NguoiDung");
            CapNhapTungBang("DanhMucLaptop");
            CapNhapTungBang("Laptop");
            CapNhapTungBang("HoaDon");
            CapNhapTungBang("ChiTietHoaDon");
            CapNhapTungBang("NhaCungCap");
            CapNhapTungBang("NhapLaptop");
            CapNhapTungBang("ChiTietNhap");
        }
    }
}
