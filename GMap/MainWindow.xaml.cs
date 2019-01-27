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
        private const int DEFAULT_ZOOM = 14;
        private MapObjectCollection MapObjectCollection = new MapObjectCollection();

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

            RoutingProvider routingProvider = GMapProviders.OpenStreetMap;

            MapRoute route = routingProvider.GetRoute(
                new PointLatLng(55.016789, 82.944568),
                new PointLatLng(55.029888, 82.921444),
                false,
                false,
                DEFAULT_ZOOM);

            GMapRoute gmRoute = new GMapRoute(route.Points);

            MapObjectCollection.Add(new Route("Музей Октябрьского района - Площадь Ленина", route.Points));
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
            Map.Zoom = DEFAULT_ZOOM;
            Map.Position = new PointLatLng(55.012823, 82.950359);
            // настройка взаимодействия с картой
            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            Map.CanDragMap = true;
            Map.DragButton = MouseButton.Left;

            MapObjectCollection.Draw(Map);
        }
    }
}
