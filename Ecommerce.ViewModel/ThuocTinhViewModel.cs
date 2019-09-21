using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("ThuocTinh")]
    public class ThuocTinhViewModel : BaseViewModel
    {
        [PropertyCast("NhomSanPhamID")]
        public int NhomSanPhamID { get; set; }

        [PropertyCast("MaThuocTinh")]
        public string MaThuocTinh { get; set; }

        [PropertyCast("TenThuocTinh")]
        public string TenThuocTinh { get; set; }

        [PropertyCast("DonViTinh")]
        public string DonViTinh { get; set; }
        
        public string GiaTri { get; set; }

        public ThuocTinhViewModel()
        {
            NhomSanPhamID = 0;
            MaThuocTinh = null;
            TenThuocTinh = null;
            DonViTinh = null;
            GiaTri = null;
        }
    }
}
