using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Capital_Life_Insurance_LLC
{
    public partial class EditQuashionPage : Page
    {
        private ObservableCollection<Quashions> CurrentPageList = new ObservableCollection<Quashions>();
        private Capital_Life_Insurance_LLCEntities context;
        List<Quashions> TableList = new List<Quashions>();
        int CurrentPage = 0;
        int CountQuashion;
        int CountPage;

        public EditQuashionPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (context = new Capital_Life_Insurance_LLCEntities())
            {
                var query = from quashion in context.Quashions
                            select quashion;

                TableList = query.ToList();
                CountQuashion = TableList.Count();
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
                var quashion = CurrentPageList[0];

                Title.Text = quashion.Title;
                AnswerFirst.Text = quashion.AnswerFirst;
                AnswerSecond.Text = quashion.AnswerSecond;
                AnswerThid.Text = quashion.AnswerThrid;
            }
        }

        private void SaveCurrentQuashion()
        {
            using (var dbContext = new Capital_Life_Insurance_LLCEntities())
            {
                var quashionInDatabase = dbContext.Quashions.Find(TableList[CurrentPage].QuashionID);
                if (quashionInDatabase != null)
                {
                    quashionInDatabase.Title = Title.Text;
                    quashionInDatabase.AnswerFirst = AnswerFirst.Text;
                    quashionInDatabase.AnswerSecond = AnswerSecond.Text;
                    quashionInDatabase.AnswerThrid = AnswerThid.Text;

                    dbContext.SaveChanges();

                    // Обновляем локальные данные
                    TableList[CurrentPage].Title = Title.Text;
                    TableList[CurrentPage].AnswerFirst = AnswerFirst.Text;
                    TableList[CurrentPage].AnswerSecond = AnswerSecond.Text;
                    TableList[CurrentPage].AnswerThrid = AnswerThid.Text;
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