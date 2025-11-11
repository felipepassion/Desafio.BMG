namespace Bmg.Desafio.Users.Enumerations
{
    public enum UserRole : uint
    {
        USER = 0,
        ADMIN = 1,
        SUPPORT = 2,
    }

    public static class UserRoleExtensions
    {
        public static string ToFriendlyString(this UserRole role)
        {
            switch (role)
            {
                case UserRole.ADMIN:
                    return "Admin";
                case UserRole.USER:
                    return "User";
                case UserRole.SUPPORT:
                    return "Support";
                default:
                    throw new Exception($"Unknown user role {role.ToString()}");
            }
        }
    }
}