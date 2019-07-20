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
    public class EquationTests
    {
        [TestMethod()]
        public void FindResultTest()
        {
            //#15
            Equation Test1 = new Equation("2x+3y=0,3x+2y=10");
            Test1.EquationParser();
            string Actual1 = string.Join(",", Test1.FindResult());
            Assert.AreEqual("[6],[-4]", Actual1);

            //#16
            Equation Test2 = new Equation("2x+3y=0-3x+2y=10");
            Test2.EquationParser();
            string Actual2 = string.Join(",", Test2.FindResult());
            Assert.AreEqual("[6],[-4]", Actual2);

            //#17
            Equation Test3 = new Equation("11x+y+z=11,5x+y+4z=11,-x+2y+2z=-1");
            Test3.EquationParser();
            string Actual3 = string.Join(",", Test3.FindResult());
            Assert.AreEqual("[1],[-2],[2]", Actual3);
        }
    }
}