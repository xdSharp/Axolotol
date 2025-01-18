using System.Linq;
using System.Windows;

namespace DBStore
{
    public partial class GuestWindow : Window
    {
        public GuestWindow()
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
    }
}