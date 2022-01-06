using Newtonsoft.Json;
using Restaurant_Manager_4.Infrastructure;
using Restaurant_Manager_4.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Restaurant_Manager_4.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.UserName, loginView.Password))
                {
                    CustomMembershipUser user = (CustomMembershipUser)Membership.GetUser(loginView.UserName, false);
                    if (user != null)
                    {
                        CustomSerializeModel userModel = new CustomSerializeModel()
                        {
                            UserId = user.UserId,
                            FullName = user.FullName,
                            Username = user.UserName,
                            Email = user.Email,
                            PhoneNumber = user.PhoneNumber,
                            Address = user.Address,
                            RoleName = user.Role.Select(r => r.ToString()).ToList()
                        };

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                        // Mã hoá ticket chứa thông tin user.
                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        // Set vào cookies
                        HttpCookie faCookie = new HttpCookie("Authentication", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", null);
                    }
                }
            }
            ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không hợp lệ");
            return View(loginView);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationView registrationView)
        {
            bool statusRegistration = false;
            string messageRegistration;
            if (ModelState.IsValid)
            {
                string userName = Membership.GetUserNameByEmail(registrationView.Email);
                if (!string.IsNullOrEmpty(userName))
                {
                    ModelState.AddModelError("Cảnh báo email", "Email này đã tồn tại");
                    return View(registrationView);
                }

                using (QuanLyNhaHangDataContext context = new QuanLyNhaHangDataContext())
                {
                    var user = new user()
                    {
                        ten_nguoi_dung = registrationView.FullName,
                        ten_dang_nhap = registrationView.Username,
                        mat_khau = registrationView.Password,
                        dia_chi = registrationView.Address,
                        email = registrationView.Email,
                        so_dien_thoai = registrationView.PhoneNumber,
                        vai_tro = 3, 
                        trang_thai = 1,
                        hinh_anh = "/Images/DefaultAvatar.jpg"
                    };
                    context.users.Add(user);
                    context.SaveChanges();
                }

                messageRegistration = "Đăng ký thành công";
                statusRegistration = true;
            }
            else
            {
                messageRegistration = "Có gì đó sai";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;
            return View(registrationView);
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Authentication", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }
    }
}