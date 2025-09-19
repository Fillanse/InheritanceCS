using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry
{
    public class Ellipse : Shape, IRadius
    {
        double radiusX;
        double radiusY;

        public double RadiusX
        {
            get => radiusX;
            set => radiusX = FilterSize(value);
        }
        public double RadiusY
        {
            get => radiusY;
            set => radiusY = FilterSize(value);
        }
        public Ellipse(double RadiusX, double RadiusY, int StartX, int StartY, int LineWidth, Color Color) : base(StartX, StartY, LineWidth, Color)
        {
            radiusX = RadiusX;
            radiusY = RadiusY;
        }
        public override double GetArea() => Math.PI * radiusX * radiusY;
        public override double GetPerimeter() =>
        Math.PI * (radiusX + radiusY)
        * (1 + 3 * Math.Pow(radiusX - radiusY, 2) / Math.Pow(radiusX + radiusY, 2)
        / (10 + Math.Sqrt(4 - 3 * Math.Pow(radiusX - radiusY, 2) / Math.Pow(radiusX + radiusY, 2))));

        public override void Draw(PaintEventArgs e)
        {
            using Pen pen = new Pen(Color, LineWidth);
            e.Graphics.DrawEllipse(pen, StartX, StartY, (float)radiusX * 2, (float)radiusY * 2);
        }
        public void DrawRadius(PaintEventArgs e)
        {
            using Pen pen = new Pen(Color.Gray, 1);
            int centerX = StartX + (int)RadiusX;
            int centerY = StartY + (int)RadiusY;

            e.Graphics.DrawLine(pen, centerX, centerY, (int)(StartX + RadiusX), StartY);
            e.Graphics.DrawLine(pen, centerX, centerY, StartX, (int)(StartY + RadiusY));
        }
        public void DrawDiameter(PaintEventArgs e)
        {
            using Pen pen = new Pen(Color.Gray, 1);
            int centerX = StartX + (int)RadiusX;
            int centerY = StartY + (int)RadiusY;

            e.Graphics.DrawLine(pen, centerX - (float)RadiusX, centerY, centerX + (float)RadiusX, centerY);
            e.Graphics.DrawLine(pen, centerX, centerY - (float)RadiusY, centerX, centerY + (float)RadiusY);
        }
        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine($"RadiusX: {RadiusX}");
            Console.WriteLine($"RadiusY: {RadiusY}");
            base.Info(e);
        }
    }
}