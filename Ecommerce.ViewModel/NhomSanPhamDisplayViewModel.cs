using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("NhomSanPham")]
    public class NhomSanPhamDisplayViewModel : BaseViewModel
    {
        [PropertyCast("ID")]
        public int NhomSanPhamID { get; set; }

        [PropertyCast("MaNhomSanPham")]
        public string MaNhomSanPham { get; set; }

        [PropertyCast("TenNhomSanPham")]
        public string TenNhomSanPham { get; set; }

        [PropertyCast("NhomSanPhamChaID")]
        public int? NhomSanPhamChaID { get; set; }

        [PropertyCast("NhomSanPham2.MaNhomSanPham")]
        public string MaNhomSanPhamCha { get; set; }

        [PropertyCast("NhomSanPham2.TenNhomSanPham")]
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
