using System;
using System.Collections.Generic;

namespace A3
{
    public class Shop
    {
        string _Name;
        List<Customer> _Customers;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException();
                else
                    _Name = value;
            }
        }
        public List<Customer> Customers
        {
            get
            {
                return _Customers;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                else
                    _Customers = value;
            }
        }

        public Shop(string name, List<Customer> customers)
        {
            this.Name = name;
            this.Customers = customers;
        }


        public List<City> CitiesCustomersAreFrom()
        {
            List<City> listOfCity = new List<City>();
            for(int i=0;i<Customers.Count;i++)
            {
                bool flag = false;
                for(int j=0;j<listOfCity.Count;j++)
                {
                    if (Customers[i].City == listOfCity[j])
                        flag = true;
                }
                if (!flag)
                    listOfCity.Add(Customers[i].City);
            }
            return listOfCity;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> customersFromCity = new List<Customer>();
            for(int i=0;i<Customers.Count;i++)
            {
                if (Customers[i].City == city)
                    customersFromCity.Add(Customers[i]);
            }
            return customersFromCity;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            List<Customer> customersWithMostOrderds = new List<Customer>();
            int MaxOrder = 0;
            for(int i=0;i<Customers.Count;i++)
            {
                if (Customers[i].Orders.Count > MaxOrder)
                    MaxOrder = Customers[i].Orders.Count;
            }
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Orders.Count == MaxOrder)
                    customersWithMostOrderds.Add(Customers[i]); 
            }
            return customersWithMostOrderds;
        }
    }
}