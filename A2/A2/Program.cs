using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public  class Program
    {
        public static void Main(string[] args)
        {
        }
        public static void AssignPi(out double pi)
            => pi = Math.PI;
        public static void Square(ref int num)
            => num = num * num;
        public static void Swap(ref double num1,ref double num2)
        {
            double help = num1;
            num1 = num2;
            num2 = help;
        }
        public static void Sum(out int sum, params int[] nums)
        {
            sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }
        }
        public static void Append(ref int[] first,int second)
        {
            int[] array = first;
            first = new int[(array.Length) + 1];
            for(int i=0;i<array.Length;i++)
            {
                first[i]= array[i] ;
            }
            first[array.Length] = second;

        }
        public static void AbsArray(int []array)
        {
            for(int i=0;i<array.Length;i++)
            {
                if (array[i] < 0)
                    array[i] = Math.Abs(array[i]);
            }
        }
        public static void ArraySwap(int[] first,int [] second)
        {
            for (int i=0;i<first.Length;i++)
            {
                first[i] = first[i] + second[i];
                second[i] = first[i] - second[i];
                first[i] = first[i] - second[i];
            }
        }
        public static void ArraySwap(ref int[] first,ref int[] second)
        {
            int[] help = first;
            first = second;
            second = help;
        }
    }
}