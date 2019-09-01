using Ecommerce.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataLayer.DAO
{
    public class PhanQuyenDAO
    {
        public PhanQuyen GetPhanQuyen(int nhomNguoiDungId, string maChucNang)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                PhanQuyen entity = db.PhanQuyen.Include("ChucNang").FirstOrDefault(p =>
                    p.NhomNguoiDungID == nhomNguoiDungId && p.ChucNang.MaChucNang == maChucNang);
                return entity;
            }
        }
    }
}
