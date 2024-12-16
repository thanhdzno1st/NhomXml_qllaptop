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
    public partial class Chitietkhuyenmai : UserControl
    {

        public Chitietkhuyenmai()
        {
            InitializeComponent();
            LoadDataToComboBoxes();
        }
        private void LoadDataToComboBoxes()
        {
            // Dữ liệu cho ComboBox1
            comboBox1.Items.AddRange(new string[]
            {
                "Khuyễn mãi 1",
                "Khuyễn mãi 2",
                "Khuyễn mãi 3",
                "Khuyễn mãi 4"
            });

            // Dữ liệu cho ComboBox2
            comboBox2.Items.AddRange(new string[]
            {
                "Laptop 1",
                "Laptop 2",
                "Laptop 3",
                "Laptop 4"
            });

            // Đặt giá trị mặc định (tùy chọn)
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0; // Chọn phần tử đầu tiên
            if (comboBox2.Items.Count > 0)
                comboBox2.SelectedIndex = 0; // Chọn phần tử đầu tiên
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Chitietkhuyenmai_Load(object sender, EventArgs e)
        {

        }
    }
}
