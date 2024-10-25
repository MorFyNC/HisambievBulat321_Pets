using HisambievBulat321_Pets.Core.Classes;
using HisambievBulat321_Pets.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HisambievBulat321_Pets
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            LoginCb.ItemsSource = dbManager.GetUsers();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(LoginCb.SelectedItem == null)
            {
                MessageBox.Show("Пользователь не выбран!", "WARNING!");
                return;
            }
            UserContext.Authorise(LoginCb.SelectedItem as Users);
            UIUpdater.Navigate(new MainPage());
        }
    }
}
