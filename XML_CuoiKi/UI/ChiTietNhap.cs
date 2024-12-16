using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                DataTable dt = nl.HienThiChiTiet(MaNhapHang);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có chi tiết nào cho mã nhập này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải chi tiết: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string MaLaptop = tb_maLaptop.Text;
            string GiaNhap = tb_giaNhap.Text;
            string SoLuong = tb_soLuong.Text;
            nl.ThemChiTiet(MaNhapHang, MaLaptop, SoLuong, GiaNhap);
            MessageBox.Show("Thêm Laptop thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ChiTietNhap_load(sender, e);
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
