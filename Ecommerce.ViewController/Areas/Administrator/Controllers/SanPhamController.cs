using Ecommerce.Base;
using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecommerce.Areas.Administrator.Controllers
{
    public class SanPhamController : AdminController
    {
        private readonly ISanPhamBusiness sanPhamBusiness;

        public SanPhamController(IPhanQuyenBusiness phanQuyenBusiness, ISanPhamBusiness sanPhamBusiness) : base(phanQuyenBusiness)
        {
            this.sanPhamBusiness = sanPhamBusiness;
        }

        public ActionResult Create()
        {
            //@Html.Raw(System.Web.HttpUtility.HtmlDecode(ViewBag.MoTa))
            SanPhamViewModel viewModel = sanPhamBusiness.InitInsert();
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {
            //@Html.Raw(System.Web.HttpUtility.HtmlDecode(ViewBag.MoTa))
            SanPhamViewModel viewModel = sanPhamBusiness.InitUpdate(id);
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            SanPhamViewModel viewModel = sanPhamBusiness.InitDelete(id);
            return View(viewModel);
        }

        [HttpGet]
        public JsonResult Display(int pageIndex)
        {
            List<SanPhamDisplayViewModel> viewModels = sanPhamBusiness.DisplayAll();
            viewModels.ForEach(x => { x.ThuocTinh = x.ThuocTinh.Replace(@"\", ""); });
            PageHelper page = new PageHelper(viewModels, pageIndex);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(SanPhamViewModel viewModel)
        {
            viewModel.NhomSanPhamID = int.Parse(Request.Form["NhomSanPhamID"].Substring(Request.Form["NhomSanPhamID"].IndexOf(',') + 1));
            viewModel.ThuocTinhs = JsonConvert.DeserializeObject<List<ThuocTinhViewModel>>(Request.Form["ThuocTinhs"]);
            ResultHandle result = sanPhamBusiness.Insert(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(SanPhamViewModel viewModel)
        {
            viewModel.SanPhamID = int.Parse(Request.Form["SanPhamID"].Substring(Request.Form["SanPhamID"].IndexOf(',') + 1));
            viewModel.NhomSanPhamID = int.Parse(Request.Form["NhomSanPhamID"].Substring(Request.Form["NhomSanPhamID"].IndexOf(',') + 1));
            viewModel.ThuocTinhs = JsonConvert.DeserializeObject<List<ThuocTinhViewModel>>(Request.Form["ThuocTinhs"]);
            viewModel.HinhAnh = Request.Form["HinhAnh"];
            ResultHandle result = sanPhamBusiness.Update(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(SanPhamViewModel viewModel)
        {
            ResultHandle result = sanPhamBusiness.Delete(viewModel.SanPhamID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ViewThuocTinh(int nspId)
        {
            List<ThuocTinhViewModel> list = sanPhamBusiness.GetThuocTinh(nspId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}