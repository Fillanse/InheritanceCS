using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry
{
    public interface IRadius
    {
        double RadiusX { get; set; }
        double RadiusY { get; set; }
        double GetDiameterX() => RadiusX * 2;
        double GetDiameterY() => RadiusY * 2;
        void DrawRadius(PaintEventArgs e);
        void DrawDiameter(PaintEventArgs e);
    }
}