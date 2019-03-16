using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AssignPiTest()
        {
            Program.AssignPi(out double pi);
            Assert.AreEqual(Math.PI, pi);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int num = 2;
            Program.Square(ref num);
            Assert.AreEqual(4, num);
        }

        [TestMethod()]
        public void SwapTest()
        {
            double num1 = 2;
            double num2 = 4;
            Program.Swap(ref num1, ref num2);
            Assert.AreEqual(4, num1);
            Assert.AreEqual(2, num2);
        }

        [TestMethod()]
        public void SumTest()
        {
            int[] test = new int[] { 1, 2, 3, 4, 5 };
            Program.Sum(out int sum, test);
            Assert.AreEqual(15, sum);
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] act = new int[] { 1, 2, 3 };
            int second = 4;
            int[] exp = new int[] { 1, 2, 3, 4 };
            Program.Append(ref act, second);
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] act = new int[] { -1, 2, -3, -4, 5 };
            int[] exp = new int[] { 1, 2, 3, 4, 5 };
            Program.AbsArray(act);
            CollectionAssert.AreEqual(exp, act);
        }

        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] first = new int[] { 1, 2, 3, 4 };
            int[] second = new int[] { 5, 6, 7, 8 };
            int[] actfirst = new int[] { 5, 6, 7, 8 };
            int[] actsecond = new int[] { 1, 2, 3, 4 };
            Program.ArraySwap(first, second);
            CollectionAssert.AreEqual(actfirst, first);
            CollectionAssert.AreEqual(actsecond, second);
        }

        [TestMethod()]
        public void ArraySwapTest1()
        {
            int[] first = new int[] { 1, 2, 3 };
            int[] second = new int[] { 4, 5, 6, 7, 8 };
            int[] actfirst = new int[] { 4, 5, 6, 7, 8 };
            int[] actsecond = new int[] { 1, 2, 3 };
            Program.ArraySwap(ref first, ref second);
            CollectionAssert.AreEqual(actfirst, first);
            CollectionAssert.AreEqual(actsecond, second);
        }
    }
}