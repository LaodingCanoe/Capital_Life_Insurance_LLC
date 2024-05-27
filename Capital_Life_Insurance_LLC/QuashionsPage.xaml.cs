using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        List<Quashions> CurrentPagelist = new List<Quashions>();
        List<Quashions> TableList;
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
            
            TableList = Capital_Life_Insurance_LLCEntities.GetContext().Quashions.ToList();
            GradeList = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();

            // Загрузите сохраненные ответы
            var savedAnswers = Capital_Life_Insurance_LLCEntities.GetContext().Grade
                .Where(g => g.CandidateID == IDCandidate && g.UserID == IDuser)
                .ToList();
                
            CountRecords = TableList.Count;
            ChangePage(0, 0);
        }

        private List<QuashionCandidateDto> LoadData()
        {
            using (var context = Capital_Life_Insurance_LLCEntities.GetContext())
            {
                var query = from quashion in context.Quashions
                            join grade in context.Grade on quashion.QuashionID equals grade.QuashionID into g
                            from grade in g.DefaultIfEmpty()
                            where grade.CandidateID == IDCandidate && grade.UserID == IDuser
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

        private string Grade(int? q)
        {
            var currentGrade = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();
            string GradeCandidate;
            currentGrade = currentGrade.Where(p => p.QuashionID == q && p.UserID == IDuser && p.CandidateID == IDCandidate).ToList();
            GradeCandidate = currentGrade.ToString();
            return GradeCandidate;

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

                QuestionListView.ItemsSource = LoadData();
                QuestionListView.Items.Refresh();
            }

           /* string GradeCandidate = Grade(selectedPage + 1);
            switch (GradeCandidate)
            {
                case "5":
                    {
                        First.Is
                    }
                break ;
            }*/
        }

        private void PageListBox_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ChangePage(0, PageListBox.SelectedIndex);
            NumberQuashion = PageListBox.SelectedIndex+1;
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
            var currentGrades = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();
            Grade _currentGrade = new Grade();
            _currentGrade.CandidateID = IDCandidate;
            _currentGrade.UserID = IDuser;
            _currentGrade.QuashionID = NumberQuashion;
            _currentGrade.Grade1 = 5;
            Capital_Life_Insurance_LLCEntities.GetContext().Grade.Add(_currentGrade);
            Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
            if (_currentGrade.QuashionID !=NumberQuashion && _currentGrade.CandidateID !=IDCandidate && _currentGrade.UserID!=IDuser)
            {             

                
            }
        }

        private void SecondRadioBTN_Click(object sender, RoutedEventArgs e)
        {
            var currentGrades = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();
            Grade _currentGrade = new Grade();
            _currentGrade.CandidateID = IDCandidate;
            _currentGrade.UserID = IDuser;
            _currentGrade.QuashionID = NumberQuashion;
            _currentGrade.Grade1 = 3;
            Capital_Life_Insurance_LLCEntities.GetContext().Grade.Add(_currentGrade);
            Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
        }

        private void ThirdRadioBTN_Click(object sender, RoutedEventArgs e)
        {
            var currentGrades = Capital_Life_Insurance_LLCEntities.GetContext().Grade.ToList();
            Grade _currentGrade = new Grade();
            _currentGrade.CandidateID = IDCandidate;
            _currentGrade.UserID = IDuser;
            _currentGrade.QuashionID = NumberQuashion;
            _currentGrade.Grade1 = 1;
            Capital_Life_Insurance_LLCEntities.GetContext().Grade.Add(_currentGrade);
            Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
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
