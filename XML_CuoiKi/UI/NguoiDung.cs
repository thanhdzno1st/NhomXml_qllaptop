using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using XML_CuoiKi.Models;

namespace XML_CuoiKi
{
    public partial class NguoiDung : UserControl
    {
        Models.NguoiDung nd = new Models.NguoiDung();
        public NguoiDung()
        {
            InitializeComponent();
        }

        private void NguoiDung_Load(object sender, EventArgs e)
        {
            string filePath = "./NguoiDung.xml";

            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    dataGridView1.DataSource = dataSet.Tables[0];
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Ánh xạ giá trị từ các cột của DataGridView vào TextBox tương ứng
                tb_maND.Text = row.Cells["MaNguoiDung"].Value?.ToString();
                tb_hoTen.Text = row.Cells["HoTen"].Value?.ToString();
                tb_sdt.Text = row.Cells["SoDienThoai"].Value?.ToString();
                tb_ngaySinh.Text = row.Cells["NgaySinh"].Value?.ToString();
                tb_email.Text = row.Cells["Email"].Value?.ToString();
                tb_diaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                tb_tenDangNhap.Text = row.Cells["TenDangNhap"].Value?.ToString();
                tb_matKhau.Text = row.Cells["MatKhau"].Value?.ToString();
                tb_phanQuyen.Text = row.Cells["PhanQuyen"].Value?.ToString();
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            string maND = tb_maND.Text;
            string hoTen = tb_hoTen.Text;
            string ngaySinh = tb_ngaySinh.Text;
            string email = tb_email.Text;
            string soDT = tb_sdt.Text;
            string diaChi = tb_diaChi.Text;
            string tenDN = tb_tenDangNhap.Text;
            string matKhau = tb_matKhau.Text;
            string phanQuyen = tb_phanQuyen.Text;
                nd.themND(maND, hoTen, ngaySinh, email, soDT, diaChi, tenDN, matKhau, phanQuyen);
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NguoiDung_Load(sender, e); // Cập nhật lại DataGridView
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_maND.Text) || string.IsNullOrWhiteSpace(tb_hoTen.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maND = tb_maND.Text;
            string hoTen = tb_hoTen.Text;
            string ngaySinh = tb_ngaySinh.Text;
            string email = tb_email.Text;
            string soDT = tb_sdt.Text;
            string diaChi = tb_diaChi.Text;
            string tenDN = tb_tenDangNhap.Text;
            string matKhau = tb_matKhau.Text;
            string phanQuyen = tb_phanQuyen.Text;

            try
            {
                nd.suaND(maND, hoTen, ngaySinh, email, soDT, diaChi, tenDN, matKhau, phanQuyen);
                MessageBox.Show("Sửa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NguoiDung_Load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa người dùng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            string maND = tb_maND.Text;
            try
            {
                nd.xoaND(maND);
                MessageBox.Show("Xoá người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NguoiDung_Load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá người dùng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
