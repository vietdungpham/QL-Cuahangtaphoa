using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PHIEUNHAP
    {
        private string maPN;
        private string maNCC;
        private string maNV;
        private DateTime ngayNhap;

        public string MaPN { get => maPN; set => maPN = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayNhap { get => ngayNhap; set => ngayNhap = value; }

        public PHIEUNHAP(string maPN, string maNCC, string maNV, DateTime ngayNhap)
        {
            this.maPN = maPN;
            this.maNCC = maNCC;
            this.maNV = maNV;
            this.ngayNhap = ngayNhap;
        }
    }
}
