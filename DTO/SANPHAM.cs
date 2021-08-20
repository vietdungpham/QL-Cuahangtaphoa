using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SANPHAM
    {
        private string maSP;
        private string tenSP;
        private string loaiHang;
        private string moTa;
        private int soLuong;

        public SANPHAM(string maSP, string tenSP, string loaiHang, string moTa, int soLuong)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.loaiHang = loaiHang;
            this.moTa = moTa;
            this.soLuong = soLuong;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string LoaiHang { get => loaiHang; set => loaiHang = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
    }
}
