using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Manager_4.Models;
namespace Restaurant_Manager_4.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        QuanLyNhaHangDataContext db = new QuanLyNhaHangDataContext();
        private string strCart = "Cart";
        public ActionResult Index()
        {
            return View();
        }
    }
}