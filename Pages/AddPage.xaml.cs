using HisambievBulat321_Pets.Core.Classes;
using HisambievBulat321_Pets.Core.Database;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        bool TwoPets = false;
        ComboBox newCb;
        public AddPage()
        {
            InitializeComponent();
            PetCb.ItemsSource = dbManager.GetPets();
        }

        private void AddPetBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPetBtn_Click(sender, e, PetCb);
        }

        private void AddPetBtn_Click(object sender, RoutedEventArgs e, ComboBox petCb)
        {
            if(petCb.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите первого питомца!", "WARNING!");
                return;
            }
            newCb = new ComboBox() { ItemsSource = (petCb.ItemsSource as List<Pets>).Where(x => x != petCb.SelectedItem as Pets) };
            PetsSp.Children.Add(newCb);
            TwoPets = true;
            AddPetBtn.Visibility = Visibility.Collapsed;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if(PetCb.SelectedItem == null || (TwoPets && newCb.SelectedItem == null))
            {
                MessageBox.Show("Выберите питомца!", "WARNING!");
                return;
            }
            if(PhotoImg.Source == null)
            {
                MessageBox.Show("Добавьте фото питомца!", "WARNING!");
                return;
            }
            
            dbManager.AddPhoto(DescriptionTb.Text, PhotoImg.Source.ToString(), PetCb.SelectedItem as Pets, newCb?.SelectedItem as Pets);
            
            UIUpdater.Refresh();
            UIUpdater.GoBack();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            UIUpdater.GoBack();
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            var OFDialog = new OpenFileDialog();
            OFDialog.ShowDialog();
            if(OFDialog.FileName != "")
            {
                PhotoImg.Source = new BitmapImage(new Uri(OFDialog.FileName));
                PhotoImg.Visibility = Visibility.Visible;
                AddPhotoBtn.Visibility = Visibility.Collapsed;
            }
        }
    }
}
