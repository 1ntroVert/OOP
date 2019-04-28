using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMap
{
    class MapObjectCollection
    {
        private List<MapObject> MapObjects = new List<MapObject>();

        public void Add(MapObject obj)
        {
            MapObjects.Add(obj);
        }

        public void Remove(MapObject obj)
        {
            MapObjects.Remove(obj);
        }

        public IEnumerable<GMapMarker> Markers
        {
            get
            {
                return MapObjects.Select(obj => obj.Marker);
            }
        }
       
    }
}
