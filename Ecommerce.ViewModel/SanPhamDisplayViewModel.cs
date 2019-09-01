using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class SanPhamDisplayViewModel
    {
        public int SanPhamID { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int NhomSanPhamID { get; set; }
        public string TenNhomSanPham { get; set; }
        public decimal DonGia { get; set; }
        public string HinhAnhUrl { get; set; }
        public string ThuocTinh { get; set; }
        public string MoTa { get; set; }
        public List<ThuocTinhViewModel> ThuocTinhs { get; set; }

        public SanPhamDisplayViewModel()
        {
            SanPhamID = 0;
            MaSanPham = null;
            TenSanPham = null;
            NhomSanPhamID = 0;
            TenNhomSanPham = null;
            DonGia = 0;
            HinhAnhUrl = null;
            ThuocTinh = null;
            MoTa = null;
            ThuocTinhs = new List<ThuocTinhViewModel>();
        }
    }
}
