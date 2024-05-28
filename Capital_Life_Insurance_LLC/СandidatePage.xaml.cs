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
                userId = id;
                var currentUsers = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
                userTB.Text = "Вы авторизированы как: " + currentUsers[id].FirstName.ToString() + " " + currentUsers[id].Name.ToString() + " " + currentUsers[id].Patranomic.ToString();
                RoleId.ID = currentUsers[id].RoleID;
                userRoleTB.Text = "   Роль: " + currentUsers[id].UserRoleString.ToString();
                if (RoleId.ID == 3)
                    AddBT.Visibility = Visibility.Visible;
                else
                    AddBT.Visibility = Visibility.Collapsed;
                CandidateCardsPage = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();
                CandidateList.ItemsSource = CandidateCardsPage;
                FiterCB.SelectedIndex = 0;
                SortCB.SelectedIndex = 0;
            }
        }
        
        //Код для обновление страницы
        private void UpdateCandidat()
        {
            var currentCandidate = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();

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
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage((sender as Button).DataContext as CandidateCard));
            UpdateCandidat();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage(null));
            UpdateCandidat();
        }
    }
}