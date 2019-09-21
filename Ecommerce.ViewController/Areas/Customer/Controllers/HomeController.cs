using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.Enums;
using Ecommerce.Helpers;
using Ecommerce.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ecommerce.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {
        private readonly INhomSanPhamBusiness nhomSanPhamBusiness;
        private readonly ISanPhamBusiness sanPhamBusiness;
        private readonly IDonHangBusiness donHangBusiness;

        public HomeController(INhomSanPhamBusiness nhomSanPhamBusiness, 
            ISanPhamBusiness sanPhamBusiness, IDonHangBusiness donHangBusiness)
        {
            this.nhomSanPhamBusiness = nhomSanPhamBusiness;
            this.sanPhamBusiness = sanPhamBusiness;
            this.donHangBusiness = donHangBusiness;
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;
        //    filterContext.Result = new ViewResult() { ViewName = "Error" };
        //}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string search)
        {
            ViewBag.Search = search;
            return View();
        }

        public ActionResult Product(int nspId = 0)
        {
            List<NhomSanPhamDisplayViewModel> viewModels = new List<NhomSanPhamDisplayViewModel>();
            if (nspId > 0)
            {
                nhomSanPhamBusiness.GetNhomSanPhamTree(nspId, ref viewModels);
            }

            ViewBag.NhomSPHierarchy =  viewModels;
            return View(nspId);
        }

        public ActionResult Detail(int id)
        {
            SanPhamDisplayViewModel viewModel = sanPhamBusiness.DisplaySanPham(id);
            return View(viewModel);
        }

        public ActionResult Cart()
        {
            List<GioHangItemViewModel> viewModels = CartCookieHelper.Deserialize(Request);
            return View(viewModels);
        }

        public ActionResult Checkout()
        {
            List<GioHangItemViewModel> gioHang = CartCookieHelper.Deserialize(Request);
            if (gioHang.Count == 0)
                return Content("Access denied!");

            DonHangViewModel viewModel = donHangBusiness.InitInsert();
            viewModel.GioHangItems = gioHang;
            return View(viewModel);
        }

        public ActionResult Thanks()
        {
            if (Session[SessionName.Checkout] is null)
                return Content("Access denied!");

            Session[SessionName.Checkout] = null;
            return View();
        }

        [HttpGet]
        public JsonResult GetNhomSanPham()
        {
            List<NhomSanPhamDisplayViewModel> viewModels = nhomSanPhamBusiness.DisplayAll();
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamBanChay()
        {
            List<SanPhamDisplayViewModel> viewModels = sanPhamBusiness.DisplaySanPhamBanChay();
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamMoi()
        {
            List<SanPhamDisplayViewModel> viewModels = sanPhamBusiness.DisplaySanPhamMoi();
            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSanPhamByNhomSanPham(int nspId, int pageIndex, OrderBy order)
        {
            List<SanPhamDisplayViewModel> viewModels = sanPhamBusiness.DisplaySanPhamByNhomSanPham(nspId);
            switch (order)
            {
                case OrderBy.NameAsc:
                    viewModels = viewModels.OrderBy(v => v.TenSanPham).ToList();
                    break;
                case OrderBy.NameDesc:
                    viewModels = viewModels.OrderByDescending(v => v.TenSanPham).ToList();
                    break;
                case OrderBy.PriceAsc:
                    viewModels = viewModels.OrderBy(v => v.DonGia).ToList();
                    break;
                case OrderBy.PriceDesc:
                    viewModels = viewModels.OrderByDescending(v => v.DonGia).ToList();
                    break;
            }
            PageHelper page = new PageHelper(viewModels, pageIndex, 6);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SearchSanPham(string search, int pageIndex, OrderBy order)
        {
            List<SanPhamDisplayViewModel> viewModels = sanPhamBusiness.SearchSanPham(search);
            switch (order)
            {
                case OrderBy.NameAsc:
                    viewModels = viewModels.OrderBy(v => v.TenSanPham).ToList();
                    break;
                case OrderBy.NameDesc:
                    viewModels = viewModels.OrderByDescending(v => v.TenSanPham).ToList();
                    break;
                case OrderBy.PriceAsc:
                    viewModels = viewModels.OrderBy(v => v.DonGia).ToList();
                    break;
                case OrderBy.PriceDesc:
                    viewModels = viewModels.OrderByDescending(v => v.DonGia).ToList();
                    break;
            }
            PageHelper page = new PageHelper(viewModels, pageIndex, 6);
            return Json(page, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSoLuongTrongGio()
        {
            List<GioHangItemViewModel> viewModels = CartCookieHelper.Deserialize(Request);
            return Json(viewModels.Sum(v => v.SoLuong), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ThemVaoGioHang(GioHangItemViewModel viewModel)
        {
            List<GioHangItemViewModel> viewModels = CartCookieHelper.Deserialize(Request);
            ResultHandle result = new ResultHandle();
            if (viewModels.Exists(v => v.SanPhamID == viewModel.SanPhamID))
            {
                result.Number = CommonCode.DataExisted;
                result.Message = "Sản phẩm đã tồn tại trong giỏ hàng";
            }
            else
            {
                viewModels.Add(viewModel);
                CartCookieHelper.Serialize(Response, Request, viewModels);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CapNhatGioHang(List<GioHangItemViewModel> viewModels)
        {
            CartCookieHelper.Serialize(Response, Request, viewModels);
            return Json(new ResultHandle(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DatHang(DonHangViewModel viewModel)
        {
            ResultHandle result = donHangBusiness.Insert(viewModel);
            if (!result.HasError)
            {
                //clear giỏ hàng trong cookie
                CartCookieHelper.Serialize(Response, Request, null);

                //set đặt hàng thành công để redirect đến trang thanks
                Session[SessionName.Checkout] = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}