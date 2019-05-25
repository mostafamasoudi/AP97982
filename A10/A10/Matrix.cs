using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A10
{
    public class Matrix<_Type> :
            IEnumerable<Vector<_Type>>,
            IEquatable<Matrix<_Type>>
        where _Type : IEquatable<_Type>
    {
        public readonly int RowCount;
        public readonly int ColumnCount;

        protected readonly Vector<_Type>[] Rows;
        protected int RowAddIndex = 0;
        
        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            this.Rows = new Vector<_Type>[rowCount];
            for(int i=0;i<rowCount;i++)
            {
                Rows[i]=new Vector<_Type>(columnCount);
            }
        }

        /// <summary>
        /// constructor of Matrix class
        /// </summary>
        /// <param name="rowCount"></param>
        /// <param name="columnCount"></param>
        public Matrix(IEnumerable<Vector<_Type>> rows)
            :this(rows.Count(),rows.First().Size)
        {
            foreach(var r in rows)
                this.Add(r);
        }

        public void Add(Vector<_Type> row)
        {
            this.Rows[RowAddIndex++] = row;
        }

        public Vector<_Type> this[int index]
        {
            get => this.Rows[index];
            set => this.Rows[index] = value;
        }

        public _Type this[int row, int col]
        {
            get => this.Rows[row][col];
            set => this.Rows[row][col] = value;

        }

        /// <summary>
        /// overloading + operator for the class Matrix customly
        /// </summary>
        /// <param name="m1">right hand side operand (type : matrix)</param>
        /// <param name="m2">left hand side operand (type : matrix)</param>
        /// <returns>a matrix as result of the sum</returns>
        public static Matrix<_Type> operator +(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            dynamic m3 = new Matrix<_Type>(m1.RowCount, m2.ColumnCount);
            dynamic first, second;
            try
            {
                if ((m1.RowCount != m2.RowCount) || (m1.ColumnCount != m2.ColumnCount))
                    throw new InvalidOperationException();
                for (int i = 0; i < m1.RowCount; i++)
                {
                    for (int j = 0; j < m1.ColumnCount; j++)
                    {
                        first = m1[i][j];
                        second = m2[i][j];
                        m3[i][j] = first + second;
                    }
                }
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("You Cant Plus This Two Matrix!");
                throw;
            }
            return (Matrix<_Type>)m3;
        }

        /// <summary>
        /// overloading * operator for matrix class
        /// </summary>
        /// <param name="m1">RHS of the operator</param>
        /// <param name="m2">LHS of the operator</param>
        /// <returns></returns>
        public static Matrix<_Type> operator *(Matrix<_Type> m1, Matrix<_Type> m2)
        {
            dynamic m3=new Matrix<_Type>(m1.RowCount,m2.ColumnCount);
            dynamic first, second;
            int sum;
            try
            {
                if (m1.ColumnCount != m2.RowCount)
                    throw new InvalidOperationException();

                for (int i = 0; i < m1.RowCount; i++)
                {
                    for (int j = 0; j < m2.ColumnCount; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < m2.RowCount; k++)
                        {
                            first = m1[i][k];
                            second = m2[k][j];
                            sum += first * second;
                        }
                        m3[i][j] = sum;
                    }
                }
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("You Cant Multiply This Two Matrix!");
                throw;
            }
            return (Matrix<_Type>)m3;
        }

        public static bool operator ==(Matrix<_Type> left,Matrix<_Type> right)
            => left.Equals(right);

        public static bool operator !=(Matrix<_Type> left, Matrix<_Type> right)
            => !left.Equals(right);

        /// <summary>
        /// Get an enumerator that enumerates over elements in a column
        /// </summary>
        /// <param name="col"></param>
        /// <returns>IEnumerable</returns>
        protected IEnumerable<_Type> GetColumnEnumerator(int col)
        {
            return (IEnumerable<_Type>)Rows[col].GetEnumerator();
        }

        protected Vector<_Type> GetColumn(int col) =>
            new Vector<_Type>(GetColumnEnumerator(col));


        public bool Equals(Matrix<_Type> other)
        {
            bool retvalue = true;
            dynamic @this;
            dynamic Other;
            if ((this.RowCount != other.RowCount) || (this.ColumnCount != other.ColumnCount))
            {
                retvalue = false;
                return retvalue;
            }
            for(int i=0; i<other.RowCount; i++)
            {
                for(int j=0;j<other.ColumnCount;j++)
                {
                    @this = this.Rows[i][j];
                    Other = other.Rows[i][j];
                    if (Other != @this)
                        retvalue = false;
                }
            }
            return retvalue;
        }

        public override bool Equals(object obj)
        {
            Matrix<_Type> other = (Matrix<_Type>)obj;
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            int code = 0;
            foreach (var row in this.Rows)
                code ^= row.GetHashCode();

            return code;
        }

        public IEnumerator<Vector<_Type>> GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Vector<_Type>>)Rows).GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[\n");
            for (int i = 0; i < RowCount-1; i++)
                str.Append($"{Rows[i].ToString()},\n");
            str.Append($"{Rows[RowCount-1].ToString()}\n]");
            return str.ToString();
        }
    }
}