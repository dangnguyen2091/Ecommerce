using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("SanPham")]
    public class SanPhamDisplayViewModel : BaseViewModel
    {
        [PropertyCast("ID")]
        public int SanPhamID { get; set; }

        [PropertyCast("MaSanPham")]
        public string MaSanPham { get; set; }

        [PropertyCast("TenSanPham")]
        public string TenSanPham { get; set; }

        [PropertyCast("NhomSanPhamID")]
        public int NhomSanPhamID { get; set; }

        [PropertyCast("NhomSanPham.TenNhomSanPham")]
        public string TenNhomSanPham { get; set; }

        [PropertyCast("DonGia")]
        public decimal DonGia { get; set; }

        public string HinhAnhUrl { get; set; }

        [PropertyCast("ThuocTinh")]
        public string ThuocTinh { get; set; }

        [PropertyCast("MoTa")]
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
