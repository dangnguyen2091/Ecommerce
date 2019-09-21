using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;

namespace Ecommerce.DataLayer.Repositories
{
    public class NhomSanPhamRepository : Repository<NhomSanPham>, INhomSanPhamRepository
    {
        public NhomSanPhamRepository(DbContext context) : base(context)
        {
        }
    }
}
