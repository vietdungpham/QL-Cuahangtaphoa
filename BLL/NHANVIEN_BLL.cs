using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NHANVIEN_BLL
    {
        Connecting conn = new Connecting();
        public DataTable ChonNhanVien()
        {
            String sqlQuery = "SELECT * FROM NHANVIEN";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimNhanVien(string type, string info)
        {
            String sqlQuery = "SELECT * FROM NHANVIEN WHERE "+type+" LIKE '%" + info + "%'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public void ThemNhanVien(NHANVIEN nhanVien)
        {
            string sqlQuery = "INSERT INTO NHANVIEN VALUES('" + nhanVien.ID + "', N'" + nhanVien.HoTen + "','" + nhanVien.GioiTinh + "','" + nhanVien.SoDT + "', N'" + nhanVien.DiaChi + "','" + nhanVien.MatKhau + "','"+nhanVien.TinhTrang+"')";
            conn.ExecNonQuery(sqlQuery);
        }
        public void SuaNhanVien(NHANVIEN nhanVien)
        {
            string sqlQuery = "UPDATE NHANVIEN SET TENNV= N'" + nhanVien.HoTen + "',GIOITNH='" + nhanVien.GioiTinh + "',SODT='" + nhanVien.SoDT + "', DIACHI= N'"+nhanVien.DiaChi+"',STATUS='"+nhanVien.TinhTrang+"' WHERE MANV='" + nhanVien.ID + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public void XoaNhanVien(string manv)
        {
            string sqlQuery = "DELETE NHANVIEN WHERE MANV='" + manv + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public int ktDangNhap;
        public void DangNhap(string username, string password)
        {

            string sql = "Select * from NHANVIEN where MANV='" + username + "' AND PASSWORD='"+password+"'";

            if (conn.DataReader(sql).Read() == true)
            {
                ktDangNhap = 1;
            }
            else
            {
                ktDangNhap = 0;
            }


        }
        public string LayLoaiTaiKhoan(string manv)
        {
            string sql = "exec layraloaitaikhoan '" + manv + "'";
            string loaitk = conn.GetTable(sql).Rows[0][0].ToString();
            return loaitk;
        }
        public void UpdateMK(string manv, string matkhaumoi)
        {
            string sql = "update NHANVIEN set password ='" + matkhaumoi + "' where manv='" + manv + "'"; 
            conn.ExecNonQuery(sql);
        }
        public DataTable TinhTrang()
        {
            string sql = "SELECT DISTINCT STATUS FROM NHANVIEN";
            DataTable dt = conn.GetTable(sql);
            return dt;
        }
    }
}
