using Ecommerce.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Helpers
{
    public class CartCookieHelper
    {
        public static string Serialize(HttpResponseBase response, HttpRequestBase request, List<GioHangItemViewModel> viewModels)
        {
            viewModels = viewModels ?? new List<GioHangItemViewModel>();
            string encode = HttpUtility.UrlEncode(JsonConvert.SerializeObject(viewModels));
            HttpCookie cookie = request.Cookies[SessionName.Cart];
            cookie = cookie ?? new HttpCookie(SessionName.Cart);
            cookie.Value = encode;
            response.Cookies.Add(cookie);
            return encode;
        }

        public static List<GioHangItemViewModel> Deserialize(HttpRequestBase request)
        {
            HttpCookie cookie = request.Cookies[SessionName.Cart];
            List<GioHangItemViewModel> viewModels = new List<GioHangItemViewModel>();
            if (cookie == null)
            {
                cookie = new HttpCookie(SessionName.Cart);
            }
            else
            {
                try
                {
                    //phòng trường hợp cookie bị chỉnh sửa bởi client
                    string decode = HttpUtility.UrlDecode(cookie.Value);
                    viewModels = JsonConvert.DeserializeObject<List<GioHangItemViewModel>>(decode);
                }
                catch (Exception ex) { }
            }
            return viewModels;
        }
    }
}