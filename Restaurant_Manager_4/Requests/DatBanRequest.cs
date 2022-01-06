using Restaurant_Manager_4.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Requests
{
    public class DatBanRequest
    {
        [DisplayName("Ngày đặt")]
        public DateTime ngay_dat { get; set; }

        [DisplayName("Tiền cọc trước")]
        public int tien_coc_truoc { get; set; }

        [DisplayName("Ngày đến")]
        public DateTime ngay_den { get; set; }

        [DisplayName("Giờ đến")]
        [DataType(DataType.DateTime)]
        public DateTime gio_den { get; set; }

        public List<BanDTO> banDTOs { get; set; }
        public List<MonAnDTO> monAnDTOs { get; set; }

        [DisplayName("Số lượng người")]
        public int so_luong_nguoi { get; set; }
    }
}