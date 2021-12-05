using AutoMapper;
using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.Enums;
using Restaurant_Manager_4.Helpers;
using Restaurant_Manager_4.Models;
using Restaurant_Manager_4.Requests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Hosting;

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
                    act => act.MapFrom(src => ((ETrangThaiBan)src.trang_thai).GetEnumDescription())
                    )
                .ForMember(
                    dest => dest.dat_coc_toi_thieu,
                    act => act.MapFrom(src => src.dat_coc_toi_thieu.ToString() + " đồng")
                    )
                );
        }

        // GET: Ban
        public ActionResult Index()
        {
            using (QuanLyNhaHangDataContext quanLyNhaHangDataContext = new QuanLyNhaHangDataContext())
            {
                Mapper mapper = new Mapper(_mapperConfiguration);
                List<ban> bans = quanLyNhaHangDataContext.bans.ToList();
                List<BanDTO> banResponses = bans
                    .Select(ban => mapper.Map<BanDTO>(ban)).ToList();
                return View(banResponses);
            }
        }

        // GET: Ban/Details/5
        public ActionResult Details(int id)
        {
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                ban detailBan = context.bans.Where(ban => ban.id == id).FirstOrDefault();
                Mapper mapper = new Mapper(_mapperConfiguration);
                BanDTO showBan = mapper.Map<BanDTO>(detailBan);
                showBan.hinh_anh = Server.MapPath(showBan.hinh_anh);
                return View(showBan);
            }
        }

        // GET: Ban/Create
        [HttpGet]
        public ActionResult Create()
        {
            var descriptorsAsValue = Selectlists.EnumSelectlist<ETrangThaiBan>();
            ViewBag.trangThaiBan = descriptorsAsValue;
            return View();
        }

        // POST: Ban/Create
        [HttpPost]
        public ActionResult Create(BanRequest banRequest)
        {
            try
            {
                string timestamp = DateTime.Now.ToFileTime().ToString();
                string fileName = $"ban_{timestamp}";
                string extension = Path.GetExtension(banRequest.imageFile.FileName);
                banRequest.hinh_anh = "../upload/image_Ban/" + fileName + extension;
                string path = Path.Combine(Server.MapPath("../upload/image_Ban/"), fileName+extension);
                banRequest.imageFile.SaveAs(path);
                using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
                {
                    ban ban = new ban
                    {
                        ten_ban = banRequest.ten_ban,
                        cho_ngoi_toi_da = banRequest.cho_ngoi_toi_da,
                        trang_thai = banRequest.trang_thai,
                        dat_coc_toi_thieu = banRequest.dat_coc_toi_thieu,
                        mo_ta = banRequest.mo_ta,
                        hinh_anh = banRequest.hinh_anh
                    };
                    context.bans.Add(ban);
                    context.SaveChanges();
                }
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            catch
            {
                var descriptorsAsValue = Selectlists.EnumSelectlist<ETrangThaiBan>();
                ViewBag.trangThaiBan = descriptorsAsValue;
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
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                var mapper = new Mapper(_mapperConfiguration);
                ban banNeedDelete = context.bans.Where(ban => ban.id == id).FirstOrDefault();
                BanDTO banDTO = mapper.Map<BanDTO>(banNeedDelete);
                return View(banDTO);
            }
        }

        // POST: Ban/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
                {
                    ban banNeedDelete = context.bans.Where(ban => ban.id == id).FirstOrDefault();
                    string fileName = Path.GetFileNameWithoutExtension(banNeedDelete.hinh_anh);
                    string extension = Path.GetExtension(banNeedDelete.hinh_anh);
                    string databaseImagePath = "upload/image_Ban/" + fileName + extension;
                    string imagePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, databaseImagePath);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    context.bans.Remove(banNeedDelete);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
