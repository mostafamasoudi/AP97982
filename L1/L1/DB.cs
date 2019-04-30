using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DB
    {
        public static List<Airline> Airlines = new List<Airline>();

        public static List<User> Users = new List<User>();

        public static List<Ticket> Tickets = new List<Ticket>();

        public static List<Flight> Flights = new List<Flight>();

        public static void AddAirline(Airline airline)
        {
            Airlines.Add(airline);
        }

        public static void AddTicket(Ticket ticket)
        {
            Tickets.Add(ticket);
        }

        public static void AddUser(User user)
        {
            Users.Add(user);
        }

        public static void AddFlight(Flight flight)
        {
            Flights.Add(flight);
        }

        public static void DeleteAirline(Airline airline)
        {
            Airlines.Remove(airline);
        }

        public static void DeleteTicket(Ticket ticket)
        {
            Tickets.Remove(ticket);
        }

        public static void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public static void DeleteFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        /// <summary>
        /// returns most expensive ticket
        /// </summary>
        /// <returns></returns>
        public static Ticket MostExpensiveTicket()
        {
            double MaxPrice = 0;
            int ID_MaxPrice = -1;
            for(int i=0;i<Tickets.Count;i++)
            {
                if (Tickets[i].Price > MaxPrice)
                {
                    MaxPrice = Tickets[i].Price;
                    ID_MaxPrice = i;
                }
            }
            return Tickets[ID_MaxPrice];
        }

        /// <summary>
        /// returns airline with most sold tickets
        /// </summary>
        /// <returns></returns>
        public static Airline FavouriteAirline()
        {
            List<int> count = new List<int>(Airlines.Count) { };
            for (int i = 0; i < Tickets.Count;i++)
            {
                if (Tickets[i].IsSold())
                {
                    for(int j=0;j<Airlines.Count;j++)
                    {
                        if (Airlines[j] == Tickets[i].Flight.Airline)
                        {
                            count[j]++;
                            break;
                        }
                    }
                }  
            }
            int maxvalue = 0;
            int idofmaxvalue = -1;
            for(int i=0;i<count.Count;i++)
            {
                if(count[i]>=maxvalue)
                {
                    maxvalue = count[i];
                    idofmaxvalue = i;
                }
            }
            return Airlines[idofmaxvalue];
        }

        /// <summary>
        /// returns amount of money users should pay from their credit accounts
        /// </summary>
        /// <returns></returns>
        public static double UsersDebts()
        {
            double usersdebts = 0;
            for(int i=0;i<Users.Count;i++)
            {
                if(Users[i].Account<=0)
                    usersdebts += Math.Abs(Users[i].Account);
                else
                    usersdebts -= Users[i].Account ;
            }
            return usersdebts;
        }

        public static List<string> ListOfDestination()
        {
            List<string> listofdestination = new List<string>();
            for(int i=0;i<Users.Count;i++)
            {
                for(int j=0;j<Users[i].Tickets.Count;j++)
                {
                    bool flag = true;
                    for(int k=0;k<listofdestination.Count;k++)
                    {
                        if (listofdestination[k] == Users[i].Tickets[j].Flight.Destination)
                            flag = false;
                    }
                    if (flag)
                        listofdestination.Add(Users[i].Tickets[j].Flight.Destination);
                }
            }
            return listofdestination;
        }

        /// <summary>
        /// returns passengers favourite destination
        /// </summary>
        /// <returns></returns>
        public static string FavouriteDestination()
        {
            List<string> listofdestination = ListOfDestination();
            List<int> countofdestination = new List<int>(listofdestination.Count);

            for (int i = 0; i < Users.Count; i++)
            {
                for (int j = 0; j < Users[i].Tickets.Count; j++)
                {
                     for (int z = 0; z < listofdestination.Count; z++)
                     {
                        if (listofdestination[z] == Users[i].Tickets[j].Flight.Destination)
                            countofdestination[z]++;
                     }

                }
            }
            int max = 0;
            int max_ID = -1;
            for(int i=0;i<countofdestination.Count;i++)
            {
                if(countofdestination[i]>=max)
                {
                    max = countofdestination[i];
                    max_ID = i;
                }
            }
            return listofdestination[max_ID];
            
        }


    }
}
