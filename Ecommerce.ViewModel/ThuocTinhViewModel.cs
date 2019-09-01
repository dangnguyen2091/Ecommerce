using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class ThuocTinhViewModel
    {
        public int NhomSanPhamID { get; set; }
        public string MaThuocTinh { get; set; }
        public string TenThuocTinh { get; set; }
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
