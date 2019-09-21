using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.DataLayer.Context;
using Ecommerce.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Business.BUS
{
    public class SanPhamBusiness : Business<SanPhamViewModel, SanPhamDisplayViewModel>, ISanPhamBusiness
    {
        private readonly INhomSanPhamBusiness nhomSanPhamBusiness;

        public SanPhamBusiness(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            nhomSanPhamBusiness = new NhomSanPhamBusiness(unitOfWork);
        }
        
        private string ParseListThuocTinhToJson(List<ThuocTinhViewModel> viewModels)
        {
            var s = viewModels.Select(d => $"\\\"{d.MaThuocTinh}\\\":\\\"{d.GiaTri}\\\"");
            string json = "{" + string.Join(",", s) + "}";
            return json;
        }

        protected override string Validate(SanPhamViewModel viewModel)
        {
            string error = "";
            if (string.IsNullOrEmpty(viewModel.MaSanPham))
                error += "Mã không được rỗng\n";
            if (string.IsNullOrEmpty(viewModel.TenSanPham))
                error += "Tên không được rỗng\n";
            if (viewModel.NhomSanPhamID <= 0)
                error += "Nhóm sản phẩm không được rỗng\n";
            if (viewModel.DonGia < 0)
                error += "Đơn giá không được nhỏ hơn 0\n";
            return error;
        }

        public SanPhamViewModel InitInsert()
        {
            List<NhomSanPham> nhomSanPhams = unitOfWork.NhomSanPhamRepository.FindAll(includeProperties: "NhomSanPham2").ToList();
            SanPhamViewModel viewModel = new SanPhamViewModel
            {
                NhomSanPhamCollection = CastToViewModels<NhomSanPham, NhomSanPhamViewModel>(nhomSanPhams)
            };
            return viewModel;
        }

        public SanPhamViewModel InitUpdate(int id)
        {
            List<NhomSanPham> nhomSanPhams = unitOfWork.NhomSanPhamRepository.FindAll(includeProperties: "NhomSanPham2").ToList();
            SanPhamViewModel viewModel = GetById(id);
            viewModel.NhomSanPhamCollection = CastToViewModels<NhomSanPham, NhomSanPhamViewModel>(nhomSanPhams);
            return viewModel;
        }

        public SanPhamViewModel InitDelete(int id)
        {
            SanPhamViewModel viewModel = GetById(id);
            return viewModel;
        }

        public ResultHandle Insert(SanPhamViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            ResultHandle result = ImageHelper.SaveImage(viewModel.FileUpload, ImageHelper.Prefix.SanPham, viewModel.MaSanPham);
            if (!result.HasError)
            {
                viewModel.HinhAnh = result.Outputs["HinhAnh"]?.ToString();
                SanPham entity = (SanPham)viewModel.ToEntity();
                entity.ThuocTinh = ParseListThuocTinhToJson(viewModel.ThuocTinhs);
                unitOfWork.SanPhamRepository.Insert(entity);
                result = unitOfWork.Save();
            }
            return result;
        }

        public ResultHandle Update(SanPhamViewModel viewModel)
        {
            string validation = Validate(viewModel);
            if (!string.IsNullOrEmpty(validation))
            {
                return ResultHandle.InvalidInput(validation);
            }
            ResultHandle result = ImageHelper.SaveImage(viewModel.FileUpload, ImageHelper.Prefix.SanPham, viewModel.MaSanPham);
            if (!result.HasError)
            {
                if (!(result.Outputs["HinhAnh"] == null && !string.IsNullOrEmpty(viewModel.HinhAnh)))
                    viewModel.HinhAnh = result.Outputs["HinhAnh"]?.ToString();
                SanPham entity = (SanPham)viewModel.ToEntity();
                entity.ThuocTinh = ParseListThuocTinhToJson(viewModel.ThuocTinhs);
                unitOfWork.SanPhamRepository.Update(entity);
                result = unitOfWork.Save();
            }
            return result;
        }

        public ResultHandle Delete(int id)
        {
            unitOfWork.SanPhamRepository.Delete(id);
            ResultHandle result = unitOfWork.Save();
            return result;
        }

        public List<SanPhamDisplayViewModel> DisplayAll()
        {
            List<SanPham> entities = unitOfWork.SanPhamRepository.FindAll(includeProperties: "NhomSanPham").ToList();
            List<SanPhamDisplayViewModel> viewModels = CastToViewModels<SanPham, SanPhamDisplayViewModel>(entities);
            for (int i = 0; i < entities.Count; i++)
            {
                viewModels[i].HinhAnhUrl = ImageHelper.GetImageUrl(entities[i].HinhAnh);
            }
            return viewModels;
        }

        public List<SanPhamViewModel> GetAll()
        {
            List<SanPham> entities = unitOfWork.SanPhamRepository.FindAll(includeProperties: "NhomSanPham").ToList();
            List<SanPhamViewModel> viewModels = CastToViewModels<SanPham, SanPhamViewModel>(entities);
            return viewModels;
        }

        public SanPhamViewModel GetById(int id)
        {
            SanPham entity = unitOfWork.SanPhamRepository.Find(filter: e => e.ID == id, includeProperties: "NhomSanPham");
            SanPhamViewModel viewModel = new SanPhamViewModel();
            viewModel.BindEntity(entity);
            return viewModel;
        }

        public List<ThuocTinhViewModel> GetThuocTinh(int nspId)
        {
            List<ThuocTinhViewModel> list = new List<ThuocTinhViewModel>();
            NhomSanPhamViewModel nspViewModel = nhomSanPhamBusiness.GetById(nspId);
            while (nspViewModel?.NhomSanPhamChaID != null)
            {
                list.InsertRange(0, nhomSanPhamBusiness.GetThuocTinhByNhomSanPhamID(nspViewModel.NhomSanPhamChaID.Value));
                nspViewModel = nhomSanPhamBusiness.GetById(nspViewModel.NhomSanPhamChaID.Value);
            }
            list.AddRange(nhomSanPhamBusiness.GetThuocTinhByNhomSanPhamID(nspId));
            return list;
        }

        public List<SanPhamDisplayViewModel> DisplaySanPhamBanChay()
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            viewModels = ListHelper.GetRandom(viewModels, 9);
            return viewModels;
        }

        public List<SanPhamDisplayViewModel> DisplaySanPhamMoi()
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            viewModels = ListHelper.GetRandom(viewModels, 6);
            return viewModels;
        }

        public List<SanPhamDisplayViewModel> DisplaySanPhamByNhomSanPham(int nspId)
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            if (nspId > 0)
            {
                List<NhomSanPhamDisplayViewModel> nsps = new List<NhomSanPhamDisplayViewModel>();
                nhomSanPhamBusiness.GetNhomSanPhamTreeDown(nspId, ref nsps);

                List<SanPhamDisplayViewModel> sps = new List<SanPhamDisplayViewModel>();
                foreach (NhomSanPhamDisplayViewModel nsp in nsps)
                {
                    sps.AddRange(viewModels.FindAll(s => s.NhomSanPhamID == nsp.NhomSanPhamID));
                }
                viewModels = sps;
            }
            return viewModels;
        }

        public SanPhamDisplayViewModel DisplaySanPham(int id)
        {
            SanPham entity = unitOfWork.SanPhamRepository.Find(filter: e => e.ID == id);
            if (entity != null)
            {
                SanPhamDisplayViewModel viewModel = new SanPhamDisplayViewModel();
                viewModel.BindEntity(entity);
                viewModel.HinhAnhUrl = ImageHelper.GetImageUrl(entity.HinhAnh);
                List<ThuocTinhViewModel> thuocTinhs = new List<ThuocTinhViewModel>();
                JObject jObject = (JObject)JsonConvert.DeserializeObject(viewModel.ThuocTinh.Replace(@"\", ""));
                thuocTinhs = GetThuocTinh(viewModel.NhomSanPhamID);
                foreach (ThuocTinhViewModel thuocTinh in thuocTinhs)
                {
                    thuocTinh.GiaTri = jObject[thuocTinh.MaThuocTinh]?.ToString();
                }
                viewModel.ThuocTinhs = thuocTinhs;
                return viewModel;
            }
            return null;
        }

        public List<SanPhamDisplayViewModel> SearchSanPham(string search)
        {
            List<SanPham> entities = unitOfWork.SanPhamRepository.FindAll(
                filter: e => e.TenSanPham.ToLower().Contains(search.ToLower()),
                includeProperties: "NhomSanPham").ToList();
            List<SanPhamDisplayViewModel> viewModels = CastToViewModels<SanPham, SanPhamDisplayViewModel>(entities);
            return viewModels;
        }
    }
}
