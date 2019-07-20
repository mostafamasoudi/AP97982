using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class DrawDiagram
    {
        public CoordinatePlane Plane;
        public Functions Functions;
        
        public DrawDiagram(double scale, string min_x, string max_x, string min_y, string max_y, string function)
        {
            try
            {
                Functions =
                function.FunctionParser(double.Parse(min_x), double.Parse(max_x), double.Parse(min_y), double.Parse(max_y));
            }
            catch (Exception)
            {
                MessageBox.Show("         BAD INPUT\n\n  Please Enter Again", "ERROR");
            }
        }

        public void DrawPlane(Grid drawingGrid)
        {
            this.Plane = new CoordinatePlane(drawingGrid, Functions);
            Plane.Setting_X_Axis();
            Plane.Setting_Y_Axis();
            Plane.DefineColumn();
            Plane.DefineRow();
        }

        public void DrawFunc()
        {
            Calculate();
            Plane.NetGrid.Children.Add(Functions.Line);
        }

        public void Calculate()
        {
            double CalY;
            double count = Functions.MinX;
            while (count < Functions.MaxX)
            {
                CalY = Functions.Polynomial(count);
                if ((CalY >= Functions.MinY) && (CalY <= Functions.MaxY))
                    Functions.Line.Points.Add(new System.Windows.Point
                             (Plane.NetGrid.Width / 2 + count * Plane.ScaleX
                             , (-1) * CalY * Plane.ScaleY + Plane.NetGrid.Height / 2));
                count += 0.2;
            }
            Functions.Line.Stroke = Brushes.Black;
            Functions.Line.StrokeThickness = 1;
        }
    }
}
