using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.DTO
{
    public class BanDTO
    {
        public int id { get; set; }
        [DisplayName("Tên bàn")]
        public string ten_ban { get; set; }

        [DisplayName("Chỗ ngồi tối đa")]
        public int cho_ngoi_toi_da { get; set; }

        [DisplayName("Trạng thái")]
        public string trang_thai { get; set; }

        [DisplayName("Đặt cọc tối thiểu")]
        public string dat_coc_toi_thieu { get; set; }

        [DisplayName("Hình ảnh")]
        public string hinh_anh { get; set; }

        [DisplayName("Mô tả")]
        public string mo_ta { get; set; }
    }
}