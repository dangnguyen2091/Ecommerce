using Ecommerce.Attributes;
using Ecommerce.Business.BUS;
using Ecommerce.Common.Struct;
using Ecommerce.Helpers;
using Ecommerce.ViewModel;
using System.Web.Mvc;

namespace Ecommerce.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        [AdminAuthorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string url = null)
        {
            if (LoginHelper.KiemTraDangNhapAdmin(Session))
            {
                return RedirectToAction(nameof(Index));
            }
            DangNhapViewModel viewModel = new DangNhapViewModel()
            {
                RequestUrl = url,
            };
            return View(viewModel);
        }

        public ActionResult Logout()
        {
            LoginHelper.DangXuatAdmin(Session);
            return RedirectToAction(nameof(Login));
        }

        public ActionResult AccessDenied()
        {
            return Content("Access denied!");
        }
        
        [HttpPost]
        public ActionResult Login(DangNhapViewModel viewModel)
        {
            TaiKhoanBUS bus = new TaiKhoanBUS();
            ResultHandle result = bus.KiemTraDangNhap(viewModel);
            if (!result.HasError)
            {
                LoginHelper.DangNhapAdmin(Session, (TaiKhoanViewModel)result.Outputs["TaiKhoanDangNhap"]);          
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}