using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XML_CuoiKi.Models
{
    class Laptop
    {
        connect Fxml = new connect();
        public bool kiemtra(string MaLaptop)
        {
            XmlTextReader reader = new XmlTextReader("Laptop.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            DataView dv = new DataView(ds.Tables[0]);
            dv.Sort = "MaLaptop";
            reader.Close();
            int index = dv.Find(MaLaptop);
            if (index == -1)
            {
                return false;
            }
            return true;
        }

        public void them(string MaLaptop, string TenLaptop, string HangSanXuat, string LoaiCardDoHoa,
                  string LoaiCPU, string DungLuongRAM, string LoaiRAM, string LoaiOCung,
                  string KichThuocManHinh, string DoPhanGiaiManHinh, string CongNgheAmThanh,
                  string CongGiaoTiep, string Wifi, string Bluetooth, string KichThuoc,
                  string TrongLuong, string TinhNangDacBiet, string BaoMatKhac,
                  string HeDieuHanh, string Pin, decimal GiaBan, int SoLuongTon, string Anh,
                  string MaDanhMuc)
        {
            string noiDung = "<_x0027_Laptop_x0027_>" +
                             "<MaLaptop>" + MaLaptop + "</MaLaptop>" +
                             "<TenLaptop>" + TenLaptop + "</TenLaptop>" +
                             "<HangSanXuat>" + HangSanXuat + "</HangSanXuat>" +
                             "<LoaiCardDoHoa>" + LoaiCardDoHoa + "</LoaiCardDoHoa>" +
                             "<LoaiCPU>" + LoaiCPU + "</LoaiCPU>" +
                             "<DungLuongRAM>" + DungLuongRAM + "</DungLuongRAM>" +
                             "<LoaiRAM>" + LoaiRAM + "</LoaiRAM>" +
                             "<LoaiOCung>" + LoaiOCung + "</LoaiOCung>" +
                             "<KichThuocManHinh>" + KichThuocManHinh + "</KichThuocManHinh>" +
                             "<DoPhanGiaiManHinh>" + DoPhanGiaiManHinh + "</DoPhanGiaiManHinh>" +
                             "<CongNgheAmThanh>" + CongNgheAmThanh + "</CongNgheAmThanh>" +
                             "<CongGiaoTiep>" + CongGiaoTiep + "</CongGiaoTiep>" +
                             "<Wifi>" + Wifi + "</Wifi>" +
                             "<Bluetooth>" + Bluetooth + "</Bluetooth>" +
                             "<KichThuoc>" + KichThuoc + "</KichThuoc>" +
                             "<TrongLuong>" + TrongLuong + "</TrongLuong>" +
                             "<TinhNangDacBiet>" + TinhNangDacBiet + "</TinhNangDacBiet>" +
                             "<BaoMatKhac>" + BaoMatKhac + "</BaoMatKhac>" +
                             "<HeDieuHanh>" + HeDieuHanh + "</HeDieuHanh>" +
                             "<Pin>" + Pin + "</Pin>" +
                             "<GiaBan>" + GiaBan + "</GiaBan>" +
                             "<SoLuongTon>" + SoLuongTon + "</SoLuongTon>" +
                             "<Anh>" + Anh + "</Anh>" +
                             "<MaDanhMuc>" + MaDanhMuc + "</MaDanhMuc>" +
                             "</_x0027_Laptop_x0027_>";

            Fxml.Them("Laptop.xml", noiDung);
        }


        public void sua(string MaLaptop, string TenLaptop, string HangSanXuat, string LoaiCardDoHoa,
                  string LoaiCPU, string DungLuongRAM, string LoaiRAM, string LoaiOCung,
                  string KichThuocManHinh, string DoPhanGiaiManHinh, string CongNgheAmThanh,
                  string CongGiaoTiep, string Wifi, string Bluetooth, string KichThuoc,
                  string TrongLuong, string TinhNangDacBiet, string BaoMatKhac,
                  string HeDieuHanh, string Pin, decimal GiaBan, int SoLuongTon, string Anh,
                  string MaDanhMuc)
        {
            // Tạo nội dung XML của nút mới
            string noiDung =
                             "<MaLaptop>" + MaLaptop + "</MaLaptop>" +
                             "<TenLaptop>" + TenLaptop + "</TenLaptop>" +
                             "<HangSanXuat>" + HangSanXuat + "</HangSanXuat>" +
                             "<LoaiCardDoHoa>" + LoaiCardDoHoa + "</LoaiCardDoHoa>" +
                             "<LoaiCPU>" + LoaiCPU + "</LoaiCPU>" +
                             "<DungLuongRAM>" + DungLuongRAM + "</DungLuongRAM>" +
                             "<LoaiRAM>" + LoaiRAM + "</LoaiRAM>" +
                             "<LoaiOCung>" + LoaiOCung + "</LoaiOCung>" +
                             "<KichThuocManHinh>" + KichThuocManHinh + "</KichThuocManHinh>" +
                             "<DoPhanGiaiManHinh>" + DoPhanGiaiManHinh + "</DoPhanGiaiManHinh>" +
                             "<CongNgheAmThanh>" + CongNgheAmThanh + "</CongNgheAmThanh>" +
                             "<CongGiaoTiep>" + CongGiaoTiep + "</CongGiaoTiep>" +
                             "<Wifi>" + Wifi + "</Wifi>" +
                             "<Bluetooth>" + Bluetooth + "</Bluetooth>" +
                             "<KichThuoc>" + KichThuoc + "</KichThuoc>" +
                             "<TrongLuong>" + TrongLuong + "</TrongLuong>" +
                             "<TinhNangDacBiet>" + TinhNangDacBiet + "</TinhNangDacBiet>" +
                             "<BaoMatKhac>" + BaoMatKhac + "</BaoMatKhac>" +
                             "<HeDieuHanh>" + HeDieuHanh + "</HeDieuHanh>" +
                             "<Pin>" + Pin + "</Pin>" +
                             "<GiaBan>" + GiaBan + "</GiaBan>" +
                             "<SoLuongTon>" + SoLuongTon + "</SoLuongTon>" +
                             "<Anh>" + Anh + "</Anh>" +
                             "<MaDanhMuc>" + MaDanhMuc + "</MaDanhMuc>";

            // Gọi hàm `Sua` trong lớp `connect` để cập nhật thông tin
            Fxml.Sua("Laptop.xml", "_x0027_Laptop_x0027_", "MaLaptop", MaLaptop, noiDung);
        }

        public void xoa(string MaLaptop)
        {
            Fxml.Xoa("Laptop.xml", "_x0027_Laptop_x0027_", "MaLaptop", MaLaptop);
        }
    }
}
