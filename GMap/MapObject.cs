using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMap
{
    abstract class MapObject
    {
        public string Title { get; set; }
        public abstract GMapMarker GetDrawableMarker();

        protected MapObject(string title)
        {
            Title = title;
        }
    }
}
