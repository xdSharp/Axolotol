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

namespace Notes
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenMenuWindow(object sender, RoutedEventArgs e)
        {
            string userLogin = Login.Text;
            string userPassword = Password.Password;

            bool isUserlLoginEmpty = string.IsNullOrWhiteSpace(userLogin);
            if (isUserlLoginEmpty)
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

            bool isLoginSucceded = UserData.Users.Any(x => x.Login == userLogin && x.Password == userPassword);
            if (!isLoginSucceded)
            {
                MessageBox.Show("Проверьте пароль и логин, либо пройдите регистрацию!", "Ошибка");
                return;
            }

            MessageBox.Show("Авторизация прошла успешно!", "Успех");

            var menuWindow = new MenuWindow();
            App.Current.MainWindow = menuWindow;
            menuWindow.Show();
            Close();
        }

        private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            var secondWindow = new RegistrationWindow();
            secondWindow.ShowDialog();
        }
    }
}
