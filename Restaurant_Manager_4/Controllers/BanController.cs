using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Restaurant_Manager_4.Infrastructure;
using Restaurant_Manager_4.Models;
using Restaurant_Manager_4.Enums;
using Restaurant_Manager_4.Helpers;
using AutoMapper;
using Restaurant_Manager_4.DTO;

namespace Restaurant_Manager_4.Controllers
{
    public class BanController : Controller
    {
        private MapperConfiguration _mapperConfiguration;

        public BanController()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
                cfg.CreateMap<ban, BanDTO>()
                .ForMember(
                    dest => dest.trang_thai, 
                    act => act.MapFrom(
                        src => ((ETrangThaiBan)src.trang_thai).GetEnumDescription()))
                        );
        }

        // GET: Ban
        public ActionResult Index()
        {
            using (QuanLyNhaHangDataContext quanLyNhaHangDataContext = new QuanLyNhaHangDataContext())
            {
                var mapper = new Mapper(_mapperConfiguration);
                List<ban> bans = quanLyNhaHangDataContext.bans.ToList();
                List<BanDTO> banResponses = bans
                    .Select(ban => mapper.Map<BanDTO>(ban)).ToList();
                return View(banResponses);
            }
        }

        // GET: Ban/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ban/Create
        public ActionResult Create()
        {
            var descriptorsAsValue = Selectlists.EnumSelectlist<ETrangThaiBan>();
            ViewData["TrangThaiBan"] = descriptorsAsValue;
            return View();
        }

        // POST: Ban/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                CustomPrincipal user = (CustomPrincipal)HttpContext.User;
                using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
                {
                    ban ban = new ban()
                    {
                        ten_ban = collection["ten_ban"],
                        cho_ngoi_toi_da = int.Parse(collection["cho_ngoi_toi_da"]),
                        mo_ta = collection["mo_ta"],
                        dat_coc_toi_thieu = int.Parse(collection["dat_coc_toi_thieu"]),
                    };
                    ban.trang_thai = (int)Enum.Parse(typeof(ETrangThaiBan), collection["TableStatus"]);
                    context.bans.Add(ban);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ban/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ban/Edit/5
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

        // GET: Ban/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ban/Delete/5
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
