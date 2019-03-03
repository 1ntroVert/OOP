using System;
using System.Windows;

namespace Inheritance
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Disk disk = new Disk(
                title.Text,
                Convert.ToInt64(price.Text),
                barcode.Text,
                (DiskType)Enum.Parse(typeof(DiskType), type.Text),
                content.Text);
            MainWindow.productCollection.AddProduct(disk);
        }
    }
}
