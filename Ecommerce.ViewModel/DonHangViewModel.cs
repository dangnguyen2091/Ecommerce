using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("DonHang")]
    public class DonHangViewModel : BaseViewModel
    {
        [PropertyCast("ID")]
        public int DonHangID { get; set; }

        [PropertyCast("MaDonHang")]
        public string MaDonHang { get; set; }

        [PropertyCast("NgayLap")]
        public DateTime NgayLap { get; set; }

        [PropertyCast("KhachHangID")]
        public int KhachHangID { get; set; }

        [PropertyCast("NguoiNhan")]
        public string NguoiNhan { get; set; }

        [PropertyCast("DiaChiNhan")]
        public string DiaChiNhan { get; set; }

        [PropertyCast("SdtNguoiNhan")]
        public string SdtNguoiNhan { get; set; }

        [PropertyCast("HinhThucThanhToan")]
        public int HinhThucThanhToan { get; set; }

        [PropertyCast("PhiVanChuyen")]
        public decimal PhiVanChuyen { get; set; }

        [PropertyCast("TinhTrangDonHang")]
        public int TinhTrangDonHang { get; set; }

        [PropertyCast("GhiChu")]
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
