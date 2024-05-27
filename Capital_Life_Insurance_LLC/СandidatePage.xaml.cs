using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Capital_Life_Insurance_LLC
{
    public partial class СandidatePage : Page
    {
        List<CandidateCard> CandidateCardsPage = new List<CandidateCard>();

        public СandidatePage(int id)
        {
            InitializeComponent();
            LoadCandidates();
            FiterCB.SelectedIndex = 0;
            SortCB.SelectedIndex = 0;
        }

        private void LoadCandidates()
        {
            CandidateCardsPage = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();
            UpdateCandidates();
        }

        private void UpdateCandidates()
        {
            var currentCandidate = CandidateCardsPage;

            if (FiterCB.SelectedIndex > 0)
            {
                var selectedPosition = (FiterCB.SelectedItem as ComboBoxItem).Content.ToString();
                if (selectedPosition != "Всё")
                {
                    currentCandidate = currentCandidate.Where(p => p.PositionToString == selectedPosition).ToList();
                }
            }
            /*
            if (SortCB.SelectedIndex == 1)
            {
                currentCandidate = currentCandidate.OrderBy(p => p.Score).ToList();
            }
            else if (SortCB.SelectedIndex == 2)
            {
                currentCandidate = currentCandidate.OrderByDescending(p => p.Score).ToList();
            }*/

            currentCandidate = currentCandidate.Where(p => p.FIO.ToLower().Contains(SearchTB.Text.ToLower()) ||
                                                           p.Phone.ToLower().Contains(SearchTB.Text.ToLower()) ||
                                                           p.Email.ToLower().Contains(SearchTB.Text.ToLower())).ToList();

            CandidateList.ItemsSource = currentCandidate;
        }

        private void FiterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCandidates();
        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCandidates();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCandidates();
        }

        private void EditBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage(null));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage((sender as Button).DataContext as CandidateCard));
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CandidateAddEditPage((sender as Button).DataContext as CandidateCard));
            
        }
    }
}
