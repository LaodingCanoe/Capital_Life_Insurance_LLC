using System;
using System.Collections.Generic;
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
    public partial class СandidatePage : Page
    {
        List<CandidateCard> CandidateCardsPage = new List<CandidateCard>();
        public СandidatePage(int id)
        {
            InitializeComponent();
            CandidateCardsPage = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();            
            CandidateList.ItemsSource = CandidateCardsPage;
            FiterCB.SelectedIndex = 0;
            SortCB.SelectedIndex = 0;
        }

        //Код для обновление страницы
        private void UpdateCandidat()
        {
            var currentCandidate = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();

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

            /* if (SortCB.SelectedIndex == 1)
             {
                 currentCandidate = currentCandidate.OrderBy(p => p.GenderCode == "ж").ToList();
             }
             else if (FiterCB.SelectedIndex == 2)
             {
                 currentCandidate = currentCandidate.Where(p => p.GenderCode == "м").ToList();
             }*/

            currentCandidate = currentCandidate.Where(p => p.FIO.ToLower().Contains(SearchTB.Text.ToLower()) || p.Phone.ToLower().Contains(SearchTB.Text.ToLower()) || p.Email.ToLower().Contains(SearchTB.Text.ToLower())).ToList();

            CandidateList.ItemsSource = currentCandidate;

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
    }
}