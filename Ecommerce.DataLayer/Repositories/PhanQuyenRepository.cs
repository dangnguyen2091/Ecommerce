using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;

namespace Ecommerce.DataLayer.Repositories
{
    public class PhanQuyenRepository : Repository<PhanQuyen>, IPhanQuyenRepository
    {
        public PhanQuyenRepository(DbContext context) : base(context)
        {
        }
    }
}
