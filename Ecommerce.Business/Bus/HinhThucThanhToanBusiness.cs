using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Business.BUS
{
    public class HinhThucThanhToanBusiness : Business<HinhThucThanhToanViewModel, HinhThucThanhToanViewModel>, IHinhThucThanhToanBusiness
    {
        public HinhThucThanhToanBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ResultHandle Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<HinhThucThanhToanViewModel> DisplayAll()
        {
            throw new NotImplementedException();
        }

        public List<HinhThucThanhToanViewModel> GetAll()
        {
            List<HinhThucThanhToan> entities = unitOfWork.HinhThucThanhToanRepository.FindAll().ToList();
            List<HinhThucThanhToanViewModel> viewModels =
                CastToViewModels<HinhThucThanhToan, HinhThucThanhToanViewModel>(entities);
            return viewModels;
        }

        public HinhThucThanhToanViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public HinhThucThanhToanViewModel InitDelete(int id)
        {
            throw new NotImplementedException();
        }

        public HinhThucThanhToanViewModel InitInsert()
        {
            throw new NotImplementedException();
        }

        public HinhThucThanhToanViewModel InitUpdate(int id)
        {
            throw new NotImplementedException();
        }

        public ResultHandle Insert(HinhThucThanhToanViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public ResultHandle Update(HinhThucThanhToanViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
