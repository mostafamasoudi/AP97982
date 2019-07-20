using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class FrameBorder
    {
        public Point LocalOnFrame;
        public int Size;
        public int Thickness;
        public SolidColorBrush Color;
        public double Angle;
        public Line Line;

        public FrameBorder(Point localonframe, int size, int thickness, SolidColorBrush color,double angle)
        {
            LocalOnFrame = localonframe;
            Size = size;
            Thickness = thickness;
            Color = color;
            Angle = angle;
            Line = new Line();
        }

        public void SettingLine()
        {
            Line.X1 = LocalOnFrame.X;
            Line.Y1 = LocalOnFrame.Y;
            Line.X2 = Line.X1 - (Size * Math.Cos(Math.PI * (90 - Angle) / 180));
            Line.Y2 = Line.Y1 + (Size * Math.Sin(Math.PI * (90 - Angle) / 180));
            Line.StrokeThickness = Thickness;
            Line.Stroke = Color;
        }

        public void Drawing()
        {
            SettingLine();
            AnalogClock.CanvasFrame.Children.Add(Line);
        }
    }
}
