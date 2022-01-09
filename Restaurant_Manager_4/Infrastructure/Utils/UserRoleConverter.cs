namespace Restaurant_Manager_4.Infrastructure.Utils
{
    public class UserRoleConverter
    {
        public static UserRole GetRole(int? roleId)
        {

            if (roleId == null)
            {
                return UserRole.Customer;
            }
            switch (roleId)
            {
                case 0:
                    return UserRole.Admin;
                case 1:
                    return UserRole.Employee;
                default:
                    return UserRole.Customer;
            }
        }

        public static UserRole GetRole(string roleName)
        {
            switch (roleName)
            {
                case null:
                    return UserRole.Customer;
                case "Customer":
                    return UserRole.Customer;
                case "Employee":
                    return UserRole.Employee;
                default:
                    return UserRole.Admin;
            }
        }
    }
}