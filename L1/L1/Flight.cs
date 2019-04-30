using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Flight
    {
        //Properties:
        //FlightID: string
        //Airline: Airline
        //Capacity: int
        //Source: string
        //Destination: string
        //FlyDate: DateTime
        public string FlightID;
        public Airline Airline;
        public int Capacity;
        public string Source;
        public string Destination;
        public DateTime FlyDate;

        
        /// <summary>
        /// set properties and add the object to DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="airline"></param>
        /// <param name="capacity"></param>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <param name="dateTime"></param>
        public Flight(string id, Airline airline, int capacity, string source, string dest,
            DateTime dateTime)
        {
            this.FlightID = id;
            this.Airline = airline;
            this.Capacity = capacity;
            this.Source = source;
            this.Destination = dest;
            this.FlyDate = dateTime;
            DB.AddFlight(this);
        }

        public bool IsFull()
        {
            if (Capacity <= 0)
                return true;
            else
                return false;
        }
    }
}
