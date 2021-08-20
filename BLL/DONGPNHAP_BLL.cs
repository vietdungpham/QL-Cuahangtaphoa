using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DONGPNHAP_BLL
    {
        Connecting conn = new Connecting();
        public void ThemDongPNhap(DONGPN dongPNhap)
        {
            string sqlQuery = "INSERT INTO DONGPNHAP VALUES('" + dongPNhap.MaSP + "','" + dongPNhap.MaPN + "'," + dongPNhap.SLNhap1 + "," + dongPNhap.DonGiaNhap + ")";
            conn.ExecNonQuery(sqlQuery);
        }
        public DataTable ToanBoSanPham(string maPN)
        {
            String sqlQuery = "select SANPHAM.MASP, SANPHAM.TENSP, DONGPNHAP.SOLUONGNHAP, DONGPNHAP.DONGIANHAP, DONGPNHAP.SOLUONGNHAP*DONGPNHAP.DONGIANHAP AS THANHTIEN from DONGPNHAP inner join SANPHAM on DONGPNHAP.MASP=SANPHAM.MASP WHERE MAPN='" + maPN + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimTheoKieu(string kieuTim, string maPN)
        {
            String sqlQuery = "SELECT " + kieuTim + " FROM PNHAP INNER JOIN DONGPNHAP ON DONGPNHAP.MAPN=PNHAP.MAPN INNER JOIN NHANVIEN ON PNHAP.MANV=NHANVIEN.MANV INNER JOIN NHACC ON PNHAP.MANCC=NHACC.MANCC WHERE PNHAP.MAPN='" + maPN + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }

        public DataTable BaoCaoDS(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = "exec baocaodoanhsonhap '"+ngayBD+"','"+ngayKT+"'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
    }
}
