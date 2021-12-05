using AutoMapper;
using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.Models;
using Restaurant_Manager_4.Requests;
using Restaurant_Manager_4.SerializableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurant_Manager_4.Controllers
{
    public class DatBanController : Controller
    {
        public DatBanController()
        {
        }

        // GET: DatBan
        public ActionResult Index()
        {
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                Mapper mapper = new Mapper(ModelMappers.ModelMappers.BAN_TO_BANDTO);
                //CustomPrincipal customPrincipal = (CustomPrincipal)HttpContext.User;
                List<ban> bans = context.bans.Where(ban => ban.trang_thai == 0).ToList();
                List<BanDTO> banDTOs = bans.Select(ban => mapper.Map<BanDTO>(ban)).ToList<BanDTO>();
                return View(banDTOs);
            }
        }

        public ActionResult ChonMonAn(string idBan)
        {
            DatMonAnSessionData datMonAnSessionData = Session["DatMonAnSession"] as DatMonAnSessionData;


            if (idBan != null)
            {
                if (datMonAnSessionData == null)
                {
                    datMonAnSessionData = new DatMonAnSessionData();
                    Session["DatMonAnSession"] = datMonAnSessionData;
                }
                datMonAnSessionData = Session["DatMonAnSession"] as DatMonAnSessionData;
                if (int.TryParse(idBan, out int nIdBan))
                {
                    if (!datMonAnSessionData.Bans.Contains(nIdBan))
                    {
                        datMonAnSessionData.Bans.Add(nIdBan);
                        Session["DatMonAnSession"] = datMonAnSessionData;
                    }
                }
            }

            if (datMonAnSessionData == null)
            {
                ViewBag.banDTOs = new List<BanDTO>();
                ViewBag.monAnDTOs = new List<MonAnDTO>();
                return View();
            }

            datMonAnSessionData = this.Session["DatMonAnSession"] as DatMonAnSessionData;
            List<int> nIdBans = datMonAnSessionData.Bans;
            List<int> nIdMonAns = datMonAnSessionData.MonAns;


            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                Mapper mapperBanToBanDTO = new Mapper(ModelMappers.ModelMappers.BAN_TO_BANDTO);

                List<BanDTO> banDTOs = new List<BanDTO>();
                foreach (int banId in nIdBans)
                {
                    ban ban = context.bans.Where(b => b.id == banId).FirstOrDefault();
                    BanDTO banDTO = mapperBanToBanDTO.Map<BanDTO>(ban);
                    banDTOs.Add(banDTO);
                }

                List<MonAnDTO> monAnDTOs = new List<MonAnDTO>();
                foreach (int monAnId in nIdMonAns)
                {
                    mon_an monAn = context.mon_an.Where(ma => ma.id == monAnId).FirstOrDefault();
                    MonAnDTO monAnDTO = mapperBanToBanDTO.Map<MonAnDTO>(monAn);
                    monAnDTOs.Add(monAnDTO);
                }

                ViewBag.banDTOs = banDTOs;
                ViewBag.monAnDTOs = monAnDTOs;
                int tien_coc_truoc = 0;
                foreach (ban ban in context.bans.Where(ban => nIdBans.Contains(ban.id)).ToList())
                {
                    tien_coc_truoc += (int)ban.dat_coc_toi_thieu;
                }

                DatBanRequest datBanRequest = new DatBanRequest
                {
                    ngay_dat = DateTime.Now,
                    so_luong_nguoi = 0,
                    tien_coc_truoc = tien_coc_truoc
                };
                return View(datBanRequest);
            }
        }

        // GET: DatBan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DatBan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatBan/Create
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

        // GET: DatBan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DatBan/Edit/5
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

        // GET: DatBan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatBan/Delete/5
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
