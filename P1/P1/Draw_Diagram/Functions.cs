using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace P1
{
    public class Functions
    {
        public double MinX;
        public double MaxX;
        public double MinY;
        public double MaxY;
        public List<char> Asign;
        public List<int> Power;
        public List<double> ConstantNumber;
        public Polyline Line;

        public Functions(double minX, double maxX, double minY, double maxY)
        {
            this.MinX = minX;
            this.MaxX = maxX;
            this.MinY = minY;
            this.MaxY = maxY;
            this.Power = new List<int>();
            this.ConstantNumber = new List<double>();
            this.Asign = new List<char>();
            this.Line = new Polyline();
        }

        public delegate double Function(double x);

        public double Polynomial(double x)
        {
            double Sum = 0;
            for(int i=0;i<Power.Count;i++)
            {
                Sum += ConstantNumber[i] * Math.Pow(x, Power[i]);
            }
            return Sum;
        }
    }
}
