using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Restaurant_Manager_4.Models;
using System.Linq;

namespace Restaurant_Manager_4.Controllers
{
    public class DanhMucMonAnController : Controller
    {
        // GET: DanhMucMonAn
        public ActionResult Index()
        {
            using (var context = new QuanLyNhaHangDataContext())
            {
                List<danh_muc_mon_an> DanhMucMonAnList = context.danh_muc_mon_an.ToList();
                return View(DanhMucMonAnList);
            }
        }

        /// <summary>
        /// Hiển thị chi tiết của một món ăn có trong danh mục.
        /// </summary>
        /// <param name="TenMonAn"></param>
        /// <returns></returns>
        [ActionName("ChiTiet")]
        public ActionResult Detail(string TenMonAn)
        {
            var input = Server.HtmlDecode(TenMonAn);
            return Content(input);
        }

        [NonAction]
        public string DoSomethingRelativeController()
        {
            return "Làm gì đó liên quan đến nghiệp vụ controller";
        }
    }
}