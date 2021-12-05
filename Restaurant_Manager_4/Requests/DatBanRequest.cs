using Restaurant_Manager_4.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Requests
{
    public class DatBanRequest
    {
        public DateTime ngay_dat { get; set; }
        public int tien_coc_truoc { get; set; }
        public int ngay_den { get; set; }
        public List<BanDTO> banDTOs { get; set; }
        public List<MonAnDTO> monAnDTOs { get; set; }
        public int so_luong_nguoi { get; set; }
    }
}