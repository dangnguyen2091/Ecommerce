using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class SanPhamViewModel
    {
        public int SanPhamID { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int NhomSanPhamID { get; set; }
        public decimal DonGia { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string ThuocTinh { get; set; }
        public List<ThuocTinhViewModel> ThuocTinhs { get; set; }

        public System.Web.HttpPostedFileBase FileUpload { get; set; }
        public List<NhomSanPhamViewModel> NhomSanPhamCollection { get; set; }

        public SanPhamViewModel()
        {
            SanPhamID = 0;
            MaSanPham = null;
            TenSanPham = null;
            NhomSanPhamID = 0;
            DonGia = 0;
            MoTa = null;
            HinhAnh = null;
            ThuocTinh = null;
            ThuocTinhs = new List<ThuocTinhViewModel>();
            NhomSanPhamCollection = new List<NhomSanPhamViewModel>();
        }
    }
}
