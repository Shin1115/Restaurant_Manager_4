using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.Enums;
using Restaurant_Manager_4.Models;

namespace Restaurant_Manager_4.Controllers
{
    public class DatBanMonAnController : Controller
    {
        private Mapper _mapper;
        public DatBanMonAnController()
        {
            _mapper = new Mapper(ModelMappers.ModelMappers.MONAN_TO_MONANDTO);
        }
        // GET: DatBanMonAn
        public ActionResult Index()
        {
            using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
            {
                List<mon_an> monAns = context.mon_an
                    .Where(monAn => monAn.trang_thai == (int)ETrangThaiMonAn.ConHang)
                    .ToList();
                List<MonAnDTO> monAnDTOs = monAns
                    .Select(monAn => _mapper.Map<MonAnDTO>(monAn))
                    .ToList();
                return View(monAnDTOs);
            }
        }
    }
}
