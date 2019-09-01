using Ecommerce.Common.Struct;
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
    public class NhomSanPhamBUS
    {
        #region Cast to entity
        private NhomSanPham Cast(NhomSanPhamViewModel viewModel)
        {
            NhomSanPham entity = new NhomSanPham()
            {
                ID = viewModel.NhomSanPhamID,
                MaNhomSanPham = viewModel.MaNhomSanPham,
                TenNhomSanPham = viewModel.TenNhomSanPham,
                NhomSanPhamChaID = viewModel.NhomSanPhamChaID,
                ThuocTinhs = new ThuocTinhBUS().Cast(viewModel.ThuocTinhs),
            };
            return entity;
        }
        #endregion

        #region Cast to viewmodel

        #endregion

        private string Validate(NhomSanPhamViewModel viewModel)
        {
            string error = "";
            if (string.IsNullOrEmpty(viewModel.MaNhomSanPham))
                error += "Mã không được rỗng\n";
            if (string.IsNullOrEmpty(viewModel.TenNhomSanPham))
                error += "Tên không được rỗng\n";
            return error;
        }

        public NhomSanPhamViewModel InitCreate()
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            List<NhomSanPhamViewModel> viewModels = bus.GetAll();
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel();
            viewModel.NhomSanPhamChaCollection = viewModels.FindAll(n => n.NhomSanPhamChaID == null);
            viewModel.NhomSanPhamChaCollection.Insert(0, new NhomSanPhamViewModel());
            return viewModel;
        }

        public NhomSanPhamViewModel InitUpdate(int id)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            NhomSanPhamViewModel viewModel = bus.GetById(id);
            List<NhomSanPhamViewModel> viewModels = bus.GetAll();
            viewModel.NhomSanPhamChaCollection = viewModels.FindAll(n =>
                n.NhomSanPhamChaID == null && n.NhomSanPhamID != viewModel.NhomSanPhamID);
            viewModel.NhomSanPhamChaCollection.Insert(0, new NhomSanPhamViewModel());
            return viewModel;
        }

        public NhomSanPhamViewModel InitDelete(int id)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            NhomSanPhamViewModel viewModel = bus.GetById(id);
            return viewModel;
        }

        public ResultHandle Insert(NhomSanPhamViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            NhomSanPham entity = Cast(viewModel);
            NhomSanPhamDAO dao = new NhomSanPhamDAO();
            ResultHandle result = dao.Insert(entity);
            return result;
        }

        public ResultHandle Update(NhomSanPhamViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            NhomSanPham entity = Cast(viewModel);
            NhomSanPhamDAO dao = new NhomSanPhamDAO();
            ResultHandle result = dao.Update(entity);
            return result;
        }

        public ResultHandle Delete(int id)
        {
            NhomSanPhamDAO dao = new NhomSanPhamDAO();
            ResultHandle result = dao.Delete(id);
            return result;
        }

        public List<NhomSanPhamDisplayViewModel> DisplayAll()
        {
            NhomSanPhamDAO dao = new NhomSanPhamDAO();
            List<NhomSanPham> entities = dao.GetAll();
            List<NhomSanPhamDisplayViewModel> viewModels = new List<NhomSanPhamDisplayViewModel>();
            foreach (NhomSanPham entity in entities)
            {
                NhomSanPhamDisplayViewModel viewModel = new NhomSanPhamDisplayViewModel()
                {
                    NhomSanPhamID = entity.ID,
                    MaNhomSanPham = entity.MaNhomSanPham,
                    TenNhomSanPham = entity.TenNhomSanPham,
                    NhomSanPhamChaID = entity.NhomSanPhamChaID,
                    TenNhomSanPhamCha = entity.NhomSanPham2?.TenNhomSanPham,
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public List<NhomSanPhamViewModel> GetAll()
        {
            NhomSanPhamDAO dao = new NhomSanPhamDAO();
            List<NhomSanPham> entities = dao.GetAll();
            List<NhomSanPhamViewModel> viewModels = new List<NhomSanPhamViewModel>();
            foreach (NhomSanPham entity in entities)
            {
                NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel()
                {
                    NhomSanPhamID = entity.ID,
                    MaNhomSanPham = entity.MaNhomSanPham,
                    TenNhomSanPham = entity.TenNhomSanPham,
                    NhomSanPhamChaID = entity.NhomSanPhamChaID,
                    MaNhomSanPhamCha = entity.NhomSanPham2?.MaNhomSanPham,
                    TenNhomSanPhamCha = entity.NhomSanPham2?.TenNhomSanPham,
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public NhomSanPhamViewModel GetById(int id)
        {
            NhomSanPhamDAO dao = new NhomSanPhamDAO();
            NhomSanPham entity = dao.GetById(id);
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel()
            {
                NhomSanPhamID = entity.ID,
                MaNhomSanPham = entity.MaNhomSanPham,
                TenNhomSanPham = entity.TenNhomSanPham,
                NhomSanPhamChaID = entity.NhomSanPhamChaID,
                MaNhomSanPhamCha = entity.NhomSanPham2?.MaNhomSanPham,
                TenNhomSanPhamCha = entity.NhomSanPham2?.TenNhomSanPham,
                ThuocTinhs = new ThuocTinhBUS().Cast(entity.ThuocTinhs.ToList()),
            };
            return viewModel;
        }

        public List<ThuocTinhViewModel> GetThuocTinhByNhomSanPhamID(int id)
        {
            ThuocTinhDAO dao = new ThuocTinhDAO();
            List<ThuocTinh> entities = dao.GetThuocTinhByNhomSanPhamID(id);
            List<ThuocTinhViewModel> viewModels = new ThuocTinhBUS().Cast(entities);
            return viewModels;
        }

        public void GetNhomSanPhamTree(int id, ref List<NhomSanPhamDisplayViewModel> viewModels)
        {
            List<NhomSanPhamDisplayViewModel> list = DisplayAll();
            NhomSanPhamDisplayViewModel viewModel = list.FirstOrDefault(i => i.NhomSanPhamID == id);
            if (viewModel != null)
            {
                if (viewModel.NhomSanPhamChaID != null)
                {
                    GetNhomSanPhamTree(viewModel.NhomSanPhamChaID.Value, ref viewModels);
                }
                viewModels.Add(viewModel);
            }
        }

        public void GetNhomSanPhamTreeDown(int id, ref List<NhomSanPhamDisplayViewModel> viewModels)
        {
            List<NhomSanPhamDisplayViewModel> list = DisplayAll();
            NhomSanPhamDisplayViewModel viewModel = list.FirstOrDefault(i => i.NhomSanPhamID == id);
            if (viewModel != null)
            {
                viewModels.Add(viewModel);
                List<NhomSanPhamDisplayViewModel> children = list.FindAll(i => i.NhomSanPhamChaID == id);
                foreach (NhomSanPhamDisplayViewModel child in children)
                {
                    GetNhomSanPhamTreeDown(child.NhomSanPhamID, ref viewModels);
                }
            }
        }
    }
}
