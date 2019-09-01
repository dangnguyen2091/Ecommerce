using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class DonHangViewModel
    {
        public int DonHangID { get; set; }
        public string MaDonHang { get; set; }
        public DateTime NgayLap { get; set; }
        public int KhachHangID { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiNhan { get; set; }
        public string SdtNguoiNhan { get; set; }
        public int HinhThucThanhToan { get; set; }
        public decimal PhiVanChuyen { get; set; }
        public int TinhTrangDonHang { get; set; }
        public string GhiChu { get; set; }
        public List<GioHangItemViewModel> GioHangItems { get; set; }
        public List<HinhThucThanhToanViewModel> HinhThucThanhToanCollection { get; set; }

        public DonHangViewModel()
        {
            DonHangID = 0;
            MaDonHang = null;
            NgayLap = new DateTime();
            KhachHangID = 0;
            NguoiNhan = null;
            DiaChiNhan = null;
            SdtNguoiNhan = null;
            HinhThucThanhToan = 0;
            PhiVanChuyen = 0;
            TinhTrangDonHang = 0;
            GhiChu = null;
            GioHangItems = new List<GioHangItemViewModel>();
            HinhThucThanhToanCollection = new List<HinhThucThanhToanViewModel>();
        }
    }
}
