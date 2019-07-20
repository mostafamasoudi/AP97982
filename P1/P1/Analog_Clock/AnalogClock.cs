using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Threading;

namespace P1
{
    public class AnalogClock
    {
        public static Canvas CanvasFrame;
        public static Ellipse Frame;
        public Point Center;
        public SecondHand SecondHand;
        public MinuteHand MinuteHand;
        public HourHand HourHand;
        public List<FrameBorder> Borders;

        public AnalogClock(Canvas canvasFrame, Ellipse frame, Point center)
        {
            CanvasFrame = canvasFrame;
            Frame = frame;
            Center = center;

            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Tick += Timer_Tick;
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();

            //Initialize FrameBorder;
            Borders = new List<FrameBorder>();
            InitializeFrameBorder();
            //Initialize SecondHand
            SecondHand = new SecondHand(1, Brushes.Black, Center, DateTime.Now.Second * 6, CanvasFrame.Width * 4 / 10);
            //Initialize MinuteHand
            MinuteHand = new MinuteHand(4, Brushes.Black, Center, (DateTime.Now.Minute * 6) + (DateTime.Now.Second / 59), CanvasFrame.Width * 4 / 11);
            //Initialize HourHand
            HourHand = new HourHand(7, Brushes.Black, Center, (DateTime.Now.Hour * 30) + (DateTime.Now.Minute * 0.5), CanvasFrame.Width * 2 / 10);

            Thread.Sleep(800);

        }

        private void InitializeFrameBorder()
        {
            int Radius = 95;
            int Angle = 0;
            for(int i=0;i<60;i++)
            {
                Borders.Add(new FrameBorder(new Point(Center.X + (Radius * Math.Cos((90 - Angle) * Math.PI / 180))
                                                    , Center.Y - (Radius * Math.Sin((90 - Angle) * Math.PI / 180)))
                                           , (i % 5 == 0 ? 15 : 5), (i % 5 == 0 ? 4 : 2), Brushes.Black, Angle));
                Borders[i].Drawing();
                Angle += 6;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SecondHand.UpdateHand();
            MinuteHand.UpdateHand();
            HourHand.UpdateHand();
        }
    }
}
