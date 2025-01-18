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

    public partial class AddWindow : Window

    {
        public AddWindow()
        {
            InitializeComponent();
            
        }

        private void AddNote(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameAdd.Text) ||
                string.IsNullOrWhiteSpace(ContentAdd.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            NameAdd.Clear();
            ContentAdd.Clear();

        }

        private void GoToMenuWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
