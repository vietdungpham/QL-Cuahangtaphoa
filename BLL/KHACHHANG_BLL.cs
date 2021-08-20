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
    public class KHACHHANG_BLL
    {
        Connecting conn = new Connecting();
        public DataTable ChonKhachHang()
        {
            String sqlQuery = "SELECT * FROM KHACHHANG";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimKhachHang(string kieuTK, string tuKhoa)
        {
            String sqlQuery = "SELECT * FROM KHACHHANG WHERE " + kieuTK + " LIKE N'%" + tuKhoa + "%'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public void ThemKhachHang(string maKH, string tenKH,string sdt)
        {
            string sqlQuery = "INSERT INTO KHACHHANG VALUES('" + maKH + "', N'" + tenKH + "',null,'" + sdt + "')";
            conn.ExecNonQuery(sqlQuery);
        }
        public void SuaKhachHang(KHACHHANG khachHang)
        {
            string sqlQuery = "UPDATE KHACHHANG SET TENKH= N'" + khachHang.HoTen + "',GIOITNH='" + khachHang.GioiTinh + "' WHERE MAKH='" + khachHang.ID + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public void XoaKhachHang(KHACHHANG khachHang)
        {
            string sqlQuery = "DELETE KHACHHANG WHERE MAKH='" + khachHang.ID + "'";
            conn.ExecNonQuery(sqlQuery);
        }

        public bool KTTonTaiKH(string sdt, string tenKH)
        {
            string sql = "Select * from KHACHHANG WHERE MAKH =" + sdt + " OR TENKH =N'" + tenKH + "'";
            if (conn.DataReader(sql).Read() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
