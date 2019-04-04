using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Order
    {
        List<Product> _Products;
        bool _IsDelivered;
        public List<Product> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
            }
        }
        public bool IsDelivered
        {
            get
            {
                return _IsDelivered;
            }
            set
            {
                if(value==false || value==true)
                    _IsDelivered = value;
                else
                    Console.WriteLine("Bad Report For Delivering");
            }
        }

        public Order(List<Product> products, bool isDelivered)
        {
            this.IsDelivered = isDelivered;
            this.Products = products;
        }

        public float CalculateTotalPrice()
        {
            float totalprice = 0;
            for(int i=0;i<Products.Count;i++)
            {
                totalprice += Products[i].Price;
            }
            return totalprice;
        }
    }
}