using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
{
    public partial class UserEditPage : Page
    {
        private Users _currentUsers = new Users();
        public UserEditPage(Users UserSelected)
        {
            InitializeComponent();
            var _currentRole = Capital_Life_Insurance_LLCEntities.GetContext().Role.ToList();
            RoleCB.ItemsSource = _currentRole;
            if (UserSelected != null)
            {
                this._currentUsers = UserSelected;
                LoginTBl.Visibility = Visibility.Hidden;
                LoginTB.Visibility = Visibility.Hidden;
                PasswordTBl.Visibility = Visibility.Hidden;
                PasswordTB.Visibility = Visibility.Hidden;
                DeleteBT.Visibility = Visibility.Visible;
                RoleCB.SelectedIndex = UserSelected.RoleID-1;

            }            

            DataContext = _currentUsers;
            PhoneTB.Loaded += (s, e) =>
            {
                DataObject.AddPastingHandler(PhoneTB, PhoneNumberTextBox_Pasting);
            };
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
            if (RoleCB.SelectedItem == null)
                errors.AppendLine("Укажите роль пользователя");
            if (_currentUsers.UserID == 0)
            {
                if (PasswordTB.Password.Length < 6)
                    errors.AppendLine("Пароль должен быть больше 6 символов");
                if (!PasswordTB.Password.Any(char.IsDigit))
                    errors.AppendLine("Пароль должен содержать цифры");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                _currentUsers.FirstName = FirstNameTB.Text;
                _currentUsers.Name = NameTB.Text;
                _currentUsers.Patranomic = PatranomicTB.Text;
                _currentUsers.Phone = PhoneTB.Text;
                _currentUsers.Email = EmailTB.Text;
                _currentUsers.RoleID = RoleCB.SelectedIndex + 1;
                if(_currentUsers.UserID == 0)
                {
                    _currentUsers.Login = LoginTB.Text;
                    _currentUsers.Password = PasswordTB.Password;
                    var AllUsers = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
                    AllUsers = AllUsers.Where(p => p.Login == LoginTB.Text).ToList();
                    if(AllUsers.Count>0)
                    {
                        MessageBox.Show("Данный пользователь уже существует");
                    }
                    else
                    {
                        Capital_Life_Insurance_LLCEntities.GetContext().Users.Add(_currentUsers);
                        try
                        {
                            Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
                            MessageBox.Show("Пользователь добавлен");
                            Manager.MainFrame.GoBack();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
                else
                {
                    Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    Manager.MainFrame.GoBack();
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
            Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]+$");
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
        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            var currentDelete = (sender as Button).DataContext as Users;            
            if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание!",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Capital_Life_Insurance_LLCEntities.GetContext().Users.Remove(currentDelete);
                    Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
                    Manager.MainFrame.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
