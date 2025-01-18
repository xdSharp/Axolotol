using System.Linq;
using System.Windows;

namespace DBStore
{
    public partial class EditBookWindow : Window
    {
        private int _bookId;

        public EditBookWindow(int bookId)
        {
            InitializeComponent();
            _bookId = bookId;
            LoadBook();
        }

        private void LoadBook()
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == _bookId);
                if (book != null)
                {
                    TitleBox.Text = book.Title;
                    AuthorBox.Text = book.Author;
                    YearBox.Text = book.Year.ToString();
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Id == _bookId);
                if (book != null)
                {
                    book.Title = TitleBox.Text;
                    book.Author = AuthorBox.Text;
                    book.Year = int.Parse(YearBox.Text);
                    context.SaveChanges();
                }
            }

            this.Close();
        }
    }
}