using Restaurant_Manager_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant_Manager_4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        quan_ly_nha_hangEntities db = new quan_ly_nha_hangEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection filed, string uremail)
        {
            string users = filed["email"];
            //string pass = MyString.toMD5(filed["password"]);
            string pass = filed["password"];
            string error = "";
            //xuly
            user checkrow = getRow(users);
            if (checkrow != null)
            {
                //Login
                if (checkrow.mat_khau.Equals(pass))
                {
                    Session["Users"] = checkrow.email;
                    Session["UserID"] = checkrow.id.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    error = "mật khẩu đéo được";
                }

            }
            else
            {
                error = "Đăng nhập đéo được";
            }
            ViewBag.StrError = "<div class='text-danger'>" + error + "</div>";
            return View();
        }
        public user getRow(string useremail)
        {
            var finerow =  db.users.Where(x => x.email == useremail).FirstOrDefault();
            return finerow;
        }
        public ActionResult Logout()
        {
            Session["Users"] = "";
            Session["UserID"] = "";
            return Redirect("~/Login/Login");
        }
    }
}