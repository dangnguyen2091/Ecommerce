using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModel
{
    public class DangNhapViewModel : BaseViewModel
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string RequestUrl { get; set; }

        public DangNhapViewModel()
        {
            TenDangNhap = null;
            MatKhau = null;
            RequestUrl = null;
        }
    }
}
