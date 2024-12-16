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
    public partial class Chitietnhap : UserControl
    {
        public Chitietnhap()
        {
            InitializeComponent();
            LoadDataToComboBoxes();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void LoadDataToComboBoxes()
        {
            // Dữ liệu cho ComboBox2
            comboBox1.Items.AddRange(new string[]
            {
                "Laptop 1",
                "Laptop 2",
                "Laptop 3",
                "Laptop 4"
            });
            // Dữ liệu cho ComboBox1
            comboBox2.Items.AddRange(new string[]
            {
                "Nhập hàng 1",
                "Nhập hàng 2",
                "Nhập hàng 3",
                "Nhập hàng 4"
            });

           

            // Đặt giá trị mặc định (tùy chọn)
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0; // Chọn phần tử đầu tiên
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0; // Chọn phần tử đầu tiên
        }

    }
}
