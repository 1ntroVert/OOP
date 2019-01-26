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
    /// Логика взаимодействия для CircularProgressBar.xaml
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        public CircularProgressBar()
        {
            InitializeComponent();
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(CircularProgressBar),
            new PropertyMetadata(0.0, new PropertyChangedCallback(ValueChanged)));

        private static void ValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var circularProgressBar = obj as CircularProgressBar;
            circularProgressBar.Label.Text = string.Format("{0}%", circularProgressBar.Value);
            circularProgressBar.CircularArc.Angle = circularProgressBar.Value / 100.0 * 360.0;
        }
    }
}
