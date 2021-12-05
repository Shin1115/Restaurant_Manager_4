using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Requests
{
    public class BanRequest
    {
        [DisplayName("Tên bàn")]
        [Required(ErrorMessage ="Phải có tên")]
        public string ten_ban { get; set; }

        [Required(ErrorMessage ="Phải có chỗ ngồi tối đa")]
        [Range(1, 10, ErrorMessage ="Chỗi ngồi tối đa nằm trong khoảng từ 1-10")]
        [DisplayName("Chỗ ngồi tối đa")]
        public int cho_ngoi_toi_da { get; set; }

        [Required(ErrorMessage = "Bạn chưa chọn trạng thái bàn")]
        [DisplayName("Trạng thái bàn")]
        public int trang_thai { get; set; }

        [Required(ErrorMessage ="Phải có đặt cọc tối thiểu")]
        [DisplayName("Đặt cọc tối thiểu")]
        public int dat_coc_toi_thieu { get; set; }

        [DisplayName("Tải ảnh lên")]
        public string hinh_anh { get; set; }

        [Required(ErrorMessage = "Phải kèm theo một ảnh")]
        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }

        [DisplayName("Mô tả")]
        public string mo_ta { get; set; }
    }
}