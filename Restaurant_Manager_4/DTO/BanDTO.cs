using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.DTO
{
    public class BanDTO
    {
        public int id { get; set; }
        public string ten_ban { get; set; }
        public int cho_ngoi_toi_da { get; set; }
        public string trang_thai { get; set; }
        public int dat_coc_toi_thieu { get; set; }
        public string hinh_anh { get; set; }
        public string mo_ta { get; set; }
    }
}