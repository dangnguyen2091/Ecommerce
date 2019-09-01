using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Helpers
{
    public class LoginHelper
    {
        public static void DangNhapAdmin(HttpSessionStateBase session, TaiKhoanViewModel taiKhoanViewModel)
        {
            session[SessionName.UserAdmin] = taiKhoanViewModel;
        }

        public static void DangXuatAdmin(HttpSessionStateBase session)
        {
            session[SessionName.UserAdmin] = null;
        }

        public static bool KiemTraDangNhapAdmin(HttpSessionStateBase session) => session[SessionName.UserAdmin] != null;
    }
}