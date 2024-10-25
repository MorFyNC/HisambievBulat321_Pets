using HisambievBulat321_Pets.Core.Database;

namespace HisambievBulat321_Pets.Core.Classes
{
    internal static class UserContext
    {
        private static Users CurrentUser;

        public static void Authorise(Users user) => CurrentUser = user;
        public static Users GetUser() => CurrentUser;
    }
}
