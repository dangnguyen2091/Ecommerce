using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.DAO;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.BUS
{
    public class HinhThucThanhToanBUS
    {
        private HinhThucThanhToanViewModel Cast(HinhThucThanhToan entity)
        {
            HinhThucThanhToanViewModel viewModel = new HinhThucThanhToanViewModel()
            {
                HinhThucThanhToanID = entity.ID,
                TenHinhThucThanhToan = entity.TenHinhThucThanhToan,
            };
            return viewModel;
        }

        private List<HinhThucThanhToanViewModel> Cast(List<HinhThucThanhToan> entities)
        {
            List<HinhThucThanhToanViewModel> viewModels = new List<HinhThucThanhToanViewModel>();
            foreach (HinhThucThanhToan entity in entities)
            {
                HinhThucThanhToanViewModel viewModel = Cast(entity);
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public List<HinhThucThanhToanViewModel> GetAll()
        {
            HinhThucThanhToanDAO dao = new HinhThucThanhToanDAO();
            List<HinhThucThanhToan> entities = dao.GetAll();
            List<HinhThucThanhToanViewModel> viewModels = Cast(entities);
            return viewModels;
        }
    }
}
