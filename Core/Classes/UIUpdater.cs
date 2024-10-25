using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HisambievBulat321_Pets.Core.Classes
{
    public static class UIUpdater
    {
        private static Frame MainFrame;
        private static ListView MainList;
        public static void Navigate(Page page) => MainFrame.Navigate(page);
        public static void InitFrame(Frame frame) => MainFrame = frame;
        public static void InitList(ListView listView) => MainList = listView;
        public static void GoBack() => MainFrame.GoBack();
        public static void Refresh() => MainList.ItemsSource = dbManager.GetPhotos().Where(x => x.Pets.Users == UserContext.GetUser());
    }
}
