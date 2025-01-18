using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


    public partial class MenuWindow : Window
    {
        public ObservableCollection<Note> Notes { get; set; }
        public MenuWindow()
        {
            InitializeComponent();
            Notes = new ObservableCollection<Note>
            {
                new Note { Id = 1, Name = "Мысль1", Category = "Личная", Content = "бла бла бла бла бла бла бла бла бла бла бла бла" },
                new Note { Id = 2, Name = "Задачи1", Category = "Срочная", Content = "бла бла бла бла бла бла" },
                new Note { Id = 3, Name = "Работа", Category = "Важная", Content = "бла бла бла бла бла бла бла бла бла бла бла бла бла бла бла бла бла бла" },
                new Note { Id = 4, Name = "Мысль2", Category = "Личная", Content = "бла бла бла бла бла бла" },
                new Note { Id = 5, Name = "Задачи2", Category = "Срочная", Content = "бла бла бла бла бла бла" }

            };
            dg.ItemsSource = Notes;
        }

        private void GoToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void GoToAddWindow(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
          
        }
        private void EditNote(object sender, RoutedEventArgs e)
        {

            if (dg.SelectedItem != null)
            {   var selectedNote = dg.SelectedItem as Note; 
                EditWindow editWindow = new EditWindow(selectedNote);
                editWindow.NoteEdited += (s, args) => 
                {
                var noteToUpdate = Notes.FirstOrDefault(note => note.Id == args.Note.Id);
                if (noteToUpdate != null)
                {
                    noteToUpdate.Name = args.Note.Name;
                    noteToUpdate.Category = args.Note.Category;
                    noteToUpdate.Content = args.Note.Content;
                }
            };
                editWindow.Show();
            }
            else
            {
                MessageBox.Show("Выберите заметку для редактирования");
            }
        }

        private void DeleteNote(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItems.Count > 0)
            {
                var selectedProduct = dg.SelectedItem as Note;
                if (selectedProduct != null)
                {
                    Notes.Remove(selectedProduct);
                    MessageBox.Show("Заметка удалена!");
                }
            }
            else
            {
                MessageBox.Show("Выберите заметку для удаления.");
            }
        }

        public class Note
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Content { get; set; }
        }
    }
}
