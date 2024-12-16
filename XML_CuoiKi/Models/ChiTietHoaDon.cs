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

		// Kiểm tra dữ liệu đầu vào
		public bool CheckEmpty(string MaHoaDon, string MaLaptop, string SoLuong, decimal GiaBan)
		{
			return !string.IsNullOrEmpty(MaHoaDon) &&
				   !string.IsNullOrEmpty(MaLaptop) &&
				   !string.IsNullOrEmpty(SoLuong) &&
				   GiaBan > 0;
		}

		// Kiểm tra xem chi tiết hóa đơn có tồn tại hay không
		public bool MaChiTietHoaDonTonTai(string MaHoaDon, string MaLaptop)
		{
			XmlDocument doc1 = new XmlDocument();
			doc1.Load(Application.StartupPath + "\\ChiTietHoaDon.xml");
			XmlNode node = doc1.SelectSingleNode("NewDataSet/_x0027_ChiTietHoaDon_x0027_[" +
				"MaHoaDon='" + MaHoaDon + "' and MaLaptop='" + MaLaptop + "']");
			return node != null;
		}

		// Thêm chi tiết hóa đơn mới
		public void ThemChiTietHoaDon(string MaHoaDon, string MaLaptop, string SoLuong, decimal GiaBan)
		{
			if (MaChiTietHoaDonTonTai(MaHoaDon, MaLaptop))
			{
				throw new Exception("Chi tiết hóa đơn với mã sản phẩm đã tồn tại.");
			}

			string MaChiTiet = GenerateMaChiTiet(); // Giả sử bạn có một hàm để tạo mã chi tiết
			decimal thanhTien = decimal.Parse(SoLuong) * GiaBan;

			string ChiTietHoaDon = "<_x0027_ChiTietHoaDon_x0027_>" +
									"<MaChiTiet>" + MaChiTiet + "</MaChiTiet>" +
									"<MaHoaDon>" + MaHoaDon + "</MaHoaDon>" +
									"<MaLaptop>" + MaLaptop + "</MaLaptop>" +
									"<SoLuong>" + SoLuong + "</SoLuong>" +
									"<GiaBan>" + GiaBan.ToString("F2") + "</GiaBan>" +
									"<ThanhTien>" + thanhTien.ToString("F2") + "</ThanhTien>" + // Tính thành tiền
									"</_x0027_ChiTietHoaDon_x0027_>";

			Fxml.Them("ChiTietHoaDon.xml", ChiTietHoaDon);
		}

		// Tạo mã chi tiết (có thể sửa theo logic của bạn)
		private string GenerateMaChiTiet()
		{
			// Tạo mã chi tiết ngẫu nhiên hoặc dựa vào cơ sở dữ liệu hiện tại
			// Ví dụ đơn giản:
			return Guid.NewGuid().ToString();
		}

		// Hiển thị chi tiết hóa đơn theo mã hóa đơn
		public DataTable HienThiChiTietHoaDon(string MaHoaDon)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("MaChiTiet", typeof(string));  // Thêm cột MaChiTiet
			dt.Columns.Add("MaHoaDon", typeof(int));
			dt.Columns.Add("MaLaptop", typeof(int));
			dt.Columns.Add("SoLuong", typeof(int));
			dt.Columns.Add("GiaBan", typeof(decimal));
			dt.Columns.Add("ThanhTien", typeof(decimal));  // Thêm cột ThanhTien

			try
			{
				XDocument doc = XDocument.Load(path);

				// Lọc danh sách theo MaHoaDon
				var list = doc.Descendants("_x0027_ChiTietHoaDon_x0027_")
							  .Where(x => x.Element("MaHoaDon")?.Value == MaHoaDon);

				foreach (var item in list)
				{
					string maChiTiet = item.Element("MaChiTiet")?.Value ?? "";
					int maHoaDon = int.Parse(item.Element("MaHoaDon")?.Value ?? "0");
					int maLaptop = int.Parse(item.Element("MaLaptop")?.Value ?? "0");
					int soLuong = int.Parse(item.Element("SoLuong")?.Value ?? "0");
					decimal giaBan = decimal.Parse(item.Element("GiaBan")?.Value ?? "0");
					decimal thanhTien = decimal.Parse(item.Element("ThanhTien")?.Value ?? "0");

					// Thêm một dòng vào DataTable
					dt.Rows.Add(
						maChiTiet,  // Hiển thị MaChiTiet
						maHoaDon,
						maLaptop,
						soLuong,
						giaBan,
						thanhTien  // Hiển thị Thành Tiền
					);
				}
			}
			catch (Exception ex)
			{
				// Log lỗi hoặc thông báo cho người dùng
				Console.WriteLine("Lỗi khi đọc dữ liệu XML: " + ex.Message);
			}

			return dt;
		}

		// Cập nhật chi tiết hóa đơn
		public void CapNhatChiTietHoaDon(string MaHoaDon, string MaLaptop, string SoLuong, decimal GiaBan)
		{
			XmlDocument doc1 = new XmlDocument();
			doc1.Load(Application.StartupPath + "\\ChiTietHoaDon.xml");

			// Sửa XPath cho đúng
			XmlNode node = doc1.SelectSingleNode("NewDataSet/_x0027_ChiTietHoaDon_x0027_[" +
				"MaHoaDon='" + MaHoaDon + "' and MaLaptop='" + MaLaptop + "']");

			if (node != null)
			{
				node["SoLuong"].InnerText = SoLuong;
				node["GiaBan"].InnerText = GiaBan.ToString("F2");
				decimal thanhTien = decimal.Parse(SoLuong) * GiaBan;
				node["ThanhTien"].InnerText = thanhTien.ToString("F2");
				doc1.Save(Application.StartupPath + "\\ChiTietHoaDon.xml");
			}
			else
			{
				throw new Exception("Không tìm thấy chi tiết hóa đơn để cập nhật.");
			}
		}
	}
}
