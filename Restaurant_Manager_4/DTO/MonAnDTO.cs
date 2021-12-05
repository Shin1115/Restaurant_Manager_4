using Restaurant_Manager_4.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.DTO
{
    public class MonAnDTO
    {
        public string ten_mon_an { get; set; }
        public int gia { get; set; }
        public DateTime ngay_them { get; set; }
        public DateTime ngay_sua { get; set; }
        public ETrangThaiMonAn trang_thai { get; set; }
        public string hinh_anh { get; set; }
    }
}