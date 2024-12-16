using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_CuoiKi.Models;
using XML_CuoiKi.UI;

namespace XML_CuoiKi
{
    public partial class Home : Form
    {
		connect connect = new connect();
        public string HoTen { get; set; }
        public int MaNguoiDung { get; set; }
        public string Quyen { get; set; }
        public Home()
        {
            InitializeComponent();
        }
        private void ShowControl(UserControl control)
        {
            // Xóa nội dung cũ
            Panel_navigation.Controls.Clear();

            // Thêm UserControl mới vào Panel
            control.Dock = DockStyle.Fill;
            Panel_navigation.Controls.Add(control);
        }

        private void btn_hoadon_Click(object sender, EventArgs e)
        {
            ShowControl(new HoaDon(MaNguoiDung));
        }

        private void btn_nguoidung_Click(object sender, EventArgs e)
        {
            ShowControl(new NguoiDung());

        }

  


        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); // Thoát toàn bộ chương trình
        }



        private void btn_laptop_Click(object sender, EventArgs e)
        {
            ShowControl(new Laptop());
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ShowControl(new TrangChu());
			tb_hoTen.Text = HoTen;
			tb_quyen.Text = Quyen;
			// Kiểm tra quyền và ẩn nút btn_nguoidung nếu quyền là "nhân viên"
			if (Quyen.Equals("Nhân viên", StringComparison.OrdinalIgnoreCase))
			{
				btn_nguoidung.Visible = false; // Ẩn nút
			}
			else
			{
				btn_nguoidung.Visible = true; // Hiển thị nút (nếu không phải nhân viên)
			}

		}

        private void btn_Danhmuc_Click(object sender, EventArgs e)
        {
            ShowControl(new Danhmuclaptop());

        }

        private void btn_nhacungcap_Click(object sender, EventArgs e)
        {
            ShowControl(new Nhacungcap());

        }



        private void button1_Click(object sender, EventArgs e)
        {
            ShowControl(new TrangChu());
        }



        private void button9_Click(object sender, EventArgs e)
        {
			XML_CuoiKi.UI.DangNhap dn = new XML_CuoiKi.UI.DangNhap();
			dn.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ShowControl(new Nhaplaptop());
        }

		private void tb_hoTen_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Panel_navigation_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
