using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Restaurant_Manager_4.Infrastructure.Utils;

namespace Restaurant_Manager_4.Infrastructure
{
    public class CustomPrincipal : IPrincipal
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string[] Roles  { get; set; }


        public IIdentity Identity { get; private set; }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        /// <summary>
        /// Phương thức này thực hiện kiểm tra 
        /// user hiện tại có thuộc một role nào đó hay không.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            UserRole userRole = UserRoleConverter.GetRole(Roles[0]);
            UserRole requestRole = UserRoleConverter.GetRole(role);

            if ((int)userRole <= (int)requestRole)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}