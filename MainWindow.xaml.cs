﻿using HisambievBulat321_Pets.Core.Classes;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthPage());
            UIUpdater.InitFrame(MainFrame);
            UIUpdater.InitTopMenu(TopSp);
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e) => UserContext.Logout();
    }
}
