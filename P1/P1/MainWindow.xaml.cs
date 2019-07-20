using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            AnalogClock clock = new AnalogClock(CanvasFrame, Frame
                , new Point(CanvasFrame.Margin.Left + CanvasFrame.Width / 2, CanvasFrame.Margin.Top + CanvasFrame.Height / 2));
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        { 
            Equation equation = new Equation(Input_Equation.Text);
            equation.EquationParser();
            StringBuilder TextBlockShow = new StringBuilder();
            Matrix<double> Result = new Matrix<double>(equation.Variables.Count,1);
            bool Error = false;
            try
            {
                Result = equation.FindResult();
            }
            catch
            {
                if (equation.Hamgen == true)
                    TextBlockShow.Append("No Unique Solution");
                else
                    TextBlockShow.Append("No Solution");
                Error = true;
            }
            if (!Error)
            {
                for (int i = 0; i < equation.Variables.Count; i++)
                {
                    TextBlockShow.Append($"{equation.Variables[i]}={Result[i, 0]}");
                    if (i != equation.Variables.Count - 1)
                        TextBlockShow.Append(",");
                }
            }
            Answer_Equation.Text = TextBlockShow.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Answer_Equation.Text = null;
            Input_Equation.Text = null;
        }

        private void B_Draw_Click(object sender, RoutedEventArgs e)
        {
            DrawDiagram Diagram = new DrawDiagram(50, Min_x.Text, Max_x.Text, Min_y.Text, Max_y.Text, function.Text);
            Diagram.DrawPlane(DrawingGrid);
            Diagram.DrawFunc();
        }

        private void Diagram_Clear_Click(object sender, RoutedEventArgs e)
        {
            Min_x.Text = null;
            Max_x.Text = null;
            Min_y.Text = null;
            Max_y.Text = null;
            function.Text = null;
            DrawingGrid.Children.Clear();
        }

    }
}
