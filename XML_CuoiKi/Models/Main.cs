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
            //Xóa toàn bộ dữ liệu các bảng
            Fxml.InsertOrUpDateSQL("delete from NguoiDung");
            Fxml.InsertOrUpDateSQL("delete from Laptop");
            Fxml.InsertOrUpDateSQL("delete from DanhMucLaptop");
            Fxml.InsertOrUpDateSQL("delete from NhaCungCap");
            Fxml.InsertOrUpDateSQL("delete from HoaDon");
            Fxml.InsertOrUpDateSQL("delete from ChiTietHoaDon");
            Fxml.InsertOrUpDateSQL("delete from NhapLaptop");
            Fxml.InsertOrUpDateSQL("delete from ChiTietNhap");
            //Cập nhập toàn bộ dữ liệu các bảng
            CapNhapTungBang("NguoiDung");
            CapNhapTungBang("Laptop");
            CapNhapTungBang("DanhMucLaptop");
            CapNhapTungBang("NhaCungCap");
            CapNhapTungBang("HoaDon");
            CapNhapTungBang("ChiTietHoaDon");
            CapNhapTungBang("NhapLaptop");
            CapNhapTungBang("ChiTietNhap");
        }
    }
}
