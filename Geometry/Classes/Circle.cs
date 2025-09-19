using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Geometry
{
    public class Circle : Ellipse
    {
        public double Radius => RadiusX;

        public Circle(double radius, int startX, int startY, int lineWidth, Color color) : base(radius, radius, startX, startY, lineWidth, color) { } 
    }
}