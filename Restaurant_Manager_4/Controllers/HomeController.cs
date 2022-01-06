using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Restaurant_Manager_4.Models;

namespace Restaurant_Manager_4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                List<mon_an> monAns = context.mon_an.ToList();
                return View(monAns);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Product_Detail()
        {
            return View();
        }
    }
}