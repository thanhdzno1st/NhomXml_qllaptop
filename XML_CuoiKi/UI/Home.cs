using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_CuoiKi.UI;

namespace XML_CuoiKi
{
    public partial class Home : Form
    {
        public string HoTen { get; set; }
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
            ShowControl(new HoaDon());
        }

        private void btn_nguoidung_Click(object sender, EventArgs e)
        {
            if(Quyen == "Admin") { 
                ShowControl(new NguoiDung());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vào đây", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            DangNhap dn = new DangNhap();
            dn.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ShowControl(new Nhaplaptop());
        }
    }
}
