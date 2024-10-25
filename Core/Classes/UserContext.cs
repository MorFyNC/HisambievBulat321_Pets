using HisambievBulat321_Pets.Core.Database;

namespace HisambievBulat321_Pets.Core.Classes
{
    internal static class UserContext
    {
        private static Users CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                if(value != null)
                    UIUpdater.RefreshUserName();
            }
        }
        private static Users _currentUser;
        public static void Authorise(Users user) => CurrentUser = user;
        public static Users GetUser() => CurrentUser;
        public static void Logout()
        {
            CurrentUser = null;
            UIUpdater.Navigate(new AuthPage());
            UIUpdater.SwitchTopMenu();
        }
    }
}
