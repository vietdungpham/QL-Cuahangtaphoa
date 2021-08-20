using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NHANVIEN : NGUOI
    {
        private string diaChi;
        private string matKhau;
        private string tinhTrang;

        public NHANVIEN(string iD, string hoTen, string gioiTinh, string soDT, string diaChi, string matKhau, string tinhTrang) : base(iD, hoTen, gioiTinh, soDT)
        {
            this.diaChi = diaChi;
            this.matKhau = matKhau;
            this.TinhTrang = tinhTrang;
        }

        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
    }
}
