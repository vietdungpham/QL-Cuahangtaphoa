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
    public class NHACC_BLL
    {
        Connecting conn = new Connecting();
        public DataTable ChonNhaCC()
        {
            String sqlQuery = "SELECT * FROM NHACC";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable LaySDTNCC(string tenNCC)
        {
            string sql = "SELECT SODT FROM NHACC WHERE TENNCC LIKE N'%" + tenNCC + "%'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
        public void ThemNCC(NHACC nhaCC)
        {
            string sqlQuery = "INSERT INTO NHACC VALUES('" + nhaCC.MaNCC + "', N'" + nhaCC.TenNCC + "', N'" + nhaCC.DiaChi + "','" + nhaCC.SoDT + "')";
            conn.ExecNonQuery(sqlQuery);
        }
        public void SuaNCC(NHACC nhaCC)
        {
            string sqlQuery = "UPDATE NHACC SET TENNCC= N'" + nhaCC.TenNCC + "',DIACHI= N'" + nhaCC.DiaChi + "' WHERE MANCC='" + nhaCC.MaNCC + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public void XoaNCC(string maNCC)
        {
            string sqlQuery = "DELETE NHACC WHERE MANCC='" + maNCC + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public int tonTaiNCC;
        public void KTNhaCC(string tenNCC)
        {
            string sql = "select * from NHACC WHERE TENNCC= N'" + tenNCC + "'";
            if (conn.DataReader(sql).Read() == true)
            {
                tonTaiNCC = 0;
            }
            else
            {
                tonTaiNCC = 1;
            }
        }
        public bool KTTTNhaCC(string tenNCC)
        {
            string sql = "select * from NHACC WHERE TENNCC= N'" + tenNCC + "'";
            if (conn.DataReader(sql).Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable TimKiemNCC(string kieuTK, string tuKhoa)
        {
            string sql = "Select * from NHACC where " + kieuTK + " LIKE N'%" + tuKhoa + "%'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
    }
}
