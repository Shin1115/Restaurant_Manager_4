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
using Restaurant_Manager_4.Infrastructure;

namespace Restaurant_Manager_4.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: Cart
        QuanLyNhaHangDataContext db = new QuanLyNhaHangDataContext();
        private string strCart = "Cart";
        private string countCart = "Count";
        public ActionResult Index()
        {
            var user = db.users.Include(n => n.dat_ban);
            return View(user.ToList());
        }

        //Order Now
        public ActionResult OrderNow (int id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Cart> lsCart = new List<Cart>
                {
                    new Cart(db.mon_an.Find(id),1)
                };
                Session[strCart] = lsCart;
            }
            else
            {
                List<Cart> lsCart = (List<Cart>)Session[strCart];
                int check = isExistingcheck(id);
                if (check == -1)
                {
                    lsCart.Add(new Cart(db.mon_an.Find(id), 1));
                }
                else
                    lsCart[check].Soluong++;
                Session[strCart] = lsCart;
                //Session[countCart] = lsCart;

            }
            return View("Index");
        }

        //checked 
        public int isExistingcheck(int _id)
        {
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                if (lsCart[i].Monan.id == _id) return i;
            }
            return -1;
        }

        public ActionResult Update(FormCollection frc)
        {
            string[] qty = frc.GetValues("qty");
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            for (int i = 0; i < lsCart.Count; i++)
            {
                lsCart[i].Soluong = Convert.ToInt32(qty[i]);
            }
            Session[strCart] = lsCart;
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            int check = isExistingcheck(id);
            List<Cart> lsCart = (List<Cart>)Session[strCart];
            lsCart.RemoveAt(check);
            return View("Index");
        }

        public ActionResult CheckOut()
        {
            List<Cart> temp = (List<Cart>)Session[strCart];
            if (temp != null)
            {
                ViewBag.total = string.Format("{0:N0}", temp.Sum(x => x.Soluong * x.Monan.gia));
            }else            
            ViewBag.total = 0;
            return View("CheckOut");
        }
        public ActionResult ProcessOrder()
        {
            return View("OrderSuccess");
        }


        //private readonly QuanLyNhaHangDataContext _context;

        //public ShoppingCartController (QuanLyNhaHangDataContext context)
        //{
        //    _context = context;
        //}
        //public ActionResult ProcessOrder(FormCollection frc)
        //{
        //    List<Cart> lsCart = (List<Cart>)Session[strCart];
        //    CustomPrincipal user = (CustomPrincipal)HttpContext.User;
        //    int userId = user.UserId;
        //    using  (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
        //    {
        //        user currentUser = context.users
        //            .Where(us => us.id == userId)
        //            .First();
        //        hoa_don hoaDon = new hoa_don()
        //        {
        //            ngay_tao = DateTime.Now,


        //        };
        //        chi_tiet_hoa_don chi_Tiet_Hoa_Don = new chi_tiet_hoa_don()
        //        {
        //            so_luong = int.Parse(frc["so_luong"]),
        //        };
        //        hoaDon.chi_tiet_hoa_don.Add(chi_Tiet_Hoa_Don);
        //        currentUser.hoa_don.Add(hoaDon);
        //        context.SaveChanges();
        //    }
        //    foreach(Cart cart in lsCart)
        //    {
        //        chi_tiet_hoa_don cthoa_don = new chi_tiet_hoa_don()
        //        {
        //            id = user.UserId, 
        //        };
        //    }            

        //    return View("OrderSuccess");
        //}
    }
}