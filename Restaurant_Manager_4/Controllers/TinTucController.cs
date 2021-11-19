using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Manager_4.Infrastructure;
using Restaurant_Manager_4.Models;

namespace Restaurant_Manager_4.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class TinTucController : Controller
    {
        private QuanLyNhaHangDataContext _context;
        public TinTucController()
        {
            _context = new QuanLyNhaHangDataContext();
        }

        // GET: TinTuc
        public ActionResult Index()
        {
            using(var context = new QuanLyNhaHangDataContext())
            {
                List<tin_tuc> tinTucList = context.tin_tuc.ToList();
                return View(tinTucList);
            }
        }

        // GET: TinTuc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TinTuc/Create
        public ActionResult Create()
        {
            using (var context = new QuanLyNhaHangDataContext())
            {
                tin_tuc tin_Tuc = new tin_tuc();
                return View(tin_Tuc);
            }
        }

        // POST: TinTuc/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                tin_tuc newTintuc = new tin_tuc()
                {
                    tieu_de = collection["tieu_de"],
                    noi_dung = collection["noi_dung"]
                };
                newTintuc.ngay_viet = DateTime.Now;
                _context.tin_tuc.Add(newTintuc);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinTuc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TinTuc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinTuc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TinTuc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
