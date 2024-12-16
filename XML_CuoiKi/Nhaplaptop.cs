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
    public partial class Nhaplaptop : UserControl
    {
        public Nhaplaptop()
        {
            InitializeComponent();
            LoadDataToComboBoxes();
        }

        private void LoadDataToComboBoxes()
        {
            // Dữ liệu cho ComboBox1
            comboBox1.Items.AddRange(new string[]
            {
                "Nhân viên 1",
                "Nhân viên 2",
                "Nhân viên 3",
                "Nhân viên 4"
            });

            // Dữ liệu cho ComboBox2
            comboBox2.Items.AddRange(new string[]
            {
                "Nhà cung cấp 1",
                "Nhà cung cấp 2",
                "Nhà cung cấp 3",
                "Nhà cung cấp 4"
            });

            // Đặt giá trị mặc định (tùy chọn)
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0; // Chọn phần tử đầu tiên
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0; // Chọn phần tử đầu tiên
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Nhaplaptop_Load(object sender, EventArgs e)
        {

        }
    }
}
