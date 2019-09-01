using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class NhomSanPhamDisplayViewModel
    {
        public int NhomSanPhamID { get; set; }
        public string MaNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public int? NhomSanPhamChaID { get; set; }
        public string MaNhomSanPhamCha { get; set; }
        public string TenNhomSanPhamCha { get; set; }

        public NhomSanPhamDisplayViewModel()
        {
            NhomSanPhamID = 0;
            MaNhomSanPham = null;
            TenNhomSanPham = null;
            NhomSanPhamChaID = null;
            MaNhomSanPhamCha = null;
            TenNhomSanPhamCha = null;
        }
    }
}
