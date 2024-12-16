using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace XML_CuoiKi.Models
{
    class DangNhap
    {
        connect FileXML = new connect();
        public bool kiemtraTTDN(string duongdan, string TenDangNhap, string MatKhau)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = FileXML.HienThi(duongdan);
                dt.DefaultView.RowFilter = "TenDangNhap ='" + TenDangNhap + "' AND MatKhau ='" + MatKhau + "'";
                if (dt.DefaultView.Count > 0)
                    return true;
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    }
}
