using Ecommerce.Business.BUS;
using Ecommerce.Helpers;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ecommerce.Attributes
{
    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var route = httpContext.Request.RequestContext.RouteData;
            string area = route.DataTokens["area"] as string;
            if (area != "Administrator")
            {
                throw new Exception($"Cannot use this attribute for {area} area");
            }
            //Kiểm tra đăng nhập
            if (!LoginHelper.KiemTraDangNhapAdmin(httpContext.Session))
            {
                httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                return false;
            }
            //Kiểm tra phân quyền
            string action = route.GetRequiredString("action");
            string controller = route.GetRequiredString("controller");
            TaiKhoanViewModel taiKhoan = (TaiKhoanViewModel)httpContext.Session[SessionName.UserAdmin];
            PhanQuyenBUS phanQuyenBUS = new PhanQuyenBUS();
            if (!phanQuyenBUS.KiemTraPhanQuyen(taiKhoan.NhomNguoiDungID, controller, action))
            {
                httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return false;
            }
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //var o = filterContext.HttpContext.Session["AdminUser"];
            //string area = filterContext.RouteData.DataTokens["area"].ToString();
            int statusCode = filterContext.HttpContext.Response.StatusCode;
            if (statusCode == (int)System.Net.HttpStatusCode.Unauthorized)
            {
                string requestUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    area = "Administrator",
                    controller = "Home",
                    action = "Login",
                    url = requestUrl,
                }));
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    area = "Administrator",
                    controller = "Home",
                    action = "AccessDenied",
                }));
            }
        }
    }
}