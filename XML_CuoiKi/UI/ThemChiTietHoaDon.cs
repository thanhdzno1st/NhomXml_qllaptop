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
        Models.ChiTietHoaDon ct = new Models.ChiTietHoaDon();

        public ThemChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void ThemChiTietHoaDon_load(object sender, EventArgs e)
        {
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
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string MaLaptop = tb_maLaptop.Text;
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

                tb_maLaptop.Text = row.Cells["MaLaptop"].Value?.ToString();
                tb_soLuong.Text = row.Cells["SoLuong"].Value?.ToString();
            }
        }
    }
}
