using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace XML_CuoiKi
{
    public partial class Danhmuclaptop : UserControl
    {
        Models.DanhMuc dm = new Models.DanhMuc();
        public Danhmuclaptop()
        {
            InitializeComponent();
        }
        private void Danhmuclaptop_Load(object sender, EventArgs e)
        {
            string filePath = "./DanhMucLaptop.xml";

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
                tb_idDanhMuc.Text = row.Cells["MaDanhMuc"].Value?.ToString();
                tb_tenDanhMuc.Text = row.Cells["TenDanhMuc"].Value?.ToString();
                tb_moTa.Text = row.Cells["MoTa"].Value?.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string MaDanhMuc = tb_idDanhMuc.Text;
            string TenDanhMuc = tb_tenDanhMuc.Text;
            string MoTa = tb_moTa.Text;
            dm.themDM(MaDanhMuc, TenDanhMuc, MoTa);
            MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Danhmuclaptop_Load(sender, e); // Cập nhật lại DataGridView
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_idDanhMuc.Text) || string.IsNullOrWhiteSpace(tb_tenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string MaDanhMuc = tb_idDanhMuc.Text;
            string TenDanhMuc = tb_tenDanhMuc.Text;
            string MoTa = tb_moTa.Text;

            try
            {
                dm.suaDM(MaDanhMuc, TenDanhMuc, MoTa);
                MessageBox.Show("Sửa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Danhmuclaptop_Load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa danh mục: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string MaDanhMuc = tb_idDanhMuc.Text;
            try
            {
                dm.xoaDM(MaDanhMuc);
                MessageBox.Show("Xoá danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Danhmuclaptop_Load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá danh mục: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
