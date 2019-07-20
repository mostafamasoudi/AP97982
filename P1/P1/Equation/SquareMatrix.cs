using System;
using System.Collections.Generic;
using System.IO;

namespace P1
{
    public class SquareMatrix<_Type> : Matrix<_Type>
         where _Type : IEquatable<_Type>
    {
        public SquareMatrix(IEnumerable<Vector<_Type>> rows)
            : base(rows)
        {
        }

        public SquareMatrix(int rowandcolumn) 
            : base(rowandcolumn, rowandcolumn)
        {
        }

        public static SquareMatrix<double> Inverse(SquareMatrix<double> matrix)
        {
            SquareMatrix<double> FinalMatrix = new SquareMatrix<double>(matrix.ColumnCount);
            double Determinate = SquareMatrix<double>.Determinate(matrix);
            if (Determinate == 0)
                throw new DivideByZeroException();
            int Negative = 1;
            for(int i = 0; i < matrix.ColumnCount; i++)
            {
                for(int j = 0; j < matrix.ColumnCount; j++)
                {
                    SquareMatrix<double> NewMatrix = new SquareMatrix<double>(matrix.ColumnCount - 1);
                    int p = 0, q = 0;
                    for (int m = 0; m < matrix.ColumnCount; m++)
                    {
                        q = 0;
                        for (int n = 0; n < matrix.ColumnCount; n++)
                        {
                            if((i != m) && (j != n))
                            {
                                NewMatrix[p, q] = matrix[m, n];
                                q++;
                            }
                        }
                        if (m != i)
                            p++;
                    }
                    FinalMatrix[j , i] =  SquareMatrix<double>.Determinate(NewMatrix) / Determinate;
                }
            }

            for (int i = 0; i < matrix.ColumnCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    FinalMatrix[i, j] *= Negative;
                    Negative *= -1;
                }
                if (FinalMatrix.ColumnCount % 2 == 0)
                    Negative *= -1;
            }
            return FinalMatrix;
        }

        public static double Determinate(SquareMatrix<double> matrix)
        {
            if (matrix.ColumnCount == 2)
                return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);

            if (matrix.ColumnCount == 1)
                return matrix[0, 0];

            double Sum = 0;
            int Negative = 1;
            for(int i = 0; i < matrix.ColumnCount; i++)
            {
                SquareMatrix<double> NewMatrix = new SquareMatrix<double>(matrix.ColumnCount-1);
                int p = 0, q;
                for(int j = 1; j < matrix.ColumnCount; j++)
                {
                    q = 0;
                    for(int k = 0; k < matrix.ColumnCount; k++)
                    {
                        if (k != i)
                        {
                            NewMatrix[p, q] = matrix[j, k];
                            q++;
                        }
                    }
                    p++;
                }
                Sum += Negative * matrix[0, i] * Determinate(NewMatrix);
                Negative *= -1;
            }
            return Sum;
        }
    }
}