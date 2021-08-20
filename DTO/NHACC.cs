using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NHACC
    {
        private string maNCC;
        private string tenNCC;
        private string soDT;
        private string diaChi;

        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }

        public NHACC(string maNCC, string tenNCC, string soDT, string diaChi)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.soDT = soDT;
            this.diaChi = diaChi;
        }
    }
}
