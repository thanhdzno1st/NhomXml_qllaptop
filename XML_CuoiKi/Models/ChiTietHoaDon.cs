using System;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Linq;

namespace XML_CuoiKi.Models
{
    class ChiTietHoaDon
    {
        connect Fxml = new connect();
        public XDocument doc;
        public string path = "./ChiTietHoaDon.xml";

        public bool CheckEmpty(string MaHoaDon, string MaLaptop, string SoLuong, string GiaBan)
        {
            return !string.IsNullOrEmpty(MaHoaDon) &&
                   !string.IsNullOrEmpty(MaLaptop) &&
                   !string.IsNullOrEmpty(SoLuong) &&
                   !string.IsNullOrEmpty(GiaBan);
        }

        public bool MaChiTietHoaDonTonTai(string MaHoaDon, string MaLaptop)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\ChiTietHoaDon.xml");
            XmlNode node = doc1.SelectSingleNode("NewDataSet/_x0027_ChiTietHoaDon_x0027_[MaHoaDon='" + MaHoaDon + "' and MaLaptop='" + MaLaptop + "']");
            return node != null;
        }

        public void ThemChiTietHoaDon(string MaHoaDon, string MaLaptop, string SoLuong, string GiaBan)
        {
            if (MaChiTietHoaDonTonTai(MaHoaDon, MaLaptop))
            {
                throw new Exception("Chi tiết hóa đơn với mã sản phẩm đã tồn tại.");
            }

            string ChiTietHoaDon = "<_x0027_ChiTietHoaDon_x0027_>" +
                                    "<MaHoaDon>" + MaHoaDon + "</MaHoaDon>" +
                                    "<MaLaptop>" + MaLaptop + "</MaLaptop>" +
                                    "<SoLuong>" + SoLuong + "</SoLuong>" +
                                    "<GiaBan>" + GiaBan + "</GiaBan>" +
                                    "</_x0027_ChiTietHoaDon_x0027_>";

            Fxml.Them("ChiTietHoaDon.xml", ChiTietHoaDon);
        }

        public DataTable HienThiChiTietHoaDon(string MaHoaDon)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHoaDon", typeof(int));
            dt.Columns.Add("MaLaptop", typeof(int));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("GiaBan", typeof(decimal));

            XDocument doc = XDocument.Load(path);
            var list = doc.Descendants("_x0027_ChiTietHoaDon_x0027_")
                          .Where(x => x.Element("MaHoaDon")?.Value == MaHoaDon);

            foreach (var item in list)
            {
                dt.Rows.Add(
                    int.Parse(item.Element("MaHoaDon")?.Value ?? "0"),
                    int.Parse(item.Element("MaLaptop")?.Value ?? "0"),
                    int.Parse(item.Element("SoLuong")?.Value ?? "0"),
                    decimal.Parse(item.Element("GiaBan")?.Value ?? "0")
                );
            }

            return dt;
        }


        public void CapNhatChiTietHoaDon(string MaHoaDon, string MaLaptop, string SoLuong, string GiaBan)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\ChiTietHoaDon.xml");
            XmlNode node = doc1.SelectSingleNode("NewDataSet/_x0027_ChiTietHoaDon_x0027_[MaHoaDon='" + MaHoaDon + "' and MaLaptop='" + MaLaptop + "']");

            if (node != null)
            {
                node["SoLuong"].InnerText = SoLuong;
                node["GiaBan"].InnerText = GiaBan;
                doc1.Save(Application.StartupPath + "\\ChiTietHoaDon.xml");
            }
            else
            {
                throw new Exception("Không tìm thấy chi tiết hóa đơn để cập nhật.");
            }
        }
    }
}
