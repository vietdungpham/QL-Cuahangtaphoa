using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NGUOI
    {
        private string iD;
        private string hoTen;
        private string gioiTinh;
        private string soDT;

        public string ID { get => iD; set => iD = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SoDT { get => soDT; set => soDT = value; }

        public NGUOI(string iD, string hoTen, string gioiTinh, string soDT)
        {
            this.iD = iD;
            this.hoTen = hoTen;
            this.gioiTinh = gioiTinh;
            this.soDT = soDT;
        }
    }
}
