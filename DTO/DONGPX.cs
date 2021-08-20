using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DONGPX
    {
        private string maPX;
        private string maSP;
        private string SLXuat;
        private string donGiaXuat;

        public string MaPX { get => maPX; set => maPX = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string SLXuat1 { get => SLXuat; set => SLXuat = value; }
        public string DonGiaXuat { get => donGiaXuat; set => donGiaXuat = value; }

        public DONGPX(string maPX, string maSP, string sLXuat, string donGiaXuat)
        {
            this.maPX = maPX;
            this.maSP = maSP;
            SLXuat = sLXuat;
            this.DonGiaXuat = donGiaXuat;
        }
    }
}
