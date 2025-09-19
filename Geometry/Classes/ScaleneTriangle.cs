using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry.Classes
{
    public class ScaleneTriangle : Triangle
    {
        public ScaleneTriangle(double a, double b, double c, int startX, int startY, int lineWidth, Color color)
            : base(a, b, c, startX, startY, lineWidth, color) { }

        public override Point[] GetPoints()
        {
            int Ax = StartX, Ay = StartY;
            int Bx = StartX + (int)A, By = StartY;

            double cosGamma = (B * B + C * C - A * A) / (2 * B * C);
            double angle = Math.Acos(cosGamma);

            int Cx = StartX + (int)(C * Math.Cos(angle));
            int Cy = StartY - (int)(C * Math.Sin(angle));

            return [new Point(Ax, Ay), new Point(Bx, By), new Point(Cx, Cy)];
        }
    }
}