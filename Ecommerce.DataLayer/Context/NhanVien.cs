//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ecommerce.DataLayer.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        public int ID { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int NhomNguoiDungID { get; set; }
    
        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
