using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry.Classes
{
    public class SpecialRightTriangle : Triangle
    {
        public SpecialRightTriangle(double a,double b, int startX, int startY, int lineWidth, Color color)
            : base(Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2)), a, b, startX, startY, lineWidth, color) { }

        public override Point[] GetPoints() =>
            [
                new Point(StartX, StartY),                  
                new Point(StartX + (int)A, StartY),        
                new Point(StartX, StartY - (int)B)          
            ];

    }
}