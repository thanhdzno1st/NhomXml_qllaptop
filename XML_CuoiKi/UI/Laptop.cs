using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string laptopFilePath = "./Laptop.xml";
            string danhMucLaptopFilePath = "./DanhMucLaptop.xml"; // Đường dẫn tới file DanhMucLaptop.xml

            // Kiểm tra và load dữ liệu vào DataGridView từ Laptop.xml
            if (System.IO.File.Exists(laptopFilePath))
            {
                try
                {
                    DataSet laptopDataSet = new DataSet();
                    laptopDataSet.ReadXml(laptopFilePath);
                    dataGridView1.DataSource = laptopDataSet.Tables[0];
                    // Tạo mã laptop mới
                    int newLaptopCode = GenerateNewLaptopCode(laptopDataSet.Tables[0]);
                    tb_maLaptop.Text = newLaptopCode.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file XML Laptop: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File XML Laptop không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Kiểm tra và load dữ liệu vào ComboBox từ DanhMucLaptop.xml
            if (System.IO.File.Exists(danhMucLaptopFilePath))
            {
                try
                {
                    DataSet danhMucLaptopDataSet = new DataSet();
                    danhMucLaptopDataSet.ReadXml(danhMucLaptopFilePath);

                    // Giả sử file DanhMucLaptop.xml có một cột chứa tên danh mục laptop
                    // Giả sử bạn đã có danh sách danh mục từ một DataSet (danhMucLaptopDataSet)
                    cb_danhmuclaptop.DataSource = danhMucLaptopDataSet.Tables[0]; // Giả sử dữ liệu là bảng đầu tiên
                    cb_danhmuclaptop.DisplayMember = "TenDanhMuc"; // Tên cột bạn muốn hiển thị trên ComboBox
                    cb_danhmuclaptop.ValueMember = "MaDanhMuc"; // Tên cột bạn muốn lưu giá trị khi chọn item

                    // Thêm mục mặc định vào đầu ComboBox
                    DataRow newRow = danhMucLaptopDataSet.Tables[0].NewRow();
                    newRow["TenDanhMuc"] = "-- danh mục --"; // Đặt tên mặc định
                    newRow["MaDanhMuc"] = DBNull.Value; // Đặt giá trị mặc định (null hoặc một giá trị không hợp lệ)
                    danhMucLaptopDataSet.Tables[0].Rows.InsertAt(newRow, 0); // Thêm vào đầu bảng

                    // Cập nhật lại ComboBox để hiển thị mặc định
                    cb_danhmuclaptop.SelectedIndex = 0; // Đặt lựa chọn mặc định là "-- danh mục --"
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file XML DanhMucLaptop: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File XML DanhMucLaptop không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Hàm để tạo mã laptop mới (kiểu int)
        private int GenerateNewLaptopCode(DataTable laptopTable)
        {
            // Kiểm tra xem bảng laptop có dữ liệu không
            if (laptopTable.Rows.Count == 0)
            {
                return 1; // Nếu không có laptop nào, trả về mã đầu tiên là 1
            }

            // Lấy tất cả các mã laptop hiện có (giả sử mã là kiểu int)
            var existingCodes = laptopTable.AsEnumerable()
                                            .Select(row => row.Field<int>("MaLaptop"))
                                            .ToList();

            // Lấy mã laptop cao nhất
            int maxCode = existingCodes.Max();

            // Tạo mã laptop mới (cộng 1 vào mã cao nhất)
            return maxCode + 1;
        }
        private int GenerateNewLaptopCodeFromXML(string filePath)
        {
            // Kiểm tra xem file XML có tồn tại không
            if (File.Exists(filePath))
            {
                try
                {
                    DataSet laptopDataSet = new DataSet();
                    laptopDataSet.ReadXml(filePath);

                    if (laptopDataSet.Tables.Count > 0)
                    {
                        DataTable laptopTable = laptopDataSet.Tables[0];
                        return GenerateNewLaptopCode(laptopTable); // Sử dụng hàm GenerateNewLaptopCode để tạo mã mới
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc file XML Laptop: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return 1; // Nếu không đọc được, trả về mã đầu tiên là 1
        }
        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

                // Tìm MaDanhMuc trong ComboBox và chọn TenDanhMuc tương ứng
                string maDanhMuc = row.Cells["MaDanhMuc"].Value?.ToString();
                foreach (var item in cb_danhmuclaptop.Items)
                {
                    if (item is DataRowView dataRowView)
                    {
                        // Kiểm tra MaDanhMuc trong ComboBox
                        if (dataRowView["MaDanhMuc"].ToString() == maDanhMuc)
                        {
                            // Gán TenDanhMuc vào ComboBox
                            cb_danhmuclaptop.SelectedItem = item;
                            break;
                        }
                    }
                }

                // Tải ảnh từ URL và hiển thị trên PictureBox
                string imageUrl = tb_anh.Text;

                if (!string.IsNullOrEmpty(imageUrl))
                {
                    try
                    {
                        // Sử dụng HttpClient để tải ảnh từ URL
                        using (var client = new System.Net.Http.HttpClient())
                        {
                            var imageBytes = await client.GetByteArrayAsync(imageUrl);

                            // Kiểm tra xem dữ liệu ảnh có hợp lệ không
                            if (imageBytes != null && imageBytes.Length > 0)
                            {
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    pb_anh.Image = Image.FromStream(ms); // Tạo đối tượng Image từ byte array
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ảnh không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi khi tải ảnh, hiển thị thông báo lỗi
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nếu URL không hợp lệ hoặc không có ảnh, xóa ảnh trong PictureBox
                    pb_anh.Image = null;
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
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

            // Lấy giá trị MaDanhMuc từ ComboBox thay vì TextBox
            string MaDanhMuc = cb_danhmuclaptop.SelectedValue?.ToString(); // Lấy giá trị MaDanhMuc từ ComboBox

            if (string.IsNullOrEmpty(MaDanhMuc))
            {
                MessageBox.Show("Vui lòng chọn danh mục laptop!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo mã laptop mới tự động
            string MaLaptop = GenerateNewLaptopCodeFromXML("./Laptop.xml").ToString(); // Tạo mã laptop mới từ file XML

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
                                      // Lấy giá trị MaDanhMuc từ ComboBox thay vì TextBox
            string MaDanhMuc = cb_danhmuclaptop.SelectedValue?.ToString(); // Lấy giá trị MaDanhMuc từ ComboBox

            if (string.IsNullOrEmpty(MaDanhMuc))
            {
                MessageBox.Show("Vui lòng chọn danh mục laptop!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
