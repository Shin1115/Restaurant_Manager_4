using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.IO;
using Restaurant_Manager_4.Models;
using System.Net;

namespace Restaurant_Manager_4.Controllers
{
    public class MonAnController : Controller
    {
        // GET: MonAn
        QuanLyNhaHangDataContext db = new QuanLyNhaHangDataContext();
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;
            List<mon_an> lstdatban = db.mon_an.ToList();
            var monanlst = db.mon_an.OrderByDescending(x => x.id).ToList().ToPagedList(pageNumber, pageSize);
            return View(monanlst);
        }

        // GET: MonAn/Details/5
        public ActionResult Details(int id)
        {
            mon_an monan = db.mon_an.Find(id);
            return View(monan);
        }

        // GET: MonAn/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MonAn/Create
        [HttpPost]
        public ActionResult Create(mon_an monan, HttpPostedFileBase uploadhinh)
        {
            db.mon_an.Add(monan);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int _id = int.Parse(db.mon_an.ToList().Last().id.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "ma" + _id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/upload/image_Food/"), _FileName);
                uploadhinh.SaveAs(_path);

                mon_an man = db.mon_an.FirstOrDefault(x => x.id == _id);
                man.hinh_anh = _FileName;
                db.SaveChanges();
            }            
            return RedirectToAction("Index");
        }

        // GET: MonAn/Edit/5
        public ActionResult Edit(int id)
        {
            mon_an monan = db.mon_an.FirstOrDefault(x => x.id == id);
            return View(monan);
        }

        // POST: MonAn/Edit/5
        [HttpPost]
        public ActionResult Edit(mon_an monan, HttpPostedFileBase uploadhinh)
        {
            mon_an editma = db.mon_an.FirstOrDefault(x => x.id == monan.id);
            editma.ten_mon_an = monan.ten_mon_an;
            editma.gia = monan.gia;
            editma.ngay_them = monan.ngay_them;
            editma.ngay_sua = monan.ngay_sua;
            editma.trang_thai = monan.trang_thai;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int _id = monan.id;

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "ma" + _id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/upload/image_Food/"), _FileName);
                uploadhinh.SaveAs(_path);
                editma.hinh_anh = _FileName;

            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: MonAn/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mon_an monan = db.mon_an.Find(id);
            if (monan == null)
            {
                return HttpNotFound();
            }
            return View(monan);
        }

        // POST: MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mon_an monan = db.mon_an.Find(id);
            db.mon_an.Remove(monan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
