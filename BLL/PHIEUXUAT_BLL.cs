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
    public class PHIEUXUAT_BLL
    {
        Connecting conn = new Connecting();
        public DataTable ToanBoPhieuXuat()
        {
            String sqlQuery = "select PXUAT.MAPX, TENKH, TENNV, NGAYXUAT from PXUAT " +
                "inner join KHACHHANG on PXUAT.MAKH=KHACHHANG.MAKH INNER JOIN " +
                "NHANVIEN ON PXUAT.MANV=NHANVIEN.MANV";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimTheoKieu(string kieuTim, string tuKhoa)
        {
            String sqlQuery = "select PXUAT.MAPX, TENKH, TENNV, NGAYXUAT from PXUAT inner join KHACHHANG " +
                "on PXUAT.MAKH=KHACHHANG.MAKH INNER JOIN NHANVIEN " +
                "ON PXUAT.MANV=NHANVIEN.MANV " +
                "WHERE PXUAT." + kieuTim + " LIKE '" + tuKhoa + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public void ThemPhieuXuat(PHIEUXUAT phieuXuat)
        {
            string sqlQuery = "INSERT INTO PXUAT VALUES('" + phieuXuat.MaPX + "','" + phieuXuat.MaKH + "','" + phieuXuat.MaNV + "','"+phieuXuat.NgayXuat.ToString()+"')";
            conn.ExecNonQuery(sqlQuery);
        }
        public DataTable InHoaDon(string maPX)
        {
            string sql = "SELECT PXUAT.MAPX, PXUAT.NGAYXUAT, KHACHHANG.TENKH, NHANVIEN.TENNV " +
                "FROM PXUAT INNER JOIN NHANVIEN ON PXUAT.MANV=NHANVIEN.MANV " +
                "INNER JOIN KHACHHANG ON PXUAT.MAKH=KHACHHANG.MAKH WHERE PXUAT.MAPX='" + maPX + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
    }
}
