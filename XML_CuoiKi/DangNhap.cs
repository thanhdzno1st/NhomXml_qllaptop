using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_CuoiKi
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text; 
            string matKhau = txtMatKhau.Text;         

       
            string connectionString = "Server=DESKTOP-7FI0AQQ;Database=XML;Integrated Security=True;";
            string query = "SELECT HoTen, PhanQuyen FROM NguoiDung WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", matKhau);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    
                    if (reader.HasRows)
                    {
                        reader.Read(); 

                        string hoTen = reader["HoTen"].ToString(); 
                        string phanQuyen = reader["PhanQuyen"].ToString(); 

                 
                        Home home = new Home(hoTen, phanQuyen);  
                        home.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }
                    else
                    {
                        // Đăng nhập thất bại
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }
    }
}
