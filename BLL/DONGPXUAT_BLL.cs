using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class DONGPXUAT_BLL
    {
        Connecting conn = new Connecting();
        public void ThemDongPXuat(DONGPX dongPXuat)
        {
            string sqlQuery = "INSERT INTO DONGPXUAT VALUES('" + dongPXuat.MaPX + "','" + dongPXuat.MaSP + "'," + dongPXuat.SLXuat1 + "," + dongPXuat.DonGiaXuat + ")";
            conn.ExecNonQuery(sqlQuery);
        }
        public DataTable ToanBoSanPham(string maPX)
        {
            String sqlQuery = "select SANPHAM.MASP, SANPHAM.TENSP, DONGPXUAT.SOLUONGXUAT, DONGPXUAT.DONGIAXUAT, DONGPXUAT.SOLUONGXUAT*DONGPXUAT.DONGIAXUAT AS 'THANHTIEN' from DONGPXUAT inner join SANPHAM on DONGPXUAT.MASP=SANPHAM.MASP WHERE MAPX='" + maPX + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimTheoKieu(string kieuTim, string maPX)
        {
            String sqlQuery = "SELECT " + kieuTim + " FROM PXUAT INNER JOIN DONGPXUAT ON DONGPXUAT.MAPX=PXUAT.MAPX INNER JOIN NHANVIEN ON PXUAT.MANV=NHANVIEN.MANV INNER JOIN KHACHHANG ON PXUAT.MAKH=KHACHHANG.MAKH WHERE PXUAT.MAPX='" + maPX + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable BaoCaoDS(DateTime ngayBD, DateTime ngayKT)
        {
            string sql = "exec baocaodoanhsoban '"+ngayBD+"','"+ngayKT+"'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
    }
}
