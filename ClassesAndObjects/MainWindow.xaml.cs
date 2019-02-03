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

namespace ClassesAndObjects
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            drawLine(10, 10, 10, 290);
            drawLine(10, 290, 290, 290);
            drawLine(290, 290, 290, 10);
            drawLine(290, 10, 10, 10);
        }

        private void drawLine(int x1, int y1, int x2, int y2)
        {
            // создание объекта (экземпляра) класса Line
            Line line = new Line();

            // задание цвета линии (красный) с помощью свойства Stroke
            line.Stroke = Brushes.Red;
            // задание толщины линии (5) с помощью свойства StrokeThickness
            line.StrokeThickness = 5;

            // задание относительных координат начала и конца линии с помощью свойств X1, Y1, X2, Y2
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;

            // добавление линии в холст (линия добавляется в список "дочерних" элементов холста)
            canvas.Children.Add(line);
        }
    }
}