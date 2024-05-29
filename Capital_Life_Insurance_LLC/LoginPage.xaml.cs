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
            LoginTB.Text = "danis123";
            PasswordTB.Password = "qwerty1";
        }

        private void RegistrarionBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new RegistrationPage());
        }
        async void  LoginBtn_Sleep()
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
            var context = Capital_Life_Insurance_LLCEntities.GetContext();
            var currentUser = context.Users
                                     .Where(p => p.Login == LoginTB.Text && p.Password == PasswordTB.Password)
                                     .ToList();

            if (currentUser.Count == 0)
            {
                MessageBox.Show("Введён не верный логин или пароль");
                await Task.Run(() => LoginBtn_Sleep());
            }
            else
            {
                var user = currentUser.First();
                int userID = user.UserID;

                if (currentUser.Count == 0)
                {
                    MessageBox.Show("Данного пользователя не существует");
                    await Task.Run(() => LoginBtn_Sleep());
                }
                else if (currentUser.Count == 1)
                {
                    UserID.ID = user.RoleID;
                    if (user.RoleID == 2)
                    {
                        Manager.MainFrame.Navigate(new UsersPage(userID));
                    }
                    else if (user.RoleID == 4)
                    {
                        MessageBox.Show("Вам еще не выдана роль, для этого обратитесь к администратору");
                    }
                    else
                    {
                        Manager.MainFrame.Navigate(new СandidatePage(userID - 1));
                    }
                }
            }
        }

    }
}
