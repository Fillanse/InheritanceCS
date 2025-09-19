using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Geometry.Classes;

namespace Geometry
{
    public class MyForm : Form
    {
        public MyForm()
        {
            this.Paint += MyForm_Paint;
            Width = 700;
            Height = 500;
        }

        private void MyForm_Paint(object? sender, PaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(150, 150, 100, 100, 1, Color.Navy);
            rectangle.DrawDiagonal(e);
            rectangle.Info(e);

            Square square = new Square(100, 300, 150, 3, Color.OliveDrab);
            square.DrawDiagonal(e);
            square.Info(e);

            Ellipse ellipse1 = new Ellipse(150, 50, 450, 150, 5, Color.Black);
            ellipse1.DrawRadius(e);
            ellipse1.Info(e);

            Ellipse ellipse2 = new Ellipse(150, 50, 450, 0, 5, Color.Black);
            ellipse2.DrawDiameter(e);
            ellipse2.Info(e);

            Circle circle1 = new Circle(50, 800, 150, 2, Color.Brown);
            circle1.DrawRadius(e);
            circle1.Info(e);

            Circle circle2 = new Circle(50, 800, 0, 2, Color.Brown);
            circle2.DrawDiameter(e);
            circle2.Info(e);

            EquilateralTriangle eTriangle = new EquilateralTriangle(150, 100, 300, 2, Color.Blue);
            eTriangle.DrawAltitude(e);
            eTriangle.Info(e);

            SpecialRightTriangle sTriangle = new SpecialRightTriangle(150, 50, 300, 450, 2, Color.Blue);
            sTriangle.DrawAltitude(e);
            sTriangle.Info(e);

            ScaleneTriangle scTriangle = new ScaleneTriangle(150, 75 ,125, 500, 450, 2, Color.Blue);
            scTriangle.DrawAltitude(e);
            scTriangle.Info(e);
        }
    }
}