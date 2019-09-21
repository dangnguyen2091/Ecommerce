using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;

namespace Ecommerce.DataLayer.Repositories
{
    public class TaiKhoanRepository : Repository<TaiKhoan>, ITaiKhoanRepository
    {
        public TaiKhoanRepository(DbContext context) : base(context)
        {
        }
    }
}
