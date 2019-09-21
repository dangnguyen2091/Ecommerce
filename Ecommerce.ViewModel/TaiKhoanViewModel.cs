using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("TaiKhoan")]
    public class TaiKhoanViewModel : BaseViewModel
    {
        [PropertyCast("NhanVien.ID")]
        public int NhanVienID { get; set; }

        [PropertyCast("NhanVien.MaNhanVien")]
        public string MaNhanVien { get; set; }

        [PropertyCast("NhanVien.TenNhanVien")]
        public string TenNhanVien { get; set; }

        [PropertyCast("TenDangNhap")]
        public string TenDangNhap { get; set; }

        [PropertyCast("NhanVien.NhomNguoiDungID")]
        public int NhomNguoiDungID { get; set; }

        public TaiKhoanViewModel()
        {
            NhanVienID = 0;
            MaNhanVien = null;
            TenNhanVien = null;
            TenDangNhap = null;
            NhomNguoiDungID = 0;
        }
    }
}
