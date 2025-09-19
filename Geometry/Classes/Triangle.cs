using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Geometry
{
    public abstract class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c, int startX, int startY, int lineWidth, Color color) : base(startX, startY, lineWidth, color)
        {
            A = FilterSize(a);
            B = FilterSize(b);
            C = FilterSize(c);
            if (A + B <= C || A + C <= B || B + C <= A) throw new ArgumentException("The triange does not exists");
        }

        public override double GetPerimeter() => A + B + C;

        public override double GetArea()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public abstract Point[] GetPoints();
        public double GetAltitude() => 2 * GetArea() / A;
        public override void Draw(PaintEventArgs e)
        {
            using var pen = new Pen(Color, LineWidth);
            e.Graphics.DrawPolygon(pen, GetPoints());
        }

        public void DrawAltitude(PaintEventArgs e)
        {
            Point[] pts = GetPoints();

            Point baseStart = pts[0];
            Point baseEnd = pts[1];
            Point opposite = pts[2];

            float dx = baseEnd.X - baseStart.X;
            float dy = baseEnd.Y - baseStart.Y;
            float t =
            ((opposite.X - baseStart.X) * dx + (opposite.Y - baseStart.Y) * dy) / (dx * dx + dy * dy);

            Point foot = new Point((int)(baseStart.X + t * dx), (int)(baseStart.Y + t * dy));

            using Pen pen = new Pen(Color.Gray, 1);

            e.Graphics.DrawLine(pen, opposite, foot);
        }
        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine($"Side A:{A}");
            Console.WriteLine($"Side B:{B}");
            Console.WriteLine($"Side C:{C}");
            base.Info(e);
        }
    }
}