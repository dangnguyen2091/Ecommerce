using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("SanPham")]
    public class SanPhamViewModel : BaseViewModel
    {
        [PropertyCast("ID")]
        public int SanPhamID { get; set; }

        [PropertyCast("MaSanPham")]
        public string MaSanPham { get; set; }

        [PropertyCast("TenSanPham")]
        public string TenSanPham { get; set; }

        [PropertyCast("NhomSanPhamID")]
        public int NhomSanPhamID { get; set; }

        [PropertyCast("DonGia")]
        public decimal DonGia { get; set; }

        [PropertyCast("MoTa")]
        public string MoTa { get; set; }

        [PropertyCast("HinhAnh")]
        public string HinhAnh { get; set; }

        [PropertyCast("ThuocTinh")]
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
