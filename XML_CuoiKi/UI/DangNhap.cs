﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XML_CuoiKi.UI
{
    public partial class DangNhap : Form
    {
        public XDocument doc;
        public string path = "./NguoiDung.xml";
        Models.DangNhap dn = new Models.DangNhap();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các textbox
            string TaiKhoan = tb_tenDangNhap.Text;
            string MatKhau = tb_matKhau.Text;

            // Kiểm tra thông tin đăng nhập
            if (string.IsNullOrWhiteSpace(TaiKhoan) || string.IsNullOrWhiteSpace(MatKhau))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra tài khoản và mật khẩu
            if (dn.kiemtraTTDN(path, TaiKhoan, MatKhau))
            {
                // Đọc file XML để kiểm tra quyền
                DataSet ds = new DataSet();
                ds.ReadXml(path);
                DataTable dt = ds.Tables[0];

                // Lọc thông tin người dùng dựa trên tài khoản và mật khẩu
                DataRow[] rows = dt.Select($"TenDangNhap = '{TaiKhoan}' AND MatKhau = '{MatKhau}'");

                if (rows.Length > 0)
                {
                    string quyen = rows[0]["PhanQuyen"].ToString();
                    string hoTen = rows[0]["HoTen"].ToString();
                    int MaNguoiDung = Convert.ToInt32(rows[0]["MaNguoiDung"]);

					if (quyen == "nhan_vien")
					{
						MessageBox.Show("Đăng nhập thành công với quyền nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Chuyển đến giao diện quản lý
                        Home home = new Home();
                        home.Quyen = "Nhân viên";
                        home.HoTen = hoTen;
                        home.MaNguoiDung = MaNguoiDung;
                        home.Show();
                        this.Hide();
                    }
                    else
                    if(quyen == "admin")
                    {
						MessageBox.Show("Đăng nhập thành công với quyền admin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
						// Chuyển đến giao diện quản lý
						Home home = new Home();
						home.Quyen = "Admin";
                        home.HoTen = hoTen;
                        home.MaNguoiDung = MaNguoiDung;
						home.Show();
						this.Hide();
					}
					else 
                    {
                        MessageBox.Show("Bạn không có quyền truy cập vào hệ thống quản lý!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void DangNhap_Load(object sender, EventArgs e)
		{

		}
	}
}
