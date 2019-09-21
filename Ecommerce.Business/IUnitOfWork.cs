using Ecommerce.Common.Struct;
using Ecommerce.DataLayer.IRepositories;

namespace Ecommerce.Business
{
    public interface IUnitOfWork
    {
        IDonHangRepository DonHangRepository { get; }
        IHinhThucThanhToanRepository HinhThucThanhToanRepository { get; }
        INhomSanPhamRepository NhomSanPhamRepository { get; }
        IPhanQuyenRepository PhanQuyenRepository { get; }
        ISanPhamRepository SanPhamRepository { get; }
        ITaiKhoanRepository TaiKhoanRepository { get; }
        IThuocTinhRepository ThuocTinhRepository { get; }
        ResultHandle Save();
    }
}
