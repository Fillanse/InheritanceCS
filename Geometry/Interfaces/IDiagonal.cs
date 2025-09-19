using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry
{
    public interface IDiagonal
    {
        double Width { get; set; }
        double Height { get; set; }
        double GetDiagonal() => Math.Sqrt(Width * Width + Height * Height);
        void DrawDiagonal(PaintEventArgs e);
    }
}