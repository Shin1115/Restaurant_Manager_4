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
        public int SoLuongNguoi { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayToi { get; set; }
        public int TienCocTruoc { get; set; }
        public List<PhanMucRequest> DanhSachPhanMuc { get; set; }
    }
}