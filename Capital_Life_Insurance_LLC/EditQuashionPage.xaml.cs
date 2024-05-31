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
        private Capital_Life_Insurance_LLCEntities context;
        private List<Question> TableList = new List<Question>();
        private int CurrentPage = 0;
        private int CountQuashion;
        private int CountPage;

        public EditQuashionPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (context = new Capital_Life_Insurance_LLCEntities())
            {
                var query = from question in context.Question
                            select question;

                TableList = query.ToList();
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
            if (CurrentPageList.Count > 0)
            {
                SaveCurrentQuashion();
            }

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
            if (TableList.Count > 0)
            {
                CurrentPageList.Add(TableList[CurrentPage]);
                var question = CurrentPageList[0];
                Title.Text = question.Title;

                using (context = new Capital_Life_Insurance_LLCEntities())
                {
                    var answers = context.Answers.Where(x => x.QuestionID == question.QuestionID).ToList();
                    AnswerList.ItemsSource = answers;
                }
            }
        }

        private void SaveCurrentQuashion()
        {
            using (var dbContext = new Capital_Life_Insurance_LLCEntities())
            {
                var questionInDatabase = dbContext.Question.Find(TableList[CurrentPage].QuestionID);
                if (questionInDatabase != null)
                {
                    questionInDatabase.Title = Title.Text;

                    var answersInDatabase = dbContext.Answers.Where(p => p.QuestionID == questionInDatabase.QuestionID).ToList();
                    for (int i = 0; i < answersInDatabase.Count; i++)
                    {
                        var answerItem = (Answers)AnswerList.Items[i];
                        answersInDatabase[i].AnswerTitle = answerItem.AnswerTitle;
                        answersInDatabase[i].AnswerWeightCoefficient = answerItem.AnswerWeightCoefficient;
                    }

                    dbContext.SaveChanges();

                    // Update local data
                    TableList[CurrentPage].Title = Title.Text;
                }
            }
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (PageListBox.SelectedItem != null)
            {
                SaveCurrentQuashion();
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
    }
}
