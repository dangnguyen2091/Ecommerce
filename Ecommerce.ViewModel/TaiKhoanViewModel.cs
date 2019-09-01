using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class TaiKhoanViewModel
    {
        public int NhanVienID { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string TenDangNhap { get; set; }
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
