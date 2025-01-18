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
using System.Windows.Shapes;

namespace Notes
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void CloseRegistrationWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GoToMainPage(object sender, EventArgs e)
        {
            string userLogin = Login.Text;
            string userPassword = Password.Password;
            string userRepeatPassword = RepeatPassword.Password;

            bool isUserLoginEmpty = string.IsNullOrWhiteSpace(userLogin);
            if (isUserLoginEmpty)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }

            bool isUserPasswordEmpty = string.IsNullOrWhiteSpace(userPassword);
            if (isUserPasswordEmpty)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }

            bool isUserRepeatPasswordEmpty = string.IsNullOrWhiteSpace(userRepeatPassword);
            if (isUserRepeatPasswordEmpty)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка");
                return;
            }

            bool isUserExistByLogin = UserData.Users.Any(x => x.Login == userLogin);
            if (isUserExistByLogin)
            {
                MessageBox.Show("Этот логин уже занят!", "Ошибка");
                return;
            }

            bool isPasswordRepeatSucceded = userPassword == userRepeatPassword;
            if (!isPasswordRepeatSucceded)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка");
                return;
            }

            UserData.Users.Add(new User(UserData.Users.Count + 1, userLogin, userPassword));

            Close();
        }
    }
}
