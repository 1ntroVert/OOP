using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GMap
{
    class Area : MapObject
    {
        public List<PointLatLng> Points { get; private set; }

        public Area(string title, List<PointLatLng> points) : base(title)
        {
            Points = points;
        }

        public override GMapMarker Marker => new GMapPolygon(Points)
        {
            Shape = new Path
            {
                Stroke = Brushes.Black,
                Fill = Brushes.LightSeaGreen,
                Opacity = 0.5
            }
        };
    }
}
