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
    public class HourHand:IHand
    {
        public int Thickness { get; set; }
        public SolidColorBrush Color { get; set; }
        public Point FirstOfHand { get; set; }
        public Point EndOfHand { get; set; }
        public double Angle { get; set; }
        public double Size { get; set; }
        public Line Hand { get; set; }

        public HourHand(int thickness, SolidColorBrush color, Point firstOfHand, double angle, double size)
        {
            Thickness = thickness;
            Color = color;
            FirstOfHand = firstOfHand;
            Angle = angle;
            this.Size = size;
            this.EndOfHand = new Point(FirstOfHand.X + (Size * Math.Cos(Math.PI * (90 - Angle) / 180))
                                     , FirstOfHand.Y - (Size * Math.Sin(Math.PI * (90 - Angle) / 180)));
            Hand = new Line();
        }

        public void DrawingHand()
        {
            Hand.X1 = FirstOfHand.X;
            Hand.Y1 = FirstOfHand.Y;
            Hand.X2 = EndOfHand.X;
            Hand.Y2 = EndOfHand.Y;
            Hand.StrokeThickness = Thickness;
            Hand.Stroke = Color;
            AnalogClock.CanvasFrame.Children.Add(Hand);
        }

        public void UpdateHand()
        {
            AnalogClock.CanvasFrame.Children.Remove(Hand);
            this.Angle = (DateTime.Now.Hour * 30)+(DateTime.Now.Minute*0.5);
            EndOfHand.X = FirstOfHand.X + (Size * Math.Cos(Math.PI * (90 - Angle) / 180));
            EndOfHand.Y = FirstOfHand.Y - (Size * Math.Sin(Math.PI * (90 - Angle) / 180));
            DrawingHand();
        }
    }
}
