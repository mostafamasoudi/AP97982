using System;
using System.Collections.Generic;

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
            List<Product> listOfProduct = new List<Product>();
            foreach(var order in Orders)
            {
                foreach(var product in order.Products)
                {
                    bool exist = false;
                    for(int k=0;k<listOfProduct.Count;k++)
                    foreach(var listofproduct in listOfProduct)
                    {
                        if (product== listofproduct)
                            exist = true;
                    }
                    if (exist == false)
                        listOfProduct.Add(product);
                }
            }
            return listOfProduct;
        }

        public Product MostOrderedProduct()
        {
            List<Product> listOfProduct = ListOfExistProduct();
            int maxNumber = 0;
            int idOfMaxProduct = -1;
            for (int k = 0; k < listOfProduct.Count; k++)
            {
                int count = 0;
                for (int i = 0; i < Orders.Count; i++)
                {
                    for (int j = 0; j < Orders[i].Products.Count; j++)
                    {
                        if (listOfProduct[k] == Orders[i].Products[j])
                            count++;
                    }
                }
                if (count >= maxNumber)
                {
                    maxNumber = count;
                    idOfMaxProduct = k;
                }
            }
            return listOfProduct[idOfMaxProduct];
            
        }

        public List<Order> UndeliveredOrders()
        {
            List<Order> UnDelivered = new List<Order>();
            for (int i = 0; i < Orders.Count; i++)
            {
                if (!Orders[i].IsDelivered)
                    UnDelivered.Add(Orders[i]);
            }
            return UnDelivered;
        }
    }
}