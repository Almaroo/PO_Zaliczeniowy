using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorLeafletMap
{
    public sealed record Point
    {
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}
