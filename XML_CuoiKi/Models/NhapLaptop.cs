using System;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Linq;

namespace XML_CuoiKi.Models
{
    class NhapLaptop
    {
        connect Fxml = new connect();
        public XDocument doc;
        public string path = "./NhapLaptop.xml";
        public string path1 = "./ChiTietNhap.xml";
        public bool KiemTraMaHoaDon(string MaNhapHang)
        {
            XmlTextReader reader = new XmlTextReader("NhapLaptop.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNhapHang";
            reader.Close();
            int index = dv.Find(MaNhapHang);
            return index != -1;
        }

        public bool MaHoaDonDaTonTai(string MaNhapHang)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\NhapLaptop.xml");
            XmlNode node = doc1.SelectSingleNode("NewDataSet/_x0027_NhapLaptop_x0027_[MaNhapHang='" + MaNhapHang + "']");
            return node != null;
        }

        public void Them(string MaNhapHang, string MaNhaCungCap, string MaNhanVien)
        {
            if (MaHoaDonDaTonTai(MaNhapHang))
            {
                throw new Exception("Mã nhập đã tồn tại.");
            }

            string HoaDon = "<_x0027_NhapLaptop_x0027_>" +
                            "<MaNhapHang>" + MaNhapHang + "</MaNhapHang>" +
                            "<MaNhaCungCap>" + MaNhaCungCap + "</MaNhaCungCap>" +
                            "<MaNhanVien>" + MaNhanVien + "</MaNhanVien>" +
                            "<NgayNhap>" + DateTime.Now.ToString("yyyy-MM-dd") + "</NgayNhap>" +
                            "<TongTienNhap>0</TongTienNhap>" +
                            "</_x0027_NhapLaptop_x0027_>";
            Fxml.Them("NhapLaptop.xml", HoaDon);
        }
        public DataTable HienThiChiTiet(string MaNhapHang)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaNhapHang", typeof(int));
            dt.Columns.Add("MaLaptop", typeof(int));
            dt.Columns.Add("SoLuongNhap", typeof(int));
            dt.Columns.Add("GiaNhap", typeof(int));

            XDocument doc = XDocument.Load(path1);
            var list = doc.Descendants("_x0027_ChiTietNhap_x0027_")
                          .Where(x => x.Element("MaNhapHang")?.Value == MaNhapHang);

            foreach (var item in list)
            {
                dt.Rows.Add(
                    int.Parse(item.Element("MaNhapHang")?.Value ?? "0"),
                    int.Parse(item.Element("MaLaptop")?.Value ?? "0"),
                    int.Parse(item.Element("SoLuongNhap")?.Value ?? "0"),
                    decimal.Parse(item.Element("GiaNhap")?.Value ?? "0")
                );
            }

            return dt;
        }
    }
}
