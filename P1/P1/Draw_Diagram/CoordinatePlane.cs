using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace P1
{
    public class CoordinatePlane
    {
        public Functions function;
        public Grid NetGrid;
        public Line X_Line;
        public Line Y_Line;
        public double ScaleX;
        public double ScaleY;

        public CoordinatePlane(Grid drawingGrid,Functions f)
        {
            this.NetGrid = drawingGrid;
            this.function = f;
        }

        public void DefineColumn()
        {
            List<Line> columns = new List<Line>();
            ScaleX = NetGrid.Width / (Math.Abs(function.MaxX) + Math.Abs(function.MinX));
            for (int i = 1; i <= 2*(int)function.MaxX ; i++)
            {
                columns.Add(new Line());
                columns[i - 1].X1 = Y_Line.X1 + (i * ScaleX / 2);
                columns[i - 1].Y1 = Y_Line.Y1;
                columns[i - 1].X2 = Y_Line.X2 + (i * ScaleX / 2);
                columns[i - 1].Y2 = Y_Line.Y2;
                columns[i - 1].StrokeThickness = 1;
                columns[i - 1].Stroke = Brushes.LightBlue;
                columns[i - 1].Opacity = 30;
                NetGrid.Children.Add(columns[i - 1]);
            }
            for (int i = 1; i <= 2 * Math.Abs(function.MinX); i++)
            {
                columns.Add(new Line());
                columns[(int)function.MaxX * 2 + i - 1].X1 = Y_Line.X1 - (i * ScaleX / 2);
                columns[(int)function.MaxX * 2 + i - 1].Y1 = Y_Line.Y1;
                columns[(int)function.MaxX * 2 + i - 1].X2 = Y_Line.X2 - (i * ScaleX / 2);
                columns[(int)function.MaxX * 2 + i - 1].Y2 = Y_Line.Y2;
                columns[(int)function.MaxX * 2 + i - 1].StrokeThickness = 1;
                columns[(int)function.MaxX * 2 + i - 1].Stroke = Brushes.LightBlue;
                columns[(int)function.MaxX * 2 + i - 1].Opacity = 30;
                NetGrid.Children.Add(columns[(int)function.MaxX * 2 + i - 1]);
            }
        }

        public void DefineRow()
        {
            List<Line> rows = new List<Line>();
            ScaleY = NetGrid.Height / (Math.Abs(function.MaxY) + Math.Abs(function.MinY));
            for (int i = 1; i <= 2 * (int)function.MaxY; i++)
            {
                rows.Add(new Line());
                rows[i - 1].X1 = X_Line.X1;
                rows[i - 1].Y1 = X_Line.Y1 - (i * ScaleY / 2);
                rows[i - 1].X2 = X_Line.X2 ;
                rows[i - 1].Y2 = X_Line.Y2 - (i * ScaleY / 2);
                rows[i - 1].StrokeThickness = 1;
                rows[i - 1].Stroke = Brushes.LightBlue;
                rows[i - 1].Opacity = 30;
                NetGrid.Children.Add(rows[i - 1]);
            }
            for (int i = 1; i <= 2 * Math.Abs(function.MinY); i++)
            {
                rows.Add(new Line());
                rows[(int)function.MaxY * 2 + i - 1].X1 = X_Line.X1;
                rows[(int)function.MaxY * 2 + i - 1].Y1 = X_Line.Y1 + (i * ScaleY / 2);
                rows[(int)function.MaxY * 2 + i - 1].X2 = X_Line.X2;
                rows[(int)function.MaxY * 2 + i - 1].Y2 = X_Line.Y2 + (i * ScaleY / 2);
                rows[(int)function.MaxY * 2 + i - 1].StrokeThickness = 1;
                rows[(int)function.MaxY * 2 + i - 1].Stroke = Brushes.LightBlue;
                rows[(int)function.MaxY * 2 + i - 1].Opacity = 30;
                NetGrid.Children.Add(rows[(int)function.MaxY * 2 + i - 1]);
            }
            
            NetGrid.Children.Add(X_Line);
            NetGrid.Children.Add(Y_Line);
        }

        public void Setting_X_Axis()
        {
            X_Line = new Line();
            X_Line.X1 = 0;
            X_Line.Y1 = NetGrid.Height / 2;
            X_Line.X2 = NetGrid.Width;
            X_Line.Y2 = NetGrid.Height / 2;
            X_Line.StrokeThickness = 3;
            X_Line.Stroke = Brushes.Black;
        }

        public void Setting_Y_Axis()
        {
            Y_Line = new Line();
            Y_Line.X1 = NetGrid.Width/2;
            Y_Line.Y1 = NetGrid.Height;
            Y_Line.X2 = NetGrid.Width / 2;
            Y_Line.Y2 = 0;
            Y_Line.StrokeThickness = 3;
            Y_Line.Stroke = Brushes.Black;
        }

    }
}
