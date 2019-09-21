using Ecommerce.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.ViewModel
{
    [EntityCast("PhanQuyen")]
    public class PhanQuyenViewModel : BaseViewModel
    {
        [PropertyCast("ID")]
        public int PhanQuyenID { get; set; }

        [PropertyCast("NhomNguoiDungID")]
        public int NhomNguoiDungID { get; set; }

        [PropertyCast("ChucNangID")]
        public int ChucNangID { get; set; }

        [PropertyCast("Xem")]
        public bool? Xem { get; set; }

        [PropertyCast("Them")]
        public bool? Them { get; set; }

        [PropertyCast("Sua")]
        public bool? Sua { get; set; }

        [PropertyCast("Xoa")]
        public bool? Xoa { get; set; }

        public PhanQuyenViewModel()
        {
            PhanQuyenID = 0;
            NhomNguoiDungID = 0;
            ChucNangID = 0;
            Xem = null;
            Them = null;
            Sua = null;
            Xoa = null;
        }
    }
}
