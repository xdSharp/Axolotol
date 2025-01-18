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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ListView
{

    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Яблоко", Category = "Фрукты", Price = "50" },
                new Product { Id = 2, Name = "Банан", Category = "Фрукты", Price = "30" },
                new Product { Id = 3, Name = "Апельсин", Category = "Фрукты", Price = "40" },
                new Product { Id = 4, Name = "Помидор", Category = "Овощи", Price = "60" },
                new Product { Id = 5, Name = "Картошка", Category = "Овощи", Price = "20" },
                new Product { Id = 6, Name = "Морковь", Category = "Овощи", Price = "25" },
                new Product { Id = 7, Name = "Курица", Category = "Мясо", Price = "250" },
                new Product { Id = 8, Name = "Говядина", Category = "Мясо", Price = "400" },
                new Product { Id = 9, Name = "Рис", Category = "Зерновые", Price = "100" },
                new Product { Id = 10, Name = "Макароны", Category = "Зерновые", Price = "70" }

            };

            dg.ItemsSource = Products;
        }

        private void AddNewProduct(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(CategoryBox.Text) ||
                string.IsNullOrWhiteSpace(PriceBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля!");
                return;
            }

            int newId = Products.Count > 0 ? Products.Max(a => a.Id) + 1 : 1;

            Products.Add(new Product
            {
                Id = newId,
                Name = NameBox.Text,
                Category = CategoryBox.Text,
                Price = PriceBox.Text,
            });


            NameBox.Clear();
            CategoryBox.Clear();
            PriceBox.Clear();

            dg.ItemsSource = Products.ToList();


        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItems.Count > 0)
            {
                var selectedProduct = dg.SelectedItem as Product;
                if (selectedProduct != null)
                {
                    Products.Remove(selectedProduct);
                    MessageBox.Show("Продукт удален!");
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.");
            }
        }
        private void EditProduct(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedItems.Count > 0) // Проверяем выделен ли элемент
            {
                var item = dg.SelectedItem as Product; 
                if (item != null) 
                { 
                    NameBoxEdit.Text = item.Name;
                    CategoryBoxEdit.Text = item.Category;
                    PriceBoxEdit.Text = item.Price;

                }

            }
            else
            {
                MessageBox.Show("Выберите Продукт!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }



        private void SaveProduct(object sender, RoutedEventArgs e)
        {
            var item = dg.SelectedItem as Product;
            item.Name = NameBoxEdit.Text;
            item.Category = CategoryBoxEdit.Text;
            item.Price = PriceBoxEdit.Text;
            dg.ItemsSource = Products.ToList();
            MessageBox.Show("Данные обновлены", "Успех", MessageBoxButton.OK);
            NameBoxEdit.Clear();
            CategoryBoxEdit.Clear();
            PriceBoxEdit.Clear();
        }

        
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
    }
}
