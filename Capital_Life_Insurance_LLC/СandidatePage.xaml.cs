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
        public СandidatePage(int id)
        {
            InitializeComponent();
            CandidateCardsPage = Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.ToList();            
            CandidateList.ItemsSource = CandidateCardsPage;
            FiterCB.SelectedIndex = 0;
            SortCB.SelectedIndex = 0;
        }

        private void FiterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SortCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
