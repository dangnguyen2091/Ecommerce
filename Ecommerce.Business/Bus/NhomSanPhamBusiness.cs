using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Business.BUS
{
    public class NhomSanPhamBusiness : Business<NhomSanPhamViewModel, NhomSanPhamDisplayViewModel>, INhomSanPhamBusiness
    {
        public NhomSanPhamBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        protected override string Validate(NhomSanPhamViewModel viewModel)
        {
            string error = "";
            if (string.IsNullOrEmpty(viewModel.MaNhomSanPham))
                error += "Mã không được rỗng\n";
            if (string.IsNullOrEmpty(viewModel.TenNhomSanPham))
                error += "Tên không được rỗng\n";
            return error;
        }

        public NhomSanPhamViewModel InitInsert()
        {
            List<NhomSanPham> entities = unitOfWork.NhomSanPhamRepository.FindAll(
                filter: e => e.NhomSanPhamChaID == null, 
                includeProperties: "NhomSanPham2").ToList();
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel
            {
                NhomSanPhamChaCollection = CastToViewModels<NhomSanPham, NhomSanPhamViewModel>(entities)
            };
            viewModel.NhomSanPhamChaCollection.Insert(0, new NhomSanPhamViewModel());
            return viewModel;
        }

        public NhomSanPhamViewModel InitUpdate(int id)
        {
            List<NhomSanPham> entities = unitOfWork.NhomSanPhamRepository.FindAll(
                filter: e => e.NhomSanPhamChaID == null && e.ID != id, 
                includeProperties: "NhomSanPham2").ToList();
            NhomSanPhamViewModel viewModel = GetById(id);
            viewModel.NhomSanPhamChaCollection = CastToViewModels<NhomSanPham, NhomSanPhamViewModel>(entities);
            viewModel.NhomSanPhamChaCollection.Insert(0, new NhomSanPhamViewModel());
            return viewModel;
        }

        public NhomSanPhamViewModel InitDelete(int id)
        {
            NhomSanPhamViewModel viewModel = GetById(id);
            return viewModel;
        }

        public ResultHandle Insert(NhomSanPhamViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            NhomSanPham entity = (NhomSanPham)viewModel.ToEntity();
            unitOfWork.NhomSanPhamRepository.Insert(entity);
            unitOfWork.ThuocTinhRepository.InsertRange(
                CastToEntities<ThuocTinhViewModel, ThuocTinh>(viewModel.ThuocTinhs));
            ResultHandle result = unitOfWork.Save();
            return result;
        }

        public ResultHandle Update(NhomSanPhamViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            NhomSanPham entity = (NhomSanPham)viewModel.ToEntity();
            unitOfWork.ThuocTinhRepository.DeleteRange(
                unitOfWork.ThuocTinhRepository.FindAll(filter: e => e.NhomSanPhamID == entity.ID));
            unitOfWork.NhomSanPhamRepository.Update(entity);
            unitOfWork.ThuocTinhRepository.InsertRange(
                CastToEntities<ThuocTinhViewModel, ThuocTinh>(viewModel.ThuocTinhs));
            ResultHandle result = unitOfWork.Save();
            return result;
        }

        public ResultHandle Delete(int id)
        {
            unitOfWork.ThuocTinhRepository.DeleteRange(
                unitOfWork.ThuocTinhRepository.FindAll(filter: e => e.NhomSanPhamID == id));
            unitOfWork.NhomSanPhamRepository.Delete(id);
            ResultHandle result = unitOfWork.Save();
            return result;
        }

        public List<NhomSanPhamDisplayViewModel> DisplayAll()
        {
            List<NhomSanPham> entities = unitOfWork.NhomSanPhamRepository.FindAll(
                includeProperties: "NhomSanPham2").ToList();
            List<NhomSanPhamDisplayViewModel> viewModels = 
                CastToViewModels<NhomSanPham, NhomSanPhamDisplayViewModel>(entities);
            return viewModels;
        }

        public List<NhomSanPhamViewModel> GetAll()
        {
            List<NhomSanPham> entities = unitOfWork.NhomSanPhamRepository.FindAll(
                includeProperties: "NhomSanPham2").ToList();
            List<NhomSanPhamViewModel> viewModels = 
                CastToViewModels<NhomSanPham, NhomSanPhamViewModel>(entities);
            return viewModels;
        }

        public NhomSanPhamViewModel GetById(int id)
        {
            NhomSanPham entity = unitOfWork.NhomSanPhamRepository.Find(
                filter: e => e.ID == id, 
                includeProperties: "NhomSanPham2,ThuocTinhs");
            NhomSanPhamViewModel viewModel = new NhomSanPhamViewModel();
            viewModel.BindEntity(entity);
            viewModel.ThuocTinhs = CastToViewModels<ThuocTinh, ThuocTinhViewModel>(entity.ThuocTinhs.ToList());
            return viewModel;
        }

        public List<ThuocTinhViewModel> GetThuocTinhByNhomSanPhamID(int id)
        {
            List<ThuocTinh> entities = unitOfWork.ThuocTinhRepository.FindAll(
                filter: e => e.NhomSanPhamID == id).ToList();
            List<ThuocTinhViewModel> viewModels = CastToViewModels<ThuocTinh, ThuocTinhViewModel>(entities);
            return viewModels;
        }

        public void GetNhomSanPhamTree(int id, ref List<NhomSanPhamDisplayViewModel> viewModels)
        {
            NhomSanPham entity = unitOfWork.NhomSanPhamRepository.Find(
                filter: e => e.ID == id, 
                includeProperties: "NhomSanPham2");
            if (entity != null)
            {
                NhomSanPhamDisplayViewModel viewModel = new NhomSanPhamDisplayViewModel();
                viewModel.BindEntity(entity);
                if (viewModel.NhomSanPhamChaID != null)
                {
                    GetNhomSanPhamTree(viewModel.NhomSanPhamChaID.Value, ref viewModels);
                }
                viewModels.Add(viewModel);
            }
        }

        public void GetNhomSanPhamTreeDown(int id, ref List<NhomSanPhamDisplayViewModel> viewModels)
        {
            NhomSanPham entity = unitOfWork.NhomSanPhamRepository.Find(
                filter: e => e.ID == id, 
                includeProperties: "NhomSanPham2");
            if (entity != null)
            {
                NhomSanPhamDisplayViewModel viewModel = new NhomSanPhamDisplayViewModel();
                viewModel.BindEntity(entity);
                viewModels.Add(viewModel);
                List<NhomSanPham> entities = unitOfWork.NhomSanPhamRepository.FindAll(
                    filter: e => e.NhomSanPhamChaID == id, 
                    includeProperties: "NhomSanPham2").ToList();
                List<NhomSanPhamDisplayViewModel> children = 
                    CastToViewModels<NhomSanPham, NhomSanPhamDisplayViewModel>(entities);
                foreach (NhomSanPhamDisplayViewModel child in children)
                {
                    GetNhomSanPhamTreeDown(child.NhomSanPhamID, ref viewModels);
                }
            }
        }
    }
}
