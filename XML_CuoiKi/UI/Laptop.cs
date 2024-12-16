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
    public partial class Laptop : UserControl
    {
        Models.Laptop lt = new Models.Laptop();
        public Laptop()
        {
            InitializeComponent();
        }

        private void Laptop_load(object sender, EventArgs e)
        {
            string filePath = "./Laptop.xml";
            img_anh.ImageLocation = "path/to/image.jpg";

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
                tb_maLaptop.Text = row.Cells["MaLaptop"].Value?.ToString();
                tb_tenLaptop.Text = row.Cells["TenLaptop"].Value?.ToString();
                tb_hangSanXuat.Text = row.Cells["HangSanXuat"].Value?.ToString();
                tb_loaiCarDoHoa.Text = row.Cells["LoaiCardDoHoa"].Value?.ToString();
                tb_loaiCPU.Text = row.Cells["LoaiCPU"].Value?.ToString();
                tb_dungLuongRAM.Text = row.Cells["DungLuongRAM"].Value?.ToString();
                tb_loaiRAM.Text = row.Cells["LoaiRAM"].Value?.ToString();
                tb_loaiOCung.Text = row.Cells["LoaiOCung"].Value?.ToString();
                tb_kichThuocManHinh.Text = row.Cells["KichThuocManHinh"].Value?.ToString();
                tb_doPhanGiaiManHinh.Text = row.Cells["DoPhanGiaiManHinh"].Value?.ToString();
                tb_congNgheAmThanh.Text = row.Cells["CongNgheAmThanh"].Value?.ToString();
                tb_congGiaoTiep.Text = row.Cells["CongGiaoTiep"].Value?.ToString();
                tb_wifi.Text = row.Cells["Wifi"].Value?.ToString();
                tb_bluetooth.Text = row.Cells["Bluetooth"].Value?.ToString();
                tb_kichThuoc.Text = row.Cells["KichThuoc"].Value?.ToString();
                tb_trongLuong.Text = row.Cells["TrongLuong"].Value?.ToString();
                tb_tinhNangDacBiet.Text = row.Cells["TinhNangDacBiet"].Value?.ToString();
                tb_baoMatKhac.Text = row.Cells["BaoMatKhac"].Value?.ToString();
                tb_heDieuHanh.Text = row.Cells["HeDieuHanh"].Value?.ToString();
                tb_pin.Text = row.Cells["Pin"].Value?.ToString();
                tb_giaBan.Text = row.Cells["GiaBan"].Value?.ToString();
                tb_soLuongTon.Text = row.Cells["SoLuongTon"].Value?.ToString();
                tb_anh.Text = row.Cells["Anh"].Value?.ToString();
                tb_maDanhMuc.Text = row.Cells["MaDanhMuc"].Value?.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string MaLaptop = tb_maLaptop.Text;
            string TenLaptop = tb_tenLaptop.Text;
            string HangSanXuat = tb_hangSanXuat.Text;
            string LoaiCardDoHoa = tb_loaiCarDoHoa.Text;
            string LoaiCPU = tb_loaiCPU.Text;
            string DungLuongRAM = tb_dungLuongRAM.Text;
            string LoaiRAM = tb_loaiRAM.Text;
            string LoaiOCung = tb_loaiOCung.Text;
            string KichThuocManHinh = tb_kichThuocManHinh.Text;
            string DoPhanGiaiManHinh = tb_doPhanGiaiManHinh.Text;
            string CongNgheAmThanh = tb_congNgheAmThanh.Text;
            string CongGiaoTiep = tb_congGiaoTiep.Text;
            string Wifi = tb_wifi.Text;
            string Bluetooth = tb_bluetooth.Text;
            string KichThuoc = tb_kichThuoc.Text;
            string TrongLuong = tb_trongLuong.Text;
            string TinhNangDacBiet = tb_tinhNangDacBiet.Text;
            string BaoMatKhac = tb_baoMatKhac.Text;
            string HeDieuHanh = tb_heDieuHanh.Text;
            string Pin = tb_pin.Text;
            decimal GiaBan = Convert.ToDecimal(tb_giaBan.Text);
            int SoLuongTon = Convert.ToInt32(tb_soLuongTon.Text);
            string Anh = tb_anh.Text;
            string MaDanhMuc = tb_maDanhMuc.Text;
            
            // Gọi hàm them để thêm dữ liệu vào XML
            lt.them(MaLaptop, TenLaptop, HangSanXuat, LoaiCardDoHoa, LoaiCPU, DungLuongRAM,
                     LoaiRAM, LoaiOCung, KichThuocManHinh, DoPhanGiaiManHinh, CongNgheAmThanh,
                     CongGiaoTiep, Wifi, Bluetooth, KichThuoc, TrongLuong, TinhNangDacBiet,
                     BaoMatKhac, HeDieuHanh, Pin, GiaBan, SoLuongTon, Anh, MaDanhMuc);

            // Hiển thị thông báo thành công
            MessageBox.Show("Thêm laptop thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật lại DataGridView
            Laptop_load(sender, e);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các TextBox có thông tin đầy đủ không
            if (string.IsNullOrWhiteSpace(tb_maLaptop.Text) || string.IsNullOrWhiteSpace(tb_tenLaptop.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ các TextBox
            string MaLaptop = tb_maLaptop.Text;
            string TenLaptop = tb_tenLaptop.Text;
            string HangSanXuat = tb_hangSanXuat.Text;
            string LoaiCardDoHoa = tb_loaiCarDoHoa.Text;
            string LoaiCPU = tb_loaiCPU.Text;
            string DungLuongRAM = tb_dungLuongRAM.Text;
            string LoaiRAM = tb_loaiRAM.Text;
            string LoaiOCung = tb_loaiOCung.Text;
            string KichThuocManHinh = tb_kichThuocManHinh.Text;
            string DoPhanGiaiManHinh = tb_doPhanGiaiManHinh.Text;
            string CongNgheAmThanh = tb_congNgheAmThanh.Text;
            string CongGiaoTiep = tb_congGiaoTiep.Text;
            string Wifi = tb_wifi.Text;
            string Bluetooth = tb_bluetooth.Text;
            string KichThuoc = tb_kichThuoc.Text;
            string TrongLuong = tb_trongLuong.Text;
            string TinhNangDacBiet = tb_tinhNangDacBiet.Text;
            string BaoMatKhac = tb_baoMatKhac.Text;
            string HeDieuHanh = tb_heDieuHanh.Text;
            string Pin = tb_pin.Text;
            decimal GiaBan = decimal.Parse(tb_giaBan.Text); // Cần kiểm tra kiểu dữ liệu
            int SoLuongTon = int.Parse(tb_soLuongTon.Text); // Cần kiểm tra kiểu dữ liệu
            string Anh = tb_anh.Text; // Đảm bảo có đường dẫn ảnh hợp lệ
            string MaDanhMuc = tb_maDanhMuc.Text;

            try
            {
                // Gọi hàm sửa dữ liệu từ lớp xử lý
                lt.sua(MaLaptop, TenLaptop, HangSanXuat, LoaiCardDoHoa, LoaiCPU, DungLuongRAM, LoaiRAM, LoaiOCung,
                       KichThuocManHinh, DoPhanGiaiManHinh, CongNgheAmThanh, CongGiaoTiep, Wifi, Bluetooth, KichThuoc,
                       TrongLuong, TinhNangDacBiet, BaoMatKhac, HeDieuHanh, Pin, GiaBan, SoLuongTon, Anh, MaDanhMuc);

                MessageBox.Show("Sửa thông tin laptop thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Laptop_load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa thông tin laptop: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string MaLaptop = tb_maLaptop.Text;
            try
            {
                lt.xoa(MaLaptop);
                MessageBox.Show("Xoá Laptop công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Laptop_load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá Laptop: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
