using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;

namespace BLL
{
    public class SANPHAM_BLL
    {
        Connecting conn = new Connecting();
        public DataTable ChonSanPham()
        {
            String sqlQuery = "SELECT * FROM SANPHAM";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TatCaLoaiHang()
        {
            string sqlQuery = "SELECT DISTINCT LOAIHANG FROM SANPHAM";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }
        public DataTable TimSanPham(string kieuTK, string tuKhoa)
        {
            String sqlQuery = "SELECT * FROM SANPHAM WHERE "+kieuTK+" LIKE N'%" + tuKhoa + "%'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }


        public DataTable TimSanPhamTheoSL(string bieuThuc)
        {
            String sqlQuery = "SELECT * FROM SANPHAM WHERE SL " + bieuThuc + " 0";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sqlQuery);
            return dt;
        }

        public DataTable ThemDSMua(string maSP)
        {
            string sqlQuery = "select TENSP, (DONGIANHAP/100*15 + DONGIANHAP) as GIA from SANPHAM inner join DONGPNHAP on SANPHAM.MASP = DONGPNHAP.MASP where SANPHAM.MASP = '" + maSP + "'";
            return conn.GetTable(sqlQuery);
        }
        public int kiemtratrunghang;
        public void ThemSanPham(SANPHAM sanPham)
        {
           
            string sql = "Select * from SANPHAM where TENSP= N'" + sanPham.TenSP + "'";
        
            if (conn.DataReader(sql).Read() == true)
            {
                MessageBox.Show("Mặt hàng này đã có");
                kiemtratrunghang = 1;
            }
            else
            {
                string sqlQuery = "INSERT INTO SANPHAM VALUES('" + sanPham.MaSP + "',N'" + sanPham.TenSP + "',N'" + sanPham.LoaiHang + "',N'" + sanPham.MoTa + "','" + sanPham.SoLuong + "')";
                conn.ExecNonQuery(sqlQuery);
                kiemtratrunghang = 0;
            }                
        }
        public int tonTaiSP;
        public void KTSanPham(string tenSP)
        {

            string sql = "Select * from SANPHAM where TENSP= N'" + tenSP + "'";

            if (conn.DataReader(sql).Read() == true)
            {
                tonTaiSP = 1;
            }
            else
            {
                tonTaiSP = 0;
            }
        }
        public DataTable ThongKeSanPhamBanChay()
        {
            string sqlQuery = "exec SanPhamBanChayNhat";
            return conn.GetTable(sqlQuery);
        }

        public DataTable TKSanPhamTonNN()
        {
            string sqlQuery = "exec SanPhamTonNhieuNhat";
            return conn.GetTable(sqlQuery);
        }

        public void SuaSanPham(string maSP, string tenSP, string loaiHang, string moTa)
        {
            string sqlQuery = "UPDATE SANPHAM SET TENSP=N'" + tenSP + "', LOAIHANG=N'" + loaiHang + "', MOTA=N'" + moTa + "' WHERE MASP='" + maSP + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public void XoaSanPham(string maSP)
        {
            string sqlQuery = "DELETE SANPHAM WHERE MASP='" + maSP + "'";
            conn.ExecNonQuery(sqlQuery);
        }
        public DataTable LayMASP(string tenSP)
        {
            string sql = "Select MASP from SANPHAM where TENSP= N'" + tenSP + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
        public DataTable LaySLTonKho(string maSP)
        {
            string sql = "select SL from SANPHAM where MASP='" + maSP + "'";
            DataTable dt = new DataTable();
            dt = conn.GetTable(sql);
            return dt;
        }
    }
}
