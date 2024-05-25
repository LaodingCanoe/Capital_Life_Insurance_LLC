using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Capital_Life_Insurance_LLC
{
    public partial class QuashionsPage : Page
    {
        List<Quashions> CurrentPagelist = new List<Quashions>();
        List<Quashions> TableList;
        int CountRecords;
        int CountPage;
        int CurrentPage = 0;

        public QuashionsPage()
        {
            InitializeComponent();
            TableList = Capital_Life_Insurance_LLCEntities.GetContext().Quashions.ToList();
            CountRecords = TableList.Count;
            ChangePage(0, 0);
        }

        private void ChangePage(int direction, int? selectedPage)
        {
            CurrentPagelist.Clear();

            CountPage = (int)Math.Ceiling((double)CountRecords / 1);

            var ifUpdate = true;
            int min;
            if (selectedPage.HasValue)
            {
                if (selectedPage >= 0 && selectedPage < CountPage)
                {
                    CurrentPage = (int)selectedPage;
                    min = CurrentPage + 1;
                    for (int i = CurrentPage; i < min; i++)
                    {
                        CurrentPagelist.Add(TableList[i]);
                    }
                }
            }
            else
            {
                switch (direction)
                {
                    case 1:
                        if (CurrentPage > 0)
                        {
                            CurrentPage--;
                            min = CurrentPage + 1;
                            for (int i = CurrentPage; i < min; i++)
                            {
                                CurrentPagelist.Add(TableList[i]);
                            }
                        }
                        else
                        {
                            ifUpdate = false;
                        }
                        break;
                    case 2:
                        if (CurrentPage < CountPage - 1)
                        {
                            CurrentPage++;
                            min = CurrentPage + 1;
                            for (int i = CurrentPage; i < min; i++)
                            {
                                CurrentPagelist.Add(TableList[i]);
                            }
                        }
                        else
                        {
                            ifUpdate = false;
                        }
                        break;
                }
            }

            if (ifUpdate)
            {
                PageListBox.Items.Clear();
                for (int i = 1; i <= CountPage; i++)
                {
                    PageListBox.Items.Add(i);
                }
                PageListBox.SelectedIndex = CurrentPage;

                QuestionListView.ItemsSource = CurrentPagelist;
                QuestionListView.Items.Refresh();

                SaveButton.Visibility = TableList.All(q => q.IsAnswered) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ChangePage(0, PageListBox.SelectedIndex);
        }

        private void RightBT_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(2, null);
        }

        private void LeftBT_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(1, null);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                foreach (var question in TableList)
                {
                    var grade = new Grade
                    {
                        QuashionID = question.QuashionID,
                        Grade1 = question.IsAnswerFirstSelected ? 5 :
                                 question.IsAnswerSecondSelected ? 3 : 1
                    };
                    context.Grade.Add(grade);
                }
                context.SaveChanges();
            }

            MessageBox.Show("Результаты успешно сохранены!", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            
                var radioButton = sender as RadioButton;
                if (radioButton == null) return;

                var question = radioButton.DataContext as Quashions;
                if (question == null) return;

                string answer = null;
                switch (radioButton.Name)
                {
                    case "First":
                        answer = nameof(question.IsAnswerFirstSelected);
                        break;
                    case "Second":
                        answer = nameof(question.IsAnswerSecondSelected);
                        break;
                    case "Third":
                        answer = nameof(question.IsAnswerThirdSelected);
                        break;
                    default:
                        break;
                }

                if (answer != null)
                {
                foreach (var prop in typeof(Quashions).GetProperties())
                {
                    if (prop.Name.Contains("Answer"))
                    {
                        if (prop.Name != answer)
                        {
                            prop.SetValue(question, false);
                        }
                        else
                        {
                            prop.SetValue(question, true);
                        }
                    }
                }
                    radioButton.IsChecked = true;
                    question.GetType().GetProperty(answer)?.SetValue(question, true);

                    // Сохраняем выбранный ответ в базу данных
                    using (var context = new Capital_Life_Insurance_LLCEntities())
                    {
                        var grade = new Grade
                        {
                            QuashionID = question.QuashionID,
                            Grade1 = question.IsAnswerFirstSelected ? 5 :
                                     question.IsAnswerSecondSelected ? 3 :
                                     question.IsAnswerThirdSelected ? 1 : 0 // По умолчанию 0
                        };
                        context.Grade.Add(grade);
                        context.SaveChanges();
                    }
                }

                SaveButton.Visibility = TableList.All(q => q.IsAnswered) ? Visibility.Visible : Visibility.Collapsed;
            
            
        }

    }
}
