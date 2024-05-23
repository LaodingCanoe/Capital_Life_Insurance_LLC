using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private Users _users = new Users();
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = _users;
        }

        private void Registration_end_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(FirstName.Text))
                errors.AppendLine("Укажите фамилию");
            if (string.IsNullOrWhiteSpace(Name.Text))
                errors.AppendLine("Укажите имя");
            if (Phone.Text.Length < 10)
                errors.AppendLine("Укажите верный номер телефона");
            if (!IsValidEmail(Email.Text))
                errors.AppendLine("Укажите верный email");
            if (Password.Text.Length < 6)
                errors.AppendLine("Пароль должен быть больше 6 символов");
            if (!Password.Text.Any(char.IsDigit))
                errors.AppendLine("Пароль должен содержать цифры");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                _users.FirstName = FirstName.Text;
                _users.Name = Name.Text;
                _users.Patranomic = Patronomic.Text;
                _users.Phone = "+7" + Phone.Text;
                _users.Email = Email.Text;
                _users.Login = Login.Text;
                _users.Password = Password.Text;
                _users.RoleID = 4;
                var AllUsers = Capital_Life_Insurance_LLCEntities.GetContext().Users.ToList();
                AllUsers = AllUsers.Where(p => p.Login == Login.Text).ToList();

                if (AllUsers.Count == 0)
                {
                    if (_users.UserID == 0)
                        Capital_Life_Insurance_LLCEntities.GetContext().Users.Add(_users);
                    try
                    {
                        Capital_Life_Insurance_LLCEntities.GetContext().SaveChanges();
                        MessageBox.Show("Регистрация успешна");
                        Manager.MainFrame.Navigate(new СandidatePage(_users.UserID - 1));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Данный пользователь уже существует");
                }
            }
        }

        // Проверка корректности email
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            // Убедитесь, что @ находится перед точкой, и обе эти символы присутствуют
            return atIndex > 0 && dotIndex > atIndex;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text.Length > 0)
            {
                int caretIndex = textBox.SelectionStart;
                textBox.TextChanged -= TextBox_TextChanged; // Отписываемся от события, чтобы избежать рекурсии
                textBox.Text = char.ToUpper(textBox.Text[0]) + textBox.Text.Substring(1);
                textBox.SelectionStart = caretIndex; // Устанавливаем курсор в то же положение
                textBox.TextChanged += TextBox_TextChanged; // Повторно подписываемся на событие
            }
        }

        // Обработчик для запрета ввода пробелов
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || (e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.OemMinus || e.Key == Key.OemPlus || e.Key == Key.OemQuestion || e.Key == Key.OemPeriod || e.Key == Key.OemComma || e.Key == Key.OemQuotes || e.Key == Key.OemSemicolon)
            {
                e.Handled = true;
            }
        }
        
        // Обработчик для запрета вставки пробелов через клавиши (например, Ctrl+V)
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space || (e.Key >= Key.D0 && e.Key <= Key.D9) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || e.Key == Key.OemMinus || e.Key == Key.OemPlus || e.Key == Key.OemQuestion || e.Key == Key.OemPeriod || e.Key == Key.OemComma || e.Key == Key.OemQuotes || e.Key == Key.OemSemicolon)
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

            if (!IsTextNumber(e.Text) || textBox.Text.Length >= 10)
            {
                e.Handled = true;
            }
        }

        // Обработчик для запрета вставки нецифровых символов через буфер обмена
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

        // Обработчик для запрета ввода нецифровых символов через клавиши
        private void PhoneNumberTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        // Проверка допустимого текста (только цифры)
        private bool IsTextNumber(string text)
        {
            Regex regex = new Regex(@"^[0-9]+$"); // Только цифры
            return regex.IsMatch(text);
        }

        
    }

}

