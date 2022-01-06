using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Restaurant_Manager_4.Models
{
    public class Cart
    {
        public mon_an Monan { get; set; }
        public int Soluong { get; set; }

        public Cart(mon_an monan, int soluong)
        {
            Monan = monan;
            Soluong = soluong;
        }
    }
}