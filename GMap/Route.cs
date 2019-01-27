using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.WindowsPresentation;

namespace GMap
{
    class Route : MapObject
    {
        public List<PointLatLng> Points { get; private set; }

        public Route(string title, List<PointLatLng> points) : base(title)
        {
            Points = points;
        }

        public override GMapMarker GetDrawableMarker()
        {
            return new GMapRoute(Points)
            {
                Shape = new Path()
                {
                    Stroke = Brushes.LightSeaGreen,
                    Fill = Brushes.LightSeaGreen,
                    StrokeThickness = 4
                }
            };
        }
    }
}
