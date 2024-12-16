using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XML_CuoiKi.Models;

namespace XML_CuoiKi.UI
{
    public partial class TrangChu : UserControl
    {
        Main M = new Main();
        HeThong HT = new HeThong();
        connect Fxml = new connect();
        public TrangChu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                M.CapNhapSQL();
                MessageBox.Show("Cập nhập SQL server thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HT.TaoXML();
                MessageBox.Show("Cập nhập XML thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
