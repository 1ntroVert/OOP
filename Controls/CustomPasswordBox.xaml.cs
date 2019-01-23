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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Controls
{
    /// <summary>
    /// Логика взаимодействия для CustomPasswordBox.xaml
    /// </summary>
    public partial class CustomPasswordBox : UserControl
    {
        public CustomPasswordBox()
        {
            InitializeComponent();
            textBox.TextChanged += TextChanged;
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            Password = textBox.Text;
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
            "Password",
            typeof(string),
            typeof(CustomPasswordBox),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            "Icon",
            typeof(StreamGeometry),
            typeof(CustomPasswordBox),
            new PropertyMetadata(default(StreamGeometry)));

        public StreamGeometry Icon
        {
            get { return (StreamGeometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
    }
}
