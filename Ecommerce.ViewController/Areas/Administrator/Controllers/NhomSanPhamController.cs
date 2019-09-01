using Ecommerce.Attributes;
using Ecommerce.Base;
using Ecommerce.Business.BUS;
using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Administrator.Controllers
{
    public class NhomSanPhamController : AdminController
    {
        public ActionResult Create()
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            NhomSanPhamViewModel viewModel = bus.InitCreate();
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            NhomSanPhamViewModel viewModel = bus.InitUpdate(id);
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            NhomSanPhamViewModel viewModel = bus.InitDelete(id);
            return View(viewModel);
        }

        [HttpGet]
        public JsonResult Display(int pageIndex)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            List<NhomSanPhamDisplayViewModel> viewModels = bus.DisplayAll();
            PageHelper page = new PageHelper(viewModels, pageIndex);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(NhomSanPhamViewModel viewModel)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            ResultHandle result = bus.Insert(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(NhomSanPhamViewModel viewModel)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            ResultHandle result = bus.Update(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(NhomSanPhamViewModel viewModel)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            ResultHandle result = bus.Delete(viewModel.NhomSanPhamID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ViewThuocTinh(int id)
        {
            NhomSanPhamBUS bus = new NhomSanPhamBUS();
            List<ThuocTinhViewModel> list = bus.GetThuocTinhByNhomSanPhamID(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}