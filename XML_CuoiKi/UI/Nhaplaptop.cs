using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace XML_CuoiKi.UI
{
    public partial class Nhaplaptop : UserControl
    {
        Models.NhapLaptop nl = new Models.NhapLaptop();

        public Nhaplaptop()
        {
            InitializeComponent();
        }

        private void Nhaplaptop_load(object sender, EventArgs e)
        {
            string filePath = "./NhapLaptop.xml";

            if (System.IO.File.Exists(filePath))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    dataGridView1.DataSource = dataSet.Tables[0];
                    int newMaNhapHang = GenerateNewMaNhapHang(dataSet.Tables[0]);
                    tb_maNhapHang.Text = newMaNhapHang.ToString(); // Hiển thị mã tự động tăng
                    tb_maNhapHang.Enabled = false; // Ẩn không cho sửa textbox mã nhập hàng
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

        private int GenerateNewMaNhapHang(DataTable nhapLaptopTable)
        {
            if (nhapLaptopTable.Rows.Count == 0)
            {
                return 1;
            }

            var existingCodes = nhapLaptopTable.AsEnumerable()
                                                .Select(row => row.Field<int>("MaNhapHang"))
                                                .ToList();

            int maxCode = existingCodes.Max();
            return maxCode + 1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tb_maNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString();
                tb_maNhaCungCap.Text = row.Cells["MaNhaCungCap"].Value?.ToString();
                tb_search.Text = row.Cells["MaNhapHang"].Value?.ToString();
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNhanVien = tb_maNhanVien.Text;
                string MaNhaCungCap = tb_maNhaCungCap.Text;

                if (string.IsNullOrEmpty(MaNhanVien) || string.IsNullOrEmpty(MaNhaCungCap))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string MaNhapHang = tb_maNhapHang.Text;

                if (nl.MaHoaDonDaTonTai(MaNhapHang))
                {
                    MessageBox.Show("Mã đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                nl.Them(MaNhapHang, MaNhaCungCap, MaNhanVien);
                MessageBox.Show("Thêm phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Nhaplaptop_load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nhaplaptop_load(sender, e);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            XmlTextReader reader = new XmlTextReader("NhapLaptop.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaNhapHang";
            reader.Close();
            int index = dv.Find(tb_search.Text.Trim());
            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy");
                tb_search.Focus();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("MaNhapHang");
                dt.Columns.Add("MaNhaCungCap");
                dt.Columns.Add("MaNhanVien");
                dt.Columns.Add("NgayNhap");
                dt.Columns.Add("TongTienNhap");
                object[] list = { dv[index]["MaNhapHang"], dv[index]["MaNhaCungCap"], dv[index]["MaNhanVien"], dv[index]["NgayNhap"], dv[index]["TongTienNhap"] };
                dt.Rows.Add(list);
                dataGridView1.DataSource = dt;
            }
        }

        private void btn_themChiTiet_Click(object sender, EventArgs e)
        {
            string maNhapHang = tb_search.Text;

            if (string.IsNullOrEmpty(maNhapHang))
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChiTietNhap formThemChiTiet = new ChiTietNhap
            {
                MaNhapHang = maNhapHang
            };
            formThemChiTiet.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                tb_maNhapHang.Text = row.Cells["MaNhapHang"].Value?.ToString();
                tb_maNhanVien.Text = row.Cells["MaNhanVien"].Value?.ToString();
                tb_maNhaCungCap.Text = row.Cells["MaNhaCungCap"].Value?.ToString();
                tb_search.Text = row.Cells["MaNhapHang"].Value?.ToString();
            }
        }
    }
}
