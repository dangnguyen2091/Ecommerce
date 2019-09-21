using Ecommerce.Attributes;
using Ecommerce.Business.BUS;
using Ecommerce.Business.IBus;
using Ecommerce.Common.Struct;
using Ecommerce.Helpers;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Base
{
    [AdminAuthorize]
    public class AdminController : Controller
    {
        private readonly IPhanQuyenBusiness phanQuyenBusiness;

        public AdminController(IPhanQuyenBusiness phanQuyenBusiness)
        {
            this.phanQuyenBusiness = phanQuyenBusiness;
        }

        public virtual ActionResult Index()
        {
            string controller = ControllerContext.RouteData.Values["controller"].ToString();
            TaiKhoanViewModel taiKhoan = Session[SessionName.UserAdmin] as TaiKhoanViewModel;
            phanQuyenBusiness.GetPhanQuyen(taiKhoan.NhomNguoiDungID, controller, out bool them, out bool sua, out bool xoa);
            CRUD crud = new CRUD()
            {
                Controller = controller,
                CanCreate = them,
                CanUpdate = sua,
                CanDelete = xoa,
            };
            ViewBag.CRUD = crud;
            return View();
        }
    }
}