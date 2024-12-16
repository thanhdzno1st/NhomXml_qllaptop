using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_CuoiKi
{
    public partial class Nhacungcap : UserControl
    {
        Models.NhaCungCap ncc = new Models.NhaCungCap();
        public Nhacungcap()
        {
            InitializeComponent();
        }
        private void Nhacungcap_load(object sender, EventArgs e)
        {
            string filePath = "./NhaCungCap.xml";

            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    dataGridView1.DataSource = dataSet.Tables[0];
                    int newNhacungcapCode = GenerateNewnhacungcapCode(dataSet.Tables[0]);
                    tb_maNhaCungCap.Text = newNhacungcapCode.ToString();
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
        private int GenerateNewnhacungcapCode(DataTable laptopTable)
        {
            // Kiểm tra xem bảng laptop có dữ liệu không
            if (laptopTable.Rows.Count == 0)
            {
                return 1; // Nếu không có laptop nào, trả về mã đầu tiên là 1
            }

            // Lấy tất cả các mã laptop hiện có (giả sử mã là kiểu int)
            var existingCodes = laptopTable.AsEnumerable()
                                            .Select(row => row.Field<int>("MaNhaCungCap"))
                                            .ToList();

            // Lấy mã laptop cao nhất
            int maxCode = existingCodes.Max();

            // Tạo mã laptop mới (cộng 1 vào mã cao nhất)
            return maxCode + 1;
        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Ánh xạ giá trị từ các cột của DataGridView vào TextBox tương ứng
                tb_maNhaCungCap.Text = row.Cells["MaNhaCungCap"].Value?.ToString();
                tb_tenNhaCungCap.Text = row.Cells["TenNhaCungCap"].Value?.ToString();
                tb_soDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                tb_email.Text = row.Cells["Email"].Value?.ToString();
                tb_diaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                tb_anh.Text = row.Cells["Anh"].Value?.ToString();
                // Tải ảnh từ URL và hiển thị trên PictureBox
                string imageUrl = tb_anh.Text;

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        // Sử dụng HttpClient để tải ảnh từ URL
                        using (var client = new System.Net.Http.HttpClient())
                        {
                            var imageBytes = await client.GetByteArrayAsync(imageUrl);

                            // Kiểm tra xem dữ liệu ảnh có hợp lệ không
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    pb_anh.Image = Image.FromStream(ms); // Tạo đối tượng Image từ byte array
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ảnh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi khi tải ảnh, hiển thị thông báo lỗi
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nếu URL không hợp lệ hoặc không có ảnh, xóa ảnh trong PictureBox
                    pb_anh.Image = null;
                }
            }
        }

            private void btn_them_Click_1(object sender, EventArgs e)
        {
            string MaNhaCungCap = tb_maNhaCungCap.Text;
            string TenNhaCungCap = tb_tenNhaCungCap.Text;
            string SoDienThoai = tb_soDienThoai.Text;
            string Email = tb_email.Text;
            string DiaChi = tb_diaChi.Text;
            string Anh = tb_anh.Text;
            ncc.them(MaNhaCungCap, TenNhaCungCap, SoDienThoai, Email, DiaChi, Anh);
            MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Nhacungcap_load(sender, e); // Cập nhật lại DataGridView
        }

        private void btn_sua_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_maNhaCungCap.Text) || string.IsNullOrWhiteSpace(tb_tenNhaCungCap.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string MaNhaCungCap = tb_maNhaCungCap.Text;
            string TenNhaCungCap = tb_tenNhaCungCap.Text;
            string SoDienThoai = tb_soDienThoai.Text;
            string Email = tb_email.Text;
            string DiaChi = tb_diaChi.Text;
            string Anh = tb_anh.Text;

            try
            {
                ncc.sua(MaNhaCungCap, TenNhaCungCap, SoDienThoai, Email, DiaChi, Anh);
                MessageBox.Show("Sửa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nhacungcap_load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa danh mục: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click_1(object sender, EventArgs e)
        {
            string MaNhaCungCap = tb_maNhaCungCap.Text;
            try
            {
                ncc.xoa(MaNhaCungCap);
                MessageBox.Show("Xoá nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nhacungcap_load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá nhà cung cấp: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
