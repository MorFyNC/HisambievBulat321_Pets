using System.Windows;
using System.Linq;
using System.Windows.Controls;

namespace HisambievBulat321_Pets.Core.Classes
{
    public static class UIUpdater
    {
        private static Frame MainFrame;
        private static ListView MainList;
        private static StackPanel TopMenu;
        public static void Navigate(Page page) => MainFrame.Navigate(page);
        public static void GoBack() => MainFrame.GoBack();

        public static void InitFrame(Frame frame) => MainFrame = frame;
        public static void InitList(ListView listView) => MainList = listView;
        public static void InitTopMenu(StackPanel menu) => TopMenu = menu;

        

        public static void Refresh() 
            => MainList.ItemsSource = dbManager.GetPhotos().Where(x => x.Pets.Users == UserContext.GetUser());
        public static void RefreshUserName() => ((TextBlock)TopMenu.Children[0]).Text = UserContext.GetUser().Name;
        
        public static void SwitchTopMenu() 
            => TopMenu.Visibility = TopMenu.Visibility == Visibility.Collapsed ? Visibility.Visible : Visibility.Collapsed;
    }
}
