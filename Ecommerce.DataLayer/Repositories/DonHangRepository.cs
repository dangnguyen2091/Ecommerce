using Ecommerce.DataLayer.Context;
using Ecommerce.DataLayer.IRepositories;
using System.Data.Entity;
using System.Linq;

namespace Ecommerce.DataLayer.Repositories
{
    public class DonHangRepository : Repository<DonHang>, IDonHangRepository
    {
        public DonHangRepository(DbContext context) : base(context)
        {
        }

        public int MaxID()
        {
            int max = dbSet.Count() == 0 ? 0 : dbSet.Max(d => d.ID);
            return max;
        }
    }
}
