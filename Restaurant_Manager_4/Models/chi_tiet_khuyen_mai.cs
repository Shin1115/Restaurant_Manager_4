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
    
    public partial class chi_tiet_khuyen_mai
    {
        public int id { get; set; }
        public Nullable<int> id_khuyen_mai { get; set; }
        public Nullable<int> id_mon_an { get; set; }
        public Nullable<int> phan_tram_giam { get; set; }
    
        public virtual khuyen_mai khuyen_mai { get; set; }
        public virtual mon_an mon_an { get; set; }
    }
}
