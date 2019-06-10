using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool Equals(object obj)
        {
            FullName item = (FullName)obj;
            if (this.FirstName == item.FirstName && this.LastName == item.LastName)
                return true;
            return false;
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            int sum = 0;
            string[] numberList = expression.Split('+');

            if (numberList.ToList().Contains(""))
                throw new InvalidDataException();

            foreach (var n in numberList)
                sum += int.Parse(n);
            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            try
            {
                value=CalculateSum(expression);
                return true;
            }
            catch(Exception e)
            {
                value = 0;
                return false;
            }
        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            
            double h;
            int count = 0;
            double odd = 3;
            double num = 1;
            double o = -1;
            Console.WriteLine(Math.Round(Math.PI, 10));
            //num<=Math.Round(Math.PI,10)
            while (count< 10372344)
            {
                h = (1 / odd);
                num += Math.Round(h * (o),10);
                odd += 2;
                o *= -1;
                count++;
            }
            Console.WriteLine(num*4);
            return count;
        }

        public static int Fibonacci(this int n)
        {
            int first = 1,second=1,third=1;
            int count = 2;
            while (count <= n)
            {
                third = first + second;
                first = second;
                second = third;
                count++;
            }
            return third;
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }
    }
}