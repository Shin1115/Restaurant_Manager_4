﻿using System;
using System.Web.Mvc;

namespace Restaurant_Manager_4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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


        [OutputCache(Duration = 15)]
        public string GetTime()
        {
            return DateTime.Now.ToString("T");
        }
    }
}