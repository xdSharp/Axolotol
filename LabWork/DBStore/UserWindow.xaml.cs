using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DBStore
{
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            LoadBooks();
        }

        private void LoadBooks()
        {
            using (var context = new LibraryContext())
            {
                BooksListView.ItemsSource = context.Books.ToList();
            }
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int bookId = (int)button.Tag;

            using (var context = new LibraryContext())
            {
                var order = new Order { BookId = bookId, UserId = CurrentUser.Id, Status = "Pending" };
                context.Orders.Add(order);
                context.SaveChanges();
            }

            MessageBox.Show("Заказ оформлен.");
        }
    }
}