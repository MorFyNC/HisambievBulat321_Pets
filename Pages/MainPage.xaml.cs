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
            SortCb.SelectedItem = Ascending;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addp = new AddPage();
            UIUpdater.Navigate(addp);
        }

        private void GetPhotos()
        {
            var source = dbManager.GetPhotos()
                .Where(x =>
                (x.Description.ToLower().Contains(SearchTb.Text.ToLower())
                || SearchTb.Text == "")
                && x.Pets.Users == UserContext.GetUser())
                .OrderBy(x =>
                x.Description)
                .ToList();

            if (SortCb.SelectedItem == Descending)
                source.Reverse();

            LstView.ItemsSource = source;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetPhotos();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetPhotos();
        }
    }
}
