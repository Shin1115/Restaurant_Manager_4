//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class chi_tiet_dat_hang
    {
        public int id { get; set; }
        public Nullable<int> id_mon_an { get; set; }
        public Nullable<int> id_dat_hang { get; set; }
        public Nullable<int> so_luong { get; set; }
    
        public virtual dat_hang dat_hang { get; set; }
        public virtual mon_an mon_an { get; set; }
    }
}