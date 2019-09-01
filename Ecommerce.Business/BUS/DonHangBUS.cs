using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.DAO;
using Ecommerce.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ecommerce.Business.BUS
{
    public class DonHangBUS
    {
        #region Cast to entity
        private DonHang Cast(DonHangViewModel viewModel)
        {
            DonHang entity = new DonHang()
            {
                ID = viewModel.DonHangID,
                MaDonHang = viewModel.MaDonHang,
                NgayLap = viewModel.NgayLap,
                KhachHangID = viewModel.KhachHangID,
                NguoiNhan = viewModel.NguoiNhan,
                DiaChiNhan = viewModel.DiaChiNhan,
                SdtNguoiNhan = viewModel.SdtNguoiNhan,
                HinhThucThanhToan = viewModel.HinhThucThanhToan,
                PhiVanChuyen = viewModel.PhiVanChuyen,
                TinhTrangDonHang = viewModel.TinhTrangDonHang,
                GhiChu = viewModel.GhiChu,
                DonHangCTs = Cast(viewModel.GioHangItems)
            };
            return entity;
        }

        private DonHangCT Cast(GioHangItemViewModel viewModel)
        {
            DonHangCT entity = new DonHangCT()
            {
                SanPhamID = viewModel.SanPhamID,
                SoLuong = viewModel.SoLuong,
                DonGia = viewModel.DonGia
            };
            return entity;
        }

        private List<DonHangCT> Cast(List<GioHangItemViewModel> viewModels)
        {
            List<DonHangCT> entities = new List<DonHangCT>();
            foreach (GioHangItemViewModel viewModel in viewModels)
            {
                DonHangCT entity = Cast(viewModel);
                entities.Add(entity);
            }
            return entities;
        }
        #endregion

        public string Validate(DonHangViewModel viewModel)
        {
            string error = "";
            if (string.IsNullOrEmpty(viewModel.NguoiNhan))
                error += "Người nhận không được rỗng\n";
            if (string.IsNullOrEmpty(viewModel.DiaChiNhan))
                error += "Địa chỉ nhận hàng không được rỗng\n";
            if (string.IsNullOrEmpty(viewModel.SdtNguoiNhan))
                error += "Số điện thoại người nhận không được rỗng\n";
            if (viewModel.HinhThucThanhToan == 0)
                error += "Hình thức thanh toán không được rỗng";
            return error;
        }

        public DonHangViewModel InitDatHang()
        {
            DonHangViewModel viewModel = new DonHangViewModel();
            viewModel.HinhThucThanhToanCollection = new HinhThucThanhToanBUS().GetAll();
            return viewModel;
        }

        public ResultHandle Insert(DonHangViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            viewModel.NgayLap = DateTime.Now;
            viewModel.KhachHangID = 1;
            viewModel.TinhTrangDonHang = 1;
            DonHang entity = Cast(viewModel);
            DonHangDAO dao = new DonHangDAO();
            ResultHandle result = dao.Insert(entity);
            return result;
        }
    }
}
