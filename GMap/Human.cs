using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GMap
{
    class Human : MapObject
    {
        public PointLatLng Point { get; private set; }
        public PointLatLng DestinationPoint { get; set; }
        protected event EventHandler<SeatedEventArgs> Seated;

        public Human(string title, PointLatLng startPoint) : base(title)
        {
            Point = startPoint;
        }

        private GMapMarker HumanMarker;

        public override GMapMarker Marker
        {
            get
            {
                HumanMarker = new GMapMarker(Point)
                {
                    Shape = new Image
                    {
                        Width = 64,
                        Height = 64,
                        ToolTip = Title,
                        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/human.png"))
                    }
                };
                return HumanMarker;
            }
        }

        public void CarArrived(object sender, EventArgs e)
        {
            var car = sender as Car;
            car.Arrived -= CarArrived;
            Seated += car.PassengerSeated;
            Thread.Sleep(1000);
            Seated.Invoke(this, new SeatedEventArgs { DestinationPoint = DestinationPoint });
        }

        public void MoveTo(PointLatLng point)
        {
            Point = point;
            HumanMarker.Position = point;
        }


        public class SeatedEventArgs : EventArgs
        {
            public PointLatLng DestinationPoint { get; set; }
        }
    }
}
