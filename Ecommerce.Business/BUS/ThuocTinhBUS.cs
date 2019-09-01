using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.BUS
{
    public class ThuocTinhBUS
    {
        public ThuocTinh Cast(ThuocTinhViewModel viewModel)
        {
            ThuocTinh entity = new ThuocTinh()
            {
                NhomSanPhamID = viewModel.NhomSanPhamID,
                MaThuocTinh = viewModel.MaThuocTinh,
                TenThuocTinh = viewModel.TenThuocTinh,
                DonViTinh = viewModel.DonViTinh,
            };
            return entity;
        }

        public List<ThuocTinh> Cast(List<ThuocTinhViewModel> viewModels)
        {
            List<ThuocTinh> entities = new List<ThuocTinh>();
            foreach (ThuocTinhViewModel viewModel in viewModels)
            {
                ThuocTinh entity = Cast(viewModel);
                entities.Add(entity);
            }
            return entities;
        }

        public ThuocTinhViewModel Cast(ThuocTinh entity)
        {
            ThuocTinhViewModel viewModel = new ThuocTinhViewModel()
            {
                NhomSanPhamID = entity.NhomSanPhamID,
                MaThuocTinh = entity.MaThuocTinh,
                TenThuocTinh = entity.TenThuocTinh,
                DonViTinh = entity.DonViTinh,
            };
            return viewModel;
        }

        public List<ThuocTinhViewModel> Cast(List<ThuocTinh> entities)
        {
            List<ThuocTinhViewModel> viewModels = new List<ThuocTinhViewModel>();
            foreach (ThuocTinh entity in entities)
            {
                ThuocTinhViewModel viewModel = Cast(entity);
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
