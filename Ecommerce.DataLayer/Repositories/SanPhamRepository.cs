using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;

namespace Ecommerce.DataLayer.Repositories
{
    public class SanPhamRepository : Repository<SanPham>, ISanPhamRepository
    {
        public SanPhamRepository(DbContext context) : base(context)
        {
        }
    }
}
