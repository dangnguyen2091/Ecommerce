using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.DAO;
using Ecommerce.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.BUS
{
    public class SanPhamBUS
    { 
        #region Cast to entity
        private SanPham Cast(SanPhamViewModel viewModel)
        {
            SanPham entity = new SanPham()
            {
                ID = viewModel.SanPhamID,
                MaSanPham = viewModel.MaSanPham,
                TenSanPham = viewModel.TenSanPham,
                NhomSanPhamID = viewModel.NhomSanPhamID,
                DonGia = viewModel.DonGia,
                MoTa = viewModel.MoTa,
                HinhAnh = viewModel.HinhAnh,
                ThuocTinh = ParseListThuocTinhToJson(viewModel.ThuocTinhs),
            };
            return entity;
        }
        #endregion

        #region Cast to viewmodel
        private SanPhamViewModel Cast(SanPham entity)
        {
            SanPhamViewModel viewModel = new SanPhamViewModel()
            {
                SanPhamID = entity.ID,
                MaSanPham = entity.MaSanPham,
                TenSanPham = entity.TenSanPham,
                NhomSanPhamID = entity.NhomSanPhamID,
                DonGia = entity.DonGia,
                MoTa = entity.MoTa,
                HinhAnh = entity.HinhAnh,
                ThuocTinh = entity.ThuocTinh,
            };
            return viewModel;
        }
        #endregion
        
        private string ParseListThuocTinhToJson(List<ThuocTinhViewModel> viewModels)
        {
            var s = viewModels.Select(d => $"\\\"{d.MaThuocTinh}\\\":\\\"{d.GiaTri}\\\"");
            string json = "{" + string.Join(",", s) + "}";
            return json;
        }

        private string Validate(SanPhamViewModel viewModel)
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

        public SanPhamViewModel InitCreate()
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            SanPhamViewModel viewModel = new SanPhamViewModel();
            viewModel.NhomSanPhamCollection = bus.GetAll();
            return viewModel;
        }

        public SanPhamViewModel InitUpdate(int id)
        {
            NhomSanPhamBUS nspBus = new NhomSanPhamBUS();
            SanPhamBUS spBus = new SanPhamBUS();
            SanPhamViewModel viewModel = spBus.GetById(id);
            viewModel.NhomSanPhamCollection = nspBus.GetAll();
            return viewModel;
        }

        public SanPhamViewModel InitDelete(int id)
        {
            SanPhamBUS bus = new SanPhamBUS();
            SanPhamViewModel viewModel = bus.GetById(id);
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
                SanPham entity = Cast(viewModel);
                SanPhamDAO dao = new SanPhamDAO();
                result = dao.Insert(entity);
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
                SanPham entity = Cast(viewModel);
                SanPhamDAO dao = new SanPhamDAO();
                result = dao.Update(entity);
            }
            return result;
        }

        public ResultHandle Delete(int id)
        {
            SanPhamDAO dao = new SanPhamDAO();
            ResultHandle result = dao.Delete(id);
            return result;
        }

        public List<SanPhamDisplayViewModel> DisplayAll()
        {
            SanPhamDAO dao = new SanPhamDAO();
            List<SanPham> entities = dao.GetAll();
            List<SanPhamDisplayViewModel> viewModels = new List<SanPhamDisplayViewModel>();
            foreach (SanPham entity in entities)
            {
                SanPhamDisplayViewModel viewModel = new SanPhamDisplayViewModel()
                {
                    SanPhamID = entity.ID,
                    MaSanPham = entity.MaSanPham,
                    TenSanPham = entity.TenSanPham,
                    NhomSanPhamID = entity.NhomSanPhamID,
                    TenNhomSanPham = entity.NhomSanPham.TenNhomSanPham,
                    DonGia = entity.DonGia,
                    ThuocTinh = entity.ThuocTinh,
                    MoTa = entity.MoTa,
                    HinhAnhUrl = ImageHelper.GetImageUrl(entity.HinhAnh),
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public List<SanPhamViewModel> GetAll()
        {
            SanPhamDAO dao = new SanPhamDAO();
            List<SanPham> entities = dao.GetAll();
            List<SanPhamViewModel> viewModels = new List<SanPhamViewModel>();
            foreach (SanPham entity in entities)
            {
                SanPhamViewModel viewModel = Cast(entity);
                viewModels.Add(viewModel);
            }
            return viewModels;
        }

        public SanPhamViewModel GetById(int id)
        {
            SanPhamDAO dao = new SanPhamDAO();
            SanPham entity = dao.GetById(id);
            SanPhamViewModel viewModel = Cast(entity);
            return viewModel;
        }

        public List<ThuocTinhViewModel> GetThuocTinh(int nspId)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            List<ThuocTinhViewModel> list = new List<ThuocTinhViewModel>();
            NhomSanPhamViewModel nspViewModel = bus.GetById(nspId);
            while (nspViewModel?.NhomSanPhamChaID != null)
            {
                list.InsertRange(0, bus.GetThuocTinhByNhomSanPhamID(nspViewModel.NhomSanPhamChaID.Value));
                nspViewModel = bus.GetById(nspViewModel.NhomSanPhamChaID.Value);
            }
            list.AddRange(bus.GetThuocTinhByNhomSanPhamID(nspId));
            return list;
        }

        public List<SanPhamDisplayViewModel> GetSanPhamBanChay()
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            viewModels = ListHelper.GetRandom(viewModels, 9);
            return viewModels;
        }

        public List<SanPhamDisplayViewModel> GetSanPhamMoi()
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            viewModels = ListHelper.GetRandom(viewModels, 6);
            return viewModels;
        }

        public List<SanPhamDisplayViewModel> GetByNhomSanPham(int nspId)
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            if (nspId > 0)
            {
                NhomSanPhamBUS nspBUS = new NhomSanPhamBUS();
                List<NhomSanPhamDisplayViewModel> nsps = new List<NhomSanPhamDisplayViewModel>();
                nspBUS.GetNhomSanPhamTreeDown(nspId, ref nsps);

                List<SanPhamDisplayViewModel> sps = new List<SanPhamDisplayViewModel>();
                foreach (NhomSanPhamDisplayViewModel nsp in nsps)
                {
                    sps.AddRange(viewModels.FindAll(s => s.NhomSanPhamID == nsp.NhomSanPhamID));
                }
                viewModels = sps;
            }
            return viewModels;
        }

        public SanPhamDisplayViewModel GetSanPham(int id)
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            SanPhamDisplayViewModel viewModel = viewModels.FirstOrDefault(s => s.SanPhamID == id);
            if (viewModel != null)
            {
                List<ThuocTinhViewModel> thuocTinhs = new List<ThuocTinhViewModel>();
                JObject jObject = (JObject)JsonConvert.DeserializeObject(viewModel.ThuocTinh.Replace(@"\", ""));
                thuocTinhs = GetThuocTinh(viewModel.NhomSanPhamID);
                foreach (ThuocTinhViewModel thuocTinh in thuocTinhs)
                {
                    thuocTinh.GiaTri = jObject[thuocTinh.MaThuocTinh]?.ToString();
                }
                viewModel.ThuocTinhs = thuocTinhs;
            }
            return viewModel;
        }

        public List<SanPhamDisplayViewModel> SearchSanPham(string search)
        {
            List<SanPhamDisplayViewModel> viewModels = DisplayAll();
            viewModels = viewModels.FindAll(v => v.TenSanPham.ToLower().Contains(search.ToLower()));
            return viewModels;
        }
    }
}
