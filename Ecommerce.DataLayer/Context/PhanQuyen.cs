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
    
    public partial class PhanQuyen
    {
        public int ID { get; set; }
        public int NhomNguoiDungID { get; set; }
        public int ChucNangID { get; set; }
        public Nullable<bool> Xem { get; set; }
        public Nullable<bool> Them { get; set; }
        public Nullable<bool> Sua { get; set; }
        public Nullable<bool> Xoa { get; set; }
    
        public virtual ChucNang ChucNang { get; set; }
        public virtual NhomNguoiDung NhomNguoiDung { get; set; }
    }
}