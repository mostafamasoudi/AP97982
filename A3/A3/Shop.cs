using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<City> listofcity = new List<City>();
            for(int i=0;i<Customers.Count;i++)
            {
                bool flag = false;
                for(int j=0;j<listofcity.Count;j++)
                {
                    if (Customers[i].City == listofcity[j])
                        flag = true;
                }
                if (!flag)
                    listofcity.Add(Customers[i].City);
            }
            return listofcity;
        }

        public List<Customer> CustomersFromCity(City city)
        {
            List<Customer> customersfromcity = new List<Customer>();
            for(int i=0;i<Customers.Count;i++)
            {
                if (Customers[i].City == city)
                    customersfromcity.Add(Customers[i]);
            }
            return customersfromcity;
        }

        public List<Customer> CustomersWithMostOrders()
        {
            List<Customer> customerswithmostorderds = new List<Customer>();
            int MaxOrder = 0;
            for(int i=0;i<Customers.Count;i++)
            {
                if (Customers[i].Orders.Count > MaxOrder)
                    MaxOrder = Customers[i].Orders.Count;
            }
            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Orders.Count == MaxOrder)
                    customerswithmostorderds.Add(Customers[i]); 
            }
            return customerswithmostorderds;
        }
    }
}