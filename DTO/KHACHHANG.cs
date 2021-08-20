using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KHACHHANG : NGUOI
    {
        public KHACHHANG(string iD, string hoTen, string gioiTinh, string soDT) : base(iD, hoTen, gioiTinh, soDT)
        {

        }
    }

}
