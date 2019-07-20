using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public interface IHand
    {
        int Thickness { get; set; }
        SolidColorBrush Color { get; set; }
        Point FirstOfHand { get; set; }
        Point EndOfHand { get; set; }
        double Angle { get; set; }
        double Size { get; set; }
        Line Hand { get; set; }

        void DrawingHand();
        void UpdateHand();
    }
}