using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML_CuoiKi.Models
{
    class NguoiDung
    {
        connect Fxml = new connect();
        public bool kiemtra(string MaNguoiDung)
        {
            XmlTextReader reader = new XmlTextReader("NguoiDung.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNguoiDung";
            reader.Close();
            int index = dv.Find(MaNguoiDung);
            if (index == -1)
            {
                return false;
            }
            return true;
        }

        public void themND(string MaNguoiDung, string HoTen, string NgaySinh, string Email, string SoDienThoai, string DiaChi, string TenDangNhap, string MatKhau, string PhanQuyen)
        {
            string noiDung = "<_x0027_NguoiDung_x0027_>" +
                            "<MaNguoiDung>" + MaNguoiDung + "</MaNguoiDung>" +
                            "<HoTen>" + HoTen + "</HoTen>" +
                            "<NgaySinh>" + NgaySinh + "</NgaySinh>" +
                            "<Email>" + Email + "</Email>" +
                            "<SoDienThoai>" + SoDienThoai + "</SoDienThoai>" +
                            "<DiaChi>" + DiaChi + "</DiaChi>" +
                            "<TenDangNhap>" + TenDangNhap + "</TenDangNhap>" +
                            "<MatKhau>" + MatKhau + "</MatKhau>" +
                            "<PhanQuyen>" + PhanQuyen + "</PhanQuyen>" +
                            "</_x0027_NguoiDung_x0027_>";
            Fxml.Them("NguoiDung.xml", noiDung);
        }

        public void suaND(string MaNguoiDung, string HoTen, string NgaySinh, string Email, string SoDienThoai, string DiaChi, string TenDangNhap, string MatKhau, string PhanQuyen)
        {
            // Tạo nội dung XML của nút mới
            string noiDung =
                "<MaNguoiDung>" + MaNguoiDung + "</MaNguoiDung>" +
                "<HoTen>" + HoTen + "</HoTen>" +
                "<NgaySinh>" + NgaySinh + "</NgaySinh>" +
                "<Email>" + Email + "</Email>" +
                "<SoDienThoai>" + SoDienThoai + "</SoDienThoai>" +
                "<DiaChi>" + DiaChi + "</DiaChi>" +
                "<TenDangNhap>" + TenDangNhap + "</TenDangNhap>" +
                "<MatKhau>" + MatKhau + "</MatKhau>" +
                "<PhanQuyen>" + PhanQuyen + "</PhanQuyen>";

            // Gọi hàm `Sua` trong lớp `connect`
            Fxml.Sua("NguoiDung.xml", "_x0027_NguoiDung_x0027_", "MaNguoiDung", MaNguoiDung, noiDung);
        }



        public void xoaND(string MaNguoiDung)
        {
            Fxml.Xoa("NguoiDung.xml", "_x0027_NguoiDung_x0027_", "MaNguoiDung", MaNguoiDung);
        }
        public bool checkEmpty(string MaNguoiDung, string HoTen, string SoDienThoai, string Email)
        {
            if (string.IsNullOrEmpty(MaNguoiDung) || string.IsNullOrEmpty(HoTen) ||
                string.IsNullOrEmpty(SoDienThoai) || string.IsNullOrEmpty(Email))
            {
                return false;
            }
            return true;
        }
    }
}
