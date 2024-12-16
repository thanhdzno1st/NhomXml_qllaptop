using System;
using System.Data;
using System.Windows.Forms;
using XML_CuoiKi.Models; 

namespace XML_CuoiKi
{
    public partial class ThemChiTietHoaDon : Form
    {
        public string MaHoaDon { get; set; }
        Models.HoaDon hd = new Models.HoaDon();
        ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
        public ThemChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ThemChiTietHoaDon_load(object sender, EventArgs e)
        {
			string laptopFilePath = "./Laptop.xml";
			lb_maHoaDon.Text = MaHoaDon;

            try
            {
                DataTable dt = chiTietHoaDon.HienThiChiTietHoaDon(MaHoaDon);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có chi tiết hóa đơn nào cho mã hóa đơn này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			// Kiểm tra và load dữ liệu vào ComboBox từ DanhMucLaptop.xml
			if (System.IO.File.Exists(laptopFilePath))
			{
				try
				{
					DataSet LaptopDataSet = new DataSet();
					LaptopDataSet.ReadXml(laptopFilePath);

					cb_laptop.DataSource = LaptopDataSet.Tables[0]; // Giả sử dữ liệu là bảng đầu tiên
					cb_laptop.DisplayMember = "TenLaptop"; // Tên cột bạn muốn hiển thị trên ComboBox
					cb_laptop.ValueMember = "MaDanhMuc"; // Tên cột bạn muốn lưu giá trị khi chọn item

					// Thêm mục mặc định vào đầu ComboBox
					DataRow newRow = LaptopDataSet.Tables[0].NewRow();
					newRow["TenLaptop"] = "-- danh mục --"; // Đặt tên mặc định
					newRow["MaDanhMuc"] = DBNull.Value; // Đặt giá trị mặc định (null hoặc một giá trị không hợp lệ)
					LaptopDataSet.Tables[0].Rows.InsertAt(newRow, 0); // Thêm vào đầu bảng

					// Cập nhật lại ComboBox để hiển thị mặc định
					cb_laptop.SelectedIndex = 0; // Đặt lựa chọn mặc định là "-- danh mục --"
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi đọc file XML Laptop: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("File XML Laptop không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

        private void btn_them_Click(object sender, EventArgs e)
        {
			string MaLaptop = cb_laptop.SelectedValue?.ToString(); // Lấy giá trị MaDanhMuc từ ComboBox

			if (string.IsNullOrEmpty(MaLaptop))
			{
				MessageBox.Show("Vui lòng chọn laptop!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			string SoLuong = tb_soLuong.Text;    
            hd.ThemChiTietHoaDon(MaHoaDon, MaLaptop, SoLuong);
            MessageBox.Show("Thêm Laptop thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThemChiTietHoaDon_load(sender, e); 

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

				string maLaptop = row.Cells["MaLaptop"].Value?.ToString();
				foreach (var item in cb_laptop.Items)
				{
					if (item is DataRowView dataRowView)
					{
						// Kiểm tra MaDanhMuc trong ComboBox
						if (dataRowView["MaLaptop"].ToString() == maLaptop)
						{
							// Gán TenDanhMuc vào ComboBox
							cb_laptop.SelectedItem = item;
							break;
						}
					}
				}
				tb_soLuong.Text = row.Cells["SoLuong"].Value?.ToString();
            }
        }
    }
}
