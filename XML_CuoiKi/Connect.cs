using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Diagnostics;


namespace XML_CuoiKi
{
    class Connect
    {        
        string Conn = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=dbQlycuahanglaptop;Integrated Security=True";
        //string Conn = @"Data Source=TRANKHANH\SQLEXPRESS; Initial Catalog = myShop5; Integrated Security=true";
        public DataTable HienThi(string file)
        {
            DataTable dt = new DataTable();
            string FilePath = Application.StartupPath + "\\" + file;
            if (File.Exists(FilePath))
            {
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            }
            return dt;
        }
        public void TaoXML(string bang)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            string sql = "Select* from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("'" + bang + "'");
            ad.Fill(dt);
            dt.WriteXml(Application.StartupPath + "\\" + bang + ".xml", XmlWriteMode.WriteSchema);
        }

        public string LayGiaTri(string duongDan, string truongA, string giaTriA, string truongB)
        {
            string giatriB = "";
            DataTable dt = new DataTable();
            dt = HienThi(duongDan);
            int soDongNhanVien = dt.Rows.Count;
            for (int i = 0; i < soDongNhanVien; i++)
            {
                if (dt.Rows[i][truongA].ToString().Trim().Equals(giaTriA))
                {
                    giatriB = dt.Rows[i][truongB].ToString();
                    return giatriB;
                }
            }
            return giatriB;
        }

        public void Them(string duongDan, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode currNode;
            XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
            docFrag.InnerXml = noiDung;
            currNode = doc.DocumentElement;
            currNode.InsertAfter(docFrag, currNode.LastChild);
            doc.Save(duongDan);
        }

        public void Sua(string duongDan, string tenFile, string suaTheoTruong, string giaTriTruong, string noiDung)
        {
            XmlTextReader reader = new XmlTextReader(duongDan);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();
            XmlNode oldHang;
            XmlElement root = doc.DocumentElement;
            oldHang = root.SelectSingleNode("/NewDataSet/" + tenFile + "[" + suaTheoTruong + " ='" + giaTriTruong + "']");
            XmlElement newhang = doc.CreateElement(tenFile);
            newhang.InnerXml = noiDung;
            root.ReplaceChild(newhang, oldHang);
            doc.Save(duongDan);
        }
        public void Xoa(string duongDan, string tenFileXML, string xoaTheoTruong, string giaTriTruong)
        {
            string fileName = Application.StartupPath + "\\" + duongDan;
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode nodeCu = doc.SelectSingleNode("NewDataSet/" + tenFileXML + "[" + xoaTheoTruong + "='" + giaTriTruong + "']");
            doc.DocumentElement.RemoveChild(nodeCu);
            doc.Save(fileName);
        }

        public void InsertOrUpDateSQL(string sql)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

