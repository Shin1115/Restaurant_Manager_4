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

        public String List()
        {
            return @"<ul>
              <li>Ali Raza</li>
              <li>Mark Upston</li>
              <li>Allan Bommer</li>
              <li>Greg Jerry</li>
           </ul>";
        }

        public ActionResult Detail(string TenMonAn)
        {
            var input = Server.HtmlDecode(TenMonAn);
            return Content(input);
        }
    }
}