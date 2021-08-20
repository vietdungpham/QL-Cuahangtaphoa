using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PHIEUXUAT
    {
        private string maPX;
        private string maKH;
        private string maNV;
        private DateTime ngayXuat;

        public string MaPX { get => maPX; set => maPX = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public DateTime NgayXuat { get => ngayXuat; set => ngayXuat = value; }

        public PHIEUXUAT(string maPX, string maKH, string maNV, DateTime ngayXuat)
        {
            this.maPX = maPX;
            this.maKH = maKH;
            this.maNV = maNV;
            this.ngayXuat = ngayXuat;
        }
    }
}
