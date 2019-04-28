using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GMap
{
    class Car : MapObject
    {
        public PointLatLng Point { get; private set; }
        private GMapMarker CarMarker;

        public event EventHandler Moved;
        public event EventHandler Arrived;

        public Route Route { get; private set; }

        public List<Human> passengers { get; private set; } = new List<Human>();

        public Car(string title, PointLatLng startPoint) : base(title)
        {
            Point = startPoint;
        }

        public override GMapMarker Marker
        {
            get
            {
                CarMarker = new GMapMarker(Point)
                {
                    Shape = new Image
                    {
                        Width = 96,
                        Height = 96,
                        ToolTip = Title,
                        Source = new BitmapImage(new Uri("pack://application:,,,/Resources/car.png"))
                    }
                };
                return CarMarker;
            }
        }

        public void MoveTo(PointLatLng endPoint)
        {
            Route = new Route(null, Utils.buildRoute(Point, endPoint));
            Thread newThread = new Thread(new ThreadStart(MoveByRoute));
            newThread.Start();
        }

        private void MoveByRoute()
        {
            foreach (var point in Route.Points)
            {
                Application.Current.Dispatcher.Invoke(delegate
                {
                    Point = point;
                    CarMarker.Position = point;
                    foreach (Human passenger in passengers)
                    {
                        passenger.MoveTo(point);
                    }
                    Moved?.Invoke(this, EventArgs.Empty);
                });
                Thread.Sleep(500);
            }
            Arrived?.Invoke(this, null);
        }

        public void PassengerSeated(object sender, Human.SeatedEventArgs e)
        {
            passengers.Clear();
            passengers.Add(sender as Human);
            MoveTo(e.DestinationPoint);
        }
    }
}

