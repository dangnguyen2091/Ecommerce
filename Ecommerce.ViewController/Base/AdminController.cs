using Ecommerce.Attributes;
using Ecommerce.Business.BUS;
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
        public virtual ActionResult Index()
        {
            string controller = ControllerContext.RouteData.Values["controller"].ToString();
            TaiKhoanViewModel taiKhoan = Session[SessionName.UserAdmin] as TaiKhoanViewModel;
            PhanQuyenBUS bus = new PhanQuyenBUS();
            bus.GetPhanQuyen(taiKhoan.NhomNguoiDungID, controller, out bool them, out bool sua, out bool xoa);
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