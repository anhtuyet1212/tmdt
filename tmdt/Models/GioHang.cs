using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tmdt.Models
{
    public class GioHang
    {
        public sp Spham { get; set; }
        public int SoLuong { get; set; }
        public GioHang()
        {

        }
        public GioHang(sp spham, int soluong)
        {
            this.Spham = spham;
            this.SoLuong = soluong;
        }
    }
}