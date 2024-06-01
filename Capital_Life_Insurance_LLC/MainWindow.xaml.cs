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

namespace Capital_Life_Insurance_LLC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
            Manager.MainFrame = MainFrame;
        }

        private void BackBT_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BackBT.Visibility = Visibility.Visible;
            }
            else
            {
                BackBT.Visibility = Visibility.Hidden;
            }
        }

        private void MainFrame_ContentRendered_1(object sender, EventArgs e)
        {

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content is СandidatePage candidatePage)
            {
                candidatePage.UpdateCandidat();
            }
            if (e.Content is UsersPage usersPage)
            {
                usersPage.Update();
            }
            if(e.Content is QuashionsPage quashionsPage)
            {
                quashionsPage.LoadData();
            }
        }
    }
}
