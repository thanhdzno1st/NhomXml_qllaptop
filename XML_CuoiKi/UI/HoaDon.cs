using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XML_CuoiKi
{
    public partial class HoaDon : UserControl
    {
		private int maNguoitao;
		Models.HoaDon hd = new Models.HoaDon();
        public HoaDon(int maNguoitao)
        {
            InitializeComponent();
			this.maNguoitao = maNguoitao;

		}

		private void HoaDon_load(object sender, EventArgs e)
        {
            string filePath = "./HoaDon.xml";

            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    dataGridView1.DataSource = dataSet.Tables[0];
					int newhoadonCode = GenerateNewHoadonCode(dataSet.Tables[0]);
					tb_maHoaDon.Text = newhoadonCode.ToString();
				}
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file XML: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File XML không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
		private int GenerateNewHoadonCode(DataTable laptopTable)
		{
			// Kiểm tra xem bảng laptop có dữ liệu không
			if (laptopTable.Rows.Count == 0)
			{
				return 1; // Nếu không có laptop nào, trả về mã đầu tiên là 1
			}

			// Lấy tất cả các mã laptop hiện có (giả sử mã là kiểu int)
			var existingCodes = laptopTable.AsEnumerable()
											.Select(row => row.Field<int>("MaHoaDon"))
											.ToList();

			// Lấy mã laptop cao nhất
			int maxCode = existingCodes.Max();

			// Tạo mã laptop mới (cộng 1 vào mã cao nhất)
			return maxCode + 1;
		}

		private void button3_Click(object sender, EventArgs e)
        {
            string maHoaDon = tb_search.Text;

            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThemChiTietHoaDon formThemChiTiet = new ThemChiTietHoaDon
            {
                MaHoaDon = maHoaDon
            };
            formThemChiTiet.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tb_maHoaDon.Text = row.Cells["MaHoaDon"].Value?.ToString();
                tb_tenkhachhang.Text = row.Cells["TenKhachHang"].Value?.ToString();
                tb_search.Text = row.Cells["MaHoaDon"].Value?.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHoaDon = tb_maHoaDon.Text;
                string TenKhachHang = tb_tenkhachhang.Text;
                if (string.IsNullOrEmpty(MaHoaDon) || string.IsNullOrEmpty(TenKhachHang))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (hd.MaHoaDonDaTonTai(MaHoaDon))
                {
                    MessageBox.Show("Mã hóa đơn đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                hd.ThemHoaDon(MaHoaDon, maNguoitao, TenKhachHang);
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HoaDon_load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HoaDon_load(sender, e);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("HoaDon.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaHoaDon";
            reader.Close();
            int index = dv.Find(tb_search.Text.Trim());
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                tb_search.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MaHoaDon");
                dt.Columns.Add("TenKhachHang");
                dt.Columns.Add("NgayLap");
                dt.Columns.Add("TongTien");
                object[] list = { dv[index]["MaHoaDon"], dv[index]["TenKhachHang"], dv[index]["NgayLap"], dv[index]["TongTien"] };
                dt.Rows.Add(list);
                dataGridView1.DataSource = dt;
            }
        }

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            string MaHoaDon = tb_search.Text;

            if (string.IsNullOrEmpty(MaHoaDon))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                XmlDocument hoaDonDoc = new XmlDocument();
                hoaDonDoc.Load("./HoaDon.xml");

                XmlNode hoaDonNode = hoaDonDoc.SelectSingleNode($"NewDataSet/_x0027_HoaDon_x0027_[MaHoaDon = '{MaHoaDon}']");

                if (hoaDonNode == null)
                {
                    MessageBox.Show("Không tìm thấy hóa đơn với mã: " + MaHoaDon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string TenKhachHang = hoaDonNode["TenKhachHang"]?.InnerText;
                string NgayLap = hoaDonNode["NgayLap"]?.InnerText;
                string TongTien = hoaDonNode["TongTien"]?.InnerText;

                string outputFilePath = $"XuatHoaDon.xml";
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };

                using (XmlWriter writer = XmlWriter.Create(outputFilePath, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("_x0027_HoaDon_x0027_");

                    writer.WriteElementString("MaHoaDon", MaHoaDon);
                    writer.WriteElementString("TenKhachHang", TenKhachHang);
                    writer.WriteElementString("NgayLap", NgayLap);
                    writer.WriteElementString("TongTien", TongTien);

                    XmlDocument chiTietDoc = new XmlDocument();
                    chiTietDoc.Load("./ChiTietHoaDon.xml");

                    XmlDocument laptopDoc = new XmlDocument();
                    laptopDoc.Load("./Laptop.xml");

                    XmlNodeList chiTietHoaDonNodes = chiTietDoc.SelectNodes($"NewDataSet/_x0027_ChiTietHoaDon_x0027_[MaHoaDon = '{MaHoaDon}']");

                    foreach (XmlNode chiTietNode in chiTietHoaDonNodes)
                    {
                        writer.WriteStartElement("_x0027_ChiTietHoaDon_x0027_");

                        string MaLaptop = chiTietNode["MaLaptop"]?.InnerText;

                        XmlNodeList laptopNodes = laptopDoc.SelectNodes($"NewDataSet/_x0027_Laptop_x0027_[MaLaptop = '{MaLaptop}']");
                        string TenLaptop = string.Empty;
                        if (laptopNodes.Count > 0)
                        {
                            TenLaptop = laptopNodes[0]["TenLaptop"]?.InnerText;
                        }

                        string SoLuong = chiTietNode["SoLuong"]?.InnerText;
                        string GiaBan = chiTietNode["GiaBan"]?.InnerText;

                        writer.WriteElementString("MaLaptop", MaLaptop);
                        writer.WriteElementString("TenLaptop", TenLaptop);
                        writer.WriteElementString("SoLuong", SoLuong);
                        writer.WriteElementString("GiaBan", GiaBan);

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }

                MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            inHoaDon();
        }

        private void inHoaDon()
        {
            string pathHTML = "HoaDon.html";

            XmlDocument hoaDonDoc = new XmlDocument();
            hoaDonDoc.Load("./XuatHoaDon.xml");

            XmlNode hoaDonNode = hoaDonDoc.SelectSingleNode("/_x0027_HoaDon_x0027_");

            string MaHoaDon = hoaDonNode["MaHoaDon"]?.InnerText;
            string TenKhachHang = hoaDonNode["TenKhachHang"]?.InnerText;
            string NgayLap = hoaDonNode["NgayLap"]?.InnerText;
            string TongTien = hoaDonNode["TongTien"]?.InnerText;

            var htmlContent = new StringBuilder();
            htmlContent.AppendLine("<html>");
            htmlContent.AppendLine("<head>");
            htmlContent.AppendLine("<style>");
            htmlContent.AppendLine("body { font-family: Arial, sans-serif; background-color: #f7f7f7; margin: 0; padding: 20px; }");
            htmlContent.AppendLine(".invoice { background-color: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); width: 80%; margin: 20px auto; }");
            htmlContent.AppendLine(".invoice h1 { text-align: center; color: #333; }");
            htmlContent.AppendLine(".invoice table { width: 100%; border-collapse: collapse; margin-top: 20px; }");
            htmlContent.AppendLine(".invoice th, .invoice td { padding: 12px 15px; text-align: left; border: 1px solid #ddd; }");
            htmlContent.AppendLine(".invoice th { background-color: #f2f2f2; font-weight: bold; }");
            htmlContent.AppendLine(".invoice td { background-color: #f9f9f9; }");
            htmlContent.AppendLine(".invoice td:first-child { background-color:; }");
            htmlContent.AppendLine(".invoice .total-row { background-color:; font-weight: bold; }");
            htmlContent.AppendLine(".button { display: inline-block; padding: 10px 20px; background-color: #4CAF50; color: white; border: none; cursor: pointer; border-radius: 4px; text-align: center; }");
            htmlContent.AppendLine(".button:hover { background-color: #45a049; }");
            htmlContent.AppendLine("</style>");
            htmlContent.AppendLine("</head>");
            htmlContent.AppendLine("<body>");
            htmlContent.AppendLine("<div class='invoice'>");
            htmlContent.AppendLine("<h1>Hóa Đơn</h1>");

            htmlContent.AppendLine("<table>");
            htmlContent.AppendLine("<tr><td><strong>Mã Hóa Đơn:</strong></td><td>" + MaHoaDon + "</td></tr>");
            htmlContent.AppendLine("<tr><td><strong>Tên khách hàng:</strong></td><td>" + TenKhachHang + "</td></tr>");
            htmlContent.AppendLine("<tr><td><strong>Ngày Lập:</strong></td><td>" + NgayLap + "</td></tr>");
            htmlContent.AppendLine("<tr><td><strong>Tổng Tiền:</strong></td><td>" + TongTien + "</td></tr>");
            htmlContent.AppendLine("</table>");

            XmlNodeList chiTietHoaDonNodes = hoaDonNode.SelectNodes("_x0027_ChiTietHoaDon_x0027_");

            htmlContent.AppendLine("<h3>Chi Tiết Sản Phẩm</h3>");
            htmlContent.AppendLine("<table>");
            htmlContent.AppendLine("<tr><th>Mã Laptop</th><th>Tên Laptop</th><th>Số Lượng</th><th>Giá Bán</th></tr>");

            foreach (XmlNode chiTietNode in chiTietHoaDonNodes)
            {
                string MaLaptop = chiTietNode["MaLaptop"]?.InnerText;
                string TenLaptop = chiTietNode["TenLaptop"]?.InnerText;
                string SoLuong = chiTietNode["SoLuong"]?.InnerText;
                string GiaBan = chiTietNode["GiaBan"]?.InnerText;

                htmlContent.AppendLine("<tr>");
                htmlContent.AppendLine("<td>" + MaLaptop + "</td>");
                htmlContent.AppendLine("<td>" + TenLaptop + "</td>");
                htmlContent.AppendLine("<td>" + SoLuong + "</td>");
                htmlContent.AppendLine("<td style='text-align:right'>" + GiaBan + "</td>");
                htmlContent.AppendLine("</tr>");
            }

            htmlContent.AppendLine("</table>");
            htmlContent.AppendLine("<br><br>");
            htmlContent.AppendLine("</div>");
            htmlContent.AppendLine("</body>");
            htmlContent.AppendLine("</html>");

            File.WriteAllText(pathHTML, htmlContent.ToString());

            Process.Start(new ProcessStartInfo
            {
                FileName = pathHTML,
                UseShellExecute = true
            });
        }

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
