//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace tmdt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class sp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sp()
        {
            this.chitietdhs = new HashSet<chitietdh>();
        }
    
        public int ma { get; set; }
        public string ten { get; set; }
        public string mota { get; set; }
        public int maloai { get; set; }
        public string anhnho { get; set; }
        public string anh1 { get; set; }
        public string anh2 { get; set; }
        public string anh3 { get; set; }
        public string tskt { get; set; }
        public Nullable<bool> tieubieu { get; set; }
        public Nullable<bool> trangthai { get; set; }
        public Nullable<bool> xoa { get; set; }
        public string hang { get; set; }
        public Nullable<decimal> gia { get; set; }
        public Nullable<int> khuyenmai { get; set; }
        public Nullable<System.DateTime> ngaydang { get; set; }
        public string dvt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitietdh> chitietdhs { get; set; }
        public virtual loaisp loaisp { get; set; }
    }
}
