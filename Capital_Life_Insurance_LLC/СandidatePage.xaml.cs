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
    
    public static class UserHR
    {
        public static int ID = 0;
    }
    public partial class СandidatePage : Page
    {
        private int ID = 0;
        List<CandidateCard> CandidateCardsPage = new List<CandidateCard>();

        public СandidatePage(int id)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                InitializeComponent();
                ID = id+1;
                var currentUser = Capital_Life_Insurance_LLCEntities.GetContext().Users.FirstOrDefault(u => u.UserID == ID);
                var currentUsers = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
                if (ID >= 0 && ID <= currentUsers.Count)
                {
                    userTB.Text = "Вы авторизированы как: " + currentUser.FirstName.ToString() + " " + currentUser.Name.ToString() + " " + currentUser.Patranomic.ToString();
                    RoleId.ID = currentUser.RoleID;
                    userRoleTB.Text = "   Роль: " + currentUser.UserRoleString.ToString();



                    if (RoleId.ID == 3)
                    {
                        AddBT.Visibility = Visibility.Visible;
                        CandidateCardsPage = CandidateCardsPage.Where(p => p.CreateUserID == ID).ToList();
                    }

                    else
                    {
                        AddBT.Visibility = Visibility.Collapsed;
                        EditQuashion.Visibility = Visibility.Collapsed;
                    }

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
                currentCandidate = currentCandidate.Where(p => p.CreateUserID == ID).ToList();

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

            currentCandidate = currentCandidate.Where(p => p.FIO.ToLower().Contains(SearchTB.Text.ToLower()) || p.Phone.ToLower().Contains(SearchTB.Text.ToLower()) || p.Email.ToLower().Contains(SearchTB.Text.ToLower())).ToList();
            foreach (var candidate in currentCandidate)
            {
                candidate.GradeSupervisor = CalculateGradeSupervisor(candidate.CandidateID);
            }
            foreach (var candidate in currentCandidate)
            {
                candidate.GradeHR = CalculateGradeHR(candidate.CandidateID);
            }
            /*
            if (RoleId.ID == 1) 
            {
                foreach (var candidate in currentCandidate)
                {
                    candidate.GradeSupervisor = CalculateGradeSupervisor(candidate.CandidateID);
                }
            }
            if (RoleId.ID == 3)
            {
                foreach (var candidate in currentCandidate)
                {
                    candidate.GradeHR = CalculateGradeHR(candidate.CandidateID);
                }
            }*/;
            foreach (var candidate in currentCandidate)
            {
                candidate.GradeALL = CalculateGradeAll(candidate.CandidateID);
            }

            if (SortCB.SelectedIndex == 1)
            {
                currentCandidate = currentCandidate.OrderBy(p => p.GradeALLSort).ToList();
            }
            else if (SortCB.SelectedIndex == 2) // Changed from FiterCB to SortCB
            {
                currentCandidate = currentCandidate.OrderByDescending(p => p.GradeALLSort).ToList();
            }
            CandidateList.ItemsSource = currentCandidate;

        }
        public string CalculateGradeAll(int candidateId)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var candidate = context.CandidateCard.FirstOrDefault(c => c.CandidateID == candidateId);
                if (candidate == null || candidate.Grade == null || !candidate.Grade.Any())
                {
                    return "Нет";
                }

                var grades = candidate.Grade.Where(g => g.Grade1.HasValue).Select(g => g.Grade1.Value);

                if (!grades.Any())
                {
                    return "Нет";
                }
                else
                {
                    return grades.Sum().ToString("F1");
                }
            }
        }
        public string CalculateGradeHR(int candidateId)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var hrUser = context.Users.FirstOrDefault(u => u.RoleID == 3); // Assuming RoleID 1 is for HR
                if (context.Grade == null || !context.Grade.Any() || hrUser == null)
                {
                    return "Нет";
                }
                var grades = context.Grade
                    .Where(g => g.UserID == hrUser.UserID && g.CandidateID == candidateId && g.Grade1.HasValue)
                    .Select(g => g.Grade1.Value);

                if (!grades.Any())
                {
                    return "Нет";
                }
                else
                {
                    return grades.Sum().ToString("F1"); // Using Average to give a more meaningful grade
                }
            }
        }

        public string CalculateGradeSupervisor(int candidateId)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var supervisorUser = context.Users.FirstOrDefault(u => u.RoleID == 1); // Assuming RoleID 2 is for Supervisor
                if (context.Grade == null || !context.Grade.Any() || supervisorUser == null)
                {
                    return "Нет";
                }

                var grades = context.Grade
                    .Where(g => g.UserID == supervisorUser.UserID && g.CandidateID == candidateId && g.Grade1.HasValue)
                    .Select(g => g.Grade1.Value);

                if (!grades.Any())
                {
                    return "Нет";
                }
                else
                {
                    return grades.Sum().ToString("F1"); // Using Average to give a more meaningful grade
                }
            }
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
                int candidateId = (int)button.CommandParameter;
                Manager.MainFrame.Navigate(new QuashionsPage(candidateId, ID));
            }
            UpdateCandidat();
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage((sender as Button).DataContext as CandidateCard, ID));
            UpdateCandidat();
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage(null, ID));
            UpdateCandidat();
        }

        private void EditQuashion_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditQuashionPage());
        }
    }
}