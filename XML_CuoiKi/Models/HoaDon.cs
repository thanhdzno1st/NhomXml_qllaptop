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

		public void ThemHoaDon(string MaHoaDon, int MaNguoiDung, String TenKhachHang)
		{
			if (MaHoaDonDaTonTai(MaHoaDon))
			{
				throw new Exception("Mã hóa đơn đã tồn tại.");
			}

			string HoaDon = "<_x0027_HoaDon_x0027_>" +
							"<MaHoaDon>" + MaHoaDon + "</MaHoaDon>" +
							"<TenKhachHang>" + TenKhachHang + "</TenKhachHang>" +
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

			decimal giaBan; // GiaBan as decimal for accurate price representation
			decimal thanhTien; // Variable for calculating total price
			int maChiTiet; // Integer for MaChiTiet (detail code)

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

				// Retrieve giaBan as decimal
				if (!decimal.TryParse(laptop.Element("GiaBan").Value, out giaBan))
				{
					throw new Exception("Giá bán không hợp lệ: " + laptop.Element("GiaBan").Value);
				}

				// Check if SoLuong is a valid integer
				if (!int.TryParse(SoLuong, out int SoLuongInt))
				{
					throw new Exception("Số lượng không hợp lệ: " + SoLuong);
				}

				// Calculate the total price (Thành Tiền)
				thanhTien = giaBan * SoLuongInt;

				// Generate MaChiTiet (get the highest existing MaChiTiet + 1)
				maChiTiet = GetNextMaChiTiet(); // Function to get the next MaChiTiet

				// Tạo chi tiết hóa đơn với Mã Chi Tiết và Thành Tiền
				string ChiTietHoaDon = "<_x0027_ChiTietHoaDon_x0027_>" +
										"<MaChiTiet>" + maChiTiet + "</MaChiTiet>" + // Add Mã Chi Tiết
										"<MaHoaDon>" + MaHoaDon + "</MaHoaDon>" +
										"<MaLaptop>" + MaLaptop + "</MaLaptop>" +
										"<SoLuong>" + SoLuong + "</SoLuong>" +
										"<GiaBan>" + giaBan.ToString("F2") + "</GiaBan>" + // Format GiaBan as decimal
										"<ThanhTien>" + thanhTien.ToString("F2") + "</ThanhTien>" + // Add Thành Tiền
										"</_x0027_ChiTietHoaDon_x0027_>";

				Fxml.Them("ChiTietHoaDon.xml", ChiTietHoaDon);
				CapNhatTongTien(MaHoaDon, giaBan, SoLuongInt); // Update with Thành Tiền as well
			}
			catch (Exception ex)
			{
				// Do nothing, suppress the error
				// Optionally log the error internally if needed for debugging
				// For example: Logger.Log(ex.Message);
			}
		}
		public int GetNextMaChiTiet()
		{
			// Load ChiTietHoaDon.xml to find the highest MaChiTiet
			XDocument doc = XDocument.Load("ChiTietHoaDon.xml");

			// Get the highest MaChiTiet value
			var maxMaChiTiet = doc.Descendants("_x0027_ChiTietHoaDon_x0027_")
								  .Select(x => (int?)x.Element("MaChiTiet"))
								  .Max() ?? 0; // If no values found, return 0

			// Return the next value
			return maxMaChiTiet + 1;
		}



		public void CapNhatTongTien(string MaHoaDon, Decimal giaBan, int SoLuong)
        {
			int giaBanInt = Convert.ToInt32(giaBan);
			int tongTien = 0;
            tongTien = giaBanInt * SoLuong;
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
