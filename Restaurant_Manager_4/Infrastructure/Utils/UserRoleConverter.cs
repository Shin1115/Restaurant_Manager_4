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
                case 1:
                    return UserRole.Admin;
                case 2:
                    return UserRole.Employee;
                default:
                    return UserRole.Customer;
            }
        }
    }
}