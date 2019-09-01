using Ecommerce.Common.Struct;
using Ecommerce.Common.Utilities;
using Ecommerce.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataLayer.DAO
{
    public class DonHangDAO
    {
        public ResultHandle Insert(DonHang entity)
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                int max = db.DonHang.Count() == 0 ? 0: db.DonHang.Max(d => d.ID);
                entity.MaDonHang = $"DH{max + 1}";
                db.DonHang.Add(entity);
                ResultHandle result = db.Save();
                return result;
            }
        }
    }
}
