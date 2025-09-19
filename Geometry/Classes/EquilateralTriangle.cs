using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry.Classes
{
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double side, int startX, int startY, int lineWidth, Color color) : base(side, side, side, startX, startY, lineWidth, color) { }

        public override Point[] GetPoints() =>
            [
                new Point(StartX, StartY + (int)A),            
                new Point(StartX + (int)A, StartY + (int)A),    
                new Point(StartX + (int)A/2, StartY)
            ];
    }
}