using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Geometry
{
    public class Rectangle : Shape, IDiagonal
    {
        double width;
        double height;
        public double Width
        {
            get => width;
            set => width = FilterSize(value);
        }
        public double Height
        {
            get => height;
            set => height = FilterSize(value);
        }
        public Rectangle(double Width, double Height, int StartX, int StartY, int LineWidth, Color color) : base(StartX, StartY, LineWidth, color) { width = Width; height = Height; }


        public override double GetArea() => width * height;
        public override double GetPerimeter() => (width + height) * 2;

        public override void Draw(PaintEventArgs e)
        {
            using Pen pen = new Pen(Color, LineWidth);
            e.Graphics.DrawRectangle(pen, StartX, StartY, (float)Width, (float)Height);
        }
        public void DrawDiagonal(PaintEventArgs e)
        {
            using Pen pen = new Pen(Color, 1);
            e.Graphics.DrawLine(pen, StartX, StartY, (int)(StartX + Width), (int)(StartY + Height));
        }
        public override void Info(PaintEventArgs e)
        {
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Height: {Height}");
            base.Info(e);
        }

    }
}