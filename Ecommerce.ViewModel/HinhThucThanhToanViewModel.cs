using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    public class HinhThucThanhToanViewModel
    {
        public int HinhThucThanhToanID { get; set; }
        public string TenHinhThucThanhToan { get; set; }

        public HinhThucThanhToanViewModel()
        {
            HinhThucThanhToanID = 0;
            TenHinhThucThanhToan = null;
        }
    }
}
