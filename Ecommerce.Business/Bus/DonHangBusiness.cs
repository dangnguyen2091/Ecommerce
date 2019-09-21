using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;

namespace Ecommerce.Business.BUS
{
    public class DonHangBusiness : Business<DonHangViewModel, DonHangViewModel>, IDonHangBusiness
    {
        private readonly IHinhThucThanhToanBusiness hinhThucThanhToanBusiness;

        public DonHangBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            hinhThucThanhToanBusiness = new HinhThucThanhToanBusiness(unitOfWork);
        }

        protected override string Validate(DonHangViewModel viewModel)
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

        public DonHangViewModel InitInsert()
        {
            DonHangViewModel viewModel = new DonHangViewModel();
            viewModel.HinhThucThanhToanCollection = hinhThucThanhToanBusiness.GetAll();
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
            DonHang entity = (DonHang)viewModel.ToEntity();
            entity.MaDonHang = $"DH{unitOfWork.DonHangRepository.MaxID() + 1}";
            entity.DonHangCTs = CastToEntities<GioHangItemViewModel, DonHangCT>(viewModel.GioHangItems);
            unitOfWork.DonHangRepository.Insert(entity);
            ResultHandle result = unitOfWork.Save();
            return result;
        }

        public DonHangViewModel InitUpdate(int id)
        {
            throw new NotImplementedException();
        }

        public DonHangViewModel InitDelete(int id)
        {
            throw new NotImplementedException();
        }

        public ResultHandle Update(DonHangViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public ResultHandle Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<DonHangViewModel> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public List<DonHangViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public DonHangViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
