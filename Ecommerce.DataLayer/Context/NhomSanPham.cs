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
    
    public partial class NhomSanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhomSanPham()
        {
            this.NhomSanPham1 = new HashSet<NhomSanPham>();
            this.ThuocTinhs = new HashSet<ThuocTinh>();
            this.SanPhams = new HashSet<SanPham>();
        }
    
        public int ID { get; set; }
        public string MaNhomSanPham { get; set; }
        public string TenNhomSanPham { get; set; }
        public Nullable<int> NhomSanPhamChaID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomSanPham> NhomSanPham1 { get; set; }
        public virtual NhomSanPham NhomSanPham2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuocTinh> ThuocTinhs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
