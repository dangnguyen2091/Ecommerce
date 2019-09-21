using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("HinhThucThanhToan")]
    public class HinhThucThanhToanViewModel : BaseViewModel
    {
        [PropertyCast("ID")]
        public int HinhThucThanhToanID { get; set; }

        [PropertyCast("TenHinhThucThanhToan")]
        public string TenHinhThucThanhToan { get; set; }

        public HinhThucThanhToanViewModel()
        {
            HinhThucThanhToanID = 0;
            TenHinhThucThanhToan = null;
        }
    }
}
