using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Requests
{
    public class PhanMucRequest
    {
        public int Id { get; set; }
        public List<int> BanIds { get; set; }
        public List<int> MonAnIds { get; set; }
    }
}