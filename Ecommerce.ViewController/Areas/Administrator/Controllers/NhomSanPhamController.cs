using Ecommerce.Base;
using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ecommerce.Areas.Administrator.Controllers
{
    public class NhomSanPhamController : AdminController
    {
        private readonly INhomSanPhamBusiness nhomSanPhamBusiness;        

        public NhomSanPhamController(IPhanQuyenBusiness phanQuyenBusiness, INhomSanPhamBusiness nhomSanPhamBusiness) : base(phanQuyenBusiness)
        {
            this.nhomSanPhamBusiness = nhomSanPhamBusiness;
        }

        public ActionResult Create()
        {
            NhomSanPhamViewModel viewModel = nhomSanPhamBusiness.InitInsert();
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {
            NhomSanPhamViewModel viewModel = nhomSanPhamBusiness.InitUpdate(id);
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            NhomSanPhamViewModel viewModel = nhomSanPhamBusiness.InitDelete(id);
            return View(viewModel);
        }

        [HttpGet]
        public JsonResult Display(int pageIndex)
        {
            List<NhomSanPhamDisplayViewModel> viewModels = nhomSanPhamBusiness.DisplayAll();
            PageHelper page = new PageHelper(viewModels, pageIndex);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(NhomSanPhamViewModel viewModel)
        {
            ResultHandle result = nhomSanPhamBusiness.Insert(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(NhomSanPhamViewModel viewModel)
        {
            ResultHandle result = nhomSanPhamBusiness.Update(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(NhomSanPhamViewModel viewModel)
        {
            ResultHandle result = nhomSanPhamBusiness.Delete(viewModel.NhomSanPhamID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ViewThuocTinh(int id)
        {
            List<ThuocTinhViewModel> list = nhomSanPhamBusiness.GetThuocTinhByNhomSanPhamID(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}