using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurant_Manager_4.Infrastructure
{
    public class RegistrationView
    {
        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tên đăng nhập")]
        public string Username { get; set; }

        [DisplayName("Tên đầy đủ")]
        [Required(ErrorMessage = "Bạn phải nhập tên đầy đủ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Trường Email không được để trống")]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu")]
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(18, ErrorMessage = "{0} phải dài từ {2} ký tự.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bạn cần xác nhận mật khẩu")]
        [DisplayName("Nhập lại Mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}