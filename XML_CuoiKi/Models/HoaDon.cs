using System;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Linq;

namespace XML_CuoiKi.Models
{
    class HoaDon
    {
        connect Fxml = new connect();
        public XDocument doc;
        public string path = "./HoaDon.xml";

        public bool CheckEmpty(string MaHoaDon, string MaNguoiDung)
        {
            return !string.IsNullOrEmpty(MaHoaDon) && !string.IsNullOrEmpty(MaNguoiDung);
        }

        public bool KiemTraMaHoaDon(string MaHoaDon)
        {
            XmlTextReader reader = new XmlTextReader("HoaDon.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaHoaDon";
            reader.Close();
            int index = dv.Find(MaHoaDon);
            return index != -1;
        }

        public bool MaHoaDonDaTonTai(string MaHoaDon)
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\HoaDon.xml");
            XmlNode node = doc1.SelectSingleNode("NewDataSet/_x0027_HoaDon_x0027_[MaHoaDon='" + MaHoaDon + "']");
            return node != null;
        }

        public void ThemHoaDon(string MaHoaDon, string MaNguoiDung)
        {
            if (MaHoaDonDaTonTai(MaHoaDon))
            {
                throw new Exception("Mã hóa đơn đã tồn tại.");
            }

            string HoaDon = "<_x0027_HoaDon_x0027_>" +
                            "<MaHoaDon>" + MaHoaDon + "</MaHoaDon>" +
                            "<MaNguoiDung>" + MaNguoiDung + "</MaNguoiDung>" +
                            "<NgayLap>" + DateTime.Now.ToString("yyyy-MM-dd") + "</NgayLap>" +
                            "<TongTien>0</TongTien>" +
                            "</_x0027_HoaDon_x0027_>";
            Fxml.Them("HoaDon.xml", HoaDon);
        }


       

        public void ThemChiTietHoaDon(string MaHoaDon, string MaLaptop, string SoLuong)
        {
            if (!KiemTraMaHoaDon(MaHoaDon))
            {
                throw new Exception("Hóa đơn không tồn tại.");
            }

            string giaBan;
            // Lấy giá bán từ Laptop.xml
            try
            {
                XDocument doc = XDocument.Load("Laptop.xml");
                var laptop = doc.Descendants("_x0027_Laptop_x0027_")
                                .FirstOrDefault(x => x.Element("MaLaptop").Value == MaLaptop);

                if (laptop == null)
                {
                    throw new Exception("Không tìm thấy Laptop với mã: " + MaLaptop);
                }

                giaBan = laptop.Element("GiaBan").Value;

                // Kiểm tra xem giaBan có phải là một số hợp lệ không
                if (!int.TryParse(giaBan, out int giaBanInt))
                {
                    throw new Exception("Giá bán không hợp lệ: " + giaBan);
                }
                if (!int.TryParse(SoLuong, out int SoLuongInt))
                {
                    throw new Exception("Giá bán không hợp lệ: " + giaBan);
                }
                // Tạo chi tiết hóa đơn
                string ChiTietHoaDon = "<_x0027_ChiTietHoaDon_x0027_>" +
                                        "<MaHoaDon>" + MaHoaDon + "</MaHoaDon>" +
                                        "<MaLaptop>" + MaLaptop + "</MaLaptop>" +
                                        "<SoLuong>" + SoLuong + "</SoLuong>" +
                                        "<GiaBan>" + giaBan + "</GiaBan>" +
                                        "</_x0027_ChiTietHoaDon_x0027_>";

                Fxml.Them("ChiTietHoaDon.xml", ChiTietHoaDon);
                CapNhatTongTien(MaHoaDon, giaBanInt, SoLuongInt); // Truyền giaBanInt đã được chuyển đổi
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy giá bán từ Laptop.xml: " + ex.Message);
            }
        }



        public void CapNhatTongTien(string MaHoaDon, int giaBan, int SoLuong)
        {
            int tongTien = 0;
            tongTien = giaBan * SoLuong;
            // Lấy tổng tiền hiện tại từ HoaDon.xml để cộng thêm
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(Application.StartupPath + "\\HoaDon.xml");
            XmlNode node1 = doc1.SelectSingleNode("NewDataSet/_x0027_HoaDon_x0027_[MaHoaDon = '" + MaHoaDon + "']");

            if (node1 != null)
            {
                int tongTienCu = int.Parse(node1["TongTien"].InnerText); // Lấy tổng tiền cũ từ HoaDon.xml
                tongTien += tongTienCu; // Cộng tổng tiền hiện tại vào tổng tiền mới

                // Cập nhật tổng tiền mới vào HoaDon.xml
                node1["TongTien"].InnerText = tongTien.ToString();
                doc1.Save(Application.StartupPath + "\\HoaDon.xml");
            }
        }






    }
}
