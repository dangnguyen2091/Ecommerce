using Ecommerce.Common.Struct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ecommerce.Common.Utilities
{
    public class ImageHelper
    {
        public enum Prefix { SanPham = 1, }

        private static string GetPrefix(Prefix prefix)
        {
            if (prefix == Prefix.SanPham) return "SP";
            return "";
        }

        private static string GenerateFileName(Prefix prefix, string fileName, string extension)
        {
            return $"{GetPrefix(prefix)}_{fileName}.{extension}";
        }

        public static ResultHandle SaveImage(HttpPostedFileBase filePosted, Prefix prefix, string fileName)
        {
            ResultHandle result = new ResultHandle();
            try
            {
                string name = null;
                if (filePosted != null)
                {
                    string extension = filePosted.FileName.Substring(filePosted.FileName.LastIndexOf('.') + 1);
                    name = GenerateFileName(prefix, fileName, extension);
                    filePosted.SaveAs(Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images"), name));
                }
                result.Outputs.Add("HinhAnh", name);
            }
            catch (Exception)
            {
                result = ResultHandle.UploadFailed();
            }
            return result;
        }

        public static string GetImageUrl(string fileName)
        {
            string url = string.Empty;
            if (!string.IsNullOrEmpty(fileName))
            {
                url = $"/Content/images/{fileName}";
            }
            return url;
        }
    }
}