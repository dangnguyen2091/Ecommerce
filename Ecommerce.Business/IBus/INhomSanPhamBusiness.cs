using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.IBus
{
    public interface INhomSanPhamBusiness : IBusiness<NhomSanPhamViewModel, NhomSanPhamDisplayViewModel>
    {
        List<ThuocTinhViewModel> GetThuocTinhByNhomSanPhamID(int id);
        void GetNhomSanPhamTree(int id, ref List<NhomSanPhamDisplayViewModel> viewModels);
        void GetNhomSanPhamTreeDown(int id, ref List<NhomSanPhamDisplayViewModel> viewModels);
    }
}
