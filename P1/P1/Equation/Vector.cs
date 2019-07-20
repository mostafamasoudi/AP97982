using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    /// <summary>
    /// A vector of numbers. Implement vector addition and multiplication.
    /// </summary>
    /// <typeparam name="_Type"></typeparam>
    public class Vector<_Type> : 
        IEnumerable<_Type>, IEquatable<Vector<_Type>>
        where _Type: IEquatable<_Type>        
    {
        /// <summary>
        /// Vector data
        /// </summary>
        protected readonly _Type[] Data;

        /// <summary>
        /// Add index. Only used for collection initialization.
        /// </summary>
        protected int AddIndex = 0;

        /// <summary>
        /// Vector Size
        /// </summary>
        public int Size => Data.Length;

        /// <summary>
        /// Add method to allow collection initialization.
        /// </summary>
        /// <param name="v"></param>
        public void Add(_Type v)
        {
            Data[AddIndex++] = v;
        }

        /// <summary>
        /// Create a new Vector
        /// </summary>
        /// <param name="length">Vector length</param>
        public Vector(int length)
        {
            this.Data = new _Type[length];
        }


        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="other"></param>
        public Vector(Vector<_Type> other)
            : this(other.Size)
        {
            for(int i=0;i<other.Size;i++)
            {
                other.Data[i] = this.Data[i];
            }
        }

        /// <summary>
        /// Constructor for IEnumerable
        /// </summary>
        /// <param name="list">IEnumerable of _Type</param>
        public Vector(IEnumerable<_Type> list)
            : this(list.Count())
        {
            foreach(var l in list)
                this.Add(l);
        }

        /// <summary>
        /// Accessor for data elements
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public _Type this[int index]
        {
            get => this.Data[index];
            set => this.Data[index] = value;
        }

        /// <summary>
        /// Add two vectors
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>sum of vector 1 and 2</returns>
        public static Vector<_Type> operator +(Vector<_Type> v1, Vector<_Type> v2)
        {
            dynamic left = v1;
            dynamic right = v2;
            Vector<_Type> v3 = new Vector<_Type>(v1.Data.Length);
            try
            {
                for (int i = 0; i < v1.Data.Length; i++)
                {
                    v3.Data[i] = left.Data[i] + right.Data[i];
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("You Cant Plus This Two Vector!");
                throw;
            }
            return v3;
        }

        /// <summary>
        /// Inner product of two vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>Inner product of vector one and two</returns>
        public static _Type operator *(Vector<_Type> v1, Vector<_Type> v2)
        {
            dynamic left = v1;
            dynamic right = v2;
            dynamic multiply = 0;
            try
            {
                for (int i = 0; i < v1.Data.Length; i++)
                {
                    multiply += left.Data[i] * right.Data[i];
                }
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("You Cant Multiply This Two Vector!");
                throw;
            }
            return multiply;
        }
        

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>whether v1 is equal to v2</returns>
        public static bool operator ==(Vector<_Type> v1, Vector<_Type> v2)
        {
            dynamic left ;
            dynamic right ;
            bool retvalue = true;
            if (v1.Size != v2.Size)
            {
                retvalue = false;
                return retvalue;
            }
            for(int i=0;i<v1.Size;i++)
            {
                left = v1.Data[i];
                right = v2.Data[i];
                if (left != right)
                    retvalue = false;
            }
            return retvalue;
        }


        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="v1">vector 1</param>
        /// <param name="v2">vector 2</param>
        /// <returns>v1 not equal to v2</returns>
        public static bool operator !=(Vector<_Type> v1, Vector<_Type> v2)
            => !(v1 == v2);

        /// <summary>
        /// Override Object.Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Whether this object is equal to obj</returns>
        public override bool Equals(object obj)
        {
            Vector<_Type> other = obj as Vector<_Type>;
            return this.Equals(other);
        }

        /// <summary>
        /// Implementing IEquatable interface
        /// </summary>
        /// <param name="other">another vector</param>
        /// <returns>whether other vector is equal to this vector</returns>
        public bool Equals(Vector<_Type> other)
        {
            return this == other;
        }

        public override int GetHashCode()
        {
            int gethashcode = 0;
            dynamic data;
            foreach(var d in this.Data)
            {
                data = d;
                gethashcode ^= data;
            }
            return gethashcode;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[");
            str.Append( string.Join("," ,this.Data));
            str.Append("]");
            return str.ToString();
        }

        public IEnumerator<_Type> GetEnumerator()
        {
            return ((IEnumerable<_Type>)Data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<_Type>)Data).GetEnumerator();
        }
    }
}
