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
    
    public partial class ban
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ban()
        {
            this.chi_tiet_dat_ban = new HashSet<chi_tiet_dat_ban>();
        }
    
        public int id { get; set; }
        public string ten_ban { get; set; }
        public Nullable<int> cho_ngoi_toi_da { get; set; }
        public Nullable<int> trang_thai { get; set; }
        public Nullable<int> dat_coc_toi_thieu { get; set; }
        public string hinh_anh { get; set; }
        public string mo_ta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chi_tiet_dat_ban> chi_tiet_dat_ban { get; set; }
    }
}