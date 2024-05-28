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
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                InitializeComponent();
                this.IDCandidate = IDCandidate;
                this.IDuser = IDuser;

                // Загрузите сохраненные ответы
                /*
                var savedAnswers = Capital_Life_Insurance_LLCEntities.GetContext().Grade
                    .Where(g => g.CandidateID == IDCandidate && g.UserID == IDuser)
                    .ToList();*/
                TableList = LoadData();
                ChangePage(0, 0);
            }
        }

        private List<QuashionCandidateDto> LoadData()
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                var query = from quashion in context.Quashions
                            join grade in context.Grade
                            on new { quashion.QuashionID, CandidateID = IDCandidate, UserID = IDuser }
                            equals new { grade.QuashionID, grade.CandidateID, grade.UserID } into g
                            from grade in g.DefaultIfEmpty()
                            select new QuashionCandidateDto
                            {
                                Title = quashion.Title,
                                AnswerFirst = quashion.AnswerFirst,
                                AnswerSecond = quashion.AnswerSecond,
                                AnswerThrid = quashion.AnswerThrid,
                                First = grade != null && grade.Grade1 == 5,
                                Second = grade != null && grade.Grade1 == 3,
                                Thrid = grade != null && grade.Grade1 == 1
                            };
                return query.ToList();
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
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void FirstRadioBTN_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                // Используем context для запроса
                var currentGrade = context.Grade
                    .Where(p => p.UserID == IDuser && p.CandidateID == IDCandidate && p.QuashionID == NumberQuashion)
                    .ToList();

                if (currentGrade.Count() == 0)
                {
                    Grade _currentGrade = new Grade
                    {
                        CandidateID = IDCandidate,
                        UserID = IDuser,
                        QuashionID = NumberQuashion,
                        Grade1 = 5
                    };
                    context.Grade.Add(_currentGrade);
                    context.SaveChanges();
                }
                else
                {
                    // Возможно, обновление существующей записи?
                    var existingGrade = currentGrade.First();
                    existingGrade.Grade1 = 5;
                    context.SaveChanges();
                }
            }

        }
        
        private void SecondRadioBTN_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                // Используем context для запроса
                var currentGrade = context.Grade
                    .Where(p => p.UserID == IDuser && p.CandidateID == IDCandidate && p.QuashionID == NumberQuashion)
                    .ToList();

                if (currentGrade.Count() == 0)
                {
                    Grade _currentGrade = new Grade
                    {
                        CandidateID = IDCandidate,
                        UserID = IDuser,
                        QuashionID = NumberQuashion,
                        Grade1 = 3
                    };
                    context.Grade.Add(_currentGrade);
                    context.SaveChanges();
                }
                else
                {
                    // Возможно, обновление существующей записи?
                    var existingGrade = currentGrade.First();
                    existingGrade.Grade1 = 5;
                    context.SaveChanges();
                }
            }
        }

        private void ThirdRadioBTN_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new Capital_Life_Insurance_LLCEntities())
            {
                // Используем context для запроса
                var currentGrade = context.Grade
                    .Where(p => p.UserID == IDuser && p.CandidateID == IDCandidate && p.QuashionID == NumberQuashion)
                    .ToList();

                if (currentGrade.Count() == 0)
                {
                    Grade _currentGrade = new Grade
                    {
                        CandidateID = IDCandidate,
                        UserID = IDuser,
                        QuashionID = NumberQuashion,
                        Grade1 = 1
                    };
                    context.Grade.Add(_currentGrade);
                    context.SaveChanges();
                }
                else
                {
                    // Возможно, обновление существующей записи?
                    var existingGrade = currentGrade.First();
                    existingGrade.Grade1 = 5;
                    context.SaveChanges();
                }
            }
        }
    }

    public class QuashionCandidateDto
    {
        public string Title { get; set; }
        public string AnswerFirst { get; set; }
        public string AnswerSecond { get; set; }
        public string AnswerThrid { get; set; }
        public bool First { get; set; }
        public bool Second { get; set; }
        public bool Thrid { get; set; }
        
    }
}
