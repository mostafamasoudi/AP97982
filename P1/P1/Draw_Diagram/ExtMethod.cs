using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    public static class ExtMethod
    {
        public static Functions FunctionParser(this string Input,double min_x,double max_x,double min_y,double max_y)
        {
            Functions newfunction = new Functions(min_x, max_x, min_y, max_y);
            newfunction.Asign = Input.Where(d => (d == '-') || (d == '+')).ToList();
            if (Input[0] != '-')
                newfunction.Asign.Insert(0, '+');

            var list = Input.Split('+', '-');
            foreach (var l in list)
            {
                if (!l.Contains('x'))
                {
                    newfunction.Power.Add(0);
                    newfunction.ConstantNumber.Add(double.Parse(l));
                    continue;
                }
                var s = l.Split('x');

                if (s[0] != "")
                    newfunction.ConstantNumber.Add(double.Parse(s[0]));
                else
                    newfunction.ConstantNumber.Add(1);

                s[1] = s[1].Replace("^", "");

                if (s[1] != "")
                    newfunction.Power.Add(int.Parse(s[1]));
                else
                    newfunction.Power.Add(1);
            }
            for (int i = 0; i < newfunction.Asign.Count; i++)
                newfunction.ConstantNumber[i] *= double.Parse($"{newfunction.Asign[i]}1");
            return newfunction;
        }
    }
}
