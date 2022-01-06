using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant_Manager_4
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ChonBan",
                url: "DatBan/Index/{idPhanMuc}",
                defaults: new { controller = "Datban", action = "Index", idPhanMuc = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "XoaPhanMuc",
                url: "DatBan/XoaPhanMuc/{idPhanMuc}",
                defaults: new { controller = "Datban", action = "XoaPhanMuc", idPhanMuc = UrlParameter.Optional}
                );

            routes.MapRoute(
                name: "DatBanController",
                url: "DatBan/ThemBan/{idBan}/{idPhanMuc}",
                defaults: new { controller = "Datban", action = "ThemBan", idBan = UrlParameter.Optional, idPhanMuc = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "XoaBanDaDat",
                url: "DatBan/XoaBan/{idBan}/{idPhanMuc}",
                defaults: new { controller = "Datban", action = "XoaBan", idBan = UrlParameter.Optional, idPhanMuc = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "ThemBanVaoPhanMuc",
                url: "DatBan/Index/{idPhanMuc}",
                defaults: new { controller = "Datban", action = "Index", idPhanMuc = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "BaoCaoThongKe",
                url: "BaoCaoThongKe/{action}/{id}",
                defaults: new { controller = "BaoCao", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DanhMucMonAn",
                url: "DanhMucMonAn/{action}/{TenMonAn}",
                defaults: new { controller = "DanhMucMonAn", action = "List", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
