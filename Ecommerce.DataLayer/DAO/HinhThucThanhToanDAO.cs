using Ecommerce.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataLayer.DAO
{
    public class HinhThucThanhToanDAO
    {
        public List<HinhThucThanhToan> GetAll()
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                List<HinhThucThanhToan> list = new List<HinhThucThanhToan>();
                list = db.HinhThucThanhToan.ToList();
                return list;
            }
        }
    }
}
