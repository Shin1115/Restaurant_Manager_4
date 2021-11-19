using Restaurant_Manager_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Restaurant_Manager_4.Infrastructure.Utils;

namespace Restaurant_Manager_4.Infrastructure
{
    public class CustomMembershipUser: MembershipUser
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public ICollection<UserRole> Role { get; set; }

        public CustomMembershipUser(user user) : base("CustomMembership", user.ten_nguoi_dung, user.id, user.email, 
            string.Empty, string.Empty, true, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now)
        {
            UserId = user.id;
            PhoneNumber = user.so_dien_thoai;
            Address = user.dia_chi;
            Role = new List<UserRole>() { UserRoleConverter.GetRole(user.vai_tro) };
        }
    }
}