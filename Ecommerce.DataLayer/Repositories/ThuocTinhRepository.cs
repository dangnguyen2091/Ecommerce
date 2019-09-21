using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;

namespace Ecommerce.DataLayer.Repositories
{
    public class ThuocTinhRepository : Repository<ThuocTinh>, IThuocTinhRepository
    {
        public ThuocTinhRepository(DbContext context) : base(context)
        {
        }
    }
}
