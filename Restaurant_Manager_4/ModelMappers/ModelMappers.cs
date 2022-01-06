using AutoMapper;
using Restaurant_Manager_4.DTO;
using Restaurant_Manager_4.Enums;
using Restaurant_Manager_4.Helpers;
using Restaurant_Manager_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.ModelMappers
{
    public class ModelMappers
    {
        public static MapperConfiguration BAN_TO_BANDTO = new MapperConfiguration(cfg =>
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

        public static MapperConfiguration MONAN_TO_MONANDTO = new MapperConfiguration(cfg =>
         cfg.CreateMap<mon_an, MonAnDTO>()
         .ForMember(
             dest => dest.trang_thai,
             act => act.MapFrom(src => ((ETrangThaiMonAn)src.trang_thai).GetEnumDescription())
             )
         .ForMember(
             dest => dest.gia,
             act => act.MapFrom(src => src.gia.ToString() + " đồng")
             )
        );
    }
}