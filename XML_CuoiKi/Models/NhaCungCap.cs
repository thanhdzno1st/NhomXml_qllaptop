using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;


namespace XML_CuoiKi.Models
{
    class NhaCungCap
    {
        connect Fxml = new connect();
        public bool kiemtra(string MaDanhMuc)
        {
            XmlTextReader reader = new XmlTextReader("NhaCungCap.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNhaCungCap";
            reader.Close();
            int index = dv.Find(MaDanhMuc);
            if (index == -1)
            {
                return false;
            }
            return true;
        }

        public void them(string MaNhaCungCap, string TenNhaCungCap, string SoDienThoai, string Email, string DiaChi, string Anh)
        {
            string noiDung = "<_x0027_NhaCungCap_x0027_>" +
                            "<MaNhaCungCap>" + MaNhaCungCap + "</MaNhaCungCap>" +
                            "<TenNhaCungCap>" + TenNhaCungCap + "</TenNhaCungCap>" +
                            "<SoDienThoai>" + SoDienThoai + "</SoDienThoai>" +
                            "<Email>" + Email + "</Email>" +
                            "<DiaChi>" + DiaChi + "</DiaChi>" +
                            "<Anh>" + Anh + "</Anh>" +
                            "</_x0027_NhaCungCap_x0027_>";
            Fxml.Them("NhaCungCap.xml", noiDung);
        }

        public void sua(string MaNhaCungCap, string TenNhaCungCap, string SoDienThoai, string Email, string DiaChi, string Anh)
        {
            // Tạo nội dung XML của nút mới
            string noiDung =

                            "<MaNhaCungCap>" + MaNhaCungCap + "</MaNhaCungCap>" +
                            "<TenNhaCungCap>" + TenNhaCungCap + "</TenNhaCungCap>" +
                            "<SoDienThoai>" + SoDienThoai + "</SoDienThoai>" +
                            "<Email>" + Email + "</Email>" +
                            "<DiaChi>" + DiaChi + "</DiaChi>" +
                            "<Anh>" + Anh + "</Anh>";

            // Gọi hàm `Sua` trong lớp `connect`
            Fxml.Sua("NhaCungCap.xml", "_x0027_NhaCungCap_x0027_", "MaNhaCungCap", MaNhaCungCap, noiDung);
        }



        public void xoa(string MaNhaCungCap)
        {
            Fxml.Xoa("NhaCungCap.xml", "_x0027_NhaCungCap_x0027_", "MaNhaCungCap", MaNhaCungCap);
        }
        public bool checkEmpty(string MaDanhMuc, string TenDanhMuc, string MoTa)
        {
            if (string.IsNullOrEmpty(MaDanhMuc) || string.IsNullOrEmpty(TenDanhMuc) ||
                string.IsNullOrEmpty(MoTa))
            {
                return false;
            }
            return true;
        }
    }
}
