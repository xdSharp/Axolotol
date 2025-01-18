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
using static Notes.MenuWindow;

namespace Notes
{

    public partial class EditWindow : Window
    {
        public Note EditedNote { get; private set; }

        public event EventHandler<NoteEventArgs> NoteEdited;
        public EditWindow(Note note)
        {
            InitializeComponent();
            EditedNote = note;

            NameEdit.Text = note.Name;
            CategoryCMBEdit.ItemsSource = new List<string> { "Личная", "Срочная", "Важная" };
            CategoryCMBEdit.Text = note.Category;
            ContentEdit.Text = note.Content;
        }

        private void GoToMenuWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void SaveEditNote(object sender, RoutedEventArgs e)
        {
            EditedNote.Name = NameEdit.Text;
            EditedNote.Category = CategoryCMBEdit.Text;
            EditedNote.Content = ContentEdit.Text;

            MessageBox.Show("Данные обновлены", "Успех", MessageBoxButton.OK);
            this.Close();

        }

        private void CategoryCMBEdit_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class NoteEventArgs : EventArgs
    {
        public Note Note { get; }

        public NoteEventArgs(Note note)
        {
            Note = note;
        }
    }

}
