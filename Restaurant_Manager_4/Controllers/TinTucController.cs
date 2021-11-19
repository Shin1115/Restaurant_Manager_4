﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Manager_4.Infrastructure;
using Restaurant_Manager_4.Models;

namespace Restaurant_Manager_4.Controllers
{
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
                List<tin_tuc> tinTucList = context.tin_tuc.Include("user").ToList();
                return View(tinTucList);
            }
        }

        // GET: TinTuc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TinTuc/Create
        [CustomAuthorize(Roles = "Admin")]
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
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CustomPrincipal user = (CustomPrincipal)HttpContext.User;
                tin_tuc newTintuc = new tin_tuc()
                {
                    tieu_de = collection["tieu_de"],
                    noi_dung = collection["noi_dung"],
                    id_nguoi_viet = user.UserId
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
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TinTuc/Edit/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
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
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TinTuc/Delete/5
        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
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
