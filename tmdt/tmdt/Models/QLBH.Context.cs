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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLBH123Entities : DbContext
    {
        public QLBH123Entities()
            : base("name=QLBH123Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cauhinh> cauhinhs { get; set; }
        public virtual DbSet<chitietdh> chitietdhs { get; set; }
        public virtual DbSet<chuyenmuc> chuyenmucs { get; set; }
        public virtual DbSet<donhang> donhangs { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<loaisp> loaisps { get; set; }
        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<sp> sps { get; set; }
        public virtual DbSet<tintuc> tintucs { get; set; }
    }
}
