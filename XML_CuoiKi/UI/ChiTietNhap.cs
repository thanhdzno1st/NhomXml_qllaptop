using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace XML_CuoiKi.UI
{
    public partial class ChiTietNhap : Form
    {
        Models.NhapLaptop nl = new Models.NhapLaptop();
        public string MaNhapHang { get; set; }

        public ChiTietNhap()
        {
            InitializeComponent();
        }

        private void ChiTietNhap_load(object sender, EventArgs e)
        {
            label1.Text = MaNhapHang;

            try
            {
                string filePath = "./ChiTietNhap.xml"; // Tệp XML lưu thông tin chi tiết nhập
                if (System.IO.File.Exists(filePath))
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    dataGridView1.DataSource = dataSet.Tables[0];

                    // Tính toán mã chi tiết nhập tiếp theo
                    int newMaChiTietNhap = GenerateNewMaChiTietNhap(dataSet.Tables[0]);
                    tb_maChiTietNhap.Text = newMaChiTietNhap.ToString();
                    tb_maChiTietNhap.Enabled = false; // Ẩn không cho sửa textbox mã nhập hàng
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu chi tiết nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đọc file XML: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GenerateNewMaChiTietNhap(DataTable chiTietNhapTable)
        {
            // Kiểm tra xem bảng có dữ liệu không
            if (chiTietNhapTable.Rows.Count == 0)
            {
                return 1; // Nếu không có chi tiết nào, trả về mã đầu tiên là 1
            }

            // Lấy tất cả các mã chi tiết nhập hiện có (giả sử mã là kiểu int)
            var existingCodes = chiTietNhapTable.AsEnumerable()
                                                .Select(row => row.Field<int>("MaChiTietNhap"))
                                                .ToList();

            // Lấy mã chi tiết nhập cao nhất
            int maxCode = existingCodes.Max();

            // Tạo mã chi tiết nhập mới (cộng 1 vào mã cao nhất)
            return maxCode + 1;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                string MaLaptop = tb_maLaptop.Text;
                string GiaNhap = tb_giaNhap.Text;
                string SoLuong = tb_soLuong.Text;

                string MaChiTietNhap = tb_maChiTietNhap.Text; // Lấy giá trị MaChiTietNhap tự động

                if (string.IsNullOrEmpty(MaLaptop) || string.IsNullOrEmpty(GiaNhap) || string.IsNullOrEmpty(SoLuong))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm chi tiết nhập với MaChiTietNhap tự động
                nl.ThemChiTiet(MaChiTietNhap, MaNhapHang, MaLaptop, SoLuong, GiaNhap);

                MessageBox.Show("Thêm Laptop thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChiTietNhap_load(sender, e); // Load lại dữ liệu chi tiết nhập
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tb_maLaptop.Text = row.Cells["MaLaptop"].Value?.ToString();
                tb_giaNhap.Text = row.Cells["GiaNhap"].Value?.ToString();
                tb_soLuong.Text = row.Cells["SoLuongNhap"].Value?.ToString();
            }
        }
    }
}
