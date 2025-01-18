using System.Linq;
using System.Windows;

namespace DBStore
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;

            using (var context = new LibraryContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    OpenUserWindow(user.Role);
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void OpenUserWindow(string role)
        {
            Window window;

            switch (role)
            {
                case "Guest":
                    window = new GuestWindow();
                    break;
                case "User":
                    window = new UserWindow();
                    break;
                case "Employee":
                case "Director": // Директор использует то же окно, что и сотрудник
                    window = new EmployeeWindow();
                    break;
                default:
                    window = new GuestWindow();
                    break;
            }

            window.Show();
            this.Close();
        }
        Window.Show();
            this.Close();
        }
    }
}