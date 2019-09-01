using Ecommerce.Attributes;
using Ecommerce.Base;
using Ecommerce.Business.BUS;
using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Areas.Administrator.Controllers
{
    public class SanPhamController : AdminController
    {
        public ActionResult Create()
        {
            //@Html.Raw(System.Web.HttpUtility.HtmlDecode(ViewBag.MoTa))
            SanPhamBUS bus = new SanPhamBUS();
            SanPhamViewModel viewModel = bus.InitCreate();
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {
            //@Html.Raw(System.Web.HttpUtility.HtmlDecode(ViewBag.MoTa))
            SanPhamBUS bus = new SanPhamBUS();
            SanPhamViewModel viewModel = bus.InitUpdate(id);
            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            SanPhamBUS bus = new SanPhamBUS();
            SanPhamViewModel viewModel = bus.InitDelete(id);
            return View(viewModel);
        }

        [HttpGet]
        public JsonResult Display(int pageIndex)
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<SanPhamDisplayViewModel> viewModels = bus.DisplayAll();
            viewModels.ForEach(x => { x.ThuocTinh = x.ThuocTinh.Replace(@"\", ""); });
            PageHelper page = new PageHelper(viewModels, pageIndex);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(SanPhamViewModel viewModel)
        {
            viewModel.NhomSanPhamID = int.Parse(Request.Form["NhomSanPhamID"].Substring(Request.Form["NhomSanPhamID"].IndexOf(',') + 1));
            viewModel.ThuocTinhs = JsonConvert.DeserializeObject<List<ThuocTinhViewModel>>(Request.Form["ThuocTinhs"]);
            SanPhamBUS bus = new SanPhamBUS();            
            ResultHandle result = bus.Insert(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(SanPhamViewModel viewModel)
        {
            viewModel.SanPhamID = int.Parse(Request.Form["SanPhamID"].Substring(Request.Form["SanPhamID"].IndexOf(',') + 1));
            viewModel.NhomSanPhamID = int.Parse(Request.Form["NhomSanPhamID"].Substring(Request.Form["NhomSanPhamID"].IndexOf(',') + 1));
            viewModel.ThuocTinhs = JsonConvert.DeserializeObject<List<ThuocTinhViewModel>>(Request.Form["ThuocTinhs"]);
            viewModel.HinhAnh = Request.Form["HinhAnh"];
            SanPhamBUS bus = new SanPhamBUS();
            ResultHandle result = bus.Update(viewModel);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(SanPhamViewModel viewModel)
        {
            SanPhamBUS bus = new SanPhamBUS();
            ResultHandle result = bus.Delete(viewModel.SanPhamID);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ViewThuocTinh(int nspId)
        {
            SanPhamBUS bus = new SanPhamBUS();
            List<ThuocTinhViewModel> list = bus.GetThuocTinh(nspId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}