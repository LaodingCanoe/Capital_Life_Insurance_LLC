using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Animation;
using static System.Net.Mime.MediaTypeNames;

namespace Capital_Life_Insurance_LLC
{
    public partial class QuashionsPage : Page
    {
        List<QuashionCandidateDto> CurrentPagelist = new List<QuashionCandidateDto>();
        List<QuashionCandidateDto> TableList;
        List<Grade> GradeList;
        int CountRecords;
        int CountPage;
        int CurrentPage = 0;
        int IDCandidate;
        int IDuser;

        int NumberQuashion = 1;

        public QuashionsPage(int IDCandidate, int IDuser)
        {
            InitializeComponent();
            this.IDCandidate = IDCandidate;
            this.IDuser = IDuser;

            TableList = LoadData();
            DataContext = this;  // Set the data context for binding
            ChangePage(0, 0);
        }

        private List<QuashionCandidateDto> LoadData()
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var query = from question in context.Question
                            join answer in context.Answers on question.QuestionID equals answer.QuestionID into qa
                            from answer in qa.DefaultIfEmpty()
                            join grade in context.Grade
                            on new { QuestionID = question.QuestionID, CandidateID = IDCandidate, UserID = IDuser }
                            equals new { grade.QuestionID, grade.CandidateID, grade.UserID } into g
                            from grade in g.DefaultIfEmpty()
                            select new
                            {
                                question,
                                answer,
                                grade
                            };

                var result = query.ToList()
                    .GroupBy(x => x.question.QuestionID)
                    .Select(g => new QuashionCandidateDto
                    {
                        Title = g.First().question.Title,
                        Answers = g.Where(x => x.answer != null)
                                   .Select(x => new AnswerDto
                                   {
                                       AnswerId = x.answer.AnswerId,
                                       AnswerTitle = x.answer.AnswerTitle,
                                       AnswerWeightCoefficient = x.answer.AnswerWeightCoefficient
                                   }).ToList(),
                        SelectedGrade = g.FirstOrDefault(x => x.grade != null)?.grade.Grade1 ?? 0.0
                    }).ToList();

                return result;
            }
        }




        private void ChangePage(int direction, int? selectedPage)
        {
            //TableList = LoadData();
            //CurrentPage = TableList.Count;
           
            CurrentPagelist.Clear();
            CountRecords = TableList.Count;
            
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
                            NumberQuashion++;
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
                            NumberQuashion--;
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
            }
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ChangePage(0, Convert.ToInt32(PageListBox.SelectedItem.ToString()) - 1);
            NumberQuashion = PageListBox.SelectedIndex + 1;
        }

        private void RightBT_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(2, null);
            NumberQuashion = PageListBox.SelectedIndex + 1;
        }

        private void LeftBT_Click(object sender, RoutedEventArgs e)
        {
            ChangePage(1, null);
            NumberQuashion = PageListBox.SelectedIndex + 1;
            СandidatePage candidatePage = new СandidatePage(0);
            candidatePage.UpdateCandidat();

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SaveGrade(int selectedAnswerId, double answerWeightCoefficient)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var user = context.Users.FirstOrDefault(u => u.UserID == IDuser);
                var question = context.Question.FirstOrDefault(q => q.QuestionID == NumberQuashion);

                if (user != null && question != null)
                {
                    double userWeightCoefficient = Convert.ToDouble(user.UserWeightCoefficient);
                    double quashionWeightCoefficient = question.QuashionWeightCoefficient;
                    double calculatedGrade = answerWeightCoefficient * quashionWeightCoefficient * userWeightCoefficient;

                    var currentGrade = context.Grade
                        .FirstOrDefault(g => g.UserID == IDuser && g.CandidateID == IDCandidate && g.QuestionID == NumberQuashion);

                    if (currentGrade == null)
                    {
                        Grade newGrade = new Grade
                        {
                            CandidateID = IDCandidate,
                            UserID = IDuser,
                            QuestionID = NumberQuashion,
                            Grade1 = calculatedGrade
                        };
                        context.Grade.Add(newGrade);
                    }
                    else
                    {
                        currentGrade.Grade1 = calculatedGrade;
                    }
                    context.SaveChanges();
                }
            }
        }

        private void AnswerRadioButton_Click(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null && radioButton.DataContext is AnswerDto selectedAnswer)
            {
                SaveGrade(selectedAnswer.AnswerId, selectedAnswer.AnswerWeightCoefficient);
            }
        }





    }

    public class QuashionCandidateDto
    {
        public string Title { get; set; }
        public List<AnswerDto> Answers { get; set; }
        public double SelectedGrade { get; set; }  // The calculated grade
    }

    public class AnswerDto
    {
        public int AnswerId { get; set; }
        public string AnswerTitle { get; set; }
        public double AnswerWeightCoefficient { get; set; }
    }

}
