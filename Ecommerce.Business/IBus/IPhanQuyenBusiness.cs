using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.IBus
{
    public interface IPhanQuyenBusiness
    {
        bool KiemTraPhanQuyen(int nhomNguoiDungId, string controller, string action);
        void GetPhanQuyen(int nhomNguoiDungId, string controller, out bool them, out bool sua, out bool xoa);
    }
}
