using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Geometry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Form myform = new Form();
            // IntPtr hwnd = myform.Handle;
            // Graphics graphics = Graphics.FromHwnd(hwnd);
            // System.Drawing.Rectangle window_rect = new System.Drawing.Rectangle(myform.Left, myform.Top, myform.Width, myform.Height);
            // PaintEventArgs e = new PaintEventArgs(graphics, window_rect);

            // e.Graphics.DrawLine(new Pen(Color.Red, 10), 100, 100, 500, 500);

            MyForm form = new MyForm();
            Application.Run(form);
        }
    }
}