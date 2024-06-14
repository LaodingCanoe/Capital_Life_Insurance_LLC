using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Capital_Life_Insurance_LLC
{  
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
                ID = id + 1;
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
            };
            foreach (var candidate in currentCandidate)
            {
                candidate.GradeALL = CalculateGradeAll(candidate.CandidateID);
            }
            if (SortCB.SelectedIndex == 1)
            {
                currentCandidate = currentCandidate.OrderBy(p => p.GradeALLSort).ToList();
            }
            else if (SortCB.SelectedIndex == 2) 
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
                var hrUser = context.Users.FirstOrDefault(u => u.RoleID == 3);
                var supervisorUser = context.Users.FirstOrDefault(u => u.RoleID == 1);
                if (hrUser == null || supervisorUser == null)
                {
                    return "Нет";
                }
                var hrGrades = candidate.Grade.Where(g => g.UserID == hrUser.UserID && g.AnswersID.HasValue).Select(g => g.AnswersID.Value);
                var supervisorGrades = candidate.Grade.Where(g => g.UserID == supervisorUser.UserID && g.AnswersID.HasValue).Select(g => g.AnswersID.Value);
                if (!hrGrades.Any() && !supervisorGrades.Any())
                {
                    return "Нет";
                }
                double totalScore = 0.0;
                double maxPossibleScore = 0.0;
                foreach (var answerId in hrGrades)
                {
                    var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                    if (answer != null)
                    {
                        var question = context.Question.FirstOrDefault(q => q.QuestionID == answer.QuestionID);
                        if (question != null)
                        {
                            double questionWeight = question.QuashionWeightCoefficient;
                            double answerWeight = answer.AnswerWeightCoefficient;
                            totalScore += questionWeight * answerWeight * 0.4;

                            double maxAnswerWeight = context.Answers
                                .Where(a => a.QuestionID == question.QuestionID)
                                .Max(a => a.AnswerWeightCoefficient);
                            maxPossibleScore += questionWeight * maxAnswerWeight * 0.4;
                        }
                    }
                }
                foreach (var answerId in supervisorGrades)
                {
                    var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                    if (answer != null)
                    {
                        var question = context.Question.FirstOrDefault(q => q.QuestionID == answer.QuestionID);
                        if (question != null)
                        {
                            double questionWeight = question.QuashionWeightCoefficient;
                            double answerWeight = answer.AnswerWeightCoefficient;
                            totalScore += questionWeight * answerWeight * 0.6;

                            double maxAnswerWeight = context.Answers
                                .Where(a => a.QuestionID == question.QuestionID)
                                .Max(a => a.AnswerWeightCoefficient);
                            maxPossibleScore += questionWeight * maxAnswerWeight * 0.6;
                        }
                    }
                }
                double convertedScore = totalScore * (100.0 / maxPossibleScore);
                return convertedScore.ToString("F1");
            }
        }
        public string CalculateGradeHR(int candidateId)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var hrUser = context.Users.FirstOrDefault(u => u.RoleID == 3);
                if (context.Grade == null || !context.Grade.Any() || hrUser == null)
                {
                    return "Нет";
                }
                var grades = context.Grade
                    .Where(g => g.UserID == hrUser.UserID && g.CandidateID == candidateId && g.AnswersID.HasValue)
                    .Select(g => g.AnswersID.Value);
                if (!grades.Any())
                {
                    return "Нет";
                }
                else
                {
                    double totalScore = 0.0;
                    double maxPossibleScore = 0.0;
                    foreach (var answerId in grades)
                    {
                        var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                        if (answer != null)
                        {
                            var question = context.Question.FirstOrDefault(q => q.QuestionID == answer.QuestionID);
                            if (question != null)
                            {
                                double questionWeight = question.QuashionWeightCoefficient;
                                double answerWeight = answer.AnswerWeightCoefficient;
                                totalScore += questionWeight * answerWeight * 0.4;

                                double maxAnswerWeight = context.Answers
                                    .Where(a => a.QuestionID == question.QuestionID)
                                    .Max(a => a.AnswerWeightCoefficient);
                                maxPossibleScore += questionWeight * maxAnswerWeight * 0.4;
                            }
                        }
                    }
                    double convertedScore = totalScore * (40.0 / maxPossibleScore);
                    return convertedScore.ToString("F1");
                }
            }
        }
        public string CalculateGradeSupervisor(int candidateId)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var supervisorUser = context.Users.FirstOrDefault(u => u.RoleID == 1);
                if (context.Grade == null || !context.Grade.Any() || supervisorUser == null)
                {
                    return "Нет";
                }
                var grades = context.Grade
                    .Where(g => g.UserID == supervisorUser.UserID && g.CandidateID == candidateId && g.AnswersID.HasValue)
                    .Select(g => g.AnswersID.Value);
                if (!grades.Any())
                {
                    return "Нет";
                }
                else
                {
                    double totalScore = 0.0;
                    double maxPossibleScore = 0.0;
                    foreach (var answerId in grades)
                    {
                        var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                        if (answer != null)
                        {
                            var question = context.Question.FirstOrDefault(q => q.QuestionID == answer.QuestionID);
                            if (question != null)
                            {
                                double questionWeight = question.QuashionWeightCoefficient;
                                double answerWeight = answer.AnswerWeightCoefficient;
                                totalScore += questionWeight * answerWeight * 0.6;

                                double maxAnswerWeight = context.Answers
                                    .Where(a => a.QuestionID == question.QuestionID)
                                    .Max(a => a.AnswerWeightCoefficient);

                                maxPossibleScore += questionWeight * maxAnswerWeight * 0.6;
                            }
                        }
                    }
                    double convertedScore = totalScore * (60.0 / maxPossibleScore);
                    return convertedScore.ToString("F1");
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