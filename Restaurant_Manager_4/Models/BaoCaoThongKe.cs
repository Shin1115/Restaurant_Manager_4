using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Models
{
    public class BaoCaoThongKe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime NgayXuat { get; set; }
        public string EmployeeName { get; set; }
    }
}