using AutoMapper;
using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.Enums;
using Restaurant_Manager_4.Helpers;
using Restaurant_Manager_4.Models;
using Restaurant_Manager_4.Requests;
using Restaurant_Manager_4.SerializableObjects;
using Restaurant_Manager_4.SerializableObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Restaurant_Manager_4.Controllers
{
    public class DatBanController : Controller
    {
        private static string DAT_MON_AN_SESSION_KEY = "DatMonAnSession";
        private Mapper _mapperBan;
        private Mapper _mapperMonAn;
        public DatBanController()
        {
            _mapperBan = new Mapper(ModelMappers.ModelMappers.BAN_TO_BANDTO);
            _mapperMonAn = new Mapper(ModelMappers.ModelMappers.MONAN_TO_MONANDTO);
        }

        // GET: DatBan
        public ActionResult Index(string idPhanMuc = "1")
        {
            CreateDatMonAnSessionData();
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {   
                //CustomPrincipal customPrincipal = (CustomPrincipal)HttpContext.User;
                List<ban> bans = context.bans.Where(ban => ban.trang_thai == 0).ToList();
                List<BanDTO> banDTOs = bans.Select(ban => _mapperBan.Map<BanDTO>(ban)).ToList<BanDTO>();
                return View(banDTOs);
            }
        }

        public ActionResult DanhSachMonAn(string idPhanMuc = "1")
        {
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                List<mon_an> monAns = context.mon_an
                    .Where(monAn => monAn.trang_thai == (int)ETrangThaiMonAn.ConHang)
                    .ToList();
                List<MonAnDTO> monAnDTOs = monAns
                    .Select(monAn => _mapperMonAn.Map<MonAnDTO>(monAn))
                    .ToList();
                return View(monAnDTOs);
            }
        }

        public ActionResult ThemMonAn(string idMonAn, string idPhanMuc = "1")
        {
            CreateDatMonAnSessionData();
            DatMonAnSessionData datMonAnSessionData = Session[DAT_MON_AN_SESSION_KEY] as DatMonAnSessionData;
            int nIdPhanMuc = int.Parse(idPhanMuc);
            if (idMonAn != null)
            {
                int nIdMonAn = int.Parse(idMonAn);
                if (!IsExistInSessionDataMonAn(nIdMonAn))
                {
                    datMonAnSessionData.Data[nIdPhanMuc][PhanMucType.Ban].Add(nIdMonAn);
                }
            }
            return Redirect("ThemBan");
        }

        public ActionResult ThemBan(string idBan, string idPhanMuc = "1")
        {
            CreateDatMonAnSessionData();
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                List<phan_muc_ban> phan_Muc_Bans = context.phan_muc_ban.ToList();
                ViewBag.DanhSachPhanMuc = phan_Muc_Bans;
            }
            DatMonAnSessionData datMonAnSessionData = Session[DAT_MON_AN_SESSION_KEY] as DatMonAnSessionData;
            int nIdPhanMuc = int.Parse(idPhanMuc);
            if (idBan != null)
            {
                int nIdBan = int.Parse(idBan);
                if (!IsExistInSessionDataBan(nIdBan))
                {
                    datMonAnSessionData.Data[nIdPhanMuc][PhanMucType.Ban].Add(nIdBan);
                }
            }
            Session[DAT_MON_AN_SESSION_KEY] = datMonAnSessionData;

            ViewBag.BanDTOs = GetBanDTOs(datMonAnSessionData);
            ViewBag.DatMonAnSessionData = datMonAnSessionData;

            DatBanRequest datBanRequest = new DatBanRequest();
            datBanRequest.banDTOs = GetBanDTOs(datMonAnSessionData);
            datBanRequest.monAnDTOs = new List<MonAnDTO>();
            datBanRequest.tien_coc_truoc = 0;
            datBanRequest.so_luong_nguoi = 0;
            datBanRequest.ngay_dat = DateTime.Now;
            datBanRequest.ngay_den = datBanRequest.ngay_dat.AddDays(3);
            return View(datBanRequest);
        }

        public ActionResult XoaBan(string idBan)
        {
            return View();
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

        private List<BanDTO> GetBanDTOs(DatMonAnSessionData datMonAnSessionData)
        {
            List<BanDTO> banDTOs = new List<BanDTO>();
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                Dictionary<int, Dictionary<PhanMucType,List<int>>> data = datMonAnSessionData.Data;
                foreach (KeyValuePair<int, Dictionary<PhanMucType, List<int>>> keyValuePair in data)
                {
                    Dictionary<PhanMucType, List<int>> danhSachBanMonAnId = keyValuePair.Value;
                    List<int> idBans = danhSachBanMonAnId[PhanMucType.Ban];
                    foreach (int idBan in idBans)
                    {
                        ban ban = context.bans.Where(b => b.id == idBan).FirstOrDefault();
                        BanDTO banDTO = _mapperBan.Map<BanDTO>(ban);
                        banDTOs.Add(banDTO);
                    }
                }
                return banDTOs;
            }
        }

        private void CreateDatMonAnSessionData()
        {
            if (!(Session[DAT_MON_AN_SESSION_KEY] is DatMonAnSessionData datMonAnSessionData))
            {
                ViewBag.BanDTOs = new List<BanDTO>();
                ViewBag.MonAnDTOs = new List<MonAnDTO>();
                Dictionary<int, Dictionary<PhanMucType, List<int>>> data = new Dictionary<int, Dictionary<PhanMucType, List<int>>>();
                using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
                {
                    foreach (phan_muc_ban phanMucBan in context.phan_muc_ban.ToList())
                    {
                        Dictionary<PhanMucType, List<int>> phanMucDic = new Dictionary<PhanMucType, List<int>>();
                        phanMucDic[PhanMucType.Ban] = new List<int>();
                        phanMucDic[PhanMucType.MonAn] = new List<int>();
                        data[phanMucBan.id] = phanMucDic;
                    }
                }

                Session[DAT_MON_AN_SESSION_KEY] = new DatMonAnSessionData()
                {
                    Data = data
                };
            }
        }

        private bool IsExistInSessionDataBan(int idBan)
        {
            DatMonAnSessionData datMonAnSessionData = Session[DAT_MON_AN_SESSION_KEY] as DatMonAnSessionData;
            if (datMonAnSessionData!=null)
            {
                foreach (Dictionary<PhanMucType, List<int>> value in datMonAnSessionData.Data.Values)
                {
                    if (value[PhanMucType.Ban].Contains(idBan))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }

        private bool IsExistInSessionDataMonAn(int idMonAn)
        {
            DatMonAnSessionData datMonAnSessionData = Session[DAT_MON_AN_SESSION_KEY] as DatMonAnSessionData;
            if (datMonAnSessionData != null)
            {
                foreach (Dictionary<PhanMucType, List<int>> value in datMonAnSessionData.Data.Values)
                {
                    if (value[PhanMucType.MonAn].Contains(idMonAn))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}
