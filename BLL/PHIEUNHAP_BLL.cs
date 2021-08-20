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
    public class PHIEUNHAP_BLL
    {
        Connecting conn = new Connecting();
        public DataTable ToanBoPhieuNhap()
        {
            String sqlQuery = "select PNHAP.MAPN, NHACC.TENNCC, NHANVIEN.TENNV, PNHAP.NGAYNHAP from PNHAP inner join NHACC on PNHAP.MANCC=NHACC.MANCC INNER JOIN NHANVIEN ON PNHAP.MANV=NHANVIEN.MANV";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimTheoKieu(string kieuTim, string tuKhoa)
        {
            String sqlQuery = "select PNHAP.MAPN, NHACC.TENNCC, NHANVIEN.TENNV, PNHAP.NGAYNHAP from PNHAP inner join NHACC on PNHAP.MANCC=NHACC.MANCC INNER JOIN NHANVIEN ON PNHAP.MANV=NHANVIEN.MANV WHERE " + kieuTim + " LIKE N'%" + tuKhoa + "%'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public void ThemPhieuNhap(PHIEUNHAP phieuNhap)
        {
            string sqlQuery = "INSERT INTO PNHAP VALUES('" + phieuNhap.MaPN + "','" + phieuNhap.MaNCC + "','" + phieuNhap.MaNV + "','" + phieuNhap.NgayNhap.ToString() + "')";
            conn.ExecNonQuery(sqlQuery);
        }
    }
}
