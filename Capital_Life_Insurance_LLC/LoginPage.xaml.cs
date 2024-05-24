using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>

    public static class UserID
    {
        public static int ID = 0;
    }
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            LoginTB.Text = "iskan123";
            PasswordTB.Password = "qwerty1";
        }

        private void RegistrarionBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }
        async void LoginBtn_Sleep()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                LoginBT.IsEnabled = false;
            }));
            Thread.Sleep(10000);
            this.Dispatcher.Invoke((Action)(() =>
            {
                LoginBT.IsEnabled = true;
            }));
        }

        private async void LoginBT_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
            currentUser = currentUser.Where(p => p.Login == LoginTB.Text && p.Password == PasswordTB.Password).ToList();
            int userID = 0;
            if (currentUser.Count() == 0)
            {
                MessageBox.Show("Введён не верный логин или пароль");
                await Task.Run(() => LoginBtn_Sleep());
            }
            else
            {
                foreach (Users user in currentUser)
                {
                    userID = user.UserID;
                }
                if (currentUser.Count == 0)
                {
                    MessageBox.Show("Данного пользователя не существует");
                    await Task.Run(() => LoginBtn_Sleep());
                }
                else if (currentUser.Count == 1)
                {
                    currentUser = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
                    UserID.ID = currentUser[userID - 1].RoleID;
                    if (currentUser[userID-1].RoleID == 2) 
                    {
                        Manager.MainFrame.Navigate(new UsersPage(userID - 1));
                    }
                    else
                    {
                        Manager.MainFrame.Navigate(new СandidatePage(userID - 1));
                    }
                    
                }
            }
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new UserEditPage(null));
        }
    }
}
