using Ecommerce.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataLayer.DAO
{
    public class ThuocTinhDAO
    {
        public List<ThuocTinh> GetThuocTinhByNhomSanPhamID(int id)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                List<ThuocTinh> entities = db.ThuocTinh.Where(e => e.NhomSanPhamID == id).ToList();
                return entities;
            }
        }
    }
}
