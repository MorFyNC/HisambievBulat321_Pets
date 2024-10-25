using HisambievBulat321_Pets.Core.Classes;
using HisambievBulat321_Pets.Core.Database;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HisambievBulat321_Pets
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            LstView.ItemsSource = dbManager.GetPhotos().Where(x => x.Pets.Users == UserContext.GetUser());
            UIUpdater.InitList(LstView);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addp = new AddPage();
            UIUpdater.Navigate(addp);
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
