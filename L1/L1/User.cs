using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class User
    {
        public string FullName;

        public string NationalID;

        public string PhoneNumber;

        public List<Ticket> Tickets;

        public double Account;

        public User(string fullName, string nationalID, string phoneNumber, double account=0)
        {
            FullName = fullName;
            NationalID = nationalID;
            PhoneNumber = phoneNumber;
            Tickets = new List<Ticket>();
            Account = account;
            DB.AddUser(this);
        }

        /// <summary>
        /// reserve new ticket
        /// do necessary changes on Ticket, Flight, and User properties.
        /// </summary>
        /// <param name="ticket"></param>
        public void Reserve(Ticket ticket)
        {
            if (!ticket.IsSold())
            {
                ticket.Buyer = this;
                ticket.Flight.Capacity--;
                this.Account -= ticket.Price;
            }
        }

        /// <summary>
        /// cancel ticket reservation
        /// do necessary changes on Ticket, Flight, and User properties.
        /// 40% of the ticket price backs to the buyer account
        /// </summary>
        /// <param name="ticket"></param>
        public void Cancel(Ticket ticket)
        {
            this.Account += ticket.Price * 40 / 100;
        }

        /// <summary>
        /// returns tickets with dates between two significant dates
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public List<Ticket> DateFilteredTickets(DateTime startDateTime, DateTime endDateTime)
        {
            List<Ticket> dateFilteredTickets = new List<Ticket>();
            for (int i=0;i<Tickets.Count;i++)
            {
                if (Tickets[i].Flight.FlyDate >= startDateTime && Tickets[i].Flight.FlyDate <= endDateTime)
                {
                    dateFilteredTickets.Add(Tickets[i]);
                }
            }
            return dateFilteredTickets;
        }

        /// <summary>
        /// returns tickets with dates between 18 March, 28 March
        /// </summary>
        /// <returns></returns>
        public List<Ticket> NowruzTickets()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns tickets of a significant airline
        /// </summary>
        /// <param name="airline"></param>
        /// <returns></returns>
        public List<Ticket> AirlineTickets(Airline airline)
        {
            List<Ticket> airlinetickets = new List<Ticket>();
            for(int i=0;i<Tickets.Count;i++)
            {
                if (Tickets[i].Flight.Airline == airline)
                    airlinetickets.Add(Tickets[i]);
            }
            return airlinetickets;
        }

        /// <summary>
        /// returns tickets with a significent route
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        public List<Ticket> RouteTickets(string source, string dest)
        {
            List<Ticket> routetickets = new List<Ticket>();
            for (int i = 0; i < Tickets.Count; i++)
            {
                if (Tickets[i].Flight.Source == source && Tickets[i].Flight.Destination == dest)
                    routetickets.Add(Tickets[i]);
            }
            return routetickets;
        }

    }
}
