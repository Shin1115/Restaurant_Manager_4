﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant_Manager_4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class quan_ly_nha_hangEntities : DbContext
    {
        public quan_ly_nha_hangEntities()
            : base("name=quan_ly_nha_hangEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ban> bans { get; set; }
        public virtual DbSet<chi_tiet_danh_muc> chi_tiet_danh_muc { get; set; }
        public virtual DbSet<chi_tiet_dat_ban> chi_tiet_dat_ban { get; set; }
        public virtual DbSet<chi_tiet_dat_hang> chi_tiet_dat_hang { get; set; }
        public virtual DbSet<chi_tiet_hoa_don> chi_tiet_hoa_don { get; set; }
        public virtual DbSet<chi_tiet_khuyen_mai> chi_tiet_khuyen_mai { get; set; }
        public virtual DbSet<danh_gia_khach_hang> danh_gia_khach_hang { get; set; }
        public virtual DbSet<danh_muc_mon_an> danh_muc_mon_an { get; set; }
        public virtual DbSet<dat_ban> dat_ban { get; set; }
        public virtual DbSet<dat_ban_mon_an> dat_ban_mon_an { get; set; }
        public virtual DbSet<dat_hang> dat_hang { get; set; }
        public virtual DbSet<hoa_don> hoa_don { get; set; }
        public virtual DbSet<khuyen_mai> khuyen_mai { get; set; }
        public virtual DbSet<mon_an> mon_an { get; set; }
        public virtual DbSet<tin_tuc> tin_tuc { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
