using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2
{
    public class MyString
    {
        public string myString;

        public MyString(string str)
        {
            this.myString = str;
        }

        public static explicit operator MyString(string v)
            => new MyString(v);

        public static bool operator ==(MyString left, string right)
            => left.myString == right;

        public static bool operator !=(MyString left, string right)
            => left.myString != right;

        public static MyString operator ++(MyString mystr)
        {
            mystr.myString = mystr.myString.ToUpper();
            return mystr;
        }

        public static MyString operator --(MyString mystr)
        {
            mystr.myString = mystr.myString.ToLower();
            return mystr;
        }

        public override bool Equals(object obj)
        {
            MyString mystr;
            string str;
            if(obj is string)
            {
                str = obj as string;
                return str == this.myString;
            }
            else if(obj is MyString)
            {
                mystr = obj as MyString;
                return this.myString == mystr.myString;
            }
            return false;
            
        }

        public static explicit operator string(MyString v)
            => v.myString;

    }
}
