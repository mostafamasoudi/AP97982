using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Customer
    {
        string _Name;
        City _City;
        List<Order> _Orders;
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
        public City City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }
        public List<Order> Orders
        {
            get
            {
                return _Orders;
            }
            set
            {
                _Orders = value;

            }
        }

        public Customer(string name, City city, List<Order> orders)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException();
            else
                this.Name = name;
            if (city == null)
                throw new ArgumentNullException();
            else
                this.City = city;
            if (orders == null)
                throw new ArgumentNullException();
            else
                this.Orders = orders;
        }
        private List<Product> ListOfExistProduct()
        {
            List<Product> listofproduct = new List<Product>();
            for(int i=0;i<Orders.Count;i++)
            {
                for(int j=0;j<Orders[i].Products.Count;j++)
                {
                    bool exist = false;
                    for(int k=0;k<listofproduct.Count;k++)
                    {
                        if (Orders[i].Products[j]== listofproduct[k])
                            exist = true;
                    }
                    if (exist == false)
                        listofproduct.Add(Orders[i].Products[j]);
                }
            }
            return listofproduct;
        }

        public Product MostOrderedProduct()
        {
            List<Product> listofproduct = ListOfExistProduct();
            int maxnumber = 0;
            int IDofmaxproduct = -1;
            for (int k = 0; k < listofproduct.Count; k++)
            {
                int count = 0;
                for (int i = 0; i < Orders.Count; i++)
                {
                    for (int j = 0; j < Orders[i].Products.Count; j++)
                    {
                        if (listofproduct[k] == Orders[i].Products[j])
                            count++;
                    }
                }
                if (count >= maxnumber)
                {
                    maxnumber = count;
                    IDofmaxproduct = k;
                }
            }
            return listofproduct[IDofmaxproduct];
            
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> undelivered = new List<Order>();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (!Orders[i].IsDelivered)
                    undelivered.Add(Orders[i]);
            }
            return undelivered;
        }
    }
}