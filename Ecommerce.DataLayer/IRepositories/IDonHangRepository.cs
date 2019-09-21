using Ecommerce.DataLayer.Context;

namespace Ecommerce.DataLayer.IRepositories
{
    public interface IDonHangRepository : IRepository<DonHang>
    {
        int MaxID();
    }
}
