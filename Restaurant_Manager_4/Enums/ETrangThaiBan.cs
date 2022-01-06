using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Enums
{
    public enum ETrangThaiBan
    {
        [Description("Còn trống")]
        ConTrong,
        [Description("Đang sử dụng")]
        DangSuDung,
        [Description("Tạm ẩn")]
        TamAn
    }
}