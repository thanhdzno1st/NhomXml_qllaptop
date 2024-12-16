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
    }
}
