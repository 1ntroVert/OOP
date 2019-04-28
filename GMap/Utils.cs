using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMap
{
    class Utils
    {
        public static readonly double DEFAULT_ZOOM = 18;

        // провайдер 
        public static RoutingProvider routingProvider = GMapProviders.OpenStreetMap;

        public static List<PointLatLng> buildRoute(PointLatLng startPoint, PointLatLng endPoint)
        {
            return routingProvider.GetRoute(
                startPoint,
                endPoint,
                false,
                false,
                (int)DEFAULT_ZOOM).Points;
        }
    }
}

