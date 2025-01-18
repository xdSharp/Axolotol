using System.Windows;

namespace DBStore
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            using (var context = new LibraryContext())
            {
                var user = new User { Login = login, Password = password, Role = "User" };
                context.Users.Add(user);
                context.SaveChanges();
            }

            MessageBox.Show("Регистрация успешна.");
            this.Close();
        }
    }
}