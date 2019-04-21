using System;

namespace A3
{
    public class City
    {
        string _Name = null;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                bool flag = true;
                for(int i=0;i<value.Length;i++)
                {
                    if ((!char.IsLetter(value[i])) && (value[i] != ' '))
                    {
                        Console.WriteLine("Bad Name For City");
                        flag = false;
                        break;
                    }
                }
                if (flag == true)
                    _Name = value;
            }
        }
        public City(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentOutOfRangeException();
            else
                this.Name = name;
        }
    }
}