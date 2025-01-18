using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DBStore
{
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            LoadBooks();
            LoadOrders();
        }

        private void LoadBooks()
        {
            using (var context = new LibraryContext())
            {
                BooksListView.ItemsSource = context.Books.ToList();
            }
        }

        private void LoadOrders()
        {
            using (var context = new LibraryContext())
            {
                OrdersDataGrid.ItemsSource = context.Orders.Include("Book").Include("User").ToList();
            }
        }

        private void EditBookButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int bookId = (int)button.Tag;

            var editWindow = new EditBookWindow(bookId);
            editWindow.ShowDialog();
            LoadBooks();
        }

        private void ConfirmOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int orderId = (int)button.Tag;

            using (var context = new LibraryContext())
            {
                var order = context.Orders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    order.Status = "Confirmed";
                    context.SaveChanges();
                }
            }

            LoadOrders();
        }
    }
}