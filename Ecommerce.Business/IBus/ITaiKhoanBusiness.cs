using Ecommerce.Common.Struct;
using Ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.IBus
{
    public interface ITaiKhoanBusiness
    {
        ResultHandle KiemTraDangNhap(DangNhapViewModel viewModel);
    }
}
