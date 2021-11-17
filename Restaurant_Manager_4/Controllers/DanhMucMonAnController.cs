using System;
using System.Web.Mvc;

namespace Restaurant_Manager_4.Controllers
{
    public class DanhMucMonAnController : Controller
    {
        // GET: DanhMucMonAn
        public string Index()
        {
            return "Danh Muc Mon An";
        }

        /// <summary>
        /// Hiển thị danh sách các món ăn có trong danh mục.
        /// </summary>
        /// <returns></returns>
        [ActionName("DanhSach")]
        public ActionResult List()
        {
            return View();
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