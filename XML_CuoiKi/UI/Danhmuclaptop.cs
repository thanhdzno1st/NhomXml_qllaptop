using System;
using System.Data;
using System.IO;
using System.Linq;
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
                    // Tạo mã laptop mới
                    int newDanhmucLaptopCode = GenerateNewDanhmucLaptopCode(dataSet.Tables[0]);
                    tb_idDanhMuc.Text = newDanhmucLaptopCode.ToString();
                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("File XML không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int GenerateNewDanhmucLaptopCode(DataTable laptopTable)
        {
            // Kiểm tra xem bảng laptop có dữ liệu không
            if (laptopTable.Rows.Count == 0)
            {
                return 1; // Nếu không có laptop nào, trả về mã đầu tiên là 1
            }

            // Lấy tất cả các mã laptop hiện có (giả sử mã là kiểu int)
            var existingCodes = laptopTable.AsEnumerable()
                                            .Select(row => row.Field<int>("MaDanhMuc"))
                                            .ToList();

            // Lấy mã laptop cao nhất
            int maxCode = existingCodes.Max();

            // Tạo mã laptop mới (cộng 1 vào mã cao nhất)
            return maxCode + 1;
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
            if (string.IsNullOrWhiteSpace(tb_tenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = "./DanhMucLaptop.xml";
            DataSet dataSet = new DataSet();

            // Đọc dữ liệu từ file XML
            if (File.Exists(filePath))
            {
                dataSet.ReadXml(filePath);
            }
            else
            {
                // Nếu file không tồn tại, tạo bảng mới
                DataTable dt = new DataTable("DanhMucLaptop");
                dt.Columns.Add("MaDanhMuc", typeof(int));
                dt.Columns.Add("TenDanhMuc", typeof(string));
                dt.Columns.Add("MoTa", typeof(string));
                dataSet.Tables.Add(dt);
            }

            DataTable laptopTable = dataSet.Tables[0];

            // Tự động tạo mã danh mục mới
            int newDanhmucLaptopCode = GenerateNewDanhmucLaptopCode(laptopTable);

            // Thêm danh mục mới vào DataTable
            DataRow newRow = laptopTable.NewRow();
            newRow["MaDanhMuc"] = newDanhmucLaptopCode;
            newRow["TenDanhMuc"] = tb_tenDanhMuc.Text;
            newRow["MoTa"] = tb_moTa.Text;
            laptopTable.Rows.Add(newRow);

            try
            {
                // Ghi dữ liệu vào file XML
                dataSet.WriteXml(filePath);
                MessageBox.Show("Thêm danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Danhmuclaptop_Load(sender, e); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm danh mục: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void tb_moTa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
