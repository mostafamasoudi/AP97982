using System;

namespace A3
{
    public class Product
    {
        private string _Name;
        private float _Price;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException();
                else
                    _Name = value;
            }
        }
        public float Price
        {
            get
            {
                return _Price;
            }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Wrong Price!");
                else
                    _Price = value;
            }
        }

        public Product(string name, float price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}