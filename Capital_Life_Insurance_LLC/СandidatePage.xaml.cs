using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для СandidatePage.xaml
    /// </summary>
    public static class RoleId
    {
        public static int ID = 0;
    }
    public partial class СandidatePage : Page
    {
        List<CandidateCard> CandidateCardsPage = new List<CandidateCard>();
        private int userId;

        public СandidatePage(int id)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                InitializeComponent();
                userId = id+1;
                var currentUser = Capital_Life_Insurance_LLCEntities.GetContext().Users.FirstOrDefault(u => u.UserID == userId);
                var currentUsers = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
                if (userId >= 0 && userId <= currentUsers.Count)
                {
                    userTB.Text = "Вы авторизированы как: " + currentUser.FirstName.ToString() + " " + currentUser.Name.ToString() + " " + currentUser.Patranomic.ToString();
                    RoleId.ID = currentUser.RoleID;
                    userRoleTB.Text = "   Роль: " + currentUser.UserRoleString.ToString();

                    

                    if (RoleId.ID == 3)
                    {
                        AddBT.Visibility = Visibility.Visible;
                        CandidateCardsPage = CandidateCardsPage.Where(p => p.CreateUserID == userId).ToList();
                    }
                        
                    else
                        AddBT.Visibility = Visibility.Collapsed;

                    CandidateCardsPage = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();
                    CandidateList.ItemsSource = CandidateCardsPage;
                    FiterCB.SelectedIndex = 0;
                    SortCB.SelectedIndex = 0;
                    UpdateCandidat();
                }
                else
                {
                    MessageBox.Show("Некорректный идентификатор пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            UpdateCandidat();
        }

        //Код для обновление страницы
        public void UpdateCandidat()
        {
            var currentCandidate = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();
            if (RoleId.ID == 3)
                currentCandidate = currentCandidate.Where(p => p.CreateUserID == userId).ToList();

            if (FiterCB.SelectedIndex == 1)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Страховой агент").ToList();
            }
            else if (FiterCB.SelectedIndex == 2)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Бухгалтер").ToList();
            }
            else if (FiterCB.SelectedIndex == 3)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Менеджер по рекламе").ToList();
            }
            else if (FiterCB.SelectedIndex == 4)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Менеджер по маркетингу").ToList();
            }
            else if (FiterCB.SelectedIndex == 5)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Менеджер по работе с клиентами").ToList();
            }
            else if (FiterCB.SelectedIndex == 6)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Менеджер по продажам").ToList();
            }
            else if (FiterCB.SelectedIndex == 7)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "Специалист по урегулированию убытков").ToList();
            }
            else if (FiterCB.SelectedIndex == 8)
            {
                currentCandidate = currentCandidate.Where(p => p.PositionToString == "HR-специалист").ToList();
            }

            /* if (SortCB.SelectedIndex == 1)
             {
                 currentCandidate = currentCandidate.OrderBy(p => p.GenderCode == "ж").ToList();
             }
             else if (FiterCB.SelectedIndex == 2)
             {
                 currentCandidate = currentCandidate.Where(p => p.GenderCode == "м").ToList();
             }*/

            currentCandidate = currentCandidate.Where(p => p.FIO.ToLower().Contains(SearchTB.Text.ToLower()) || p.Phone.ToLower().Contains(SearchTB.Text.ToLower()) || p.Email.ToLower().Contains(SearchTB.Text.ToLower())).ToList();

            CandidateList.ItemsSource = currentCandidate;

        }
        
        private void FiterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCandidat();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCandidat();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCandidat();
        }

        private void Take_a_questionnaireBT_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter != null)
            {
              /*  var currentGrade = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();
                var CountQuashions = Capital_Life_Insurance_LLCEntities.GetContext().Quashions.Count();
                var cirrentQuashions = Capital_Life_Insurance_LLCEntities.GetContext().Quashions.ToList();
                Quashions _currentQuashions = new Quashions();
                for (int i = 0; i < CountQuashions; i++)
                {
                    _currentQuashions.QuashionID = ;
                    _currentQuashions.UserID = IDuser;
                    _currentQuashions.QuashionID = NumberQuashion;
                    _currentQuashions.Grade1 = 5;
                }*/
                int candidateId = (int)button.CommandParameter;
                //var currentgrade = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();
                Manager.MainFrame.Navigate(new QuashionsPage(candidateId, userId+1));
            }
            UpdateCandidat();
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage((sender as Button).DataContext as CandidateCard, userId));
            UpdateCandidat();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage(null, userId));
            UpdateCandidat();
        }
    }
}