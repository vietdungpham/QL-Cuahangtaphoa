using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DONGPN
    {
        private string maPN;
        private string maSP;
        private string SLNhap;
        private string donGiaNhap;

        public string MaPN { get => maPN; set => maPN = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string SLNhap1 { get => SLNhap; set => SLNhap = value; }
        public string DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }

        public DONGPN(string maPN, string maSP, string sLNhap, string donGiaNhap)
        {
            this.maPN = maPN;
            this.maSP = maSP;
            SLNhap = sLNhap;
            this.donGiaNhap = donGiaNhap;
        }
    }
}
