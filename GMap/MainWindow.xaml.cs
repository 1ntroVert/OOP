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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace GMap
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MapObjectCollection MapObjectCollection = new MapObjectCollection();

        Route route;
        Car car;
        Human i = new Human("Вася Пупкин", new PointLatLng(55.001841257855773, 82.980337142944336));

        bool fromClicked = false;
        bool toClicked = false;
        PointLatLng from;
        PointLatLng to;

        public MainWindow()
        {
            InitializeComponent();

            MapObjectCollection.Add(new Location("Coober, Спортивный центр", new PointLatLng(55.015104, 82.948034)));
            MapObjectCollection.Add(new Location("Октябрьская", new PointLatLng(55.018812, 82.940049)));
            MapObjectCollection.Add(new Location("Театр \"Старый дом\"", new PointLatLng(55.007645, 82.939107)));
            MapObjectCollection.Add(new Location("Сибирский государственный университет телекоммуникаций и информатики", new PointLatLng(55.013248, 82.950426)));

            MapObjectCollection.Add(new Area("сквер ГПНТБ", new PointLatLng[] {
                new PointLatLng(55.015963, 82.946845),
                new PointLatLng(55.016607, 82.947543),
                new PointLatLng(55.016215, 82.948772),
                new PointLatLng(55.016667, 82.949546),
                new PointLatLng(55.016363, 82.950350),
                new PointLatLng(55.015180, 82.948833) }.ToList()));


            car = new Car("Reno Logan", new PointLatLng(55.008683394217464, 83.044366836547852));
            car.Arrived += i.CarArrived;
            car.Moved += Car_Moved;
            MapObjectCollection.Add(car);
            MapObjectCollection.Add(i);
        }

        private void MapLoaded(object sender, RoutedEventArgs e)
        {
            // настройка доступа к данным
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            // установка провайдера карт
            Map.MapProvider = OpenStreetMapProvider.Instance;
            // установка зума и расположения
            Map.MinZoom = 2;
            Map.MaxZoom = 17;
            Map.Zoom = 12;
            Map.Position = new PointLatLng(55.001841257855773, 82.980337142944336);
            // настройка взаимодействия с картой
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;

            foreach (var marker in MapObjectCollection.Markers)
                Map.Markers.Add(marker);

            List<PointLatLng> points = new PointLatLng[] {
                new PointLatLng(55.015963, 82.946845),
                new PointLatLng(55.016607, 82.947543),
                new PointLatLng(55.016363, 82.950350),
                new PointLatLng(55.015180, 82.948833) }.ToList();

        }

        private void Car_Moved(object sender, EventArgs e)
        {
            Map.Position = (sender as Car).Point;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fromClicked = true;
            toClicked = false;
            Map.Cursor = Cursors.Cross;
            checkBox.IsEnabled = true;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true)
            {
                from = i.Point;
                From.Content = i.Point.ToString();
                Map.Cursor = Cursors.Arrow; 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fromClicked = false;
            toClicked = true;
            Map.Cursor = Cursors.Cross;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            route = new Route("-", Utils.buildRoute(from, to));
            Map.Markers.Add(route.Marker);
            i.DestinationPoint = to;
            Map.Zoom = Utils.DEFAULT_ZOOM;
            car.MoveTo(from);
        }

        private void Map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            double lat = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y).Lat; // широта
            double lng = Map.FromLocalToLatLng((int)e.GetPosition(Map).X, (int)e.GetPosition(Map).Y).Lng; // долгота

            if (fromClicked)
            {
                from = new PointLatLng(lat, lng);
                From.Content = from.ToString();
            }
            if (toClicked)
            {
                to = new PointLatLng(lat, lng);
                To.Content = to.ToString();
            }
            Map.Cursor = Cursors.Arrow;
        }

        private void Map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}