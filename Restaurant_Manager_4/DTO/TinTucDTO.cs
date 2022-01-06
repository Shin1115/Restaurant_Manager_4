using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.DTO
{
    public class TinTucDTO
    {
        public int Id { get; set; }
        [DisplayName("Ngày viết")]
        public DateTime NgayViet { get; set; }
        [DisplayName("Tiêu đề")]
        public string TieuDe { get; set; }
        [DisplayName("Nội dung")]
        public string NoiDung { get; set; }
        [DisplayName("Tên người viết")]
        public string TenNguoiViet { get; set; }
    }
}