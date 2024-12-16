using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML_CuoiKi.Models
{
    class DanhMuc
    {
        connect Fxml = new connect();
        public bool kiemtra(string MaDanhMuc)
        {
            XmlTextReader reader = new XmlTextReader("DanhMucLaptop.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaDanhMuc";
            reader.Close();
            int index = dv.Find(MaDanhMuc);
            if (index == -1)
            {
                return false;
            }
            return true;
        }

        public void themDM(string MaDanhMuc, string TenDanhMuc, string MoTa)
        {
            string noiDung = "<_x0027_DanhMucLaptop_x0027_>" +
                            "<MaDanhMuc>" + MaDanhMuc + "</MaDanhMuc>" +
                            "<TenDanhMuc>" + TenDanhMuc + "</TenDanhMuc>" +
                            "<MoTa>" + MoTa + "</MoTa>" +
                            "</_x0027_DanhMucLaptop_x0027_>";
            Fxml.Them("DanhMucLaptop.xml", noiDung);
        }

        public void suaDM(string MaDanhMuc, string TenDanhMuc, string MoTa)
        {
            string noiDung =

                            "<MaDanhMuc>" + MaDanhMuc + "</MaDanhMuc>" +
                            "<TenDanhMuc>" + TenDanhMuc + "</TenDanhMuc>" +
                            "<MoTa>" + MoTa + "</MoTa>";
            Fxml.Sua("DanhMucLaptop.xml", "_x0027_DanhMucLaptop_x0027_", "MaDanhMuc", MaDanhMuc, noiDung);
        }



        public void xoaDM(string MaDanhMuc)
        {
            Fxml.Xoa("DanhMucLaptop.xml", "_x0027_DanhMucLaptop_x0027_", "MaDanhMuc", MaDanhMuc);
        }
        public bool checkEmpty(string MaDanhMuc, string TenDanhMuc, string MoTa)
        {
            if (string.IsNullOrEmpty(MaDanhMuc) || string.IsNullOrEmpty(TenDanhMuc) ||
                string.IsNullOrEmpty(MoTa))
            {
                return false;
            }
            return true;
        }
    }
}
