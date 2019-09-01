using Ecommerce.DataLayer.Context;
using System.Linq;

namespace Ecommerce.DataLayer.DAO
{
    public class TaiKhoanDAO
    {
        public TaiKhoan KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                TaiKhoan entity = db.TaiKhoan.Include("NhanVien")
                    .FirstOrDefault(t => t.TenDangNhap == tenDangNhap && t.MatKhau == matKhau);
                return entity;
            }
        }
    }
}
