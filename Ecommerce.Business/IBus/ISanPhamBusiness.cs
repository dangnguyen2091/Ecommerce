using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.IBus
{
    public interface ISanPhamBusiness : IBusiness<SanPhamViewModel, SanPhamDisplayViewModel>
    {
        List<ThuocTinhViewModel> GetThuocTinh(int nspId);
        List<SanPhamDisplayViewModel> DisplaySanPhamBanChay();
        List<SanPhamDisplayViewModel> DisplaySanPhamMoi();
        List<SanPhamDisplayViewModel> DisplaySanPhamByNhomSanPham(int nspId);
        SanPhamDisplayViewModel DisplaySanPham(int id);
        List<SanPhamDisplayViewModel> SearchSanPham(string search);
    }
}
