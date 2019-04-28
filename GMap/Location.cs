using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GMap
{
    class Location : MapObject
    {
        public PointLatLng Point { get; private set; }

        public Location(string title, PointLatLng point) : base(title)
        {
            Point = point;
        }

        public override GMapMarker Marker => new GMapMarker(Point)
        {
            Shape = new Image
            {
                Width = 32,
                Height = 32,
                ToolTip = Title,
                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/marker.png"))
            }
        };
    }
}
