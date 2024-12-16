using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                tb_maNhaCungCap.Text = row.Cells["MaNhaCungCap"].Value?.ToString();
                tb_tenNhaCungCap.Text = row.Cells["TenNhaCungCap"].Value?.ToString();
                tb_soDienThoai.Text = row.Cells["SoDienThoai"].Value?.ToString();
                tb_email.Text = row.Cells["Email"].Value?.ToString();
                tb_diaChi.Text = row.Cells["DiaChi"].Value?.ToString();
                tb_anh.Text = row.Cells["Anh"].Value?.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
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

        private void btn_sua_Click(object sender, EventArgs e)
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

        private void btn_xoa_Click(object sender, EventArgs e)
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
