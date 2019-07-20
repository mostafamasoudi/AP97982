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
    public class SquareMatrixTests
    {
        [TestMethod()]
        public void DeterminateTest()
        {
            //#7
            SquareMatrix<double> M1 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 5, 3, 5},
                new Vector<double>(3) { 0, -3, 2},
                new Vector<double>(3) { -2, 1, 3}
            };
            Assert.AreEqual(-97, SquareMatrix<double>.Determinate(M1));

            //#8
            SquareMatrix<double> M2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 2, 3, 5},
                new Vector<double>(3) { 4, 6, 10},
                new Vector<double>(3) { -2, 1, 3}
            };
            Assert.AreEqual(0, SquareMatrix<double>.Determinate(M2));

            //#9
            SquareMatrix<double> M3 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2) { 2, 3},
                new Vector<double>(2) { -4, 6}
            };
            Assert.AreEqual(24, SquareMatrix<double>.Determinate(M3));

            //#10
            SquareMatrix<double> M4 = new SquareMatrix<double>(1)
            {
                new Vector<double>(1) { 2}
            };
            Assert.AreEqual(2, SquareMatrix<double>.Determinate(M4));

            //#11
            SquareMatrix<double> M5 = new SquareMatrix<double>(4)
            {
                new Vector<double>(4) {1,3,2,4 },
                new Vector<double>(4) {10,-12,1,0 },
                new Vector<double>(4) {1,7,0,-6 },
                new Vector<double>(4) {-2,3,0,1 }
            };
            Assert.AreEqual(110, SquareMatrix<double>.Determinate(M5));

            //#12
            SquareMatrix<double> M6 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2) { 5.5, 2.1},
                new Vector<double>(2) { 2, 3.4}
            };
            Assert.AreEqual(14.5, SquareMatrix<double>.Determinate(M6));

        }

        [TestMethod()]
        public void InverseTest()
        {
            //#13
            SquareMatrix<double> M1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2) { 4, 7},
                new Vector<double>(2) { 4,8}
            };
            M1 = SquareMatrix<double>.Inverse(M1);
            SquareMatrix<double> M_1 = new SquareMatrix<double>(2)
            {
                new Vector<double>(2) { 2, -1.75},
                new Vector<double>(2) { -1, 1}
            };
            for(int i = 0; i < M1.RowCount; i++)
                for(int j = 0; j < M1.RowCount; j++)
                    Assert.AreEqual(M_1[i, j], M1[i, j]);

            //#14
            SquareMatrix<double> M2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 2,4,8},
                new Vector<double>(3) { 4,2,2},
                new Vector<double>(3) { -2,4,4}
            };
            M2 = SquareMatrix<double>.Inverse(M2);
            SquareMatrix<double> M_2 = new SquareMatrix<double>(3)
            {
                new Vector<double>(3) { 0,0.2,-0.1},
                new Vector<double>(3) { -0.25,0.3,0.35},
                new Vector<double>(3) { 0.25,-0.2,-0.15}
            };
            for (int i = 0; i < M2.RowCount; i++)
                for (int j = 0; j < M2.RowCount; j++)
                    Assert.AreEqual(M_2[i, j], M2[i, j]);
        }
    }
}