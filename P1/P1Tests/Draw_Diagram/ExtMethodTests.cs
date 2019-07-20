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
    public class ExtMethodTests
    {
        [TestMethod()]
        public void FunctionParserTest()
        {
            //#1
            string Func1 = "12x^3-3x^2+x-5";
            Functions Result_Func1= Func1.FunctionParser(0, 0, 0, 0);

            string Exp_Func1_Power= "3,2,1,0";
            string Act_Func1_Power = string.Join(",", Result_Func1.Power.ToArray());
            Assert.AreEqual(Exp_Func1_Power, Act_Func1_Power);

            string Exp_Func1_Const = "12,-3,1,-5";
            string Act_Func1_Const = string.Join(",", Result_Func1.ConstantNumber.ToArray());
            Assert.AreEqual(Exp_Func1_Const, Act_Func1_Const);

            //#2
            string Func2 = "325x^10-x^3-10x^2+x";
            Functions Result_Func2= Func2.FunctionParser(0, 0, 0, 0);

            string Exp_Func2_Power = "10,3,2,1";
            string Act_Func2_Power = string.Join(",", Result_Func2.Power.ToArray());
            Assert.AreEqual(Exp_Func2_Power, Act_Func2_Power);

            string Exp_Func2_Const = "325,-1,-10,1";
            string Act_Func2_Const = string.Join(",", Result_Func2.ConstantNumber.ToArray());
            Assert.AreEqual(Exp_Func2_Const, Act_Func2_Const);

            //#3 معادله غیر استاندار
            string Func3 = "2x^2+4x^1-10+x^4";
            Functions Result_Func3 = Func3.FunctionParser(0, 0, 0, 0);

            string Exp_Func3_Power = "2,1,0,4";
            string Act_Func3_Power = string.Join(",", Result_Func3.Power.ToArray());
            Assert.AreEqual(Exp_Func3_Power, Act_Func3_Power);

            string Exp_Func3_Const = "2,4,-10,1";
            string Act_Func3_Const = string.Join(",", Result_Func3.ConstantNumber.ToArray());
            Assert.AreEqual(Exp_Func3_Const, Act_Func3_Const);

        }
    }
}