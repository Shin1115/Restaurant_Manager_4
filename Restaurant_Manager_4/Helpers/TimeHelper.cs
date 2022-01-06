using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Helpers
{
    public class TimeHelper
    {
        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}