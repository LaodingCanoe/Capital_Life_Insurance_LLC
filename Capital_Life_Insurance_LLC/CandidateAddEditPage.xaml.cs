using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
{    public partial class CandidateAddEditPage : Page
    {
        private CandidateCard _currenCandidate = new CandidateCard();
        private int IDCandidate = 0;
        private int IDUser = 0;
        public CandidateAddEditPage(CandidateCard CandidateSelected, int id)
        {
            InitializeComponent();
            var context = Capital_Life_Insurance_LLCEntities.GetContext();
            var educations = context.Education.ToList();
            var _currentPosition = Capital_Life_Insurance_LLCEntities.GetContext().Positions.ToList();
            MultiSelectListBox.ItemsSource = educations;
            IDUser = id;
            PositionCB.ItemsSource = _currentPosition;
            if (CandidateSelected != null)
            {
                _currenCandidate = CandidateSelected;
                IDCandidate = _currenCandidate.CandidateID;
                PositionCB.SelectedIndex = CandidateSelected.Position - 1;
                DeleteBT.Visibility = Visibility.Visible;

                foreach (var candidateEducation in _currenCandidate.CandidateEducation)
                {
                    var education = educations.FirstOrDefault(e => e.EducationID == candidateEducation.Education);
                    if (education != null)
                    {
                        MultiSelectListBox.SelectedItems.Add(education);
                    }
                }
            }
            else
            {
                Bithday.Text = "01.01.1950";
            }
            DataContext = _currenCandidate;
        }
        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(FirstNameTB.Text))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(NameTB.Text))
                errors.AppendLine("Укажите имя");
            if (PhoneTB.Text.Length < 12)
                errors.AppendLine("Укажите верный номер телефона");
            if (!IsValidEmail(EmailTB.Text))
                errors.AppendLine("Укажите верный email");
            if (PositionCB.SelectedItem == null)
                errors.AppendLine("Укажите желаемую должность");
            if (Bithday.Text == "")
            {
                errors.AppendLine("Укаажите дату рождения");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                _currenCandidate.FirstName = FirstNameTB.Text;
                _currenCandidate.Name = NameTB.Text;
                _currenCandidate.Patranomic = PatranomicTB.Text;
                _currenCandidate.Phone = PhoneTB.Text;
                _currenCandidate.Email = EmailTB.Text;
                _currenCandidate.Position = PositionCB.SelectedIndex + 1;
                _currenCandidate.Bithday = Convert.ToDateTime(Bithday.Text);
                _currenCandidate.CreateUserID = IDUser;
                _currenCandidate.CandidateEducation.Clear();
                foreach (var education in MultiSelectListBox.SelectedItems.Cast<Education>())
                {
                    _currenCandidate.CandidateEducation.Add(new CandidateEducation
                    {
                        Candidate = _currenCandidate.CandidateID,
                        Education = education.EducationID
                    });
                }
                if (_currenCandidate.CandidateID == 0)
                {
                    Capital_Life_Insurance_LLCEntities.GetContext().CandidateCard.Add(_currenCandidate);                    
                }                   
                try
                {                    
                    Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
                    MessageBox.Show("Кандидат добавлен");
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            var currentDelete = (sender as Button).DataContext as CandidateCard;
            if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new Capital_Life_Insurance_LLCEntities())
                    {
                        var candidateToDelete = context.CandidateCard
                            .Include(c => c.Grade) 
                            .Include(c => c.CandidateEducation) 
                            .FirstOrDefault(c => c.CandidateID == currentDelete.CandidateID);
                        if (candidateToDelete != null)
                        {
                            context.Grade.RemoveRange(candidateToDelete.Grade);
                            context.CandidateEducation.RemoveRange(candidateToDelete.CandidateEducation);
                            context.CandidateCard.Remove(candidateToDelete);
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show("Кандидат и связанные записи удалены.");
                    Manager.MainFrame.GoBack();                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');
            return atIndex > 0 &&
                   dotIndex > atIndex + 1 &&  
                   email.Length > dotIndex + 1 && 
                   !email.Substring(dotIndex + 1).Contains('.');
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.Length > 0)
            {
                int caretIndex = textBox.SelectionStart;
                textBox.TextChanged -= TextBox_TextChanged;
                textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1);
                textBox.SelectionStart = caretIndex;
                textBox.TextChanged += TextBox_TextChanged;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }        
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = (string)e.DataObject.GetData(DataFormats.Text);
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private bool IsTextAllowed(string text)
        {
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]+$"); // Только буквы
            return regex.IsMatch(text);
        }
        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!IsTextNumber(e.Text) || textBox.Text.Length >= 12)
            {
                e.Handled = true;
            }
        }
        private void PhoneNumberTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                string text = (string)e.DataObject.GetData(DataFormats.Text);
                if (!IsTextNumber(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        private void PhoneNumberTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private bool IsTextNumber(string text)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(text);
        }
        private void PhoneTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!textBox.Text.StartsWith("+7"))
            {
                textBox.TextChanged -= PhoneTB_TextChanged;
                textBox.Text = "+7" + textBox.Text;
                textBox.SelectionStart = textBox.Text.Length;
                textBox.TextChanged += PhoneTB_TextChanged;
            }
        }
        private void ImageBT_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myOpenFileDialog = new OpenFileDialog();
            if (myOpenFileDialog.ShowDialog() == true)
            {
                _currenCandidate.PhotoPath = myOpenFileDialog.FileName;
                PhotoIM.Source = new BitmapImage(new Uri(myOpenFileDialog.FileName));
            }
        }
    }
}