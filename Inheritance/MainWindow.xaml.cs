using System.Collections.Generic;
using System.Windows;

namespace Inheritance
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static ProductCollection productCollection;

        public MainWindow()
        {
            InitializeComponent();
            LocalDatabase localDatabase = new LocalDatabase("Database.sqlite");
            productCollection = new ProductCollection(localDatabase);
            productCollection.LoadProducts();

            var products = productCollection.GetProducts(); // получение списка товаров
            datagrid.ItemsSource = products; // добавление списка товаров в DataGrid
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win1 = new Window1();
            win1.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = (Product)datagrid.SelectedItem; // выбранный товар
            productCollection.RemoveProduct(selectedProduct);
        }
    }
}
