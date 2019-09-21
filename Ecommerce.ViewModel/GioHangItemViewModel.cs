using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("DonHangCT")]
    public class GioHangItemViewModel : BaseViewModel
    {
        [PropertyCast("SanPhamID")]
        public int SanPhamID { get; set; }

        [PropertyCast("SanPham.TenSanPham")]
        public string TenSanPham { get; set; }

        [PropertyCast("SoLuong")]
        public int SoLuong { get; set; }

        [PropertyCast("DonGia")]
        public decimal DonGia { get; set; }

        public string HinhAnhUrl { get; set; }
    }
}
