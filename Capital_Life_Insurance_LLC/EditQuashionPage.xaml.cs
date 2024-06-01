using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Capital_Life_Insurance_LLC
{
    public partial class EditQuashionPage : Page
    {
        private ObservableCollection<Question> CurrentPageList = new ObservableCollection<Question>();
        private ObservableCollection<Answers> AnswersList = new ObservableCollection<Answers>();
        private Capital_Life_Insurance_LLCEntities context;
        private List<Question> TableList = new List<Question>();
        private int CurrentPage = 0;
        private int CountQuashion;
        private int CountPage;
        string title;

        public EditQuashionPage()
        {
            InitializeComponent();
            LoadData();
            ChangePage(0);
            Title.Text = title;
            AnswerList.ItemsSource = AnswersList;
        }

        private void LoadData()
        {
            using (context = new Capital_Life_Insurance_LLCEntities())
            {
                var questions = context.Question.ToList();

                TableList = questions;
                CountQuashion = TableList.Count;
                CountPage = (int)Math.Ceiling((double)CountQuashion / 1);
                PageListBox.ItemsSource = Enumerable.Range(1, CountPage).ToList();
                LoadCurrentPage();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentQuashion();
            MessageBox.Show("Изменения сохранены");
            Manager.MainFrame.GoBack();
        }

        private void ChangePage(int direction)
        {
            CurrentPage += direction;
            if (CurrentPage < 0)
            {
                CurrentPage = 0;
            }
            else if (CurrentPage >= CountPage)
            {
                CurrentPage = CountPage - 1;
            }

            LoadCurrentPage();
        }

        private void LoadCurrentPage()
        {
            CurrentPageList.Clear();
            AnswersList.Clear();

            if (TableList.Count > 0)
            {
                CurrentPageList.Add(TableList[CurrentPage]);
                var question = CurrentPageList[0];
                Title.Text = question.Title;
                title = question.Title;

                using (context = new Capital_Life_Insurance_LLCEntities())
                {
                    var answers = context.Answers.Where(x => x.QuestionID == question.QuestionID).ToList();
                    foreach (var answer in answers)
                    {
                        AnswersList.Add(answer);
                    }

                    var questionFromDb = context.Question.FirstOrDefault(q => q.QuestionID == question.QuestionID);
                    if (questionFromDb != null)
                    {
                        QuashionWeightCoefficient.Text = questionFromDb.QuashionWeightCoefficient.ToString();
                    }
                }
            }
            Title.Text = title;
        }


        private void SaveCurrentQuashion()
        {
            using (var dbContext = new Capital_Life_Insurance_LLCEntities())
            {
                var questionInDatabase = dbContext.Question.Find(TableList[CurrentPage].QuestionID);
                if (questionInDatabase != null)
                {
                    questionInDatabase.Title = Title.Text;
                    questionInDatabase.QuashionWeightCoefficient = int.Parse(QuashionWeightCoefficient.Text); // Парсим значение из текстового поля

                    var answersInDatabase = dbContext.Answers.Where(p => p.QuestionID == questionInDatabase.QuestionID).ToList();
                    for (int i = 0; i < answersInDatabase.Count; i++)
                    {
                        var answerItem = AnswersList[i];
                        answersInDatabase[i].AnswerTitle = answerItem.AnswerTitle;
                        answersInDatabase[i].AnswerWeightCoefficient = answerItem.AnswerWeightCoefficient;
                    }

                    dbContext.SaveChanges();

                    TableList[CurrentPage].Title = Title.Text;
                }
            }
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (PageListBox.SelectedItem != null)
            {
                CurrentPage = (int)PageListBox.SelectedItem - 1;
                LoadCurrentPage();
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveCurrentQuashion();
        }

        private void LeftBT_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(-1);
        }

        private void RightBT_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(1);
        }

        private void AddAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageList.Count > 0)
            {
                var currentQuestion = CurrentPageList[0];

                int maxAnswerId;
                using (var dbContext = new Capital_Life_Insurance_LLCEntities())
                {
                    maxAnswerId = dbContext.Answers.Max(a => (int?)a.AnswerId) ?? 0;
                }

                var newAnswer = new Answers
                {
                    AnswerId = maxAnswerId + 1,
                    AnswerTitle = "Новый ответ",
                    AnswerWeightCoefficient = 1,
                    QuestionID = currentQuestion.QuestionID
                };

                using (var dbContext = new Capital_Life_Insurance_LLCEntities())
                {
                    dbContext.Answers.Add(newAnswer);
                    dbContext.SaveChanges();
                }

                LoadCurrentPage();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var answer = button.DataContext as Answers;
                if (answer != null)
                {
                    using (var dbContext = new Capital_Life_Insurance_LLCEntities())
                    {
                        var answerInDatabase = dbContext.Answers.Find(answer.AnswerId);
                        if (answerInDatabase != null)
                        {
                            dbContext.Answers.Remove(answerInDatabase);
                            dbContext.SaveChanges();
                        }
                    }
                    LoadCurrentPage();
                }
            }
        }

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            int maxQuestionID = 0;

            if (TableList.Count > 0)
            {
                maxQuestionID = TableList.Max(q => q.QuestionID);
            }

            var newQuestion = new Question
            {
                QuestionID = maxQuestionID + 1,
                Title = "Новый вопрос"
            };

            using (var dbContext = new Capital_Life_Insurance_LLCEntities())
            {
                dbContext.Question.Add(newQuestion);
                dbContext.SaveChanges();
            }

            TableList.Add(newQuestion);
            CountQuashion++;
            CountPage = (int)Math.Ceiling((double)CountQuashion / 1);
            PageListBox.ItemsSource = Enumerable.Range(1, CountPage).ToList();

            int newIndex = TableList.FindIndex(q => q.QuestionID == newQuestion.QuestionID);
            ChangePage(newIndex - CurrentPage);
        }

        private void DeleteQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPageList.Count > 0)
            {
                var currentQuestion = CurrentPageList[0];

                MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    using (var dbContext = new Capital_Life_Insurance_LLCEntities())
                    {
                        var answersToRemove = dbContext.Answers.Where(a => a.QuestionID == currentQuestion.QuestionID).ToList();

                        foreach (var answer in answersToRemove)
                        {
                            dbContext.Answers.Remove(answer);
                        }

                        var questionToRemove = dbContext.Question.FirstOrDefault(q => q.QuestionID == currentQuestion.QuestionID);
                        if (questionToRemove != null)
                        {
                            dbContext.Question.Remove(questionToRemove);
                        }

                        dbContext.SaveChanges();
                    }

                    TableList.Remove(currentQuestion);
                    CountQuashion--;
                    CountPage = (int)Math.Ceiling((double)CountQuashion / 1);
                    PageListBox.ItemsSource = Enumerable.Range(1, CountPage).ToList();
                    LoadCurrentPage();
                }
            }
        }
    }
}