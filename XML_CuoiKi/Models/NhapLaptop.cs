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
            dt.Columns.Add("MaChiTietNhap", typeof(int));
            dt.Columns.Add("MaNhapHang", typeof(int));
            dt.Columns.Add("MaLaptop", typeof(int));
            dt.Columns.Add("SoLuongNhap", typeof(int));
            dt.Columns.Add("GiaNhap", typeof(decimal));
            dt.Columns.Add("ThanhTienNhap", typeof(decimal));

            XDocument doc = XDocument.Load(path1);
            var list = doc.Descendants("_x0027_ChiTietNhap_x0027_")
                          .Where(x => x.Element("MaNhapHang")?.Value == MaNhapHang);

            foreach (var item in list)
            {
                dt.Rows.Add(
                    int.Parse(item.Element("MaChiTietNhap")?.Value ?? "0"),
                    int.Parse(item.Element("MaNhapHang")?.Value ?? "0"),
                    int.Parse(item.Element("MaLaptop")?.Value ?? "0"),
                    int.Parse(item.Element("SoLuongNhap")?.Value ?? "0"),
                    decimal.Parse(item.Element("GiaNhap")?.Value ?? "0"),
                    decimal.Parse(item.Element("ThanhTienNhap")?.Value ?? "0")
                );
            }

            return dt;
        }

        public void ThemChiTiet(string MaChiTietNhap, string MaNhapHang, string MaLaptop, string SoLuongNhap, string GiaNhap)
        {
            if (!int.TryParse(SoLuongNhap, out int SoLuongInt))
            {
                throw new Exception("Số lượng không hợp lệ: " + SoLuongNhap);
            }

            if (!int.TryParse(GiaNhap, out int GiaNhapDecimal))
            {
                throw new Exception("Giá nhập không hợp lệ: " + GiaNhap);
            }

            // Tính ThanhTienNhap
            decimal ThanhTienNhap = GiaNhapDecimal * SoLuongInt;

            string ChiTiet = "<_x0027_ChiTietNhap_x0027_>" +
                                    "<MaChiTietNhap>" + MaChiTietNhap + "</MaChiTietNhap>" +
                                    "<MaNhapHang>" + MaNhapHang + "</MaNhapHang>" +
                                    "<MaLaptop>" + MaLaptop + "</MaLaptop>" +
                                    "<SoLuongNhap>" + SoLuongNhap + "</SoLuongNhap>" +
                                    "<GiaNhap>" + GiaNhap + "</GiaNhap>" +
                                    "<ThanhTienNhap>" + ThanhTienNhap.ToString() + "</ThanhTienNhap>" +
                                    "</_x0027_ChiTietNhap_x0027_>";

            Fxml.Them("ChiTietNhap.xml", ChiTiet);
            CapNhatTongTien(MaNhapHang, GiaNhapDecimal, SoLuongInt);
        }

        public void CapNhatTongTien(string MaNhapHang, decimal GiaNhap, int SoLuong)
        {
            decimal tongTien = GiaNhap * SoLuong;
            // Lấy tổng tiền hiện tại từ HoaDon.xml để cộng thêm
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\NhapLaptop.xml");
            XmlNode node1 = doc1.SelectSingleNode("NewDataSet/_x0027_NhapLaptop_x0027_[MaNhapHang = '" + MaNhapHang + "']");

            if (node1 != null)
            {
                decimal tongTienCu = decimal.Parse(node1["TongTienNhap"].InnerText); // Lấy tổng tiền cũ từ HoaDon.xml
                tongTien += tongTienCu; // Cộng tổng tiền hiện tại vào tổng tiền mới

                // Cập nhật tổng tiền mới vào HoaDon.xml
                node1["TongTienNhap"].InnerText = tongTien.ToString();
                doc1.Save(Application.StartupPath + "\\NhapLaptop.xml");
            }
        }
    }
}
