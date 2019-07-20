using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public class Equation
    {
        public bool Hamgen;
        public List<char> Variables;
        public List<double> ListOfConstantNum;
        public List<List<double>> ListOfCoefficients;
        public string Input;
        SquareMatrix<double> A;

        public Equation(string input)
        {
            Hamgen = true;
            this.Input = input;

            //Create List Of Variables
            Variables = new List<char>();
            for (char i = 'a'; i <= 'z'; i++)
                if (Input.Contains(i))
                    Variables.Add(i);

            //Create List Of Constant Number
            ListOfConstantNum = new List<double>();

            //Create List Of Coefficients
            ListOfCoefficients = new List<List<double>>();
            for (int i = 0; i < Variables.Count; i++)
            {
                ListOfCoefficients.Add(new List<double>(Variables.Count));
                for (int j = 0; j < Variables.Count; j++)
                    ListOfCoefficients[i].Add(0);
            }
        }

        public void Setting_A()
        {
            A = new SquareMatrix<double>(Variables.Count);
            for(int j=0;j<ListOfCoefficients.Count;j++)
            {
                for(int k=0;k< ListOfCoefficients.Count;k++)
                {
                    A[j, k] = ListOfCoefficients[j][k];
                }
            }
        }

        public Matrix<double> FindResult()
        {
            Setting_A();
            Matrix<double> C = new Matrix<double>(ListOfConstantNum.Count, 1);
            for (int i = 0; i < ListOfConstantNum.Count; i++)
            {
                C[i, 0] = ListOfConstantNum[i];
                if (ListOfConstantNum[i] != 0)
                    this.Hamgen = false;
            }

            return SquareMatrix<double>.Inverse(A) * C;
        }

        public void EquationParser()
        {
            List<string> list = new List<string>();
            char seperator;
            if (Input.Contains(','))
                seperator = ',';
            else
                seperator = '-';
            int startindex ;
            int endindex = -1;
            int j = 0;
            while (j < Variables.Count)
            {
                startindex = endindex;
                endindex = Input.IndexOf(seperator, Input.IndexOf('=') + 2);
                if (endindex < 0)
                    endindex = Input.Count();
                list.Add(Input.Substring(startindex + 1, endindex - startindex - 1));
                Input = Input.Remove(Input.IndexOf('='), 1);
                endindex -= 1;
                j++;
            }
            Variables.Add('=');
            for (int i = 0; i < list.Count; i++)
            {
                var str = list[i].Split(Variables.ToArray());
                for (int k = 0; k < str.Length - 1; k++)
                {
                    try
                    {
                        ListOfCoefficients[i][k] = double.Parse(str[k]);
                    }
                    catch
                    {
                        if (str[k] == "-")
                            ListOfCoefficients[i][k] = -1;
                        else if (str[k] == "+")
                            ListOfCoefficients[i][k] = +1;
                    }
                }
                ListOfConstantNum.Add(double.Parse(str[str.Length - 1]));
            }
            Variables.Remove('=');
        }
    }
}
