using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Enums
{
    public enum ETrangThaiMonAn
    {
        [Description("Hết hàng")]
        HetHang,
        [Description("Còn hàng")]
        ConHang
    }
}