using Restaurant_Manager_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Manager_4.Controllers
{
    public class BaoCaoController : Controller
    {
        public static List<BaoCaoThongKe> BaoCaoThongKes = new List<BaoCaoThongKe>()
            {
                new BaoCaoThongKe
                {
                    Id = 1,
                    EmployeeName = "Xin",
                    Name = "ThongKe Thang 10",
                    NgayXuat = DateTime.Parse(DateTime.Today.ToString())
                },
                new BaoCaoThongKe
                {
                    Id = 2,
                    EmployeeName = "Huy",
                    Name = "ThongKe Thang 11",
                    NgayXuat = DateTime.Parse(DateTime.Today.ToString())
                },
                new BaoCaoThongKe
                {
                    Id = 3,
                    EmployeeName = "Duyen",
                    Name = "ThongKe Thang 12",
                    NgayXuat = DateTime.Parse(DateTime.Today.ToString())
                },
            };

        // GET: BaoCao
        public ActionResult Index()
        {
            var baocaothongkes = from bctk in BaoCaoThongKes
                                 orderby bctk.Id
                                 select bctk;
            return View(baocaothongkes);
        }

        // GET: BaoCao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BaoCao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaoCao/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BaoCao/Edit/5
        public ActionResult Edit(int id)
        {
            List<BaoCaoThongKe> baoCaoThongKes = GetHoaDonList();
            BaoCaoThongKe baoCaoThongKe = baoCaoThongKes.Single(bctk => bctk.Id == id);
            return View(baoCaoThongKe);
        }

        // POST: BaoCao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                BaoCaoThongKe baocaothongke = BaoCaoThongKes.Single(m => m.Id == id);
                if (TryUpdateModel(baocaothongke))
                {
                    //To Do:- database code
                    return RedirectToAction("Index");
                }
                return View(baocaothongke);
            }
            catch
            {
                return View();
            }
        }

        // GET: BaoCao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BaoCao/Delete/5
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

        [NonAction]
        public List<BaoCaoThongKe> GetHoaDonList()
        {
            return new List<BaoCaoThongKe>()
            {
                new BaoCaoThongKe
                {
                    Id = 1,
                    EmployeeName = "Xin",
                    Name = "ThongKe Thang 10",
                    NgayXuat = DateTime.Parse(DateTime.Today.ToString())
                },
                new BaoCaoThongKe
                {
                    Id = 2,
                    EmployeeName = "Huy",
                    Name = "ThongKe Thang 11",
                    NgayXuat = DateTime.Parse(DateTime.Today.ToString())
                },
                new BaoCaoThongKe
                {
                    Id = 3,
                    EmployeeName = "Duyen",
                    Name = "ThongKe Thang 12",
                    NgayXuat = DateTime.Parse(DateTime.Today.ToString())
                },
            };
        }
    }
}
