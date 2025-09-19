using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IAltitude
    {
        double A { get; }
        double B { get; }
        double C { get; }
        Point[] GetPoints();
        void GetAltitude();
        void DrawAltitude();
    }
}