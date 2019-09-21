using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;

namespace Ecommerce.DataLayer.Repositories
{
    public class HinhThucThanhToanRepository : Repository<HinhThucThanhToan>, IHinhThucThanhToanRepository
    {
        public HinhThucThanhToanRepository(DbContext context) : base(context)
        {
        }
    }
}
