using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1.Tests
{
    [TestClass()]
    public class FunctionsTests
    {
        [TestMethod()]
        public void PolynomialTest()
        {
            //#4
            string Func1 = "10x^2";
            Functions Result_Func1 = Func1.FunctionParser(0, 0, 0, 0);
            Assert.AreEqual(250, Result_Func1.Polynomial(5));

            //#5
            string Func2 = "2x^3-4x^2+x-10";
            Functions Result_Func2 = Func2.FunctionParser(0, 0, 0, 0);
            Assert.AreEqual(-10, Result_Func2.Polynomial(0));

            //#6
            string Func3 = "100";
            Functions Result_Func3 = Func3.FunctionParser(0, 0, 0, 0);
            Assert.AreEqual(100, Result_Func3.Polynomial(50));
        }
    }
}