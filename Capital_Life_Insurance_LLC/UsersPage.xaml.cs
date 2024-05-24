﻿using System;
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

namespace Capital_Life_Insurance_LLC
{
    /// <summary>
    /// Логика взаимодействия для UsersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage(int ID)
        {
            InitializeComponent();
            var currentUsers = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
            UserNameTB.Text = "Вы авторизированы как: " + currentUsers[ID].FirstName.ToString() + " " + currentUsers[ID].Name.ToString() + " " + currentUsers[ID].Patranomic.ToString();
            UserRoleTB.Text = "   Роль: " + currentUsers[ID].UserRoleString.ToString();
            UsersList.ItemsSource = currentUsers;
            Update();
        }
        public void Update()
        {
            UsersList.ItemsSource = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList(); 
            
        }

        

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserEditPage((sender as Button).DataContext as Users));
            Update();
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }


        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager.MainFrame.Navigate(new UserEditPage(null));
                Update();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            Update();



        }
    }
}